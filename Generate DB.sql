USE [master]
GO

/****** Object:  Database [BookLibraryDB]    Script Date: 11/7/2015 12:19:03 AM ******/
CREATE DATABASE [BookLibraryDB]
GO

CREATE LOGIN [booksUser] WITH PASSWORD=N'books', DEFAULT_DATABASE=[BookLibraryDB], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

USE [BookLibraryDB]
GO

/****** Object:  User [booksUser]    Script Date: 11/7/2015 12:21:42 AM ******/
CREATE USER [booksUser] FOR LOGIN [booksUser] WITH DEFAULT_SCHEMA=[dbo]
GO

-- Define role
exec sys.sp_addrolemember @membername = N'booksUser', @rolename = N'db_owner'
GO

USE [BookLibraryDB]
GO

CREATE TABLE [dbo].[Author](
	[Author_ID] [int] IDENTITY(1,1) NOT NULL,
	[Author_Name] [varchar](250) NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[Author_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Category](
	[Category_ID] [int] IDENTITY(1,1) NOT NULL,
	[Category_Name] [varchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Category_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Book](
	[Book_ID] [int] IDENTITY(1,1) NOT NULL,
	[Category_ID] [int] NULL,
	[Author_ID] [int] NULL,
	[Book_Name] [varchar](150) NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[Book_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

INSERT INTO [dbo].[Author] ([Author_Name]) VALUES ('RICK WARREN')
INSERT INTO [dbo].[Author] ([Author_Name]) VALUES ('ANNE FRANK')
INSERT INTO [dbo].[Author] ([Author_Name]) VALUES ('JANE AUSTEN')

INSERT INTO [dbo].[Category]([Category_Name]) VALUES ('RELIGION')
INSERT INTO [dbo].[Category]([Category_Name]) VALUES ('DRAMA')
INSERT INTO [dbo].[Category]([Category_Name]) VALUES ('ROMANTIC')


INSERT INTO [dbo].[Book]([Category_ID] ,[Author_ID]  ,[Book_Name]) VALUES (1,1,'THE PURPOSE DRIVEN')
INSERT INTO [dbo].[Book]([Category_ID] ,[Author_ID]  ,[Book_Name]) VALUES (2,2,'ANNE FRANK DIARY')
INSERT INTO [dbo].[Book]([Category_ID] ,[Author_ID]  ,[Book_Name]) VALUES (3,3,'PRIDE & PREJUDICE')

GO
