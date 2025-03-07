USE [master]
GO
/****** Object:  Database [BulutSistemDb]    Script Date: 22.01.2025 03:05:05 ******/
CREATE DATABASE [BulutSistemDb] ON  PRIMARY 
( NAME = N'BulutSistemDb', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\BulutSistemDb.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BulutSistemDb_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\BulutSistemDb_log.LDF' , SIZE = 576KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BulutSistemDb] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BulutSistemDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BulutSistemDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BulutSistemDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BulutSistemDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BulutSistemDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BulutSistemDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [BulutSistemDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BulutSistemDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BulutSistemDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BulutSistemDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BulutSistemDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BulutSistemDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BulutSistemDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BulutSistemDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BulutSistemDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BulutSistemDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BulutSistemDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BulutSistemDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BulutSistemDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BulutSistemDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BulutSistemDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BulutSistemDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BulutSistemDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BulutSistemDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BulutSistemDb] SET  MULTI_USER 
GO
ALTER DATABASE [BulutSistemDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BulutSistemDb] SET DB_CHAINING OFF 
GO
USE [BulutSistemDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 22.01.2025 03:05:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 22.01.2025 03:05:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ParentCategoryId] [int] NULL,
	[Created_At] [datetime2](7) NOT NULL,
	[Updated_At] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 22.01.2025 03:05:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Stock_Quantity] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Created_At] [datetime2](7) NOT NULL,
	[Updated_At] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductVariants]    Script Date: 22.01.2025 03:05:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductVariants](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[VariantName] [nvarchar](255) NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[StockQuantity] [int] NOT NULL,
	[Created_At] [datetime2](7) NOT NULL,
	[Updated_At] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_ProductVariants] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 22.01.2025 03:05:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[NormalizedName] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](21) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 22.01.2025 03:05:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[AppUserId] [uniqueidentifier] NOT NULL,
	[AppRoleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[AppUserId] ASC,
	[AppRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 22.01.2025 03:05:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[RefreshToken] [nvarchar](max) NULL,
	[RefreshTokenExpires] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsAdmin] [bit] NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[NormalizedUserName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[NormalizedEmail] [nvarchar](max) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Variants]    Script Date: 22.01.2025 03:05:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Variants](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VariantName] [nvarchar](255) NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[StockQuantity] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Created_At] [datetime2](7) NOT NULL,
	[Updated_At] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Variants] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Categories_ParentCategoryId]    Script Date: 22.01.2025 03:05:06 ******/
CREATE NONCLUSTERED INDEX [IX_Categories_ParentCategoryId] ON [dbo].[Categories]
(
	[ParentCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_CategoryId]    Script Date: 22.01.2025 03:05:06 ******/
CREATE NONCLUSTERED INDEX [IX_Products_CategoryId] ON [dbo].[Products]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductVariants_ProductId]    Script Date: 22.01.2025 03:05:06 ******/
CREATE NONCLUSTERED INDEX [IX_ProductVariants_ProductId] ON [dbo].[ProductVariants]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserRoles_AppRoleId]    Script Date: 22.01.2025 03:05:06 ******/
CREATE NONCLUSTERED INDEX [IX_UserRoles_AppRoleId] ON [dbo].[UserRoles]
(
	[AppRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Variants_ProductId]    Script Date: 22.01.2025 03:05:06 ******/
CREATE NONCLUSTERED INDEX [IX_Variants_ProductId] ON [dbo].[Variants]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Categories_ParentCategoryId] FOREIGN KEY([ParentCategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Categories_ParentCategoryId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories_CategoryId]
GO
ALTER TABLE [dbo].[ProductVariants]  WITH CHECK ADD  CONSTRAINT [FK_ProductVariants_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductVariants] CHECK CONSTRAINT [FK_ProductVariants_Products_ProductId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles_AppRoleId] FOREIGN KEY([AppRoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles_AppRoleId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users_AppUserId] FOREIGN KEY([AppUserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users_AppUserId]
GO
ALTER TABLE [dbo].[Variants]  WITH CHECK ADD  CONSTRAINT [FK_Variants_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Variants] CHECK CONSTRAINT [FK_Variants_Products_ProductId]
GO
USE [master]
GO
ALTER DATABASE [BulutSistemDb] SET  READ_WRITE 
GO
