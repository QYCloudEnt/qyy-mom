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
    /// IBomService
    /// </summary>
    public interface IBomService : IBaseService<Bom, int>
    {
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="whereExp">查询条件表达式 Item1: 主表查询条件表达式, Item2: 导航表查询条件集合</param>
        /// <param name="pageIndex">页标, 默认1</param>
        /// <param name="pageSize">页数, 默认10</param>
        /// <param name="orderByFields">排序字段, 如name asc,age desc</param>
        /// <returns></returns>
        Task<PageModel<Bom>> GetWithPage((Expression<Func<Bom, bool>>, List<FormattableString>) whereExp, int pageIndex, int pageSize, string orderByFields = "");

        /// <summary>
        /// 根据主键Id获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Bom> GetById(int id);

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> AddData(Bom entity);

        /// <summary>
        /// 修改全部数据(默认根据主键更新)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>修改的主键Id</returns>
        Task<bool> UpdateData(Bom entity);

        /// <summary>
        /// 根据主键Id删除数据
        /// </summary>
        /// <param name="ids">多个以逗号分隔</param>
        /// <returns></returns>
        Task<bool> DeleteData(string ids);

        /// <summary>
        /// Bom和产品料号绑定(默认情况下两者Code一致关联)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> BindPart(BomBindPartParam model);

        /// <summary>
        /// 获取所有Bom集合
        /// </summary>
        /// <param name="whereExp"></param>
        /// <returns></returns>
        Task<List<Bom>> GetList((Expression<Func<Bom, bool>>, List<FormattableString>) whereExp);
    }
}