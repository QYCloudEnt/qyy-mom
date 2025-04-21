<template>
  <div>
    <DynamicTable
      ref="dynamicTableRef"
      row-key="id"
      :header-title="$t('routes.menu.sys.role')"
      :data-request="action.getListByPage"
      :columns="columns"
      bordered
      size="small"
    >
      <template #toolbar>
        <a-button v-if="$auth('/api/SysRole/Add')" type="primary" @click="openMenuModal({})">
          {{ $t('common.add') }}
        </a-button>
      </template>
    </DynamicTable>
  </div>
</template>

<script lang="ts" setup>
  import { ref } from 'vue'
  import { useRoute, useRouter } from 'vue-router'
  import type { TreeDataItem } from 'ant-design-vue/lib/tree/Tree'
  import { DynamicTable } from '@/components/core/dynamic-table'
  import { useFormModal } from '@/hooks/useModal/useFormModal'
  import type { FormSchema } from '@/components/core/schema-form/src/types/form'
  import { formatDept2Tree, formatMenu2Tree } from '@/utils/tree'
  import type { TableColumn } from '@/components/core/dynamic-table'
  import action from '@/api/sys/role'
  import menuAction from '@/api/sys/menu'
  import { useI18n } from '@/hooks/useI18n'

  defineOptions({
    name: 'SysRole',
  })

  const dynamicTableRef = ref<InstanceType<typeof DynamicTable>>()
  const { t } = useI18n()

  const [showModal] = useFormModal()
  const route = useRoute()
  const router = useRouter()

  const getCheckedKeys = (checkedList: number[], options: TreeDataItem[], total = []) => {
    return options.reduce<number[]>((prev, curr) => {
      if (curr.children?.length) {
        getCheckedKeys(checkedList, curr.children, total)
      } else {
        if (checkedList.includes(curr.value)) {
          prev.push(curr.value)
        }
      }
      return prev
    }, total)
  }

  /**
   * @description 打开新增/编辑弹窗
   */
  const openMenuModal = async record => {
    const [formRef] = await showModal({
      modalProps: {
        title: `${record.id ? t('common.edit') : t('common.add')}${t('column.role')}`,
        width: '50%',
        onFinish: async values => {
          values.id = record.id
          const menusRef = formRef?.compRefMap.get('menuIds')!
          const params = {
            ...values,
            menus: [...menusRef.halfCheckedKeys, ...menusRef.checkedKeys],
          }
          console.log('新增/编辑角色', params)
          await (record.id ? action.update : action.add)(params)
          dynamicTableRef.value?.reload()
        },
      },
      formProps: {
        labelWidth: 100,
        schemas: roleSchemas,
      },
    })

    const menuData = await menuAction.getMenuList()
    const menuTree = formatMenu2Tree(menuData)

    formRef?.updateSchema([
      {
        field: 'menus',
        componentProps: { treeData: menuTree },
      },
    ])
    if (record.id) {
      const data = await action.getById(record.id)
      const menus = await menuAction.getMenuListByRoleId(record.id)
      const menuIds = menus.map(n => n.id)

      formRef?.setFieldsValue({
        ...record,
        roleName: data.roleName,
        description: data.description,
        menus: getCheckedKeys(menuIds, menuTree),
      })
    }
  }

  const delRowConfirm = async record => {
    await action.delete(record.id)
    dynamicTableRef.value?.reload()
  }

  // 表格列
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
      title: '名称',
      width: 200,
      align: 'center',
      dataIndex: 'roleName',
    },
    {
      title: '描述',
      dataIndex: 'description',
      align: 'center',
      hideInSearch: true,
    },
    {
      title: '创建人',
      dataIndex: 'createUser',
      align: 'center',
    },
    {
      title: '创建时间',
      dataIndex: 'createTime',
      align: 'center',
      hideInSearch: true,
    },
    {
      title: '更新时间',
      align: 'center',
      dataIndex: 'updateTime',
      hideInSearch: true,
    },
    {
      title: '操作',
      width: 300,
      dataIndex: 'ACTION',
      hideInSearch: true,
      align: 'center',
      fixed: 'right',
      actions: ({ record }) => [
        {
          label: t('common.edit'),
          onClick: () => openMenuModal(record),
        },
        {
          label: t('common.delete'),
          danger: true,
          popConfirm: {
            title: t('column.confirmDel'),
            onConfirm: () => delRowConfirm(record),
          },
        },
      ],
    },
  ]

  // 表单信息
  const roleSchemas: FormSchema[] = [
    {
      field: 'roleName',
      component: 'Input',
      label: '名称',
      rules: [{ required: true, type: 'string' }],
      colProps: {
        span: 12,
      },
    },
    {
      field: 'description',
      component: 'InputTextArea',
      label: '描述',
    },
    {
      field: 'menus',
      component: 'Tree',
      label: '菜单权限',
      colProps: {
        span: 24,
      },
      componentProps: {
        checkable: true,
        vModelKey: 'checkedKeys',
        style: {
          height: '300px',
          paddingTop: '5px',
          overflow: 'auto',
          borderRadius: '6px',
          border: '1px solid #dcdfe6',
        },
      },
    },
  ]
</script>
