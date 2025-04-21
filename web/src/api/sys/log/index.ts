import { http } from '@/api/http'

/**
 * 系统日志接口
 */
export default {
  /**
   * 获取分页列表(文件中获取)
   * @param query
   * @returns
   */
  getWithPageFromFile: (query: API.PageParams) =>
    http.get<API.TableListResult<API.SysLogResult>>('/SysLog/GetWithPage', query),

  /**
   * 获取分页列表(数据库表中获取)
   * @param query
   * @returns
   */
  getWithPageFromDb: (query: API.PageParams) =>
    http.get<API.TableListResult<API.SysLogResult>>('/SysLog/GetWithPageFromDb', query),
}
