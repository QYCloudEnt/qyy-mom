<template>
  <Spin :spinning="loading">
    <div class="p-2">
      <div>
        <SchemaForm
          v-if="search"
          ref="queryFormRef"
          class="mb-16px pt-24px pr-24px"
          submit-on-reset
          :schemas="schemas"
          :label-width="120"
          @toggle-advanced="e => $emit('toggle-advanced', e)"
          @submit="fetch"
        >
        </SchemaForm>
      </div>
      <div>
        <List
          :grid="{ gutter: 5, xs: 1, sm: 2, md: 4, lg: 4, xl: 6, xxl: grid }"
          :data-source="data"
          :pagination="paginationProp"
        >
          <template #header>
            <div class="flex justify-end space-x-2">
              <slot name="header"></slot>
              <Tooltip v-if="showRowCount">
                <template #title>
                  <div class="w-50">每行显示数量</div>
                  <Slider
                    id="slider"
                    v-bind="sliderProp"
                    v-model:value="grid"
                    @change="sliderChange"
                  />
                </template>
                <Button><TableOutlined /></Button>
              </Tooltip>
              <Tooltip @click="fetch">
                <template #title>{{ $t('common.redo') }}</template>
                <Button><RedoOutlined /></Button>
              </Tooltip>
            </div>
          </template>
          <template #renderItem="{ item }">
            <ListItem class="mt-2">
              <Card>
                <template #title>
                  <div class="flex justify-center">{{ item.name }}</div>
                </template>
                <template #cover>
                  <div :class="height" class="overflow-hidden p-1 h-52">
                    <Image :src="renderImg(item.previewImage)" />
                  </div>
                </template>
                <template #actions>
                  <EditOutlined
                    v-if="$auth('/api/ReportBigScreen/Update') && item.status != 1"
                    @click="handleEdit(item.id)"
                  />
                  <EditOutlined v-else class="editBtn" />
                  <Dropdown
                    :trigger="['hover']"
                    :drop-menu-list="[
                      {
                        text: $t('common.open'),
                        event: '1',
                        icon: 'icon-duqushujuku',
                        onClick: handlePreview.bind(null, item.id),
                      },
                      {
                        text: $t('common.copy'),
                        event: '2',
                        icon: 'icon-fuzhi',
                        disabled: !$auth('/api/ReportBigScreen/Copy'),
                        popConfirm: {
                          title: '是否确认克隆',
                          confirm: handleCopy.bind(null, item.id),
                        },
                      },
                      {
                        text: $t('common.rename'),
                        event: '3',
                        icon: 'icon-rizhi',
                        disabled: !$auth('/api/ReportBigScreen/ChangeName'),
                        divider: true,
                        onClick: handleChangeName.bind(null, item),
                      },
                      {
                        text: $t('common.publish'),
                        event: '4',
                        icon: 'icon-tuisong',
                        disabled: !$auth('/api/ReportBigScreen/Publish'),
                        vIf: item.status == 0,
                        popConfirm: {
                          title: '是否确认发布',
                          confirm: handlePublish.bind(null, item.id),
                        },
                      },
                      {
                        text: $t('common.cancelPublish'),
                        event: '5',
                        icon: 'jieruguanli',
                        disabled: !$auth('/api/ReportBigScreen/CancelPublish'),
                        vIf: item.status == 1,
                        popConfirm: {
                          title: '是否确认取消发布',
                          confirm: handleCancelPublish.bind(null, item.id),
                        },
                      },
                      {
                        text: $t('common.delete'),
                        event: '6',
                        disabled: !$auth('/api/ReportBigScreen/Delete'),
                        icon: 'icon-shanchu',
                        popConfirm: {
                          title: '是否确认删除',
                          confirm: handleDelete.bind(null, item.id),
                        },
                      },
                    ]"
                    popconfirm
                  >
                    <!-- <EllipsisOutlined /> -->
                    <Icon icon="ant-design:product-outlined" />
                  </Dropdown>
                </template>

                <CardMeta>
                  <template #title>
                    <div class="flex justify-between">
                      <Badge
                        :status="item.status ? 'success' : 'warning'"
                        :text="item.status ? $t('common.published') : $t('common.unPublished')"
                      />
                      <Tag color="cyan">
                        {{
                          item.updateId
                            ? `${item.updateUser} ${item.updateTime}`
                            : `${item.createUser} ${item.createTime}`
                        }}
                      </Tag>
                      <!-- <TypographyText
                        :content="item.updateId ? `${item.updateTime}` : `${item.createTime}`"
                      /> -->
                    </div>
                  </template>
                  <!-- <template #avatar>
                  <Avatar :src="renderImg(item.previewImage)" />
                </template>
                <template #description>{{ item.content }}</template> -->
                </CardMeta>
              </Card>
            </ListItem>
          </template>
        </List>
      </div>
    </div>
  </Spin>
</template>
<script lang="ts" setup>
  import { computed, onMounted, ref } from 'vue'
  import { SchemaForm, schemaFormProps } from '@/components/core/schema-form'
  import {
    EditOutlined,
    EllipsisOutlined,
    RedoOutlined,
    TableOutlined,
  } from '@ant-design/icons-vue'
  import {
    List,
    Card,
    Image,
    Typography,
    Tooltip,
    Slider,
    Avatar,
    Tag,
    Spin,
    Badge,
  } from 'ant-design-vue'
  import { Dropdown } from '@/components/basic/Dropdown'
  import { Button } from '@/components/basic/button'
  import { isFunction } from '@/utils/is'
  import { renderImg } from '@/utils/common'
  import { useSlider, grid } from './data'

  const ListItem = List.Item
  const CardMeta = Card.Meta
  const TypographyText = Typography.Text
  const loading = ref(false)
  // 获取slider属性
  const sliderProp = computed(() => useSlider(4))

  // 组件接收参数
  const props = defineProps({
    ...schemaFormProps,
    // 请求API的参数
    params: {
      type: Object,
      default: () => ({}),
    },
    //api
    api: {
      type: Function as PropType<(params: any) => Promise<any>>,
      default: null,
    },
    search: {
      type: Boolean,
      default: true,
    },
    /**显示更改每行数据按钮 */
    showRowCount: {
      type: Boolean,
      default: false,
    },
  })

  //暴露内部方法
  const emit = defineEmits([
    'getMethod',
    'delete',
    'edit',
    'changeName',
    'publish',
    'cancelPublish',
    'preview',
    'copy',
    'toggle-advanced',
  ])

  //数据
  const data = ref([])

  // 切换每行个数
  // cover图片自适应高度
  //修改pageSize并重新请求数据

  const height = computed(() => {
    return `h-${120 - grid.value * 6}`
  })

  //表单
  // const [registerForm, { validate }] = useForm({
  //   schemas: [{ field: 'type', component: 'Input', label: '类型' }],
  //   labelWidth: 80,
  //   baseColProps: { span: 6 },
  //   actionColOptions: { span: 24 },
  //   autoSubmitOnEnter: true,
  //   submitFunc: handleSubmit
  // })
  // //表单提交
  // async function handleSubmit() {
  //   const data = await validate()
  //   await fetch(data)
  // }
  function sliderChange(n) {
    pageSize.value = n * 4
    fetch()
  }

  // 自动请求并暴露内部方法
  onMounted(() => {
    fetch()
    emit('getMethod', fetch)
  })

  /**
   * 查询
   * @param p 参数
   */
  async function fetch(p: any = {}) {
    loading.value = true
    // delete p?.HeaderUniqForm
    const { api, params } = props
    if (api && isFunction(api)) {
      const { list, pagination } = await api({
        ...params,
        pageIndex: page.value,
        pageSize: pageSize.value,
        ...p,
      }).finally(() => (loading.value = false))
      data.value = list
      total.value = pagination?.total ?? 0
    } else {
      loading.value = false
    }
  }
  //分页相关
  const page = ref(1)
  const pageSize = ref(8)
  const total = ref(0)
  const paginationProp = ref({
    showSizeChanger: false,
    showQuickJumper: true,
    pageSize,
    current: page,
    total,
    showTotal: total => `共 ${total} 条数据, 每页 ${pageSize.value} 条`,
    onChange: pageChange,
    onShowSizeChange: pageSizeChange,
  })

  function pageChange(p, pz) {
    page.value = p
    pageSize.value = pz
    fetch()
  }

  function pageSizeChange(current, size) {
    console.log(current)
    pageSize.value = size
    fetch()
  }

  async function handleDelete(id) {
    emit('delete', id)
  }

  async function handleEdit(id) {
    emit('edit', id)
  }

  async function handleChangeName(item) {
    emit('changeName', item)
  }

  async function handlePublish(id) {
    emit('publish', id)
  }

  async function handleCancelPublish(id) {
    emit('cancelPublish', id)
  }

  async function handleCopy(id) {
    emit('copy', id)
  }

  async function handlePreview(id) {
    emit('preview', id)
  }
</script>

<style lang="less" scoped>
  .ant-image {
    display: flex !important;
    justify-content: center !important;
  }

  .editBtn {
    color: #666 !important;
    cursor: not-allowed;
  }
</style>
