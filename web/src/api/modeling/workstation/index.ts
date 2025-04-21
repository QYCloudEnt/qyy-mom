import { http } from '@/api/http'

export default {
  /**
   * 获取分页列表
   * @param query
   * @returns
   */
  getWithPage: (query: API.PageParams) =>
    http.get<API.TableListResult>('/Workstation/GetWithPage', query),

  /**
   * 根据Id获取单条
   * @param id
   * @returns
   */
  getById: (id: number) => http.get(`/Workstation/Get/${id}`),

  /**
   * 新增一条数据
   * @param data
   * @returns
   */
  add: (data: any) => http.post(`/Workstation/Add`, data),

  /**
   * 删除数据
   * @param ids 主键Ids
   * @returns
   */
  delete: (ids: number[]) => http.delete(`/Workstation/Delete`, { ids: ids.join(',') }),

  /**
   * 更新数据
   * @param data
   * @returns
   */
  update: (data: any) => http.put(`/Workstation/Update`, data),

  /**
   * 根据产线id获取集合
   * @param lineId 产线id
   * @returns 工位实体集合
   */
  getListByLineId: (lineId: number) => http.get(`/Workstation/GetListByLineId?lineId=${lineId}`),

  /**
   * 获取当前登录用户有权限的产线集合(根据分配的工位判断)
   * @returns
   */
  getHasAuthLineList: () => http.get<any[]>(`/Workstation/GetHasAuthLineList`),

  /**
   * 根据产线id获取有权限的工位集合
   * @param lineId 产线id
   * @returns 工位实体集合
   */
  getHasAuthListByLineId: (lineId: number) =>
    http.get(`/Workstation/GetHasAuthListByLineId?lineId=${lineId}`),

  /**
   * 根据工位id获取对应的工序
   * @param workStationId 工位id
   * @returns 工序类
   */
  getProcessOperationByWorkStationId: (workStationId: number) =>
    http.get(`/Workstation/GetProcessOperationByWorkStationId?workStationId=${workStationId}`),

  /**
   * 获取分配工位的用户id集合
   * @param workStationId 工位id
   * @returns
   */
  getAssignUserIdByWorkStationId: (workStationId: number) =>
    http.get<number[]>(
      `/Workstation/GetAssignUserIdByWorkStationId?workStationId=${workStationId}`,
    ),

  /**
   * 分配工位给用户
   * @param data 参数
   * @returns
   */
  assignWorkStationToUser: (data: { workStationId: number; sysUserIds: number[] }) =>
    http.put(`/Workstation/AssignWorkStationToUser`, data),
}
