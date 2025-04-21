<template>
  <div>
    <Card :bordered="false" class="mb-3">
      <div class="flex items-center">
        <div class="flex items-center gap-40" style="max-width: 800px; margin: 30px auto 0">
          <SchemaForm :schemas />
          <div class="flex flex-col gap-10">
            <Button type="primary" :loading @click="search"> 查询 </Button>
            <Button color="red" :disabled="!dataSource.length" @click="openLockModal">
              锁定
            </Button>
          </div>
        </div>
      </div>
    </Card>

    <DynamicTable
      row-key="code"
      :search="false"
      :allow-search-in-column="false"
      :data-source="dataSource"
      :columns
      bordered
      size="small"
    />
  </div>
</template>

<script lang="ts" setup>
  import { ref, unref } from 'vue'
  import { Card } from 'ant-design-vue'
  import { useForm } from '@/components/core/schema-form'
  import type { FormSchema } from '@/components/core/schema-form'
  import { useTable, type TableColumn } from '@/components/core/dynamic-table'
  import { useFormModal } from '@/hooks/useModal/useFormModal'
  import { useI18n } from '@/hooks/useI18n'
  import { baseColumns } from './columns'
  import { transformEnumToOptions } from '@/enums/commonEnum'
  import { formatToDateTime } from '@/utils/dateUtil'
  import cacheAction from '@/api/cache'
  import action from '@/api/product/lock'

  defineOptions({
    name: 'ProductLock',
  })

  const loading = ref(false)
  const dataSource = ref<any[]>([])
  const [showModal] = useFormModal()

  const { t } = useI18n()
  const [SchemaForm, schemaInstance] = useForm({
    labelWidth: 160,
    showActionButtonGroup: false,
  })
  const [DynamicTable] = useTable()

  const openLockModal = async () => {
    await showModal({
      modalProps: {
        title: `确定锁定`,
        width: '40%',
        onFinish: async values => {
          const params = { ...values, Datas: dataSource.value }
          await action.lock(params)
          await schemaInstance.resetFields()
          dataSource.value = []
        },
      },
      formProps: {
        labelWidth: 130,
        schemas: lockSchemas,
      },
    })
  }

  const search = async () => {
    const values = await schemaInstance.validate()
    loading.value = true
    let params = {
      type: values.type,
      codes: (values.code as string)
        .replaceAll('\n', ',')
        .replaceAll('，', ',')
        .split(',')
        .map(x => x.trim()),
      operationId: values.operationId,
      timeS: '',
      timeE: '',
    }
    if (values.lockTime) {
      params.timeS = formatToDateTime(values.lockTime[0])
      params.timeE = formatToDateTime(values.lockTime[1])
    }
    const data: any[] = await action.getLockInfo(params).finally(() => (loading.value = false))
    const rows = data.filter(item => !dataSource.value.map(x => x.code).includes(item.code))
    console.log(rows, data)
    dataSource.value = [...dataSource.value, ...rows]
  }

  const schemas: FormSchema[] = [
    {
      field: 'type',
      label: '锁定类型',
      required: true,
      component: 'Select',
      componentProps: {
        options: [],
      },
      colProps: {
        span: 24,
      },
    },
    {
      field: 'code',
      label: '编码',
      component: 'InputTextArea',
      componentProps: {
        placeholder: '多个编码，支持换行和逗号分隔',
      },
      required: true,
      colProps: {
        span: 24,
      },
    },
    {
      field: 'operationId',
      label: '工序',
      component: 'Select',
      componentProps: {
        options: [],
      },
    },
    {
      field: 'lockTime',
      label: '锁定时间',
      component: 'RangePicker',
      componentProps: {
        showTime: true,
        format: 'YYYY-MM-DD HH:mm:ss',
      },
    },
  ]

  const lockSchemas: FormSchema[] = [
    {
      field: 'reason',
      label: '锁定原因',
      component: 'InputTextArea',
      required: true,
    },
  ]

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
          label: t('common.delete'),
          danger: true,
          popConfirm: {
            title: t('column.confirmDel'),
            onConfirm: () =>
              (dataSource.value = dataSource.value.filter(x => x.code !== record.code)),
          },
        },
      ],
    },
  ]
</script>

<style lang="less" scoped></style>
