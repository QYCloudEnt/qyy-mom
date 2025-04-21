import { request, type RequestOptions } from '@/utils/request'
import { http } from '@/api/http'

/**
 * @description 登录
 * @param {LoginParams} params 参数
 * @param {RequestOptions} options 其他配置
 * @returns
 */
export function login(params: API.LoginParams, options?: RequestOptions) {
  return request<API.LoginResult>('/Login/JWTToken', {
    method: 'post',
    data: params,
    ...(options || {}),
  })
}

/**
 * 刷新token
 * @param token 旧token
 * @param pwd 密码
 * @returns 新token
 */
export function refreshToken(token: string, pwd?: string) {
  return http.get<API.LoginResult>('/Login/RefreshToken', { token, pwd })
}

/**
 * @description 登出
 */
export function logout(data: { token: string }) {
  return request({
    url: 'account/logout',
    method: 'post',
    data,
  })
}

/**
 * @description 外部系统登录
 * @param {LoginParams} params
 * @returns
 */
export function sso(params: API.SsoLoginParams) {
  return request<API.LoginResult>({
    url: '/Login/SSO',
    method: 'post',
    data: params,
  })
}
