import { ref } from 'vue'
import { defineStore } from 'pinia'
import type { RouteRecordRaw } from 'vue-router'
import { store } from '@/store'
import { ACCESS_TOKEN_KEY, IS_CHANGE_ROUTER, REFRESH_TIME } from '@/enums/cacheEnum'
import { Storage } from '@/utils/Storage'
import { resetRouter } from '@/router'
import { generateDynamicRoutes } from '@/router/helper/routeHelper'
import { login as loginApi, sso } from '@/api/login'
import action from '@/api/sys/user'

export type MessageEvent = {
  data?: any
  type?: 'ping' | 'close' | 'updatePermsAndMenus'
}

export const useUserStore = defineStore(
  'user',
  () => {
    const token = ref(Storage.get(ACCESS_TOKEN_KEY, null))
    const name = ref('admin')
    const avatar = ref('')
    const perms = ref<string[]>([])
    const menus = ref<RouteRecordRaw[]>([])
    const userInfo = ref<Partial<API.AdminUserInfo>>({})
    const serverConnected = ref(true)

    const setServerConnectStatus = (isConnect: boolean) => {
      serverConnected.value = isConnect
    }

    const sortMenus = (menus: RouteRecordRaw[] = []) => {
      return menus
        .filter(n => {
          const flag = !n.meta?.hideInMenu
          if (flag && n.children?.length) {
            n.children = sortMenus(n.children)
          }
          return flag
        })
        .sort((a, b) => ~~Number(a.meta?.orderNo) - ~~Number(b.meta?.orderNo))
    }

    /** 获取token */
    const getToken = () => token.value

    /** 清空token及用户信息 */
    const resetToken = () => {
      token.value = name.value = avatar.value = ''
      perms.value = []
      menus.value = []
      userInfo.value = {}
      Storage.clear()
    }

    /** 更新用户信息 */
    const setUserInfo = (newUserInfo: Partial<API.AdminUserInfo>) => {
      userInfo.value = newUserInfo
    }

    /**
     * 登录成功保存token
     * @param token token
     * @param extimestamp 时间戳(毫秒)
     */
    const setToken = (_token: string, extimestamp: number) => {
      token.value = _token
      Storage.setValExpire(ACCESS_TOKEN_KEY, token.value, extimestamp)
      Storage.setValExpire(REFRESH_TIME, true, extimestamp)
      Storage.set(IS_CHANGE_ROUTER, false)
    }
    /** 登录 */
    const login = async (params: API.LoginParams) => {
      try {
        const data = await loginApi(params, { isReturnResult: true })
        setToken(data.token, data.expires_timestamp)
        return afterLogin()
      } catch (error) {
        return Promise.reject(error)
      }
    }

    /** 外部系统登录 */
    const ssoLogin = async (params: API.SsoLoginParams) => {
      try {
        const data = await sso(params)
        setToken(data.token, data.expires_timestamp)
        return await afterLogin()
      } catch (error) {
        return Promise.reject(error)
      }
    }

    /** 登录成功之后, 获取用户信息以及生成权限路由 */
    const afterLogin = async () => {
      try {
        userInfo.value = await action.getInfo()

        await fetchPermsAndMenus()
      } catch (error) {
        return Promise.reject(error)
      }
    }
    /** 获取权限及菜单 */
    const fetchPermsAndMenus = async () => {
      const { perms: permsData, menus: menusData } = await action.permmenu()
      perms.value = permsData
      const result = generateDynamicRoutes(menusData as unknown as RouteRecordRaw[])
      menus.value = sortMenus(result)
    }
    /** 登出 */
    const logout = async () => {
      resetToken()
      resetRouter()
    }

    return {
      token,
      name,
      perms,
      menus,
      userInfo,
      login,
      afterLogin,
      logout,
      resetToken,
      setToken,
      setServerConnectStatus,
      setUserInfo,
      getToken,
      ssoLogin,
    }
  },
  {
    persist: {
      paths: ['token'],
    },
  },
)

// 在组件setup函数外使用
export function useUserStoreWithOut() {
  return useUserStore(store)
}
