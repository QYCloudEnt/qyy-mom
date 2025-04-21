using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;

namespace TMom.Infrastructure.Repository
{
    /// <summary>
    /// SupplierRepository
    /// </summary>
    public class SupplierRepository : BaseRepository<Supplier, int>, ISupplierRepository
    {
        public SupplierRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}