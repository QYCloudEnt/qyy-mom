using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;

namespace TMom.Infrastructure.Repository
{
    /// <summary>
    /// SysRoleMenuRepository
    /// </summary>
    public class SysRoleMenuRepository : BaseRepository<SysRoleMenu, int>, ISysRoleMenuRepository
    {
        public SysRoleMenuRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}