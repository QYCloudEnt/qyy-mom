import { http } from '@/api/http'

export default {
  /**
   * 获取分页列表
   * @param query
   * @returns
   */
  getWithPage: (query: API.PageParams) => http.get<API.TableListResult>('/Bom/GetWithPage', query),

  /**
   * 获取所有Bom列表
   * @param query
   * @returns
   */
  getList: (query: API.PageParams) => http.get('/Bom/GetList', query),

  /**
   * 根据Id获取单条
   * @param id
   * @returns
   */
  getById: (id: number) => http.get(`/Bom/Get/${id}`),

  /**
   * 新增一条数据
   * @param data
   * @returns
   */
  add: (data: any) => http.post(`/Bom/Add`, data),

  /**
   * 删除数据
   * @param ids 主键Ids
   * @returns
   */
  delete: (ids: number[]) => http.delete(`/Bom/Delete`, { ids: ids.join(',') }),

  /**
   * 更新数据
   * @param data
   * @returns
   */
  update: (data: any) => http.put(`/Bom/Update`, data),

  /**
   * BOM关联产品
   * @param data
   * @returns
   */
  bindPart: (data: any) => http.patch(`/Bom/BindPart`, data),
}
