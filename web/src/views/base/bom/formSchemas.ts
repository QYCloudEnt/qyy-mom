import type { FormSchema } from '@/components/core/schema-form'
import cacheAction from '@/api/cache/'
import partAction from '@/api/base/partMaterial'

/**
 * 表单信息
 */
export const formSchemas: FormSchema[] = [
  {
    field: 'code',
    component: 'Input',
    label: '编码',
    required: true,
    colProps: {
      span: 24,
    },
  },
  {
    field: 'name',
    component: 'Input',
    label: '名称',
    required: true,
    colProps: {
      span: 24,
    },
  },
  {
    field: 'version',
    component: 'Input',
    label: '版本',
    defaultValue: '1.0',
    colProps: {
      span: 1242,
    },
  },
  {
    field: 'parentCode',
    component: 'TreeSelect',
    label: '上级',
    componentProps: {
      fieldNames: {
        label: 'code',
        value: 'key',
      },
      getPopupContainer: () => document.body,
    },
  },
  {
    field: 'processOperationId',
    component: 'Select',
    label: '工序',
    componentProps: {
      showSearch: true,
      optionFilterProp: 'label',
      option: [],
    },
  },
  {
    field: 'useQty',
    component: 'InputNumber',
    helpMessage: '保留2位小数',
    label: '用量',
  },
  {
    field: 'description',
    component: 'InputTextArea',
    label: '描述',
  },
]

export const bindPartFormSchemas: FormSchema[] = [
  {
    field: 'partCode',
    component: 'Select',
    label: '产品料号',
    helpMessage: '用于BOM编码和产品料号编码不一致对应时使用',
    required: true,
    componentProps: {
      showSearch: true,
      optionFilterProp: 'label', // label 作为搜索条件
      request: async () => {
        const list = await partAction.getListByGroupType('Product')
        return list.map(item => ({
          label: item.code,
          value: item.code,
        }))
      },
    },
  },
]
