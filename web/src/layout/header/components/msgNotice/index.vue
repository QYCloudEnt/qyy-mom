<template>
  <div>
    <Tooltip :title="$t('common.msgNotice')" placement="bottom">
      <Badge :count="0" :offset="[5, -6]">
        <BellOutlined @click="handleClick" />
      </Badge>
    </Tooltip>
    <DraggableModal v-model:open="show" width="30%" :title="$t('common.msgNotice')" :footer="null">
      <Segmented v-model:value="activeKey" :block="true" :options="options" />
    </DraggableModal>
  </div>
</template>

<script lang="ts" setup>
  import { ref } from 'vue'
  import { Tooltip, Segmented, Badge } from 'ant-design-vue'
  import { BellOutlined } from '@ant-design/icons-vue'
  import { DraggableModal } from '@/components/core/draggable-modal'

  defineOptions({
    name: 'MsgNotice',
  })

  const show = ref(false)
  const activeKey = ref<string>('未读消息')
  const options = ref(['未读消息', '已读消息'])

  const handleClick = () => {
    console.log('click')
    show.value = true
  }
</script>

<style lang="less" scoped></style>
