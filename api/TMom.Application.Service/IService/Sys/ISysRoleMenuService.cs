using TMom.Domain.Model.Entity;

namespace TMom.Application.Service.IService
{
    /// <summary>
    /// ISysRoleMenuService
    /// </summary>
    public interface ISysRoleMenuService : IBaseService<SysRoleMenu, int>
    {
        Task<List<SysRoleMenu>> RoleMenuMaps();

        Task TestAOP();
    }
}