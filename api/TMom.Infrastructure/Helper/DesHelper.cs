using System.Security.Cryptography;
using System.Text;

namespace TMom.Infrastructure
{
    /// <summary>
    /// Des 加密帮助类
    /// </summary>
    public static class DesHelper
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="input"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Encrypt(string input, string key = "repo-8rt2-feng19")
        {
            try
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                using (var des = DES.Create())
                {
                    des.Mode = CipherMode.CBC;
                    des.Padding = PaddingMode.PKCS7;
                    using (var ms = new MemoryStream())
                    {
                        byte[] arr_key = Encoding.UTF8.GetBytes(key.Substring(0, 8));
                        using (var cs = new CryptoStream(ms, des.CreateEncryptor(arr_key, arr_key), CryptoStreamMode.Write))
                        {
                            cs.Write(inputBytes, 0, inputBytes.Length);
                            cs.FlushFinalBlock();
                            return Convert.ToBase64String(ms.ToArray());
                        }
                    }
                }
            }
            catch
            {
                return input;
            }
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Decrypt(string cipherText, string key = "repo-8rt2-feng19")
        {
            try
            {
                byte[] inputBytes = Convert.FromBase64String(cipherText);
                using (var des = DES.Create())
                {
                    des.Mode = CipherMode.CBC;
                    des.Padding = PaddingMode.PKCS7;
                    using (var ms = new MemoryStream())
                    {
                        byte[] arr_key = Encoding.UTF8.GetBytes(key.Substring(0, 8));
                        using (var cs = new CryptoStream(ms, des.CreateDecryptor(arr_key, arr_key), CryptoStreamMode.Write))
                        {
                            cs.Write(inputBytes, 0, inputBytes.Length);
                            cs.FlushFinalBlock();
                            return Encoding.UTF8.GetString(ms.ToArray());
                        }
                    }
                }
            }
            catch
            {
                return cipherText;
            }
        }
    }
}