declare module '*.vue' {
  import type { DefineComponent } from 'vue'
  const Component: DefineComponent<{}, {}, any>
  export default Component
}

declare module 'mitt' {
  import mitt from 'mitt'
  export default mitt
}

declare module 'ant-design-vue/es/locale/*' {
  import type { Locale } from 'ant-design-vue/types/locale-provider'
  const locale: Locale & ReadonlyRecordable
  export default locale as Locale & ReadonlyRecordable
}

declare module 'virtual:*' {
  const result: any
  export default result
}

declare module 'dhtmlx-gantt' {
  import gantt from 'dhtmlx-gantt'
  export default gantt
}
