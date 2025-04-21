/*
 Navicat Premium Data Transfer

 Source Server         : MES
 Source Server Type    : SQL Server
 Source Server Version : 13004001 (13.00.4001)
 Source Host           : 10.108.106.11:1433
 Source Catalog        : BOND_DEV
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 13004001 (13.00.4001)
 File Encoding         : 65001

 Date: 07/03/2025 11:32:07
*/


-- ----------------------------
-- Table structure for sys_menu
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[sys_menu]') AND type IN ('U'))
	DROP TABLE [dbo].[sys_menu]
GO

CREATE TABLE [dbo].[sys_menu] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [MenuName] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [ParentId] int  NULL,
  [Icon] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [Type] int DEFAULT '0' NOT NULL,
  [LinkUrl] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [ViewPath] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [IsKeepAlive] bit DEFAULT '0' NOT NULL,
  [IsShow] bit DEFAULT '1' NOT NULL,
  [IsExternal] bit DEFAULT '0' NOT NULL,
  [IsEmbed] bit DEFAULT '0' NOT NULL,
  [Redirect] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [OrderSort] int DEFAULT '1' NOT NULL,
  [CreateId] int  NOT NULL,
  [CreateTime] datetime  NOT NULL,
  [UpdateId] int  NULL,
  [UpdateTime] datetime  NULL,
  [IsDeleted] bit DEFAULT '0' NOT NULL
)
GO

ALTER TABLE [dbo].[sys_menu] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'菜单名称',
'SCHEMA', N'dbo',
'TABLE', N'sys_menu',
'COLUMN', N'MenuName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'父菜单Id',
'SCHEMA', N'dbo',
'TABLE', N'sys_menu',
'COLUMN', N'ParentId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'菜单图标',
'SCHEMA', N'dbo',
'TABLE', N'sys_menu',
'COLUMN', N'Icon'
GO

EXEC sp_addextendedproperty
'MS_Description', N'类型, 0:目录  1:页面  2:按钮',
'SCHEMA', N'dbo',
'TABLE', N'sys_menu',
'COLUMN', N'Type'
GO

EXEC sp_addextendedproperty
'MS_Description', N'菜单Url(路由router)',
'SCHEMA', N'dbo',
'TABLE', N'sys_menu',
'COLUMN', N'LinkUrl'
GO

EXEC sp_addextendedproperty
'MS_Description', N'前端页面存放路径',
'SCHEMA', N'dbo',
'TABLE', N'sys_menu',
'COLUMN', N'ViewPath'
GO

EXEC sp_addextendedproperty
'MS_Description', N'是否缓存页面 0:不缓存, 1:缓存',
'SCHEMA', N'dbo',
'TABLE', N'sys_menu',
'COLUMN', N'IsKeepAlive'
GO

EXEC sp_addextendedproperty
'MS_Description', N'是否显示',
'SCHEMA', N'dbo',
'TABLE', N'sys_menu',
'COLUMN', N'IsShow'
GO

EXEC sp_addextendedproperty
'MS_Description', N'是否外链',
'SCHEMA', N'dbo',
'TABLE', N'sys_menu',
'COLUMN', N'IsExternal'
GO

EXEC sp_addextendedproperty
'MS_Description', N'是否内嵌',
'SCHEMA', N'dbo',
'TABLE', N'sys_menu',
'COLUMN', N'IsEmbed'
GO

EXEC sp_addextendedproperty
'MS_Description', N'排序',
'SCHEMA', N'dbo',
'TABLE', N'sys_menu',
'COLUMN', N'OrderSort'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人',
'SCHEMA', N'dbo',
'TABLE', N'sys_menu',
'COLUMN', N'CreateId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'sys_menu',
'COLUMN', N'CreateTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改人',
'SCHEMA', N'dbo',
'TABLE', N'sys_menu',
'COLUMN', N'UpdateId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改时间',
'SCHEMA', N'dbo',
'TABLE', N'sys_menu',
'COLUMN', N'UpdateTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'是否删除 0:未删除  1:已删除',
'SCHEMA', N'dbo',
'TABLE', N'sys_menu',
'COLUMN', N'IsDeleted'
GO

EXEC sp_addextendedproperty
'MS_Description', N'系统菜单表',
'SCHEMA', N'dbo',
'TABLE', N'sys_menu'
GO


-- ----------------------------
-- Records of sys_menu
-- ----------------------------
SET IDENTITY_INSERT [dbo].[sys_menu] ON
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1', N'系统管理', NULL, N'ant-design:setting-outlined', N'0', N'/sys', NULL, N'0', N'1', N'0', N'0', NULL, N'100', N'1', N'2023-04-26 00:00:00.000', N'1', N'2024-02-24 21:02:16.000', N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'2', N'用户管理', N'1', N'ant-design:user-outlined', N'1', N'/sys/user', N'sys/user/index', N'1', N'1', N'0', N'0', NULL, N'1', N'1', N'2023-02-08 16:14:00.000', N'1', N'2024-02-24 21:02:40.000', N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'3', N'角色管理', N'1', N'ant-design:user-switch-outlined', N'1', N'/sys/role', N'sys/role/index', N'1', N'1', N'0', N'0', NULL, N'2', N'1', N'2023-02-08 16:14:00.000', N'1', N'2024-02-24 21:05:28.000', N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'4', N'菜单管理', N'1', N'ant-design:menu-unfold-outlined', N'1', N'/sys/menu', N'sys/menu/index', N'1', N'1', N'0', N'0', NULL, N'3', N'1', N'2023-02-08 16:14:00.000', N'1', N'2024-02-24 21:06:03.000', N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'5', N'组织架构', N'1', N'ant-design:apartment-outlined', N'1', N'/sys/org', N'sys/org/index', N'0', N'1', N'0', N'0', NULL, N'5', N'1', N'2023-02-08 16:14:00.000', N'1', N'2024-02-24 21:07:30.000', N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'6', N'系统日志', N'1', N'ant-design:file-done-outlined', N'1', N'/sys/log', N'sys/log/index', N'0', N'1', N'0', N'0', NULL, N'6', N'1', N'2023-02-08 16:14:00.000', N'1', N'2025-02-10 14:58:21.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'7', N'开发配置', NULL, N'ant-design:experiment-outlined', N'0', N'/dev', NULL, N'0', N'1', N'0', N'0', NULL, N'98', N'1', N'2023-02-08 16:14:00.000', N'1', N'2024-02-24 20:55:57.000', N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'8', N'代码生成', N'7', N'ant-design:dot-net-outlined', N'1', N'/dev/autoCode', N'dev/autoCode/index', N'1', N'1', N'0', N'0', NULL, N'1', N'1', N'2023-02-08 16:14:00.000', N'1', N'2024-02-24 20:57:42.000', N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'9', N'数据字典', N'7', N'ant-design:reconciliation-outlined', N'1', N'/dev/dataDic', N'dev/dataDic/index', N'0', N'1', N'0', N'0', NULL, N'2', N'1', N'2023-02-08 16:14:00.000', N'1', N'2024-02-24 20:59:23.000', N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'10', N'详情', N'2', N'', N'1', N'/sys/user/detail/:id', N'sys/user/detail', N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', N'1', N'2024-04-15 09:37:26.000', N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'11', N'查询', N'2', NULL, N'2', N'/api/SysUser/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'12', N'新增', N'2', NULL, N'2', N'/api/SysUser/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'13', N'编辑', N'2', NULL, N'2', N'/api/SysUser/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'14', N'删除', N'2', NULL, N'2', N'/api/SysUser/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'15', N'查询', N'3', NULL, N'2', N'/api/SysRole/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'16', N'新增', N'3', NULL, N'2', N'/api/SysRole/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'17', N'编辑', N'3', NULL, N'2', N'/api/SysRole/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'18', N'删除', N'3', NULL, N'2', N'/api/SysRole/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'19', N'查询', N'4', NULL, N'2', N'/api/SysMenu/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'20', N'新增', N'4', NULL, N'2', N'/api/SysMenu/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'21', N'编辑', N'4', NULL, N'2', N'/api/SysMenu/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'22', N'删除', N'4', NULL, N'2', N'/api/SysMenu/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'23', N'查询', N'5', NULL, N'2', N'/api/SysOrg/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'24', N'新增', N'5', NULL, N'2', N'/api/SysOrg/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'25', N'编辑', N'5', NULL, N'2', N'/api/SysOrg/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'26', N'删除', N'5', NULL, N'2', N'/api/SysOrg/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'27', N'查询', N'9', NULL, N'2', N'/api/DataDic/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'28', N'新增', N'9', NULL, N'2', N'/api/DataDic/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'29', N'编辑', N'9', NULL, N'2', N'/api/DataDic/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'30', N'删除', N'9', NULL, N'2', N'/api/DataDic/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'31', N'工厂管理', N'1', N'ant-design:partition-outlined', N'1', N'/sys/factory', N'sys/factory/index', N'0', N'1', N'0', N'0', NULL, N'4', N'1', N'2023-02-08 16:14:00.000', N'1', N'2024-02-24 21:07:22.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'32', N'查询', N'31', NULL, N'2', N'/api/SysFactory/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'33', N'新增', N'31', NULL, N'2', N'/api/SysFactory/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'34', N'编辑', N'31', NULL, N'2', N'/api/SysFactory/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'35', N'删除', N'31', NULL, N'2', N'/api/SysFactory/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'36', N'系统集成', NULL, N'ant-design:cloud-server-outlined', N'0', N'/si', NULL, N'0', N'1', N'0', N'0', NULL, N'99', N'1', N'2023-02-08 16:14:00.000', N'1', N'2025-02-10 14:57:22.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'37', N'定时任务', N'36', N'ep:stopwatch', N'1', N'/watch/job', N'watch/job/index', N'1', N'1', N'0', N'0', NULL, N'6', N'1', N'2023-02-08 16:14:00.000', N'1', N'2025-02-10 14:57:23.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'38', N'报表开发', NULL, N'ant-design:bar-chart-outlined', N'0', N'/report', NULL, N'0', N'1', N'0', N'0', NULL, N'97', N'1', N'2023-02-08 16:14:00.000', N'1', N'2025-02-10 14:56:51.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'39', N'数据源配置', N'38', N'ep:coin', N'1', N'/report/dB', N'report/dB/index', N'1', N'1', N'0', N'0', NULL, N'1', N'1', N'2023-02-08 16:14:00.000', N'1', N'2025-02-10 14:56:51.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'40', N'报表配置', N'38', N'ant-design:insert-row-above-outlined', N'1', N'/report/config', N'report/config/index', N'1', N'1', N'0', N'0', NULL, N'2', N'1', N'2023-02-08 16:14:00.000', N'1', N'2025-02-10 14:56:51.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'41', N'报表查询', N'38', N'ant-design:fund-outlined', N'1', N'/report/query', N'report/query/index', N'1', N'1', N'0', N'0', NULL, N'3', N'1', N'2023-02-08 16:14:00.000', N'1', N'2025-02-10 14:56:51.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'42', N'报表查询', N'41', N'icon-wenjiansousuo', N'1', N'/report/query/detail/:id', N'report/query/detail', N'1', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', N'1', N'2024-04-15 09:36:37.000', N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'43', N'查询', N'39', NULL, N'2', N'/api/ReportDB/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'44', N'新增', N'39', NULL, N'2', N'/api/ReportDB/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'45', N'编辑', N'39', NULL, N'2', N'/api/ReportDB/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'46', N'删除', N'39', NULL, N'2', N'/api/ReportDB/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'47', N'查询', N'40', NULL, N'2', N'/api/ReportConfig/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'48', N'新增', N'40', NULL, N'2', N'/api/ReportConfig/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'49', N'编辑', N'40', NULL, N'2', N'/api/ReportConfig/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'50', N'删除', N'40', NULL, N'2', N'/api/ReportConfig/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'51', N'查询', N'37', NULL, N'2', N'/api/SysJob/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'52', N'新增', N'37', NULL, N'2', N'/api/SysJob/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'53', N'编辑', N'37', NULL, N'2', N'/api/SysJob/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'54', N'删除', N'37', NULL, N'2', N'/api/SysJob/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'55', N'立即执行', N'37', NULL, N'2', N'/api/SysJob/ExecuteJobImmediate', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'56', N'暂停', N'37', NULL, N'2', N'/api/SysJob/PauseJob', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'57', N'恢复', N'37', NULL, N'2', N'/api/SysJob/ResumeJob', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'58', N'开启所有任务', N'37', NULL, N'2', N'/api/SysJob/StartAllJob', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'59', N'停止所有任务', N'37', NULL, N'2', N'/api/SysJob/StopAllJob', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'60', N'数据大屏', N'38', N'ant-design:fund-projection-screen-outlined', N'1', N'/report/bigScreen', N'report/bigScreen/index', N'0', N'1', N'0', N'0', NULL, N'4', N'1', N'2023-02-08 16:14:00.000', N'1', N'2025-02-10 14:56:51.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'61', N'查询', N'60', NULL, N'2', N'/api/ReportBigScreen/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'62', N'新增', N'60', NULL, N'2', N'/api/ReportBigScreen/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'63', N'编辑', N'60', NULL, N'2', N'/api/ReportBigScreen/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'64', N'删除', N'60', NULL, N'2', N'/api/ReportBigScreen/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'65', N'克隆', N'60', NULL, N'2', N'/api/ReportBigScreen/Copy', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'66', N'重命名', N'60', NULL, N'2', N'/api/ReportBigScreen/ChangeName', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'67', N'发布', N'60', NULL, N'2', N'/api/ReportBigScreen/Publish', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'68', N'取消发布', N'60', NULL, N'2', N'/api/ReportBigScreen/CancelPublish', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'69', N'首页', NULL, N'zaixianyonghujiankong', N'1', N'/iframe/dashboard/welcome1', N'/#/report/query/5', N'1', N'0', N'1', N'1', NULL, N'0', N'1', N'2023-05-06 16:12:27.000', N'1', N'2024-02-24 20:43:05.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'70', N'DbMigration', N'7', N'ant-design:delivered-procedure-outlined', N'1', N'/dev/dbMigration', N'dev/dbMigration/index', N'1', N'1', N'0', N'0', NULL, N'0', N'1', N'2023-05-17 10:05:12.000', N'1', N'2024-02-24 20:56:52.000', N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'71', N'数据迁移', N'70', NULL, N'2', N'/api/CodeFirst/DbMigration', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-05-17 10:13:20.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'72', N'基础数据', NULL, N'ant-design:hdd-outlined', N'0', N'/base', NULL, N'0', N'1', N'0', N'0', NULL, N'1', N'1', N'2023-05-19 15:59:41.000', N'1', N'2024-02-23 21:44:17.000', N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'73', N'编码规则', N'7', N'ant-design:qrcode-outlined', N'1', N'/dev/sequence', N'dev/sequence/index', N'0', N'1', N'0', N'0', NULL, N'3', N'1', N'2023-05-19 16:01:29.000', N'1', N'2025-02-10 14:57:01.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'74', N'查询', N'73', NULL, N'2', N'/api/Sequence/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-05-19 16:01:29.000', N'1', N'2025-02-10 14:57:01.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'75', N'新增', N'73', NULL, N'2', N'/api/Sequence/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-05-19 16:01:29.000', N'1', N'2025-02-10 14:57:01.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'76', N'编辑', N'73', NULL, N'2', N'/api/Sequence/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-05-19 16:01:29.000', N'1', N'2025-02-10 14:57:01.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'77', N'删除', N'73', NULL, N'2', N'/api/Sequence/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-05-19 16:01:29.000', N'1', N'2025-02-10 14:57:01.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'78', N'详情-新增', N'73', NULL, N'2', N'/api/SequenceDetail/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-05-23 14:06:45.000', N'1', N'2025-02-10 14:57:01.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'79', N'详情-删除', N'73', NULL, N'2', N'/api/SequenceDetail/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-05-23 14:07:09.000', N'1', N'2025-02-10 14:57:01.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'80', N'详情-编辑', N'73', NULL, N'2', N'/api/SequenceDetail/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-05-23 14:08:03.000', N'1', N'2025-02-10 14:57:01.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'81', N'详情-查询', N'73', NULL, N'2', N'/api/SequenceDetail/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-05-23 14:08:41.000', N'1', N'2025-02-10 14:57:01.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'82', N'对象存储', N'36', N'ep:files', N'1', N'/dev/file', N'dev/file/index', N'1', N'1', N'0', N'0', NULL, N'7', N'1', N'2023-07-21 14:58:04.000', N'1', N'2025-02-10 14:57:23.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'83', N'新增模板', N'60', NULL, N'2', N'/api/ReportBigScreenTemplate/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-08-10 15:51:49.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'84', N'模板编辑', N'60', NULL, N'2', N'/api/ReportBigScreenTemplate/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-08-22 22:50:37.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'85', N'模板删除', N'60', NULL, N'2', N'/api/ReportBigScreenTemplate/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-08-22 22:50:51.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'86', N'删除文件或文件夹', N'82', NULL, N'2', N'/api/File/DelFileOrDir', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-09-04 17:11:39.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'87', N'上传文件', N'82', NULL, N'2', N'/api/File/Upload', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-09-11 14:35:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'88', N'重置密码', N'2', NULL, N'2', N'/api/SysUser/ResetPwd', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2023-09-13 19:36:15.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'89', N'开发文档', NULL, N'ep:document', N'1', N'/iframe/doc', N'https://www.yefeng.club/treportdoc/backend/introduce.html', N'0', N'1', N'1', N'0', NULL, N'101', N'1', N'2024-01-05 13:32:19.000', N'1', N'2024-06-29 08:28:55.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'90', N'测试', N'89', NULL, N'2', N'/api/File/RenameFile', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-01-11 10:43:49.000', N'1', N'2024-01-11 10:44:47.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'91', N'测试API', N'89', NULL, N'2', N'/api/Login/ChangeFactory', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-01-11 10:44:31.000', N'1', N'2024-01-11 10:44:52.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'92', N'在线开发', NULL, N'ep:magic-stick', N'1', N'/dev/template', N'dev/template/index', N'1', N'1', N'0', N'0', NULL, N'96', N'1', N'2024-03-04 21:37:29.000', N'1', N'2025-02-10 14:56:48.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'93', N'查询', N'92', NULL, N'2', N'/api/Template/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-03-04 21:42:05.000', N'1', N'2025-02-10 14:56:48.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'94', N'新增', N'92', NULL, N'2', N'/api/Template/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-03-04 21:42:35.000', N'1', N'2025-02-10 14:56:48.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'95', N'编辑', N'92', NULL, N'2', N'/api/Template/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-03-04 21:42:51.000', N'1', N'2025-02-10 14:56:48.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'96', N'删除', N'92', NULL, N'2', N'/api/Template/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-03-04 21:43:11.000', N'1', N'2025-02-10 14:56:48.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'97', N'模板编辑', N'92', N'ant-design:container-twotone', N'1', N'/dev/template/edit/:layout/:id', N'dev/template/edit/index', N'1', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-03-06 21:02:10.000', N'1', N'2025-02-10 14:56:48.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'98', N'模板预览', N'92', N'ant-design:fund-view-outlined', N'1', N'/dev/template/preview/:layout/:id', N'dev/template/preview/index', N'1', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-03-08 13:38:38.000', N'1', N'2025-02-10 14:56:48.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'99', N'生产管理', NULL, N'ant-design:sisternode-outlined', N'0', N'/product', NULL, N'0', N'1', N'0', N'0', NULL, N'3', N'1', N'2024-03-19 16:55:05.000', N'1', N'2024-05-10 11:34:29.000', N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'101', N'工艺路线', N'99', N'ant-design:api-twotone', N'1', N'/product/processRoute', N'views/product/processRoute', N'1', N'1', N'0', N'0', NULL, N'1', N'1', N'2024-03-19 21:41:21.000', NULL, NULL, N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'102', N'工艺路线', N'128', N'ant-design:node-index-outlined', N'1', N'/process/route', N'process/route/index', N'1', N'1', N'0', N'0', NULL, N'2', N'1', N'2024-03-19 21:58:40.000', N'1', N'2024-04-03 00:06:18.000', N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'103', N'查询', N'102', NULL, N'2', N'/api/ProcessRoute/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-03-19 21:58:40.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'104', N'新增', N'102', NULL, N'2', N'/api/ProcessRoute/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-03-19 21:58:40.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'105', N'编辑', N'102', NULL, N'2', N'/api/ProcessRoute/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-03-19 21:58:40.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'106', N'删除', N'102', NULL, N'2', N'/api/ProcessRoute/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-03-19 21:58:40.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'107', N'工厂建模', N'72', N'ant-design:sliders-outlined', N'0', N'/modeling', NULL, N'0', N'1', N'0', N'0', NULL, N'0', N'1', N'2024-03-27 10:32:26.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'108', N'车间管理', N'107', N'ant-design:gateway-outlined', N'1', N'/modeling/workshop', N'/modeling/workshop/index', N'1', N'1', N'0', N'0', NULL, N'1', N'1', N'2024-03-27 10:40:28.000', N'1', N'2024-03-27 21:30:50.000', N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'109', N'查询', N'108', NULL, N'2', N'/api/Workshop/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-03-27 10:40:28.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'110', N'新增', N'108', NULL, N'2', N'/api/Workshop/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-03-27 10:40:28.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'111', N'编辑', N'108', NULL, N'2', N'/api/Workshop/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-03-27 10:40:28.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'112', N'删除', N'108', NULL, N'2', N'/api/Workshop/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-03-27 10:40:28.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'113', N'产线管理', N'107', N'ant-design:line-outlined', N'1', N'/modeling/line', N'/modeling/line/index', N'1', N'1', N'0', N'0', NULL, N'2', N'1', N'2024-03-27 11:22:23.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'114', N'查询', N'113', NULL, N'2', N'/api/Line/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-03-27 11:22:23.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'115', N'新增', N'113', NULL, N'2', N'/api/Line/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-03-27 11:22:23.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'116', N'编辑', N'113', NULL, N'2', N'/api/Line/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-03-27 11:22:23.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'117', N'删除', N'113', NULL, N'2', N'/api/Line/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-03-27 11:22:23.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'118', N'工序管理', N'107', N'ant-design:format-painter-outlined', N'1', N'/modeling/operation', N'/modeling/operation/index', N'1', N'1', N'0', N'0', NULL, N'3', N'1', N'2024-03-27 11:24:54.000', N'1', N'2024-04-03 00:06:50.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'119', N'查询', N'118', NULL, N'2', N'/api/Operation/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-03-27 11:24:54.000', N'1', N'2024-04-03 00:06:50.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'120', N'新增', N'118', NULL, N'2', N'/api/Operation/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-03-27 11:24:54.000', N'1', N'2024-04-03 00:06:50.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'121', N'编辑', N'118', NULL, N'2', N'/api/Operation/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-03-27 11:24:54.000', N'1', N'2024-04-03 00:06:50.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'122', N'删除', N'118', NULL, N'2', N'/api/Operation/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-03-27 11:24:54.000', N'1', N'2024-04-03 00:06:50.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'123', N'工位管理', N'107', N'ep:place', N'1', N'/modeling/workstation', N'/modeling/workstation/index', N'1', N'1', N'0', N'0', NULL, N'4', N'1', N'2024-03-27 11:26:48.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'124', N'查询', N'123', NULL, N'2', N'/api/Workstation/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-03-27 11:26:48.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'125', N'新增', N'123', NULL, N'2', N'/api/Workstation/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-03-27 11:26:49.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'126', N'编辑', N'123', NULL, N'2', N'/api/Workstation/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-03-27 11:26:49.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'127', N'删除', N'123', NULL, N'2', N'/api/Workstation/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-03-27 11:26:49.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'128', N'工艺管理', NULL, N'ant-design:merge-outlined', N'0', N'/process', NULL, N'0', N'1', N'0', N'0', NULL, N'2', N'1', N'2024-04-02 23:16:46.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'129', N'工序管理', N'128', N'ant-design:format-painter-outlined', N'1', N'/process/operation', N'/process/operation/index', N'1', N'1', N'0', N'0', NULL, N'1', N'1', N'2024-04-02 23:25:18.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'130', N'查询', N'129', NULL, N'2', N'/api/ProcessOperation/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-02 23:25:18.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'131', N'新增', N'129', NULL, N'2', N'/api/ProcessOperation/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-02 23:25:18.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'132', N'编辑', N'129', NULL, N'2', N'/api/ProcessOperation/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-02 23:25:18.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'133', N'删除', N'129', NULL, N'2', N'/api/ProcessOperation/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-02 23:25:18.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'134', N'主数据', N'72', N'ant-design:gold-outlined', N'0', N'/master', NULL, N'0', N'1', N'0', N'0', NULL, N'1', N'1', N'2024-04-07 16:13:43.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'135', N'物料管理', N'134', N'ant-design:deployment-unit-outlined', N'1', N'/base/material', N'/base/material/index', N'1', N'1', N'0', N'0', NULL, N'1', N'1', N'2024-04-07 16:19:30.000', N'1', N'2024-08-27 10:35:54.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'136', N'查询', N'135', NULL, N'2', N'/api/Material/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-07 16:19:31.000', N'1', N'2024-08-27 10:35:54.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'137', N'新增', N'135', NULL, N'2', N'/api/Material/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-07 16:19:31.000', N'1', N'2024-08-27 10:35:54.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'138', N'编辑', N'135', NULL, N'2', N'/api/Material/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-07 16:19:31.000', N'1', N'2024-08-27 10:35:54.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'139', N'删除', N'135', NULL, N'2', N'/api/Material/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-07 16:19:31.000', N'1', N'2024-08-27 10:35:54.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'140', N'产品料号', N'134', N'ant-design:instagram-outlined', N'1', N'/base/partMaterial', N'/base/partMaterial/index', N'1', N'1', N'0', N'0', NULL, N'2', N'1', N'2024-04-07 16:25:55.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'141', N'查询', N'140', NULL, N'2', N'/api/PartMaterial/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-07 16:25:55.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'142', N'新增', N'140', NULL, N'2', N'/api/PartMaterial/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-07 16:25:55.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'143', N'编辑', N'140', NULL, N'2', N'/api/PartMaterial/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-07 16:25:55.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'144', N'删除', N'140', NULL, N'2', N'/api/PartMaterial/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-07 16:25:55.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'145', N'BOM', N'134', N'ant-design:bold-outlined', N'1', N'/base/bom', N'/base/bom/index', N'1', N'1', N'0', N'0', NULL, N'3', N'1', N'2024-04-07 16:29:07.000', N'1', N'2024-04-08 16:01:37.000', N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'146', N'查询', N'145', NULL, N'2', N'/api/Bom/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-07 16:29:07.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'147', N'新增', N'145', NULL, N'2', N'/api/Bom/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-07 16:29:07.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'148', N'编辑', N'145', NULL, N'2', N'/api/Bom/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-07 16:29:07.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'149', N'删除', N'145', NULL, N'2', N'/api/Bom/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-07 16:29:07.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'150', N'替代料管理', N'134', N'ep:set-up', N'1', N'/base/materialReplace', N'/base/materialReplace/index', N'1', N'1', N'0', N'0', NULL, N'4', N'1', N'2024-04-09 16:35:49.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'151', N'查询', N'150', NULL, N'2', N'/api/MaterialReplace/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-09 16:35:49.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'152', N'新增', N'150', NULL, N'2', N'/api/MaterialReplace/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-09 16:35:49.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'153', N'编辑', N'150', NULL, N'2', N'/api/MaterialReplace/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-09 16:35:49.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'154', N'删除', N'150', NULL, N'2', N'/api/MaterialReplace/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-09 16:35:49.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'155', N'集成配置', N'36', N'ant-design:api-outlined', N'1', N'/si/config', N'/si/config/index', N'1', N'1', N'0', N'0', NULL, N'1', N'1', N'2024-04-11 11:22:28.000', N'1', N'2025-02-10 14:57:23.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'156', N'查询', N'155', NULL, N'2', N'/api/SiConfig/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-11 11:22:28.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'157', N'新增', N'155', NULL, N'2', N'/api/SiConfig/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-11 11:22:28.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'158', N'编辑', N'155', NULL, N'2', N'/api/SiConfig/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-11 11:22:28.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'159', N'删除', N'155', NULL, N'2', N'/api/SiConfig/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-11 11:22:28.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'160', N'推送模板', N'36', N'ant-design:file-markdown-outlined', N'1', N'/si/msgTemplate', N'/si/msgTemplate/index', N'1', N'1', N'0', N'0', NULL, N'2', N'1', N'2024-04-11 11:24:40.000', N'1', N'2025-02-10 14:57:23.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'161', N'查询', N'160', NULL, N'2', N'/api/SiMsgTemplate/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-11 11:24:40.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'162', N'新增', N'160', NULL, N'2', N'/api/SiMsgTemplate/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-11 11:24:40.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'163', N'编辑', N'160', NULL, N'2', N'/api/SiMsgTemplate/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-11 11:24:40.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'164', N'删除', N'160', NULL, N'2', N'/api/SiMsgTemplate/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-11 11:24:40.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'165', N'消息推送', N'36', N'ant-design:send-outlined', N'1', N'/si/msgLog', N'/si/msgLog/index', N'1', N'1', N'0', N'0', NULL, N'3', N'1', N'2024-04-12 14:41:19.000', N'1', N'2025-02-10 14:57:23.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'166', N'查询', N'165', NULL, N'2', N'/api/SiMsgLog/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-12 14:41:19.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'167', N'新增', N'165', NULL, N'2', N'/api/SiMsgLog/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-12 14:41:19.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'168', N'编辑', N'165', NULL, N'2', N'/api/SiMsgLog/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-12 14:41:19.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'169', N'删除', N'165', NULL, N'2', N'/api/SiMsgLog/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-12 14:41:19.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'170', N'供应商管理', N'72', N'ant-design:shop-outlined', N'1', N'/base/supplier', N'/base/supplier/index', N'1', N'1', N'0', N'0', NULL, N'5', N'1', N'2024-04-17 14:57:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'171', N'查询', N'170', NULL, N'2', N'/api/Supplier/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-17 14:57:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'172', N'新增', N'170', NULL, N'2', N'/api/Supplier/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-17 14:57:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'173', N'编辑', N'170', NULL, N'2', N'/api/Supplier/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-17 14:57:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'174', N'删除', N'170', NULL, N'2', N'/api/Supplier/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-17 14:57:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'175', N'客户管理', N'72', N'ant-design:box-plot-outlined', N'1', N'/base/customer', N'/base/customer/index', N'1', N'1', N'0', N'0', NULL, N'6', N'1', N'2024-04-17 14:59:02.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'176', N'查询', N'175', NULL, N'2', N'/api/Customer/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-17 14:59:02.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'177', N'新增', N'175', NULL, N'2', N'/api/Customer/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-17 14:59:02.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'178', N'编辑', N'175', NULL, N'2', N'/api/Customer/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-17 14:59:02.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'179', N'删除', N'175', NULL, N'2', N'/api/Customer/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-17 14:59:02.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'180', N'属性管理', N'7', N'ant-design:signature-outlined', N'1', N'/dev/attribute', N'/dev/attribute/index', N'1', N'1', N'0', N'0', NULL, N'4', N'1', N'2024-04-17 17:15:35.000', N'1', N'2025-02-10 14:57:04.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'181', N'查询', N'180', NULL, N'2', N'/api/Attribute/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-17 17:15:35.000', N'1', N'2025-02-10 14:57:05.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'182', N'新增', N'180', NULL, N'2', N'/api/Attribute/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-17 17:15:35.000', N'1', N'2025-02-10 14:57:05.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'183', N'编辑', N'180', NULL, N'2', N'/api/Attribute/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-17 17:15:35.000', N'1', N'2025-02-10 14:57:05.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'184', N'删除', N'180', NULL, N'2', N'/api/Attribute/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-17 17:15:35.000', N'1', N'2025-02-10 14:57:05.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'185', N'工单管理', N'99', N'ep:credit-card', N'1', N'/product/workOrder', N'/product/workOrder/index', N'1', N'1', N'0', N'0', NULL, N'1', N'1', N'2024-04-21 20:56:09.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'186', N'查询', N'185', NULL, N'2', N'/api/WorkOrder/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-21 20:56:09.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'187', N'新增', N'185', NULL, N'2', N'/api/WorkOrder/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-21 20:56:09.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'188', N'编辑', N'185', NULL, N'2', N'/api/WorkOrder/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-21 20:56:09.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'189', N'删除', N'185', NULL, N'2', N'/api/WorkOrder/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-21 20:56:09.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'190', N'工单拆分', N'185', NULL, N'2', N'/api/WorkOrder/SplitWorkOrder', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-22 17:20:02.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'191', N'计划排程', N'99', N'ant-design:schedule-outlined', N'1', N'/product/aps', N'product/aps/index', N'0', N'1', N'0', N'0', NULL, N'2', N'1', N'2024-04-23 21:27:01.000', N'1', N'2025-02-10 14:55:50.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'192', N'更新计划时间', N'191', NULL, N'2', N'/api/WorkOrder/UpdatePlanDate', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-04-25 20:49:13.000', N'1', N'2025-02-10 14:55:50.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'193', N'排班设置', N'72', N'ep:calendar', N'0', N'/calendar', NULL, N'0', N'1', N'0', N'0', NULL, N'3', N'1', N'2024-05-04 17:10:17.000', N'1', N'2024-05-09 14:55:42.000', N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'194', N'假期设置', N'193', N'ant-design:calendar-outlined', N'1', N'/base/calendar/holiday', N'base/calendar/holiday/index', N'0', N'1', N'0', N'0', NULL, N'1', N'1', N'2024-05-04 17:12:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'195', N'不良主数据', N'72', N'ant-design:delete-row-outlined', N'0', N'/failure', NULL, N'0', N'1', N'0', N'0', NULL, N'2', N'1', N'2024-05-09 15:00:44.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'196', N'不良类型', N'195', N'ant-design:robot-outlined', N'1', N'/base/failureType', N'/base/failureType/index', N'1', N'1', N'0', N'0', NULL, N'1', N'1', N'2024-05-09 15:04:12.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'197', N'查询', N'196', NULL, N'2', N'/api/FailureType/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-05-09 15:04:12.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'198', N'新增', N'196', NULL, N'2', N'/api/FailureType/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-05-09 15:04:12.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'199', N'编辑', N'196', NULL, N'2', N'/api/FailureType/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-05-09 15:04:12.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'200', N'删除', N'196', NULL, N'2', N'/api/FailureType/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-05-09 15:04:12.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'201', N'不良现象', N'195', N'ant-design:delete-column-outlined', N'1', N'/base/failureSymptom', N'/base/failureSymptom/index', N'1', N'1', N'0', N'0', NULL, N'2', N'1', N'2024-05-09 15:06:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'202', N'查询', N'201', NULL, N'2', N'/api/FailureSymptom/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-05-09 15:06:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'203', N'新增', N'201', NULL, N'2', N'/api/FailureSymptom/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-05-09 15:06:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'204', N'编辑', N'201', NULL, N'2', N'/api/FailureSymptom/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-05-09 15:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'205', N'删除', N'201', NULL, N'2', N'/api/FailureSymptom/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-05-09 15:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'206', N'终端作业', NULL, N'ant-design:right-square-outlined', N'0', N'/terminal', NULL, N'0', N'1', N'0', N'0', NULL, N'4', N'1', N'2024-05-09 15:35:35.000', N'1', N'2025-02-10 14:55:57.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'207', N'终端实例', N'206', N'ep:cpu', N'1', N'/terminal/instance', N'terminal/instance/index', N'0', N'1', N'0', N'0', NULL, N'2', N'1', N'2024-05-10 11:26:59.000', N'1', N'2025-02-10 14:55:57.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'208', N'技能管理', N'72', N'ep:ice-cream-round', N'1', N'/base/skill', N'/base/skill/index', N'1', N'1', N'0', N'0', NULL, N'4', N'1', N'2024-05-12 22:27:21.000', N'1', N'2024-05-12 22:27:42.000', N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'209', N'查询', N'208', NULL, N'2', N'/api/Skill/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-05-12 22:27:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'210', N'新增', N'208', NULL, N'2', N'/api/Skill/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-05-12 22:27:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'211', N'编辑', N'208', NULL, N'2', N'/api/Skill/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-05-12 22:27:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'212', N'删除', N'208', NULL, N'2', N'/api/Skill/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-05-12 22:27:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'213', N'发布', N'92', NULL, N'2', N'/api/Template/Publish', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-05-13 14:53:15.000', N'1', N'2025-02-10 14:56:48.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'214', N'分配用户', N'208', NULL, N'2', N'/api/Skill/AssignSkillToUser', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-05-13 15:32:47.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'215', N'分配用户', N'123', NULL, N'2', N'/api/Workstation/AssignWorkStationToUser', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-05-13 15:33:12.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'216', N'分配用户', N'92', NULL, N'2', N'/api/Template/AssignTemplateToUser', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-05-13 15:33:51.000', N'1', N'2025-02-10 14:56:48.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'217', N'仓库管理', NULL, N'ep:office-building', N'0', N'/warehouse', NULL, N'0', N'1', N'0', N'0', NULL, N'6', N'1', N'2024-05-15 15:30:25.000', N'1', N'2025-02-10 14:56:05.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'218', N'质量管理', NULL, N'ep:fries', N'0', N'/quality', NULL, N'0', N'1', N'0', N'0', NULL, N'7', N'1', N'2024-05-15 15:34:33.000', N'1', N'2025-02-10 14:56:07.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'219', N'设备管理', NULL, N'ep:refrigerator', N'0', N'/equipment', NULL, N'0', N'1', N'0', N'0', NULL, N'8', N'1', N'2024-05-15 15:37:58.000', N'1', N'2025-02-10 14:56:17.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'220', N'APP管理', NULL, N'ep:cellphone', N'0', N'/app', NULL, N'0', N'1', N'0', N'0', NULL, N'102', N'1', N'2024-05-15 15:42:03.000', N'1', N'2025-02-10 14:57:32.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'221', N'设备类型', N'219', N'ant-design:pull-request-outlined', N'1', N'/equipment/type', N'/equipment/type/index', N'1', N'1', N'0', N'0', NULL, N'1', N'1', N'2024-05-15 15:49:20.000', N'1', N'2025-02-10 14:56:17.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'222', N'查询', N'221', NULL, N'2', N'/api/EquipmentType/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-05-15 15:49:20.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'223', N'新增', N'221', NULL, N'2', N'/api/EquipmentType/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-05-15 15:49:20.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'224', N'编辑', N'221', NULL, N'2', N'/api/EquipmentType/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-05-15 15:49:20.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'225', N'删除', N'221', NULL, N'2', N'/api/EquipmentType/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-05-15 15:49:20.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'226', N'设备台账', N'219', N'ant-design:one-to-one-outlined', N'1', N'/equipment/base', N'equipment/base/index', N'1', N'1', N'0', N'0', NULL, N'2', N'1', N'2024-05-15 17:12:42.000', N'1', N'2025-02-10 14:56:17.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'227', N'查询', N'226', NULL, N'2', N'/api/Equipment/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-05-15 17:12:42.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'228', N'新增', N'226', NULL, N'2', N'/api/Equipment/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-05-15 17:12:42.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'229', N'编辑', N'226', NULL, N'2', N'/api/Equipment/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-05-15 17:12:42.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'230', N'删除', N'226', NULL, N'2', N'/api/Equipment/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-05-15 17:12:42.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'231', N'设备详情', N'226', NULL, N'1', N'/equipment/base/detail/:id', N'equipment/base/detail', N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-05-17 09:42:47.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'232', N'打印模板', N'7', N'ant-design:printer-outlined', N'1', N'/dev/printTemplate', N'/dev/printTemplate/index', N'1', N'1', N'0', N'0', NULL, N'5', N'1', N'2024-05-17 15:50:14.000', N'1', N'2025-02-10 14:57:08.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'233', N'查询', N'232', NULL, N'2', N'/api/PrintTemplate/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-05-17 15:50:14.000', N'1', N'2025-02-10 14:57:08.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'234', N'新增', N'232', NULL, N'2', N'/api/PrintTemplate/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-05-17 15:50:14.000', N'1', N'2025-02-10 14:57:08.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'235', N'编辑', N'232', NULL, N'2', N'/api/PrintTemplate/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-05-17 15:50:14.000', N'1', N'2025-02-10 14:57:08.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'236', N'删除', N'232', NULL, N'2', N'/api/PrintTemplate/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-05-17 15:50:14.000', N'1', N'2025-02-10 14:57:08.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'237', N'客户端', N'206', N'ant-design:harmony-o-s-outlined', N'1', N'/terminal/client', N'/terminal/client/index', N'1', N'1', N'0', N'0', NULL, N'1', N'1', N'2024-05-29 17:19:16.000', N'1', N'2025-02-10 14:55:57.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'238', N'查询', N'237', NULL, N'2', N'/api/Client/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-05-29 17:19:16.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'239', N'新增', N'237', NULL, N'2', N'/api/Client/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-05-29 17:19:16.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'240', N'编辑', N'237', NULL, N'2', N'/api/Client/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-05-29 17:19:16.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'241', N'删除', N'237', NULL, N'2', N'/api/Client/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-05-29 17:19:16.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'242', N'下载文件', N'237', NULL, N'2', N'/api/Client/DownloadFile', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-05-30 08:47:29.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'243', N'取消发布', N'92', NULL, N'2', N'/api/Template/UnPublish', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-03 13:32:10.000', N'1', N'2025-02-10 14:56:48.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'244', N'更新发布状态', N'102', NULL, N'2', N'/api/ProcessRoute/UpdatePublishStatus', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-03 13:33:16.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'245', N'工装夹具', N'219', N'ant-design:gold-outlined', N'1', N'/equipment/tool', N'/equipment/tool/index', N'1', N'1', N'0', N'0', NULL, N'3', N'1', N'2024-06-06 21:47:33.000', N'1', N'2025-02-10 14:56:17.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'246', N'查询', N'245', NULL, N'2', N'/api/EquipmentTool/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-06 21:47:33.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'247', N'新增', N'245', NULL, N'2', N'/api/EquipmentTool/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-06 21:47:33.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'248', N'编辑', N'245', NULL, N'2', N'/api/EquipmentTool/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-06 21:47:33.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'249', N'删除', N'245', NULL, N'2', N'/api/EquipmentTool/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-06 21:47:33.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'250', N'点检保养', N'219', N'ant-design:monitor-outlined', N'0', N'/inspection', NULL, N'0', N'1', N'0', N'0', NULL, N'4', N'1', N'2024-06-09 19:55:51.000', N'1', N'2025-02-10 14:56:17.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'251', N'项目维护', N'250', N'ant-design:signature-outlined', N'1', N'/equipment/itemConfig', N'/equipment/itemConfig/index', N'1', N'1', N'0', N'0', NULL, N'1', N'1', N'2024-06-09 20:16:30.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'252', N'查询', N'251', NULL, N'2', N'/api/EquipmentItemConfig/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-09 20:16:30.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'253', N'新增', N'251', NULL, N'2', N'/api/EquipmentItemConfig/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-09 20:16:30.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'254', N'编辑', N'251', NULL, N'2', N'/api/EquipmentItemConfig/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-09 20:16:30.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'255', N'删除', N'251', NULL, N'2', N'/api/EquipmentItemConfig/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-09 20:16:30.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'256', N'项目表单', N'250', N'ant-design:profile-outlined', N'1', N'/equipment/itemForm', N'/equipment/itemForm/index', N'1', N'1', N'0', N'0', NULL, N'2', N'1', N'2024-06-09 20:55:45.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'257', N'查询', N'256', NULL, N'2', N'/api/EquipmentItemForm/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-09 20:55:45.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'258', N'新增', N'256', NULL, N'2', N'/api/EquipmentItemForm/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-09 20:55:45.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'259', N'编辑', N'256', NULL, N'2', N'/api/EquipmentItemForm/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-09 20:55:45.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'260', N'删除', N'256', NULL, N'2', N'/api/EquipmentItemForm/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-09 20:55:45.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'261', N'计划配置', N'250', N'ant-design:reconciliation-twotone', N'1', N'/equipment/maintenancePlan', N'/equipment/maintenancePlan/index', N'1', N'1', N'0', N'0', NULL, N'3', N'1', N'2024-06-10 21:15:58.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'262', N'查询', N'261', NULL, N'2', N'/api/EquipmentMaintenancePlan/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-10 21:15:59.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'263', N'新增', N'261', NULL, N'2', N'/api/EquipmentMaintenancePlan/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-10 21:15:59.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'264', N'编辑', N'261', NULL, N'2', N'/api/EquipmentMaintenancePlan/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-10 21:15:59.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'265', N'删除', N'261', NULL, N'2', N'/api/EquipmentMaintenancePlan/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-10 21:15:59.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'266', N'维修查询', N'383', N'ant-design:tool-outlined', N'1', N'/equipment/repairSearch', N'equipment/repairSearch/index', N'1', N'1', N'0', N'0', NULL, N'2', N'1', N'2024-06-12 17:00:06.000', N'1', N'2024-09-24 16:23:22.000', N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'267', N'查询', N'266', NULL, N'2', N'/api/EquipmentRepair/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-12 17:00:06.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'268', N'新增', N'266', NULL, N'2', N'/api/EquipmentRepair/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-12 17:00:06.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'269', N'编辑', N'266', NULL, N'2', N'/api/EquipmentRepair/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-12 17:00:06.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'270', N'删除', N'266', NULL, N'2', N'/api/EquipmentRepair/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-12 17:00:06.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'271', N'记录查询', N'250', N'ant-design:file-search-outlined', N'1', N'/equipment/maintenanceTrack', N'/equipment/maintenanceTrack/index', N'1', N'1', N'0', N'0', NULL, N'4', N'1', N'2024-06-12 17:26:15.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'272', N'查询', N'271', NULL, N'2', N'/api/EquipmentMaintenanceTrack/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-12 17:26:16.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'273', N'新增', N'271', NULL, N'2', N'/api/EquipmentMaintenanceTrack/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-12 17:26:16.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'274', N'编辑', N'271', NULL, N'2', N'/api/EquipmentMaintenanceTrack/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-12 17:26:16.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'275', N'删除', N'271', NULL, N'2', N'/api/EquipmentMaintenanceTrack/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-12 17:26:16.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'276', N'释放条码', N'185', NULL, N'2', N'/api/WorkOrder/ReleaseProductSn', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-18 17:15:49.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'277', N'取消任务', N'271', NULL, N'2', N'/api/EquipmentMaintenanceTrack/Cancel', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-19 09:24:14.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'278', N'检验类型', N'218', N'ant-design:highlight-outlined', N'1', N'/qc/checkType', N'/qc/checkType/index', N'1', N'1', N'0', N'0', NULL, N'1', N'1', N'2024-06-19 20:27:38.000', N'1', N'2025-02-10 14:56:07.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'279', N'查询', N'278', NULL, N'2', N'/api/QcCheckType/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-19 20:27:38.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'280', N'新增', N'278', NULL, N'2', N'/api/QcCheckType/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-19 20:27:38.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'281', N'编辑', N'278', NULL, N'2', N'/api/QcCheckType/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-19 20:27:38.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'282', N'删除', N'278', NULL, N'2', N'/api/QcCheckType/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-19 20:27:38.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'283', N'检验项群组', N'218', N'ant-design:tags-twotone', N'1', N'/qc/checkGroup', N'/qc/checkGroup/index', N'1', N'1', N'0', N'0', NULL, N'2', N'1', N'2024-06-19 20:32:56.000', N'1', N'2024-06-19 21:20:47.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'284', N'查询', N'283', NULL, N'2', N'/api/QcCheckGroup/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-19 20:32:56.000', N'1', N'2024-06-19 21:20:47.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'285', N'新增', N'283', NULL, N'2', N'/api/QcCheckGroup/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-19 20:32:56.000', N'1', N'2024-06-19 21:20:47.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'286', N'编辑', N'283', NULL, N'2', N'/api/QcCheckGroup/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-19 20:32:56.000', N'1', N'2024-06-19 21:20:47.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'287', N'删除', N'283', NULL, N'2', N'/api/QcCheckGroup/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-19 20:32:56.000', N'1', N'2024-06-19 21:20:47.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'288', N'检验项目', N'218', N'ant-design:tag-outlined', N'1', N'/qc/checkItem', N'/qc/checkItem/index', N'1', N'1', N'0', N'0', NULL, N'2', N'1', N'2024-06-19 21:26:12.000', N'1', N'2025-02-10 14:56:07.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'289', N'查询', N'288', NULL, N'2', N'/api/QcCheckItem/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-19 21:26:12.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'290', N'新增', N'288', NULL, N'2', N'/api/QcCheckItem/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-19 21:26:12.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'291', N'编辑', N'288', NULL, N'2', N'/api/QcCheckItem/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-19 21:26:12.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'292', N'删除', N'288', NULL, N'2', N'/api/QcCheckItem/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-19 21:26:12.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'293', N'检验方案', N'218', N'ant-design:reconciliation-outlined', N'1', N'/qc/checkSchema', N'/qc/checkSchema/index', N'1', N'1', N'0', N'0', NULL, N'3', N'1', N'2024-06-20 14:32:02.000', N'1', N'2025-02-10 14:56:07.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'294', N'查询', N'293', NULL, N'2', N'/api/QcCheckSchema/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-20 14:32:02.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'295', N'新增', N'293', NULL, N'2', N'/api/QcCheckSchema/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-20 14:32:02.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'296', N'编辑', N'293', NULL, N'2', N'/api/QcCheckSchema/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-20 14:32:02.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'297', N'删除', N'293', NULL, N'2', N'/api/QcCheckSchema/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-20 14:32:02.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'298', N'检验任务', N'218', N'ant-design:carry-out-outlined', N'1', N'/qc/checkTask', N'/qc/checkTask/index', N'1', N'1', N'0', N'0', NULL, N'4', N'1', N'2024-06-20 16:41:04.000', N'1', N'2025-02-10 14:56:07.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'299', N'查询', N'298', NULL, N'2', N'/api/QcCheckTask/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-20 16:41:04.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'300', N'新增', N'298', NULL, N'2', N'/api/QcCheckTask/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-20 16:41:04.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'301', N'编辑', N'298', NULL, N'2', N'/api/QcCheckTask/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-20 16:41:04.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'302', N'删除', N'298', NULL, N'2', N'/api/QcCheckTask/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-20 16:41:04.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'303', N'维修方法', N'195', N'ant-design:tool-outlined', N'1', N'/base/repairMethod', N'/base/repairMethod/index', N'1', N'1', N'0', N'0', NULL, N'3', N'1', N'2024-06-25 15:34:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'304', N'查询', N'303', NULL, N'2', N'/api/RepairMethod/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-25 15:34:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'305', N'新增', N'303', NULL, N'2', N'/api/RepairMethod/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-25 15:34:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'306', N'编辑', N'303', NULL, N'2', N'/api/RepairMethod/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-25 15:34:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'307', N'删除', N'303', NULL, N'2', N'/api/RepairMethod/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-25 15:34:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'308', N'IOT', NULL, N'ep:coordinate', N'0', N'/iot', NULL, N'0', N'1', N'0', N'0', NULL, N'9', N'1', N'2024-06-28 09:51:16.000', N'1', N'2025-02-10 14:56:43.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'309', N'数据采集', N'308', N'ant-design:usb-outlined', N'1', N'/iframe/iot/dc', N'https://yefeng.club/iot', N'0', N'1', N'1', N'0', NULL, N'1', N'1', N'2024-06-28 22:47:17.000', N'1', N'2025-02-10 14:56:43.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'310', N'应用菜单', N'220', N'ant-design:appstore-outlined', N'1', N'/app/menu', N'/app/menu/index', N'1', N'1', N'0', N'0', NULL, N'1', N'1', N'2024-06-29 09:12:41.000', N'1', N'2025-02-10 14:57:32.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'311', N'查询', N'310', NULL, N'2', N'/api/AppMenu/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-29 09:12:41.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'312', N'新增', N'310', NULL, N'2', N'/api/AppMenu/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-29 09:12:41.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'313', N'编辑', N'310', NULL, N'2', N'/api/AppMenu/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-29 09:12:41.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'314', N'删除', N'310', NULL, N'2', N'/api/AppMenu/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-29 09:12:41.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'315', N'保存', N'310', NULL, N'2', N'/api/AppMenu/Save', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-06-30 21:38:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'316', N'工艺设计', N'102', NULL, N'2', N'/api/ProcessRoute/UpdateDesign', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-07-10 21:51:10.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'317', N'仓库定义', N'217', N'ant-design:bank-outlined', N'1', N'/wms/warehouse', N'/wms/warehouse/index', N'1', N'1', N'0', N'0', NULL, N'1', N'1', N'2024-07-24 16:15:34.000', N'1', N'2025-02-10 14:56:05.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'318', N'查询', N'317', NULL, N'2', N'/api/WmsWarehouse/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-07-24 16:15:34.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'319', N'新增', N'317', NULL, N'2', N'/api/WmsWarehouse/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-07-24 16:15:34.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'320', N'编辑', N'317', NULL, N'2', N'/api/WmsWarehouse/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-07-24 16:15:34.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'321', N'删除', N'317', NULL, N'2', N'/api/WmsWarehouse/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-07-24 16:15:34.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'322', N'货架/库区', N'217', N'ant-design:border-outer-outlined', N'1', N'/wms/region', N'/wms/region/index', N'1', N'1', N'0', N'0', NULL, N'2', N'1', N'2024-07-24 16:17:39.000', N'1', N'2025-02-10 14:56:05.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'323', N'查询', N'322', NULL, N'2', N'/api/WmsRegion/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-07-24 16:17:39.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'324', N'新增', N'322', NULL, N'2', N'/api/WmsRegion/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-07-24 16:17:39.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'325', N'编辑', N'322', NULL, N'2', N'/api/WmsRegion/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-07-24 16:17:39.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'326', N'删除', N'322', NULL, N'2', N'/api/WmsRegion/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-07-24 16:17:39.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'327', N'库位设置', N'217', N'ant-design:borderless-table-outlined', N'1', N'/wms/location', N'/wms/location/index', N'1', N'1', N'0', N'0', NULL, N'3', N'1', N'2024-07-24 17:11:08.000', N'1', N'2025-02-10 14:56:05.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'328', N'查询', N'327', NULL, N'2', N'/api/WmsLocation/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-07-24 17:11:08.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'329', N'新增', N'327', NULL, N'2', N'/api/WmsLocation/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-07-24 17:11:08.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'330', N'编辑', N'327', NULL, N'2', N'/api/WmsLocation/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-07-24 17:11:08.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'331', N'删除', N'327', NULL, N'2', N'/api/WmsLocation/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-07-24 17:11:08.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'332', N'入库管理', N'217', N'ant-design:node-expand-outlined', N'0', N'/inWarehouse', NULL, N'0', N'1', N'0', N'0', NULL, N'5', N'1', N'2024-07-25 16:25:37.000', N'1', N'2025-02-10 14:56:05.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'333', N'原材暂收', N'353', N'ant-design:file-text-outlined', N'1', N'/wms/reelStock', N'wms/reelStock/index', N'1', N'1', N'0', N'0', NULL, N'0', N'1', N'2024-07-25 16:27:20.000', N'1', N'2024-09-13 22:25:10.000', N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'334', N'查询', N'333', NULL, N'2', N'/api/WmsReceiptNo/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-07-25 16:27:20.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'335', N'新增', N'333', NULL, N'2', N'/api/WmsReceiptNo/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-07-25 16:27:20.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'336', N'编辑', N'333', NULL, N'2', N'/api/WmsReceiptNo/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-07-25 16:27:20.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'337', N'删除', N'333', NULL, N'2', N'/api/WmsReceiptNo/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-07-25 16:27:20.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'338', N'来料检验', N'218', N'ep:ice-cream-round', N'1', N'/qc/iQC', N'/qc/iQC/index', N'1', N'1', N'0', N'0', NULL, N'5', N'1', N'2024-07-26 11:19:25.000', N'1', N'2025-02-10 14:56:07.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'339', N'查询', N'338', NULL, N'2', N'/api/QcIQC/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-07-26 11:19:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'340', N'新增', N'338', NULL, N'2', N'/api/QcIQC/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-07-26 11:19:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'341', N'编辑', N'338', NULL, N'2', N'/api/QcIQC/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-07-26 11:19:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'342', N'删除', N'338', NULL, N'2', N'/api/QcIQC/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-07-26 11:19:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'343', N'审核', N'338', NULL, N'2', N'/api/QcIQC/Audit', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-07-26 13:58:19.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'344', N'登录日志', N'1', N'ant-design:environment-outlined', N'1', N'/sys/loginLog', N'sys/loginLog/index', N'0', N'1', N'0', N'0', NULL, N'7', N'1', N'2024-07-29 14:36:32.000', N'1', N'2025-02-10 14:58:19.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'345', N'IQC详情', N'338', NULL, N'1', N'/qc/iQC/detail/:id', N'qc/iQC/detail', N'1', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-08-09 19:48:33.000', N'1', N'2024-08-11 20:15:08.000', N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'346', N'数据录入', N'338', NULL, N'2', N'/api/QcIQC/DataEntry', NULL, N'0', N'1', N'0', N'0', NULL, N'0', N'1', N'2024-08-11 19:13:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'347', N'原材入库', N'332', N'ant-design:login-outlined', N'1', N'/wms/inMaterial', N'wms/inMaterial/index', N'1', N'1', N'0', N'0', NULL, N'2', N'1', N'2024-08-12 11:42:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'348', N'标签配置', N'7', N'ant-design:barcode-outlined', N'1', N'/dev/label', N'/dev/label/index', N'1', N'1', N'0', N'0', NULL, N'7', N'1', N'2024-08-12 21:50:37.000', N'1', N'2025-02-10 14:57:13.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'349', N'查询', N'348', NULL, N'2', N'/api/Label/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-08-12 21:50:37.000', N'1', N'2025-02-10 14:57:13.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'350', N'新增', N'348', NULL, N'2', N'/api/Label/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-08-12 21:50:37.000', N'1', N'2025-02-10 14:57:13.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'351', N'编辑', N'348', NULL, N'2', N'/api/Label/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-08-12 21:50:37.000', N'1', N'2025-02-10 14:57:13.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'352', N'删除', N'348', NULL, N'2', N'/api/Label/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-08-12 21:50:37.000', N'1', N'2025-02-10 14:57:13.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'353', N'库存查询', N'217', N'ant-design:reconciliation-outlined', N'0', N'/stock', N'/wms/stock/index', N'1', N'1', N'0', N'0', NULL, N'4', N'1', N'2024-08-13 21:14:12.000', N'1', N'2025-02-10 14:56:05.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'354', N'查询', N'353', NULL, N'2', N'/api/WmsStock/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-08-13 21:14:12.000', N'1', N'2024-08-14 21:59:33.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'355', N'新增', N'353', NULL, N'2', N'/api/WmsStock/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-08-13 21:14:12.000', N'1', N'2024-08-14 21:59:37.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'356', N'编辑', N'353', NULL, N'2', N'/api/WmsStock/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-08-13 21:14:12.000', N'1', N'2024-08-14 21:59:40.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'357', N'删除', N'353', NULL, N'2', N'/api/WmsStock/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-08-13 21:14:12.000', N'1', N'2024-08-14 21:59:42.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'358', N'原材料仓', N'353', N'ant-design:file-search-outlined', N'1', N'/wms/reel', N'wms/reel/index', N'0', N'1', N'0', N'0', NULL, N'1', N'1', N'2024-08-14 11:32:30.000', N'1', N'2024-09-16 18:10:39.000', N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'359', N'锁定', N'358', NULL, N'2', N'/api/WmsMaterialStock/Lock', NULL, N'0', N'1', N'0', N'0', NULL, N'0', N'1', N'2024-08-14 22:00:03.000', N'1', N'2024-08-14 22:02:37.000', N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'360', N'解锁', N'358', NULL, N'2', N'/api/WmsMaterialStock/UnLock', NULL, N'0', N'1', N'0', N'0', NULL, N'0', N'1', N'2024-08-14 22:00:36.000', N'1', N'2024-08-14 22:02:43.000', N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'361', N'测试模板', N'308', N'ant-design:account-book-outlined', N'1', N'/common/template', N'common/template/index', N'1', N'1', N'0', N'0', N'11', N'0', N'1', N'2024-08-16 17:13:37.000', N'1', N'2025-02-10 14:56:43.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'362', N'领料申请', N'99', N'ep:collection', N'1', N'/product/pickMaterial', N'product/pickMaterial/index', N'1', N'1', N'0', N'0', NULL, N'3', N'1', N'2024-08-18 17:08:10.000', N'1', N'2024-08-19 10:22:46.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'363', N'测试菜单', N'308', N'ant-design:android-outlined', N'1', N'/dev/template/preview', N'dev/template/preview/index', N'0', N'1', N'0', N'0', NULL, N'0', N'1', N'2024-08-18 19:18:51.000', N'1', N'2024-08-18 19:19:34.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'364', N'出库管理', N'217', N'ant-design:node-collapse-outlined', N'0', N'/outWarehouse', NULL, N'0', N'1', N'0', N'0', NULL, N'6', N'1', N'2024-08-24 22:04:15.000', N'1', N'2025-02-10 14:56:05.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'365', N'备料单', N'217', N'ant-design:bold-outlined', N'1', N'/wms/prepMaterialNo', N'/wms/prepMaterialNo/index', N'1', N'1', N'0', N'0', NULL, N'8', N'1', N'2024-08-24 22:05:13.000', N'1', N'2025-02-10 14:56:05.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'366', N'查询', N'365', NULL, N'2', N'/api/WmsPrepMaterialNo/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-08-24 22:05:13.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'367', N'新增', N'365', NULL, N'2', N'/api/WmsPrepMaterialNo/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-08-24 22:05:13.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'368', N'编辑', N'365', NULL, N'2', N'/api/WmsPrepMaterialNo/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-08-24 22:05:13.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'369', N'删除', N'365', NULL, N'2', N'/api/WmsPrepMaterialNo/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-08-24 22:05:13.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'370', N'红牌物料管控', N'217', N'ant-design:audit-outlined', N'1', N'/wms/materialControl', N'wms/materialControl/index', N'1', N'1', N'0', N'0', NULL, N'7', N'1', N'2024-08-25 10:27:23.000', N'1', N'2025-02-10 14:56:05.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'371', N'生产领料单', N'217', N'ep:memo', N'1', N'/wms/pickMaterialNo', N'/wms/pickMaterialNo/index', N'1', N'1', N'0', N'0', NULL, N'9', N'1', N'2024-08-25 21:35:22.000', N'1', N'2025-02-10 14:56:05.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'372', N'查询', N'371', NULL, N'2', N'/api/WmsPickMaterialNo/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-08-25 21:35:22.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'373', N'新增', N'371', NULL, N'2', N'/api/WmsPickMaterialNo/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-08-25 21:35:22.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'374', N'编辑', N'371', NULL, N'2', N'/api/WmsPickMaterialNo/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-08-25 21:35:22.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'375', N'删除', N'371', NULL, N'2', N'/api/WmsPickMaterialNo/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-08-25 21:35:22.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'376', N'主数据群组', N'134', N'ant-design:google-plus-outlined', N'1', N'/base/partGroup', N'/base/partGroup/index', N'1', N'1', N'0', N'0', NULL, N'0', N'1', N'2024-08-27 09:46:57.000', N'1', N'2024-08-27 09:47:45.000', N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'377', N'查询', N'376', NULL, N'2', N'/api/PartGroup/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-08-27 09:46:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'378', N'新增', N'376', NULL, N'2', N'/api/PartGroup/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-08-27 09:46:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'379', N'编辑', N'376', NULL, N'2', N'/api/PartGroup/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-08-27 09:46:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'380', N'删除', N'376', NULL, N'2', N'/api/PartGroup/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-08-27 09:46:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'381', N'开工', N'185', NULL, N'2', N'/api/WorkOrder/StartWork', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-08-27 22:40:01.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'382', N'来料标签打印', N'217', N'ant-design:printer-outlined', N'1', N'/wms/labelPrint', N'wms/labelPrint/index', N'1', N'1', N'0', N'0', NULL, N'4', N'1', N'2024-09-10 21:00:01.000', N'1', N'2025-02-10 14:56:05.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'383', N'维修管理', N'219', N'ant-design:tool-outlined', N'0', N'/repair', NULL, N'0', N'1', N'0', N'0', NULL, N'7', N'1', N'2024-09-14 22:36:34.000', N'1', N'2025-02-10 14:56:17.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'384', N'故障维护', N'383', N'ant-design:delete-row-outlined', N'1', N'/equipment/fault', N'/equipment/fault/index', N'1', N'1', N'0', N'0', NULL, N'1', N'1', N'2024-09-14 22:39:07.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'385', N'查询', N'384', NULL, N'2', N'/api/EquipmentFault/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-09-14 22:39:07.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'386', N'新增', N'384', NULL, N'2', N'/api/EquipmentFault/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-09-14 22:39:07.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'387', N'编辑', N'384', NULL, N'2', N'/api/EquipmentFault/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-09-14 22:39:07.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'388', N'删除', N'384', NULL, N'2', N'/api/EquipmentFault/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-09-14 22:39:07.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'389', N'点检保养报告', N'219', N'ant-design:insert-row-above-outlined', N'1', N'/equipment/report', N'equipment/report/index', N'1', N'1', N'0', N'0', NULL, N'8', N'1', N'2024-09-28 17:03:04.000', N'1', N'2025-02-10 14:56:17.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'390', N'多语言', N'7', N'ant-design:translation-outlined', N'1', N'/dev/language', N'/dev/language/index', N'1', N'1', N'0', N'0', NULL, N'8', N'1', N'2024-09-30 15:16:22.000', N'1', N'2025-02-10 14:57:17.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'391', N'查询', N'390', NULL, N'2', N'/api/Language/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-09-30 15:16:23.000', N'1', N'2025-02-10 14:57:17.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'392', N'新增', N'390', NULL, N'2', N'/api/Language/Add', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-09-30 15:16:23.000', N'1', N'2025-02-10 14:57:17.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'393', N'编辑', N'390', NULL, N'2', N'/api/Language/Update', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-09-30 15:16:23.000', N'1', N'2025-02-10 14:57:17.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'394', N'删除', N'390', NULL, N'2', N'/api/Language/Delete', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-09-30 15:16:23.000', N'1', N'2025-02-10 14:57:17.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'395', N'产品锁定', N'99', N'ant-design:lock-outlined', N'1', N'/product/lock', N'product/lock/index', N'1', N'1', N'0', N'0', NULL, N'5', N'1', N'2024-10-01 10:28:02.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'396', N'产品解锁', N'99', N'ant-design:unlock-outlined', N'1', N'/product/unLock', N'product/unLock/index', N'1', N'1', N'0', N'0', NULL, N'6', N'1', N'2024-10-01 10:29:18.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'397', N'查询', N'396', NULL, N'2', N'/api/ProductLock/GetWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-10-02 12:50:03.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'398', N'解锁', N'396', NULL, N'2', N'/api/ProductLock/UnLock', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-10-02 12:50:33.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'399', N'查询配置', N'73', NULL, N'2', N'/api/Sequence/GetDetailsWithPage', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-10-12 13:26:47.000', N'1', N'2025-02-10 14:57:01.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'400', N'修改产线', N'191', NULL, N'2', N'/api/WorkOrder/ChangeLine', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'1', N'2024-10-12 14:04:17.000', N'1', N'2025-02-10 14:55:50.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'401', N'修改项目名称', N'92', NULL, N'2', N'/api/Template/UpdateProjectName', NULL, N'0', N'0', N'0', N'0', NULL, N'0', N'5', N'2024-10-21 17:30:40.000', N'1', N'2025-02-10 14:56:48.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'402', N'测试图表', N'308', N'ant-design:apple-outlined', N'1', N'/iframe/iot/test', N'https://yefeng.club/*dffBgw1CRMM=#/online/22', N'0', N'1', N'1', N'1', NULL, N'0', N'1', N'2024-11-02 19:15:45.000', N'1', N'2025-02-10 14:56:43.000', N'1')
GO

INSERT INTO [dbo].[sys_menu] ([Id], [MenuName], [ParentId], [Icon], [Type], [LinkUrl], [ViewPath], [IsKeepAlive], [IsShow], [IsExternal], [IsEmbed], [Redirect], [OrderSort], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'403', N'测试', N'308', N'ant-design:account-book-twotone', N'1', N'/iframe/iot/dcw', N'https://yefeng.club/*dffBgw1CRMM=#/online/23', N'0', N'1', N'1', N'1', NULL, N'0', N'1', N'2024-11-06 09:43:40.000', N'1', N'2025-02-10 14:56:43.000', N'1')
GO

SET IDENTITY_INSERT [dbo].[sys_menu] OFF
GO


-- ----------------------------
-- Auto increment value for sys_menu
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[sys_menu]', RESEED, 403)
GO


-- ----------------------------
-- Primary Key structure for table sys_menu
-- ----------------------------
ALTER TABLE [dbo].[sys_menu] ADD CONSTRAINT [PK_sys_menu_Id] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

