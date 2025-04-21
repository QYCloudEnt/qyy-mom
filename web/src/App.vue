<template>
  <ProConfigProvider>
    <router-view #="{ Component }">
      <component :is="Component" />
    </router-view>
    <LockScreen />
  </ProConfigProvider>
</template>

<script setup lang="ts">
  import { watch } from 'vue'
  import { LockScreen } from '@/components/basic/lockscreen'
  import { useLocale } from '@/locales/useLocale'
  import { useLayoutSettingStore } from '@/store/modules/layoutSetting'
  import zhCN from 'ant-design-vue/es/locale/zh_CN'
  import dayjs from 'dayjs'
  import 'dayjs/locale/zh-cn'
  dayjs.locale(zhCN.locale)

  const { getAntdLocale } = useLocale()
  const themeStore = useLayoutSettingStore()

  watch(
    () => getAntdLocale.value,
    newVal => {
      dayjs.locale(newVal.locale)
    },
  )
  watch(
    () => themeStore.layoutSetting.colorPrimary,
    newVal => {
      document.documentElement.style.setProperty('--color', newVal)
    },
    {
      immediate: true,
    },
  )

  watch(
    () => themeStore.getNavTheme,
    newVal => {
      const bgColor = newVal === 'realDark' ? '#000' : '#fff'
      document.documentElement.style.setProperty('--bg-color', bgColor)
    },
    {
      immediate: true,
    },
  )
</script>

<style lang="less">
  :root {
    --nprogress-color: var(--color) !important;
  }

  body {
    background-color: var(--bg-color);
  }

  .nprogress .bar {
    background: var(--color) !important;
  }
</style>
