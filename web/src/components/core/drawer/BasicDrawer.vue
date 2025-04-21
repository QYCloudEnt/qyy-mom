<template>
  <transition name="fade-transform" mode="out-in" appear>
    <div>
      <Drawer
        v-bind="getBindValues"
        :title="drawerInfo.title"
        :placement="placement"
        :closable="drawerInfo.showCloseIcon"
        :open="drawerInfo.open"
        :width="drawerInfo.width"
        :mask-closable="drawerInfo.clickmaskFlag"
        @close="onClose"
      >
        <Spin :spinning="drawerInfo.loading">
          <div class="drawer-content">
            <slot></slot>
          </div>
        </Spin>
        <DrawerFooter v-bind="getProps" :confirm-loading="drawerInfo.loading" @close="onClose">
          <template v-for="item in Object.keys($slots)" #[item]="data">
            <slot :name="item" v-bind="data || {}"></slot>
          </template>
        </DrawerFooter>
      </Drawer>
    </div>
  </transition>
</template>
<script lang="ts">
  import { defineComponent, reactive, watch, unref, computed, ref, toRaw } from 'vue'
  import { Drawer, Spin } from 'ant-design-vue'
  import DrawerFooter from './components/DrawerFooter.vue'
  import { drawerProps } from './drawer'
  import { deepMerge } from '@/utils'
  import { type DrawerProps } from 'ant-design-vue/es/drawer'
  import { useAttrs } from '@/hooks/useAttrs'
  export default defineComponent({
    components: { Drawer, DrawerFooter, Spin },
    props: {
      ...drawerProps(),
      loading: {
        type: Boolean,
        default: false,
      },
      // 打开方向
      openDirection: {
        type: String,
        default: 'right',
      },
      // 宽度
      width: {
        type: String,
        default: '500px',
      },
      /**
       * 标题
       */
      title: {
        type: String,
        required: true,
      },
      // 是否展示抽屉
      open: {
        type: Boolean,
        default: false,
      },
      // 显示关闭图标
      showCloseflag: {
        type: Boolean,
        default: true,
      },
      //  点击蒙层是否允许关闭
      clickmaskFlag: {
        type: Boolean,
        default: true,
      },
    },
    setup(props, { emit }) {
      const attrs = useAttrs()
      const visibleRef = ref(false)
      const propsRef = ref<Partial<Nullable<DrawerProps>>>(null)

      const drawerInfo = reactive({
        placement: props.openDirection || undefined, //打开的方向
        width: props.width, //宽度
        title: props.title, //标题
        loading: props.loading, //是否加载中
        open: props.open, //默认关闭
        showCloseIcon: props.showCloseflag, //closable
        clickmaskFlag: props.clickmaskFlag, //  点击蒙层是否允许关闭
      })
      // 点击遮罩层或右上角叉或取消按钮的回调
      function onClose() {
        emit('onClose')
      }

      function handleOk() {
        emit('ok')
      }

      // 监听打开或者关闭
      watch(props, ({ open, loading }) => {
        drawerInfo.open = open
        drawerInfo.loading = loading
        drawerInfo.title = props.title
      })

      const getMergeProps = computed((): DrawerProps => {
        return deepMerge(toRaw(props), unref(propsRef))
      })

      const getProps = computed((): DrawerProps => {
        const opt = {
          placement: 'right',
          ...unref(attrs),
          ...unref(getMergeProps),
          open: unref(visibleRef),
        }
        opt.title = undefined
        const { width, getContainer } = opt

        if (!width) {
          opt.width = '100%'
        }
        return opt as DrawerProps
      })

      const getBindValues = computed((): DrawerProps => {
        return {
          ...attrs,
          ...unref(getProps),
        }
      })

      return {
        drawerInfo,
        handleOk,
        onClose,
        getBindValues,
        getProps: getProps as any,
      }
    },
  })
</script>
<style lang="less" scoped>
  .drawer-content {
    // display: flex;
    // justify-content: center;
    // align-items: center;
    margin-bottom: 60px;
    // padding: 5px;
    // min-height: 500px;
    // overflow-y: scroll;
  }
</style>
