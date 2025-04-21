namespace TMom.Infrastructure.LogHelper
{
    public class LogInfo
    {
        public long Id { get; set; } = 0;

        /// <summary>
        /// 请求时间
        /// </summary>
        public DateTime Datetime { get; set; }

        /// <summary>
        /// 详细内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 请求Ip
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 接口地址
        /// </summary>
        public string ApiUrl { get; set; }

        /// <summary>
        /// 耗时(ms)
        /// </summary>
        public string OPTime { get; set; }

        /// <summary>
        /// 请求方式
        /// </summary>
        public string HttpType { get; set; }

        /// <summary>
        /// 请求参数
        /// </summary>
        public string RequestParams { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public string ResponseData { get; set; }

        /// <summary>
        /// 日志分类
        /// </summary>
        public string LogType { get; set; }

        /// <summary>
        /// 重要程度
        /// </summary>
        public int Import { get; set; } = 0;

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool? Success { get; set; } = true;
    }
}