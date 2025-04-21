using System.Net.Http.Headers;
using System.Text;

namespace TMom.Infrastructure.Helper
{
    /// <summary>
    /// HttpHelper 使用HttpClientFactory方式
    /// </summary>
    public class HttpHelper
    {
        private static readonly IHttpClientFactory _httpClientFactory = AutofacContainer.Resolve<IHttpClientFactory>();

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="url"></param>
        /// <param name="dicHeaders"></param>
        /// <param name="timeoutSecond">超时时间默认180秒</param>
        /// <returns></returns>
        public static async Task<string> GetAsync(string url, Dictionary<string, string>? dicHeaders = null, int timeoutSecond = 180)
        {
            try
            {
                var client = BuildHttpClient(dicHeaders, timeoutSecond);
                var response = await client.GetAsync(url);
                var responseContent = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return responseContent;
                }
                else
                {
                    throw new CustomHttpException(response.StatusCode.ToString(), responseContent);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"HttpGet:{url} Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="url"></param>
        /// <param name="dicHeaders"></param>
        /// <param name="timeoutSecond">超时时间默认180秒</param>
        /// <returns></returns>
        public static async Task<T> GetAsync<T>(string url, Dictionary<string, string>? dicHeaders = null, int timeoutSecond = 180) where T : class
        {
            try
            {
                var client = BuildHttpClient(dicHeaders, timeoutSecond);
                var response = await client.GetAsync(url);
                var responseContent = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return JsonHelper.ParseFormByJson<T>(responseContent);
                }
                else
                {
                    throw new CustomHttpException(response.StatusCode.ToString(), responseContent);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"HttpGet:{url} Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="url"></param>
        /// <param name="requestBody"></param>
        /// <param name="dicHeaders"></param>
        /// <param name="timeoutSecond">超时时间默认180秒</param>
        /// <returns></returns>
        public static async Task<T> PostAsync<T>(string url, string requestBody, Dictionary<string, string>? dicHeaders = null, int timeoutSecond = 180) where T : class
        {
            try
            {
                var client = BuildHttpClient(null, timeoutSecond);
                var requestContent = GenerateStringContent(requestBody, dicHeaders);
                var response = await client.PostAsync(url, requestContent);
                var responseContent = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var result = JsonHelper.ParseFormByJson<T>(responseContent);
                    return result;
                }
                else
                {
                    throw new CustomHttpException(response.StatusCode.ToString(), responseContent);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"HttpPost:{url} Error: {ex.Message}");
            }
        }

        /// <summary>
        /// common request
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="requestBody"></param>
        /// <param name="dicHeaders"></param>
        /// <param name="timeoutSecond">超时时间默认180秒</param>
        /// <returns></returns>
        public static async Task<T> ExecuteAsync<T>(string url, HttpMethod method, string? requestBody = null, Dictionary<string, string>? dicHeaders = null, int timeoutSecond = 180)
        {
            try
            {
                var client = BuildHttpClient(null, timeoutSecond);
                var request = GenerateHttpRequestMessage(url, requestBody, method, dicHeaders);
                var response = await client.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var type = typeof(T);
                    if (type.IsPrimitive || type == typeof(string))
                    {
                        return (T)Convert.ChangeType(responseContent, typeof(T));
                    }
                    else
                    {
                        return JsonHelper.ParseFormByJson<T>(responseContent);
                    }
                }
                else
                {
                    throw new CustomHttpException(response.StatusCode.ToString(), responseContent);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{method.ObjToString()}:{url} Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Generate HttpRequestMessage
        /// </summary>
        /// <param name="url"></param>
        /// <param name="requestBody"></param>
        /// <param name="method"></param>
        /// <param name="dicHeaders"></param>
        /// <returns></returns>
        private static HttpRequestMessage GenerateHttpRequestMessage(string url, string? requestBody, HttpMethod method, Dictionary<string, string>? dicHeaders)
        {
            using (var request = new HttpRequestMessage(method, url))
            {
                if (!string.IsNullOrEmpty(requestBody))
                {
                    request.Content = new StringContent(requestBody);
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                }
                if (dicHeaders != null)
                {
                    foreach (var header in dicHeaders)
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }
                }
                return request;
            }
        }

        /// <summary>
        ///  Generate StringContent
        /// </summary>
        /// <param name="requestBody"></param>
        /// <param name="dicHeaders"></param>
        /// <returns></returns>
        private static StringContent GenerateStringContent(string requestBody, Dictionary<string, string>? dicHeaders)
        {
            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            if (dicHeaders != null)
            {
                foreach (var headerItem in dicHeaders)
                {
                    content.Headers.Add(headerItem.Key, headerItem.Value);
                }
            }
            return content;
        }

        /// <summary>
        /// Build HttpClient
        /// </summary>
        /// <param name="timeoutSecond"></param>
        /// <returns></returns>
        private static HttpClient BuildHttpClient(Dictionary<string, string>? dicDefaultHeaders, int? timeoutSecond)
        {
            var httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Clear();
            //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (dicDefaultHeaders != null)
            {
                foreach (var headerItem in dicDefaultHeaders)
                {
                    if (!httpClient.DefaultRequestHeaders.Contains(headerItem.Key))
                    {
                        httpClient.DefaultRequestHeaders.Add(headerItem.Key, headerItem.Value);
                    }
                }
            }
            if (timeoutSecond.HasValue)
            {
                httpClient.Timeout = TimeSpan.FromSeconds(timeoutSecond.Value);
            }
            return httpClient;
        }
    }
}