<template>
  <div>
    <Flex>
      <SettingItem label="起始站">
        <Switch v-model:checked="config.isStart" />
      </SettingItem>
      <SettingItem label="产出站">
        <Switch v-model:checked="config.isOutput" />
      </SettingItem>
    </Flex>
    <Flex class="w-50%">
      <SettingItem label="缺料提醒">
        <Switch v-model:checked="config.isLackMaterialWarn" />
      </SettingItem>
    </Flex>
    <Flex>
      <SettingItem
        label="跳转的工艺路线"
        :label-width="120"
        help-msg="当过站非Pass状态时跳转到的工艺路线. e.g: 产品过站NG时跳到维修工艺路线"
      >
        <Select
          v-model:value="config.jumpToRouteId"
          :options="routeOptions"
          allow-clear
          class="w-full"
        />
      </SettingItem>
    </Flex>
    <Flex>
      <SettingItem
        label="返回后的工序"
        :label-width="120"
        help-msg="跳转的工艺路线执行完成后返回的工序. e.g: 维修工艺路线执行完成后返回到原工艺路线中的工序"
      >
        <Select
          v-model:value="config.backOperationId"
          :options="operationOptions"
          :disabled="!config.jumpToRouteId"
          allow-clear
          class="w-full"
        />
      </SettingItem>
    </Flex>
  </div>
</template>

<script lang="ts" setup>
  import { computed, ref } from 'vue'
  import { Flex, Switch, Select } from 'ant-design-vue'
  import { SettingItem } from '@/components/basic/collapseItem/index.ts'
  import type { BaseParamsType } from './type.d'

  const props = defineProps({
    routeId: {
      type: Number,
      required: true,
    },
    routes: {
      type: Array as PropType<any[]>,
      required: true,
    },
    operations: {
      type: Array as PropType<any[]>,
      required: true,
    },
    optionData: {
      type: Object as PropType<BaseParamsType>,
      required: true,
    },
  })

  const config = computed(() => props.optionData)

  const routeOptions = ref<any[]>([])
  const operationOptions = computed(() => props.operations)

  const initOptions = () => {
    routeOptions.value = props.routes
      .filter(item => item.id !== props.routeId)
      .map(item => ({
        label: item.name,
        value: item.id,
      }))
  }

  initOptions()
</script>

<style lang="less" scoped></style>
