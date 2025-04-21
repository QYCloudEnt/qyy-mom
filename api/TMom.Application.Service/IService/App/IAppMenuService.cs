using TMom.Domain.Model.Entity;
using TMom.Domain.Model;
using System.Linq.Expressions;
using TMom.Application.Dto;

namespace TMom.Application.Service.IService
{
    /// <summary>
    /// IAppMenuService
    /// </summary>
    public interface IAppMenuService : IBaseService<AppMenu, int>
    {
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        Task<int> AddData(AppMenuAddParam para);

        /// <summary>
        /// 根据主键Id删除数据
        /// </summary>
        /// <param name="ids">多个以逗号分隔</param>
        /// <returns></returns>
        Task<bool> DeleteData(string ids);

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        Task<bool> Save(List<AppMenuDto> para);

        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <returns></returns>
        Task<List<AppMenuDto>> GetList();

        /// <summary>
        /// 获取当前用户拥有权限的菜单列表
        /// </summary>
        /// <returns></returns>
        Task<List<AppMenuDto>> GetAuthMenus();
    }
}