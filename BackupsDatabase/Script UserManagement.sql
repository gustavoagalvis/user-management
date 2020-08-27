DROP DATABASE [UserManagement]
GO
CREATE DATABASE [UserManagement]
GO
USE [UserManagement]
GO
ALTER TABLE [dbo].[users] DROP CONSTRAINT [FK_users_roles]
GO
ALTER TABLE [dbo].[permissions_roles] DROP CONSTRAINT [FK_permissions_roles_roles]
GO
ALTER TABLE [dbo].[permissions_roles] DROP CONSTRAINT [FK_permissions_roles_permissions]
GO
/****** Object:  Table [dbo].[users]    Script Date: 27/08/2020 7:53:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[users]') AND type in (N'U'))
DROP TABLE [dbo].[users]
GO
/****** Object:  Table [dbo].[roles]    Script Date: 27/08/2020 7:53:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[roles]') AND type in (N'U'))
DROP TABLE [dbo].[roles]
GO
/****** Object:  Table [dbo].[permissions_roles]    Script Date: 27/08/2020 7:53:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[permissions_roles]') AND type in (N'U'))
DROP TABLE [dbo].[permissions_roles]
GO
/****** Object:  Table [dbo].[permissions]    Script Date: 27/08/2020 7:53:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[permissions]') AND type in (N'U'))
DROP TABLE [dbo].[permissions]
GO
/****** Object:  Table [dbo].[permissions]    Script Date: 27/08/2020 7:53:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[permissions](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[public_name] [varchar](50) NOT NULL,
	[routes] [varchar](50) NOT NULL,
	[description] [varchar](max) NULL,
 CONSTRAINT [PK_permissions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[permissions_roles]    Script Date: 27/08/2020 7:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[permissions_roles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[role_id] [int] NOT NULL,
	[permission_id] [int] NOT NULL,
 CONSTRAINT [PK_permissions_roles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[roles]    Script Date: 27/08/2020 7:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[role] [varchar](50) NOT NULL,
	[description] [varchar](max) NULL,
 CONSTRAINT [PK_roles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 27/08/2020 7:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](max) NOT NULL,
	[fullname] [varchar](max) NOT NULL,
	[address] [varchar](50) NOT NULL,
	[phone] [varchar](50) NOT NULL,
	[email] [varchar](max) NOT NULL,
	[age] [int] NOT NULL,
	[roles_id] [int] NOT NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[permissions] ON 
GO
INSERT [dbo].[permissions] ([id], [name], [public_name], [routes], [description]) VALUES (2, N'welcome', N'bienvenida', N'/home', N'noticias de la empresa')
GO
INSERT [dbo].[permissions] ([id], [name], [public_name], [routes], [description]) VALUES (3, N'news', N'noticias', N'/news', N'noticias de la empresa')
GO
INSERT [dbo].[permissions] ([id], [name], [public_name], [routes], [description]) VALUES (4, N'user_list', N'listar', N'/user-list', N'listar usuario')
GO
INSERT [dbo].[permissions] ([id], [name], [public_name], [routes], [description]) VALUES (7, N'user_create', N'crear', N'/user-create', N'editar los usuario')
GO
INSERT [dbo].[permissions] ([id], [name], [public_name], [routes], [description]) VALUES (8, N'user_edit', N'editar', N'/user-list', N'crear los usuarios')
GO
INSERT [dbo].[permissions] ([id], [name], [public_name], [routes], [description]) VALUES (9, N'user_delete', N'eliminar', N'/user-list', N'eliminar usuarios')
GO
SET IDENTITY_INSERT [dbo].[permissions] OFF
GO
SET IDENTITY_INSERT [dbo].[permissions_roles] ON 
GO
INSERT [dbo].[permissions_roles] ([id], [role_id], [permission_id]) VALUES (1, 1, 2)
GO
INSERT [dbo].[permissions_roles] ([id], [role_id], [permission_id]) VALUES (2, 1, 3)
GO
INSERT [dbo].[permissions_roles] ([id], [role_id], [permission_id]) VALUES (3, 1, 4)
GO
INSERT [dbo].[permissions_roles] ([id], [role_id], [permission_id]) VALUES (6, 1, 7)
GO
INSERT [dbo].[permissions_roles] ([id], [role_id], [permission_id]) VALUES (7, 1, 8)
GO
INSERT [dbo].[permissions_roles] ([id], [role_id], [permission_id]) VALUES (8, 1, 9)
GO
INSERT [dbo].[permissions_roles] ([id], [role_id], [permission_id]) VALUES (9, 4, 2)
GO
INSERT [dbo].[permissions_roles] ([id], [role_id], [permission_id]) VALUES (10, 4, 3)
GO
INSERT [dbo].[permissions_roles] ([id], [role_id], [permission_id]) VALUES (11, 3, 2)
GO
INSERT [dbo].[permissions_roles] ([id], [role_id], [permission_id]) VALUES (12, 3, 3)
GO
INSERT [dbo].[permissions_roles] ([id], [role_id], [permission_id]) VALUES (13, 3, 4)
GO
INSERT [dbo].[permissions_roles] ([id], [role_id], [permission_id]) VALUES (14, 2, 2)
GO
INSERT [dbo].[permissions_roles] ([id], [role_id], [permission_id]) VALUES (15, 2, 3)
GO
INSERT [dbo].[permissions_roles] ([id], [role_id], [permission_id]) VALUES (16, 2, 4)
GO
INSERT [dbo].[permissions_roles] ([id], [role_id], [permission_id]) VALUES (17, 2, 8)
GO
SET IDENTITY_INSERT [dbo].[permissions_roles] OFF
GO
SET IDENTITY_INSERT [dbo].[roles] ON 
GO
INSERT [dbo].[roles] ([id], [role], [description]) VALUES (1, N'Administrador', NULL)
GO
INSERT [dbo].[roles] ([id], [role], [description]) VALUES (2, N'Editor', NULL)
GO
INSERT [dbo].[roles] ([id], [role], [description]) VALUES (3, N'Asistente', NULL)
GO
INSERT [dbo].[roles] ([id], [role], [description]) VALUES (4, N'Visitante', NULL)
GO
SET IDENTITY_INSERT [dbo].[roles] OFF
GO
SET IDENTITY_INSERT [dbo].[users] ON 
GO
INSERT [dbo].[users] ([id], [username], [password], [fullname], [address], [phone], [email], [age], [roles_id]) VALUES (3, N'admon', N'123', N'Gustavo Galvis', N'cra 12', N'3207812108', N'gustavoagalvis@gmail.com', 32, 1)
GO
INSERT [dbo].[users] ([id], [username], [password], [fullname], [address], [phone], [email], [age], [roles_id]) VALUES (5, N'editor', N'123', N'Carlos Sanchez', N'cra 24', N'3001234959', N'test@gmail.com', 20, 2)
GO
INSERT [dbo].[users] ([id], [username], [password], [fullname], [address], [phone], [email], [age], [roles_id]) VALUES (11, N'asistente', N'123', N'Juan Perez', N'cra 22', N'3007877377', N'juan@gmail.com', 20, 3)
GO
INSERT [dbo].[users] ([id], [username], [password], [fullname], [address], [phone], [email], [age], [roles_id]) VALUES (12, N'visitante', N'123', N'Carolina Rojas', N'cra 34', N'3134595589', N'carolina@gmail.com', 22, 4)
GO
SET IDENTITY_INSERT [dbo].[users] OFF
GO
ALTER TABLE [dbo].[permissions_roles]  WITH CHECK ADD  CONSTRAINT [FK_permissions_roles_permissions] FOREIGN KEY([permission_id])
REFERENCES [dbo].[permissions] ([id])
GO
ALTER TABLE [dbo].[permissions_roles] CHECK CONSTRAINT [FK_permissions_roles_permissions]
GO
ALTER TABLE [dbo].[permissions_roles]  WITH CHECK ADD  CONSTRAINT [FK_permissions_roles_roles] FOREIGN KEY([role_id])
REFERENCES [dbo].[roles] ([id])
GO
ALTER TABLE [dbo].[permissions_roles] CHECK CONSTRAINT [FK_permissions_roles_roles]
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [FK_users_roles] FOREIGN KEY([roles_id])
REFERENCES [dbo].[roles] ([id])
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_users_roles]
GO
