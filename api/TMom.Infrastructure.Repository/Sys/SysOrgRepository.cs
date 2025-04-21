using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;

namespace TMom.Infrastructure.Repository
{
    /// <summary>
    /// SysOrgRepository
    /// </summary>
    public class SysOrgRepository : BaseRepository<SysOrg, int>, ISysOrgRepository
    {
        public SysOrgRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}