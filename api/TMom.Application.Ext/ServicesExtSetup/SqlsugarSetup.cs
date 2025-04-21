using Microsoft.Extensions.DependencyInjection;
using TMom.Domain.Model;
using TMom.Domain.Model.Seed;
using TMom.Infrastructure;
using TMom.Infrastructure.Helper;
using SqlSugar;
using StackExchange.Profiling;
using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.CustomTypeProviders;
using System.Reflection;
using static TMom.Domain.Model.GlobalVars;

namespace TMom.Application.Ext
{
    /// <summary>
    /// SqlSugar 启动服务
    /// </summary>
    public static class SqlsugarSetup
    {
        public static void AddSqlsugarSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // 默认添加主数据库连接
            MainDb.CurrentDbConnId = Appsettings.app(["MainDB"]);

            var mainDB = MyContext.GetMainConnectionDb();

            SnowFlakeSingle.WorkId = Appsettings.app(["SnowWorkId"]).ObjToInt();
            StaticConfig.DynamicExpressionParserType = typeof(DynamicExpressionParser);
            StaticConfig.DynamicExpressionParsingConfig = new ParsingConfig()//用到SqlFunc需要配置这个属性
            {
                CustomTypeProvider = new SqlSugarTypeProvider()
            };

            // 只读库
            // 1.如果存在事务所有操作都走主库，不存在事务 修改、写入、删除走主库，查询操作走只读库
            // 2.HitRate 越大走这个只读库的概率越大
            var listConfig_Readonly = new List<SlaveConnectionConfig>();
            BaseDBConfig.MutiConnectionString.readonlyDbs.ForEach(s =>
            {
                listConfig_Readonly.Add(new SlaveConnectionConfig()
                {
                    HitRate = s.HitRate,
                    ConnectionString = s.Connection
                });
            });

            // 单例 + 多租户方式来处理多库事务、AOP日志
            services.AddSingleton<ISqlSugarClient>(o =>
            {
                return new SqlSugarScope(new ConnectionConfig()
                {
                    ConfigId = MainDb.CurrentDbConnId.ToLower(),
                    ConnectionString = mainDB.Connection,
                    DbType = (DbType)mainDB.DbType,
                    IsAutoCloseConnection = true,
                    AopEvents = new AopEvents
                    {
                        OnLogExecuting = (sql, p) =>
                        {
                            if (Appsettings.app(["AppSettings", "SqlAOP", "Enabled"]).ObjToBool())
                            {
                                if (Appsettings.app(["AppSettings", "SqlAOP", "OutToLogFile", "Enabled"]).ObjToBool())
                                {
                                    Parallel.For(0, 1, e =>
                                    {
                                        MiniProfiler.Current.CustomTiming("SQL：", GetParas(p) + "【SQL语句】：" + sql);
                                        LogLock.OutSql2Log("SqlLog", [GetParas(p), "【SQL语句】：" + sql]);
                                    });
                                }
                                if (Appsettings.app(["AppSettings", "SqlAOP", "OutToConsole", "Enabled"]).ObjToBool())
                                {
                                    ConsoleHelper.WriteColorLine(RenderSql(p, sql), ConsoleColor.Cyan);
                                }
                            }
                        },
                    },
                    MoreSettings = new ConnMoreSettings()
                    {
                        //IsWithNoLockQuery = true,
                        SqlServerCodeFirstNvarchar = true,
                        PgSqlIsAutoToLower = true,
                        IsAutoRemoveDataCache = true
                    },
                    SlaveConnectionConfigs = listConfig_Readonly,
                    // 自定义特性
                    ConfigureExternalServices = new ConfigureExternalServices()
                    {
                        EntityService = (property, column) =>
                        {
                            if (column.IsPrimarykey && property.PropertyType == typeof(int))
                            {
                                column.IsIdentity = true;
                            }
                            //高版C#写法 支持string?和string
                            if (new NullabilityInfoContext().Create(property).WriteState is NullabilityState.Nullable)
                            {
                                column.IsNullable = true;
                            }
                        },
                        EntityNameService = (property, column) =>
                        {
                            // 表名驼峰转下划线方法
                            column.DbTableName = UtilMethods.ToUnderLine(column.DbTableName);
                        }
                    },
                    InitKeyType = InitKeyType.Attribute
                });
            });
        }

        //扩展类型
        public class SqlSugarTypeProvider : DefaultDynamicLinqCustomTypeProvider
        {
            public override HashSet<Type> GetCustomTypes()
            {
                var customTypes = base.GetCustomTypes();
                customTypes.Add(typeof(SqlFunc));//识别SqlFunc
                return customTypes;
            }
        }

        #region 私有方法

        private static string GetWholeSql(SugarParameter[] paramArr, string sql)
        {
            foreach (var param in paramArr)
            {
                sql.Replace(param.ParameterName, param.Value.ObjToString());
            }

            return sql;
        }

        private static string GetParas(SugarParameter[] pars)
        {
            if (pars.Length == 0) return string.Empty;
            string key = "【SQL参数】：";
            foreach (var param in pars)
            {
                key += $"{param.ParameterName}:{param.Value}\n";
            }

            return key;
        }

        private static string RenderSql(SugarParameter[] p, string sql)
        {
            if (p.Length == 0)
                return string.Join("\r\n", new string[] { "--------", "【SQL语句】：" + GetWholeSql(p, sql) });
            else
                return string.Join("\r\n", new string[] { "--------", GetParas(p), "【SQL语句】：" + GetWholeSql(p, sql) });
        }

        #endregion 私有方法
    }
}