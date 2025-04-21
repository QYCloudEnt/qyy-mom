/**
 * @type {import('prettier').Config}
 */
export default {
  printWidth: 100,
  semi: false,
  vueIndentScriptAndStyle: true,
  singleQuote: true,
  trailingComma: 'all',
  proseWrap: 'never',
  htmlWhitespaceSensitivity: 'strict',
  endOfLine: 'auto',
  // prettier-自动格式化代码
  formatOnSave: true,
  // prettier- (x) => {} 箭头函数参数只有一个时是否要有小括号。avoid：省略括号
  arrowParens: 'avoid',
}
