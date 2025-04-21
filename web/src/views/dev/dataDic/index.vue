<template>
  <SplitPanel>
    <template #left-content>
      <Spin :spinning="listLoading">
        <Affix :offset-top="140">
          <Input.Search
            v-model:value="key"
            style="margin-bottom: 20px"
            placeholder="请输入分类名称"
            @search="getCateList(key)"
          />
        </Affix>
        <list :data-source="categoryList">
          <template #renderItem="{ item }">
            <BadgeRibbon v-if="item.categoryCode === '#'" text="Root" color="blue">
              <List.Item
                class="listItem"
                :class="{ 'item-selected': item.code == selectItemKey }"
                @click="selectItemData(item)"
              >
                <a>{{ item?.name }}</a>
              </List.Item>
            </BadgeRibbon>
            <List.Item
              v-else
              class="listItem"
              :class="{ 'item-selected': item.code == selectItemKey }"
              @click="selectItemData(item)"
            >
              <a>{{ item?.name }}</a>
            </List.Item>
          </template>
        </list>
      </Spin>
    </template>
    <template #right-content>
      <DynamicTable
        ref="dynamicTableRef"
        row-key="id"
        :data-request="loadData"
        :columns="columns"
        :search="state.categoryCode === '#'"
        bordered
        size="small"
      >
        <template #toolbar>
          <a-button :disabled="!state.code" type="primary" @click="openMenuModal({})">
            {{ t('common.add') }}
          </a-button>
        </template>
      </DynamicTable>
    </template>
  </SplitPanel>
</template>
<script lang="tsx" setup>
  import { reactive, ref } from 'vue'
  import { Input, List, Spin, Affix, BadgeRibbon } from 'ant-design-vue'
  import { SplitPanel } from '@/components/basic/split-panel'
  import { DynamicTable } from '@/components/core/dynamic-table'
  import { useFormModal } from '@/hooks/useModal/useFormModal'
  import type { FormSchema } from '@/components/core/schema-form/src/types/form'
  import type { TableColumn } from '@/components/core/dynamic-table'
  import { useI18n } from '@/hooks/useI18n'
  import { baseColumns } from './columns'
  import action from '@/api/dev/dataDic'

  defineOptions({
    name: 'DataDic',
  })

  const { t } = useI18n()
  const dynamicTableRef = ref<InstanceType<typeof DynamicTable>>()

  const [showModal] = useFormModal()
  const key = ref('')
  const listLoading = ref(false)
  const categoryList = ref<Array<State>>([])
  const selectItemKey = ref('')

  interface State {
    id: number
    code: string
    name: string
    isSql: boolean
    isBusiness: boolean
    sqlStr: string
    categoryCode: string
    categoryName: string
  }
  const state = reactive<State>({
    id: 0,
    code: '',
    name: '',
    isSql: false,
    isBusiness: true,
    sqlStr: '',
    categoryCode: '',
    categoryName: '',
  })

  /**
   * 加载数据
   */
  const loadData = async params => {
    if (!state.code) {
      return []
    }
    params.categoryCode = state.code
    const data = await action.getWithPage(params)
    return data
  }

  /**
   * 点击左侧列表
   * @param item
   */
  const selectItemData = async (item: State) => {
    state.id = item.id
    state.code = item.code
    state.name = item.name
    state.isSql = item.isSql
    state.isBusiness = item.isBusiness
    state.sqlStr = item.sqlStr
    state.categoryCode = item.categoryCode
    state.categoryName = item.categoryName
    const actionCol = columns.value.at(-1)!
    columns.value = [...baseColumns, actionCol]
    selectItemKey.value = item.code
    dynamicTableRef?.value?.reload()
  }

  /**
   * 获取所有分类
   * @param key 分类名称
   */
  const getCateList = async (key?: string) => {
    listLoading.value = true
    const data = await action.getCateoryList(key).finally(() => (listLoading.value = false))
    categoryList.value = data
  }
  getCateList()

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
          params.categoryCode = state.code
          params.categoryName = state.name
          await (record.id ? action.update : action.add)(params)
          dynamicTableRef.value?.reload()
          getCateList(key.value)
        },
      },
      formProps: {
        labelWidth: 100,
        layout: 'horizontal',
        schemas: formSchemas,
      },
    })

    if (record.id) {
      const data = await action.getById(record.id)

      formRef?.setFieldsValue({
        ...data,
      })
    } else {
      const len =
        selectItemKey.value === 'BaseCategory'
          ? categoryList.value.length
          : dynamicTableRef.value?.tableData.length || 0
      formRef?.setFieldsValue({
        sortNo: len + 1,
      })
    }
  }

  /**
   * 删除行数据
   */
  const delRowConfirm = async record => {
    await action.delete(record.id)
    dynamicTableRef.value?.reload()
    getCateList(key.value)
  }

  /**
   * 表单信息
   */
  const formSchemas: FormSchema[] = [
    {
      field: 'id',
      component: 'Input',
      label: 'id',
      vIf: false,
    },
    {
      field: 'code',
      component: 'Input',
      label: '编码',
      rules: [{ required: true, type: 'string' }],
      dynamicDisabled: ({ formModel }) => state.categoryCode === '#' && formModel.id,
    },
    {
      field: 'name',
      component: 'Input',
      label: '名称',
      rules: [{ required: true, type: 'string' }],
    },
    {
      field: 'remark',
      component: 'InputTextArea',
      label: '备注',
    },
    {
      field: 'sortNo',
      defaultValue: 0,
      component: 'InputNumber',
      label: '排序',
      rules: [{ required: true }],
    },
  ]

  const columns = ref<TableColumn<any>[]>([
    ...baseColumns,
    {
      title: '操作',
      width: 100,
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
  ])
</script>
<style lang="less" scoped>
  .listItem {
    display: flex;
    justify-content: center;
  }

  .item-selected {
    border-radius: 5px;
    background-color: #13a8a8;

    & a {
      color: aliceblue;
    }
  }
</style>
