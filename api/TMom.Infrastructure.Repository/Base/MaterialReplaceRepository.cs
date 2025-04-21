using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;

namespace TMom.Infrastructure.Repository
{
    /// <summary>
    /// MaterialReplaceRepository
    /// </summary>
    public class MaterialReplaceRepository : BaseRepository<MaterialReplace, int>, IMaterialReplaceRepository
    {
        public MaterialReplaceRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}