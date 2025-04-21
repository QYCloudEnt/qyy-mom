
<div align=center><img src="./web/src/assets/images/logo.png" width="100"></div>

<div align=center>
   <a href='https://gitcode.com/thgao/tmom'><img src='https://gitcode.com/thgao/tmom/star/badge.svg' alt='star'></img></a>
</div>


# TMom

#### 介绍
支持多厂区/多项目级的MOM/MES系统，计划排程、工艺路线设计、在线低代码报表、大屏看板、移动端、AOT客户端......
目标是尽可能打造一款通用的生产制造系统。前端基于最新的vue3、ts、ant design vue, 后端使用.net8、Sqlsugar，支持多种数据库切换、数据隔离与聚合

- 账号：admin，密码：123456
- [在线预览完整版](https://www.yefeng.club/)
<!-- - [功能说明文档](https://yefeng.club/tmomdoc/) -->
  
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

### 生态伙伴

[![image](./web/src/assets/demo/ccflow.png)](https://ccflow.org/index.html?frm=tmom)

### 系统架构

![image](./web/src/assets/demo/0.png)

### 压测记录

> 测试服务器: Linux centos8 配置: 8核16G, 数据库: Mysql 8

> 测试生成10000个产品SN, 测试表: Product, 字段Sn唯一索引列

> 压测结果: 生成Sn无重复, 插入数据无报错, 接口响应时间正常, 压测过程中服务器CPU、内存、磁盘IO正常

![image](./web/src/assets/demo/locust_3.png)

![image](./web/src/assets/demo/locust_1.png)

![image](./web/src/assets/demo/locust_2.png)

### 交流群

<div align=center>
   <img src="./web/src/assets/demo/tmom group.jpg" width="300">
</div>

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

#### 项目截图

- 工艺流程设计

![image](./web/src/assets/demo/1.png)

- 工单排程
  
![image](./web/src/assets/demo/2.png)

- 信息追溯
  
![image](./web/src/assets/demo/14.png)

- 在线开发

![image](./web/src/assets/demo/13.png)
  
![image](./web/src/assets/demo/3.png)

- 操作日志
  
![image](./web/src/assets/demo/12.png)

- 报表查询
  
![image](./web/src/assets/demo/11.png)

- 终端作业
  
![image](./web/src/assets/demo/6.png)

- 终端作业(客户端)
  
![image](./web/src/assets/demo/6-1.png)

- 编码规则
  
![image](./web/src/assets/demo/7.png)

- 打印模板
  
![image](./web/src/assets/demo/10.png)

- 对象存储
  
<div align=center>
   <img src="./web/src/assets/demo/9.png" width="500">
   <img src="./web/src/assets/demo/8.png" width="500">
</div>

- APP
  
![image](./web/src/assets/demo/5.png)
  
<div align=center>
   <img src="./web/src/assets/demo/app1.png" width="300">
   <img src="./web/src/assets/demo/app2.png" width="300">
</div>

<br />
<br />

<div align=center>
   <img src="./web/src/assets/demo/app3.png" width="300">
   <img src="./web/src/assets/demo/app4.png" width="300">
</div>

### 版权说明

- 本项目仅供研究学习交流使用，未经允许不得进行简单修改包装声称是自己的项目
- 未经开发者授权，本产品及衍生产品不得用于任何形式的商业用途
