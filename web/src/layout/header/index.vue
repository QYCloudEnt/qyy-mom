<template>
  <Layout.Header :style="headerStyle" class="layout-header">
    <div class="header-left">
      <slot name="left">
        <Space :size="20">
          <span
            class="menu-fold cursor-pointer"
            @click="() => emit('update:collapsed', !collapsed)"
          >
            <component :is="collapsed ? MenuUnfoldOutlined : MenuFoldOutlined" />
          </span>
          <LayoutBreadcrumb />
        </Space>
      </slot>
    </div>
    <div class="header-menu">
      <slot name="menu" />
    </div>
    <div class="header-right">
      <Space :size="20">
        <GithubOutlined @click="goGitee" />
        <Search />
        <Tooltip :title="$t('layout.header.tooltipLock')" placement="bottom">
          <LockOutlined @click="lockscreenStore.setLock(true)" />
        </Tooltip>
        <FullScreen />
        <LocalePicker />
        <MsgNotice />
        <div>{{ userInfo.realName }}</div>
        <Dropdown placement="bottomRight">
          <Avatar :src="avatar" :alt="userInfo.realName">{{ userInfo.realName }}</Avatar>
          <template #overlay>
            <Menu>
              <Menu.Item @click="$router.push({ name: 'account-settings' })">
                <user-outlined /> {{ $t('routes.account.settings') }}
              </Menu.Item>
              <Menu.Divider />
              <Menu.Item>
                <div @click.prevent="doLogout">
                  <poweroff-outlined /> {{ $t('layout.header.dropdownItemLoginOut') }}
                </div>
              </Menu.Item>
            </Menu>
          </template>
        </Dropdown>
        <ProjectSetting />
      </Space>
    </div>
  </Layout.Header>
</template>

<script lang="tsx" setup>
  import { computed, createVNode, type CSSProperties } from 'vue'
  import { useRouter, useRoute } from 'vue-router'
  import {
    QuestionCircleOutlined,
    MenuFoldOutlined,
    MenuUnfoldOutlined,
    PoweroffOutlined,
    LockOutlined,
    UserOutlined,
    GithubOutlined,
  } from '@ant-design/icons-vue'
  import {
    Layout,
    message,
    Modal,
    Dropdown,
    Menu,
    Space,
    Avatar,
    Tooltip,
    type MenuTheme,
  } from 'ant-design-vue'
  import { Search, FullScreen, ProjectSetting, LayoutBreadcrumb, MsgNotice } from './components/'
  import { LocalePicker } from '@/components/basic/locale-picker'
  import { useUserStore } from '@/store/modules/user'
  import { useKeepAliveStore } from '@/store/modules/keepAlive'
  import { useLockscreenStore } from '@/store/modules/lockscreen'
  import { LOGIN_NAME } from '@/router/constant'
  import { useLayoutSettingStore } from '@/store/modules/layoutSetting'
  import { Storage } from '@/utils/Storage'
  import { REMEMBERUSER, THEME_KEY } from '@/enums/cacheEnum'
  import { useI18n } from '@/hooks/useI18n'

  defineProps({
    collapsed: {
      type: Boolean,
    },
    theme: {
      type: String as PropType<MenuTheme>,
    },
  })
  const emit = defineEmits(['update:collapsed'])
  const userStore = useUserStore()
  const layoutSettingStore = useLayoutSettingStore()
  const lockscreenStore = useLockscreenStore()
  const keepAliveStore = useKeepAliveStore()
  const { t } = useI18n()

  const router = useRouter()
  const route = useRoute()
  const userInfo = computed(() => userStore.userInfo)
  const headerStyle = computed<CSSProperties>(() => {
    const { navTheme, layout } = layoutSettingStore.layoutSetting
    const isDark = navTheme === 'dark' && layout === 'topmenu'
    return {
      backgroundColor: navTheme === 'realDark' || isDark ? '' : 'rgba(255, 255, 255, 0.85)',
      color: isDark ? 'rgba(255, 255, 255, 0.85)' : '',
    }
  })

  const avatar = computed(() =>
    userInfo.value.avatar ? `${import.meta.env.VITE_BASE_STATIC_URL}${userInfo.value.avatar}` : '',
  )
  const goGitee = () => window.open('https://gitee.com/thgao/tmom', '_blank')

  // 退出登录
  const doLogout = () => {
    Modal.confirm({
      title: t('common.confirmLogout'),
      icon: createVNode(QuestionCircleOutlined),
      onOk: async () => {
        const rememberUser = Storage.get(REMEMBERUSER)
        const layoutSetting = Storage.get(THEME_KEY)
        keepAliveStore.clear()
        // 移除标签页
        localStorage.clear()
        await userStore.logout()
        message.success(t('common.logoutSuccess'))
        rememberUser && Storage.set(REMEMBERUSER, rememberUser)
        Storage.set(THEME_KEY, layoutSetting)
        router.replace({
          name: LOGIN_NAME,
          query: {
            redirect: route.fullPath,
          },
        })
      },
    })
  }
</script>

<style lang="less" scoped>
  .layout-header {
    display: flex;
    position: sticky;
    z-index: 10;
    top: 0;
    align-items: center;
    justify-content: space-between;
    height: var(--app-header-height);
    padding: 0 20px;

    .header-right {
      min-width: 180px;
      cursor: pointer;
    }

    .header-menu {
      flex: 1;
      align-items: center;
      min-width: 0;
    }
  }
</style>
