using TMom.Infrastructure.Helper;

namespace TMom.Infrastructure.Common
{
    public static class SetSysStaticInfo
    {
        public static void PrepareStaticVal(string name, string soluPath, string wwwrootPath)
        {
            soluPath = soluPath.TrimEnd('\\');
            int ind = soluPath.LastIndexOf('\\');
            soluPath = soluPath.Substring(0, ind);
            SystemInfo.soluPath = soluPath;
            SystemInfo.EntityPath = $@"{soluPath}\TMom.Domain.Model\Entity";
            SystemInfo.IServicePath = $@"{soluPath}\TMom.Application.Service\IService";
            SystemInfo.ServicePath = $@"{soluPath}\TMom.Application.Service\Service";
            SystemInfo.IRepositoryPath = $@"{soluPath}\TMom.Domain.IRepository";
            SystemInfo.RepositoryPath = $@"{soluPath}\TMom.Infrastructure.Repository";
            SystemInfo.VuePath = Appsettings.app(new string[] { "VueConfig", "ViewPath" });

            // 文件路径, 开发环境 存放在wwwroot下, 生产环境会配置Nginx
            MomFilePath.BaseFilesPath = wwwrootPath;
        }
    }

    #region 系统相关信息

    /// <summary>
    /// 系统相关信息
    /// </summary>
    public static class SystemInfo
    {
        /// <summary>
        /// Vue 文件路径
        /// </summary>
        public static string VuePath = "";

        /// <summary>
        /// 解决方案所在路径
        /// </summary>
        public static string soluPath = "";

        /// <summary>
        /// 实体所在路径
        /// </summary>
        public static string EntityPath = "";

        /// <summary>
        /// IService层所在路径
        /// </summary>
        public static string IServicePath = "";

        /// <summary>
        /// Service层所在路径
        /// </summary>
        public static string ServicePath = "";

        /// <summary>
        /// IRepository所在路径
        /// </summary>
        public static string IRepositoryPath = "";

        /// <summary>
        /// Repository所在路径
        /// </summary>
        public static string RepositoryPath = "";

        /// <summary>
        /// 用户默认密码
        /// </summary>
        public const string defPwd = "123456";
    }

    /// <summary>
    /// 路由变量前缀配置
    /// </summary>
    public static class RoutePrefix
    {
        /// <summary>
        /// 前缀名
        /// 如果不需要，尽量留空，不要修改
        /// 除非一定要在所有的 api 前统一加上特定前缀
        /// </summary>
        public const string Name = "";
    }

    #endregion 系统相关信息
}