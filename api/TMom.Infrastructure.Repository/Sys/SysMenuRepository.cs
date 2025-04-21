using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;

namespace TMom.Infrastructure.Repository
{
    /// <summary>
    /// SysMenuRepository
    /// </summary>
    public class SysMenuRepository : BaseRepository<SysMenu, int>, ISysMenuRepository
    {
        public SysMenuRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<List<SysMenu>> GetMenusByUserId(int id)
        {
            var list = await Db.Queryable<SysUserRole, SysRoleMenu, SysMenu>((sur, srm, sm) => srm.SysRoleId == sur.SysRoleId && sm.Id == srm.SysMenuId)
                               .Where((sur, srm, sm) => sur.SysUserId == id && sur.IsDeleted == false && srm.IsDeleted == false && sm.IsDeleted == false)
                               .OrderBy((sur, srm, sm) => sm.OrderSort)
                               .Select((sur, srm, sm) => new SysMenu()
                               {
                                   Id = sm.Id,
                                   MenuName = sm.MenuName,
                                   ParentId = sm.ParentId,
                                   Icon = sm.Icon,
                                   Type = sm.Type,
                                   LinkUrl = sm.LinkUrl,
                                   ViewPath = sm.ViewPath,
                                   IsKeepAlive = sm.IsKeepAlive,
                                   IsShow = sm.IsShow,
                                   OrderSort = sm.OrderSort,
                                   IsExternal = sm.IsExternal,
                                   IsEmbed = sm.IsEmbed
                               })
                               .Distinct()
                               .ToListAsync();
            return list;
        }
    }
}