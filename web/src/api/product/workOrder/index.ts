import { http } from '@/api/http'

export default {
  /**
   * 获取分页列表
   * @param query
   * @returns
   */
  getWithPage: (query: API.PageParams) =>
    http.get<API.TableListResult>('/WorkOrder/GetWithPage', query),

  /**
   * 根据Id获取单条
   * @param id
   * @returns
   */
  getById: (id: number) => http.get(`/WorkOrder/Get/${id}`),

  /**
   * 新增一条数据
   * @param data
   * @returns
   */
  add: (data: any) => http.post(`/WorkOrder/Add`, data),

  /**
   * 删除数据
   * @param ids 主键Ids
   * @returns
   */
  delete: (ids: number[]) => http.delete(`/WorkOrder/Delete`, { ids: ids.join(',') }),

  /**
   * 更新数据
   * @param data
   * @returns
   */
  update: (data: any) => http.put(`/WorkOrder/Update`, data),

  /**
   * 工单拆分
   * @param data
   * @returns
   */
  splitWorkOrder: (data: any) => http.post(`/WorkOrder/SplitWorkOrder`, data),

  /**
   * 获取工单释放条码信息
   * @param id 工单id
   * @returns
   */
  getReleaseSnInfo: (id: number) =>
    http.get<WorkOrderReleaseSn>(`/WorkOrder/GetReleaseSnInfo`, { id }),

  /** 释放产品条码 */
  releaseProductSn: (data: any) => http.post(`/WorkOrder/ReleaseProductSn`, data),

  /**
   * 分页获取工单下的产品sn列表
   * @param query
   * @returns
   */
  getProductSnList: (query: API.PageParams) =>
    http.get<API.TableListResult>('/WorkOrder/GetProductSnList', query),

  /**
   * 根据工单状态获取工单集合
   * @param statusList 工单状态集合
   * @returns
   */
  getWorkOrderForSelect: (statusList: string[]) =>
    http.get<API.SelectResult[]>(`/WorkOrder/GetWorkOrderForSelect`, {
      statusStrs: statusList.join(','),
    }),

  /**
   * 备料
   * @param id 工单id
   * @returns
   */
  prepMaterial: (id: number) => http.postStr(`/WorkOrder/PrepMaterial`, { id }),
}
