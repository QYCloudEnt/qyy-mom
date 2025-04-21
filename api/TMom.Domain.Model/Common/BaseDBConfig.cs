using TMom.Domain.Model.Seed;
using TMom.Infrastructure;
using SqlSugar;
using System.Reflection;

namespace TMom.Domain.Model
{
    public class BaseDBConfig
    {
        /// <summary>
        /// 前者: 所有数据库配置, 后者: 只读库配置
        /// </summary>
        public static (List<MutiDBOperate> allDbs, List<MutiDBOperate> readonlyDbs) MutiConnectionString => MutiInitConn();

        /// <summary>
        /// 生成表
        /// </summary>
        /// <param name="dbConn"></param>
        /// <param name="dbType"></param>
        /// <param name="configId"></param>
        public static void InitBusinessDatabaseTable(string dbConn, DbType dbType, string configId)
        {
            // 生成数据库
            var db = DBHelper.GetBusinessDB(dbConn, dbType, configId);
            db.DbMaintenance.CreateDatabase();

            var list = DBSeed.GetTableEntityType();
            var modelTypes = list.ToList();
            modelTypes.ForEach(t =>
            {
                var tblName = DBSeed.GetRealTableName(t);
                if (!string.IsNullOrEmpty(tblName) && !db.DbMaintenance.IsAnyTable(tblName))
                {
                    Console.WriteLine(tblName);
                    if (t.GetCustomAttributes().Any(x => x is SplitTableAttribute))
                    {
                        if (!DBSeed.IsAnySplitTable(db, t))
                        {
                            db.CodeFirst.SplitTables().InitTables(t);
                        }
                    }
                    else
                    {
                        db.CodeFirst.InitTables(t);
                    }
                }
            });
        }

        private static string DifDBConnOfSecurity(params string[] conn)
        {
            foreach (var item in conn)
            {
                try
                {
                    if (File.Exists(item))
                    {
                        return File.ReadAllText(item).Trim();
                    }
                }
                catch (System.Exception) { }
            }

            return conn[conn.Length - 1];
        }

        /// <summary>
        /// 获取数据库链接配置
        /// </summary>
        /// <returns>前者: 所有数据库配置, 后者: 只读库配置</returns>
        public static (List<MutiDBOperate>, List<MutiDBOperate>) MutiInitConn()
        {
            List<MutiDBOperate> listdatabase = Appsettings.app<MutiDBOperate>("DBS")
                .Where(i => i.Enabled).ToList();
            foreach (var i in listdatabase)
            {
                SpecialDbString(i);
            }
            List<MutiDBOperate> listdatabaseSimpleDB = new List<MutiDBOperate>();//单库
            List<MutiDBOperate> listdatabaseReadonlyDB = new List<MutiDBOperate>();//只读库

            // 单库，只保留一个
            if (!Appsettings.app(new string[] { "MutiDBEnabled" }).ObjToBool())
            {
                if (listdatabase.Count == 1)
                {
                    return (listdatabase, listdatabaseReadonlyDB);
                }
                else
                {
                    var dbFirst = listdatabase.FirstOrDefault(d => d.ConnId == Appsettings.app(new string[] { "MainDB" }).ObjToString());
                    if (dbFirst == null)
                    {
                        dbFirst = listdatabase.FirstOrDefault();
                    }
                    listdatabaseSimpleDB.Add(dbFirst);
                    return (listdatabaseSimpleDB, listdatabaseReadonlyDB);
                }
            }

            // 开启了读写分离，获取只读库
            if (Appsettings.app(new string[] { "CQRSEnabled" }).ObjToBool())
            {
                if (listdatabase.Count > 1)
                {
                    listdatabaseReadonlyDB = listdatabase.Where(d => d.IsReadonlyDb).ToList();
                }
            }

            return (listdatabase, listdatabaseReadonlyDB);
        }

        /// <summary>
        /// 定制Db字符串
        /// 目的是保证安全：优先从本地txt文件获取，若没有文件则从appsettings.json中获取
        /// </summary>
        /// <param name="mutiDBOperate"></param>
        /// <returns></returns>
        private static MutiDBOperate SpecialDbString(MutiDBOperate mutiDBOperate)
        {
            if (mutiDBOperate.DbType == DataBaseType.Sqlite)
            {
                mutiDBOperate.Connection = $"DataSource=" + Path.Combine(Environment.CurrentDirectory, mutiDBOperate.Connection);
            }
            else if (mutiDBOperate.DbType == DataBaseType.SqlServer)
            {
                mutiDBOperate.Connection = DifDBConnOfSecurity(@"D:\my-file\dbCountPsw1_SqlserverConn.txt", mutiDBOperate.Connection);
            }
            else if (mutiDBOperate.DbType == DataBaseType.MySql)
            {
                mutiDBOperate.Connection = DifDBConnOfSecurity(@"D:\my-file\dbCountPsw1_MySqlConn.txt", mutiDBOperate.Connection);
            }
            else if (mutiDBOperate.DbType == DataBaseType.Oracle)
            {
                mutiDBOperate.Connection = DifDBConnOfSecurity(@"D:\my-file\dbCountPsw1_OracleConn.txt", mutiDBOperate.Connection);
            }

            return mutiDBOperate;
        }
    }

    public enum DataBaseType
    {
        MySql = 0,
        SqlServer = 1,
        Sqlite = 2,
        Oracle = 3,
        PostgreSQL = 4,
        Dm = 5,
        Kdbndp = 6,
        Oscar = 7,
        MySqlConnector = 8,
        Access = 9,
        OpenGauss = 10,
        QuestDB = 11,
        HG = 12,
        ClickHouse = 13,
        GBase = 14,
        Odbc = 15,
        OceanBaseForOracle = 16,
        TDengine = 17,
        GaussDB = 18,
        OceanBase = 19,
        Tidb = 20,
        Vastbase = 21,
        PolarDB = 22,
        Custom = 900
    }

    public class MutiDBOperate
    {
        /// <summary>
        /// 连接启用开关
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 连接ID
        /// </summary>
        public string ConnId { get; set; }

        /// <summary>
        /// 只读库执行级别，越大越先执行
        /// </summary>
        public int HitRate { get; set; }

        /// <summary>
        /// 是否只读库, 默认false
        /// </summary>
        public bool IsReadonlyDb { get; set; } = false;

        /// <summary>
        /// 连接字符串
        /// </summary>
        public string Connection { get; set; }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public DataBaseType DbType { get; set; }
    }
}