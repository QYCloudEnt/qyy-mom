using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TMom.Infrastructure;
using TMom.Infrastructure.LogHelper;
using System.Text.RegularExpressions;

namespace TMom.Application.Ext
{
    /// <summary>
    /// 中间件
    /// 记录请求和响应数据
    /// </summary>
    public class RequRespLogMildd
    {
        /// <summary>
        ///
        /// </summary>
        private readonly RequestDelegate _next;

        private readonly ILogger<RequRespLogMildd> _logger;

        /// <summary>
        ///
        /// </summary>
        /// <param name="next"></param>
        public RequRespLogMildd(RequestDelegate next, ILogger<RequRespLogMildd> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (Appsettings.app("Middleware", "RequestResponseLog", "Enabled").ObjToBool())
            {
                // 过滤，只有接口
                if (context.Request.Path.Value.Contains("api"))
                {
                    context.Request.EnableBuffering();

                    // 存储请求数据
                    await RequestDataLog(context);

                    await _next(context);

                    // 存储响应数据
                    ResponseDataLog(context.Response);
                }
                else
                {
                    await _next(context);
                }
            }
            else
            {
                await _next(context);
            }
        }

        private async Task RequestDataLog(HttpContext context)
        {
            var request = context.Request;
            var sr = new StreamReader(request.Body);

            var content = $" QueryData:{request.Path + request.QueryString}\r\n BodyData:{await sr.ReadToEndAsync()}";

            if (!string.IsNullOrEmpty(content))
            {
                SerilogServer.WriteLog("RequestResponseLog", new string[] { "Request Data:", content });

                request.Body.Position = 0;
            }
        }

        private void ResponseDataLog(HttpResponse response)
        {
            var responseBody = response.GetResponseBody();

            // 去除 Html
            var reg = "<[^>]+>";

            if (!string.IsNullOrEmpty(responseBody))
            {
                var isHtml = Regex.IsMatch(responseBody, reg);
                SerilogServer.WriteLog("RequestResponseLog", new string[] { "Response Data:", responseBody });
            }
        }
    }
}