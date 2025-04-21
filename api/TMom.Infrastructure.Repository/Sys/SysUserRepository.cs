using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;

namespace TMom.Infrastructure.Repository
{
    /// <summary>
    /// SysUserRepository
    /// </summary>
    public class SysUserRepository : BaseRepository<SysUser, int>, ISysUserRepository
    {
        public SysUserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}