using Microsoft.IdentityModel.Tokens;
using TMom.Infrastructure.DB;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TMom.Infrastructure
{
    public class JwtHelper
    {
        /// <summary>
        /// 颁发JWT字符串
        /// </summary>
        /// <param name="tokenModel"></param>
        /// <returns></returns>
        public static string IssueJwt(TokenModelJwt tokenModel)
        {
            string iss = Appsettings.app(new string[] { "Audience", "Issuer" });
            string aud = Appsettings.app(new string[] { "Audience", "Audience" });
            string secret = AppSecretConfig.Audience_Secret_String;

            var claims = new List<Claim>
                {
                new Claim(JwtRegisteredClaimNames.Jti, tokenModel.Uid.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, $"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),
                new Claim(JwtRegisteredClaimNames.Nbf,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}") ,
                //这个就是过期时间，目前是过期1000秒，可自定义，注意JWT有自己的缓冲过期时间
                new Claim (JwtRegisteredClaimNames.Exp,$"{new DateTimeOffset(DateTime.Now.AddSeconds(1000)).ToUnixTimeSeconds()}"),
                new Claim(ClaimTypes.Expiration, DateTime.Now.AddSeconds(1000).ToString()),
                new Claim(JwtRegisteredClaimNames.Iss,iss),
                new Claim(JwtRegisteredClaimNames.Aud,aud),
               };

            // 可以将一个用户的多个角色全部赋予；
            claims.AddRange(tokenModel.Role.Split(',').Select(s => new Claim(ClaimTypes.Role, s)));

            //秘钥 (SymmetricSecurityKey 对安全性的要求，密钥的长度太短会报出异常)
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: iss,
                claims: claims,
                signingCredentials: creds);

            var jwtHandler = new JwtSecurityTokenHandler();
            var encodedJwt = jwtHandler.WriteToken(jwt);

            return encodedJwt;
        }

        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="jwtStr"></param>
        /// <returns></returns>
        public static TokenModelJwt SerializeJwt(string jwtStr)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            TokenModelJwt tokenModelJwt = new TokenModelJwt();

            // token校验
            if (jwtStr.IsNotEmptyOrNull() && jwtHandler.CanReadToken(jwtStr))
            {
                JwtSecurityToken jwtToken = jwtHandler.ReadJwtToken(jwtStr);

                object role;

                jwtToken.Payload.TryGetValue(ClaimTypes.Role, out role);

                tokenModelJwt = new TokenModelJwt
                {
                    Uid = (jwtToken.Id).ObjToInt(),
                    Role = role != null ? role.ObjToString() : "",
                };
            }
            return tokenModelJwt;
        }

        public static bool customSafeVerify(string token)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var symmetricKeyAsBase64 = AppSecretConfig.Audience_Secret_String;
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var jwt = jwtHandler.ReadJwtToken(token);
            return jwt.RawSignature == Microsoft.IdentityModel.JsonWebTokens.JwtTokenUtilities.CreateEncodedSignature(jwt.RawHeader + "." + jwt.RawPayload, signingCredentials);
        }

        /// <summary>
        /// 验证Token是否有效
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool ValidateToken(string? token)
        {
            if (string.IsNullOrWhiteSpace(token)) return false;
            var tokenModel = SerializeJwt(token);
            return tokenModel != null && tokenModel.Uid > 0 && customSafeVerify(token);
        }
    }

    /// <summary>
    /// 令牌
    /// </summary>
    public class TokenModelJwt
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Uid { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// 职能
        /// </summary>
        public string Work { get; set; }
    }
}