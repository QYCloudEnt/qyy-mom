namespace TMom.Infrastructure
{
    /// <summary>
    /// 自定义的失败请求异常
    /// </summary>
    public class CustomFailRequestException : Exception
    {
        public CustomFailRequestException()
        { }

        /// <summary>
        /// 自定义的失败请求异常
        /// </summary>
        /// <param name="message">错误消息</param>
        public CustomFailRequestException(string message) : base(message) { }

        public CustomFailRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}