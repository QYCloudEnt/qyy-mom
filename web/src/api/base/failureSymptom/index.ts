import { http } from '@/api/http'

/** 不良现象接口 */
export default {
  /**
   * 获取分页列表
   * @param query
   * @returns
   */
  getWithPage: (query: API.PageParams) =>
    http.get<API.TableListResult>('/FailureSymptom/GetWithPage', query),

  /**
   * 根据Id获取单条
   * @param id
   * @returns
   */
  getById: (id: number) => http.get(`/FailureSymptom/Get/${id}`),

  /**
   * 新增一条数据
   * @param data
   * @returns
   */
  add: (data: any) => http.post(`/FailureSymptom/Add`, data),

  /**
   * 删除数据
   * @param ids 主键Ids
   * @returns
   */
  delete: (ids: number[]) => http.delete(`/FailureSymptom/Delete`, { ids: ids.join(',') }),

  /**
   * 更新数据
   * @param data
   * @returns
   */
  update: (data: any) => http.put(`/FailureSymptom/Update`, data),

  /**
   * 获取不良现象Options
   * @param typeId 不良类型Id
   * @returns
   */
  getFailureSymptomOptions: (typeId?: number) =>
    http.get<API.SelectResult[]>(`/FailureSymptom/GetFailureSymptomOptions?typeId=${typeId}`),
}
