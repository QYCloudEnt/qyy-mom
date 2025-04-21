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

 Date: 07/03/2025 11:32:18
*/


-- ----------------------------
-- Table structure for sys_role_menu
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[sys_role_menu]') AND type IN ('U'))
	DROP TABLE [dbo].[sys_role_menu]
GO

CREATE TABLE [dbo].[sys_role_menu] (
  [Id] int  NOT NULL,
  [SysRoleId] int  NOT NULL,
  [SysMenuId] int  NOT NULL,
  [CreateId] int  NOT NULL,
  [CreateTime] datetime  NOT NULL,
  [UpdateId] int  NULL,
  [UpdateTime] datetime  NULL,
  [IsDeleted] bit DEFAULT '0' NOT NULL
)
GO

ALTER TABLE [dbo].[sys_role_menu] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'系统角色Id',
'SCHEMA', N'dbo',
'TABLE', N'sys_role_menu',
'COLUMN', N'SysRoleId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'系统菜单Id',
'SCHEMA', N'dbo',
'TABLE', N'sys_role_menu',
'COLUMN', N'SysMenuId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人',
'SCHEMA', N'dbo',
'TABLE', N'sys_role_menu',
'COLUMN', N'CreateId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'sys_role_menu',
'COLUMN', N'CreateTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改人',
'SCHEMA', N'dbo',
'TABLE', N'sys_role_menu',
'COLUMN', N'UpdateId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改时间',
'SCHEMA', N'dbo',
'TABLE', N'sys_role_menu',
'COLUMN', N'UpdateTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'是否删除 0:未删除  1:已删除',
'SCHEMA', N'dbo',
'TABLE', N'sys_role_menu',
'COLUMN', N'IsDeleted'
GO

EXEC sp_addextendedproperty
'MS_Description', N'角色和菜单关系表',
'SCHEMA', N'dbo',
'TABLE', N'sys_role_menu'
GO


-- ----------------------------
-- Records of sys_role_menu
-- ----------------------------
INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1', N'1', N'1', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'2', N'1', N'2', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'3', N'1', N'3', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'4', N'1', N'4', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'5', N'1', N'5', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'6', N'1', N'6', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'7', N'1', N'7', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'8', N'1', N'8', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'9', N'1', N'9', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'10', N'1', N'10', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'11', N'1', N'11', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'12', N'1', N'12', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'13', N'1', N'13', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'14', N'1', N'14', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'15', N'1', N'15', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'16', N'1', N'16', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'17', N'1', N'17', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'18', N'1', N'18', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'19', N'1', N'19', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'20', N'1', N'20', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'21', N'1', N'21', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'22', N'1', N'22', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'23', N'1', N'23', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'24', N'1', N'24', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'25', N'1', N'25', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'26', N'1', N'26', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'27', N'1', N'27', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'28', N'1', N'28', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'29', N'1', N'29', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'30', N'1', N'30', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'31', N'1', N'31', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'32', N'1', N'32', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'33', N'1', N'33', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'34', N'1', N'34', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'35', N'1', N'35', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'36', N'1', N'36', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'37', N'1', N'37', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'38', N'1', N'38', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'39', N'1', N'39', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'40', N'1', N'40', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'41', N'1', N'41', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'42', N'1', N'42', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'43', N'1', N'43', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'44', N'1', N'44', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'45', N'1', N'45', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'46', N'1', N'46', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'47', N'1', N'47', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'48', N'1', N'48', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'49', N'1', N'49', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'50', N'1', N'50', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'51', N'1', N'51', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'52', N'1', N'52', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'53', N'1', N'53', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'54', N'1', N'54', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'55', N'1', N'55', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'56', N'1', N'56', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'57', N'1', N'57', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'58', N'1', N'58', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'59', N'1', N'59', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'60', N'1', N'60', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'61', N'1', N'61', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'62', N'1', N'62', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'63', N'1', N'63', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'64', N'1', N'64', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'65', N'1', N'65', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'66', N'1', N'66', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'67', N'1', N'67', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'68', N'1', N'68', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'69', N'1', N'69', N'1', N'2024-02-08 16:14:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'70', N'1', N'69', N'1', N'2024-05-06 16:12:27.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'71', N'1', N'70', N'1', N'2024-05-17 10:05:12.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'72', N'1', N'71', N'1', N'2024-05-17 10:13:20.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'73', N'1', N'72', N'1', N'2024-05-19 15:59:42.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'74', N'1', N'73', N'1', N'2024-05-19 16:01:29.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'75', N'1', N'74', N'1', N'2024-05-19 16:01:29.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'76', N'1', N'75', N'1', N'2024-05-19 16:01:29.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'77', N'1', N'76', N'1', N'2024-05-19 16:01:29.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'78', N'1', N'77', N'1', N'2024-05-19 16:01:29.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'79', N'1', N'78', N'1', N'2024-05-23 14:06:45.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'80', N'1', N'79', N'1', N'2024-05-23 14:07:09.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'81', N'1', N'80', N'1', N'2024-05-23 14:08:03.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'82', N'1', N'81', N'1', N'2024-05-23 14:08:41.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'83', N'1', N'82', N'1', N'2024-07-21 14:58:04.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'84', N'1', N'83', N'1', N'2024-08-10 15:51:49.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'85', N'1', N'84', N'1', N'2024-08-22 22:50:37.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'86', N'1', N'85', N'1', N'2024-08-22 22:50:51.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'87', N'1', N'86', N'1', N'2024-09-04 17:11:39.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'88', N'1', N'87', N'1', N'2024-09-11 14:35:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'89', N'1', N'88', N'1', N'2024-09-13 19:36:16.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'90', N'2', N'7', N'1', N'2024-11-02 17:18:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'91', N'2', N'9', N'1', N'2024-11-02 17:18:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'92', N'2', N'27', N'1', N'2024-11-02 17:18:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'93', N'2', N'36', N'1', N'2024-11-02 17:18:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'94', N'2', N'38', N'1', N'2024-11-02 17:18:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'95', N'2', N'39', N'1', N'2024-11-02 17:18:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'96', N'2', N'40', N'1', N'2024-11-02 17:18:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'97', N'2', N'41', N'1', N'2024-11-02 17:18:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'98', N'2', N'42', N'1', N'2024-11-02 17:18:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'99', N'2', N'43', N'1', N'2024-11-02 17:18:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'100', N'2', N'44', N'1', N'2024-11-02 17:18:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'101', N'2', N'45', N'1', N'2024-11-02 17:18:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'102', N'2', N'47', N'1', N'2024-11-02 17:18:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'103', N'2', N'48', N'1', N'2024-11-02 17:18:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'104', N'2', N'49', N'1', N'2024-11-02 17:18:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'105', N'2', N'60', N'1', N'2024-11-02 17:18:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'106', N'2', N'61', N'1', N'2024-11-02 17:18:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'107', N'2', N'62', N'1', N'2024-11-02 17:18:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'108', N'2', N'63', N'1', N'2024-11-02 17:18:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'109', N'2', N'65', N'1', N'2024-11-02 17:18:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'110', N'2', N'66', N'1', N'2024-11-02 17:18:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'111', N'2', N'67', N'1', N'2024-11-02 17:18:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'112', N'2', N'68', N'1', N'2024-11-02 17:18:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'113', N'2', N'82', N'1', N'2024-11-02 17:18:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'114', N'2', N'83', N'1', N'2024-11-02 17:18:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'115', N'2', N'84', N'1', N'2024-11-02 17:18:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'116', N'2', N'87', N'1', N'2024-11-02 17:18:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'117', N'1', N'89', N'1', N'2024-01-05 13:32:19.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'118', N'1', N'90', N'1', N'2024-01-11 10:43:49.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'119', N'1', N'91', N'1', N'2024-01-11 10:44:31.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'120', N'1', N'92', N'1', N'2024-03-04 21:37:29.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'121', N'1', N'93', N'1', N'2024-03-04 21:42:05.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'122', N'1', N'94', N'1', N'2024-03-04 21:42:35.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'123', N'1', N'95', N'1', N'2024-03-04 21:42:52.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'124', N'1', N'96', N'1', N'2024-03-04 21:43:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'125', N'1', N'97', N'1', N'2024-03-06 21:02:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'126', N'1', N'98', N'1', N'2024-03-08 13:38:38.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'127', N'1', N'99', N'1', N'2024-03-19 16:55:05.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'128', N'1', N'102', N'1', N'2024-03-19 21:58:40.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'129', N'1', N'103', N'1', N'2024-03-19 21:58:40.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'130', N'1', N'104', N'1', N'2024-03-19 21:58:40.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'131', N'1', N'105', N'1', N'2024-03-19 21:58:40.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'132', N'1', N'106', N'1', N'2024-03-19 21:58:40.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'133', N'1', N'107', N'1', N'2024-03-27 10:32:26.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'134', N'1', N'108', N'1', N'2024-03-27 10:40:28.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'135', N'1', N'109', N'1', N'2024-03-27 10:40:28.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'136', N'1', N'110', N'1', N'2024-03-27 10:40:28.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'137', N'1', N'111', N'1', N'2024-03-27 10:40:28.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'138', N'1', N'112', N'1', N'2024-03-27 10:40:28.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'139', N'1', N'113', N'1', N'2024-03-27 11:22:23.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'140', N'1', N'114', N'1', N'2024-03-27 11:22:23.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'141', N'1', N'115', N'1', N'2024-03-27 11:22:23.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'142', N'1', N'116', N'1', N'2024-03-27 11:22:23.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'143', N'1', N'117', N'1', N'2024-03-27 11:22:23.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'144', N'1', N'118', N'1', N'2024-03-27 11:24:54.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'145', N'1', N'119', N'1', N'2024-03-27 11:24:54.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'146', N'1', N'120', N'1', N'2024-03-27 11:24:54.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'147', N'1', N'121', N'1', N'2024-03-27 11:24:54.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'148', N'1', N'122', N'1', N'2024-03-27 11:24:54.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'149', N'1', N'123', N'1', N'2024-03-27 11:26:49.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'150', N'1', N'124', N'1', N'2024-03-27 11:26:49.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'151', N'1', N'125', N'1', N'2024-03-27 11:26:49.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'152', N'1', N'126', N'1', N'2024-03-27 11:26:49.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'153', N'1', N'127', N'1', N'2024-03-27 11:26:49.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'154', N'1', N'128', N'1', N'2024-04-02 23:16:46.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'155', N'1', N'129', N'1', N'2024-04-02 23:25:18.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'156', N'1', N'130', N'1', N'2024-04-02 23:25:18.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'157', N'1', N'131', N'1', N'2024-04-02 23:25:18.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'158', N'1', N'132', N'1', N'2024-04-02 23:25:18.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'159', N'1', N'133', N'1', N'2024-04-02 23:25:18.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'160', N'1', N'134', N'1', N'2024-04-07 16:13:43.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'161', N'1', N'135', N'1', N'2024-04-07 16:19:31.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'162', N'1', N'136', N'1', N'2024-04-07 16:19:31.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'163', N'1', N'137', N'1', N'2024-04-07 16:19:31.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'164', N'1', N'138', N'1', N'2024-04-07 16:19:31.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'165', N'1', N'139', N'1', N'2024-04-07 16:19:31.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'166', N'1', N'140', N'1', N'2024-04-07 16:25:55.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'167', N'1', N'141', N'1', N'2024-04-07 16:25:55.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'168', N'1', N'142', N'1', N'2024-04-07 16:25:55.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'169', N'1', N'143', N'1', N'2024-04-07 16:25:55.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'170', N'1', N'144', N'1', N'2024-04-07 16:25:55.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'171', N'1', N'145', N'1', N'2024-04-07 16:29:07.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'172', N'1', N'146', N'1', N'2024-04-07 16:29:07.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'173', N'1', N'147', N'1', N'2024-04-07 16:29:07.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'174', N'1', N'148', N'1', N'2024-04-07 16:29:07.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'175', N'1', N'149', N'1', N'2024-04-07 16:29:07.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'176', N'1', N'150', N'1', N'2024-04-09 16:35:50.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'177', N'1', N'151', N'1', N'2024-04-09 16:35:50.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'178', N'1', N'152', N'1', N'2024-04-09 16:35:50.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'179', N'1', N'153', N'1', N'2024-04-09 16:35:50.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'180', N'1', N'154', N'1', N'2024-04-09 16:35:50.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'181', N'1', N'155', N'1', N'2024-04-11 11:22:28.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'182', N'1', N'156', N'1', N'2024-04-11 11:22:28.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'183', N'1', N'157', N'1', N'2024-04-11 11:22:28.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'184', N'1', N'158', N'1', N'2024-04-11 11:22:28.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'185', N'1', N'159', N'1', N'2024-04-11 11:22:28.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'186', N'1', N'160', N'1', N'2024-04-11 11:24:40.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'187', N'1', N'161', N'1', N'2024-04-11 11:24:40.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'188', N'1', N'162', N'1', N'2024-04-11 11:24:40.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'189', N'1', N'163', N'1', N'2024-04-11 11:24:40.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'190', N'1', N'164', N'1', N'2024-04-11 11:24:40.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'191', N'1', N'165', N'1', N'2024-04-12 14:41:19.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'192', N'1', N'166', N'1', N'2024-04-12 14:41:19.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'193', N'1', N'167', N'1', N'2024-04-12 14:41:19.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'194', N'1', N'168', N'1', N'2024-04-12 14:41:19.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'195', N'1', N'169', N'1', N'2024-04-12 14:41:19.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'196', N'1', N'170', N'1', N'2024-04-17 14:57:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'197', N'1', N'171', N'1', N'2024-04-17 14:57:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'198', N'1', N'172', N'1', N'2024-04-17 14:57:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'199', N'1', N'173', N'1', N'2024-04-17 14:57:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'200', N'1', N'174', N'1', N'2024-04-17 14:57:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'201', N'1', N'175', N'1', N'2024-04-17 14:59:02.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'202', N'1', N'176', N'1', N'2024-04-17 14:59:02.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'203', N'1', N'177', N'1', N'2024-04-17 14:59:02.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'204', N'1', N'178', N'1', N'2024-04-17 14:59:02.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'205', N'1', N'179', N'1', N'2024-04-17 14:59:02.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'206', N'1', N'180', N'1', N'2024-04-17 17:15:35.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'207', N'1', N'181', N'1', N'2024-04-17 17:15:35.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'208', N'1', N'182', N'1', N'2024-04-17 17:15:35.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'209', N'1', N'183', N'1', N'2024-04-17 17:15:35.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'210', N'1', N'184', N'1', N'2024-04-17 17:15:35.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'211', N'1', N'185', N'1', N'2024-04-21 20:56:09.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'212', N'1', N'186', N'1', N'2024-04-21 20:56:09.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'213', N'1', N'187', N'1', N'2024-04-21 20:56:09.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'214', N'1', N'188', N'1', N'2024-04-21 20:56:09.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'215', N'1', N'189', N'1', N'2024-04-21 20:56:09.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'216', N'1', N'190', N'1', N'2024-04-22 17:20:02.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'217', N'1', N'191', N'1', N'2024-04-23 21:27:01.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'218', N'1', N'192', N'1', N'2024-04-25 20:49:13.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'219', N'1', N'193', N'1', N'2024-05-04 17:10:17.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'220', N'1', N'194', N'1', N'2024-05-04 17:12:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'221', N'1', N'195', N'1', N'2024-05-09 15:00:44.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'222', N'1', N'196', N'1', N'2024-05-09 15:04:12.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'223', N'1', N'197', N'1', N'2024-05-09 15:04:12.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'224', N'1', N'198', N'1', N'2024-05-09 15:04:12.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'225', N'1', N'199', N'1', N'2024-05-09 15:04:12.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'226', N'1', N'200', N'1', N'2024-05-09 15:04:12.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'227', N'1', N'201', N'1', N'2024-05-09 15:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'228', N'1', N'202', N'1', N'2024-05-09 15:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'229', N'1', N'203', N'1', N'2024-05-09 15:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'230', N'1', N'204', N'1', N'2024-05-09 15:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'231', N'1', N'205', N'1', N'2024-05-09 15:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'232', N'1', N'206', N'1', N'2024-05-09 15:35:35.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'233', N'1', N'207', N'1', N'2024-05-10 11:26:59.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'234', N'1', N'208', N'1', N'2024-05-12 22:27:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'235', N'1', N'209', N'1', N'2024-05-12 22:27:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'236', N'1', N'210', N'1', N'2024-05-12 22:27:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'237', N'1', N'211', N'1', N'2024-05-12 22:27:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'238', N'1', N'212', N'1', N'2024-05-12 22:27:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'239', N'1', N'213', N'1', N'2024-05-13 14:53:16.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'240', N'1', N'214', N'1', N'2024-05-13 15:32:47.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'241', N'1', N'215', N'1', N'2024-05-13 15:33:12.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'242', N'1', N'216', N'1', N'2024-05-13 15:33:51.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'243', N'1', N'217', N'1', N'2024-05-15 15:30:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'244', N'1', N'218', N'1', N'2024-05-15 15:34:33.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'245', N'1', N'219', N'1', N'2024-05-15 15:37:58.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'246', N'1', N'220', N'1', N'2024-05-15 15:42:03.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'247', N'1', N'221', N'1', N'2024-05-15 15:49:20.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'248', N'1', N'222', N'1', N'2024-05-15 15:49:20.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'249', N'1', N'223', N'1', N'2024-05-15 15:49:20.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'250', N'1', N'224', N'1', N'2024-05-15 15:49:20.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'251', N'1', N'225', N'1', N'2024-05-15 15:49:20.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'252', N'1', N'226', N'1', N'2024-05-15 17:12:42.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'253', N'1', N'227', N'1', N'2024-05-15 17:12:42.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'254', N'1', N'228', N'1', N'2024-05-15 17:12:42.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'255', N'1', N'229', N'1', N'2024-05-15 17:12:42.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'256', N'1', N'230', N'1', N'2024-05-15 17:12:42.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'257', N'1', N'231', N'1', N'2024-05-17 09:42:47.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'258', N'1', N'232', N'1', N'2024-05-17 15:50:14.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'259', N'1', N'233', N'1', N'2024-05-17 15:50:14.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'260', N'1', N'234', N'1', N'2024-05-17 15:50:14.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'261', N'1', N'235', N'1', N'2024-05-17 15:50:14.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'262', N'1', N'236', N'1', N'2024-05-17 15:50:14.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'263', N'1', N'237', N'1', N'2024-05-29 17:19:16.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'264', N'1', N'238', N'1', N'2024-05-29 17:19:16.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'265', N'1', N'239', N'1', N'2024-05-29 17:19:16.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'266', N'1', N'240', N'1', N'2024-05-29 17:19:16.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'267', N'1', N'241', N'1', N'2024-05-29 17:19:16.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'268', N'1', N'242', N'1', N'2024-05-30 08:47:30.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'269', N'1', N'243', N'1', N'2024-06-03 13:32:10.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'270', N'1', N'244', N'1', N'2024-06-03 13:33:16.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'271', N'1', N'245', N'1', N'2024-06-06 21:47:33.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'272', N'1', N'246', N'1', N'2024-06-06 21:47:33.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'273', N'1', N'247', N'1', N'2024-06-06 21:47:33.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'274', N'1', N'248', N'1', N'2024-06-06 21:47:33.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'275', N'1', N'249', N'1', N'2024-06-06 21:47:33.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'276', N'1', N'250', N'1', N'2024-06-09 19:55:52.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'277', N'1', N'251', N'1', N'2024-06-09 20:16:30.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'278', N'1', N'252', N'1', N'2024-06-09 20:16:30.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'279', N'1', N'253', N'1', N'2024-06-09 20:16:30.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'280', N'1', N'254', N'1', N'2024-06-09 20:16:30.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'281', N'1', N'255', N'1', N'2024-06-09 20:16:30.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'282', N'1', N'256', N'1', N'2024-06-09 20:55:45.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'283', N'1', N'257', N'1', N'2024-06-09 20:55:45.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'284', N'1', N'258', N'1', N'2024-06-09 20:55:45.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'285', N'1', N'259', N'1', N'2024-06-09 20:55:45.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'286', N'1', N'260', N'1', N'2024-06-09 20:55:45.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'287', N'1', N'261', N'1', N'2024-06-10 21:15:59.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'288', N'1', N'262', N'1', N'2024-06-10 21:15:59.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'289', N'1', N'263', N'1', N'2024-06-10 21:15:59.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'290', N'1', N'264', N'1', N'2024-06-10 21:15:59.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'291', N'1', N'265', N'1', N'2024-06-10 21:15:59.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'292', N'1', N'266', N'1', N'2024-06-12 17:00:06.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'293', N'1', N'267', N'1', N'2024-06-12 17:00:06.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'294', N'1', N'268', N'1', N'2024-06-12 17:00:06.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'295', N'1', N'269', N'1', N'2024-06-12 17:00:06.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'296', N'1', N'270', N'1', N'2024-06-12 17:00:06.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'297', N'1', N'271', N'1', N'2024-06-12 17:26:16.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'298', N'1', N'272', N'1', N'2024-06-12 17:26:16.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'299', N'1', N'273', N'1', N'2024-06-12 17:26:16.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'300', N'1', N'274', N'1', N'2024-06-12 17:26:16.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'301', N'1', N'275', N'1', N'2024-06-12 17:26:16.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'302', N'2', N'72', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'303', N'2', N'102', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'304', N'2', N'103', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'305', N'2', N'104', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'306', N'2', N'105', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'307', N'2', N'106', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'308', N'2', N'107', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'309', N'2', N'108', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'310', N'2', N'109', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'311', N'2', N'110', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'312', N'2', N'111', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'313', N'2', N'112', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'314', N'2', N'113', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'315', N'2', N'114', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'316', N'2', N'115', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'317', N'2', N'116', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'318', N'2', N'117', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'319', N'2', N'123', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'320', N'2', N'124', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'321', N'2', N'125', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'322', N'2', N'126', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'323', N'2', N'127', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'324', N'2', N'128', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'325', N'2', N'129', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'326', N'2', N'130', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'327', N'2', N'131', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'328', N'2', N'132', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'329', N'2', N'133', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'330', N'2', N'134', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'331', N'2', N'135', N'1', N'2024-06-14 22:06:25.000', N'1', N'2024-10-02 12:57:03.000', N'1')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'332', N'2', N'136', N'1', N'2024-06-14 22:06:25.000', N'1', N'2024-10-02 12:57:03.000', N'1')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'333', N'2', N'137', N'1', N'2024-06-14 22:06:25.000', N'1', N'2024-10-02 12:57:03.000', N'1')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'334', N'2', N'138', N'1', N'2024-06-14 22:06:25.000', N'1', N'2024-10-02 12:57:03.000', N'1')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'335', N'2', N'139', N'1', N'2024-06-14 22:06:25.000', N'1', N'2024-10-02 12:57:03.000', N'1')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'336', N'2', N'140', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'337', N'2', N'141', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'338', N'2', N'142', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'339', N'2', N'143', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'340', N'2', N'144', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'341', N'2', N'145', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'342', N'2', N'146', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'343', N'2', N'147', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'344', N'2', N'148', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'345', N'2', N'149', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'346', N'2', N'150', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'347', N'2', N'151', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'348', N'2', N'152', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'349', N'2', N'153', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'350', N'2', N'154', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'351', N'2', N'170', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'352', N'2', N'171', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'353', N'2', N'172', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'354', N'2', N'173', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'355', N'2', N'174', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'356', N'2', N'175', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'357', N'2', N'176', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'358', N'2', N'177', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'359', N'2', N'178', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'360', N'2', N'179', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'361', N'2', N'193', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'362', N'2', N'194', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'363', N'2', N'195', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'364', N'2', N'196', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'365', N'2', N'197', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'366', N'2', N'198', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'367', N'2', N'199', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'368', N'2', N'200', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'369', N'2', N'201', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'370', N'2', N'202', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'371', N'2', N'203', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'372', N'2', N'204', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'373', N'2', N'205', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'374', N'2', N'208', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'375', N'2', N'209', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'376', N'2', N'210', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'377', N'2', N'211', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'378', N'2', N'212', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'379', N'2', N'214', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'380', N'2', N'215', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'381', N'2', N'244', N'1', N'2024-06-14 22:06:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'382', N'2', N'2', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'383', N'2', N'3', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'384', N'2', N'4', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'385', N'2', N'31', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'386', N'2', N'37', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'387', N'2', N'73', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'388', N'2', N'92', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'389', N'2', N'180', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'390', N'2', N'237', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'391', N'2', N'1', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'392', N'2', N'206', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'393', N'2', N'99', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'394', N'2', N'185', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'395', N'2', N'191', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'396', N'2', N'186', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'397', N'2', N'187', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'398', N'2', N'188', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'399', N'2', N'189', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'400', N'2', N'190', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'401', N'2', N'192', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'402', N'2', N'207', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'403', N'2', N'238', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'404', N'2', N'239', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'405', N'2', N'240', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'406', N'2', N'241', N'1', N'2024-06-14 22:10:11.000', N'1', N'2024-06-18 20:59:54.000', N'1')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'407', N'2', N'217', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'408', N'2', N'218', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'409', N'2', N'219', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'410', N'2', N'221', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'411', N'2', N'226', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'412', N'2', N'245', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'413', N'2', N'250', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'414', N'2', N'266', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'415', N'2', N'222', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'416', N'2', N'223', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'417', N'2', N'224', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'418', N'2', N'225', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'419', N'2', N'227', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'420', N'2', N'228', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'421', N'2', N'229', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'422', N'2', N'230', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'423', N'2', N'231', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'424', N'2', N'246', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'425', N'2', N'247', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'426', N'2', N'248', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'427', N'2', N'249', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'428', N'2', N'251', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'429', N'2', N'256', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'430', N'2', N'261', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'431', N'2', N'271', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'432', N'2', N'267', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'433', N'2', N'268', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'434', N'2', N'269', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'435', N'2', N'270', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'436', N'2', N'252', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'437', N'2', N'253', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'438', N'2', N'254', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'439', N'2', N'255', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'440', N'2', N'257', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'441', N'2', N'258', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'442', N'2', N'259', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'443', N'2', N'260', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'444', N'2', N'262', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'445', N'2', N'263', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'446', N'2', N'264', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'447', N'2', N'265', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'448', N'2', N'272', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'449', N'2', N'273', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'450', N'2', N'274', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'451', N'2', N'275', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'452', N'2', N'8', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'453', N'2', N'28', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'454', N'2', N'74', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'455', N'2', N'75', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'456', N'2', N'76', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'457', N'2', N'78', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'458', N'2', N'79', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'459', N'2', N'80', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'460', N'2', N'81', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'461', N'2', N'181', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'462', N'2', N'182', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'463', N'2', N'232', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'464', N'2', N'233', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'465', N'2', N'234', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'466', N'2', N'235', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'467', N'2', N'236', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'468', N'2', N'93', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'469', N'2', N'94', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'470', N'2', N'95', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'471', N'2', N'97', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'472', N'2', N'98', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'473', N'2', N'213', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'474', N'2', N'216', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'475', N'2', N'243', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'476', N'2', N'155', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'477', N'2', N'156', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'478', N'2', N'157', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'479', N'2', N'158', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'480', N'2', N'159', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'481', N'2', N'160', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'482', N'2', N'161', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'483', N'2', N'162', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'484', N'2', N'163', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'485', N'2', N'164', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'486', N'2', N'165', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'487', N'2', N'166', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'488', N'2', N'167', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'489', N'2', N'168', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'490', N'2', N'169', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'491', N'2', N'51', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'492', N'2', N'52', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'493', N'2', N'53', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'494', N'2', N'55', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'495', N'2', N'56', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'496', N'2', N'57', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'497', N'2', N'58', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'498', N'2', N'59', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'499', N'2', N'5', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'500', N'2', N'6', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'501', N'2', N'11', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'502', N'2', N'15', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'503', N'2', N'19', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'504', N'2', N'23', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'505', N'2', N'24', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'506', N'2', N'25', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'507', N'2', N'26', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'508', N'2', N'32', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'509', N'2', N'33', N'1', N'2024-06-14 22:10:11.000', N'1', N'2024-06-14 22:11:08.000', N'1')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'510', N'2', N'220', N'1', N'2024-06-14 22:10:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'511', N'2', N'242', N'2', N'2024-06-14 22:21:23.000', N'2', N'2024-06-14 22:21:49.000', N'1')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'512', N'1', N'276', N'1', N'2024-06-18 17:15:49.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'513', N'2', N'242', N'1', N'2024-06-18 20:59:54.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'514', N'1', N'277', N'1', N'2024-06-19 09:24:14.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'515', N'1', N'278', N'1', N'2024-06-19 20:27:38.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'516', N'1', N'279', N'1', N'2024-06-19 20:27:38.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'517', N'1', N'280', N'1', N'2024-06-19 20:27:38.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'518', N'1', N'281', N'1', N'2024-06-19 20:27:38.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'519', N'1', N'282', N'1', N'2024-06-19 20:27:38.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'520', N'1', N'283', N'1', N'2024-06-19 20:32:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'521', N'1', N'284', N'1', N'2024-06-19 20:32:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'522', N'1', N'285', N'1', N'2024-06-19 20:32:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'523', N'1', N'286', N'1', N'2024-06-19 20:32:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'524', N'1', N'287', N'1', N'2024-06-19 20:32:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'525', N'1', N'288', N'1', N'2024-06-19 21:26:12.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'526', N'1', N'289', N'1', N'2024-06-19 21:26:12.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'527', N'1', N'290', N'1', N'2024-06-19 21:26:12.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'528', N'1', N'291', N'1', N'2024-06-19 21:26:12.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'529', N'1', N'292', N'1', N'2024-06-19 21:26:12.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'530', N'1', N'293', N'1', N'2024-06-20 14:32:02.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'531', N'1', N'294', N'1', N'2024-06-20 14:32:02.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'532', N'1', N'295', N'1', N'2024-06-20 14:32:02.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'533', N'1', N'296', N'1', N'2024-06-20 14:32:02.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'534', N'1', N'297', N'1', N'2024-06-20 14:32:02.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'535', N'1', N'298', N'1', N'2024-06-20 16:41:04.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'536', N'1', N'299', N'1', N'2024-06-20 16:41:04.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'537', N'1', N'300', N'1', N'2024-06-20 16:41:04.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'538', N'1', N'301', N'1', N'2024-06-20 16:41:04.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'539', N'1', N'302', N'1', N'2024-06-20 16:41:04.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'540', N'1', N'303', N'1', N'2024-06-25 15:34:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'541', N'1', N'304', N'1', N'2024-06-25 15:34:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'542', N'1', N'305', N'1', N'2024-06-25 15:34:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'543', N'1', N'306', N'1', N'2024-06-25 15:34:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'544', N'1', N'307', N'1', N'2024-06-25 15:34:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'545', N'1', N'308', N'1', N'2024-06-28 09:51:16.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'546', N'2', N'308', N'1', N'2024-06-28 11:36:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'547', N'2', N'278', N'1', N'2024-06-28 11:36:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'548', N'2', N'288', N'1', N'2024-06-28 11:36:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'549', N'2', N'293', N'1', N'2024-06-28 11:36:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'550', N'2', N'298', N'1', N'2024-06-28 11:36:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'551', N'2', N'279', N'1', N'2024-06-28 11:36:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'552', N'2', N'280', N'1', N'2024-06-28 11:36:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'553', N'2', N'281', N'1', N'2024-06-28 11:36:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'554', N'2', N'282', N'1', N'2024-06-28 11:36:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'555', N'2', N'289', N'1', N'2024-06-28 11:36:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'556', N'2', N'290', N'1', N'2024-06-28 11:36:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'557', N'2', N'291', N'1', N'2024-06-28 11:36:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'558', N'2', N'292', N'1', N'2024-06-28 11:36:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'559', N'2', N'294', N'1', N'2024-06-28 11:36:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'560', N'2', N'295', N'1', N'2024-06-28 11:36:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'561', N'2', N'296', N'1', N'2024-06-28 11:36:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'562', N'2', N'297', N'1', N'2024-06-28 11:36:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'563', N'2', N'299', N'1', N'2024-06-28 11:36:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'564', N'2', N'300', N'1', N'2024-06-28 11:36:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'565', N'2', N'301', N'1', N'2024-06-28 11:36:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'566', N'2', N'302', N'1', N'2024-06-28 11:36:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'567', N'1', N'309', N'1', N'2024-06-28 22:47:17.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'568', N'1', N'310', N'1', N'2024-06-29 09:12:41.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'569', N'1', N'311', N'1', N'2024-06-29 09:12:41.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'570', N'1', N'312', N'1', N'2024-06-29 09:12:41.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'571', N'1', N'313', N'1', N'2024-06-29 09:12:41.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'572', N'1', N'314', N'1', N'2024-06-29 09:12:41.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'573', N'1', N'315', N'1', N'2024-06-30 21:38:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'574', N'2', N'309', N'1', N'2024-06-30 21:47:18.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'575', N'2', N'311', N'1', N'2024-06-30 21:47:18.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'576', N'2', N'310', N'1', N'2024-06-30 21:47:18.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'577', N'2', N'312', N'1', N'2024-06-30 21:47:18.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'578', N'2', N'313', N'1', N'2024-06-30 21:47:18.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'579', N'2', N'314', N'1', N'2024-06-30 21:47:18.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'580', N'2', N'315', N'1', N'2024-06-30 21:47:18.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'581', N'2', N'70', N'1', N'2024-07-10 20:26:29.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'582', N'2', N'71', N'1', N'2024-07-10 20:26:29.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'583', N'1', N'316', N'1', N'2024-07-10 21:51:10.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'584', N'2', N'316', N'1', N'2024-07-10 21:51:35.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'585', N'1', N'317', N'1', N'2024-07-24 16:15:34.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'586', N'1', N'318', N'1', N'2024-07-24 16:15:34.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'587', N'1', N'319', N'1', N'2024-07-24 16:15:34.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'588', N'1', N'320', N'1', N'2024-07-24 16:15:34.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'589', N'1', N'321', N'1', N'2024-07-24 16:15:34.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'590', N'1', N'322', N'1', N'2024-07-24 16:17:39.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'591', N'1', N'323', N'1', N'2024-07-24 16:17:39.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'592', N'1', N'324', N'1', N'2024-07-24 16:17:39.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'593', N'1', N'325', N'1', N'2024-07-24 16:17:39.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'594', N'1', N'326', N'1', N'2024-07-24 16:17:39.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'595', N'1', N'327', N'1', N'2024-07-24 17:11:08.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'596', N'1', N'328', N'1', N'2024-07-24 17:11:08.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'597', N'1', N'329', N'1', N'2024-07-24 17:11:08.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'598', N'1', N'330', N'1', N'2024-07-24 17:11:08.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'599', N'1', N'331', N'1', N'2024-07-24 17:11:08.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'600', N'1', N'332', N'1', N'2024-07-25 16:25:37.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'601', N'1', N'333', N'1', N'2024-07-25 16:27:20.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'602', N'1', N'334', N'1', N'2024-07-25 16:27:20.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'603', N'1', N'335', N'1', N'2024-07-25 16:27:20.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'604', N'1', N'336', N'1', N'2024-07-25 16:27:20.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'605', N'1', N'337', N'1', N'2024-07-25 16:27:20.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'606', N'1', N'338', N'1', N'2024-07-26 11:19:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'607', N'1', N'339', N'1', N'2024-07-26 11:19:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'608', N'1', N'340', N'1', N'2024-07-26 11:19:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'609', N'1', N'341', N'1', N'2024-07-26 11:19:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'610', N'1', N'342', N'1', N'2024-07-26 11:19:25.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'611', N'1', N'343', N'1', N'2024-07-26 13:58:19.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'612', N'2', N'317', N'1', N'2024-07-27 19:30:47.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'613', N'2', N'322', N'1', N'2024-07-27 19:30:47.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'614', N'2', N'327', N'1', N'2024-07-27 19:30:47.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'615', N'2', N'332', N'1', N'2024-07-27 19:30:47.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'616', N'2', N'318', N'1', N'2024-07-27 19:30:47.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'617', N'2', N'319', N'1', N'2024-07-27 19:30:47.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'618', N'2', N'320', N'1', N'2024-07-27 19:30:47.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'619', N'2', N'321', N'1', N'2024-07-27 19:30:47.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'620', N'2', N'323', N'1', N'2024-07-27 19:30:47.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'621', N'2', N'324', N'1', N'2024-07-27 19:30:47.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'622', N'2', N'325', N'1', N'2024-07-27 19:30:47.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'623', N'2', N'326', N'1', N'2024-07-27 19:30:47.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'624', N'2', N'328', N'1', N'2024-07-27 19:30:47.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'625', N'2', N'329', N'1', N'2024-07-27 19:30:47.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'626', N'2', N'330', N'1', N'2024-07-27 19:30:47.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'627', N'2', N'331', N'1', N'2024-07-27 19:30:47.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'628', N'2', N'333', N'1', N'2024-07-27 19:30:47.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'629', N'2', N'334', N'1', N'2024-07-27 19:30:47.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'630', N'2', N'335', N'1', N'2024-07-27 19:30:47.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'631', N'2', N'336', N'1', N'2024-07-27 19:30:47.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'632', N'2', N'337', N'1', N'2024-07-27 19:30:47.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'633', N'2', N'338', N'1', N'2024-07-27 19:30:47.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'634', N'2', N'339', N'1', N'2024-07-27 19:30:47.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'635', N'2', N'340', N'1', N'2024-07-27 19:30:47.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'636', N'2', N'341', N'1', N'2024-07-27 19:30:47.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'637', N'2', N'342', N'1', N'2024-07-27 19:30:47.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'638', N'2', N'343', N'1', N'2024-07-27 19:30:47.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'639', N'1', N'344', N'1', N'2024-07-29 14:36:32.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'640', N'2', N'344', N'1', N'2024-07-30 22:35:45.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'641', N'1', N'345', N'1', N'2024-08-09 19:48:34.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'642', N'1', N'346', N'1', N'2024-08-11 19:13:21.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'643', N'2', N'345', N'1', N'2024-08-11 19:54:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'644', N'2', N'346', N'1', N'2024-08-11 19:54:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'645', N'1', N'347', N'1', N'2024-08-12 11:42:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'646', N'2', N'347', N'1', N'2024-08-12 17:32:11.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'647', N'1', N'348', N'1', N'2024-08-12 21:50:37.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'648', N'1', N'349', N'1', N'2024-08-12 21:50:37.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'649', N'1', N'350', N'1', N'2024-08-12 21:50:37.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'650', N'1', N'351', N'1', N'2024-08-12 21:50:37.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'651', N'1', N'352', N'1', N'2024-08-12 21:50:37.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'652', N'2', N'348', N'1', N'2024-08-12 22:02:34.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'653', N'2', N'349', N'1', N'2024-08-12 22:02:34.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'654', N'2', N'350', N'1', N'2024-08-12 22:02:34.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'655', N'2', N'351', N'1', N'2024-08-12 22:02:34.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'656', N'1', N'353', N'1', N'2024-08-13 21:14:12.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'657', N'1', N'354', N'1', N'2024-08-13 21:14:12.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'658', N'1', N'355', N'1', N'2024-08-13 21:14:12.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'659', N'1', N'356', N'1', N'2024-08-13 21:14:12.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'660', N'1', N'357', N'1', N'2024-08-13 21:14:12.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'661', N'2', N'353', N'1', N'2024-08-13 22:29:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'662', N'2', N'354', N'1', N'2024-08-13 22:29:24.000', N'1', N'2024-08-14 22:03:08.000', N'1')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'663', N'2', N'355', N'1', N'2024-08-13 22:29:24.000', N'1', N'2024-08-14 22:03:08.000', N'1')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'664', N'2', N'356', N'1', N'2024-08-13 22:29:24.000', N'1', N'2024-08-14 22:03:08.000', N'1')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'665', N'2', N'357', N'1', N'2024-08-13 22:29:24.000', N'1', N'2024-08-14 22:03:08.000', N'1')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'666', N'1', N'358', N'1', N'2024-08-14 11:32:30.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'667', N'2', N'358', N'1', N'2024-08-14 19:23:19.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'668', N'1', N'359', N'1', N'2024-08-14 22:00:04.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'669', N'1', N'360', N'1', N'2024-08-14 22:00:36.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'670', N'2', N'359', N'1', N'2024-08-14 22:03:08.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'671', N'2', N'360', N'1', N'2024-08-14 22:03:08.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'672', N'1', N'361', N'1', N'2024-08-16 17:13:37.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'673', N'1', N'362', N'1', N'2024-08-18 17:08:10.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'674', N'1', N'363', N'1', N'2024-08-18 19:18:52.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'675', N'1', N'364', N'1', N'2024-08-24 22:04:15.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'676', N'1', N'365', N'1', N'2024-08-24 22:05:13.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'677', N'1', N'366', N'1', N'2024-08-24 22:05:13.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'678', N'1', N'367', N'1', N'2024-08-24 22:05:13.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'679', N'1', N'368', N'1', N'2024-08-24 22:05:13.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'680', N'1', N'369', N'1', N'2024-08-24 22:05:13.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'681', N'1', N'370', N'1', N'2024-08-25 10:27:23.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'682', N'1', N'371', N'1', N'2024-08-25 21:35:22.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'683', N'1', N'372', N'1', N'2024-08-25 21:35:22.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'684', N'1', N'373', N'1', N'2024-08-25 21:35:22.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'685', N'1', N'374', N'1', N'2024-08-25 21:35:22.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'686', N'1', N'375', N'1', N'2024-08-25 21:35:22.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'687', N'1', N'376', N'1', N'2024-08-27 09:46:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'688', N'1', N'377', N'1', N'2024-08-27 09:46:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'689', N'1', N'378', N'1', N'2024-08-27 09:46:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'690', N'1', N'379', N'1', N'2024-08-27 09:46:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'691', N'1', N'380', N'1', N'2024-08-27 09:46:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'692', N'1', N'381', N'1', N'2024-08-27 22:40:01.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'693', N'1', N'382', N'1', N'2024-09-10 21:00:01.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'694', N'1', N'383', N'1', N'2024-09-14 22:36:34.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'695', N'1', N'384', N'1', N'2024-09-14 22:39:07.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'696', N'1', N'385', N'1', N'2024-09-14 22:39:07.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'697', N'1', N'386', N'1', N'2024-09-14 22:39:07.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'698', N'1', N'387', N'1', N'2024-09-14 22:39:07.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'699', N'1', N'388', N'1', N'2024-09-14 22:39:07.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'700', N'1', N'389', N'1', N'2024-09-28 17:03:05.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'701', N'1', N'390', N'1', N'2024-09-30 15:16:23.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'702', N'1', N'391', N'1', N'2024-09-30 15:16:23.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'703', N'1', N'392', N'1', N'2024-09-30 15:16:23.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'704', N'1', N'393', N'1', N'2024-09-30 15:16:23.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'705', N'1', N'394', N'1', N'2024-09-30 15:16:23.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'706', N'1', N'395', N'1', N'2024-10-01 10:28:02.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'707', N'1', N'396', N'1', N'2024-10-01 10:29:18.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'708', N'1', N'397', N'1', N'2024-10-02 12:50:03.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'709', N'1', N'398', N'1', N'2024-10-02 12:50:33.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'710', N'2', N'383', N'1', N'2024-10-02 12:57:03.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'711', N'2', N'365', N'1', N'2024-10-02 12:57:03.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'712', N'2', N'371', N'1', N'2024-10-02 12:57:03.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'713', N'2', N'390', N'1', N'2024-10-02 12:57:03.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'714', N'2', N'395', N'1', N'2024-10-02 12:57:03.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'715', N'2', N'396', N'1', N'2024-10-02 12:57:03.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'716', N'2', N'397', N'1', N'2024-10-02 12:57:03.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'717', N'2', N'398', N'1', N'2024-10-02 12:57:03.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'718', N'2', N'382', N'1', N'2024-10-02 12:57:03.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'719', N'2', N'364', N'1', N'2024-10-02 12:57:03.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'720', N'2', N'370', N'1', N'2024-10-02 12:57:03.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'721', N'2', N'366', N'1', N'2024-10-02 12:57:03.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'722', N'2', N'367', N'1', N'2024-10-02 12:57:03.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'723', N'2', N'368', N'1', N'2024-10-02 12:57:03.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'724', N'2', N'372', N'1', N'2024-10-02 12:57:03.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'725', N'2', N'373', N'1', N'2024-10-02 12:57:03.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'726', N'2', N'374', N'1', N'2024-10-02 12:57:03.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'727', N'2', N'389', N'1', N'2024-10-02 12:57:03.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'728', N'2', N'361', N'1', N'2024-10-02 12:57:03.000', N'1', N'2024-12-04 21:43:41.000', N'1')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'729', N'2', N'391', N'1', N'2024-10-02 12:57:03.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'730', N'2', N'392', N'1', N'2024-10-02 12:57:03.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'731', N'2', N'393', N'1', N'2024-10-02 12:57:03.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'732', N'3', N'1', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'733', N'3', N'2', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'734', N'3', N'3', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'735', N'3', N'4', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'736', N'3', N'5', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'737', N'3', N'6', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'738', N'3', N'7', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'739', N'3', N'8', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'740', N'3', N'9', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'741', N'3', N'10', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'742', N'3', N'11', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'743', N'3', N'12', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'744', N'3', N'13', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'745', N'3', N'14', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'746', N'3', N'15', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'747', N'3', N'16', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'748', N'3', N'17', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'749', N'3', N'19', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'750', N'3', N'20', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'751', N'3', N'21', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'752', N'3', N'22', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'753', N'3', N'23', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'754', N'3', N'24', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'755', N'3', N'25', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'756', N'3', N'26', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'757', N'3', N'27', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'758', N'3', N'28', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'759', N'3', N'29', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'760', N'3', N'31', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'761', N'3', N'32', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'762', N'3', N'33', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'763', N'3', N'34', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'764', N'3', N'35', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'765', N'3', N'36', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'766', N'3', N'37', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'767', N'3', N'38', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'768', N'3', N'39', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'769', N'3', N'40', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'770', N'3', N'41', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'771', N'3', N'42', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'772', N'3', N'43', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'773', N'3', N'44', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'774', N'3', N'45', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'775', N'3', N'46', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'776', N'3', N'47', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'777', N'3', N'48', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'778', N'3', N'49', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'779', N'3', N'50', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'780', N'3', N'51', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'781', N'3', N'52', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'782', N'3', N'53', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'783', N'3', N'54', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'784', N'3', N'55', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'785', N'3', N'56', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'786', N'3', N'57', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'787', N'3', N'58', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'788', N'3', N'59', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'789', N'3', N'60', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'790', N'3', N'61', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'791', N'3', N'62', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'792', N'3', N'63', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'793', N'3', N'64', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'794', N'3', N'65', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'795', N'3', N'66', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'796', N'3', N'67', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'797', N'3', N'68', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'798', N'3', N'70', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'799', N'3', N'71', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'800', N'3', N'72', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'801', N'3', N'73', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'802', N'3', N'74', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'803', N'3', N'75', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'804', N'3', N'76', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'805', N'3', N'78', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'806', N'3', N'79', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'807', N'3', N'80', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'808', N'3', N'81', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'809', N'3', N'82', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'810', N'3', N'83', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'811', N'3', N'84', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'812', N'3', N'85', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'813', N'3', N'86', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'814', N'3', N'87', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'815', N'3', N'92', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'816', N'3', N'93', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'817', N'3', N'94', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'818', N'3', N'95', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'819', N'3', N'96', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'820', N'3', N'97', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'821', N'3', N'98', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'822', N'3', N'99', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'823', N'3', N'102', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'824', N'3', N'103', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'825', N'3', N'104', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'826', N'3', N'105', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'827', N'3', N'106', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'828', N'3', N'107', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'829', N'3', N'108', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'830', N'3', N'109', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'831', N'3', N'110', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'832', N'3', N'111', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'833', N'3', N'112', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'834', N'3', N'113', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'835', N'3', N'114', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'836', N'3', N'115', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'837', N'3', N'116', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'838', N'3', N'117', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'839', N'3', N'123', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'840', N'3', N'124', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'841', N'3', N'125', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'842', N'3', N'126', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'843', N'3', N'127', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'844', N'3', N'128', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'845', N'3', N'129', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'846', N'3', N'130', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'847', N'3', N'131', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'848', N'3', N'132', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'849', N'3', N'133', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'850', N'3', N'134', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'851', N'3', N'140', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'852', N'3', N'141', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'853', N'3', N'142', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'854', N'3', N'143', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'855', N'3', N'144', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'856', N'3', N'145', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'857', N'3', N'146', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'858', N'3', N'147', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'859', N'3', N'148', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'860', N'3', N'149', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'861', N'3', N'150', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'862', N'3', N'151', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'863', N'3', N'152', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'864', N'3', N'153', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'865', N'3', N'154', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'866', N'3', N'155', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'867', N'3', N'156', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'868', N'3', N'157', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'869', N'3', N'158', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'870', N'3', N'159', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'871', N'3', N'160', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'872', N'3', N'161', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'873', N'3', N'162', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'874', N'3', N'163', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'875', N'3', N'164', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'876', N'3', N'165', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'877', N'3', N'166', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'878', N'3', N'167', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'879', N'3', N'168', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'880', N'3', N'169', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'881', N'3', N'170', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'882', N'3', N'171', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'883', N'3', N'172', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'884', N'3', N'173', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'885', N'3', N'174', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'886', N'3', N'175', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'887', N'3', N'176', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'888', N'3', N'177', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'889', N'3', N'178', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'890', N'3', N'179', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'891', N'3', N'180', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'892', N'3', N'181', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'893', N'3', N'182', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'894', N'3', N'183', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'895', N'3', N'184', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'896', N'3', N'185', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'897', N'3', N'186', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'898', N'3', N'187', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'899', N'3', N'188', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'900', N'3', N'189', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'901', N'3', N'190', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'902', N'3', N'191', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'903', N'3', N'192', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'904', N'3', N'193', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'905', N'3', N'194', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'906', N'3', N'195', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'907', N'3', N'196', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'908', N'3', N'197', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'909', N'3', N'198', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'910', N'3', N'199', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'911', N'3', N'200', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'912', N'3', N'201', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'913', N'3', N'202', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'914', N'3', N'203', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'915', N'3', N'204', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'916', N'3', N'205', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'917', N'3', N'206', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'918', N'3', N'207', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'919', N'3', N'208', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'920', N'3', N'209', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'921', N'3', N'210', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'922', N'3', N'211', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'923', N'3', N'212', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'924', N'3', N'213', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'925', N'3', N'214', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'926', N'3', N'215', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'927', N'3', N'216', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'928', N'3', N'217', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'929', N'3', N'218', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'930', N'3', N'219', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'931', N'3', N'220', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'932', N'3', N'221', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'933', N'3', N'222', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'934', N'3', N'223', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'935', N'3', N'224', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'936', N'3', N'225', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'937', N'3', N'226', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'938', N'3', N'227', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'939', N'3', N'228', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'940', N'3', N'229', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'941', N'3', N'230', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'942', N'3', N'231', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'943', N'3', N'232', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'944', N'3', N'233', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'945', N'3', N'234', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'946', N'3', N'235', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'947', N'3', N'236', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'948', N'3', N'237', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'949', N'3', N'238', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'950', N'3', N'239', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'951', N'3', N'240', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'952', N'3', N'241', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'953', N'3', N'242', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'954', N'3', N'243', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'955', N'3', N'244', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'956', N'3', N'245', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'957', N'3', N'246', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'958', N'3', N'247', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'959', N'3', N'248', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'960', N'3', N'249', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'961', N'3', N'250', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'962', N'3', N'251', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'963', N'3', N'252', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'964', N'3', N'253', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'965', N'3', N'254', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'966', N'3', N'255', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'967', N'3', N'256', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'968', N'3', N'257', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'969', N'3', N'258', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'970', N'3', N'259', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'971', N'3', N'260', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'972', N'3', N'261', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'973', N'3', N'262', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'974', N'3', N'263', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'975', N'3', N'264', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'976', N'3', N'265', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'977', N'3', N'266', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'978', N'3', N'267', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'979', N'3', N'268', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'980', N'3', N'269', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'981', N'3', N'270', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'982', N'3', N'271', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'983', N'3', N'272', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'984', N'3', N'273', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'985', N'3', N'274', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'986', N'3', N'275', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'987', N'3', N'276', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'988', N'3', N'277', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'989', N'3', N'278', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'990', N'3', N'279', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'991', N'3', N'280', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'992', N'3', N'281', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'993', N'3', N'282', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'994', N'3', N'288', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'995', N'3', N'289', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'996', N'3', N'290', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'997', N'3', N'291', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'998', N'3', N'292', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'999', N'3', N'293', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1000', N'3', N'294', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1001', N'3', N'295', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1002', N'3', N'296', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1003', N'3', N'297', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1004', N'3', N'298', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1005', N'3', N'299', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1006', N'3', N'300', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1007', N'3', N'301', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1008', N'3', N'302', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1009', N'3', N'303', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1010', N'3', N'304', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1011', N'3', N'305', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1012', N'3', N'306', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1013', N'3', N'307', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1014', N'3', N'308', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1015', N'3', N'309', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1016', N'3', N'310', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1017', N'3', N'311', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1018', N'3', N'312', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1019', N'3', N'313', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1020', N'3', N'314', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1021', N'3', N'315', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1022', N'3', N'316', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1023', N'3', N'317', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1024', N'3', N'318', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1025', N'3', N'319', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1026', N'3', N'320', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1027', N'3', N'321', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1028', N'3', N'322', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1029', N'3', N'323', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1030', N'3', N'324', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1031', N'3', N'325', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1032', N'3', N'326', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1033', N'3', N'327', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1034', N'3', N'328', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1035', N'3', N'329', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1036', N'3', N'330', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1037', N'3', N'331', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1038', N'3', N'332', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1039', N'3', N'333', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1040', N'3', N'334', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1041', N'3', N'335', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1042', N'3', N'336', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1043', N'3', N'337', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1044', N'3', N'338', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1045', N'3', N'339', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1046', N'3', N'340', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1047', N'3', N'341', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1048', N'3', N'342', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1049', N'3', N'343', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1050', N'3', N'344', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1051', N'3', N'345', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1052', N'3', N'346', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1053', N'3', N'347', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1054', N'3', N'348', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1055', N'3', N'349', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1056', N'3', N'350', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1057', N'3', N'351', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1058', N'3', N'352', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1059', N'3', N'353', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1060', N'3', N'358', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1061', N'3', N'359', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1062', N'3', N'360', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1063', N'3', N'361', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1064', N'3', N'364', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1065', N'3', N'365', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1066', N'3', N'366', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1067', N'3', N'367', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1068', N'3', N'368', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1069', N'3', N'369', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1070', N'3', N'370', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1071', N'3', N'371', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1072', N'3', N'372', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1073', N'3', N'373', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1074', N'3', N'374', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1075', N'3', N'375', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1076', N'3', N'376', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1077', N'3', N'377', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1078', N'3', N'378', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1079', N'3', N'379', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1080', N'3', N'380', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1081', N'3', N'381', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1082', N'3', N'382', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1083', N'3', N'383', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1084', N'3', N'384', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1085', N'3', N'385', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1086', N'3', N'386', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1087', N'3', N'387', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1088', N'3', N'388', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1089', N'3', N'389', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1090', N'3', N'390', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1091', N'3', N'391', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1092', N'3', N'392', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1093', N'3', N'393', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1094', N'3', N'394', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1095', N'3', N'395', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1096', N'3', N'396', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1097', N'3', N'397', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1098', N'3', N'398', N'1', N'2024-10-12 10:05:56.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1099', N'1', N'399', N'1', N'2024-10-12 13:26:47.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1100', N'2', N'399', N'1', N'2024-10-12 13:27:16.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1101', N'3', N'399', N'1', N'2024-10-12 13:27:32.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1102', N'1', N'400', N'1', N'2024-10-12 14:04:18.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1103', N'2', N'400', N'1', N'2024-10-12 14:04:33.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1104', N'3', N'400', N'1', N'2024-10-12 14:04:51.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1105', N'1', N'401', N'5', N'2024-10-21 17:30:40.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1106', N'2', N'401', N'5', N'2024-10-21 17:31:24.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1107', N'1', N'402', N'1', N'2024-11-02 19:15:45.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1108', N'1', N'403', N'1', N'2024-11-06 09:43:40.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1109', N'2', N'381', N'1', N'2024-11-13 20:25:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1110', N'2', N'276', N'1', N'2024-11-13 20:25:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1111', N'2', N'377', N'1', N'2024-11-13 20:25:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1112', N'2', N'378', N'1', N'2024-11-13 20:25:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1113', N'2', N'379', N'1', N'2024-11-13 20:25:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1114', N'2', N'380', N'1', N'2024-11-13 20:25:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1115', N'2', N'376', N'1', N'2024-11-13 20:25:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1116', N'2', N'303', N'1', N'2024-11-13 20:25:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1117', N'2', N'304', N'1', N'2024-11-13 20:25:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1118', N'2', N'305', N'1', N'2024-11-13 20:25:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1119', N'2', N'306', N'1', N'2024-11-13 20:25:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1120', N'2', N'307', N'1', N'2024-11-13 20:25:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1121', N'2', N'384', N'1', N'2024-11-13 20:25:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1122', N'2', N'385', N'1', N'2024-11-13 20:25:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1123', N'2', N'386', N'1', N'2024-11-13 20:25:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1124', N'2', N'387', N'1', N'2024-11-13 20:25:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1125', N'2', N'388', N'1', N'2024-11-13 20:25:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1126', N'2', N'277', N'1', N'2024-11-13 20:25:57.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1127', N'1', N'404', N'1', N'2024-12-03 22:13:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1128', N'1', N'405', N'1', N'2024-12-03 22:13:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1129', N'1', N'406', N'1', N'2024-12-03 22:13:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1130', N'1', N'407', N'1', N'2024-12-03 22:13:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1131', N'1', N'408', N'1', N'2024-12-03 22:13:00.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1132', N'2', N'404', N'1', N'2024-12-04 21:43:41.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1133', N'2', N'405', N'1', N'2024-12-04 21:43:41.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1134', N'2', N'406', N'1', N'2024-12-04 21:43:41.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1135', N'2', N'407', N'1', N'2024-12-04 21:43:41.000', NULL, NULL, N'0')
GO

INSERT INTO [dbo].[sys_role_menu] ([Id], [SysRoleId], [SysMenuId], [CreateId], [CreateTime], [UpdateId], [UpdateTime], [IsDeleted]) VALUES (N'1136', N'2', N'408', N'1', N'2024-12-04 21:43:41.000', NULL, NULL, N'0')
GO


-- ----------------------------
-- Primary Key structure for table sys_role_menu
-- ----------------------------
ALTER TABLE [dbo].[sys_role_menu] ADD CONSTRAINT [PK_sys_role_menu_Id] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

