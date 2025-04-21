<div align=center>表格TableColumn模板文件</div>

```typescript

const columns: TableColumn[] = [
  {
    title: 'id', // 列标题
    dataIndex: 'id', // 列标识(唯一)
    width: 60, // 列宽度
    sorter: true, // 是否可排序
    hideInTable: true, // 是否在表格中隐藏
    hideInSearch: true, // 是否在搜索中隐藏
    formItemProps: { // 表单的属性, 详细信息见 FormSchema 配置
      component: 'Select',
      componentProps: {
        options: [{ label: '选项1', value: 1 }, { label: '选项2', value: 2 }],
      },
    },
    customRender: ({ text }) => <Tag color={getTagColor(text)}>{text}</Tag>, // 自定义渲染列
    ellipsis: true, // 是否超出宽度自动省略
    resizable: true, // 是否可调整列宽

  },
  {
    title: '名称',
    width: 150,
    dataIndex: 'name',
  },
  {
    title: '取子表列',
    dataIndex: ['qcCheckType', 'name'],
    hideInSearch: true,
    width: 150,
    customRender: ({ text }) => <Tag color={getTagColor(text)}>{text}</Tag>,
  },
  {
    title: '工具',
    dataIndex: 'tool',
    hideInSearch: true,
    width: 150,
    ellipsis: true,
    resizable: true,
  },
  {
    title: '标准值',
    dataIndex: 'standardVal',
    hideInSearch: true,
    width: 150,
    ellipsis: true,
    resizable: true,
  },
  ......
]

```