namespace TMom.Infrastructure
{
    /// <summary>
    /// 自定义的Http请求错误
    /// </summary>
    public class CustomHttpException : Exception
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public CustomHttpException() : base()
        { }

        public CustomHttpException(string errorCode, string errorMessage) : base()
        {
            this.ErrorCode = errorCode;
            this.ErrorMessage = errorMessage;
        }
    }
}