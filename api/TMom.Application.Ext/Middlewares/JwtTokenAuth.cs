using Microsoft.AspNetCore.Http;
using TMom.Infrastructure;

namespace TMom.Application.Ext
{
    public class JwtTokenAuth
    {
        /// <summary>
        ///
        /// </summary>
        private readonly RequestDelegate _next;

        /// <summary>
        ///
        /// </summary>
        /// <param name="next"></param>
        public JwtTokenAuth(RequestDelegate next)
        {
            _next = next;
        }

        private void PreProceed(HttpContext next)
        {
        }

        private void PostProceed(HttpContext next)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public Task Invoke(HttpContext httpContext)
        {
            PreProceed(httpContext);

            if (!httpContext.Request.Headers.ContainsKey("Authorization"))
            {
                PostProceed(httpContext);

                return _next(httpContext);
            }
            var tokenHeader = httpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            try
            {
                if (tokenHeader.Length >= 128)
                {
                    TokenModelJwt tm = JwtHelper.SerializeJwt(tokenHeader);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{DateTime.Now} middleware wrong:{e.Message}");
            }

            PostProceed(httpContext);

            return _next(httpContext);
        }
    }
}