using TMom.Infrastructure;

namespace TMom.Application.Dto
{
    /// <summary>
    /// api日志事件模型
    /// </summary>
    public class SysLogEventModel : IntegrationEvent
    {
        /// <summary>
        /// 日志类型
        /// </summary>
        public string LogType { get; set; }

        /// <summary>
        /// 日志文本
        /// </summary>
        public string LogText { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public int SysUserId { get; set; }
    }
}