using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMom.Domain.Model.Entity;
using TMom.Domain.Model;
using TMom.Application.Dto;

namespace TMom.Application.Service.IService
{
    /// <summary>
    /// IProductLockService
    /// </summary>
    public interface IProductLockService : IBaseService<ProductLock, int>
    {
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="whereExp">查询条件表达式 Item1: 主表查询条件表达式, Item2: 导航表查询条件集合</param>
        /// <param name="pageIndex">页标, 默认1</param>
        /// <param name="pageSize">页数, 默认10</param>
        /// <param name="orderByFields">排序字段, 如name asc,age desc</param>
        /// <returns></returns>
        Task<PageModel<ProductLock>> GetWithPage((Expression<Func<ProductLock, bool>>, List<FormattableString>) whereExp, int pageIndex, int pageSize, string orderByFields = "");

        /// <summary>
        /// 产品锁定
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<bool> Lock(LockDto dto);

        /// <summary>
        /// 解锁
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<bool> UnLock(List<int> ids);

        /// <summary>
        /// 获取锁定的数据信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<List<ProductLockDto>> GetLockInfo(ProductLockParam param);
    }
}