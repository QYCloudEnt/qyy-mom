import { http } from '@/api/http'

/**
 * 系统菜单接口
 */
export default {
  /**
   * 获取系统所有菜单列表(不是tree)
   * @returns
   */
  getMenuList: () => http.get(`/SysMenu/GetMenuList`),

  /**
   * 根据角色Id获取角色菜单
   * @returns
   */
  getMenuListByRoleId: (id: number) => http.get(`/SysMenu/GetMenuByRoleId`, { roleId: id }),

  /**
   * 新增一条数据
   * @param data
   * @returns
   */
  add: (data: any) => http.post(`/SysMenu/Add`, data),

  /**
   * 删除一条数据
   * @param id 主键Id
   * @returns
   */
  delete: (id: number) => http.delete(`/SysMenu/Delete`, { id }),

  /**
   * 更新数据
   * @param data
   * @returns
   */
  update: (data: any) => http.put(`/SysMenu/Update`, data),

  /**
   * 获取所有api权限列表(反射所有控制器中方法)
   * @returns
   */
  getPermsByReflection: () => http.get(`/SysMenu/GetPermList`),
}
