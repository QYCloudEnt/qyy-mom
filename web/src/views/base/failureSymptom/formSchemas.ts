import type { FormSchema } from '@/components/core/schema-form'
import failureTypeAction from '@/api/base/failureType'

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
    field: 'failureTypeId',
    component: 'Select',
    label: '类型',
    required: true,
    componentProps: {
      request: async () => {
        const { list } = await failureTypeAction.getWithPage({ pageSize: 200 })
        return list.map(item => ({ label: item.name, value: item.id }))
      },
    },
  },
  {
    field: 'description',
    component: 'InputTextArea',
    label: '描述',
  },
]
