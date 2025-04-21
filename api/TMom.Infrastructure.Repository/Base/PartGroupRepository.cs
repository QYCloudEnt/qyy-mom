using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;

namespace TMom.Infrastructure.Repository
{
    /// <summary>
    /// PartGroupRepository
    /// </summary>
    public class PartGroupRepository : BaseRepository<PartGroup, int>, IPartGroupRepository
    {
        public PartGroupRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}