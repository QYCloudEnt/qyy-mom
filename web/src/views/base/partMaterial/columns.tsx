import type { TableColumn } from '@/components/core/dynamic-table'
import { Tag } from 'ant-design-vue'
import { getTagColor, transformEnumToOptions } from '@/enums/commonEnum'

export const baseColumns: TableColumn[] = [
  {
    title: 'id',
    dataIndex: 'id',
    width: 60,
    sorter: true,
    hideInTable: true,
    hideInSearch: true,
  },
  {
    title: '编码',
    dataIndex: 'code',
    width: 200,
    ellipsis: true,
    resizable: true,
  },
  {
    title: '名称',
    dataIndex: 'name',
    width: 200,
    ellipsis: true,
    resizable: true,
  },
  {
    title: '规格型号',
    width: 150,
    dataIndex: 'spec',
    hideInSearch: true,
  },
  {
    title: '单位',
    dataIndex: 'unit',
    width: 120,
    hideInSearch: true,
  },
  {
    title: '预警值',
    dataIndex: 'warnQty',
    width: 120,
    hideInSearch: true,
  },
  {
    title: '群组名称',
    dataIndex: ['partGroup', 'name'],
    hideInSearch: true,
    width: 200,
    ellipsis: true,
    resizable: true,
  },
  {
    title: '群组类型',
    width: 150,
    dataIndex: ['partGroup', 'type'],
    formItemProps: {
      component: 'Select',
      componentProps: {
        options: [],
      },
    },
  },
  {
    title: '工艺路线',
    dataIndex: ['processRoute', 'name'],
    hideInSearch: true,
    width: 150,
    ellipsis: true,
    resizable: true,
  },
  {
    title: '描述',
    dataIndex: 'description',
    width: 160,
    hideInSearch: true,
    ellipsis: true,
    resizable: true,
  },
  {
    title: '创建人',
    dataIndex: 'createUser',
    width: 160,
    hideInSearch: true,
  },
  {
    title: '创建时间',
    dataIndex: 'createTime',
    width: 170,
    sorter: true,
    hideInSearch: true,
  },
  {
    title: '更新人',
    dataIndex: 'updateUser',
    width: 160,
    hideInSearch: true,
    hideInTable: true,
  },
  {
    title: '更新时间',
    dataIndex: 'updateTime',
    width: 170,
    hideInSearch: true,
  },
]
