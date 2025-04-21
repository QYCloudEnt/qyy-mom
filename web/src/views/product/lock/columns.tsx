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
    title: '类型',
    dataIndex: 'type',
  },
  {
    title: '编码',
    dataIndex: 'code',
  },
  {
    title: '工序',
    dataIndex: 'operation',
  },
  {
    title: '锁定起止日期',
    dataIndex: 'lockTime',
  },
]
