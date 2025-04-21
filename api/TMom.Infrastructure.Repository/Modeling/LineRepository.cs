using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;

namespace TMom.Infrastructure.Repository
{
    /// <summary>
    /// LineRepository
    /// </summary>
    public class LineRepository : BaseRepository<Line, int>, ILineRepository
    {
        public LineRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}