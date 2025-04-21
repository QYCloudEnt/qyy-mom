namespace TMom.Client.Helper
{
    public static class ResponseHelper
    {
        /// <summary>
        /// 返回成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        public static MessageModel<T> Success<T>(T data, string msg = "操作成功!")
        {
            return new MessageModel<T> { status = 200, success = true, msg = msg, data = data };
        }

        /// <summary>
        /// 返回失败
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static MessageModel<T> Fail<T>(string msg, T data)
        {
            return new MessageModel<T> { status = 500, success = false, msg = msg, data = data };
        }
    }
}