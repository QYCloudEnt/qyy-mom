import { ref, computed, getCurrentInstance } from 'vue'
import { Modal } from 'ant-design-vue'
import { ExclamationCircleOutlined } from '@ant-design/icons-vue'
import { useRoute } from 'vue-router'
import { useResizeObserver } from '@vueuse/core'
import { useI18n } from '@/hooks/useI18n'
import { useFormModal } from '@/hooks/useModal/useFormModal'
import { formatToDate, formatToDateTime } from '@/utils/dateUtil'
import { exportExcelForTable } from '@/components/basic/excel'
import { exportPageParam } from '@/utils/global'
import type DynamicTable from '../dynamic-table.vue'
import type { TableColumn } from '@/components/core/dynamic-table'
import type { FormSchema } from '@/components/core/schema-form'
import { initTagKeyColorMap } from '@/enums/commonEnum'

const { t } = useI18n()

type actionType = {
  getWithPage: (params: API.PageParams) => Promise<API.TableListResult<any>>
  getById: (id: number | string) => Promise<any>
  add: (params: any) => Promise<any>
  update: (params: any) => Promise<any>
  delete: (ids: number[]) => Promise<any>
}

type formModalType = {
  width?: string
  labelWidth?: number
  top?: number
}

type tablePluginType = {
  /** 表格实例 */
  dynamicTableInstance: InstanceType<typeof DynamicTable>
  /** 接口Action */
  action: actionType
  /** 表格基础列 */
  columns: TableColumn<any>[]
  /** 表单项 */
  formSchemas: FormSchema[]
  /** 表单Modal属性配置 */
  formModalProps?: formModalType
  /** 表单字段映射回调函数(会和其他字段合并) */
  formDataCallback?: (data: any) => Object
  /** 查询参数回调函数 */
  searchParamCallback?: (params: any) => void
  /** 表单参数提交前回调函数 */
  formParamCallback?: (params: any, record?: any) => void
}

/**
 * 表格基础增删改查hook
 * @param props 属性
 * @returns
 */
export function useTablePlugin(props: tablePluginType) {
  const [showModal] = useFormModal()
  const route = useRoute()
  const exportLoading = ref(false)
  const searchParams = ref({})

  const {
    dynamicTableInstance,
    action,
    columns,
    formSchemas,
    formModalProps = { width: '40%', labelWidth: 100, top: undefined },
    formDataCallback,
    searchParamCallback,
    formParamCallback,
  } = props

  initTagKeyColorMap()

  const colWidthSum = computed(() =>
    columns
      .filter(col => !col.hideInTable)
      .map(col => parseInt(col.width || 300))
      .reduce((sum, width) => sum + width),
  )

  const currentInstance = getCurrentInstance()

  useResizeObserver(document.documentElement, () => {
    const el = currentInstance?.proxy?.$el as HTMLDivElement
    // console.log(colWidthSum.value, el.offsetWidth, window.innerWidth, el)
    if (el && colWidthSum.value > el.offsetWidth) {
      dynamicTableInstance.setProps({
        scroll: { x: window.innerWidth > 2000 ? el.offsetWidth - 20 : 2000 },
      })
    }
  })

  /**
   * 表格行选择
   */
  const rowSelection = ref({
    selectedRowKeys: [] as number[],
    selectedRows: [] as any[],
    onChange: (selectedRowKeys: number[], selectedRows) => {
      rowSelection.value.selectedRowKeys = selectedRowKeys
      rowSelection.value.selectedRows = selectedRows
    },
  })

  /** 取消选择 */
  const handleCancelSelect = () => {
    rowSelection.value.selectedRowKeys = []
    rowSelection.value.selectedRows = []
  }

  /**
   * 勾选的行数据
   */
  const checkRows = computed(() => {
    const { selectedRows } = rowSelection.value
    return { count: selectedRows.length, rows: selectedRows }
  })

  /**
   * 导出
   */
  const aoaToExcel = async () => {
    exportLoading.value = true
    Object.assign(searchParams.value, exportPageParam)
    const { list } = await action
      .getWithPage(searchParams.value)
      .finally(() => (exportLoading.value = false))
    exportExcelForTable(list, columns, `${route.meta.title}${formatToDateTime()}.xlsx`)
  }

  /**
   * 加载数据
   */
  const loadData = async params => {
    if (params?.createTime) {
      params.createTimeS = formatToDate(params.createTime[0])
      params.createTimeE = formatToDate(params.createTime[1])
      delete params.createTime
    }
    searchParamCallback && searchParamCallback(params)
    searchParams.value = params
    const data = await action.getWithPage(params)
    handleCancelSelect()
    return data
  }

  /**
   * 重置
   */
  const reset = () => {
    handleCancelSelect()
    dynamicTableInstance.reload()
  }

  /**
   * 打开新增/编辑弹窗
   */
  const openModal = async record => {
    const [formRef] = await showModal({
      modalProps: {
        title: `${record.id ? t('common.edit') : t('common.add')}`,
        width: formModalProps.width || '40%',
        onFinish: async values => {
          values.id = record.id
          formParamCallback && formParamCallback(values, record)
          const params = { ...record, ...values }
          console.log('新增/编辑参数', params)
          await (record.id ? action.update : action.add)(params)
          dynamicTableInstance.reload()
        },
      },
      formProps: {
        labelWidth: formModalProps.labelWidth || 100,
        layout: 'horizontal',
        schemas: formSchemas,
      },
    })

    if (record.id) {
      const data = await action.getById(record.id)

      formRef?.setFieldsValue({
        ...data,
        ...formDataCallback?.(data),
      })
    }
  }

  /**
   * 删除行数据
   */
  const delRowConfirm = async (id: number | number[]) => {
    if (!Array.isArray(id)) {
      await action.delete([id])
      reset()
      return
    }
    Modal.confirm({
      title: t('column.confirmDelSelectedData'),
      icon: <ExclamationCircleOutlined />,
      centered: true,
      onOk: async () => {
        const ids = Array.isArray(id) ? id : [id]
        await action.delete(ids)
        reset()
      },
    })
  }

  return {
    /** 表格行选择配置项 */
    rowSelection,
    /** 选中的行信息 */
    checkRows,
    exportLoading,
    /** 加载表格数据 */
    loadData,
    /** 重置 */
    reset,
    /** 导出 */
    aoaToExcel,
    /** 取消选中 */
    handleCancelSelect,
    /** Modal框 */
    showModal,
    /** 打开新增/编辑弹窗 */
    openModal,
    /** 确认删除行 */
    delRowConfirm,
  }
}
