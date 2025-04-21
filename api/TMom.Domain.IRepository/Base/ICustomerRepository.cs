using TMom.Domain.Model.Entity;

namespace TMom.Domain.IRepository
{
    /// <summary>
    /// ICustomerRepository
    /// </summary>
    public interface ICustomerRepository : IBaseRepository<Customer, int>
    {
    }
}