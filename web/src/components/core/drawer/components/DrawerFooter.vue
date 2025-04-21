<template>
  <div v-if="showFooter || $slots.footer" :class="prefixCls" :style="getStyle">
    <template v-if="!$slots.footer">
      <slot name="insertFooter"></slot>
      <a-button v-if="showCancelBtn" v-bind="cancelButtonProps" class="mr-2" @click="handleClose">
        {{ cancelText }}
      </a-button>
      <slot name="centerFooter"></slot>
      <a-button
        v-if="showOkBtn"
        :type="okType"
        v-bind="okButtonProps"
        class="mr-2"
        :loading="confirmLoading"
        @click="handleOk"
      >
        {{ okText }}
      </a-button>
      <slot name="appendFooter"></slot>
    </template>

    <template v-else>
      <slot name="footer"></slot>
    </template>
  </div>
</template>
<script lang="ts">
  import type { CSSProperties } from 'vue'
  import { defineComponent, computed } from 'vue'
  import { useLayoutSettingStore } from '@/store/modules/layoutSetting'
  // import { useDesign } from '/@/hooks/web/useDesign'

  import { footerProps } from '../props'
  export default defineComponent({
    name: 'BasicDrawerFooter',
    props: {
      ...footerProps,
      height: {
        type: String,
        default: '60px',
      },
    },
    emits: ['ok', 'close'],
    setup(props, { emit }) {
      const prefixCls = 'ant-basic-drawer-footer'
      const themeStore = useLayoutSettingStore()

      const getStyle = computed((): CSSProperties => {
        const { getNavTheme } = themeStore
        const heightStr = `${props.height}`
        const isDark = getNavTheme === 'dark'
        return {
          height: heightStr,
          lineHeight: heightStr,
          backgroundColor: getNavTheme === 'realDark' ? 'rgb(31, 31, 31)' : 'rgb(255, 255, 255)',
          borderTop:
            getNavTheme === 'realDark'
              ? '1px solid rgba(253, 253, 253, 0.12)'
              : '1px solid rgba(5, 5, 5, 0.06)',
        }
      })

      function handleOk() {
        emit('ok')
      }

      function handleClose() {
        emit('close')
      }
      return { handleOk, prefixCls, handleClose, getStyle }
    },
  })
</script>

<style lang="less">
  @prefix-cls: ~'ant-basic-drawer-footer';
  @footer-height: 60px;
  .@{prefix-cls} {
    position: absolute;
    z-index: 999999;
    bottom: 0;
    left: 0;
    width: 100%;
    padding: 0 12px 0 20px;
    // background-color: @component-background;
    border-top: 1px solid #d9d9d9;
    text-align: right;

    > * {
      margin-right: 8px;
    }
  }
</style>
