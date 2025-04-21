<template>
  <div>
    <DynamicTable row-key="id" :data-request="loadData" :columns="columns" bordered size="small">
      <template #afterHeaderTitle>
        <div class="flex gap-2 ml-2">
          <a-button ghost type="primary"> 同步数据 </a-button>
          <a-button @click="dynamicTableInstance.expandAll">{{ t('common.expandAll') }}</a-button>
          <a-button @click="dynamicTableInstance.collapseAll">{{
            t('common.collapseAll')
          }}</a-button>
        </div>
      </template>
      <template #toolbar>
        <a-button v-if="$auth('/api/Bom/Add')" type="primary" @click="openModal({})">
          {{ t('common.add') }}
        </a-button>
        <a-button type="primary" :loading="exportLoading" @click="aoaToExcel">
          {{ t('common.export') }}
        </a-button>
      </template>
    </DynamicTable>
  </div>
</template>

<script lang="tsx" setup>
  import { ref } from 'vue'
  import { type TreeSelectProps } from 'ant-design-vue'
  import { useTable, useTablePlugin } from '@/components/core/dynamic-table'
  import { useI18n } from '@/hooks/useI18n'
  import type { TableColumn } from '@/components/core/dynamic-table'
  import { bindPartFormSchemas, formSchemas } from './formSchemas'
  import { baseColumns } from './columns'
  import { formatToTreeTable } from '@/utils/tree'
  import { cloneDeep } from 'lodash-es'
  import action from '@/api/base/bom'

  defineOptions({
    name: 'Bom',
  })

  const { t } = useI18n()
  const treeData = ref<TreeSelectProps['treeData']>([])

  const [DynamicTable, dynamicTableInstance] = useTable({
    pagination: false,
  })
  const { exportLoading, aoaToExcel, showModal, delRowConfirm } = useTablePlugin({
    dynamicTableInstance,
    action,
    columns: baseColumns,
    formSchemas,
  })

  const loadData = async params => {
    const data = await action.getList(params)
    treeData.value = formatToTreeTable(cloneDeep(data), '', [], 'code', 'parentCode')
    return treeData.value
  }

  /**
   * 打开新增/编辑弹窗
   */
  const openModal = async record => {
    const [formRef] = await showModal({
      modalProps: {
        title: `${record.id ? t('common.edit') : t('common.add')}`,
        width: '40%',
        onFinish: async values => {
          values.id = record.id
          const params = { ...values }
          console.log('新增/编辑参数', params)
          await (record.id ? action.update : action.add)(params)
          dynamicTableInstance.reload()
        },
      },
      formProps: {
        labelWidth: 100,
        layout: 'horizontal',
        schemas: formSchemas,
      },
    })

    formRef?.updateSchema([
      {
        field: 'parentCode',
        componentProps: {
          treeDefaultExpandedKeys: [''].concat(record?.keyPath || []),
          treeData: [{ key: '', code: '#', children: treeData.value }],
        },
      },
    ])

    if (record.id) {
      const data = await action.getById(record.id)

      formRef?.setFieldsValue({
        ...data,
      })
    }
  }

  /** 绑定产品料号 */
  const openBindPartModal = async record => {
    const [formRef] = await showModal({
      modalProps: {
        title: `绑定产品`,
        width: '40%',
        onFinish: async values => {
          values.id = record.id
          const params = { ...values }
          await action.bindPart(params)
        },
      },
      formProps: {
        labelWidth: 120,
        layout: 'horizontal',
        schemas: bindPartFormSchemas,
      },
    })
    if (record.id) {
      formRef?.setFieldsValue({
        ...record,
      })
    }
  }

  /**
   * 表格列
   */
  const columns: TableColumn<any>[] = [
    ...baseColumns,
    {
      title: '操作',
      width: 240,
      dataIndex: 'ACTION',
      hideInSearch: true,
      align: 'center',
      fixed: 'right',
      actions: ({ record }) => [
        {
          label: t('common.edit'),
          auth: {
            perm: '/api/Bom/Update',
            effect: 'disable',
          },
          onClick: () => openModal(record),
        },
        {
          label: '绑定产品',
          auth: {
            perm: '/api/Bom/Update',
            effect: 'disable',
          },
          onClick: () => openBindPartModal(record),
        },
        {
          label: t('common.delete'),
          danger: true,
          auth: {
            perm: '/api/Bom/Delete',
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
