using TMom.Application.Dto;
using TMom.Infrastructure.Helper;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace TMom.Application.Service
{
    /// <summary>
    /// JWTToken生成类
    /// </summary>
    public class JwtToken
    {
        /// <summary>
        /// 获取基于JWT的Token
        /// </summary>
        /// <param name="claims">需要在登陆的时候配置</param>
        /// <param name="permissionRequirement">在startup中定义的参数</param>
        /// <param name="now">当前时间, 外面传进来, 保证时间一致</param>
        /// <returns></returns>
        public static TokenInfoViewModel BuildJwtToken(Claim[] claims, PermissionRequirement permissionRequirement, DateTime now)
        {
            var expires = now.Add(permissionRequirement.Expiration);
            // 实例化JwtSecurityToken
            var jwt = new JwtSecurityToken(
                issuer: permissionRequirement.Issuer,
                audience: permissionRequirement.Audience,
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: permissionRequirement.SigningCredentials
            );
            // 生成 Token
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            //打包返回前台
            var responseJson = new TokenInfoViewModel
            {
                success = true,
                token = encodedJwt,
                expires_in = permissionRequirement.Expiration.TotalSeconds,
                token_type = "Bearer",
                expires_timestamp = expires.ToUnixTimestampByMilliseconds()
            };
            return responseJson;
        }
    }
}