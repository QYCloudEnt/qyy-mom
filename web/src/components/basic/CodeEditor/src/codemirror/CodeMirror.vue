<template>
  <div ref="el" class="mom-codeEditor">
    <a-button v-if="showOkBtn" id="ok-btn" :type="okType" @click="handleOk">
      {{ okText || t('common.okText') }}
    </a-button>
    <Tooltip class="codeFullScreen" :title="getTitle" placement="bottom" :mouse-enter-delay="0.5">
      <span @click="toggleDom">
        <FullscreenOutlined v-if="!isFullscreen" :style="{ fontSize: '20px', color: '#fff' }" />
        <FullscreenExitOutlined v-else :style="{ fontSize: '20px', color: '#fff' }" />
      </span>
    </Tooltip>
  </div>
</template>

<script lang="ts" setup>
  import { ref, onMounted, onUnmounted, watchEffect, watch, unref, nextTick, computed } from 'vue'
  import { useDebounceFn, useFullscreen } from '@vueuse/core'
  import { useI18n } from '@/hooks/useI18n'
  import { useWindowSizeFn } from '@/hooks/event/useWindowSizeFn'
  import { FullscreenExitOutlined, FullscreenOutlined } from '@ant-design/icons-vue'
  import { Tooltip } from 'ant-design-vue'
  import { CodeEditorProps } from '../props'
  import CodeMirror from 'codemirror'
  // css
  import './codemirror.css'
  import 'codemirror/theme/idea.css'
  import 'codemirror/theme/material-palenight.css'
  import 'codemirror/addon/lint/json-lint'
  import 'codemirror/addon/hint/show-hint.css'
  // modes
  import 'codemirror/mode/javascript/javascript'
  import 'codemirror/mode/css/css'
  import 'codemirror/mode/htmlmixed/htmlmixed'
  import 'codemirror/mode/sql/sql'
  import 'codemirror/addon/hint/show-hint'
  import 'codemirror/addon/hint/sql-hint'
  import 'codemirror/addon/hint/javascript-hint'
  // import 'codemirror/addon/hint/anyword-hint'

  const { t } = useI18n()
  const props = defineProps({
    mode: { type: String, default: 'text/x-sparksql' },
    value: { type: String, default: '' },
    readonly: { type: Boolean, default: false },
    okText: { type: String, default: '' },
    okType: { type: String, default: 'primary' },
    showOkBtn: { type: Boolean, default: true },
    submit: { type: Function },
    hintWord: { type: String, default: '' },
    hintList: { type: Array, default: () => [] },
  })

  onMounted(async () => {
    await nextTick()
    init()
    useWindowSizeFn(debounceRefresh)
  })

  onUnmounted(() => {
    editor = null
  })

  const emit = defineEmits(['change', 'ok'])

  const el = ref<Nullable<HTMLElement>>(null)
  let editor: Nullable<CodeMirror.Editor>

  const debounceRefresh = useDebounceFn(refresh, 100)

  const { toggle: toggleDom, isFullscreen } = useFullscreen(el)

  const getTitle = computed(() => {
    return unref(isFullscreen)
      ? t('layout.header.tooltipExitFull')
      : t('layout.header.tooltipEntryFull')
  })

  function handleOk() {
    emit('ok')
  }

  watch(
    () => props.value,
    async value => {
      await nextTick()
      const oldValue = editor?.getValue()
      if (value !== oldValue) {
        editor?.setValue(value ? value : '')
      }
    },
    { flush: 'post' },
  )

  watchEffect(() => {
    editor?.setOption('mode', props.mode)
  })

  function setTheme() {
    unref(editor)?.setOption('theme', 'material-palenight')
  }

  function refresh() {
    editor?.refresh()
  }

  /**
   * 自定义提示
   */
  function handleShowHint() {
    const cur = editor.getCursor() // 获取当前最新输入
    const curLine = editor.getLine(cur.line) // 获取当前所在行数
    const end = cur.ch // 获取最新输入结束位置
    const start = end - 1 // 设置检测输入的起始位置（本案例中只检测最新输入的一个字符）
    const word = curLine.charAt(start) // 获取最新输入的内容（本案例中为最新输入的一个字符）
    if (word != props.hintWord || !props.hintList) return
    return {
      hint() {
        return {
          from: CodeMirror.Pos(cur.line, start + 1), // 需要自动替换的起始位置（本案例中为最新输入的一个字符的位置）
          to: CodeMirror.Pos(cur.line, end), // 需要自动替换的终止位置（本案例中为当前输入最末端）
          list: props.hintList, // 由自动提示项组成的数组
        }
      },
    }
  }

  async function init() {
    const addonOptions = {
      autoCloseBrackets: true,
      autoCloseTags: true,
      autoRefresh: true,
      foldGutter: true,
      styleActiveLine: true, // 光标所在行高亮
      // extraKeys: { '@': 'autocomplete' }, // 切换默认提示快捷键
      lint: true,
      // hint: CodeMirror.hint.sql,
      hintOptions: {
        completeSingle: false, // 当匹配只有一项的时候是否自动补全
        tables: {},
      },
      gutters: ['CodeMirror-linenumbers', 'CodeMirror-lint-markers'],
    }

    editor = CodeMirror(el.value!, {
      value: '',
      mode: props.mode,
      readOnly: props.readonly,
      tabSize: 4,
      theme: 'material-palenight',
      lineWrapping: true,
      lineNumbers: true,
      ...addonOptions,
    })
    editor?.setValue(props.value)
    setTheme()
    editor?.on('change', () => {
      emit('change', editor?.getValue())
    })

    editor?.on('inputRead', function () {
      if (props.hintList.length) {
        editor?.showHint(handleShowHint())
      } else {
        editor?.showHint()
      }
    })
  }
</script>
<style lang="less">
  .mom-codeEditor {
    position: relative;
    width: 100%;
    height: 100%;
    overflow: auto;

    & #ok-btn {
      position: absolute;
      z-index: 999;
      right: 0;
      bottom: 0;
    }

    & .codeFullScreen {
      position: absolute;
      z-index: 999;
      top: 0;
      right: 0;
      cursor: pointer;
    }
  }
</style>
