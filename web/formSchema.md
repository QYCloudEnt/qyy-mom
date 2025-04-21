<div align=center>表单FormSchema模板文件</div>

```typescript

const schemas: FormSchema[] = [
  {
    field: 'name', // 字段名
    label: '输入框', // 字段标签
    component: 'Input', // 组件类型: Input | InputNumber | Select | DatePicker | Tree | Switch | RadioGroup | CheckboxGroup | Upload | InputTextArea | RangePicker ......
    helpMessage: '字段提示信息', // 字段提示信息
    required: true, // 是否必填
    componentProps: { // 组件属性
      placeholder: '请输入姓名'
    },
    colProps: { // 列属性
      span: 24, // 栅格布局大小 0~24
    },
  },
  {
    field: 'age',
    label: '数字输入框',
    component: 'InputNumber',
    required: true,
    componentProps: {
      placeholder: '请输入年龄'
    }
  },
  {
    field: 'gender',
    label: '选择框(静态数据源)',
    component: 'Select',
    required: true,
    componentProps: {
      placeholder: '请选择性别',
      options: [
        { label: '男', value: 'male' },
        { label: '女', value: 'female' }
      ]
    }
  },
  {
    field: 'hobby',
    label: '选择框(动态数据源)',
    component: 'Select',
    required: true,
    componentProps: {
      request: async () => await Api.get('xxx')
    }
  },
  {
    field: 'rangeDate',
    label: '日期范围选择',
    component: 'RangePicker',
  },
  {
    field: 'remark',
    label: '文本域',
    component: 'InputTextArea',
  },
  ......
]

```