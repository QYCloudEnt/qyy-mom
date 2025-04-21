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
    field: 'description',
    component: 'InputTextArea',
    label: '描述',
  },
]
