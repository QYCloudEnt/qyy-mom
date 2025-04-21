import { http } from '@/api/http'
import { request } from '@/utils/request'

/**
 * 数据字典接口
 */
export default {
  /**
   * 获取分页列表
   * @param query
   * @returns
   */
  getWithPage: (query: API.PageParams) =>
    http.get<API.TableListResult>('/DataDic/GetWithPage', query),

  /**
   * 根据Id获取单条
   * @param id
   * @returns
   */
  getById: (id: number) => http.get(`/DataDic/Get/${id}`),

  /**
   * 获取所有分类
   * @param key 分类编码或名称
   * @returns
   */
  getCateoryList: (key?: string) => http.get(`/DataDic/GetCateoryList`, { key }),

  /**
   * 根据分类名称获取数据字典
   * @param cateoryName 分类名称
   * @returns list
   */
  getByCateoryName: (cateoryName: string) => http.get(`/DataDic/GetByCateoryName`, { cateoryName }),

  /**
   * 新增一条数据
   * @param data
   * @returns
   */
  add: (data: any) => http.post(`/DataDic/Add`, data),

  /**
   * 删除一条数据
   * @param id 主键Id
   * @returns
   */
  delete: (id: number) => http.delete(`/DataDic/Delete`, { id }),

  /**
   * 更新数据
   * @param data
   * @returns
   */
  update: (data: any) => http.put(`/DataDic/Update`, data),

  /**
   * 获取字典数据提供给选择框
   * @param categoryName 分类名称
   * @returns
   */
  getForSelect: (categoryName: string) =>
    request<API.SelectResult[]>({
      url: `/DataDic/GetForSelect`,
      method: 'GET',
      params: { categoryName },
      isReturnResult: true,
    }),
}
