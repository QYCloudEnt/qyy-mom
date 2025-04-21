/**
 * 是否外链url
 * @param {string} path
 * @returns {Boolean}
 */
export function isExternal(path: string) {
  return /^(http?:|https?:|mailto:|tel:)/.test(path)
}

/**
 * 是否正确的手机号
 * @param phone 手机号
 * @returns
 */
export function isPhone(phone: string) {
  return /^[1][3,4,5,7,8,9][0-9]{9}$/.test(phone)
}

/**
 * 是否正确的邮箱
 * @param str 邮箱
 * @returns
 */
export function isEmail(str: string) {
  return /^[a-z0-9]+([._\\-]*[a-z0-9])*@([a-z0-9]+[-a-z0-9]*[a-z0-9]+.){1,63}[a-z0-9]+$/.test(str)
}

/**
 * 是否正确的JSON字符串
 * @param str json
 * @returns
 */
export function isJson(str: string) {
  try {
    JSON.parse(JSON.stringify(str))
  } catch {
    return false
  }
  return true
}

/**
 * 判断当前页面的url是否是不需要token的路由地址
 * eg: http://localhost:5002/*dffBgw1CRMM=#/reportQuery/2  返回true
 * @returns true or false
 */
export function isNotNeedTokenUrl() {
  try {
    const start = location.href.indexOf('/*')
    if (start < 0) return false
    const end = location.href.indexOf('#/')
    if (end < 0) return false
    const str = location.href.substring(start + 2, end)
    if (!str) return false
    return true
  } catch {
    return false
  }
}

/**
 * 判断当前是否竖屏状态(width < height)
 * @returns true or false
 */
export function isVerticalScreen() {
  const width = document.documentElement.clientWidth
  const height = document.documentElement.clientHeight
  return width < height
}
