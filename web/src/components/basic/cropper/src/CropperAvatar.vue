<template>
  <div :class="getClass" :style="getStyle">
    <div :class="`${prefixCls}-image-wrapper`" :style="getImageWrapperStyle" @click="openModal">
      <div :class="`${prefixCls}-image-mask`" :style="getImageWrapperStyle">
        <CloudUploadOutlined
          style="color: aliceblue; font-size: 100px"
          :style="getImageWrapperStyle"
        />
      </div>
      <img v-if="sourceValue" :src="sourceValue" />
    </div>
    <a-button
      v-if="showBtn"
      :class="`${prefixCls}-upload-btn mt-4`"
      v-bind="btnProps"
      @click="openModal"
    >
      <CloudUploadOutlined />
      {{ btnText ? btnText : t('component.cropper.selectImage') }}
    </a-button>

    <CopperModal
      :upload-api="uploadApi"
      :src="sourceValue"
      @register="register"
      @upload-success="handleUploadSuccess"
    />
  </div>
</template>
<script lang="ts">
  import {
    defineComponent,
    computed,
    type CSSProperties,
    unref,
    ref,
    watchEffect,
    watch,
    type PropType,
  } from 'vue'
  import { message } from 'ant-design-vue'
  import CopperModal from './CopperModal.vue'
  import { useModal } from '@/components/core/Modal'
  import { useI18n } from '@/hooks/useI18n'
  import type { ButtonProps } from '@/components/basic/button'
  import { CloudUploadOutlined } from '@ant-design/icons-vue'

  const props = {
    width: { type: [String, Number], default: '200px' },
    value: { type: String },
    showBtn: { type: Boolean, default: true },
    btnProps: { type: Object as PropType<ButtonProps> },
    btnText: { type: String, default: '' },
    uploadApi: { type: Function },
    // uploadApi: { type: Function as PropType<({ file: Blob, name: string }) => Promise<void>> }
  }

  export default defineComponent({
    name: 'CropperAvatar',
    components: { CopperModal, CloudUploadOutlined },
    props,
    emits: ['update:value', 'change'],
    setup(props, { emit, expose }) {
      const sourceValue = ref(props.value || '')
      const prefixCls = 'mom-cropper-avatar'
      const [register, { openModal, closeModal }] = useModal()
      const { t } = useI18n()

      const getClass = computed(() => [prefixCls])

      const getWidth = computed(() => `${`${props.width}`.replace(/px/, '')}px`)

      const getIconWidth = computed(() => `${parseInt(`${props.width}`.replace(/px/, '')) / 2}px`)

      const getStyle = computed((): CSSProperties => ({ width: unref(getWidth) }))

      const getImageWrapperStyle = computed(
        (): CSSProperties => ({ width: unref(getWidth), height: unref(getWidth) }),
      )

      watchEffect(() => {
        sourceValue.value = props.value || ''
      })

      watch(
        () => sourceValue.value,
        (v: string) => {
          emit('update:value', v)
        },
      )

      /**
       * 上传成功后事件
       * @param param0 source: base64图片, data: 接口返回的data
       */
      function handleUploadSuccess({ source, data }) {
        sourceValue.value = source
        emit('change', source, data)
        message.success(t('component.cropper.uploadSuccess'))
      }

      expose({ openModal: openModal.bind(null, true), closeModal })

      return {
        t,
        prefixCls,
        register,
        openModal: openModal as any,
        getIconWidth,
        sourceValue,
        getClass,
        getImageWrapperStyle,
        getStyle,
        handleUploadSuccess,
      }
    },
  })
</script>

<style lang="less" scoped>
  @prefix-cls: ~'mom-cropper-avatar';

  .@{prefix-cls} {
    display: inline-block;
    text-align: center;

    &-image-wrapper {
      overflow: hidden;
      // background: @component-background;
      border: 1px solid #d9d9d9;
      border-radius: 50%;
      cursor: pointer;

      img {
        width: 100%;
      }
    }

    &-image-mask {
      position: absolute;
      width: inherit;
      height: inherit;
      transition: opacity 0.4s;
      border-radius: inherit;
      opacity: 0;
      background: rgb(0 0 0 / 40%);
      cursor: pointer;

      ::v-deep(svg) {
        margin: auto;
        margin-top: 22%;
      }
    }

    &-image-mask:hover {
      opacity: 40;
    }

    &-upload-btn {
      margin: 10px auto;
    }
  }
</style>
