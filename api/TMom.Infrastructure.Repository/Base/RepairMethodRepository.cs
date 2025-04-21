using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;

namespace TMom.Infrastructure.Repository
{
    /// <summary>
    /// RepairMethodRepository
    /// </summary>
    public class RepairMethodRepository : BaseRepository<RepairMethod, int>, IRepairMethodRepository
    {
        public RepairMethodRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}