import type { TableColumn } from '@/components/core/dynamic-table'
import { Tag, Image } from 'ant-design-vue'
import {
  PublishStatusEnum,
  getEmunIndex,
  transformEnumToOptions,
  getTagColor,
} from '@/enums/commonEnum'
import { renderImg } from '@/utils/common'

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
    title: '名称',
    width: 150,
    dataIndex: 'name',
    resizable: true,
  },
  {
    title: '预览图',
    dataIndex: 'imgUrl',
    width: 150,
    hideInSearch: true,
    customRender: ({ record }) => {
      return <Image width={120} src={renderImg(record.imgUrl)} />
    },
  },
  {
    title: '类型',
    dataIndex: 'typeName',
    hideInSearch: true,
    customRender: ({ text }) => {
      return <Tag color={getTagColor(text)}>{text}</Tag>
    },
  },
  {
    title: '状态',
    dataIndex: 'status',
    formItemProps: {
      component: 'Select',
      componentProps: {
        options: transformEnumToOptions(PublishStatusEnum),
      },
    },
    customRender: ({ text }) => (
      <Tag color={['error', 'success'][getEmunIndex(PublishStatusEnum, text)]}>
        {PublishStatusEnum[text]}
      </Tag>
    ),
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
    title: '更新时间',
    dataIndex: 'updateTime',
    width: 170,
    hideInSearch: true,
  },
]
