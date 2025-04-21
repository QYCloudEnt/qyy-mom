import { http } from '@/api/http'
import { request } from '@/utils/request'

/**
 * 系统角色接口
 */
export default {
  /**
   * 获取分页列表
   * @param query
   * @returns
   */
  getListByPage: (query: API.PageParams) => http.get('/SysRole/GetWithPage', query),

  /**
   * 根据Id获取单条
   * @param id
   * @returns
   */
  getById: (id: number) => http.get(`/SysRole/Get/${id}`),

  /**
   * 新增一条数据
   * @param data
   * @returns
   */
  add: (data: any) => http.post(`/SysRoleMenu/Add`, data),

  /**
   * 删除一条数据
   * @param id 主键Id
   * @returns
   */
  delete: (id: number) => http.delete(`/SysRole/Delete`, { id }),

  /**
   * 更新数据
   * @param data
   * @returns
   */
  update: (data: any) => http.put(`/SysRole/Update`, data),

  /**
   * 获取角色数据提供给选择框
   * @returns 直接返回data: [{label: 'xxx', value: 'xxx'}]
   */
  getRolesForSelect: () =>
    request<API.SelectResult[]>({
      url: `/SysRole/GetRolesForSelect`,
      method: 'GET',
      isReturnResult: true,
    }),
}
