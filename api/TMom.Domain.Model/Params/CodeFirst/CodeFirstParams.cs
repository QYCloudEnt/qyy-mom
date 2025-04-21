namespace TMom.Domain.Model.Params
{
    public class CodeFirstParams
    {
        /// <summary>
        /// 文件夹名称
        /// </summary>
        public string fileName { get; set; }

        public string? connID { get; set; }

        public bool createVue { get; set; }

        /// <summary>
        /// vue模板
        /// </summary>
        public string? vueTemplate { get; set; }

        public string? menuName { get; set; }

        /// <summary>
        /// 上级菜单Id
        /// </summary>
        public int parentId { get; set; }

        public string? icon { get; set; }

        public string[] tableNames { get; set; }
    }
}