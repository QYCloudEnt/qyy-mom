using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;

namespace TMom.Infrastructure.Repository
{
    /// <summary>
    /// SysRoleRepository
    /// </summary>
    public class SysRoleRepository : BaseRepository<SysRole, int>, ISysRoleRepository
    {
        public SysRoleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}