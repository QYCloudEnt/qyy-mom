using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;

namespace TMom.Infrastructure.Repository
{
    /// <summary>
    /// WorkstationRepository
    /// </summary>
    public class WorkstationRepository : BaseRepository<Workstation, int>, IWorkstationRepository
    {
        public WorkstationRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}