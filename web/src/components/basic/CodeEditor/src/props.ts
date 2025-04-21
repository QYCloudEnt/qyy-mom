import { useI18n } from '@/hooks/useI18n'
const { t } = useI18n()

export const CodeEditorProps = {
  value: { type: [Object, String] },
  /**
   * text/javascript
   * text/x-sparksql
   * application/json
   * ...
   */
  mode: { type: String, default: 'text/x-sparksql' },
  readonly: { type: Boolean },
  autoFormat: { type: Boolean, default: true },
  okText: { type: String, default: t('common.okText') },
  okType: { type: String, default: 'primary' },
  showOkBtn: { type: Boolean, default: true },
  /**
   * 按钮事件
   */
  submit: { type: Function as (value: string) => any },
  // okButtonProps: Object as PropType<Recordable>

  /** 触发提示字符 (mode = 'application/json'生效) */
  hintWord: { type: String, default: '@' },
  /** 提示文字列表  */
  hintList: { type: Array, default: () => [] },
  /** 前缀 */
  prefix: { type: String, default: '' },
  /** 后缀 */
  suffix: { type: String, default: '' },
}
