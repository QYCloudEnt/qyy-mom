import { isVerticalScreen } from '@/utils/validate'
import type { FormSchema } from '../types'
import { computed } from 'vue'

/**
 * 计算表单项的col span
 * @param formSchemas 表单项
 * @returns
 */
export const useFormColSpan = (formSchemas: FormSchema[]) => {
  const schemas = computed(() => {
    return formSchemas.map(item => {
      const component = item.component || 'Input'
      let span = ['TableSelect', 'RangePicker', 'TransferSelect'].includes(component as string)
        ? 8
        : 4
      if (isVerticalScreen()) {
        span = 20
      } else if (document.body.clientWidth <= 1440) {
        span = 8
      }
      return { colProps: { span }, ...item }
    })
  })

  return { schemas }
}
