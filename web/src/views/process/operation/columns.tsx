import type { TableColumn } from '@/components/core/dynamic-table'
import { Tag } from 'ant-design-vue'
import { getTagColor } from '@/enums/commonEnum'

export const baseColumns: TableColumn[] = [
  {
    title: 'id',
    dataIndex: 'id',
    sorter: true,
    width: 60,
    hideInTable: true,
    hideInSearch: true,
  },
  {
    title: '编码',
    dataIndex: 'code',
  },
  {
    title: '名称',
    dataIndex: 'name',
  },
  {
    title: '类型',
    dataIndex: 'typeName',
    width: 100,
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
    sorter: true,
    width: 160,
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
