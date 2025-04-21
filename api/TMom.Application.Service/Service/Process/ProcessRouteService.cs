using System.Linq.Expressions;
using TMom.Application.Service.IService;
using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;
using TMom.Domain.Model;
using TMom.Infrastructure;
using TMom.Infrastructure.Repository;
using TMom.Application.Dto;

namespace TMom.Application.Service.Service
{
    public class ProcessRouteService : BaseService<ProcessRoute, int>, IProcessRouteService
    {
        private readonly IBaseRepository<ProcessRoute, int> _dal;
        private readonly IProcessRouteRepository _processRouteRepository;
        private readonly IUser _user;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProcessRouteBaseRepository _processRouteBaseRepository;
        private readonly IProcessRouteSequenceRepository _processRouteSequenceRepository;
        private readonly IProcessRouteTestRepository _processRouteTestRepository;
        private readonly IRedisRepository _redisRepository;

        public ProcessRouteService(IBaseRepository<ProcessRoute, int> dal, IProcessRouteRepository processRouteRepository, IUser user
            , IUnitOfWork unitOfWork, IProcessRouteBaseRepository processRouteBaseRepository
            , IProcessRouteSequenceRepository processRouteSequenceRepository, IProcessRouteTestRepository processRouteTestRepository
            , IRedisRepository redisRepository)
        {
            this._dal = dal;
            base.BaseRepo = dal;
            _processRouteRepository = processRouteRepository;
            _user = user;
            _unitOfWork = unitOfWork;
            _processRouteBaseRepository = processRouteBaseRepository;
            _processRouteSequenceRepository = processRouteSequenceRepository;
            _processRouteTestRepository = processRouteTestRepository;
            _redisRepository = redisRepository;
        }

        #region 模板生成 CRUD

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="whereExp">条件表达式</param>
        /// <param name="pageIndex">页标, 默认1</param>
        /// <param name="pageSize">页数, 默认10</param>
        /// <param name="selectExp">查询表达式</param>
        /// <returns></returns>
        public async Task<PageModel<ProcessRoute>> GetWithPage((Expression<Func<ProcessRoute, bool>>, List<FormattableString>) whereExp, int pageIndex, int pageSize
            , string orderByFields, Expression<Func<ProcessRoute, ProcessRoute>>? selectExp)
        {
            var data = await _processRouteRepository.QueryPage(whereExp.Item1, pageIndex, pageSize, selectExp, orderByFields);
            return data;
        }

        /// <summary>
        /// 根据主键Id获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProcessRoute> GetById(int id)
        {
            var entity = await _processRouteRepository.QueryById(id);
            return entity;
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> AddData(ProcessRoute entity)
        {
            entity.UpdateCommonFields(_user.Id);
            var id = await _processRouteRepository.Add(entity);
            return id;
        }

        /// <summary>
        /// 修改全部数据(默认根据主键更新)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>修改的主键Id</returns>
        public async Task<bool> UpdateData(ProcessRoute entity)
        {
            entity.UpdateCommonFields(_user.Id, false);
            bool isSuccess = await _processRouteRepository.Update(entity);
            return isSuccess;
        }

        /// <summary>
        /// 根据主键Id删除数据
        /// </summary>
        /// <param name="ids">多个以逗号分隔</param>
        /// <returns></returns>
        [UseTran]
        public async Task<bool> DeleteData(string ids)
        {
            List<int> idList = ids.Split(',').Select(id => id.ObjToInt()).ToList();

            await _processRouteSequenceRepository.DeleteSoft(x => idList.Contains(x.Id), _user.Id);
            await _processRouteBaseRepository.DeleteSoft(x => idList.Contains(x.Id), _user.Id);
            await _processRouteTestRepository.DeleteSoft(x => idList.Contains(x.Id), _user.Id);
            bool isSuccess = await _processRouteRepository.DeleteSoft(x => idList.Contains(x.Id), _user.Id);
            return isSuccess;
        }

        #endregion 模板生成 CRUD

        /// <summary>
        /// 更新流程数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="CustomFailRequestException"></exception>
        public async Task<bool> UpdateDesign(ProcessRouteDesignParams model)
        {
            var entity = await _processRouteRepository.QueryById(model.Id);
            if (entity == null) throw new CustomFailRequestException($"工艺路线不存在, 无法修改! Id: {model.Id}");
            int startCnt = model.ConfigForm.Count(x => x.Base.IsStart);
            int endCnt = model.ConfigForm.Count(x => x.Base.IsOutput);
            bool checkJumpRouteHasError = model.ConfigForm.Select(item => item.Base)
                .Any(x => (x.JumpToRouteId.HasValue && !x.BackOperationId.HasValue) || (x.BackOperationId.HasValue && !x.JumpToRouteId.HasValue));
            if (checkJumpRouteHasError) throw new CustomFailRequestException($"跳转的工艺路线和返回的工序必须全都为空或不为空!");

            // 新增
            List<ProcessRouteSequence> addSequences = model.ProcessData.Select(x => new ProcessRouteSequence()
            {
                ProcessRouteId = model.Id,
                OperationId = x.Id,
                NextOperationId = x.NextId,
                Status = x.Label,
            }).ToList();
            List<ProcessRouteBase> addBases = model.ConfigForm.Select(x => new ProcessRouteBase()
            {
                ProcessRouteId = model.Id,
                OperationId = x.Id,
                IsStart = x.Base.IsStart,
                IsOutput = x.Base.IsOutput,
                IsLackMaterialWarn = x.Base.IsLackMaterialWarn,
                JumpToRouteId = x.Base.JumpToRouteId,
                BackOperationId = x.Base.BackOperationId,
            }).ToList();
            List<ProcessRouteTest> addTests = model.ConfigForm.Select(x => new ProcessRouteTest()
            {
                ProcessRouteId = model.Id,
                OperationId = x.Id,
                TestMode = x.Test.TestMode,
                MaxTestCount = x.Test.MaxTestCount,
            }).ToList();
            entity.Content = model.Graph;
            entity.UpdateCommonFields(_user.Id, false);

            _unitOfWork.BeginTran();
            // 删除
            await _processRouteSequenceRepository.DeleteSoft(x => x.ProcessRouteId == model.Id, _user.Id);
            await _processRouteBaseRepository.DeleteSoft(x => x.ProcessRouteId == model.Id, _user.Id);
            await _processRouteTestRepository.DeleteSoft(x => x.ProcessRouteId == model.Id, _user.Id);

            await _processRouteSequenceRepository.Add(addSequences);
            await _processRouteBaseRepository.Add(addBases);
            await _processRouteTestRepository.Add(addTests);
            bool res = await _processRouteRepository.Update(entity, x => new { x.ImgUrl, x.Content });
            _unitOfWork.CommitTran();
            return res;
        }

        /// <summary>
        /// 更新发布状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> UpdatePublishStatus(ProcessRouteStatusParams model)
        {
            var entity = await _processRouteRepository.QueryById(model.Id);
            entity.Status = model.IsPublish ? PublishStatusEnum.Published : PublishStatusEnum.UnPublish;
            entity.UpdateCommonFields(_user.Id, false);
            bool res = await _processRouteRepository.Update(entity, x => new { x.Status });
            return res;
        }
    }
}