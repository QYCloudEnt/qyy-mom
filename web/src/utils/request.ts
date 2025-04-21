import axios, { CanceledError } from 'axios'
import { isString, set } from 'lodash-es'
import qs from 'qs'
import { message as $message, Modal } from 'ant-design-vue'
import type { AxiosRequestConfig, AxiosResponse } from 'axios'
import { ACCESS_TOKEN_KEY, IS_CHANGE_ROUTER, REFRESH_TIME } from '@/enums/cacheEnum'
import { Storage } from '@/utils/Storage'
import { ContentTypeEnum, ResultEnum } from '@/enums/httpEnum'
import { useUserStore, useUserStoreWithOut } from '@/store/modules/user'
import { start, close } from '@/utils/nprogress'
import { saveRefreshtime } from '@/api/saveRefreshTime'
import { isObject, isHttpUrl } from '@/utils/is'
import { refreshToken } from '@/api/login'
import router from '@/router'
import { setObjToUrlParams, uniqueSlash } from './urlUtils'
import type { UploadFileParams } from '@/api/axios'

export interface RequestOptions extends AxiosRequestConfig {
  /** 是否直接将数据从响应中提取出(默认true)，例如直接返回 res.data，而忽略 res.code 等信息 */
  isReturnResult?: boolean
  /** 请求成功是提示信息 */
  successMsg?: string
  /** 请求失败是提示信息 */
  errorMsg?: string
  /** 成功时，是否显示后端返回的成功信息 */
  showSuccessMsg?: boolean
  /** 失败时，是否显示后端返回的失败信息 */
  showErrorMsg?: boolean
  requestType?: 'json' | 'form'
  /**
   * 是否把参数添加到url中(POST)
   */
  isJoinParamsToUrl?: boolean
}

const UNKNOWN_ERROR = '未知错误，请重试'

/** 真实请求的路径前缀 */
export const baseApiUrl = import.meta.env.VITE_BASE_API_URL
export const baseAotClientUrl = import.meta.env.VITE_BASE_AOT_CLIENT_URL

const controller = new AbortController()
const service = axios.create({
  baseURL: baseApiUrl,
  timeout: 60000,
  signal: controller.signal,
  paramsSerializer(params) {
    return qs.stringify(params, { arrayFormat: 'brackets' })
  },
})

service.interceptors.request.use(
  config => {
    start()
    const token = Storage.get(ACCESS_TOKEN_KEY, null, true)
    if (token && config.headers) {
      // 请求头token信息，请根据实际情况进行修改
      config.headers['Authorization'] = `Bearer ${token}`
      if (config.params?.HeaderUniqForm) {
        config.headers['HeaderUniqForm'] = JSON.stringify(config.params.HeaderUniqForm)
        delete config.params.HeaderUniqForm
      }
      if (config.data?.HeaderUniqForm) delete config.data.HeaderUniqForm
      saveRefreshtime()
    }
    const params = config.data ?? config?.params
    if (params && import.meta.env.PROD) {
      config.headers.set('Content-Type', 'application/json')
    }
    return config
  },
  error => {
    Promise.reject(error)
  },
)

service.interceptors.response.use(
  (response: AxiosResponse<BaseResponse>) => {
    close()
    let res = response.data
    // 自定义的请求直接返回
    if ((response.config as any)?.isCustomHttp_ || res instanceof Blob)
      return Promise.resolve(response)

    // if the custom code is not 200, it is judged as an error.
    if (res.status !== ResultEnum.SUCCESS || !res.success) {
      $message.error(res.msg || UNKNOWN_ERROR)

      // Illegal token
      if ([1101, 1102].includes(res.status)) {
        // 取消后续所有请求
        controller.abort()
        // window.localStorage.clear();
        // window.location.reload();
        // to re-login
        Modal.confirm({
          title: '警告',
          content: res.msg || '账号异常，您可以取消停留在该页上，或重新登录',
          okText: '重新登录',
          cancelText: '取消',
          onOk: () => {
            localStorage.clear()
            window.location.reload()
          },
        })
      }

      // throw other
      const error = new Error(res.msg || UNKNOWN_ERROR) as Error & { status: any }
      error.status = res.status
      return Promise.reject(error)
    } else {
      // const userStore = useUserStore()
      // userStore.setServerConnectStatus(true)
      return response
    }
  },
  error => {
    close()
    // 处理 4xx 或者 5xx 的错误异常提示
    const isChangeRouter = Storage.getVal(IS_CHANGE_ROUTER)

    // 是否自定义的http请求(报表API中用到)
    const isCustomHttp: boolean = error.config?.isCustomHttp_ ?? false
    // Aot客户端请求
    const isAotClientHttp: boolean = error.config?.isAotClientHttp_ ?? false
    if (
      !isCustomHttp &&
      (error.response?.status === 401 || (error.response?.status === 403 && isChangeRouter))
    ) {
      const curTime = Date.now()
      const refreshTime = Storage.getExpire(REFRESH_TIME)
      if (refreshTime && curTime <= refreshTime) {
        return refreshToken(Storage.get(ACCESS_TOKEN_KEY, null, true)).then(data => {
          useUserStoreWithOut().setToken(data.token, data.expires_timestamp)
          $message.loading(`动态刷新token成功, 重新加载中...`, 1500)
          if (error.config.headers) {
            error.config.headers.Authorization = `Bearer ${data.token}`
          }
          return service(error.config).then(() => {
            if (isChangeRouter) {
              router.go(0)
              Storage.setVal(IS_CHANGE_ROUTER, false)
            }
            $message.success(`加载成功!`)
          })
        })
      }
      window.localStorage.clear()
      window.location.reload()
    }
    let errMsg =
      error?.response?.data?.msg ??
      JSON.stringify(error?.response?.data?.errors) ??
      JSON.stringify(error?.message) ??
      UNKNOWN_ERROR
    // 处理要解密的响应数据
    if (import.meta.env.PROD) {
      const data = JSON.parse(error.response.data)
      errMsg = data?.msg ?? data?.errors ?? JSON.stringify(error?.message) ?? UNKNOWN_ERROR
    }
    if (isCustomHttp) {
      errMsg = `自定义的请求返回错误: ${errMsg}`
    } else if (isAotClientHttp) {
      errMsg = `Aot客户端请求返回错误: ${errMsg}`
    }
    $message.error({ content: errMsg, key: errMsg })
    error.message = errMsg
    return Promise.reject(error)
  },
)

export type BaseResponse<T = any> = Omit<API.ResOp, 'data'> & {
  data: T
}

export function request<T = any>(
  url: string,
  config: { isReturnResult: false } & RequestOptions,
): Promise<BaseResponse<T>>
export function request<T = any>(
  url: string,
  config: RequestOptions,
): Promise<BaseResponse<T>['data']>
export function request<T = any>(
  config: { isReturnResult: false } & RequestOptions,
): Promise<BaseResponse<T>>
export function request<T = any>(config: RequestOptions): Promise<BaseResponse<T>['data']>
/**
 *
 * @param url - request url
 * @param config - AxiosRequestConfig
 */
export async function request(_url: string | RequestOptions, _config: RequestOptions = {}) {
  let url = isString(_url) ? _url : _url.url
  const config = isString(_url) ? _config : _url
  try {
    // 兼容 from data 文件上传的情况
    const { requestType, isReturnResult = true, isJoinParamsToUrl = false, ...rest } = config

    if (isJoinParamsToUrl) {
      url = setObjToUrlParams(url!, config.data)
    }
    const response = (await service.request({
      url,
      ...rest,
      headers: {
        ...rest.headers,
        ...(requestType === 'form' ? { 'Content-Type': 'multipart/form-data' } : {}),
      },
    })) as AxiosResponse<BaseResponse>
    const { data } = response
    if (data instanceof Blob) return data
    const { status, success, msg } = data || {}

    const hasSuccess =
      data && Reflect.has(data, 'status') && status === ResultEnum.SUCCESS && success

    if (hasSuccess) {
      const { successMsg, showSuccessMsg } = config
      if (showSuccessMsg) {
        $message.success(successMsg ?? msg ?? '操作成功!')
      }
      // if (successMsg) {
      //   $message.success(successMsg)
      // } else if (showSuccessMsg && msg) {
      //   $message.success(msg ?? '操作成功!')
      // }
    }

    // 页面代码需要获取 status，success，data，msg 等信息时，需要将 isReturnResult 设置为 false
    if (!isReturnResult) {
      return data
    } else {
      return data.data
    }
  } catch (error: any) {
    return Promise.reject(error)
  }
}

/**
 * Aot客户端请求
 * @param config 配置项
 */
export function aotClientHttp<T = any>(config: AxiosRequestConfig): Promise<BaseResponse<T>['data']>

/**
 * Aot客户端请求
 * @param config 配置项
 * @returns
 */
export async function aotClientHttp(config: AxiosRequestConfig): Promise<any> {
  try {
    config.url = uniqueSlash(baseAotClientUrl + config.url)
    set(config, 'isAotClientHttp_', true)
    const res = (await service.request(config)) as AxiosResponse<BaseResponse>
    const { data } = res
    return data?.data ?? data
  } catch (error: any) {
    return Promise.reject(error)
  }
}

/**
 * 上传文件
 * @param config 配置项
 * @param params 参数
 * @returns
 */
export const uploadFile = async <T = any>(config: AxiosRequestConfig, params: UploadFileParams) => {
  const formData = new window.FormData()
  const customFilename = params.name || 'file'

  if (params.filename) {
    formData.append(customFilename, params.file, params.filename)
  } else {
    formData.append(customFilename, params.file)
  }

  if (params.data) {
    Object.keys(params.data).forEach(key => {
      const value = params.data![key]
      if (Array.isArray(value)) {
        value.forEach(item => {
          formData.append(`${key}[]`, item)
        })
        return
      }

      formData.append(key, params.data![key])
    })
  }

  const fullUrl = `${baseApiUrl + config.url}`
  config.url = fullUrl

  const response = (await service.request<T>({
    ...config,
    method: 'POST',
    data: formData,
    headers: {
      'Content-type': ContentTypeEnum.FORM_DATA,
      IgnoreCancelToken: true,
    },
  })) as AxiosResponse<BaseResponse>
  const { data } = response
  return data?.data ?? data
}
