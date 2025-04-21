<template>
  <Row class="flex w-full mb-2">
    <Col class="label flex">
      <Tooltip v-if="helpMsg" placement="top" :title="helpMsg">
        <Icon icon="icon-park-outline:help" :size="20" class="help" />
      </Tooltip>
      <TypographyText
        :style="ellipsis ? { width: `${labelWidth}px`, fontSize: '12px' } : {}"
        :ellipsis="ellipsis ? { tooltip: `${label}` } : false"
        :content="`${label} : `"
      />
    </Col>
    <Col class="right text-center">
      <slot />
    </Col>
  </Row>
</template>
<script lang="ts" setup>
  import { ref } from 'vue'
  import { Row, Col, TypographyText, Tooltip } from 'ant-design-vue'

  defineOptions({
    name: 'SettingItem',
  })

  defineProps({
    labelWidth: {
      type: Number,
      default: 80,
    },
    label: {
      type: String,
      default: 'Label',
    },
    helpMsg: {
      type: String,
      default: '',
    },
  })

  const ellipsis = ref(true)
</script>
<style lang="less" scoped>
  .label {
    width: v-bind('labelWidth + "px"');
    margin-top: auto;
    margin-bottom: auto;
    padding-right: 5px;
    text-align: right;

    .help {
      cursor: pointer;
    }
  }

  .right {
    width: calc(100% - v-bind('labelWidth + "px"'));
  }
</style>
