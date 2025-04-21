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
    field: 'remark',
    component: 'InputTextArea',
    label: '备注',
  },
]
