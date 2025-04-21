<template>
  <div>
    <Flex>
      <SettingItem label="测试模式">
        <Select
          v-model:value="config.testMode"
          :options="transformEnumToOptions(TestModeEnum)"
          class="w-full"
        />
      </SettingItem>
    </Flex>
    <Flex>
      <SettingItem label="最大测试次数">
        <InputNumber
          v-model:value="config.maxTestCount"
          :min="1"
          :step="1"
          :max="10"
          class="w-full"
        />
      </SettingItem>
    </Flex>
  </div>
</template>

<script lang="ts" setup>
  import { computed } from 'vue'
  import { Flex, Switch, Select, InputNumber } from 'ant-design-vue'
  import { SettingItem } from '@/components/basic/collapseItem/index.ts'
  import type { TestParamType } from './type.d'
  import { TestModeEnum, transformEnumToOptions } from '@/enums/commonEnum'

  const props = defineProps({
    optionData: {
      type: Object as PropType<TestParamType>,
      required: true,
    },
  })

  const config = computed(() => props.optionData)
</script>

<style lang="less" scoped></style>
