using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;

namespace TMom.Infrastructure.Repository
{
    /// <summary>
    /// BomRepository
    /// </summary>
    public class BomRepository : BaseRepository<Bom, int>, IBomRepository
    {
        public BomRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}