using System.Security.Cryptography;
using System.Text;

namespace TMom.Infrastructure.Helper
{
    public class DingTalkHelper
    {
        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static long GetTimeStamp()
        {
            TimeSpan ts = DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1);
            return (long)ts.TotalMilliseconds;
        }

        /// <summary>
        /// HmacSHA256 加密
        /// </summary>
        /// <param name="secret"></param>
        /// <param name="signKey"></param>
        /// <returns></returns>
        public static string HmacSHA256(string secret, string signKey)
        {
            string signRet = string.Empty;
            using (var mac = new HMACSHA256(Encoding.UTF8.GetBytes(signKey)))
            {
                byte[] hash = mac.ComputeHash(Encoding.UTF8.GetBytes(secret));
                signRet = Convert.ToBase64String(hash);
            }
            return signRet;
        }
    }

    public class DingTalkResult
    {
        /// <summary>
        /// 错误码(0表示ok)
        /// </summary>
        public int Errcode { get; set; } = 0;

        /// <summary>
        /// 错误消息
        /// </summary>
        public string Errmsg { get; set; } = "ok";
    }
}