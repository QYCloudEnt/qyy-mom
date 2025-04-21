using System.Linq.Expressions;
using TMom.Application.Service.IService;
using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;
using TMom.Domain.Model;
using TMom.Infrastructure;
using TMom.Application.Dto;

namespace TMom.Application.Service.Service
{
    public class ProductLockService : BaseService<ProductLock, int>, IProductLockService
    {
        private readonly IBaseRepository<ProductLock, int> _dal;
        private readonly IProductLockRepository _productLockRepository;
        private readonly IUser _user;
        private readonly IPartMaterialRepository _partMaterialRepository;
        private readonly IWorkOrderRepository _workOrderRepository;

        public ProductLockService(IBaseRepository<ProductLock, int> dal, IProductLockRepository productLockRepository, IUser user
            , IPartMaterialRepository partMaterialRepository, IWorkOrderRepository workOrderRepository)
        {
            this._dal = dal;
            base.BaseRepo = dal;
            _productLockRepository = productLockRepository;
            _user = user;
            _partMaterialRepository = partMaterialRepository;
            _workOrderRepository = workOrderRepository;
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="whereExp">查询条件表达式 Item1: 主表查询条件表达式, Item2: 导航表查询条件集合</param>
        /// <param name="pageIndex">页标, 默认1</param>
        /// <param name="pageSize">页数, 默认10</param>
        /// <param name="orderByFields">排序字段, 如name asc,age desc</param>
        /// <returns></returns>
        public async Task<PageModel<ProductLock>> GetWithPage((Expression<Func<ProductLock, bool>>, List<FormattableString>) whereExp
            , int pageIndex, int pageSize, string orderByFields = "")
        {
            var data = await _productLockRepository.QueryIncludesPage(whereExp.Item1, pageIndex, pageSize, null, orderByFields
                        , whereExp.Item2, x => x.ProcessOperation);
            var users = await CommonCache.GetAllUserWithCache();
            data.list.ForEach(p =>
            {
                var user = users.FirstOrDefault(x => x.id == p.LockUserId);
                p.LockUser = user == null ? "" : $"({user.code}){user.name}";
                if (p.UnLockUserId.HasValue)
                {
                    var unLockUser = users.FirstOrDefault(x => x.id == p.UnLockUserId.Value);
                    p.UnLockUser = unLockUser == null ? "" : $"({unLockUser.code}){unLockUser.name}";
                }
            });
            return data;
        }

        /// <summary>
        /// 解锁
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<bool> UnLock(List<int> ids)
        {
            var list = await _dal.Query(x => ids.Contains(x.Id));
            int userId = _user.Id;
            list.ForEach(p =>
            {
                p.Status = LockStatus.UnLock;
                p.UnLockUserId = userId;
                p.UnLockTime = DateTime.Now;
                p.UpdateId = userId;
                p.UpdateTime = DateTime.Now;
            });
            bool res = await _dal.Update(list);
            return res;
        }

        /// <summary>
        /// 产品锁定
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<bool> Lock(LockDto dto)
        {
            var lst = dto.Datas;
            if (lst == null || !lst.Any()) return false;
            int userId = _user.Id;
            List<ProductLock> locks = lst.Select(item =>
            {
                DateTime? timeS = null;
                DateTime? timeE = null;
                if (!string.IsNullOrWhiteSpace(item.LockTime))
                {
                    var timeArr = item.LockTime.Split('~');
                    timeS = DateTime.Parse(timeArr[0].Trim());
                    timeE = DateTime.Parse(timeArr[1].Trim());
                }
                return new ProductLock
                {
                    Type = item.Type,
                    BusinessId = item.BusinessId,
                    Code = item.Code,
                    OperationId = item.OperationId,
                    DateS = timeS,
                    DateE = timeE,
                    Status = LockStatus.Lock,
                    LockUserId = userId,
                    LockTime = DateTime.Now,
                    LockReason = dto.Reason,
                    CreateId = userId,
                    CreateTime = DateTime.Now,
                };
            }).ToList();
            var ids = await _dal.Add(locks);
            return ids.Any();
        }

        /// <summary>
        /// 获取锁定的数据信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<List<ProductLockDto>> GetLockInfo(ProductLockParam param)
        {
            List<ProductLockDto> list = new List<ProductLockDto>();
            switch (param.Type)
            {
                case ProductLockType.Part:
                    list = await GetPartLock(param);
                    break;

                case ProductLockType.WorkOrder:
                    list = await GetWorkOrderLock(param);
                    break;
            }
            if (param.TimeS.HasValue)
            {
                list.ForEach(item => item.LockTime = $"{param.TimeS.Value.ToString("yyyy-MM-dd HH:mm:ss")} ~ {param.TimeE!.Value.ToString("yyyy-MM-dd HH:mm:ss")}");
            }
            if (param.OperationId.HasValue)
            {
                var operation = await _dal.Db.Queryable<ProcessOperation>().Where(x => x.Id == param.OperationId && !x.IsDeleted).FirstAsync();
                list.ForEach(item =>
                {
                    item.OperationId = operation.Id;
                    item.Operation = $"({operation.Code}){operation.Name}";
                });
            }
            return list;
        }

        #region 获取锁定信息

        /// <summary>
        /// 获取锁定主数据类型的数据
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        /// <exception cref="CustomFailRequestException"></exception>
        private async Task<List<ProductLockDto>> GetPartLock(ProductLockParam param)
        {
            var data = await _partMaterialRepository.QueryIncludes(x => x.PartGroup
                        , x => x.PartGroup.Type == PartGroupType.Product && param.Codes.Contains(x.Code));
            if (data == null || !data.Any()) throw new CustomFailRequestException($"不存在产品主数据的数据, 请检查输入的编码是否正确!");
            var list = data.Select(item => new ProductLockDto
            {
                Code = item.Code,
                Type = param.Type,
                BusinessId = item.Id,
            }).ToList();
            return list;
        }

        /// <summary>
        /// 获取锁定工单类型的数据
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        /// <exception cref="CustomFailRequestException"></exception>
        private async Task<List<ProductLockDto>> GetWorkOrderLock(ProductLockParam param)
        {
            var data = await _workOrderRepository.Query(x => param.Codes.Contains(x.Code));
            if (data == null || !data.Any()) throw new CustomFailRequestException($"不存在工单数据, 请检查输入的编码是否正确!");
            var list = data.Select(item => new ProductLockDto
            {
                Code = item.Code,
                Type = param.Type,
                BusinessId = item.Id,
            }).ToList();
            return list;
        }

        #endregion 获取锁定信息
    }
}