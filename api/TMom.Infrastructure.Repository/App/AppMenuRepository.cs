using TMom.Domain.IRepository;
using TMom.Domain.Model;
using TMom.Domain.Model.Entity;

namespace TMom.Infrastructure.Repository
{
	/// <summary>
	/// AppMenuRepository
	/// </summary>
    public class AppMenuRepository : BaseRepository<AppMenu, int>, IAppMenuRepository
    {
        public AppMenuRepository(IUnitOfWork unitOfWork): base(unitOfWork)
        {
        }
    }
}