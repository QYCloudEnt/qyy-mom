import { reactive, computed, watchPostEffect } from 'vue'
import { defineStore } from 'pinia'
import { theme as antdTheme } from 'ant-design-vue'
import type { ThemeConfig } from 'ant-design-vue/es/config-provider/context'
import { THEME_KEY } from '@/enums/cacheEnum'
import { Storage } from '@/utils/Storage'
import { themeColor, type ThemeColor } from '@/layout/header/components/setting/constant'

/**
 * 项目默认配置项
 * primaryColor - 默认主题色, 如果修改颜色不生效，请清理 localStorage
 * navTheme - sidebar theme ['dark', 'light'] 两种主题
 * colorWeak - 色盲模式
 * layout - 整体布局方式 ['sidemenu', 'topmenu'] 两种布局
 * fixedHeader - 固定 Header : boolean
 * fixSiderbar - 固定左侧菜单栏 ： boolean
 * contentWidth - 内容区布局： 流式 |  固定
 */

export type LayoutSetting = {
  navTheme: ThemeColor // theme for nav menu
  colorPrimary: string // '#F5222D', // primary color of ant design
  layout: 'sidemenu' | 'topmenu' // nav menu position: `sidemenu` or `topmenu`
  contentWidth: 'Fluid' | 'Fixed' // layout of content: `Fluid` or `Fixed`, only works when layout is topmenu
  fixedHeader: false // sticky header
  fixSiderbar: false // sticky siderbar
  colorWeak: false
  menu: {
    locale: true
    mode: 'expand' | 'collapse'
  }
  title: string
  pwa: false
  iconfontUrl: string
  /** 是否缓存标签页 */
  cacheTabs: boolean
  size: 'normal' | 'compact' // 布局尺寸
}

export const defaultSetting: LayoutSetting = {
  navTheme: 'realDark', // theme for nav menu
  colorPrimary: '#13c2c2', // '#F5222D', // primary color of ant design
  layout: 'sidemenu', // nav menu position: `sidemenu` or `topmenu`
  contentWidth: 'Fluid', // layout of content: `Fluid` or `Fixed`, only works when layout is topmenu
  fixedHeader: false, // sticky header
  fixSiderbar: false, // sticky siderbar
  colorWeak: false,
  menu: {
    locale: true,
    mode: 'collapse',
  },
  title: 'tmom',
  pwa: false,
  iconfontUrl: '',
  cacheTabs: true,
  size: 'normal',
}

export const useLayoutSettingStore = defineStore(
  'layout-setting',
  () => {
    const localLayoutSetting = Storage.get<LayoutSetting>(THEME_KEY, {})

    const layoutSetting = reactive({ ...defaultSetting, ...localLayoutSetting })

    const themeConfig = reactive<ThemeConfig>({
      algorithm: themeColor[layoutSetting.navTheme!] || antdTheme.defaultAlgorithm,
      token: {
        colorPrimary: layoutSetting.colorPrimary,
        colorInfo: layoutSetting.colorPrimary,
      },
    })

    const getNavTheme = computed(() => {
      return layoutSetting.navTheme
    })

    const getPrimaryColor = computed(() => {
      return layoutSetting.colorPrimary
    })

    const getSize = computed(() => {
      return layoutSetting.size
    })

    watchPostEffect(() => {
      if (layoutSetting.navTheme) {
        toggleTheme(layoutSetting.navTheme)
      }
      if (layoutSetting.colorPrimary) {
        setColorPrimary(layoutSetting.colorPrimary)
      }
      if (layoutSetting.size) {
        setSize(layoutSetting.size)
      }
      if (layoutSetting.menu.mode) {
        setMenuMode(layoutSetting.menu.mode)
      }
      // 修改项目配置时自动同步到 localStorage
      Storage.set(THEME_KEY, layoutSetting)
    })

    // 切换主题
    const toggleTheme = (navTheme: ThemeColor) => {
      layoutSetting.navTheme = navTheme
      if (navTheme === 'realDark') {
        document.documentElement.classList.add('dark')
      } else {
        document.documentElement.classList.remove('dark')
      }
      themeConfig.algorithm = themeColor[navTheme]
    }

    /** 设置主题色 */
    const setColorPrimary = (color: string) => {
      themeConfig.token!.colorPrimary = color
      themeConfig.token!.colorInfo = color
    }

    /** 更新布局尺寸 */
    const setSize = (size: 'normal' | 'compact') => {
      layoutSetting.size = size
    }

    /** 更新菜单收缩模式 */
    const setMenuMode = (mode: 'expand' | 'collapse') => {
      layoutSetting.menu.mode = mode
    }

    const updateLayoutSetting = (settings: Partial<LayoutSetting>) => {
      Object.assign(layoutSetting, settings)
    }

    return {
      layoutSetting,
      themeConfig,
      getNavTheme,
      toggleTheme,
      setColorPrimary,
      updateLayoutSetting,
      getPrimaryColor,
      getSize,
    }
  },
  {
    persist: true,
  },
)
