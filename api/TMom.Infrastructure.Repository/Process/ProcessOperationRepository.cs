using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;

namespace TMom.Infrastructure.Repository
{
    /// <summary>
    /// ProcessOperationRepository
    /// </summary>
    public class ProcessOperationRepository : BaseRepository<ProcessOperation, int>, IProcessOperationRepository
    {
        public ProcessOperationRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}