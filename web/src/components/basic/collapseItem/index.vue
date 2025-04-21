<template>
  <Collapse v-model:active-key="activeKey" class="mb-2 tmp-collapse">
    <CollapsePanel key="1" :header="title">
      <slot />
      <template #extra>
        <slot name="extra" />
      </template>
    </CollapsePanel>
  </Collapse>
</template>
<script lang="ts" setup>
  import { ref, watchEffect } from 'vue'
  import { Collapse, CollapsePanel } from 'ant-design-vue'

  defineOptions({
    name: 'CollapseItem',
  })

  const activeKey = ref<string[]>(['1'])
  const props = defineProps({
    expand: {
      type: Boolean,
      default: true,
    },
    title: {
      type: String,
      default: '标题',
    },
  })

  watchEffect(() => {
    activeKey.value = props.expand ? ['1'] : ['']
  })
</script>
<style lang="less">
  .tmp-collapse {
    .ant-collapse-content-box {
      padding: 10px !important;
    }
  }
</style>
