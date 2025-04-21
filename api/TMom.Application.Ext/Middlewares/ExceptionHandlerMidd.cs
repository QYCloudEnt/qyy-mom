using Microsoft.AspNetCore.Http;
using TMom.Application.Dto;
using Newtonsoft.Json;
using System.Net;

namespace TMom.Application.Ext
{
    /// <summary>
    /// 全局异常处理中间件
    /// </summary>
    public class ExceptionHandlerMidd
    {
        private readonly RequestDelegate _next;

        private static readonly log4net.ILog log =
        log4net.LogManager.GetLogger(typeof(ExceptionHandlerMidd));

        public ExceptionHandlerMidd(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception e)
        {
            if (e == null) return;
            log.Error(e.GetBaseException().ToString());

            await WriteExceptionAsync(context, e).ConfigureAwait(false);
        }

        private static async Task WriteExceptionAsync(HttpContext context, Exception e)
        {
            if (e is UnauthorizedAccessException)
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            else if (e is Exception)
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            context.Response.ContentType = "application/json";
            var msg = e.Message;
            if (e.InnerException != null)
            {
                msg = e.InnerException.Message;
            }

            await context.Response.WriteAsync(JsonConvert.SerializeObject(new ApiResponse(StatusCode.CODE500, msg, e.StackTrace).MessageModel)).ConfigureAwait(false);
        }
    }
}