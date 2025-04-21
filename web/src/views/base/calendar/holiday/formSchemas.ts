import type { FormSchema } from '@/components/core/schema-form/src/types/form'

export const formSchemas: FormSchema[] = [
  {
    field: 'date',
    label: '日期',
    component: 'Input',
    dynamicDisabled: true,
    colProps: {
      span: 18,
    },
  },
  {
    field: 'type',
    label: '类型',
    component: 'RadioGroup',
    required: true,
    componentProps: {
      options: [
        { label: '休', value: 'holiday' },
        { label: '班', value: 'workday' },
      ],
    },
  },
]
