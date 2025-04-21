import { asyncRoutes } from '../asyncModules'
import type { RouteMeta, RouteRecordRaw } from 'vue-router'
import IFramePage from '@/components/basic/iframe-page'
import { warn } from '@/utils/log'
import { rootRoute } from '@/router/routes'
import router from '@/router'
import basic from '@/router/routes/basic'
import routeModules from '@/router/routes/modules'
import { uniqueSlash } from '@/utils/urlUtils'
import { t } from '@/hooks/useI18n'
import { i18n } from '@/locales'

/** 菜单namePath集合, 用于修复隐藏菜单在面包屑中不显示BUG */
const menuNamePathMap = new Map<string, string[]>()

export const transformMenuToRoutes = (
  routeList: RouteRecordRaw[],
  parentRoute?: RouteRecordRaw,
) => {
  routeList.forEach(route => {
    route.meta ||= {} as RouteMeta
    const { show = 1, type, isExt, extOpenMode, frameRoute } = route.meta
    const _compPath = route.component as unknown as string
    const compPath = _compPath?.replace(/^\//, '') // 去除最前面的/

    // 是否在菜单中隐藏
    route.meta.hideInMenu ??= !show

    // 规范化路由路径
    route.path = route.path.startsWith('/') ? route.path : `/${route.path}`
    if (parentRoute?.path && !route.path.startsWith(parentRoute.path)) {
      route.path = uniqueSlash(`${parentRoute.path}/${route.path}`)
    }
    // 以路由路径作为唯一的路由名称
    route.name = route.path

    // 多语言key
    let key = ''

    if (type === 0) {
      route.component = null
      if (route.children?.length) {
        const redirectChild = route.children.find(n => !n.meta?.isExt)
        if (!redirectChild) {
          Reflect.deleteProperty(route, 'redirect')
        } else {
          route.redirect ??= uniqueSlash(`/${redirectChild.path}`)
        }
      }
      key = `routes.menu.${route.path.replaceAll('/', '_')}`
    } else if (type === 1) {
      key = `routes.menu.${route.path.replace('/', '').replaceAll('/', '.')}`
      // 内嵌页面
      if (isExt && extOpenMode === 2) {
        route.component = <IFramePage src={route.path} />
        route.path = frameRoute || '' //route.path.replace(new RegExp('://'), '/')
      } else if (compPath) {
        route.component = asyncRoutes[compPath]
        // 前端 src/views 目录下无对应路由组件
        if (!route.component) {
          route.component = () => import('@/views/error/comp-not-found.vue')
          warn(`在src/views/下找不到 ${compPath}.vue 或 ${compPath}.tsx, 请自行创建!`)
        }
      }
    }
    // 配置国际化
    if (isExt) key = `routes.menu.${frameRoute?.replace('/', '').replaceAll('/', '.')}`
    if (key) route.meta!.title = renderI18nRouterName(key, route.meta!.title as string)

    if (route.children?.length) {
      transformMenuToRoutes(route.children, route)
    }
  })
  return routeList
}

export const generateDynamicRoutes = (menus: RouteRecordRaw[]) => {
  const routes = [...routeModules, ...transformMenuToRoutes(menus)]
  const allRoute = [...routes, ...basic]
  menuNamePathMap.clear()
  genNamePathForRoutes(allRoute)
  renderHideMenuNamePath(allRoute)
  rootRoute.children = allRoute
  router.addRoute(rootRoute)
  return routes
}

/**
 * 主要方便于设置 a-menu 的 open-keys，即控制左侧菜单应当展开哪些菜单
 * @param {RouteRecordRaw[]} routes 需要添加 namePath 的路由
 * @param {string[]} namePath
 */
export const genNamePathForRoutes = (routes: RouteRecordRaw[], parentNamePath: string[] = []) => {
  routes.forEach(item => {
    if (item.meta && typeof item.name === 'string') {
      item.meta.namePath = parentNamePath.concat(item.name)

      if (item.meta?.hideInMenu) {
        item.meta.activeMenu ||= parentNamePath[parentNamePath.length - 1]
        if ((item as any).id && !menuNamePathMap.has(item.name)) {
          menuNamePathMap.set(item.name, item.meta.namePath)
        }
      }

      if (item.children?.length) {
        genNamePathForRoutes(item.children, item.meta.namePath)
      }
    }
  })
}

/** 重新渲染隐藏菜单的namePath(解决隐藏菜单在面包屑中不显示BUG) */
const renderHideMenuNamePath = (allRoute: RouteRecordRaw[]) => {
  menuNamePathMap.forEach((namePath, key) => {
    const hideMenu = allRoute.find(item => item.name === key)
    if (hideMenu && hideMenu.meta) {
      hideMenu.meta.namePath = namePath
    }
  })
}

/**
 * 渲染路由多语言
 * @param key key
 * @param defaultVal 默认值
 * @returns
 */
const renderI18nRouterName = (key: string, defaultVal: string) => {
  const i18nName = i18n.global.t(key)
  // 翻译后的文本和key相同, 则使用默认值
  if (!i18nName || i18nName == key) return defaultVal
  return t(key)
}
