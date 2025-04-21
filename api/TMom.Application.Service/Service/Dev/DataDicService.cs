using TMom.Application.Service.IService;
using TMom.Domain.Model.Entity;
using TMom.Domain.IRepository;
using SqlSugar;
using TMom.Domain.Model;
using System.Linq.Expressions;
using TMom.Infrastructure;

namespace TMom.Application.Service.Service
{
    public class DataDicService : BaseService<DataDic, int>, IDataDicService
    {
        private readonly IBaseRepository<DataDic, int> _dal;
        private readonly IDataDicRepository _dataDicRepository;
        private readonly IUser _user;

        public DataDicService(IBaseRepository<DataDic, int> dal, IDataDicRepository dataDicRepository, IUser user)
        {
            this._dal = dal;
            base.BaseRepo = dal;
            _dataDicRepository = dataDicRepository;
            _user = user;
        }
    }
}