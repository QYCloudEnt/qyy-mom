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
    field: 'type',
    component: 'Select',
    label: '类型',
    required: true,
    componentProps: {
      options: [],
    },
  },
  {
    field: 'description',
    component: 'InputTextArea',
    label: '描述',
  },
]
