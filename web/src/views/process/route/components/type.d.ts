export type BaseParamsType = {
  isStart: boolean
  isOutput: boolean
  /** 是否缺料提醒 */
  isLackMaterialWarn: boolean
  /** 跳转的工艺路线id */
  jumpToRouteId?: number
  /** 跳转后回来的工序id */
  backOperationId?: number
}

export type TestParamType = {
  testMode?: string
  maxTestCount?: number
}

export type ConfigParamType = {
  /** 工序id */
  id: number
  base: BaseParamsType
  test: TestParamType
}

export type ProcessItemType = {
  id: string
  nextId: string
  label: string
}
