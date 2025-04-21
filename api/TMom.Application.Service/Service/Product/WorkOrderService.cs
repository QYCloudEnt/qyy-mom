using System.Linq.Expressions;
using TMom.Application.Service.IService;
using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;
using TMom.Domain.Model;
using TMom.Infrastructure;
using TMom.Application.Dto;
using TMom.Infrastructure.Repository;

namespace TMom.Application.Service.Service
{
    public class WorkOrderService : BaseService<WorkOrder, int>, IWorkOrderService
    {
        #region 服务注入

        private readonly IBaseRepository<WorkOrder, int> _dal;
        private readonly IWorkOrderRepository _workOrderRepository;
        private readonly IUser _user;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHolidaysService _holidaysService;
        private readonly IPartMaterialService _partService;
        private readonly IBomService _bomService;

        public WorkOrderService(IBaseRepository<WorkOrder, int> dal,
            IWorkOrderRepository workOrderRepository, IUser user
            , IUnitOfWork unitOfWork, IHolidaysService holidaysService
            , IPartMaterialService partService, IBomService bomService)
        {
            this._dal = dal;
            base.BaseRepo = dal;
            _workOrderRepository = workOrderRepository;
            _user = user;
            _unitOfWork = unitOfWork;
            _holidaysService = holidaysService;
            _partService = partService;
            _bomService = bomService;
        }

        #endregion 服务注入

        #region 模板生成 CRUD

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="whereExp">查询条件表达式 Item1: 主表查询条件表达式, Item2: 导航表查询条件集合</param>
        /// <param name="pageIndex">页标, 默认1</param>
        /// <param name="pageSize">页数, 默认10</param>
        /// <param name="orderByFields">排序字段, 如name asc,age desc</param>
        /// <returns></returns>
        public async Task<PageModel<WorkOrder>> GetWithPage((Expression<Func<WorkOrder, bool>>, List<FormattableString>) whereExp
            , int pageIndex, int pageSize, string orderByFields = "")
        {
            var data = await _workOrderRepository.QueryIncludesPage(whereExp.Item1, pageIndex, pageSize, null, orderByFields
                            , whereExp.Item2, x => x.ProcessRoute, x => x.Part, x => x.Line);
            return data;
        }

        /// <summary>
        /// 根据主键Id获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<WorkOrder> GetById(int id)
        {
            var entity = (await _workOrderRepository.QueryIncludes(x => x.Part, x => x.Id == id)).First();
            return entity;
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> AddData(WorkOrder entity)
        {
            entity.UpdateCommonFields(_user.Id);
            var id = await _workOrderRepository.Add(entity);
            return id;
        }

        /// <summary>
        /// 修改全部数据(默认根据主键更新)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>修改的主键Id</returns>
        public async Task<bool> UpdateData(WorkOrder entity)
        {
            if (entity.Status == WorkOrderStatusEnum.Complete || entity.Status == WorkOrderStatusEnum.Close)
            {
                throw new CustomFailRequestException("当前工单状态不允许修改!");
            }
            entity.UpdateCommonFields(_user.Id, false);
            bool isSuccess = await _workOrderRepository.Update(entity, null, ["inputqty", "okqty", "scrapedqty"]);
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
            bool isSuccess = await _workOrderRepository.DeleteSoft(x => idList.Contains(x.Id), _user.Id);
            return isSuccess;
        }

        #endregion 模板生成 CRUD

        /// <summary>
        /// 工单拆分
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> SplitWorkOrder(SplitWorkOrderParams model)
        {
            var sourceWorkOrder = await _workOrderRepository.QueryById(model.SourceId);
            if (sourceWorkOrder.Status == WorkOrderStatusEnum.Complete || sourceWorkOrder.Status == WorkOrderStatusEnum.Close)
            {
                throw new CustomFailRequestException("当前源工单状态已完成, 无法拆分!");
            }
            sourceWorkOrder.Qty -= model.SplitQty;
            sourceWorkOrder.UpdateCommonFields(_user.Id, false);
            WorkOrder workOrder = new WorkOrder()
            {
                Type = sourceWorkOrder.Type,
                ProcessRouteId = sourceWorkOrder.ProcessRouteId,
                PartId = sourceWorkOrder.PartId,
                LineId = model.LineId,
                Status = WorkOrderStatusEnum.Initial,
                Qty = model.SplitQty,
                PlanDateS = model.PlanDateS,
                PlanDateE = model.PlanDateE,
                SourceCode = sourceWorkOrder.Code,
                Remark = model.Remark,
            };
            workOrder.UpdateCommonFields(_user.Id);
            _unitOfWork.BeginTran();
            await _workOrderRepository.Update(sourceWorkOrder);
            await _workOrderRepository.Add(workOrder);
            _unitOfWork.CommitTran();
            return true;
        }
    }
}