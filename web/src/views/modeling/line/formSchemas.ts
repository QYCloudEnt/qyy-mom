import type { FormSchema } from '@/components/core/schema-form'
import workshopAction from '@/api/modeling/workshop'

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
    field: 'workshopId',
    component: 'Select',
    label: '所属车间',
    componentProps: {
      request: async () => {
        const { list } = await workshopAction.getWithPage({ pageSize: 10000 })
        return list.map(item => ({
          label: item.name,
          value: item.id,
        }))
      },
    },
  },
  {
    field: 'description',
    component: 'InputTextArea',
    label: '描述',
  },
]
