import { http } from '@/api/http'

export default {
  /**
   * 获取缓存的用户信息列表
   * @returns 用户 id、code、name、email、isSuper 基本信息列表
   */
  getUserWithCache: () => http.get<API.UserInfoCache[]>(`/SysUser/GetAllUserWithCache`),
}
