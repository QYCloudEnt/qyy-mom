namespace TMom.Domain.Model
{
    /// <summary>
    /// 通用分页信息类
    /// </summary>
    public class PageModel<T>
    {
        /// <summary>
        /// 返回数据
        /// </summary>
        public List<T> list { get; set; }

        /// <summary>
        /// 分页信息
        /// </summary>
        public pageInfo pagination { get; set; }
    }

    public class pageInfo
    {
        /// <summary>
        /// 当前页标
        /// </summary>
        public int pageIndex { get; set; } = 1;

        /// <summary>
        /// 总页数
        /// </summary>
        public int pageCount
        {
            get
            {
                int value = (int)Math.Ceiling((decimal)total / pageSize);
                return value;
            }
        }

        /// <summary>
        /// 数据总数
        /// </summary>
        public int total { get; set; } = 0;

        /// <summary>
        /// 每页大小
        /// </summary>
        public int pageSize { set; get; } = 10;
    }
}