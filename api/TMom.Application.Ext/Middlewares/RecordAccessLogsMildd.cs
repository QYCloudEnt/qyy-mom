using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TMom.Application.Dto;
using TMom.Domain.Model;
using TMom.Infrastructure;
using TMom.Infrastructure.Helper;
using TMom.Infrastructure.LogHelper;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.Web;

namespace TMom.Application.Ext
{
    /// <summary>
    /// 中间件
    /// 记录用户方访问数据
    /// </summary>
    public class RecordAccessLogsMildd
    {
        /// <summary>
        ///
        /// </summary>
        private readonly RequestDelegate _next;

        private readonly IUser _user;
        private readonly ILogger<RecordAccessLogsMildd> _logger;
        private readonly IWebHostEnvironment _environment;
        private Stopwatch _stopwatch;

        /// <summary>
        ///
        /// </summary>
        /// <param name="next"></param>
        public RecordAccessLogsMildd(RequestDelegate next, IUser user, ILogger<RecordAccessLogsMildd> logger, IWebHostEnvironment environment)
        {
            _next = next;
            _user = user;
            _logger = logger;
            _environment = environment;
            _stopwatch = new Stopwatch();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (Appsettings.app("Middleware", "RecordAccessLogs", "Enabled").ObjToBool())
            {
                var _api = context.Request.Path.ObjToString().TrimEnd('/');
                var api = _api.ToLower();
                var ignoreApis = Appsettings.app("Middleware", "RecordAccessLogs", "IgnoreApis");

                HttpRequest request = context.Request;
                // 过滤，只有接口
                if (api.Contains("api") && !ignoreApis.ToLower().Contains(api) && request.Method != "OPTIONS")
                {
                    _stopwatch.Restart();
                    var userAccessModel = new UserAccessModel();

                    userAccessModel.API = _api;
                    userAccessModel.User = _user.Id > 0 ? $"({_user.Id}){_user.Name}" : _user.Name;
                    userAccessModel.IP = IPLogMildd.GetClientIP(context);
                    userAccessModel.BeginTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    userAccessModel.RequestMethod = request.Method;
                    userAccessModel.Agent = request.Headers["User-Agent"].ObjToString();

                    // 获取请求body内容
                    if (request.Method.ToLower().Equals("post") || request.Method.ToLower().Equals("put") || request.Method.ToLower().Equals("patch"))
                    {
                        request.EnableBuffering();

                        Stream stream = request.Body;
                        byte[] buffer = new byte[request.ContentLength.Value];
                        stream.Read(buffer, 0, buffer.Length);
                        userAccessModel.RequestData = Encoding.UTF8.GetString(buffer);

                        request.Body.Position = 0;
                    }
                    else if (request.Method.ToLower().Equals("get") || request.Method.ToLower().Equals("delete"))
                    {
                        userAccessModel.RequestData = HttpUtility.UrlDecode(request.QueryString.ObjToString(), Encoding.UTF8);
                    }

                    await _next(context);

                    // 响应完成记录时间和存入日志
                    context.Response.OnCompleted(() =>
                    {
                        _stopwatch.Stop();

                        userAccessModel.OPTime = _stopwatch.ElapsedMilliseconds + "ms";

                        // 自定义log输出
                        var requestInfo = JsonConvert.SerializeObject(userAccessModel);
                        if (Appsettings.app("Middleware", "RecordAccessLogs", "OutToFile", "Enabled").ObjToBool())
                        {
                            var logFileName = FileHelper.GetAvailableFileNameWithPrefixOrderSize(_environment.ContentRootPath, "RecordAccessLogs");
                            SerilogServer.WriteLog(logFileName, new string[] { requestInfo + "," }, false);
                        }
                        return Task.CompletedTask;
                    });
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

        /// <summary>
        /// 获取响应内容
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public async Task<string> GetResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var text = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);
            return text;
        }
    }
}