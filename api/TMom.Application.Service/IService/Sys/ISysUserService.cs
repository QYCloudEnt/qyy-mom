using TMom.Application.Dto.Sys;
using TMom.Domain.Model;
using TMom.Domain.Model.Entity;
using System.Linq.Expressions;

namespace TMom.Application.Service.IService
{
    /// <summary>
    /// ISysUserService
    /// </summary>
    public interface ISysUserService : IBaseService<SysUser, int>
    {
        /// <summary>
        /// 获取用户所有角色名及用户Id
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<(string, string)> GetUserRoleNameStr(string name);

        Task<PageModel<SysUser>> GetWithPage((Expression<Func<SysUser, bool>>, List<FormattableString>) whereExp, int? orgId, int pageIndex, int pageSize);

        Task<bool> UpdateData(SysUser request, int userId);

        Task RefreshAllUserCache();
    }
}