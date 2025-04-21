using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;

namespace TMom.Infrastructure.Repository
{
    /// <summary>
    /// FailureSymptomRepository
    /// </summary>
    public class FailureSymptomRepository : BaseRepository<FailureSymptom, int>, IFailureSymptomRepository
    {
        public FailureSymptomRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}