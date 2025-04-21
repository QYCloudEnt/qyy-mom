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
    /// IWorkshopService
    /// </summary>
    public interface IWorkshopService : IBaseService<Workshop, int>
    {
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="whereExp">查询条件表达式 Item1: 主表查询条件表达式, Item2: 导航表查询条件集合</param>
        /// <param name="pageIndex">页标, 默认1</param>
        /// <param name="pageSize">页数, 默认10</param>
        /// <returns></returns>
        Task<PageModel<Workshop>> GetWithPage((Expression<Func<Workshop, bool>>, List<FormattableString>) whereExp, int pageIndex, int pageSize);

        /// <summary>
        /// 根据主键Id获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Workshop> GetById(int id);

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> AddData(Workshop entity);

        /// <summary>
        /// 修改全部数据(默认根据主键更新)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>修改的主键Id</returns>
        Task<bool> UpdateData(Workshop entity);

        /// <summary>
        /// 根据主键Id删除数据
        /// </summary>
        /// <param name="ids">多个以逗号分隔</param>
        /// <returns></returns>
        Task<bool> DeleteData(string ids);
    }
}