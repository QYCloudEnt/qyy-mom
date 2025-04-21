using TMom.Domain.IRepository;
using TMom.Domain.Model;
using TMom.Domain.Model.Entity;

namespace TMom.Infrastructure.Repository
{
	/// <summary>
	/// DataDicRepository
	/// </summary>
    public class DataDicRepository : BaseRepository<DataDic, int>, IDataDicRepository
    {
        public DataDicRepository(IUnitOfWork unitOfWork): base(unitOfWork)
        {
        }
    }
}