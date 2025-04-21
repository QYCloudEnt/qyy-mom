<template>
  <div class="box">
    <!-- <GrowCard :loading="loading" class="enter-y mb-3" /> -->
    <ChartsDemo :loading="loading" class="mb-3" />
    <!-- <img src="~@/assets/analysis.svg" /> -->
    <Card :loading="loading" class="card">
      <Descriptions :title="$t('common.sysInfo')" bordered>
        <Descriptions.Item key="IP" label="IP">
          {{ loginIp }}
        </Descriptions.Item>
        <Descriptions.Item v-for="(value, key) in browserInfo" :key="key" :label="key">
          {{ value }}
        </Descriptions.Item>
        <Descriptions.Item :label="$t('common.intnetStatus')">
          <Badge
            :status="online ? 'processing' : 'default'"
            :text="online ? $t('common.online') : $t('common.offLine')"
          />
        </Descriptions.Item>
      </Descriptions>
    </Card>
  </div>
</template>

<script lang="ts" setup>
  import { computed, ref, watchEffect } from 'vue'
  import { Descriptions, Badge, Card } from 'ant-design-vue'
  import GrowCard from './components/GrowCard.vue'
  import ChartsDemo from './components/ChartsDemo.vue'
  import BrowserType from '@/utils/browser-type'
  import { useBattery } from '@/hooks/useBattery'
  import { useOnline } from '@/hooks/useOnline'
  import { useUserStore } from '@/store/modules/user'
  import { useI18n } from '@/hooks/useI18n'

  defineOptions({
    name: 'DashboardWelcome',
  })

  // import performanceMonitor from '@/utils/performanceMonitor'

  const { t } = useI18n()
  const loading = ref(true)

  setTimeout(() => {
    loading.value = false
  }, 1000)

  const loginIp = useUserStore().userInfo?.loginIp
  // 是否联网
  const { online } = useOnline()
  // 获取电池信息
  const { battery, batteryStatus, calcDischargingTime } = useBattery()
  // 获取浏览器信息
  const browserInfo = ref(BrowserType('zh-cn'))

  watchEffect(() => {
    Object.assign(browserInfo.value, {
      距离电池充满需要:
        Number.isFinite(battery.chargingTime) && battery.chargingTime != 0
          ? calcDischargingTime.value
          : '未知',
      剩余可使用时间:
        Number.isFinite(battery.dischargingTime) && battery.dischargingTime != 0
          ? calcDischargingTime.value
          : '未知',
      电池状态: batteryStatus.value,
      当前电量: `${battery.level}%`,
    })
  })

  // console.log(performanceMonitor.getPerformanceData(), 'performanceMonitor')
</script>

<style lang="less" scoped>
  @import '@/styles/theme.less';

  .themeBgColor(box);

  .box {
    display: flex;
    flex-direction: column;
    width: 100%;
    // height: calc(100vh - 280px);
    padding: 12px;

    img {
      flex: 1;
      min-height: 0;
    }

    .ant-form {
      flex: 2;
    }
  }
</style>
