import type { FormSchema } from '@/components/core/schema-form'

/**
 * 表单信息
 */
export const formSchemas: FormSchema[] = [
  {
    field: 'sourceMaterialId',
    component: 'Select',
    label: '源物料',
    required: true,
    componentProps: {
      options: [],
    },
  },
  {
    field: 'replaceMaterialId',
    component: 'Select',
    label: '替代物料',
    required: true,
    componentProps: {
      options: [],
    },
  },
  {
    field: 'expDateS',
    component: 'DatePicker',
    label: '有效开始日期',
  },
  {
    field: 'expDateE',
    component: 'DatePicker',
    label: '有效截止日期',
  },
  {
    field: 'remark',
    component: 'InputTextArea',
    label: '备注',
  },
]
