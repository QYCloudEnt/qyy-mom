<template>
  <Modal v-bind="getBindValue" class="mom-modal" @cancel="handleCancel">
    <template v-if="!$slots.closeIcon" #closeIcon>
      <ModalClose
        :can-fullscreen="getProps.canFullscreen"
        :full-screen="fullScreenRef"
        @cancel="handleCancel"
        @fullscreen="handleFullScreen"
      />
    </template>

    <template v-if="!$slots.title" #title>
      <ModalHeader
        :help-message="getProps.helpMessage"
        :title="getMergeProps.title"
        @dblclick="handleTitleDbClick"
      />
    </template>

    <template v-if="!$slots.footer" #footer>
      <ModalFooter v-bind="getBindValue" @ok="handleOk" @cancel="handleCancel">
        <template v-for="item in Object.keys($slots)" #[item]="data">
          <slot :name="item" v-bind="data || {}"></slot>
        </template>
      </ModalFooter>
    </template>

    <ModalWrapper
      ref="modalWrapperRef"
      :use-wrapper="getProps.useWrapper"
      :footer-offset="wrapperFooterOffset"
      :full-screen="fullScreenRef"
      :loading="getProps.loading"
      :loading-tip="getProps.loadingTip"
      :min-height="getProps.minHeight"
      :height="getWrapperHeight"
      :open="openRef"
      :modal-footer-height="footer !== undefined && !footer ? 0 : undefined"
      v-bind="omit(getProps.wrapperProps, 'open', 'height', 'modalFooterHeight')"
      @ext-height="handleExtHeight"
      @height-change="handleHeightChange"
    >
      <slot></slot>
    </ModalWrapper>

    <template v-for="item in Object.keys(omit($slots, 'default'))" #[item]="data">
      <slot :name="item" v-bind="data || {}"></slot>
    </template>
  </Modal>
</template>
<script lang="ts">
  import type { ModalProps, ModalMethods } from './typing'

  import {
    defineComponent,
    computed,
    ref,
    watch,
    unref,
    watchEffect,
    toRef,
    getCurrentInstance,
    nextTick,
  } from 'vue'
  import Modal from './components/Modal'
  import ModalWrapper from './components/ModalWrapper.vue'
  import ModalClose from './components/ModalClose.vue'
  import ModalFooter from './components/ModalFooter.vue'
  import ModalHeader from './components/ModalHeader.vue'
  import { isFunction } from '@/utils/is'
  import { deepMerge } from '@/utils'
  import { basicProps } from './props'
  import { useFullScreen } from './hooks/useModalFullScreen'
  import { omit } from 'lodash-es'

  export default defineComponent({
    name: 'BasicModal',
    components: { Modal, ModalWrapper, ModalClose, ModalFooter, ModalHeader },
    inheritAttrs: false,
    props: basicProps,
    emits: ['open-change', 'height-change', 'cancel', 'ok', 'register', 'update:open'],
    setup(props, { emit, attrs }) {
      const openRef = ref(false)
      const propsRef = ref<Partial<ModalProps> | null>(null)
      const modalWrapperRef = ref<any>(null)
      const prefixCls = 'mom-basic-modal'

      // modal   Bottom and top height
      const extHeightRef = ref(0)
      const modalMethods: ModalMethods = {
        setModalProps,
        emitVisible: undefined,
        redoModalHeight: () => {
          nextTick(() => {
            if (unref(modalWrapperRef)) {
              ;(unref(modalWrapperRef) as any).setModalHeight()
            }
          })
        },
      }

      const instance = getCurrentInstance()
      if (instance) {
        emit('register', modalMethods, instance.uid)
      }

      // Custom title component: get title
      const getMergeProps = computed((): Recordable => {
        return {
          ...props,
          ...(unref(propsRef) as any),
        }
      })

      const { handleFullScreen, getWrapClassName, fullScreenRef } = useFullScreen({
        modalWrapperRef,
        extHeightRef,
        wrapClassName: toRef(getMergeProps.value, 'wrapClassName'),
      })

      // modal component does not need title and origin buttons
      const getProps = computed((): Recordable => {
        const opt = {
          ...unref(getMergeProps),
          open: unref(openRef),
          okButtonProps: undefined,
          cancelButtonProps: undefined,
          title: undefined,
        }
        return {
          ...opt,
          wrapClassName: unref(getWrapClassName),
        }
      })

      const getBindValue = computed((): Recordable => {
        const attr = {
          ...attrs,
          ...unref(getMergeProps),
          open: unref(openRef),
          wrapClassName: unref(getWrapClassName),
        }
        if (unref(fullScreenRef)) {
          return omit(attr, ['height', 'title'])
        }
        return omit(attr, 'title')
      })

      const getWrapperHeight = computed(() => {
        if (unref(fullScreenRef)) return undefined
        return unref(getProps).height
      })

      watchEffect(() => {
        openRef.value = !!props.open
        fullScreenRef.value = !!props.defaultFullscreen
      })

      watch(
        () => unref(openRef),
        v => {
          emit('open-change', v)
          emit('update:open', v)
          instance && modalMethods.emitVisible?.(v, instance.uid)
          nextTick(() => {
            if (props.scrollTop && v && unref(modalWrapperRef)) {
              ;(unref(modalWrapperRef) as any).scrollTop()
            }
          })
        },
        {
          immediate: false,
        },
      )

      // 取消事件
      async function handleCancel(e: Event) {
        e?.stopPropagation()
        // 过滤自定义关闭按钮的空白区域
        if ((e.target as HTMLElement)?.classList?.contains(`${prefixCls}-close--custom`)) return
        if (props.closeFunc && isFunction(props.closeFunc)) {
          const isClose: boolean = await props.closeFunc()
          openRef.value = !isClose
          return
        }

        openRef.value = false
        emit('cancel', e)
      }

      /**
       * @description: 设置modal参数
       */
      function setModalProps(props: Partial<ModalProps>): void {
        // Keep the last setModalProps
        propsRef.value = deepMerge(unref(propsRef) || ({} as any), props)
        if (Reflect.has(props, 'open')) {
          openRef.value = !!props.open
        }
        if (Reflect.has(props, 'defaultFullscreen')) {
          fullScreenRef.value = !!props.defaultFullscreen
        }
      }

      function handleOk(e: Event) {
        emit('ok', e)
      }

      function handleHeightChange(height: string) {
        emit('height-change', height)
      }

      function handleExtHeight(height: number) {
        extHeightRef.value = height
      }

      function handleTitleDbClick(e) {
        if (!props.canFullscreen) return
        e.stopPropagation()
        handleFullScreen(e)
      }

      return {
        handleCancel,
        getBindValue,
        getProps,
        handleFullScreen,
        fullScreenRef,
        getMergeProps,
        handleOk,
        openRef,
        omit,
        modalWrapperRef,
        handleExtHeight,
        handleHeightChange,
        handleTitleDbClick,
        getWrapperHeight,
      }
    },
  })
</script>
<style lang="less">
  .ant-modal-close {
    background-color: transparent;
  }
</style>
