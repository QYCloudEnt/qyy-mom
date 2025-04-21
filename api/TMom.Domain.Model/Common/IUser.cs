using System.Security.Claims;

namespace TMom.Domain.Model
{
    public interface IUser
    {
        /// <summary>
        /// 当前登录用户账号
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 当前登录用户Id
        /// </summary>
        int Id { get; }

        bool IsAuthenticated();

        IEnumerable<Claim> GetClaimsIdentity();

        List<string> GetClaimValueByType(string ClaimType);

        string GetToken();

        List<string> GetUserInfoFromToken(string ClaimType = "jti");
    }
}