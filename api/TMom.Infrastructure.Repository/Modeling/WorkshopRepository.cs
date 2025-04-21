using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;

namespace TMom.Infrastructure.Repository
{
    /// <summary>
    /// WorkshopRepository
    /// </summary>
    public class WorkshopRepository : BaseRepository<Workshop, int>, IWorkshopRepository
    {
        public WorkshopRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}