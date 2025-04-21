using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;

namespace TMom.Infrastructure.Repository
{
    /// <summary>
    /// WorkOrderRepository
    /// </summary>
    public class WorkOrderRepository : BaseRepository<WorkOrder, int>, IWorkOrderRepository
    {
        public WorkOrderRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}