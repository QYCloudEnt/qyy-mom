using TMom.Application.Dto.Sys;
using TMom.Domain.Model.Entity;
using TMom.Domain.Model.Params;

namespace TMom.Application.Service.IService
{
    /// <summary>
    /// ISysMenuService
    /// </summary>
    public interface ISysMenuService : IBaseService<SysMenu, int>
    {
        Task<PermMenuDto> GetMenusByUserId(int iD);

        List<string> GetPermList();

        Task addMenuAndPermForIndex(CodeFirstParams param);

        Task addMenuAndPermForIndexDetail(CodeFirstParams param);
    }
}