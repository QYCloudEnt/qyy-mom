using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;

namespace TMom.Infrastructure.Repository
{
    /// <summary>
    /// FailureTypeRepository
    /// </summary>
    public class FailureTypeRepository : BaseRepository<FailureType, int>, IFailureTypeRepository
    {
        public FailureTypeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}