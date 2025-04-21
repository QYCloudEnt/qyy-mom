<template>
  <div
    :class="[
      'detail-list',
      size === 'small' ? 'small' : 'large',
      layout === 'vertical' ? 'vertical' : 'horizontal',
    ]"
  >
    <div v-if="title" class="title">{{ title }}</div>
    <a-row>
      <slot />
    </a-row>
  </div>
</template>
<script lang="ts">
  import { defineComponent, h, provide, inject } from 'vue'
  import ACol from 'ant-design-vue/es/grid/Col'
  // eslint-disable-next-line vue/one-component-per-file
  const Item = defineComponent({
    name: 'DetailListItem',
    props: {
      label: {
        type: String,
      },
      content: {
        type: String,
      },
    },
    setup(props, { slots }) {
      const responsive = {
        1: 'ant-col-xs-24',
        2: 'ant-col-xs-24 ant-col-sm-12',
        3: 'ant-col-xs-24 ant-col-sm-12 ant-col-md-8',
        4: 'ant-col-xs-24 ant-col-sm-12 ant-col-md-6',
      }
      const renderLabel = (h, label) => {
        return label
          ? h(
              'div',
              {
                class: 'label',
              },
              [label],
            )
          : null
      }

      const renderContent = (h, content) => {
        return content
          ? h(
              'div',
              {
                class: 'content',
              },
              [content],
            )
          : null
      }
      const col: number = inject('col')!
      const label = renderLabel(h, props?.label)
      const content = renderContent(h, slots?.default?.())
      return () =>
        h(
          ACol,
          {
            class: responsive[col],
          },
          { default: () => [label, content] },
        )
    },
  })

  // eslint-disable-next-line vue/one-component-per-file
  export default defineComponent({
    name: 'DetailList',
    Item,
    props: {
      title: {
        type: String,
        required: false,
      },
      col: {
        type: Number,
        required: false,
        default: 3,
      },
      size: {
        type: String,
        required: false,
        default: 'large',
      },
      layout: {
        type: String,
        required: false,
        default: 'horizontal',
      },
    },
    setup(props) {
      provide('col', props.col > 4 ? 4 : props.col)
    },
  })
</script>

<style lang="less">
  .detail-list {
    .title {
      margin-bottom: 16px;
      font-size: 16px;
      // color: @title-color;
      font-weight: bolder;
    }

    .label {
      display: table-cell;
      margin-right: 8px;
      padding-bottom: 16px;
      // Line-height is 22px IE dom height will calculate error
      line-height: 20px;
      // color: @title-color;
      white-space: nowrap;

      &::after {
        content: ':';
        position: relative;
        top: -0.5px;
        margin: 0 8px 0 2px;
      }
    }

    .content {
      // color: @text-color;
      display: table-cell;
      width: 100%;
      padding-bottom: 16px;
      line-height: 22px;
    }

    &.small {
      .title {
        margin-bottom: 12px;
        font-size: 14px;
        // color: @text-color;
        font-weight: normal;
      }

      .label,
      .content {
        padding-bottom: 8px;
      }
    }

    &.large {
      .label,
      .content {
        padding-bottom: 16px;
      }
    }

    &.vertical {
      .label {
        padding-bottom: 8px;
      }

      .label,
      .content {
        display: block;
      }
    }
  }
</style>
