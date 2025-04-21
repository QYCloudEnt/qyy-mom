using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;

namespace TMom.Infrastructure.Repository
{
    /// <summary>
    /// ProductLockRepository
    /// </summary>
    public class ProductLockRepository : BaseRepository<ProductLock, int>, IProductLockRepository
    {
        public ProductLockRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}