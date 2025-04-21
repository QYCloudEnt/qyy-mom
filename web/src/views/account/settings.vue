<template>
  <div ref="wrapperRef" class="account-setting">
    <Tabs tab-position="left" :tab-bar-style="tabBarStyle">
      <template v-for="item in settingList" :key="item.key">
        <TabPane :tab="item.name">
          <component :is="item.component" />
        </TabPane>
      </template>
    </Tabs>
  </div>
</template>
<script lang="ts">
  import { ref, defineComponent } from 'vue'
  import { Tabs } from 'ant-design-vue'
  import BaseSetting from './components/BaseSetting.vue'
  import SecureSetting from './components/SecureSetting.vue'
  import { useI18n } from '@/hooks/useI18n'

  const TabPane = Tabs.TabPane
  export default defineComponent({
    components: { BaseSetting, SecureSetting, Tabs, TabPane },
    setup() {
      const tabBarStyle = {
        width: '220px',
      }
      const { t } = useI18n()
      const settingList = ref<any>([])
      settingList.value = [
        {
          key: '1',
          name: t('column.basicSetting'),
          component: 'BaseSetting',
        },
        {
          key: '2',
          name: t('column.securitySetting'),
          component: 'SecureSetting',
        },
      ]

      return {
        tabBarStyle,
        settingList,
      }
    },
  })
</script>
<style lang="less" scoped>
  .account-setting {
    padding: 20px;

    .base-title {
      padding-left: 0;
    }
  }
</style>
