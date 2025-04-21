using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;

namespace TMom.Infrastructure.Repository
{
    /// <summary>
    /// ProcessRouteTestRepository
    /// </summary>
    public class ProcessRouteTestRepository : BaseRepository<ProcessRouteTest, int>, IProcessRouteTestRepository
    {
        public ProcessRouteTestRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}