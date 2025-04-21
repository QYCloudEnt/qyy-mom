import { request, type RequestOptions } from '@/utils/request'

/**
 * 封装常用的http请求
 */
const http = {
  /**
   * HTTP GET
   * @param url 请求url
   * @param params 参数
   * @param options 其他配置
   * @returns
   */
  get<T = any>(url: string, params?: object | null, options?: RequestOptions) {
    return request<T>(url, {
      method: 'GET',
      params,
      ...(options || {}),
    }) // as Promise<BaseResponse<T>> | Promise<T>
  },

  /**
   * HTTP POST
   * @param url 请求url
   * @param data 参数
   * @param options 其他配置
   * @returns
   */
  post(url: string, data: object, options?: RequestOptions) {
    return request(url, {
      method: 'POST',
      data,
      showSuccessMsg: true,
      ...(options || {}),
    })
  },

  /**
   * HTTP POST, 把参数添加到url中
   * @param url 请求url
   * @param data 参数
   * @param options 其他配置
   * @returns
   */
  postStr(url: string, data: object, options?: RequestOptions) {
    return request(url, {
      method: 'POST',
      data,
      showSuccessMsg: true,
      isJoinParamsToUrl: true,
      ...(options || {}),
    })
  },

  /**
   * HTTP DELETE
   * @param url 请求url
   * @param params 参数
   * @param data 参数
   * @returns
   */
  delete(url: string, params: object) {
    return request(url, {
      method: 'DELETE',
      params,
      successMsg: '删除成功!',
    })
  },

  /**
   * HTTP PUT
   * @param url 请求url
   * @param data 参数
   * @param options 其他配置
   * @returns
   */
  put(url: string, data: object, options?: RequestOptions) {
    return request(url, {
      method: 'PUT',
      data,
      showSuccessMsg: true,
      ...(options || {}),
    })
  },

  /**
   * HTTP PATCH
   * @param url 请求url
   * @param data 参数
   * @param options 其他配置
   * @returns
   */
  patch(url: string, data: object, options?: RequestOptions) {
    return request(url, {
      method: 'PATCH',
      data,
      showSuccessMsg: true,
      ...(options || {}),
    })
  },
}

export { http }
