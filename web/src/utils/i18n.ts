import { useI18n } from '@/hooks/useI18n'

const { t } = useI18n()

/**
 * 表单Label和表格列名的多语言渲染
 * @param key 表单field/表格dataIndex
 * @param i18n 默认的组件中的props的i18n属性
 * @param defaultVal 默认值
 * @returns
 */
export const i18nRender = (
  key: string | number | string[],
  i18n: string | undefined,
  defaultVal?: string,
) => {
  if (Array.isArray(key)) return defaultVal
  // 解决报表查询中的查询参数 忽略翻译（ignoreI18n属性）的BUG
  if ((key as string).startsWith('@')) return defaultVal
  // t('common.add') ==> common.add
  // 原因： 直接在formSchemas/columns中转换，需要刷新才会生效, 所以统一在此处理; 另外在formSchemas/columns中也可以预览文本
  if (i18n) return t(i18n.replace("t('", '').replace("')", '')) as string
  const i18nText = t(`column.${key}`)
  // 没有配置国际化的数据则返回默认值
  if (i18nText == `column.${key}`) return defaultVal
  return i18nText
}
