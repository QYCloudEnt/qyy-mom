import { http } from '@/api/http'

export default {
  /**
   * 获取分页列表
   * @param query
   * @returns
   */
  getWithPage: (query: API.PageParams) =>
    http.get<API.TableListResult>('/ProductLock/GetWithPage', query),

  /**
   * 产品锁定
   * @param data
   * @returns
   */
  lock: (data: any) => http.post(`/ProductLock/Lock`, data),

  /**
   * 产品解锁
   * @param ids
   * @returns
   */
  unLock: (ids: string) => http.postStr(`/ProductLock/UnLock`, { ids }),

  /**
   * 获取锁定的数据信息
   * @param data
   * @returns
   */
  getLockInfo: (data: any) =>
    http.post(`/ProductLock/GetLockInfo`, data, { showSuccessMsg: false }),
}
