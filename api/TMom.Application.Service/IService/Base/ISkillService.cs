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
    /// ISkillService
    /// </summary>
    public interface ISkillService : IBaseService<Skill, int>
    {
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="whereExp">查询条件表达式 Item1: 主表查询条件表达式, Item2: 导航表查询条件集合</param>
        /// <param name="pageIndex">页标, 默认1</param>
        /// <param name="pageSize">页数, 默认10</param>
        /// <param name="orderByFields">排序字段, 如name asc,age desc</param>
        /// <returns></returns>
        Task<PageModel<Skill>> GetWithPage((Expression<Func<Skill, bool>>, List<FormattableString>) whereExp, int pageIndex, int pageSize, string orderByFields = "");

        /// <summary>
        /// 根据主键Id获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Skill> GetById(int id);

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> AddData(Skill entity);

        /// <summary>
        /// 修改全部数据(默认根据主键更新)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>修改的主键Id</returns>
        Task<bool> UpdateData(Skill entity);

        /// <summary>
        /// 根据主键Id删除数据
        /// </summary>
        /// <param name="ids">多个以逗号分隔</param>
        /// <returns></returns>
        Task<bool> DeleteData(string ids);

        /// <summary>
        /// 分配技能给用户
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="sysUserIds">用户id集合</param>
        /// <returns></returns>
        Task<bool> AssignSkillToUser(int skillId, List<int> sysUserIds);

        /// <summary>
        /// 获取分配技能的用户Id集合
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <returns></returns>
        Task<List<int>> GetAssignUserIdBySkillId(int skillId);
    }
}