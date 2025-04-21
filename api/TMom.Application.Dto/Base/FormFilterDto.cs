namespace TMom.Application.Dto
{
    /// <summary>
    /// 前端header中传递过来的form信息
    /// </summary>
    public class FormFilterDto
    {
        public List<FormFilterType> form { get; set; } = new List<FormFilterType>();
    }

    public class FormFilterType
    {
        /// <summary>
        /// 字段
        /// </summary>
        public string field { get; set; }

        /// <summary>
        /// 表单类型
        /// </summary>
        public string type { get; set; }
    }

    public class MigrationDto
    {
        public List<string> tblNames { get; set; } = new List<string>();
    }
}