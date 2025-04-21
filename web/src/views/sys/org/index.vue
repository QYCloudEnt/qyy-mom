<template>
  <div>
    <DynamicTable
      ref="dynamicTableRef"
      row-key="id"
      :header-title="$t('column.orgId')"
      :data-request="loadData"
      :columns="columns"
      bordered
      size="small"
      :pagination="false"
      :search="false"
    >
      <template #toolbar>
        <CustomUpload
          :empty-hide-preview="true"
          :max-size="20"
          :max-number="1"
          :hide-preview-btn="true"
          template-url="/api/SysUser/GetImportTemplate"
          :btn-name="$t('common.import')"
          :is-import="true"
          :api="testAction.UploadFile"
          @success="handleSuccess"
        />
        <a-button v-if="$auth('/api/SysOrg/Add')" type="primary" @click="openMenuModal({})">
          {{ $t('common.add') }}
        </a-button>
      </template>
    </DynamicTable>
  </div>
</template>
<script lang="tsx" setup>
  import { ref } from 'vue'
  import { Tag, type TreeSelectProps } from 'ant-design-vue'
  import { formatTree } from '@/utils/tree'
  import { cloneDeep } from 'lodash-es'
  import { DynamicTable } from '@/components/core/dynamic-table'
  import { useFormModal } from '@/hooks/useModal/useFormModal'
  import type { FormSchema } from '@/components/core/schema-form/src/types/form'
  import type { TableColumn } from '@/components/core/dynamic-table'
  import { CustomUpload } from '@/components/basic/customUpload'
  import action from '@/api/sys/org'
  import testAction from '@/api/values'
  import { exportPageParam } from '@/utils/global'
  import { useI18n } from '@/hooks/useI18n'

  defineOptions({
    name: 'Org',
  })

  const { t } = useI18n()
  const tree = ref<TreeSelectProps['treeData']>([])
  const dynamicTableRef = ref<InstanceType<typeof DynamicTable>>()

  const [showModal] = useFormModal()

  /** 测试 上传组件 start */

  /**
   * 保存回调
   */
  const handleSuccess = (list: string[]) => {
    console.log(list)
    dynamicTableRef.value?.fetchData({ orgCode: list[0] })
  }

  /** 测试 上传组件 end */

  /**
   * 加载数据
   */
  const loadData = async params => {
    Object.assign(params, exportPageParam)
    const { list } = await action.getWithPage(params)
    tree.value = formatTree(cloneDeep(list), 'orgName', -1)
    return tree.value
  }

  /**
   * 打开新增/编辑弹窗
   */
  const openMenuModal = async record => {
    const [formRef] = await showModal({
      modalProps: {
        title: `${record.id ? t('common.edit') : t('common.add')}`,
        width: '40%',
        onFinish: async values => {
          values.id = record.id
          const params = { ...values }
          await (record.id ? action.update : action.add)(params)
          dynamicTableRef.value?.reload()
        },
      },
      formProps: {
        labelWidth: 100,
        schemas: formSchemas,
      },
    })

    formRef?.updateSchema([
      {
        field: 'parentId',
        componentProps: {
          treeDefaultExpandedKeys: [-1].concat(record?.keyPath || []),
          treeData: [{ key: -1, name: '#', children: tree.value }],
        },
      },
    ])

    formRef?.setFieldsValue({
      ...record,
      parentId: record.parentId ?? -1,
    })
  }

  /**
   * 删除行数据
   */
  const delRowConfirm = async (id: number) => {
    await action.delete([id])
    dynamicTableRef.value?.reload()
  }

  /**
   * 表格列
   */
  const columns: TableColumn<any>[] = [
    {
      title: 'id',
      dataIndex: 'id',
      width: 55,
      align: 'center',
      hideInTable: true,
      hideInSearch: true,
    },
    {
      title: '组织编码',
      dataIndex: 'orgCode',
      align: 'center',
    },
    {
      title: '组织名称',
      dataIndex: 'orgName',
      align: 'center',
    },
    {
      title: '创建时间',
      align: 'center',
      dataIndex: 'createTime',
      hideInSearch: true,
      formItemProps: {
        component: 'RangePicker',
        componentProps: {
          class: 'w-full',
        },
      },
    },
    // {
    //   title: '表格内上传操作',
    //   align: 'center',
    //   dataIndex: '',
    //   hideInSearch: true,
    //   bodyCell: () => (
    //     <BasicUpload
    //       btn-name="测试上传"
    //       empty-hide-preview={true}
    //       maxSize={20}
    //       maxNumber={10}
    //       change={handleChange}
    //       api={testAction.UploadFile}
    //       class="my-5"
    //       accept={['image/bmp']}
    //     />
    //   )
    // },
    {
      title: '操作',
      width: 200,
      dataIndex: 'ACTION',
      hideInSearch: true,
      align: 'center',
      fixed: 'right',
      actions: ({ record }) => [
        {
          label: t('common.edit'),
          auth: {
            perm: '/api/SysOrg/Update',
            effect: 'disable',
          },
          onClick: () => openMenuModal(record),
        },
        {
          label: t('common.delete'),
          danger: true,
          auth: {
            perm: '/api/SysOrg/Delete',
            effect: 'disable',
          },
          popConfirm: {
            title: t('column.confirmDel'),
            onConfirm: () => delRowConfirm(record.Id),
          },
        },
      ],
    },
  ]

  /**
   * 表单信息
   */
  const formSchemas: FormSchema[] = [
    {
      field: 'orgCode',
      component: 'Input',
      label: '组织编码',
      required: true,
    },
    {
      field: 'orgName',
      component: 'Input',
      label: '组织名称',
      required: true,
    },
    {
      field: 'parentId',
      component: 'TreeSelect',
      label: '上级组织',
      i18n: `t('column.parentOrg')`,
      componentProps: {
        fieldNames: {
          label: 'name',
          value: 'key',
        },
        getPopupContainer: () => document.body,
      },
      rules: [{ required: true, type: 'number' }],
    },
    // 测试表单内 上传文件
    // {
    //   field: 'file',
    //   component: 'Upload',
    //   label: '上传文件',
    //   // rules: [{ required: true, message: '请选择上传文件' }],
    //   componentProps: {
    //     // props: @/component/basic/upload/src/props
    //     api: testAction.UploadFile,
    //     helpText: 'excel格式'
    //   }
    // }
  ]
</script>
