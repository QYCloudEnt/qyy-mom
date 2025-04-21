using System.Linq.Expressions;
using TMom.Application.Service.IService;
using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;
using TMom.Domain.Model;
using TMom.Infrastructure;

namespace TMom.Application.Service.Service
{
    public class ProcessOperationService : BaseService<ProcessOperation, int>, IProcessOperationService
    {
        private readonly IBaseRepository<ProcessOperation, int> _dal;
        private readonly IProcessOperationRepository _processOperationRepository;
        private readonly IUser _user;
        private readonly IRedisRepository _redisRepository;

        public ProcessOperationService(IBaseRepository<ProcessOperation, int> dal,
            IProcessOperationRepository processOperationRepository, IUser user
            , IRedisRepository redisRepository)
        {
            this._dal = dal;
            base.BaseRepo = dal;
            _processOperationRepository = processOperationRepository;
            _user = user;
            _redisRepository = redisRepository;
        }

        #region 模板生成 CRUD

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="whereExp">查询条件表达式 Item1: 主表查询条件表达式, Item2: 导航表查询条件集合</param>
        /// <param name="pageIndex">页标, 默认1</param>
        /// <param name="pageSize">页数, 默认10</param>
        /// <param name="orderByFields">排序字段, 如name asc,age desc</param>
        /// <returns></returns>
        public async Task<PageModel<ProcessOperation>> GetWithPage((Expression<Func<ProcessOperation, bool>>, List<FormattableString>) whereExp, int pageIndex, int pageSize, string orderByFields = "id desc")
        {
            var data = await _processOperationRepository.QueryPage(whereExp.Item1, pageIndex, pageSize, null, orderByFields);
            return data;
        }

        /// <summary>
        /// 根据主键Id获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProcessOperation> GetById(int id)
        {
            var entity = await _processOperationRepository.QueryById(id);
            return entity;
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> AddData(ProcessOperation entity)
        {
            entity.UpdateCommonFields(_user.Id);
            var id = await _processOperationRepository.Add(entity);
            return id;
        }

        /// <summary>
        /// 修改全部数据(默认根据主键更新)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>修改的主键Id</returns>
        public async Task<bool> UpdateData(ProcessOperation entity)
        {
            entity.UpdateCommonFields(_user.Id, false);
            bool isSuccess = await _processOperationRepository.Update(entity);
            return isSuccess;
        }

        /// <summary>
        /// 根据主键Id删除数据
        /// </summary>
        /// <param name="ids">多个以逗号分隔</param>
        /// <returns></returns>
        public async Task<bool> DeleteData(string ids)
        {
            List<int> idList = ids.Split(',').Select(id => id.ObjToInt()).ToList();
            bool isSuccess = await _processOperationRepository.DeleteSoft(x => idList.Contains(x.Id), _user.Id);
            return isSuccess;
        }

        #endregion 模板生成 CRUD
    }
}