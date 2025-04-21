<template>
  <div>
    <Space>
      <a-button type="primary" @click="openUploadModal as any">
        <CloudUploadOutlined />
        {{ props.btnName ?? t('component.upload.upload') }}
      </a-button>
      <Tooltip v-if="showPreview" placement="bottom">
        <template #title>
          {{ t('component.upload.uploaded') }}
          <template v-if="fileList.length">
            {{ fileList.length }}
          </template>
        </template>
        <a-button @click="openPreviewModal as any">
          <EyeOutlined />
          <template v-if="fileList.length && showPreviewNumber">
            {{ fileList.length }}
          </template>
        </a-button>
      </Tooltip>
    </Space>
    <UploadModal
      v-bind="bindValue"
      :preview-file-list="fileList"
      @register="registerUploadModal"
      @delete="handleDelete"
      @success="handleSuccess"
    />

    <UploadPreviewModal
      :value="fileList"
      @register="registerPreviewModal"
      @list-change="handlePreviewChange"
      @delete="handlePreviewDelete"
    />
  </div>
</template>
<script lang="ts">
  import { defineComponent, ref, watch, unref, computed } from 'vue'
  import { CloudUploadOutlined, EyeOutlined } from '@ant-design/icons-vue'
  import { Tooltip, Space, message } from 'ant-design-vue'
  import { useModal } from '@/components/core/Modal'
  import { uploadContainerProps } from './props'
  import { omit } from 'lodash-es'
  import { useI18n } from '@/hooks/useI18n'
  import { isArray } from '@/utils/is'
  import UploadModal from './UploadModal.vue'
  import UploadPreviewModal from './UploadPreviewModal.vue'

  export default defineComponent({
    name: 'BasicUpload',
    components: {
      UploadModal,
      Space,
      UploadPreviewModal,
      EyeOutlined,
      Tooltip,
      CloudUploadOutlined,
    },
    props: uploadContainerProps,
    emits: ['change', 'delete', 'preview-delete', 'update:value', 'success'],

    setup(props, { emit, attrs }) {
      const { t } = useI18n()
      // 上传modal
      const [registerUploadModal, { openModal: openUploadModal }] = useModal()

      // 预览modal
      const [registerPreviewModal, { openModal: openPreviewModal }] = useModal()

      const fileList = ref<string[]>([])

      const showPreview = computed(() => {
        const { emptyHidePreview, hidePreviewBtn } = props
        if (hidePreviewBtn) return false
        if (!emptyHidePreview) return true
        return emptyHidePreview ? fileList.value.length > 0 : true
      })

      const bindValue = computed(() => {
        const value = { ...attrs, ...props }
        return omit(value, 'onChange')
      })

      watch(
        () => props.value,
        (value = []) => {
          fileList.value = isArray(value) ? (value as any) : []
        },
        { immediate: true },
      )

      // 上传modal保存操作
      function handleChange(urls: string[]) {
        fileList.value = [...unref(fileList), ...(urls || [])]
        emit('update:value', fileList.value)
        emit('change', fileList.value)
        emit('success', fileList.value)
        message.success(t('component.upload.saveSuccess'))
      }

      // 预览modal保存操作
      function handlePreviewChange(urls: string[]) {
        fileList.value = [...(urls || [])]
        emit('update:value', fileList.value)
        emit('change', fileList.value)
      }

      // 上传成功回调
      function handleSuccess(urls: string[] | null) {
        if (props.maxNumber === 1) {
          fileList.value = [...(urls || [])]
        } else {
          fileList.value = [...unref(fileList), ...(urls || [])]
        }
        emit('update:value', fileList.value)
        emit('success', fileList.value)
        message.success('操作成功')
      }

      function handleDelete(record: Recordable) {
        emit('delete', record)
      }

      function handlePreviewDelete(url: string) {
        emit('preview-delete', url)
      }

      return {
        props,
        registerUploadModal,
        openUploadModal,
        handleChange,
        handlePreviewChange,
        registerPreviewModal,
        openPreviewModal,
        fileList,
        showPreview,
        bindValue,
        handleDelete,
        handlePreviewDelete,
        handleSuccess,
        t,
      }
    },
  })
</script>
