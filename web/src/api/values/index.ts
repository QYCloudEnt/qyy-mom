import { http } from '@/api/http'
import { uploadFile } from '@/utils/request'
import type { AxiosProgressEvent } from 'axios'
import type { UploadFileParams } from '@/api/axios'

/**
 * 测试 api
 */
export default {
  /**
   * 测试 上传文件
   * @param params 文件参数
   * @param onUploadProgress
   * @returns
   */
  UploadFile: (
    params: UploadFileParams,
    onUploadProgress: (progressEvent: AxiosProgressEvent) => void,
  ) =>
    uploadFile(
      {
        url: `/Values/UploadFile`,
        onUploadProgress,
      },
      params,
    ),

  /**
   * 测试 读取Excel文件
   * @param params 文件参数
   * @param onUploadProgress
   * @returns
   */
  ReadExcelData: (
    params: UploadFileParams,
    onUploadProgress: (progressEvent: AxiosProgressEvent) => void,
  ) =>
    uploadFile(
      {
        url: `/Values/ReadExcelData`,
        onUploadProgress,
      },
      params,
    ),

  /**
   * 获取分页列表
   * @param query
   * @returns
   */
  getWithPage: (query: API.PageParams) => http.get<API.TableListResult>('/Values/Get', query),
}
