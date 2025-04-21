using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TMom.Infrastructure.Helper
{
    public static class StringHelper
    {
        /// <summary>
        /// 根据分隔符返回前n条数据
        /// </summary>
        /// <param name="content">数据内容</param>
        /// <param name="separator">分隔符</param>
        /// <param name="top">前n条</param>
        /// <param name="isDesc">是否倒序（默认false）</param>
        /// <returns></returns>
        public static List<string> GetTopDataBySeparator(string content, string separator, int top, bool isDesc = false)
        {
            if (string.IsNullOrEmpty(content))
            {
                return new List<string>() { };
            }

            if (string.IsNullOrEmpty(separator))
            {
                throw new ArgumentException("message", nameof(separator));
            }

            var dataArray = content.Split(separator).Where(d => !string.IsNullOrEmpty(d)).ToArray();
            if (isDesc)
            {
                Array.Reverse(dataArray);
            }

            if (top > 0)
            {
                dataArray = dataArray.Take(top).ToArray();
            }

            return dataArray.ToList();
        }

        /// <summary>
        /// 根据字段拼接get参数
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static string GetPars(this Dictionary<string, object> dic)
        {
            StringBuilder sb = new StringBuilder();
            bool isEnter = false;
            foreach (var item in dic)
            {
                sb.Append($"{(isEnter ? "&" : "")}{item.Key}={item.Value}");
                isEnter = true;
            }
            return sb.ToString();
        }

        /// <summary>
        /// 根据字段拼接get参数
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static string GetPars(this Dictionary<string, string> dic)
        {
            StringBuilder sb = new StringBuilder();
            bool isEnter = false;
            foreach (var item in dic)
            {
                sb.Append($"{(isEnter ? "&" : "")}{item.Key}={item.Value}");
                isEnter = true;
            }
            return sb.ToString();
        }

        /// <summary>
        /// 获取一个GUID(没有"-"符号)
        /// </summary>
        /// <param name="format">格式-默认为N</param>
        /// <returns></returns>
        public static string GetGUID(string format = "N")
        {
            return Guid.NewGuid().ToString(format);
        }

        /// <summary>
        /// 根据GUID获取19位的唯一数字序列
        /// </summary>
        /// <returns></returns>
        public static long GetGuidToLongID()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }

        /// <summary>
        /// 获取字符串最后X行
        /// </summary>
        /// <param name="resourceStr"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GetCusLine(string resourceStr, int length)
        {
            string[] arrStr = resourceStr.Split("\r\n");
            return string.Join("", (from q in arrStr select q).Skip(arrStr.Length - length + 1).Take(length).ToArray());
        }

        /// <summary>
        /// 字符串首字母变成小写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FirstToLower(this string str)
        {
            if (string.IsNullOrEmpty(str)) return str;
            return str.First().ToString().ToLower() + str.Substring(1);
        }

        /// <summary>
        /// 字符串首字母变成大写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FirstToUpper(this string str)
        {
            if (string.IsNullOrEmpty(str)) return str;
            return str.First().ToString().ToUpper() + str.Substring(1);
        }

        /// <summary>
        /// 多个Key转成多个Value字符串
        /// <para>e.g. "key1,key2,key3" ==> "value1,value2,value3"</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json">数据list</param>
        /// <param name="str">要转换的keys字符串</param>
        /// <param name="splitStr">keys中的分隔符, 默认","</param>
        /// <param name="key">数据list中的key对应的字段</param>
        /// <param name="value">数据list中的value对应的字段</param>
        /// <returns></returns>
        public static string Keys2ValsFromJson<T>(List<T> json, string str, string splitStr = ",", string key = "value", string value = "label")
        {
            if (json == null || !json.Any() || string.IsNullOrWhiteSpace(str)) return "";
            var keyList = str.Split(splitStr).ToList();
            var valueList = json.Where(x => keyList.Contains(x.GetType().GetProperty(key).GetValue(x, null)?.ToString()))
                                .Select(x => x.GetType().GetProperty(value).GetValue(x, null)?.ToString()).ToList();
            return string.Join(splitStr, valueList);
        }
    }
}