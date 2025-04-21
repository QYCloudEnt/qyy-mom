using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;

namespace TMom.Infrastructure.Repository
{
    /// <summary>
    /// PartMaterialRepository
    /// </summary>
    public class PartMaterialRepository : BaseRepository<PartMaterial, int>, IPartMaterialRepository
    {
        public PartMaterialRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}