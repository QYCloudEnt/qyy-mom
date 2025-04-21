using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;

namespace TMom.Infrastructure.Repository
{
    /// <summary>
    /// ProcessRouteBaseRepository
    /// </summary>
    public class ProcessRouteBaseRepository : BaseRepository<ProcessRouteBase, int>, IProcessRouteBaseRepository
    {
        public ProcessRouteBaseRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}