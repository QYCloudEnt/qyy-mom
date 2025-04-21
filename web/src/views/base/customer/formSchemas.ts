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
      span: 12,
    },
  },
  {
    field: 'name',
    component: 'Input',
    label: '名称',
    required: true,
    colProps: {
      span: 12,
    },
  },
  {
    field: 'shortName',
    component: 'Input',
    label: '简称',
    colProps: {
      span: 12,
    },
  },
  {
    field: 'phone',
    component: 'Input',
    label: '联系方式',
    colProps: {
      span: 12,
    },
  },
  {
    field: 'creditCode',
    component: 'Input',
    label: '社会信用代码',
  },
  {
    field: 'addr',
    component: 'InputTextArea',
    label: '地址',
  },
  {
    field: 'remark',
    component: 'InputTextArea',
    label: '备注',
  },
]
