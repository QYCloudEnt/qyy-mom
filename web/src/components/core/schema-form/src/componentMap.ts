/**
 * Component list, register here to setting it in the form
 */
import {
  Input,
  Select,
  Radio,
  Checkbox,
  AutoComplete,
  Cascader,
  DatePicker,
  InputNumber,
  Switch,
  TimePicker,
  TreeSelect,
  Tree,
  Slider,
  Rate,
  Divider,
  Upload,
  Mentions,
} from 'ant-design-vue'
import type { Component, VNodeProps } from 'vue'
import { CustomUpload } from '@/components/basic/customUpload'
import { CodeEditor } from '@/components/basic/CodeEditor'

const componentMap = {
  Input,
  InputGroup: Input.Group,
  InputPassword: Input.Password,
  InputSearch: Input.Search,
  InputTextArea: Input.TextArea,
  InputNumber,
  AutoComplete,
  Select,
  TreeSelect,
  Tree,
  Switch,
  RadioGroup: Radio.Group,
  Checkbox,
  CheckboxGroup: Checkbox.Group,
  Cascader,
  Slider,
  Rate,
  DatePicker,
  MonthPicker: DatePicker.MonthPicker,
  RangePicker: DatePicker.RangePicker,
  WeekPicker: DatePicker.WeekPicker,
  TimePicker,
  Upload,
  Mentions,
  Divider,
  CustomUpload,
  CodeEditor,
}

type ExtractPropTypes<T extends Component> = T extends new (...args: any) => any
  ? Writable<Omit<InstanceType<T>['$props'], keyof VNodeProps>>
  : never

type ComponentMapType = typeof componentMap

export type ComponentType = keyof ComponentMapType

export type ComponentMapProps = {
  [K in ComponentType]: ExtractPropTypes<ComponentMapType[K]>
}

export type AllComponentProps = ComponentMapProps[ComponentType]

export { componentMap }
