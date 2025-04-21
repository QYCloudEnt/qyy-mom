using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;

namespace TMom.Infrastructure.Repository
{
    /// <summary>
    /// ProcessRouteSequenceRepository
    /// </summary>
    public class ProcessRouteSequenceRepository : BaseRepository<ProcessRouteSequence, int>, IProcessRouteSequenceRepository
    {
        public ProcessRouteSequenceRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}