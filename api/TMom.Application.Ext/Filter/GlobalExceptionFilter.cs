using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using TMom.Infrastructure;
using TMom.Infrastructure.Helper;
using TMom.Infrastructure.Repository;
using StackExchange.Profiling;

namespace TMom.Application.Ext
{
    public class GlobalExceptionFilter
    {
        /// <summary>
        /// 全局异常错误日志
        /// </summary>
        public class GlobalExceptionsFilter : IExceptionFilter
        {
            private readonly IWebHostEnvironment _env;

            //private readonly IHubContext<ChatHub> _hubContext;
            private readonly ILogger<GlobalExceptionsFilter> _loggerHelper;

            private readonly IUnitOfWork _unitOfWork;

            public GlobalExceptionsFilter(IWebHostEnvironment env, ILogger<GlobalExceptionsFilter> loggerHelper, IUnitOfWork unitOfWork)
            {
                _env = env;
                _loggerHelper = loggerHelper;
                //_hubContext = hubContext;
                _unitOfWork = unitOfWork;
            }

            public void OnException(ExceptionContext context)
            {
                while (context.Exception.InnerException != null) context.Exception = context.Exception.InnerException;
                var json = new MessageModel<string>();
                json.msg = context.Exception.Message;// 错误信息
                json.status = 500;// 500异常
                var errorAudit = "Unable to resolve service for";
                if (!string.IsNullOrEmpty(json.msg) && json.msg.Contains(errorAudit))
                {
                    json.msg = json.msg.Replace(errorAudit, $"（若新添加服务，需要重新编译项目）{errorAudit}");
                }

                json.msgDev = context.Exception.StackTrace ?? "";// 堆栈信息
                var res = new ContentResult();
                res.Content = JsonHelper.GetJSON<MessageModel<string>>(json);

                context.Result = res;

                MiniProfiler.Current.CustomTiming("Errors：", json.msg);

                // 正常的业务逻辑异常不记录
                if (!(context.Exception is CustomFailRequestException))
                {
                    _loggerHelper.LogError(WriteLog(json.msg, context.Exception));
                }
            }

            /// <summary>
            /// 自定义返回格式
            /// </summary>
            /// <param name="throwMsg"></param>
            /// <param name="ex"></param>
            /// <returns></returns>
            public string WriteLog(string throwMsg, Exception ex)
            {
                return string.Format("\r\n【自定义错误】：{0} \r\n【异常类型】：{1} \r\n【异常信息】：{2} \r\n【堆栈调用】：{3}", new object[] { throwMsg,
                ex.GetType().Name, ex.Message, ex.StackTrace });
            }
        }

        public class InternalServerErrorObjectResult : ObjectResult
        {
            public InternalServerErrorObjectResult(object value) : base(value)
            {
                StatusCode = StatusCodes.Status500InternalServerError;
            }
        }

        //返回错误信息
        public class JsonErrorResponse
        {
            /// <summary>
            /// 生产环境的消息
            /// </summary>
            public string Message { get; set; }

            /// <summary>
            /// 开发环境的消息
            /// </summary>
            public string DevelopmentMessage { get; set; }
        }
    }
}