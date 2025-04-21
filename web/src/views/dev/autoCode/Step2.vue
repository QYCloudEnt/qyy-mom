<template>
  <div>
    <Form style="max-width: 350px; margin: 40px auto 0" v-bind="layout">
      <FormItem class="stepFormText" label="文件夹名称">{{ form.fileName }}</FormItem>
      <!-- <FormItem label="数据库名称" class="stepFormText">
        {{ form.connID || '主库' }}
      </FormItem> -->
      <FormItem label="生成Vue页面" class="stepFormText">
        {{ form.createVue ? '是' : '否' }}
      </FormItem>
      <FormItem v-if="form.createVue" label="页面模板" class="stepFormText">
        {{ vueTemp }}
      </FormItem>
      <FormItem v-if="form.createVue" label="菜单名称" class="stepFormText">
        {{ form.menuName }}
      </FormItem>
      <FormItem v-if="form.createVue" label="上级菜单" class="stepFormText">
        {{ parentName }}
      </FormItem>
      <FormItem v-if="form.createVue" label="菜单图标" class="stepFormText">
        {{ form.icon }}
      </FormItem>
      <FormItem label="实体类名称" class="stepFormText">
        {{ form.tableNames }}
      </FormItem>
      <FormItem :wrapper-col="{ span: 17, offset: 7 }">
        <Button @click="prevStep">{{ $t('routes.dev.prevStep') }}</Button>
        <Button type="primary" style="margin-left: 8px" @click="nextStep">
          {{ $t('routes.dev.submit') }}
        </Button>
      </FormItem>
    </Form>
  </div>
</template>

<script lang="ts">
  import { defineComponent, computed } from 'vue'
  import { Form, Button } from 'ant-design-vue'
  export default defineComponent({
    name: 'Step2',
    components: {
      // eslint-disable-next-line vue/no-reserved-component-names
      Form,
      FormItem: Form.Item,
      // eslint-disable-next-line vue/no-reserved-component-names
      Button,
    },
    props: {
      form: {
        type: Object,
        default: () => ({
          fileName: '',
          connID: '',
          createVue: 0,
          vueTemplate: '',
          menuName: '',
          parentId: 0,
          parentName: '',
          icon: '',
          tableNames: '',
        }),
      },
      vueTempArr: {
        type: Array as unknown as Array<any>,
        require: true,
        default: () => [],
      },
      parentName: String,
    },
    emits: ['nextStep', 'prevStep'],
    setup(props, { emit }) {
      const layout = {
        labelCol: { span: 7 },
        wrapperCol: { span: 17 },
      }
      const vueTemp = computed(
        () => props.vueTempArr.filter(x => x.value == props.form.vueTemplate)[0]?.label,
      )
      const nextStep = () => {
        emit('nextStep', props.form)
      }
      const prevStep = () => emit('prevStep', props.form, props.parentName)
      return {
        layout,
        vueTemp,
        nextStep,
        prevStep,
      }
    },
  })
</script>

<style lang="less" scoped>
  .stepFormText {
    margin-bottom: 24px;
  }
</style>
