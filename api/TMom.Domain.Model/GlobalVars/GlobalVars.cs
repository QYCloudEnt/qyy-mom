using TMom.Infrastructure;

namespace TMom.Domain.Model
{
    /// <summary>
    /// 全局静态变量
    /// </summary>
    public static class GlobalVars
    {
        #region 权限变量配置

        /// <summary>
        /// 权限变量配置
        /// </summary>
        public static class Permissions
        {
            public const string Name = "Permission";

            /// <summary>
            /// 测试网关授权
            /// 账号：test
            /// 密码：test
            /// </summary>
            public const string GWName = "GW";

            /// <summary>
            /// 当前项目是否启用IDS4权限方案
            /// true：表示启动IDS4
            /// false：表示使用JWT
            public static bool IsUseIds4 = false;
        }

        #endregion 权限变量配置

        #region Redis

        /// <summary>
        /// Redis全局Key
        /// </summary>
        public static class RedisGlobalKey
        {
            /// <summary>
            /// 所有的用户基本信息列表, 包含 Id、Code、Name
            /// </summary>
            public const string AllUserList = "AllUserList";

            /// <summary>
            /// 所有db信息
            /// </summary>
            public const string AllDbList = "AllDbList";

            /// <summary>
            /// 所有数据字典
            /// </summary>
            public const string AllDataDic = "AllDataDic";
        }

        public static class RedisHashField
        {
            public const string UserInfo = "UserInfo";
        }

        #endregion Redis

        #region DB

        /// <summary>
        /// 主库
        /// </summary>
        public static class MainDb
        {
            /// <summary>
            /// 当前主库
            /// </summary>
            public static string CurrentDbConnId = "MainDB";
        }

        #endregion DB

        #region vue模板

        public static class vueTemp
        {
            /// <summary>
            /// 查询表格
            /// </summary>
            public const string searchTable = "searchTable";

            /// <summary>
            /// 查询表格(有详情页)
            /// </summary>
            public const string searchTableHasDetail = "searchTableHasDetail";

            /// <summary>
            /// 树状表格
            /// </summary>
            public const string treeTable = "treeTable";

            /// <summary>
            /// 左右分隔
            /// </summary>
            public const string leftAndRightSplit = "leftAndRightSplit";
        }

        #endregion vue模板
    }
}