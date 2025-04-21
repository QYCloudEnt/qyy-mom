import type { TableColumn } from '@/components/core/dynamic-table'
import { getTagColor } from '@/enums/commonEnum'
import { Tag } from 'ant-design-vue'

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
    width: 150,
    dataIndex: 'code',
  },
  {
    title: '名称',
    width: 200,
    dataIndex: 'name',
  },
  {
    title: '类型',
    dataIndex: ['failureType', 'name'],
    hideInSearch: true,
    customRender: ({ text }) => {
      return <Tag color={getTagColor(text)}>{text}</Tag>
    },
  },
  {
    title: '描述',
    dataIndex: 'description',
    hideInSearch: true,
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
