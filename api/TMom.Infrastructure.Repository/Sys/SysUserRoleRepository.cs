using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;

namespace TMom.Infrastructure.Repository
{
    /// <summary>
    /// SysUserRoleRepository
    /// </summary>
    public class SysUserRoleRepository : BaseRepository<SysUserRole, int>, ISysUserRoleRepository
    {
        public SysUserRoleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}