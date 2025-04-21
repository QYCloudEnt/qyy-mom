using System.Linq.Expressions;
using TMom.Application.Service.IService;
using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;
using TMom.Domain.Model;
using TMom.Infrastructure;

namespace TMom.Application.Service.Service
{
    public class WorkstationService : BaseService<Workstation, int>, IWorkstationService
    {
        private readonly IBaseRepository<Workstation, int> _dal;
        private readonly IWorkstationRepository _workstationRepository;
        private readonly IUser _user;
        private readonly IRedisRepository _redisRepository;
        private readonly IBaseRepository<WorkstationAndUser, int> _workstationAndUserRepository;

        public WorkstationService(IBaseRepository<Workstation, int> dal, IWorkstationRepository workstationRepository, IUser user
            , IRedisRepository redisRepository, IBaseRepository<WorkstationAndUser, int> workstationAndUserRepository)
        {
            this._dal = dal;
            base.BaseRepo = dal;
            _workstationRepository = workstationRepository;
            _user = user;
            _redisRepository = redisRepository;
            _workstationAndUserRepository = workstationAndUserRepository;
        }

        #region 模板生成 CRUD

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="whereExp">查询条件表达式 Item1: 主表查询条件表达式, Item2: 导航表查询条件集合</param>
        /// <param name="pageIndex">页标, 默认1</param>
        /// <param name="pageSize">页数, 默认10</param>
        /// <returns></returns>
        public async Task<PageModel<Workstation>> GetWithPage((Expression<Func<Workstation, bool>>, List<FormattableString>) whereExp, int pageIndex, int pageSize)
        {
            var data = await _workstationRepository.QueryIncludesPage(whereExp.Item1, pageIndex, pageSize, null, null, whereExp.Item2, x => x.ProcessOperation, x => x.Line);
            return data;
        }

        /// <summary>
        /// 根据主键Id获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Workstation> GetById(int id)
        {
            var entity = await _workstationRepository.QueryById(id);
            return entity;
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> AddData(Workstation entity)
        {
            entity.UpdateCommonFields(_user.Id);
            var id = await _workstationRepository.Add(entity);
            return id;
        }

        /// <summary>
        /// 修改全部数据(默认根据主键更新)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>修改的主键Id</returns>
        public async Task<bool> UpdateData(Workstation entity)
        {
            entity.UpdateCommonFields(_user.Id, false);
            bool isSuccess = await _workstationRepository.Update(entity);
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
            bool isSuccess = await _workstationRepository.DeleteSoft(x => idList.Contains(x.Id), _user.Id);
            return isSuccess;
        }

        #endregion 模板生成 CRUD

        /// <summary>
        /// 根据产线id获取集合
        /// </summary>
        /// <param name="lineId"></param>
        /// <returns></returns>
        public async Task<List<Workstation>> GetListByLineId(int lineId)
        {
            var dataList = await _workstationRepository.QueryIncludes(x => x.ProcessOperation, x => x.LineId == lineId);
            return dataList;
        }

        /// <summary>
        /// 根据产线id获取有权限的工位集合
        /// </summary>
        /// <param name="lineId"></param>
        /// <returns></returns>
        public async Task<List<Workstation>> GetHasAuthListByLineId(int lineId)
        {
            var workStationIds = await _workstationRepository.Query(x => x.Id, x => x.LineId == lineId, "");
            var hasAuthWorkStationIds = await _workstationAndUserRepository.Query(x => x.WorkstationId, x => x.SysUserId == _user.Id, "");
            if (hasAuthWorkStationIds == null || !hasAuthWorkStationIds.Any()) return new List<Workstation>();
            var dataList = await _workstationRepository.Query(x => hasAuthWorkStationIds.Contains(x.Id));
            return dataList;
        }

        /// <summary>
        /// 根据工位id获取工序
        /// </summary>
        /// <param name="workStationId"></param>
        /// <returns></returns>
        public async Task<ProcessOperation> GetProcessOperationByWorkStationId(int workStationId)
        {
            var data = (await _workstationRepository.QueryIncludes(x => x.ProcessOperation, x => x.Id == workStationId)).FirstOrDefault();
            if (data == null) return new ProcessOperation();
            return data.ProcessOperation;
        }
    }
}