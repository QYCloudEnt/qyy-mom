namespace TMom.Domain.Model
{
    /// <summary>
    /// 所需分页参数
    /// </summary>
    public class PaginationModel
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int pageIndex { get; set; } = 1;

        /// <summary>
        /// 每页大小
        /// </summary>
        public int pageSize { get; set; } = 10;

        /// <summary>
        /// 排序字段(例如:id desc, time asc)
        /// </summary>
        public string orderByFileds { get; set; }

        /// <summary>
        /// 查询条件( 例如:id = 1 and name = 小明)
        /// </summary>
        public string conditions { get; set; }
    }
}