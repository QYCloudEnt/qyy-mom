using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TMom.Domain.Model;
using TMom.Domain.Model.Entity;
using TMom.Infrastructure;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using static TMom.Domain.Model.GlobalVars;

namespace TMom.Application.Service
{
    /// <summary>
    /// 处理token中的用户信息
    /// </summary>
    public class AspNetUser : IUser
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly ILogger<AspNetUser> _logger;

        public AspNetUser(IHttpContextAccessor accessor, ILogger<AspNetUser> logger)
        {
            _accessor = accessor;
            _logger = logger;
        }

        /// <summary>
        /// 当前登录用户账号
        /// </summary>
        public string Name => GetName();

        private string GetName()
        {
            if (IsAuthenticated() && _accessor.HttpContext.User.Identity.Name.IsNotEmptyOrNull())
            {
                return _accessor.HttpContext.User.Identity.Name;
            }
            else
            {
                if (!string.IsNullOrEmpty(GetToken()))
                {
                    var getNameType = Permissions.IsUseIds4 ? "name" : "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
                    return GetUserInfoFromToken(getNameType).FirstOrDefault().ObjToString();
                }
            }

            return "";
        }

        /// <summary>
        /// 当前登录用户Id
        /// </summary>
        public int Id => GetUserId();

        private int GetUserId()
        {
            return GetClaimValueByType("jti").FirstOrDefault()?.ObjToInt() ?? 0;
        }

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        /// <summary>
        /// 获取Token信息, 请求头中格式必须是："Bearer " + token，否则出错
        /// </summary>
        /// <returns></returns>
        public string GetToken()
        {
            string tokenStr = _accessor.HttpContext?.Request?.Headers["Authorization"].ObjToString();
            if (tokenStr.IsNotEmptyOrNull() && !tokenStr.StartsWith("Bearer "))
            {
                throw new Exception("请求头token格式有误, 必须是：'Bearer ' + token");
            }
            string token = tokenStr.Replace("Bearer ", "");
            return token;
        }

        /// <summary>
        /// 根据Token获取登录用户信息
        /// </summary>
        /// <param name="ClaimType"></param>
        /// <returns></returns>
        public List<string> GetUserInfoFromToken(string ClaimType = "jti")
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var token = "";

            token = GetToken();
            // token校验
            if (token.IsNotEmptyOrNull() && jwtHandler.CanReadToken(token))
            {
                JwtSecurityToken jwtToken = jwtHandler.ReadJwtToken(token);

                return (from item in jwtToken.Claims
                        where item.Type == ClaimType
                        select item.Value).ToList();
            }

            return new List<string>() { };
        }

        public IEnumerable<Claim>? GetClaimsIdentity()
        {
            return _accessor.HttpContext?.User.Claims;
        }

        public List<string> GetClaimValueByType(string ClaimType)
        {
            if (GetClaimsIdentity() == null) return new List<string> { };
            return (from item in GetClaimsIdentity()
                    where item.Type == ClaimType
                    select item.Value).ToList();
        }
    }
}