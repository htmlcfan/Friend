USE [master]
GO
/****** Object:  Database [Friend]    Script Date: 11/04/2016 21:00:31 ******/
CREATE DATABASE [Friend] ON  PRIMARY 
( NAME = N'Friend', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Friend.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Friend_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Friend_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Friend] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Friend].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Friend] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Friend] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Friend] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Friend] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Friend] SET ARITHABORT OFF
GO
ALTER DATABASE [Friend] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Friend] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Friend] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Friend] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Friend] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Friend] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Friend] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Friend] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Friend] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Friend] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Friend] SET  DISABLE_BROKER
GO
ALTER DATABASE [Friend] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Friend] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Friend] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Friend] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Friend] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Friend] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Friend] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Friend] SET  READ_WRITE
GO
ALTER DATABASE [Friend] SET RECOVERY FULL
GO
ALTER DATABASE [Friend] SET  MULTI_USER
GO
ALTER DATABASE [Friend] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Friend] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'Friend', N'ON'
GO
USE [Friend]
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 11/04/2016 21:00:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserInfo](
	[UID] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [nvarchar](max) NULL,
	[SEX] [nvarchar](max) NULL,
	[DATA] [varchar](50) NULL,
	[PLACE] [nvarchar](max) NULL,
	[NATION] [nvarchar](max) NULL,
	[HEIGHT] [nvarchar](max) NULL,
	[IMG] [nvarchar](max) NULL,
	[HISTORY] [nvarchar](max) NULL,
	[EDUCATION] [nvarchar](max) NULL,
	[SCHOOL] [nvarchar](max) NULL,
	[ADDRESS] [nvarchar](max) NULL,
	[WORKT] [nvarchar](max) NULL,
	[WORKPLACE] [nvarchar](max) NULL,
	[PHONE] [nvarchar](max) NULL,
	[INTEREST] [nvarchar](max) NULL,
	[OHEIGHT] [nvarchar](max) NULL,
	[OWORK] [nvarchar](max) NULL,
	[OINTEREST] [nvarchar](max) NULL,
	[OSTRENGTH] [nvarchar](max) NULL,
	[MIN] [nvarchar](max) NULL,
	[MAX] [nvarchar](max) NULL,
	[OWORKPLACE] [nvarchar](max) NULL,
	[FAMILY] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[UserType] [int] NULL,
	[OpeID] [int] NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[UserInfo] ON
INSERT [dbo].[UserInfo] ([UID], [NAME], [SEX], [DATA], [PLACE], [NATION], [HEIGHT], [IMG], [HISTORY], [EDUCATION], [SCHOOL], [ADDRESS], [WORKT], [WORKPLACE], [PHONE], [INTEREST], [OHEIGHT], [OWORK], [OINTEREST], [OSTRENGTH], [MIN], [MAX], [OWORKPLACE], [FAMILY], [Password], [UserType], [OpeID]) VALUES (1, N'王宝宝', N'女', N'1986-12-12', N'温州', N'汉族', N'1.76', N'/Upload/S1.png', NULL, NULL, N'温州大学', N'温州鹿城区', NULL, NULL, N'15687987897', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'', 1, 1)
INSERT [dbo].[UserInfo] ([UID], [NAME], [SEX], [DATA], [PLACE], [NATION], [HEIGHT], [IMG], [HISTORY], [EDUCATION], [SCHOOL], [ADDRESS], [WORKT], [WORKPLACE], [PHONE], [INTEREST], [OHEIGHT], [OWORK], [OINTEREST], [OSTRENGTH], [MIN], [MAX], [OWORKPLACE], [FAMILY], [Password], [UserType], [OpeID]) VALUES (2, N'44', N'男', N'1986-12-12', N'1', N'222', N'11', N'/Upload/S2.png', N'111', N'1', N'1', N'1', N'11', N'11', N'1', N'11', N'1', N'11', N'1', N'11', N'1', N'11', N'1', N'1', NULL, 1, 1)
INSERT [dbo].[UserInfo] ([UID], [NAME], [SEX], [DATA], [PLACE], [NATION], [HEIGHT], [IMG], [HISTORY], [EDUCATION], [SCHOOL], [ADDRESS], [WORKT], [WORKPLACE], [PHONE], [INTEREST], [OHEIGHT], [OWORK], [OINTEREST], [OSTRENGTH], [MIN], [MAX], [OWORKPLACE], [FAMILY], [Password], [UserType], [OpeID]) VALUES (11, N'11', N'男', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[UserInfo] ([UID], [NAME], [SEX], [DATA], [PLACE], [NATION], [HEIGHT], [IMG], [HISTORY], [EDUCATION], [SCHOOL], [ADDRESS], [WORKT], [WORKPLACE], [PHONE], [INTEREST], [OHEIGHT], [OWORK], [OINTEREST], [OSTRENGTH], [MIN], [MAX], [OWORKPLACE], [FAMILY], [Password], [UserType], [OpeID]) VALUES (12, N'刘德华', N'男', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 2)
INSERT [dbo].[UserInfo] ([UID], [NAME], [SEX], [DATA], [PLACE], [NATION], [HEIGHT], [IMG], [HISTORY], [EDUCATION], [SCHOOL], [ADDRESS], [WORKT], [WORKPLACE], [PHONE], [INTEREST], [OHEIGHT], [OWORK], [OINTEREST], [OSTRENGTH], [MIN], [MAX], [OWORKPLACE], [FAMILY], [Password], [UserType], [OpeID]) VALUES (13, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserInfo] ([UID], [NAME], [SEX], [DATA], [PLACE], [NATION], [HEIGHT], [IMG], [HISTORY], [EDUCATION], [SCHOOL], [ADDRESS], [WORKT], [WORKPLACE], [PHONE], [INTEREST], [OHEIGHT], [OWORK], [OINTEREST], [OSTRENGTH], [MIN], [MAX], [OWORKPLACE], [FAMILY], [Password], [UserType], [OpeID]) VALUES (14, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserInfo] ([UID], [NAME], [SEX], [DATA], [PLACE], [NATION], [HEIGHT], [IMG], [HISTORY], [EDUCATION], [SCHOOL], [ADDRESS], [WORKT], [WORKPLACE], [PHONE], [INTEREST], [OHEIGHT], [OWORK], [OINTEREST], [OSTRENGTH], [MIN], [MAX], [OWORKPLACE], [FAMILY], [Password], [UserType], [OpeID]) VALUES (15, N'11', N'男', NULL, N'11', NULL, NULL, N'/Upload/Sfe2f86e2-998c-469d-9752-acbed7fec6eb.png', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[UserInfo] ([UID], [NAME], [SEX], [DATA], [PLACE], [NATION], [HEIGHT], [IMG], [HISTORY], [EDUCATION], [SCHOOL], [ADDRESS], [WORKT], [WORKPLACE], [PHONE], [INTEREST], [OHEIGHT], [OWORK], [OINTEREST], [OSTRENGTH], [MIN], [MAX], [OWORKPLACE], [FAMILY], [Password], [UserType], [OpeID]) VALUES (16, N'11', N'男', NULL, N'11', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[UserInfo] ([UID], [NAME], [SEX], [DATA], [PLACE], [NATION], [HEIGHT], [IMG], [HISTORY], [EDUCATION], [SCHOOL], [ADDRESS], [WORKT], [WORKPLACE], [PHONE], [INTEREST], [OHEIGHT], [OWORK], [OINTEREST], [OSTRENGTH], [MIN], [MAX], [OWORKPLACE], [FAMILY], [Password], [UserType], [OpeID]) VALUES (17, N'1', N'男', NULL, N'1', NULL, NULL, N'/Upload/S0ac273e7-a853-48b7-bfb9-edf5a5b4e372.png', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[UserInfo] ([UID], [NAME], [SEX], [DATA], [PLACE], [NATION], [HEIGHT], [IMG], [HISTORY], [EDUCATION], [SCHOOL], [ADDRESS], [WORKT], [WORKPLACE], [PHONE], [INTEREST], [OHEIGHT], [OWORK], [OINTEREST], [OSTRENGTH], [MIN], [MAX], [OWORKPLACE], [FAMILY], [Password], [UserType], [OpeID]) VALUES (18, N'11', N'男', NULL, N'1', NULL, NULL, N'/Upload/S465e2d87-e62b-4e91-9750-626931300c09.png', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[UserInfo] ([UID], [NAME], [SEX], [DATA], [PLACE], [NATION], [HEIGHT], [IMG], [HISTORY], [EDUCATION], [SCHOOL], [ADDRESS], [WORKT], [WORKPLACE], [PHONE], [INTEREST], [OHEIGHT], [OWORK], [OINTEREST], [OSTRENGTH], [MIN], [MAX], [OWORKPLACE], [FAMILY], [Password], [UserType], [OpeID]) VALUES (19, N'11', N'男', NULL, N'1', NULL, NULL, N'/Upload/Sda5e387b-f352-4e7b-a47a-2ad2d4451733.png', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[UserInfo] ([UID], [NAME], [SEX], [DATA], [PLACE], [NATION], [HEIGHT], [IMG], [HISTORY], [EDUCATION], [SCHOOL], [ADDRESS], [WORKT], [WORKPLACE], [PHONE], [INTEREST], [OHEIGHT], [OWORK], [OINTEREST], [OSTRENGTH], [MIN], [MAX], [OWORKPLACE], [FAMILY], [Password], [UserType], [OpeID]) VALUES (20, NULL, N'男', NULL, N'11', N'11', N'11', N'/Upload/Sb1421352-1e59-478b-ac56-f5e58dc2f34e.png', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[UserInfo] ([UID], [NAME], [SEX], [DATA], [PLACE], [NATION], [HEIGHT], [IMG], [HISTORY], [EDUCATION], [SCHOOL], [ADDRESS], [WORKT], [WORKPLACE], [PHONE], [INTEREST], [OHEIGHT], [OWORK], [OINTEREST], [OSTRENGTH], [MIN], [MAX], [OWORKPLACE], [FAMILY], [Password], [UserType], [OpeID]) VALUES (21, NULL, N'男', NULL, N'11', N'11', N'11', N'/Upload/Sf99d0e56-de15-4011-a47f-b553377eee66.png', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1)
INSERT [dbo].[UserInfo] ([UID], [NAME], [SEX], [DATA], [PLACE], [NATION], [HEIGHT], [IMG], [HISTORY], [EDUCATION], [SCHOOL], [ADDRESS], [WORKT], [WORKPLACE], [PHONE], [INTEREST], [OHEIGHT], [OWORK], [OINTEREST], [OSTRENGTH], [MIN], [MAX], [OWORKPLACE], [FAMILY], [Password], [UserType], [OpeID]) VALUES (22, N'好美丽', N'女', NULL, N'1', N'1', N'1', N'/Upload/S930794be-c731-4cc3-9ede-6b9adedc5989.png', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1)
SET IDENTITY_INSERT [dbo].[UserInfo] OFF
/****** Object:  Table [dbo].[Admin]    Script Date: 11/04/2016 21:00:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Admin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Admin] ON
INSERT [dbo].[Admin] ([ID], [UserName], [Password]) VALUES (1, N'admin', N'admin1')
INSERT [dbo].[Admin] ([ID], [UserName], [Password]) VALUES (2, N'11', N'11')
SET IDENTITY_INSERT [dbo].[Admin] OFF
