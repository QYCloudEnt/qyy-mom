<template>
  <SplitPanel>
    <template #left-content>
      <Spin :spinning="loading">
        <div class="flex justify-between dark:text-white" style="margin-bottom: 20px">
          <div>{{ $t('routes.menu.sys.org') }}</div>
          <Space>
            <Tooltip placement="top">
              <template #title>{{ $t('common.redo') }}</template>
              <SyncOutlined @click="fetchOrgList" />
            </Tooltip>
          </Space>
        </div>
        <Tree
          v-model:expandedKeys="state.expandedKeys"
          auto-expand-parent
          :tree-data="state.orgTree"
          @select="onTreeSelect"
        />
      </Spin>
    </template>
    <template #right-content>
      <DynamicTable
        ref="dynamicTableRef"
        row-key="id"
        :header-title="$t('routes.menu.sys.user')"
        :data-request="loadData"
        :columns="columns"
        bordered
        size="small"
        :row-selection="rowSelection"
        :scroll="{ x: 1300 }"
      >
        <template v-if="isCheckRows" #title>
          <Alert class="w-full" type="info" show-icon>
            <template #message>
              {{ $t('common.selected', [isCheckRows]) }}
              <a-button type="link" @click="rowSelection.selectedRowKeys = []">{{
                $t('common.cancelChoose')
              }}</a-button>
            </template>
          </Alert>
        </template>
        <template #toolbar>
          <a-button v-if="$auth('/api/SysUser/Add')" type="primary" @click="openMenuModal({})">
            <Icon icon="ant-design:plus-outlined" />
            {{ $t('common.add') }}
          </a-button>
          <a-button type="primary" @click="aoaToExcel"> {{ $t('column.arrayExport') }} </a-button>
          <a-button type="primary" @click="openExportModal">
            {{ $t('column.customExport') }}
          </a-button>
          <a-button
            v-if="$auth('/api/SysUser/Delete')"
            type="danger"
            :disabled="!isCheckRows"
            @click="delRowConfirm(rowSelection.selectedRowKeys)"
          >
            {{ $t('common.delete') }}
          </a-button>
        </template>
      </DynamicTable>
    </template>
  </SplitPanel>
</template>

<script lang="tsx" setup>
  import { ref, computed, reactive } from 'vue'
  import { Avatar, Tag, Tooltip, Modal, Alert, Tree, Spin, Space } from 'ant-design-vue'
  import { ExclamationCircleOutlined, SyncOutlined } from '@ant-design/icons-vue'
  import { useRoute, useRouter } from 'vue-router'
  import { useTable } from '@/components/core/dynamic-table'
  import { useFormModal } from '@/hooks/useModal/useFormModal'
  import { SplitPanel } from '@/components/basic/split-panel'
  import type { FormSchema } from '@/components/core/schema-form/src/types/form'
  import type { TableColumn } from '@/components/core/dynamic-table'
  import { formatToDate, formatToDateTime } from '@/utils/dateUtil'
  import { isPhone, isEmail } from '@/utils/validate'
  import {
    useExportExcelModal,
    jsonToSheetXlsx,
    aoaToSheetXlsx,
    exportExcelForTable,
  } from '@/components/basic/excel'
  import { type TreeDataItem, formatTree } from '@/utils/tree'
  import action from '@/api/sys/user'
  import orgAction from '@/api/sys/org'
  import roleAction from '@/api/sys/role'
  import { exportPageParam } from '@/utils/global'
  import { useI18n } from '@/hooks/useI18n'

  defineOptions({
    name: 'SysUser',
  })

  const [DynamicTable, dynamicTableInstance] = useTable({ formProps: { autoSubmitOnEnter: true } })

  interface State {
    expandedKeys: number[]
    orgId: number
    orgTree: TreeDataItem[]
  }

  const loading = ref(false)
  const { t } = useI18n()

  const [showModal] = useFormModal()
  const route = useRoute()
  const router = useRouter()
  const exportExcelModal = useExportExcelModal()
  let searchParams: any = {}

  const state = reactive<State>({
    expandedKeys: [],
    orgId: 0,
    orgTree: [],
  })

  /**
   * 选中的行数据
   */
  const rowSelection = ref({
    selectedRowKeys: [] as number[],
    onChange: (selectedRowKeys: number[], selectedRows) => {
      console.log(`selectedRowKeys: ${selectedRowKeys}`, 'selectedRows: ', selectedRows)
      rowSelection.value.selectedRowKeys = selectedRowKeys
    },
  })

  /**
   * 是否勾选了表格行
   */
  const isCheckRows = computed(() => rowSelection.value.selectedRowKeys.length)

  /**
   * 数组格式导出
   */
  const aoaToExcel = async () => {
    Object.assign(searchParams, exportPageParam)
    const { list: exportData } = await action.getWithPage(searchParams)
    exportExcelForTable(exportData, columns, `${route.meta.title}${formatToDateTime()}.xlsx`)
  }

  /**
   * 自定义导出格式
   */
  const openExportModal = async () => {
    Object.assign(searchParams, exportPageParam)
    const { list: exportData } = await action.getWithPage(searchParams)
    exportExcelModal.openModal({
      onOk: ({ filename, bookType }) => {
        // 默认Object.keys(data[0])作为header
        jsonToSheetXlsx({
          data: exportData,
          filename,
          write2excelOpts: {
            bookType,
          },
        })
      },
    })
  }

  /**
   * 加载数据
   */
  const loadData = async params => {
    if (params?.createTime) {
      params.createTimeS = formatToDate(params.createTime[0])
      params.createTimeE = formatToDate(params.createTime[1])
      delete params.createTime
    }
    params.orgId = state.orgId
    searchParams = params
    const data = await action.getWithPage(params)
    rowSelection.value.selectedRowKeys = []
    return data
  }

  /**
   * 打开新增/编辑弹窗
   */
  const openMenuModal = async record => {
    const [formRef] = await showModal({
      modalProps: {
        title: `${record.id ? t('common.edit') : t('common.add')}${t('column.user')}`,
        width: '40%',
        onFinish: async values => {
          values.id = record.id
          const params = { ...values }
          // params.IsSuper = params.IsSuper === 1
          await (record.id ? action.update : action.add)(params)
          dynamicTableInstance.reload()
        },
      },
      formProps: {
        labelWidth: 120,
        schemas: formSchemas,
      },
    })

    formRef?.updateSchema([
      {
        field: 'orgId',
        componentProps: {
          treeDefaultExpandedKeys: record?.keyPath || [],
          treeData: state.orgTree,
        },
      },
    ])

    if (record.id) {
      const data = await action.getById(record.id)
      formRef?.setFieldsValue({
        ...data,
        isSuper: data.isSuper ? 1 : 0,
      })
    }
  }

  /**
   * 删除行数据
   */
  const delRowConfirm = async (id: number | number[]) => {
    if (Array.isArray(id)) {
      Modal.confirm({
        title: t('column.confirmDelSelectedData'),
        icon: <ExclamationCircleOutlined />,
        centered: true,
        onOk: async () => {
          await action.delete(id)
          rowSelection.value.selectedRowKeys = []
          dynamicTableInstance.reload()
        },
      })
    } else {
      await action.delete([id])
      dynamicTableInstance.reload()
    }
  }

  /**
   * 获取组织列表
   */
  const fetchOrgList = async () => {
    loading.value = true
    const { list } = await orgAction
      .getWithPage({ pageSize: 999999 })
      .finally(() => (loading.value = false))
    state.orgTree = formatTree(list, 'orgName', -1)
    state.expandedKeys = [...state.expandedKeys, ...state.orgTree.map(n => Number(n.key))]
  }
  fetchOrgList()

  /**
   * 点击组织
   */
  const onTreeSelect = (selectedKeys: number[]) => {
    dynamicTableInstance.getSearchFormRef()?.resetFields()
    state.orgId = selectedKeys?.[0]
    dynamicTableInstance.reload()
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
      title: '头像',
      dataIndex: 'avatar',
      width: 120,
      align: 'center',
      hideInSearch: true,
      customRender: ({ record }) => (
        <Avatar
          size="large"
          src={record.avatar ? `${import.meta.env.VITE_BASE_STATIC_URL}${record.avatar}` : ''}
        />
      ),
    },
    {
      title: '登录账号',
      width: 150,
      align: 'center',
      dataIndex: 'loginAccount',
    },
    {
      title: '真实名称',
      width: 150,
      dataIndex: 'realName',
      align: 'center',
    },
    {
      title: '是否管理员',
      dataIndex: 'isSuper',
      align: 'center',
      width: 150,
      customRender: ({ record }) => {
        return <Tag color={record.isSuper ? 'success' : 'red'}>{record.isSuper ? '是' : '否'}</Tag>
      },
      formItemProps: {
        component: 'Select',
        componentProps: {
          options: [
            {
              label: '是',
              value: 1,
            },
            {
              label: '否',
              value: 0,
            },
          ],
        },
      },
    },
    {
      title: '组织架构',
      dataIndex: 'orgName',
      width: 180,
      align: 'center',
      hideInSearch: true,
    },
    {
      title: '性别',
      dataIndex: 'gender',
      align: 'center',
      width: 55,
      hideInSearch: true,
      customRender: ({ record }) => <Tooltip>{['女', '男'][record.gender]}</Tooltip>,
    },
    {
      title: '创建人',
      dataIndex: 'createUser',
      width: 180,
      align: 'center',
    },
    {
      title: '创建时间',
      align: 'center',
      width: 180,
      dataIndex: 'createTime',
      formItemProps: {
        component: 'RangePicker',
        componentProps: {
          class: 'w-full',
        },
      },
    },
    {
      title: '操作',
      dataIndex: 'ACTION',
      hideInSearch: true,
      align: 'center',
      fixed: 'right',
      width: 200,
      resizable: true,
      actions: ({ record }) => [
        {
          icon: 'ant-design:edit-outlined',
          tooltip: t('common.edit'),
          auth: {
            perm: '/api/SysUser/Update',
            effect: 'disable',
          },
          onClick: () => openMenuModal(record),
        },
        {
          icon: 'ic:outline-lock-reset',
          tooltip: t('column.resetPwd'),
          type: 'dashed',
          auth: {
            perm: '/api/SysUser/ResetPwd',
            effect: 'delete',
          },
          popConfirm: {
            title: '你确定要重置密码嘛?',
            onConfirm: async () => await action.resetPwd(record.id),
          },
        },
        {
          icon: 'ant-design:delete-outlined',
          tooltip: t('common.delete'),
          danger: true,
          auth: {
            perm: '/api/SysUser/Delete',
            effect: 'disable',
          },
          popConfirm: {
            title: t('column.confirmDel'),
            onConfirm: () => delRowConfirm(record.id),
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
      field: 'loginAccount',
      component: 'Input',
      label: '账号',
      rules: [{ required: true, type: 'string' }],
      colProps: {
        span: 12,
      },
    },
    {
      field: 'realName',
      component: 'Input',
      label: '真实名',
      rules: [{ required: true, type: 'string' }],
      colProps: {
        span: 12,
      },
    },
    {
      field: 'isSuper',
      defaultValue: 0,
      component: 'RadioGroup',
      label: '是否管理员',
      componentProps: {
        options: [
          {
            label: '是',
            value: 1,
          },
          {
            label: '否',
            value: 0,
          },
        ],
      },
      colProps: {
        span: 12,
      },
    },
    {
      field: 'gender',
      component: 'Select',
      rules: [{ required: true, type: 'number' }],
      label: '性别',
      colProps: {
        span: 12,
      },
      componentProps: {
        options: [
          {
            label: '男',
            value: 1,
          },
          {
            label: '女',
            value: 0,
          },
        ],
        allowClear: true,
      },
    },
    {
      field: 'phoneNo',
      component: 'Input',
      label: '手机号',
      colProps: {
        span: 12,
      },
      rules: [
        {
          required: false,
          validator: async (_, value) => {
            // if (!value) {
            //   return Promise.reject('值不能为空')
            // }
            if (value && !isPhone(value)) {
              return Promise.reject('请输入正确的手机号!')
            }
            return Promise.resolve()
          },
          trigger: 'change',
        },
      ],
    },
    {
      field: 'email',
      component: 'Input',
      label: '邮箱',
      colProps: {
        span: 12,
      },
      rules: [
        {
          required: false,
          validator: async (_, value) => {
            if (value && !isEmail(value)) {
              return Promise.reject('请输入正确的邮箱!')
            }
            return Promise.resolve()
          },
          trigger: 'change',
        },
      ],
    },
    {
      field: 'sysRoleIds',
      component: 'Select',
      label: '所属角色',
      rules: [{ required: true, type: 'array' }],
      componentProps: {
        mode: 'multiple',
        request: async () => {
          const data = await roleAction.getListByPage({ pageSize: 9999 })
          return data.list.map(x => ({ label: x.roleName, value: x.id }))
        },
        allowClear: true,
      },
    },
    {
      field: 'orgId',
      component: 'TreeSelect',
      label: '组织架构',
      componentProps: {
        fieldNames: {
          label: 'name',
          value: 'id',
        },
        getPopupContainer: () => document.body,
      },
      rules: [{ required: false, type: 'number' }],
    },
    {
      field: 'addr',
      component: 'InputTextArea',
      label: '地址',
    },
    {
      field: 'remark',
      component: 'InputTextArea',
      label: '备注',
    },
  ]
</script>
