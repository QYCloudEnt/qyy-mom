import type { FormSchema } from '@/components/core/schema-form'

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
    field: 'spec',
    component: 'Input',
    label: '规格型号',
  },
  {
    field: 'unit',
    component: 'Select',
    label: '单位',
    required: true,
    componentProps: {
      options: [],
    },
  },
  {
    field: 'warnQty',
    component: 'InputNumber',
    label: '预警值',
    helpMessage: '当ReelId库存数量<=预警值时, 系统会发出预警!',
  },
  {
    field: 'groupType',
    component: 'RadioGroup',
    label: '群组类型',
    defaultValue: 'Material',
    required: true,
    componentProps: ({}) => ({
      options: [],
    }),
  },
  {
    field: 'partGroupId',
    component: 'Select',
    label: '群组',
    required: true,
  },
  {
    field: 'description',
    component: 'InputTextArea',
    label: '描述',
  },
]
