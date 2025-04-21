<template>
  <div>
    <Card>
      <Card.Meta title="关于">
        <template #description>
          <BlankLink
            :url="pkg.author.url"
            :text="pkg.name"
          />是一个高效的低代码报表开发平台，旨在能够让使用者告别繁琐的图表开发，更便捷的完成一份精美的数据报表。不仅仅支持常用的关系型数据库，如
          Mysql、Sqlserver、Oracle、PgSql等，还支持诸如TDengine、QuestDb等之类的时序数据库。
          并且还兼容了上万种Echart图表组件，自由程度任你选择。高效、方便、快捷。
        </template>
      </Card.Meta>
    </Card>
    <Card class="mt-3">
      <Descriptions title="项目信息" :column="2" bordered>
        <Descriptions.Item label="版本">
          <Tag color="processing">{{ pkg.version }}</Tag>
        </Descriptions.Item>
        <Descriptions.Item label="最后编译时间">
          <Tag color="processing">{{ lastBuildTime }}</Tag>
        </Descriptions.Item>
        <!-- <Descriptions.Item label="GitHub">
          <BlankLink :url="pkg.repository.url" text="GitHub" />
        </Descriptions.Item>
        <Descriptions.Item label="预览地址">
          <BlankLink :url="pkg.homepage" text="预览地址" />
        </Descriptions.Item> -->
      </Descriptions>
    </Card>
    <Card class="mt-3">
      <Descriptions title="生产环境依赖" bordered>
        <template v-for="(value, key) in pkg.dependencies" :key="key">
          <Descriptions.Item :label="key">
            <BlankLink :url="key" :text="value" />
          </Descriptions.Item>
        </template>
      </Descriptions>
    </Card>
    <Card class="mt-3">
      <Descriptions title="开发环境依赖" bordered>
        <template v-for="(value, key) in pkg.devDependencies" :key="key">
          <Descriptions.Item :label="key">
            <BlankLink :url="key" :text="value" />
          </Descriptions.Item>
        </template>
      </Descriptions>
    </Card>
  </div>
</template>

<script setup lang="tsx">
  import { Descriptions, Card, Tag } from 'ant-design-vue'
  const { pkg, lastBuildTime } = __APP_INFO__

  const BlankLink = ({ url = '', text }) => (
    <a href={url.replace('git+', '')} target="_blank">
      {text}
    </a>
  )
</script>
