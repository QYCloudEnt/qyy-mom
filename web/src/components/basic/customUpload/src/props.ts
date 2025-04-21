import type { PropType } from 'vue'
import type { FileBasicColumn } from './typing'
import { useI18n } from '@/hooks/useI18n'

const { t } = useI18n()

export const basicProps = {
  helpText: {
    type: String,
    default: '',
  },
  /** 按钮名称 */
  btnName: {
    type: String,
    default: t('component.upload.upload'),
  },
  /** 文件最大多少MB */
  maxSize: {
    type: Number,
    default: 2,
  },
  // 最大数量的文件，Infinity不限制
  maxNumber: {
    type: Number,
    default: Infinity,
  },
  /** 模板下载地址 */
  templateUrl: {
    type: String,
    default: '',
  },
  /** 模板名称 */
  templateName: {
    type: String,
    default: t('common.templateDownload'),
  },
  /** 是否导入功能 */
  isImport: {
    type: Boolean,
    default: false,
  },
  // 根据后缀，或者其他
  accept: {
    type: Array as PropType<string[]>,
    default: () => [],
  },
  multiple: {
    type: Boolean,
    default: true,
  },
  uploadParams: {
    type: Object,
    default: {},
  },
  /** 上传接口 */
  api: {
    type: Function,
    default: null,
    required: true,
  },
  name: {
    type: String,
    default: 'file',
  },
  filename: {
    type: String,
    default: '',
  },
  /**
   * 隐藏预览按钮
   */
  hidePreviewBtn: {
    type: Boolean,
    default: false,
  },
}

export const uploadContainerProps = {
  value: {
    type: Array,
    default: () => [],
  },
  ...basicProps,
  showPreviewNumber: {
    type: Boolean,
    default: true,
  },
  emptyHidePreview: {
    type: Boolean,
    default: false,
  },
}

export type UploadProps = {
  value: {
    type: Array<any>
  }
  helpText: {
    type: String
  }
  /** 按钮名称 */
  btnName: {
    type: String
  }
  /** 文件最大多少MB */
  maxSize: {
    type: Number
  }
  /** 最大数量的文件，Infinity不限制 */
  maxNumber: {
    type: Number
  }
  // 根据后缀，或者其他
  accept: {
    type: Array<any>
  }
  multiple: {
    type: Boolean
  }
  uploadParams: {
    type: Object
  }
  api: {
    type: Function
  }
  name: {
    type: String
  }
  filename: {
    type: String
  }
  showPreviewNumber: {
    type: Boolean
  }
  emptyHidePreview: {
    type: Boolean
  }
}

export const previewProps = {
  value: {
    type: Array as PropType<string[]>,
    default: () => [],
  },
}

export const fileListProps = {
  columns: {
    type: [Array] as PropType<FileBasicColumn[]>,
    default: null,
  },
  actionColumn: {
    type: Object as PropType<FileBasicColumn>,
    default: null,
  },
  dataSource: {
    type: Array as PropType<any[]>,
    default: null,
  },
}
