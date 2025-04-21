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
            {{ t('common.selected', [checkRows.count]) }}
            <a-button type="link" @click="handleCancelSelect">
              {{ t('common.cancelChoose') }}
            </a-button>
          </template>
        </Alert>
      </template>
      <template #afterHeaderTitle>
        <div class="flex gap-2 ml-2">
          <a-button
            ghost
            type="primary"
            :disabled="checkRows.count != 1"
            @click="() => (showDesign = true)"
          >
            流程设计
          </a-button>
        </div>
      </template>
      <template #toolbar>
        <a-button v-if="$auth('/api/ProcessRoute/Add')" type="primary" @click="openModal({})">
          {{ t('common.add') }}
        </a-button>
        <a-button type="primary" :loading="exportLoading" @click="aoaToExcel">
          {{ t('common.export') }}
        </a-button>
        <a-button
          v-if="$auth('/api/ProcessRoute/Delete')"
          type="error"
          :disabled="!checkRows.count"
          @click="delRowConfirm(rowSelection.selectedRowKeys)"
        >
          {{ t('common.delete') }}
        </a-button>
      </template>
    </DynamicTable>
    <EditRoute
      :id="checkRows.rows[0]?.id || 0"
      :show-design="showDesign"
      :name="checkRows.rows[0]?.name || ''"
      @update:show-design="(val, isSave) => handleUpdateShowDesign(val, isSave)"
    />
  </div>
</template>

<script lang="tsx" setup>
  import { ref } from 'vue'
  import { Alert } from 'ant-design-vue'
  import { useTable, useTablePlugin } from '@/components/core/dynamic-table'
  import { useI18n } from '@/hooks/useI18n'
  import type { TableColumn } from '@/components/core/dynamic-table'
  import { formSchemas } from './formSchemas'
  import { baseColumns } from './columns'
  import EditRoute from './components/editRoute.vue'
  import action from '@/api/process/route'
  import { renderImg } from '@/utils/common'

  defineOptions({
    name: 'ProcessRoute',
  })

  const { t } = useI18n()
  const [DynamicTable, dynamicTableInstance] = useTable()
  const {
    rowSelection,
    checkRows,
    exportLoading,
    loadData,
    reset,
    aoaToExcel,
    handleCancelSelect,
    openModal,
    delRowConfirm,
  } = useTablePlugin({
    dynamicTableInstance,
    action,
    columns: baseColumns,
    formSchemas,
    formParamCallback: params => {
      params.sopUrl = params.sopUrls?.[0]
    },
    formDataCallback: data => {
      return {
        sopUrls: data.sopUrl ? [data.sopUrl] : [],
      }
    },
  })

  const showDesign = ref(false)

  const handleUpdateShowDesign = (value: boolean, isSave: boolean = false) => {
    showDesign.value = value
    isSave && reset()
  }

  const handleDesign = (record: Recordable) => {
    checkRows.value.rows = [{ id: record.id, name: record.name }]
    handleUpdateShowDesign(true)
  }

  /**
   * 表格列
   */
  const columns: TableColumn<any>[] = [
    ...baseColumns,
    {
      title: '操作',
      width: 400,
      dataIndex: 'ACTION',
      hideInSearch: true,
      align: 'center',
      fixed: 'right',
      actions: ({ record }) => [
        {
          label: t('common.design'),
          onClick: () => handleDesign(record),
        },
        {
          label: '作业指导书',
          disabled: !record.sopUrl,
          onClick: () => {
            window.open(renderImg(record.sopUrl), '_blank')
          },
        },
        {
          label: t('common.edit'),
          auth: {
            perm: '/api/ProcessRoute/Update',
            effect: 'disable',
          },
          onClick: () => openModal(record),
        },
        {
          label: t('common.delete'),
          danger: true,
          auth: {
            perm: '/api/ProcessRoute/Delete',
            effect: 'disable',
          },
          popConfirm: {
            title: t('column.confirmDel'),
            onConfirm: () => delRowConfirm(record.id),
          },
        },
        {
          label: t('column.more'),
          dropDown: [
            {
              label: t('column.publish'),
              disabled: record.status == 'Published',
              auth: {
                perm: '/api/ProcessRoute/UpdatePublishStatus',
                effect: 'disable',
              },
              popConfirm: {
                title: '你确定要发布嘛?',
                onConfirm: async () => {
                  await action.updatePublishStatus({ id: record.id, isPublish: true })
                  reset()
                },
              },
            },
            {
              label: t('column.unPublish'),
              danger: true,
              disabled: record.status == 'UnPublish',
              auth: {
                perm: '/api/ProcessRoute/UpdatePublishStatus',
                effect: 'disable',
              },
              popConfirm: {
                title: '你确定要取消发布嘛?',
                onConfirm: async () => {
                  await action.updatePublishStatus({ id: record.id, isPublish: false })
                  reset()
                },
              },
            },
          ],
        },
      ],
    },
  ]
</script>
