using TMom.Domain.Model.Entity;
using TMom.Infrastructure;
using TMom.Infrastructure.Common;
using TMom.Infrastructure.Helper;
using Newtonsoft.Json;
using SqlSugar;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;
using static TMom.Domain.Model.GlobalVars;

namespace TMom.Domain.Model.Seed
{
    public class DBSeed
    {
        private static string SeedDataFolder = "TMom.Data.json/{0}.tsv";

        /// <summary>
        /// 异步添加种子数据
        /// </summary>
        /// <param name="myContext"></param>
        /// <param name="WebRootPath"></param>
        /// <param name="_sqlSugarClient"></param>
        /// <returns></returns>
        public static async Task SeedAsync(MyContext myContext, string WebRootPath, ISqlSugarClient _sqlSugarClient)
        {
            try
            {
                if (string.IsNullOrEmpty(WebRootPath))
                {
                    throw new Exception("获取wwwroot路径时，异常！");
                }

                SeedDataFolder = Path.Combine(WebRootPath, SeedDataFolder);

                Console.WriteLine("***************** TMom DataBase Set *****************");
                Console.WriteLine($"Is multi-DataBase: {Appsettings.app(["MutiDBEnabled"])}");
                Console.WriteLine($"Is CQRS: {Appsettings.app(["CQRSEnabled"])}");
                Console.WriteLine();
                Console.WriteLine($"Master DB ConId: {MyContext.ConnId}");
                Console.WriteLine($"Master DB Type: {MyContext.DbType}");
                Console.WriteLine($"Master DB ConnectString: {MyContext.ConnectionString}");
                Console.WriteLine();
                if (Appsettings.app(["MutiDBEnabled"]).ObjToBool())
                {
                    var slaveIndex = 0;
                    BaseDBConfig.MutiConnectionString.allDbs.Where(x => x.ConnId != MainDb.CurrentDbConnId && !x.IsReadonlyDb).ToList().ForEach(m =>
                    {
                        slaveIndex++;
                        Console.WriteLine($"Other_{slaveIndex} DB ID: {m.ConnId}");
                        Console.WriteLine($"Other_{slaveIndex} DB Type: {m.DbType}");
                        Console.WriteLine($"Other_{slaveIndex} DB ConnectString: {m.Connection}");
                        Console.WriteLine($"--------------------------------------");
                    });
                }
                if (Appsettings.app(["CQRSEnabled"]).ObjToBool())
                {
                    var slaveIndex = 0;
                    BaseDBConfig.MutiConnectionString.readonlyDbs.Where(x => x.IsReadonlyDb && x.ConnId != MainDb.CurrentDbConnId).ToList().ForEach(m =>
                    {
                        slaveIndex++;
                        Console.WriteLine($"Readonly_{slaveIndex} DB ID: {m.ConnId}");
                        Console.WriteLine($"Readonly_{slaveIndex} DB Type: {m.DbType}");
                        Console.WriteLine($"Readonly_{slaveIndex} DB ConnectString: {m.Connection}");
                        Console.WriteLine($"Readonly_{slaveIndex} DB HitRate: {m.HitRate}");
                        Console.WriteLine($"--------------------------------------");
                    });
                }

                Console.WriteLine();

                // 创建数据库
                Console.WriteLine($"Create Database(The Db Id: {MyContext.ConnId})...");

                if (MyContext.DbType != DbType.Oracle)
                {
                    myContext.Db.DbMaintenance.CreateDatabase();
                    ConsoleHelper.WriteSuccessLine($"Database created successfully!");
                }
                else
                {
                    //Oracle 数据库不支持该操作
                    ConsoleHelper.WriteSuccessLine($"Oracle 数据库不支持该操作，可手动创建Oracle数据库!");
                }

                // 创建数据库表，遍历指定命名空间下的class，
                // 注意不要把其他命名空间下的也添加进来。
                Console.WriteLine("Create Tables...");
                UtilTableSeed(myContext.Db);
                ConsoleHelper.WriteSuccessLine($"Tables created successfully!");
                Console.WriteLine();

                if (Appsettings.app(["AppSettings", "SeedDBDataEnabled"]).ObjToBool())
                {
                    JsonSerializerSettings setting = new JsonSerializerSettings();
                    JsonConvert.DefaultSettings = new Func<JsonSerializerSettings>(() =>
                    {
                        //日期类型默认格式化处理
                        setting.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                        setting.DateFormatString = "yyyy-MM-dd HH:mm:ss";

                        //空值处理
                        setting.NullValueHandling = NullValueHandling.Ignore;

                        //高级用法九中的Bool类型转换 设置
                        //setting.Converters.Add(new BoolConvert("是,否"));

                        return setting;
                    });

                    Console.WriteLine($"Seeding database data (The Db Id:{MyContext.ConnId})...");

                    #region SysUser

                    if (!await myContext.Db.Queryable<SysUser>().AnyAsync())
                    {
                        var data = JsonConvert.DeserializeObject<List<SysUser>>(FileHelper.ReadFile(string.Format(SeedDataFolder, "SysUser"), Encoding.UTF8), setting);

                        myContext.GetEntityDB<SysUser>().InsertRange(data);
                        Console.WriteLine("Table:sys_user created success!");
                    }
                    else
                    {
                        Console.WriteLine("Table:sys_user already exists...");
                    }

                    #endregion SysUser

                    #region SysRole

                    if (!await myContext.Db.Queryable<SysRole>().AnyAsync())
                    {
                        var data = JsonConvert.DeserializeObject<List<SysRole>>(FileHelper.ReadFile(string.Format(SeedDataFolder, "SysRole"), Encoding.UTF8), setting);

                        myContext.GetEntityDB<SysRole>().InsertRange(data);
                        Console.WriteLine("Table:sys_role created success!");
                    }
                    else
                    {
                        Console.WriteLine("Table:sys_role already exists...");
                    }

                    #endregion SysRole

                    #region SysUserRole

                    if (!await myContext.Db.Queryable<SysUserRole>().AnyAsync())
                    {
                        var data = JsonConvert.DeserializeObject<List<SysUserRole>>(FileHelper.ReadFile(string.Format(SeedDataFolder, "SysUserRole"), Encoding.UTF8), setting);

                        myContext.GetEntityDB<SysUserRole>().InsertRange(data);
                        Console.WriteLine("Table:sys_user_role created success!");
                    }
                    else
                    {
                        Console.WriteLine("Table:sys_user_role already exists...");
                    }

                    #endregion SysUserRole

                    #region SysMenu

                    if (!await myContext.Db.Queryable<SysMenu>().AnyAsync())
                    {
                        var data = JsonConvert.DeserializeObject<List<SysMenu>>(FileHelper.ReadFile(string.Format(SeedDataFolder, "SysMenu"), Encoding.UTF8), setting);

                        myContext.GetEntityDB<SysMenu>().InsertRange(data);
                        Console.WriteLine("Table:sys_menu created success!");
                    }
                    else
                    {
                        Console.WriteLine("Table:sys_menu already exists...");
                    }

                    #endregion SysMenu

                    #region SysRoleMenu

                    if (!await myContext.Db.Queryable<SysRoleMenu>().AnyAsync())
                    {
                        var data = JsonConvert.DeserializeObject<List<SysRoleMenu>>(FileHelper.ReadFile(string.Format(SeedDataFolder, "SysRoleMenu"), Encoding.UTF8), setting);

                        myContext.GetEntityDB<SysRoleMenu>().InsertRange(data);
                        Console.WriteLine("Table:sys_role_menu created success!");
                    }
                    else
                    {
                        Console.WriteLine("Table:sys_role_menu already exists...");
                    }

                    #endregion SysRoleMenu

                    #region DataDic

                    if (!await myContext.Db.Queryable<DataDic>().AnyAsync())
                    {
                        var data = JsonConvert.DeserializeObject<List<DataDic>>(FileHelper.ReadFile(string.Format(SeedDataFolder, "DataDic"), Encoding.UTF8), setting);

                        myContext.GetEntityDB<DataDic>().InsertRange(data);
                        Console.WriteLine("Table:dev_data_dic created success!");
                    }
                    else
                    {
                        Console.WriteLine("Table:dev_data_dic already exists...");
                    }

                    #endregion DataDic

                    List<InitDbDto> initDbList = new List<InitDbDto>();

                    if (initDbList.Any())
                    {
                        foreach (var item in initDbList)
                        {
                            BaseDBConfig.InitBusinessDatabaseTable(item.DbConn, (DbType)item.DbType.Value, item.Code);
                        }
                    }

                    ConsoleHelper.WriteSuccessLine($"Done seeding database!");
                }

                Console.WriteLine();
            }
            catch (Exception ex)
            {
                //$"1、若是Mysql,生成的数据库字段字符集可能不是utf8的，手动修改下. 或者删掉数据库，在连接字符串后加上CharSet = UTF8mb4，重新生成数据库. \n" +
                //    $"2、若是Oracle,注意Id是Oracle的关键字，可以修改下根实体类：RootEntity.cs；\n" +
                //    $"注意可能Sqlsugar的特性可能不适合，可能会出现特别的方法不支持问题，比如：ColumnDataType = 'nvarchar'，自行批量替换处理，改成varchar；\n" +
                //    $"若还不行，可能无法自动创建数据库，自己先手动创建数据库；
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 获取所有表的类型
        /// </summary>
        /// <returns></returns>
        public static List<Type> GetTableEntityType()
        {
            var path = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;
            var referencedAssemblies = Directory.GetFiles(path, "TMom.Domain.Model.dll").Select(Assembly.LoadFrom).ToArray();
            var modelTypes = referencedAssemblies
                .SelectMany(a => a.DefinedTypes)
                .Select(type => type.AsType())
                .Where(x => x.IsClass && x.Namespace != null && x.Namespace.Contains("TMom.Domain.Model.Entity"))
                .ToList();
            return modelTypes;
        }

        /// <summary>
        /// 基础信息表生成
        /// </summary>
        public static void UtilTableSeed(SqlSugarScope sqlSugar)
        {
            var modelTypes = GetTableEntityType();
            var utilTables = modelTypes.ToList();
            utilTables.ForEach(t =>
            {
                var tblName = GetRealTableName(t);
                if (!string.IsNullOrEmpty(tblName) && !sqlSugar.DbMaintenance.IsAnyTable(tblName))
                {
                    if (t.GetCustomAttributes().Any(x => x is SplitTableAttribute))
                    {
                        if (!IsAnySplitTable(sqlSugar, t))
                        {
                            sqlSugar.CodeFirst.SplitTables().InitTables(t);
                            Console.WriteLine($"Table:{tblName} created success!");
                        }
                    }
                    else
                    {
                        sqlSugar.CodeFirst.InitTables(t);
                        Console.WriteLine($"Table:{tblName} created success!");
                    }
                }
            });
        }

        /// <summary>
        /// 根据实体类找到真正的表名(全部下划线命名方式)
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string? GetRealTableName(Type t)
        {
            var tblName = t.GetCustomAttribute<SugarTable>()?.TableName;
            if (string.IsNullOrWhiteSpace(tblName))
            {
                tblName = UtilMethods.ToUnderLine(t.Name);
            }
            return tblName;
        }

        /// <summary>
        /// 当前数据库是否已存在某个分表
        /// </summary>
        /// <param name="sqlSugar"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsAnySplitTable(SqlSugarScope sqlSugar, Type t)
        {
            bool isAny = false;
            // 动态传递泛型
            if (t.IsClass && !t.IsAbstract)
            {
                // SplitHelper方法有重载
                MethodInfo? method = sqlSugar.GetType()
                                             .GetMethods()
                                             .FirstOrDefault(x => x.Name == "SplitHelper" && x.ReturnType == typeof(SplitTableContext));
                method = method?.MakeGenericMethod(t);
                var result = (SplitTableContext?)method?.Invoke(sqlSugar, null);
                if (result != null)
                {
                    isAny = result.GetTables().Any();
                }
            }
            return isAny;
        }

        /// <summary>
        /// 当前数据库是否已存在某个分表
        /// </summary>
        /// <param name="sqlSugar"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsAnySplitTable(SqlSugarScopeProvider sqlSugar, Type t)
        {
            bool isAny = false;
            // 动态传递泛型
            if (t.IsClass && !t.IsAbstract)
            {
                // SplitHelper方法有重载
                MethodInfo? method = sqlSugar.GetType()
                                             .GetMethods()
                                             .FirstOrDefault(x => x.Name == "SplitHelper" && x.ReturnType == typeof(SplitTableContext));
                method = method?.MakeGenericMethod(t);
                var result = (SplitTableContext?)method?.Invoke(sqlSugar, null);
                if (result != null)
                {
                    isAny = result.GetTables().Any();
                }
            }
            return isAny;
        }

        public class InitDbDto
        {
            public string Code { get; set; }

            public string DbConn { get; set; }

            public int? DbType { get; set; }
        }
    }
}