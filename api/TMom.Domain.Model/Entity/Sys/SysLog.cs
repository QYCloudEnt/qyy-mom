using SqlSugar;

namespace TMom.Domain.Model.Entity
{
    /// <summary>
    /// 系统日志表(按季度分表)
    /// </summary>
    [SplitTable(SplitType.Season)]
    [SugarTable("sys_log_{year}{month}{day}")]
    public class SysLog : RootEntity<long>
    {
        /// <summary>
        /// 日志类型
        /// </summary>
        public string LogType { get; set; }

        /// <summary>
        /// 请求方式
        /// </summary>
        public string HttpType { get; set; }

        /// <summary>
        /// 接口地址
        /// </summary>
        public string ApiUrl { get; set; }

        /// <summary>
        /// 请求参数
        /// </summary>
        [SugarColumn(Length = 4000)]
        public string RequestParams { get; set; } = "";

        /// <summary>
        /// 返回数据
        /// </summary>
        [SugarColumn(ColumnDataType = StaticConfig.CodeFirst_BigString)]
        public string ResponseData { get; set; } = "";

        /// <summary>
        /// 浏览器信息
        /// </summary>
        public string Agent { get; set; }

        public string Ip { get; set; } = "";

        /// <summary>
        /// 耗时(ms)
        /// </summary>
        public string TotalMilliseconds { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperationTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 创建时间(分表字段)
        /// </summary>
        [SplitField]
        public override DateTime CreateTime { get; set; } = DateTime.Now;
    }
}