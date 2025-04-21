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
      <template #afterHeaderTitle>
        <div class="flex gap-2 ml-2">
          <a-button
            ghost
            type="primary"
            :disabled="checkRows.count != 1"
            @click="() => (showAttribute = true)"
          >
            {{ t('common.assignAttr') }}
          </a-button>
          <a-button
            ghost
            type="primary"
            :disabled="checkRows.count != 1 || !$auth('/api/WorkOrder/SplitWorkOrder')"
            @click="openSplitModal"
          >
            工单拆分
          </a-button>
        </div>
      </template>
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
        <a-button v-if="$auth('/api/WorkOrder/Add')" type="primary" @click="openModal({})">
          {{ t('common.add') }}
        </a-button>
        <a-button type="primary" :loading="exportLoading" @click="aoaToExcel">
          {{ t('common.export') }}
        </a-button>
        <a-button
          v-if="$auth('/api/WorkOrder/Delete')"
          type="error"
          :disabled="!checkRows.count"
          @click="delRowConfirm(rowSelection.selectedRowKeys)"
        >
          {{ t('common.delete') }}
        </a-button>
      </template>
    </DynamicTable>
    <AssignAttributeModal
      :type="AttributeTypeEnum.WorkOrder"
      :open="showAttribute"
      :business-id="checkRows.rows?.[0]?.id"
      @update:open="v => (showAttribute = v)"
    />
  </div>
</template>

<script lang="tsx" setup>
  import { ref } from 'vue'
  import { Alert } from 'ant-design-vue'
  import { useTable, useTablePlugin, type TableColumn } from '@/components/core/dynamic-table'
  import { useI18n } from '@/hooks/useI18n'
  import { formatToDate } from '@/utils/dateUtil'
  import { AttributeTypeEnum } from '@/enums/commonEnum'
  import { baseColumns } from './columns'
  import { formSchemas, splitFormSchemas } from './formSchemas'
  import action from '@/api/product/workOrder'

  defineOptions({
    name: 'WorkOrder',
  })

  const showAttribute = ref(false)
  const id = ref(0)

  const { t } = useI18n()
  const [DynamicTable, dynamicTableInstance] = useTable()
  const {
    rowSelection,
    checkRows,
    exportLoading,
    showModal,
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
    formModalProps: { labelWidth: 140 },
    formParamCallback: params => {
      if (!params?.planDate) return
      params.planDateS = formatToDate(params.planDate[0])
      params.planDateE = formatToDate(params.planDate[1])
      delete params.planDate
    },
    formDataCallback: data => {
      if (!data?.planDateS) return {}
      data.planDate = [data.planDateS, data.planDateE]
      return { planDate: data.planDate }
    },
  })

  const openSplitModal = async () => {
    const record = checkRows.value.rows[0]
    if (!record) return
    const [formRef] = await showModal({
      modalProps: {
        title: `工单拆分-${record.code}`,
        width: '40%',
        onFinish: async values => {
          values.sourceId = record.id
          const params = { ...values }
          params.planDateS = formatToDate(params.planDate[0])
          params.planDateE = formatToDate(params.planDate[1])
          delete params.planDate
          await action.splitWorkOrder(params)
          reset()
        },
      },
      formProps: {
        labelWidth: 120,
        schemas: splitFormSchemas,
      },
    })

    const data = await action.getById(record.id)
    const canSplitQty = data.qty - data.completedQty
    formRef?.setFieldsValue({
      code: '',
      canSplitQty,
      lineId: data.lineId,
      planDate: ['', ''],
      remark: '',
    })
  }

  /**
   * 表格列
   */
  const columns: TableColumn<any>[] = [
    ...baseColumns,
    {
      title: '操作',
      width: 300,
      dataIndex: 'ACTION',
      hideInSearch: true,
      align: 'center',
      fixed: 'right',
      actions: ({ record }) => [
        {
          label: t('common.edit'),
          auth: {
            perm: '/api/WorkOrder/Update',
            effect: 'disable',
          },
          onClick: () => openModal(record),
        },
        {
          label: t('common.delete'),
          danger: true,
          auth: {
            perm: '/api/WorkOrder/Delete',
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
