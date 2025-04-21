using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;

namespace TMom.Infrastructure.Repository
{
    /// <summary>
    /// ProcessRouteRepository
    /// </summary>
    public class ProcessRouteRepository : BaseRepository<ProcessRoute, int>, IProcessRouteRepository
    {
        public ProcessRouteRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}