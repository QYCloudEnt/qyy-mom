import { http } from '@/api/http'
import { uploadFile } from '@/utils/request'
import type { AxiosProgressEvent } from 'axios'
import type { UploadFileParams } from '@/api/axios'

/** 工艺路线接口 */
export default {
  /**
   * 获取分页列表
   * @param query
   * @returns
   */
  getWithPage: (query: API.PageParams) =>
    http.get<API.TableListResult>('/ProcessRoute/GetWithPage', query),

  /**
   * 根据Id获取单条
   * @param id
   * @returns
   */
  getById: (id: number) => http.get(`/ProcessRoute/Get/${id}`),

  /**
   * 新增一条数据
   * @param data
   * @returns
   */
  add: (data: any) => http.post(`/ProcessRoute/Add`, data),

  /**
   * 删除数据
   * @param ids 主键Ids
   * @returns
   */
  delete: (ids: number[]) => http.delete(`/ProcessRoute/Delete`, { ids: ids.join(',') }),

  /**
   * 更新数据
   * @param data
   * @returns
   */
  update: (data: any) => http.put(`/ProcessRoute/Update`, data),

  /**
   * 更新流程数据
   * @param data
   */
  updateDesign: (data: any) => http.patch(`/ProcessRoute/UpdateDesign`, data),

  /**
   * 更新发布状态
   * @param data
   */
  updatePublishStatus: (data: { id: number; isPublish: boolean }) =>
    http.patch(`/ProcessRoute/UpdatePublishStatus`, data),

  /**
   * 上传作业指导书
   * @param params
   * @param onUploadProgress
   * @returns
   */
  uploadSop: (
    params: UploadFileParams,
    onUploadProgress: (progressEvent: AxiosProgressEvent) => void,
  ) =>
    uploadFile(
      {
        url: `/ProcessRoute/UploadSop`,
        onUploadProgress,
      },
      params,
    ),
}
