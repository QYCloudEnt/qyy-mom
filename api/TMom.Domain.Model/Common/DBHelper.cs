using TMom.Infrastructure;
using TMom.Infrastructure.Helper;
using SqlSugar;
using System.Reflection;
using static TMom.Domain.Model.GlobalVars;

namespace TMom.Domain.Model
{
    public static class DBHelper
    {
        private static SqlSugarScope sqlSugarClient => AutofacContainer.Resolve<ISqlSugarClient>() as SqlSugarScope;

        /// <summary>
        /// 获取DB
        /// </summary>
        /// <param name="dbConn"></param>
        /// <param name="dbType"></param>
        /// <param name="configId">数据库唯一名</param>
        /// <param name="timeOut">超时时间, 默认30秒</param>
        /// <returns></returns>
        public static SqlSugarScopeProvider GetBusinessDB(string dbConn, DbType dbType, string configId, int timeOut = 30)
        {
            SqlSugarScope mainDb = sqlSugarClient;
            configId = configId.ToLower();
            if (!mainDb.IsAnyConnection(configId))
            {
                mainDb.AddConnection(new ConnectionConfig()
                {
                    ConfigId = configId,
                    ConnectionString = dbConn,
                    DbType = dbType,
                    IsAutoCloseConnection = true,
                    MoreSettings = new ConnMoreSettings()
                    {
                        IsWithNoLockQuery = true,
                        SqlServerCodeFirstNvarchar = true,
                        PgSqlIsAutoToLower = true,
                        IsAutoRemoveDataCache = true
                    },
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
                                        LogLock.OutSql2Log("SqlLog", [$"业务库({configId})", GetParas(p), $"【SQL语句】：" + sql]);
                                    });
                                }
                                if (Appsettings.app(["AppSettings", "SqlAOP", "OutToConsole", "Enabled"]).ObjToBool())
                                {
                                    ConsoleHelper.WriteColorLine(RenderSql(p, sql, configId), ConsoleColor.Cyan);
                                }
                            }
                        },
                    },
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
            }
            // 获取的子对象也是线程安全
            var db = mainDb.GetConnectionScope(configId);
            db.Ado.CommandTimeOut = timeOut;
            return db;
        }

        /// <summary>
        /// 获取非主库Db(必须要先配置在appsetting.json中)
        /// </summary>
        /// <param name="configId"></param>
        /// <param name="timeOut">超时时间, 默认30秒</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static SqlSugarScopeProvider GetDb(string configId, int timeOut = 30)
        {
            configId = configId.ToLower();
            var slaveDb = BaseDBConfig.MutiConnectionString.allDbs
                .FirstOrDefault(x => x.ConnId.ToLower() == configId && x.ConnId != MainDb.CurrentDbConnId);
            if (slaveDb == null) throw new CustomFailRequestException($"没有获取到Db信息! 错误的configId: {configId}");
            return GetBusinessDB(slaveDb.Connection, (DbType)slaveDb.DbType, configId, timeOut);
        }

        /// <summary>
        /// 测试数据库连接是否成功
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="dbType"></param>
        /// <returns></returns>
        public static bool TestDBConn(string conn, int dbType)
        {
            bool isCanConn = true;
            SqlSugarClient sqlSugar = new SqlSugarClient(new ConnectionConfig()
            {
                DbType = (DbType)dbType,
                ConnectionString = conn,
                IsAutoCloseConnection = true,
            });
            try
            {
                sqlSugar.Open();
            }
            catch (Exception)
            {
                isCanConn = false;
            }
            finally
            {
                sqlSugar.Close();
                sqlSugar.Dispose();
            }
            return isCanConn;
        }

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
            string key = "【SQL参数】：";
            foreach (var param in pars)
            {
                key += $"{param.ParameterName}:{param.Value}\n";
            }

            return key;
        }

        private static string RenderSql(SugarParameter[] p, string sql, string configId)
        {
            if (p.Length == 0)
                return string.Join("\r\n", new string[] { "--------", $"库({configId})", "【SQL语句】：" + GetWholeSql(p, sql) });
            else
                return string.Join("\r\n", new string[] { "--------", $"库({configId})", GetParas(p), $"【SQL语句】：" + GetWholeSql(p, sql) });
        }
    }
}