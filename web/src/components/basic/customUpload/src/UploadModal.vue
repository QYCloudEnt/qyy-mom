<template>
  <BasicModal
    width="50%"
    :title="isImport ? t('component.import.import') : t('component.upload.upload')"
    :ok-text="t('component.upload.save')"
    v-bind="$attrs"
    :close-func="handleCloseFunc"
    :mask-closable="false"
    :keyboard="false"
    :show-ok-btn="!isImport"
    class="upload-modal"
    :ok-button-props="getOkButtonProps"
    :cancel-button-props="{ disabled: isUploadingRef }"
    @register="register"
    @ok="handleOk"
  >
    <template v-if="templateUrl" #leftFooter>
      <a :style="{ color: getPrimaryColor }" @click="handleDownloadTemplate">
        {{ templateName }}
      </a>
    </template>
    <template #centerFooter>
      <a-button
        type="primary"
        :disabled="!getIsSelectFile"
        :loading="isUploadingRef"
        @click="handleStartUpload"
      >
        {{ getUploadBtnText }}
      </a-button>
    </template>

    <div class="upload-modal-toolbar">
      <Alert :message="getHelpText" type="info" banner class="upload-modal-toolbar__text" />

      <Upload
        :accept="getStringAccept"
        :multiple="multiple"
        :before-upload="beforeUpload"
        :show-upload-list="false"
        class="upload-modal-toolbar__btn"
      >
        <a-button type="primary">
          {{ t('component.upload.choose') }}
        </a-button>
      </Upload>
    </div>
    <FileList :data-source="fileListRef" :columns="columns" :action-column="actionColumn" />
  </BasicModal>
</template>
<script lang="ts">
  import { defineComponent, reactive, ref, toRefs, unref, computed, type PropType } from 'vue'
  import { Upload, Alert, message as $message } from 'ant-design-vue'
  import { BasicModal, useModalInner } from '@/components/core/Modal'
  // hooks
  import { useUploadType } from './useUpload'
  // import { useMessage } from '@/hooks/useMessage'
  // types
  import { type FileItem, UploadResultStatus } from './typing'
  import { basicProps } from './props'
  import { createTableColumns, createActionColumn } from './data'
  // utils
  import { checkImgType, getBase64WithFile, checkFileType } from './helper'
  import { buildUUID } from '@/utils/uuid'
  import { isFunction, isHttpUrl } from '@/utils/is'
  import FileList from './FileList.vue'
  import { useI18n } from '@/hooks/useI18n'
  import { downloadByUrl } from '@/utils/file/download'
  import { useLayoutSettingStore } from '@/store/modules/layoutSetting'
  import { uniqueSlash } from '@/utils/urlUtils'
  import type { AxiosProgressEvent } from 'axios'

  export default defineComponent({
    components: { BasicModal, Upload, Alert, FileList },
    props: {
      ...basicProps,
      previewFileList: {
        type: Array as PropType<string[]>,
        default: () => [],
      },
    },
    emits: ['change', 'register', 'delete', 'success'],
    setup(props, { emit }) {
      const state = reactive<{ fileList: FileItem[] }>({
        fileList: [],
      })

      const themeStore = useLayoutSettingStore()
      // 是否正在上传
      const isUploadingRef = ref(false)
      const fileListRef = ref<FileItem[]>([])
      const { accept, helpText, maxNumber, maxSize, isImport } = toRefs(props)

      const { t } = useI18n()
      const [register, { closeModal }] = useModalInner()

      const { getStringAccept, getHelpText } = useUploadType({
        acceptRef: accept,
        helpTextRef: helpText,
        maxNumberRef: maxNumber,
        maxSizeRef: maxSize,
      })

      // const { createMessage } = useMessage()

      const getIsSelectFile = computed(() => {
        return (
          fileListRef.value.length > 0 &&
          !fileListRef.value.every(item => item.status === UploadResultStatus.SUCCESS)
        )
      })

      const getOkButtonProps = computed(() => {
        const someSuccess = fileListRef.value.some(
          item => item.status === UploadResultStatus.SUCCESS,
        )
        return {
          disabled: isUploadingRef.value || fileListRef.value.length === 0 || !someSuccess,
        }
      })

      const getUploadBtnText = computed(() => {
        const someError = fileListRef.value.some(item => item.status === UploadResultStatus.ERROR)
        if (isImport.value) {
          return isUploadingRef.value
            ? t('component.import.importing')
            : someError
              ? t('component.import.reImportFailed')
              : t('component.import.startImport')
        }
        return isUploadingRef.value
          ? t('component.upload.uploading')
          : someError
            ? t('component.upload.reUploadFailed')
            : t('component.upload.startUpload')
      })

      const getPrimaryColor = computed(() => themeStore.getPrimaryColor ?? '#13C2C2')

      const handleDownloadTemplate = () => {
        const { templateUrl } = props
        const url = isHttpUrl(templateUrl)
          ? templateUrl
          : `${uniqueSlash(
              (import.meta.env.VITE_BASE_API_URL + templateUrl).replace('/api/api/', '/api/'),
            )}`
        downloadByUrl({ url })
      }

      // 上传前校验
      function beforeUpload(file: File) {
        const { size, name } = file
        const { maxSize, accept } = props
        // 设置最大值，则判断
        if (maxSize && file.size / 1024 / 1024 >= maxSize) {
          $message.error(t('component.upload.maxSizeMultiple', [maxSize]))
          return false
        }

        // 格式校验
        if (!checkFileType(file, accept)) {
          $message.error('文件类型校验失败, 请上传正确格式的文件!')
          return false
        }

        const commonItem = {
          uuid: buildUUID(),
          file,
          size,
          name,
          percent: 0,
          type: name.split('.').pop(),
        }
        // 生成图片缩略图
        if (checkImgType(file)) {
          // beforeUpload，如果异步会调用自带上传方法
          // file.thumbUrl = await getBase64(file);
          getBase64WithFile(file).then(({ result: thumbUrl }) => {
            fileListRef.value = [
              ...unref(fileListRef),
              {
                thumbUrl,
                ...commonItem,
              },
            ]
          })
        } else {
          fileListRef.value = [...unref(fileListRef), commonItem]
        }
        return false
      }

      // 删除
      function handleRemove(record: FileItem) {
        const index = fileListRef.value.findIndex(item => item.uuid === record.uuid)
        index !== -1 && fileListRef.value.splice(index, 1)
        emit('delete', record)
      }

      // 预览
      // function handlePreview(record: FileItem) {
      //   const { thumbUrl = '' } = record;
      //   createImgPreview({
      //     imageList: [thumbUrl],
      //   });
      // }

      async function uploadApiByItem(item: FileItem) {
        const { api } = props
        if (!api || !isFunction(api)) {
          return console.warn('upload api must exist and be a function')
        }
        try {
          item.status = UploadResultStatus.UPLOADING
          // eslint-disable-next-line no-unsafe-optional-chaining
          const data = await props.api?.(
            {
              data: {
                ...(props.uploadParams || {}),
              },
              file: item.file,
              name: props.name,
              filename: props.filename,
            },
            function onUploadProgress(progressEvent: AxiosProgressEvent) {
              const complete = ((progressEvent.loaded / progressEvent.total!) * 100) | 0
              item.percent = complete
            },
          )
          // console.log(data)
          item.status = UploadResultStatus.SUCCESS
          item.responseData = data
          return {
            success: true,
            error: null,
          }
        } catch (e) {
          console.log(e)
          item.status = UploadResultStatus.ERROR
          return {
            success: false,
            error: e,
          }
        }
      }

      // 点击开始上传
      async function handleStartUpload() {
        const { maxNumber } = props
        // if ((fileListRef.value.length + props.previewFileList?.length ?? 0) > maxNumber) {
        //   return createMessage.warning(t('component.upload.maxNumber', [maxNumber]))
        // }
        if (fileListRef.value.length > maxNumber) {
          return $message.warning(t('component.upload.maxNumber', [maxNumber]))
        }
        try {
          isUploadingRef.value = true
          // 只上传不是成功状态的
          const uploadFileList =
            fileListRef.value.filter(item => item.status !== UploadResultStatus.SUCCESS) || []
          const data = await Promise.all(
            uploadFileList.map(item => {
              return uploadApiByItem(item)
            }),
          )
          isUploadingRef.value = false
          // 生产环境:抛出错误
          const errorList = data.filter((item: any) => !item.success)
          if (errorList.length > 0) throw errorList
          // 如果是上传, 成功后即可关闭弹窗
          if (isImport.value && errorList.length == 0) {
            fileListRef.value = []
            closeModal()
            // 执行回调
            emit('success', null)
          }
        } catch (e) {
          isUploadingRef.value = false
          throw e
        }
      }

      //   点击保存
      function handleOk() {
        const { maxNumber } = props

        if (fileListRef.value.length > maxNumber) {
          return $message.warning(t('component.upload.maxNumber', [maxNumber]))
        }
        if (isUploadingRef.value) {
          return $message.warning(t('component.upload.saveWarn'))
        }
        const fileList: string[] = []

        for (const item of fileListRef.value) {
          const { status, responseData } = item
          if (status === UploadResultStatus.SUCCESS && responseData) {
            fileList.push(responseData)
          }
        }
        // 存在一个上传成功的即可保存
        if (fileList.length <= 0) {
          return $message.warning(t('component.upload.saveError'))
        }
        fileListRef.value = []
        closeModal()
        // emit('change', fileList)
        emit('success', fileList)
      }

      // 点击关闭：则所有操作不保存，包括上传的
      async function handleCloseFunc() {
        if (!isUploadingRef.value) {
          fileListRef.value = []
          return true
        } else {
          $message.warning(t('component.upload.uploadWait'))
          return false
        }
      }

      return {
        columns: createTableColumns() as any[],
        actionColumn: createActionColumn(handleRemove) as any,
        register,
        closeModal,
        getHelpText,
        getStringAccept,
        getOkButtonProps,
        beforeUpload,
        // registerTable,
        fileListRef,
        state,
        isUploadingRef,
        handleStartUpload,
        handleOk,
        handleCloseFunc,
        handleDownloadTemplate,
        getPrimaryColor,
        getIsSelectFile,
        getUploadBtnText,
        t,
      }
    },
  })
</script>
<style lang="less" scoped>
  .upload-modal {
    .ant-upload-list {
      display: none;
    }

    .ant-table-wrapper .ant-spin-nested-loading {
      padding: 0;
    }

    &-toolbar {
      display: flex;
      align-items: center;
      margin-bottom: 8px;

      &__btn {
        flex: 1;
        margin-left: 8px;
        text-align: right;
      }
    }
  }
</style>
