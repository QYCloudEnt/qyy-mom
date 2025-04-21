using TMom.Domain.Model.Entity;

namespace TMom.Domain.IRepository
{
    /// <summary>
    /// IWorkOrderRepository
    /// </summary>
    public interface IWorkOrderRepository : IBaseRepository<WorkOrder, int>
    {
    }
}