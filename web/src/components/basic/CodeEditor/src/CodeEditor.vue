<template>
  <div class="h-full">
    <div v-if="prefix" class="prefix">{{ prefix }}</div>
    <CodeMirrorEditor
      :value="getValue"
      :mode="mode"
      :readonly="readonly"
      :ok-text="okText"
      :ok-type="okType"
      :show-ok-btn="showOkBtn"
      :hint-word="hintWord"
      :hint-list="hintList"
      @change="handleValueChange"
      @ok="submit(value)"
    />
    <div v-if="suffix" class="suffix">{{ suffix }}</div>
  </div>
</template>

<script lang="ts" setup>
  import { computed } from 'vue'
  import CodeMirrorEditor from './codemirror/CodeMirror.vue'
  import { CodeEditorProps } from './props'
  import { isString } from '@/utils/is'
  const MODE = {
    JSON: 'application/json',
    html: 'htmlmixed',
    js: 'javascript',
  }

  const props = defineProps({
    value: { type: [Object, String] as PropType<Record<string, any> | string> },
    /**
     * text/x-sparksql
     * application/json
     * ...
     */
    mode: { type: String, default: 'text/x-sparksql' },
    readonly: { type: Boolean },
    okText: { type: String, default: '' },
    okType: { type: String, default: 'primary' },
    showOkBtn: { type: Boolean, default: true },
    autoFormat: { type: Boolean, default: true },
    /**
     * 按钮事件
     */
    submit: { type: Function as (...args: any[]) => any },
    /** 触发提示字符 */
    hintWord: { type: String, default: '@' },
    /** 提示文字列表  */
    hintList: { type: Array, default: () => [] },
    /** 前缀 */
    prefix: { type: String, default: '' },
    /** 后缀 */
    suffix: { type: String, default: '' },
  })

  // console.log(props.okText)

  const emit = defineEmits(['change', 'update:value', 'format-error', 'ok'])

  const getValue = computed(() => {
    const { value, mode, autoFormat } = props
    if (!autoFormat || mode !== MODE.JSON) {
      return value as string
    }
    let result = value
    if (isString(value)) {
      try {
        result = JSON.parse(value)
      } catch (e) {
        emit('format-error', value)
        return value as string
      }
    }
    return JSON.stringify(result, null, 2)
  })

  function handleValueChange(v) {
    emit('update:value', v)
    emit('change', v)
  }
</script>
<style scoped lang="less">
  .prefix,
  .suffix {
    padding-left: 18px;
    background-color: #292d3e;
    color: #bb8ade;
  }
</style>
