<template>
  <Card :loading="loading" :title="$t('common.chartInfo')">
    <Row>
      <Col :xs="24" :sm="12"> <div id="chart_1"></div> </Col>
      <Col :xs="24" :sm="12"> <div id="chart_2"></div> </Col>
    </Row>
  </Card>
</template>

<script lang="ts" setup>
  import { Row, Col, Card } from 'ant-design-vue'
  import { getCurrentInstance, ref, onUnmounted, watch } from 'vue'
  import { option1, option2 } from './data'

  const instance = getCurrentInstance()
  const echarts = instance?.appContext.config.globalProperties.$echarts

  const handleResize = ref<() => void>(() => {})

  const props = defineProps({
    loading: {
      type: Boolean,
    },
  })

  const initChart = () => {
    const div1 = document.getElementById('chart_1')
    const div2 = document.getElementById('chart_2')
    if (!div1 || !div2) return

    const chart1 = echarts.init(div1)
    const chart2 = echarts.init(div2)
    chart1.setOption(option1)
    option2.series[0].areaStyle = {
      color: new echarts.graphic.LinearGradient(
        0,
        0,
        0,
        1,
        [
          {
            offset: 0,
            color: '#13c2c2',
          },
          {
            offset: 1,
            color: '#06a7ff0d',
          },
        ],
        false,
      ),
    }
    chart2.setOption({
      ...option2,
    })

    handleResize.value = () => {
      chart1.resize()
      chart2.resize()
    }
    window.addEventListener('resize', () => handleResize.value())
  }

  watch(
    () => props.loading,
    newVal => {
      if (!newVal)
        setTimeout(() => {
          initChart()
        }, 500)
    },
  )

  onUnmounted(() => window.removeEventListener('resize', () => handleResize.value()))
</script>

<style lang="less" scoped>
  .ant-col div {
    width: 100%;
    height: 50vh;
  }
</style>
