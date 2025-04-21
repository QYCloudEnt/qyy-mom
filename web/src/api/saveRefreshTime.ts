import { ACCESS_TOKEN_KEY, REFRESH_TIME } from '@/enums/cacheEnum'
import { Storage } from '@/utils/Storage'

/**
 * 保存刷新时间
 */
export const saveRefreshtime = () => {
  const nowtime = Date.now()
  let lastRefreshtime = Storage.getExpire(REFRESH_TIME)
  const expiretime = Storage.getExpire(ACCESS_TOKEN_KEY)
  const refreshCount = 20 * 60 * 1000 //滑动系数(20分钟), 超过这个时间不操作并且token失效就会跳转到登录页
  if (lastRefreshtime >= nowtime) {
    lastRefreshtime = nowtime > expiretime ? nowtime : expiretime // 取最大的那个值
    lastRefreshtime += refreshCount
    Storage.setValExpire(REFRESH_TIME, true, lastRefreshtime)
  } else {
    Storage.setValExpire(REFRESH_TIME, true, 0)
  }
}
