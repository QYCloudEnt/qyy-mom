using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMom.Domain.Model.Entity;
using TMom.Domain.Model;

namespace TMom.Application.Service.IService
{
    /// <summary>
    /// IWorkstationService
    /// </summary>
    public interface IWorkstationService : IBaseService<Workstation, int>
    {
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="whereExp">查询条件表达式 Item1: 主表查询条件表达式, Item2: 导航表查询条件集合</param>
        /// <param name="pageIndex">页标, 默认1</param>
        /// <param name="pageSize">页数, 默认10</param>
        /// <returns></returns>
        Task<PageModel<Workstation>> GetWithPage((Expression<Func<Workstation, bool>>, List<FormattableString>) whereExp, int pageIndex, int pageSize);

        /// <summary>
        /// 根据主键Id获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Workstation> GetById(int id);

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> AddData(Workstation entity);

        /// <summary>
        /// 修改全部数据(默认根据主键更新)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>修改的主键Id</returns>
        Task<bool> UpdateData(Workstation entity);

        /// <summary>
        /// 根据主键Id删除数据
        /// </summary>
        /// <param name="ids">多个以逗号分隔</param>
        /// <returns></returns>
        Task<bool> DeleteData(string ids);

        /// <summary>
        /// 根据产线id获取集合
        /// </summary>
        /// <param name="lineId"></param>
        /// <returns></returns>
        Task<List<Workstation>> GetListByLineId(int lineId);

        /// <summary>
        /// 根据产线id获取有权限的工位集合
        /// </summary>
        /// <param name="lineId"></param>
        /// <returns></returns>
        Task<List<Workstation>> GetHasAuthListByLineId(int lineId);

        /// <summary>
        /// 根据工位id获取工序
        /// </summary>
        /// <param name="workStationId"></param>
        /// <returns></returns>
        Task<ProcessOperation> GetProcessOperationByWorkStationId(int workStationId);
    }
}