using TMom.Domain.Model.Entity;

namespace TMom.Domain.IRepository
{
    /// <summary>
    /// ISysMenuRepository
    /// </summary>
    public interface ISysMenuRepository : IBaseRepository<SysMenu, int>
    {
        Task<List<SysMenu>> GetMenusByUserId(int iD);
    }
}