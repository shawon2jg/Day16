USE [master]
GO
/****** Object:  Database [UniversityDB]    Script Date: 01/02/2015 16:02:20 ******/
CREATE DATABASE [UniversityDB] ON  PRIMARY 
( NAME = N'UniversityDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\UniversityDB.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UniversityDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\UniversityDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UniversityDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniversityDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniversityDB] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [UniversityDB] SET ANSI_NULLS OFF
GO
ALTER DATABASE [UniversityDB] SET ANSI_PADDING OFF
GO
ALTER DATABASE [UniversityDB] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [UniversityDB] SET ARITHABORT OFF
GO
ALTER DATABASE [UniversityDB] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [UniversityDB] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [UniversityDB] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [UniversityDB] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [UniversityDB] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [UniversityDB] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [UniversityDB] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [UniversityDB] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [UniversityDB] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [UniversityDB] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [UniversityDB] SET  DISABLE_BROKER
GO
ALTER DATABASE [UniversityDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [UniversityDB] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [UniversityDB] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [UniversityDB] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [UniversityDB] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [UniversityDB] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [UniversityDB] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [UniversityDB] SET  READ_WRITE
GO
ALTER DATABASE [UniversityDB] SET RECOVERY SIMPLE
GO
ALTER DATABASE [UniversityDB] SET  MULTI_USER
GO
ALTER DATABASE [UniversityDB] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [UniversityDB] SET DB_CHAINING OFF
GO
USE [UniversityDB]
GO
/****** Object:  Table [dbo].[tDepartment]    Script Date: 01/02/2015 16:02:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tDepartment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Location] [varchar](150) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tDepartment] ON
INSERT [dbo].[tDepartment] ([ID], [Name], [Location]) VALUES (1, N'CSE', NULL)
INSERT [dbo].[tDepartment] ([ID], [Name], [Location]) VALUES (2, N'EEE', NULL)
INSERT [dbo].[tDepartment] ([ID], [Name], [Location]) VALUES (3, N'PHY', NULL)
INSERT [dbo].[tDepartment] ([ID], [Name], [Location]) VALUES (4, N'MATH', NULL)
SET IDENTITY_INSERT [dbo].[tDepartment] OFF
/****** Object:  Table [dbo].[tStudent]    Script Date: 01/02/2015 16:02:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tStudent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Address] [varchar](150) NULL,
	[Email] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[Dept_ID] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tStudent] ON
INSERT [dbo].[tStudent] ([ID], [Name], [Address], [Email], [Phone], [Dept_ID]) VALUES (2, N'Mamun', N'Dhaka', N'shirajul.mamun@gmail.com', NULL, NULL)
INSERT [dbo].[tStudent] ([ID], [Name], [Address], [Email], [Phone], [Dept_ID]) VALUES (3, N'Sumon', N'Dhaka', N'sumon@gmail.com', NULL, NULL)
INSERT [dbo].[tStudent] ([ID], [Name], [Address], [Email], [Phone], [Dept_ID]) VALUES (4, N'Steve Jobs', N'New York', N'jobs@gmail.com', N'34536346', NULL)
INSERT [dbo].[tStudent] ([ID], [Name], [Address], [Email], [Phone], [Dept_ID]) VALUES (5, N'Steve Jobs', N'New York', N'jobs@gmail.com', N'3424', NULL)
INSERT [dbo].[tStudent] ([ID], [Name], [Address], [Email], [Phone], [Dept_ID]) VALUES (11, N'fdsffdsf', N'', N'dfsf', N'', 3)
SET IDENTITY_INSERT [dbo].[tStudent] OFF
/****** Object:  ForeignKey [FK_tStudent_tDepartment]    Script Date: 01/02/2015 16:02:22 ******/
ALTER TABLE [dbo].[tStudent]  WITH CHECK ADD  CONSTRAINT [FK_tStudent_tDepartment] FOREIGN KEY([Dept_ID])
REFERENCES [dbo].[tDepartment] ([ID])
GO
ALTER TABLE [dbo].[tStudent] CHECK CONSTRAINT [FK_tStudent_tDepartment]
GO
