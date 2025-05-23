import type { DropdownProps } from 'ant-design-vue/es/dropdown'

export interface Axis {
  x: number
  y: number
}

export interface ContextMenuItem {
  label: string
  icon?: string
  hidden?: boolean
  disabled?: boolean
  handler?: Fn
  divider?: boolean
  children?: ContextMenuItem[]
}
export interface CreateContextOptions {
  event: MouseEvent
  icon?: string
  styles?: any
  items?: ContextMenuItem[]
}

export interface ContextMenuProps extends DropdownProps {
  event?: MouseEvent
  styles?: any
  items: ContextMenuItem[]
  customEvent?: MouseEvent
  axis?: Axis
  width?: number
  showIcon?: boolean
}

export interface ItemContentProps {
  showIcon: boolean | undefined
  item: ContextMenuItem
  handler: Fn
}
