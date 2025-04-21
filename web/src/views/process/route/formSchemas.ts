import type { FormSchema } from '@/components/core/schema-form'
import { TestModeEnum, transformEnumToOptions } from '@/enums/commonEnum'
import action from '@/api/process/route'

/**
 * 表单信息
 */
export const formSchemas: FormSchema[] = [
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
    field: 'content',
    component: 'Input',
    label: '内容',
    vIf: () => false,
  },
  {
    field: 'type',
    component: 'Select',
    label: '类型',
    required: true,
    componentProps: {
      options: [
        { label: '一般', value: 'NORMAL' },
        { label: '测试', value: 'TEST' },
      ],
    },
  },
  {
    field: 'sopUrls',
    component: 'CustomUpload',
    label: '作业指导书',
    componentProps: () => ({
      maxNumber: 1,
      maxSize: 20,
      accept: ['.pdf'],
      hidePreviewBtn: false,
      api: action.uploadSop,
    }),
  },
  {
    field: 'description',
    component: 'InputTextArea',
    label: '描述',
  },
]

/** 基础信息 */
export const baseFormSchemas: FormSchema[] = [
  {
    field: 'id',
    component: 'Input',
    label: 'id',
    vIf: () => false,
  },
  {
    field: 'isStart',
    component: 'Switch',
    label: '起始站',
    colProps: {
      span: 12,
    },
  },
  {
    field: 'isOutput',
    component: 'Switch',
    label: '产出站',
    colProps: {
      span: 12,
    },
  },
  {
    field: 'isLackMaterialWarn',
    component: 'Switch',
    label: '缺料提醒',
    colProps: {
      span: 12,
    },
  },
]

/** 测试相关 */
export const testFormSchemas: FormSchema[] = [
  {
    field: 'id',
    component: 'Input',
    label: 'id',
    vIf: () => false,
  },
  {
    field: 'testMode',
    component: 'Select',
    label: '测试模式',
    componentProps: {
      options: transformEnumToOptions(TestModeEnum),
    },
  },
  {
    field: 'maxTestCount',
    component: 'InputNumber',
    label: '最大测试次数',
  },
]
