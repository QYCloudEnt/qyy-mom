<template>
  <div>
    <DynamicTable
      row-key="id"
      :data-request="loadData"
      :columns="columns"
      bordered
      size="small"
      :row-selection="rowSelection"
    >
      <template v-if="checkRows.count" #title>
        <Alert class="w-full" type="info" show-icon>
          <template #message>
            {{ $t('common.selected', [checkRows.count]) }}
            <a-button type="link" @click="handleCancelSelect">
              {{ $t('common.cancelChoose') }}
            </a-button>
          </template>
        </Alert>
      </template>
      <template #toolbar>
        <a-button v-if="$auth('/api/Workshop/Add')" type="primary" @click="openModal({})">
          {{ $t('common.add') }}
        </a-button>
        <a-button type="primary" :loading="exportLoading" @click="aoaToExcel">
          {{ $t('common.export') }}
        </a-button>
        <a-button
          v-if="$auth('/api/Workshop/Delete')"
          type="error"
          :disabled="!checkRows.count"
          @click="delRowConfirm(rowSelection.selectedRowKeys)"
        >
          {{ $t('common.delete') }}
        </a-button>
      </template>
    </DynamicTable>
  </div>
</template>

<script lang="tsx" setup>
  import { ref } from 'vue'
  import { Alert } from 'ant-design-vue'
  import { useTable, useTablePlugin, type TableColumn } from '@/components/core/dynamic-table'
  import { useI18n } from '@/hooks/useI18n'
  import { baseColumns } from './columns'
  import { formSchemas } from './formSchemas'
  import action from '@/api/modeling/workshop'

  defineOptions({
    name: 'Workshop',
  })

  const showAttribute = ref(false)

  const { t } = useI18n()
  const [DynamicTable, dynamicTableInstance] = useTable()
  const {
    rowSelection,
    checkRows,
    exportLoading,
    loadData,
    aoaToExcel,
    handleCancelSelect,
    openModal,
    delRowConfirm,
  } = useTablePlugin({ dynamicTableInstance, action, columns: baseColumns, formSchemas })

  /**
   * 表格列
   */
  const columns: TableColumn<any>[] = [
    ...baseColumns,
    {
      title: '操作',
      width: 200,
      dataIndex: 'ACTION',
      hideInSearch: true,
      align: 'center',
      fixed: 'right',
      actions: ({ record }) => [
        {
          label: t('common.edit'),
          auth: {
            perm: '/api/Workshop/Update',
            effect: 'disable',
          },
          onClick: () => openModal(record),
        },
        {
          label: t('common.delete'),
          danger: true,
          auth: {
            perm: '/api/Workshop/Delete',
            effect: 'disable',
          },
          popConfirm: {
            title: t('column.confirmDel'),
            onConfirm: () => delRowConfirm(record.id),
          },
        },
      ],
    },
  ]
</script>
