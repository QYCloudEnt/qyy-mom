declare namespace API {
  /** 登录参数 */
  type LoginParams = {
    password: string
    username: string
  }

  /** 登录成功结果 */
  type LoginResult = {
    token: string
    expires_in: number
    token_type: string
    expires_timestamp: number
  }

  /** 获取验证码参数 */
  type CaptchaParams = {
    width?: number
    height?: number
    len?: number
    bgColor?: string
  }

  /** 获取验证码结果 */
  type CaptchaResult = {
    img: string
    id: string
  }

  /** 外部系统登录参数 */
  type SsoLoginParams = {
    code: string
    name: string
  }
}
