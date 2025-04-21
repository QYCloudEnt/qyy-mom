<template>
  <div :class="getClass">
    <template v-if="canFullscreen">
      <Tooltip v-if="fullScreen" :title="t('component.modal.restore')" placement="bottom">
        <FullscreenExitOutlined role="full" @click="handleFullScreen" />
      </Tooltip>
      <Tooltip v-else :title="t('component.modal.maximize')" placement="bottom">
        <FullscreenOutlined role="close" @click="handleFullScreen" />
      </Tooltip>
    </template>
    <Tooltip :title="t('component.model.close')" placement="bottom">
      <CloseOutlined @click="handleCancel" />
    </Tooltip>
  </div>
</template>
<script lang="ts">
  import { defineComponent, computed } from 'vue'
  import { FullscreenExitOutlined, FullscreenOutlined, CloseOutlined } from '@ant-design/icons-vue'
  import { Tooltip } from 'ant-design-vue'
  import { useI18n } from '@/hooks/useI18n'

  export default defineComponent({
    name: 'ModalClose',
    components: { Tooltip, FullscreenExitOutlined, FullscreenOutlined, CloseOutlined },
    props: {
      canFullscreen: { type: Boolean, default: false },
      fullScreen: { type: Boolean },
    },
    emits: ['cancel', 'fullscreen'],
    setup(props, { emit }) {
      const prefixCls = 'mom-basic-modal-close'
      const { t } = useI18n()

      const getClass = computed(() => {
        return [
          prefixCls,
          `${prefixCls}--custom`,
          {
            [`${prefixCls}--can-full`]: props.canFullscreen,
          },
        ]
      })

      function handleCancel(e: Event) {
        emit('cancel', e)
      }

      function handleFullScreen(e: Event) {
        e?.stopPropagation()
        e?.preventDefault()
        emit('fullscreen')
      }

      return {
        t,
        getClass,
        prefixCls,
        handleCancel,
        handleFullScreen,
      }
    },
  })
</script>
<style lang="less" scoped>
  @prefix-cls: ~'mom-basic-modal-close';
  .@{prefix-cls} {
    display: flex;
    align-items: center;
    height: 95%;

    > span {
      // margin-left: 18px;
      font-size: 16px;
    }

    &--can-full {
      > span {
        margin-left: 12px;
      }
    }

    &:not(&--can-full) {
      > span:nth-child(1) {
        &:hover {
          font-weight: 700;
        }
      }
    }

    & span:nth-child(1) {
      display: inline-block;
      padding: 10px;

      &:hover {
        color: '#13c2c2';
      }
    }

    & span:last-child {
      &:hover {
        color: #f5222d;
      }
    }
  }
</style>
