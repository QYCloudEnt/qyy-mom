namespace TMom.Client
{
    /// <summary>
    /// 通用返回信息类
    /// </summary>
    public class MessageModel<T>
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int status { get; set; } = 200;

        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool success { get; set; } = false;

        /// <summary>
        /// 返回信息
        /// </summary>
        public string msg { get; set; } = "";

        /// <summary>
        /// 开发者信息
        /// </summary>
        public string msgDev { get; set; }

        /// <summary>
        /// 返回数据集合
        /// </summary>
        public T data { get; set; }

        /// <summary>
        /// 返回成功
        /// </summary>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        public static MessageModel<T> Success(string msg = "操作成功!")
        {
            return Message(true, msg, default);
        }

        /// <summary>
        /// 返回成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        public static MessageModel<T> Success(T data, string msg = "操作成功!")
        {
            return Message(true, msg, data);
        }

        /// <summary>
        /// 返回失败
        /// </summary>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        public static MessageModel<T> Fail(string msg)
        {
            return Message(false, msg, default);
        }

        /// <summary>
        /// 返回失败
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static MessageModel<T> Fail(string msg, T data)
        {
            return Message(false, msg, data);
        }

        /// <summary>
        /// 返回消息
        /// </summary>
        /// <param name="success">失败/成功</param>
        /// <param name="msg">消息</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static MessageModel<T> Message(bool success, string msg, T data)
        {
            return new MessageModel<T>() { msg = msg, data = data, success = success };
        }
    }

    public class MessageModel
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int status { get; set; } = 200;

        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool success { get; set; } = false;

        /// <summary>
        /// 返回信息
        /// </summary>
        public string msg { get; set; } = "";

        /// <summary>
        /// 返回数据集合
        /// </summary>
        public object data { get; set; }
    }
}