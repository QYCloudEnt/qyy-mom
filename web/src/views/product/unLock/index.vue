<template>
  <div>
    <DynamicTable
      row-key="id"
      :data-request="loadData"
      :columns="baseColumns"
      bordered
      size="small"
      :row-selection="rowSelection"
    >
      <template v-if="checkRows.count" #title>
        <Alert class="w-full" type="info" show-icon>
          <template #message>
            {{ t('common.selected', [checkRows.count]) }}
            <a-button type="link" @click="handleCancelSelect">
              {{ t('common.cancelChoose') }}
            </a-button>
          </template>
        </Alert>
      </template>
      <template #toolbar>
        <a-button
          :disabled="!$auth('/api/ProductLock/UnLock') || checkRows.count === 0"
          type="primary"
          @click="openModal()"
        >
          解锁
        </a-button>
      </template>
    </DynamicTable>
  </div>
</template>

<script lang="tsx" setup>
  import { Alert, Modal } from 'ant-design-vue'
  import { useTable, useTablePlugin } from '@/components/core/dynamic-table'
  import { useI18n } from '@/hooks/useI18n'
  import { baseColumns } from './columns'
  import action from '@/api/product/lock'

  defineOptions({
    name: 'ProductUnLock',
  })

  const { t } = useI18n()
  const [DynamicTable, dynamicTableInstance] = useTable()
  const { rowSelection, checkRows, loadData, handleCancelSelect } = useTablePlugin({
    dynamicTableInstance,
    action: action as any,
    columns: baseColumns,
    formSchemas: [],
  })

  const openModal = () => {
    Modal.confirm({
      title: '提示',
      content: '确定要解锁所选数据嘛?',
      onOk: async () => {
        const ids = checkRows.value.rows.map(item => item.id).join(',')
        await action.unLock(ids)
        dynamicTableInstance.reload()
      },
    })
  }
</script>
