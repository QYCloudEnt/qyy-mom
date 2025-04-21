

# QYCLOUD-MOM

#### 介绍
支持多厂区/多项目级的MOM/MES系统，计划排程、工艺路线设计、在线低代码报表、大屏看板、移动端、AOT客户端......
目标是尽可能打造一款通用的生产制造系统。前端基于最新的vue3、ts、ant design vue, 后端使用.net8、Sqlsugar，支持多种数据库切换、数据隔离与聚合


- 账号：admin，密码：123456

#### 结构
- ./api --前端代码
- ./web --后端代码
  
#### 安装

- 安装依赖

> Node版本: 20

```bash
cd ./web

pnpm i

```

- 运行

```bash
pnpm dev
```

- 打包

```bash
pnpm build

```

- 后端

```bash
按照appsettings.json文件中备注的设置, 配置redis和db后，启动项目并导入菜单数据

```
#### 说明

1. 前端基于vue3-antdv-admin开发!
2. 后端基于.net8、Sqlsugar DDD架构，支持多种数据库
3. 基础代码前后端CRUD+数据库表直接使用代码生成
4. 报表查询在线配置Sql/Api方式查询数据，支持多种数据源: sqlserver、mysql、pgSql等等
5. 移动端操作，主要用于车间操作，如设备点检、保养、报修维修、盘点等
6. 在线模板功能设计，根据不同行业不同需求，设计符合业务需求的操作模板界面
7. 支持多厂区/多项目级，支持数据隔离与聚合报表数据查询，非常适合集团性、多元化企业
8. 可视化工艺流程、工艺文件管理、工单排程
9.  包含多种常用的打印方式: CodeSoft、Txt、FastReport、BarTender，支持自定义打印参数、打印日志、补打等功能
10. 在线开发，支持低代码开发，支持自定义报表、大屏、移动端、在线模板、组件交互等，支持多种数据源: 接口、数据库、WebSocket等

数据大屏集成goview, 详见 [go-view](https://gitee.com/dromara/go-view)

### TODO

- [ √ ] 质量管理
- [ √ ] APP管理
- [ √ ] 数据采集
- [ √ ] 消息管理
- [ √ ] EAM模块