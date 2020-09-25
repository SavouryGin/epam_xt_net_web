USE [master]
GO

/****** Object:  Database [Users_and_Awards_DB]    Script Date: 25.09.2020 11:18:05 ******/
CREATE DATABASE [Users_and_Awards_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Users_and_Awards_DB', FILENAME = N'D:\data\Users_and_Awards_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Users_and_Awards_DB_log', FILENAME = N'D:\data\Users_and_Awards_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Users_and_Awards_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Users_and_Awards_DB] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Users_and_Awards_DB] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Users_and_Awards_DB] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Users_and_Awards_DB] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Users_and_Awards_DB] SET ARITHABORT OFF 
GO

ALTER DATABASE [Users_and_Awards_DB] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Users_and_Awards_DB] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Users_and_Awards_DB] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Users_and_Awards_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Users_and_Awards_DB] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Users_and_Awards_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Users_and_Awards_DB] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Users_and_Awards_DB] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Users_and_Awards_DB] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Users_and_Awards_DB] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Users_and_Awards_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Users_and_Awards_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Users_and_Awards_DB] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Users_and_Awards_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Users_and_Awards_DB] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Users_and_Awards_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Users_and_Awards_DB] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Users_and_Awards_DB] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [Users_and_Awards_DB] SET  MULTI_USER 
GO

ALTER DATABASE [Users_and_Awards_DB] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Users_and_Awards_DB] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Users_and_Awards_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Users_and_Awards_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [Users_and_Awards_DB] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Users_and_Awards_DB] SET QUERY_STORE = OFF
GO

ALTER DATABASE [Users_and_Awards_DB] SET  READ_WRITE 
GO


USE [Users_and_Awards_DB]
GO

/****** Object:  Table [dbo].[Awards]    Script Date: 25.09.2020 11:18:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Awards](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](25) NOT NULL,
	[Avatar] [nvarchar](max) NULL,
 CONSTRAINT [PK_Awards] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

USE [Users_and_Awards_DB]
GO

/****** Object:  Table [dbo].[Nexuses]    Script Date: 25.09.2020 11:19:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Nexuses](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[AwardId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Nexuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Nexuses]  WITH CHECK ADD  CONSTRAINT [FK_Nexuses_Awards] FOREIGN KEY([AwardId])
REFERENCES [dbo].[Awards] ([Id])
GO

ALTER TABLE [dbo].[Nexuses] CHECK CONSTRAINT [FK_Nexuses_Awards]
GO

ALTER TABLE [dbo].[Nexuses]  WITH CHECK ADD  CONSTRAINT [FK_Nexuses_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[Nexuses] CHECK CONSTRAINT [FK_Nexuses_Users]
GO

USE [Users_and_Awards_DB]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 25.09.2020 11:19:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
	[Password] [nvarchar](32) NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[Age] [int] NOT NULL,
	[IsAdmin] [bit] NOT NULL,
	[Avatar] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0)) FOR [IsAdmin]
GO

USE [Users_and_Awards_DB]
GO

/****** Object:  StoredProcedure [dbo].[DeleteAwardById]    Script Date: 25.09.2020 11:20:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteAwardById]
	@Id uniqueidentifier
AS
BEGIN
	SET NOCOUNT OFF;

	DELETE 
	FROM Awards
	WHERE Id = @Id
END
GO

USE [Users_and_Awards_DB]
GO

/****** Object:  StoredProcedure [dbo].[DeleteNexusById]    Script Date: 25.09.2020 11:20:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteNexusById]
	@Id uniqueidentifier
AS
BEGIN
	SET NOCOUNT OFF;

	DELETE 
	FROM Nexuses
	WHERE Id = @Id
END
GO

USE [Users_and_Awards_DB]
GO

/****** Object:  StoredProcedure [dbo].[DeleteUserById]    Script Date: 25.09.2020 11:20:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteUserById]
	@Id uniqueidentifier
AS
BEGIN
	SET NOCOUNT OFF;

	DELETE 
	FROM Users
	WHERE Id = @Id
END
GO

USE [Users_and_Awards_DB]
GO

/****** Object:  StoredProcedure [dbo].[GetAllAwards]    Script Date: 25.09.2020 11:20:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllAwards]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM Awards
END
GO

USE [Users_and_Awards_DB]
GO

/****** Object:  StoredProcedure [dbo].[GetAllNexuses]    Script Date: 25.09.2020 11:20:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllNexuses]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM Nexuses
END
GO

USE [Users_and_Awards_DB]
GO

/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 25.09.2020 11:21:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllUsers] 
	
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM Users
END
GO


USE [Users_and_Awards_DB]
GO

/****** Object:  StoredProcedure [dbo].[GetAwardById]    Script Date: 25.09.2020 11:21:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAwardById]
	@Id uniqueidentifier
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * 
	FROM Awards
	Where Id = @Id
END
GO

USE [Users_and_Awards_DB]
GO

/****** Object:  StoredProcedure [dbo].[GetAwardByTitle]    Script Date: 25.09.2020 11:21:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAwardByTitle]
	@Title nvarchar(25)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 1 *
	FROM Awards
	Where Title = @Title
END
GO


USE [Users_and_Awards_DB]
GO

/****** Object:  StoredProcedure [dbo].[GetAwardedUsers]    Script Date: 25.09.2020 11:21:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAwardedUsers]
	@AwardId uniqueidentifier
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Users.* 
	FROM (Nexuses JOIN Awards ON (Nexuses.AwardId = Awards.Id)) JOIN Users ON  (Nexuses.UserId = Users.Id)
	WHERE Awards.Id = @AwardId
END
GO


USE [Users_and_Awards_DB]
GO

/****** Object:  StoredProcedure [dbo].[GetUserAwards]    Script Date: 25.09.2020 11:22:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserAwards]
	@UserId uniqueidentifier
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Awards.* 
	FROM (Users JOIN Nexuses ON (Nexuses.UserId = Users.Id)) JOIN Awards ON  (Nexuses.AwardId = Awards.Id)
	WHERE Users.Id = @UserId
END
GO

USE [Users_and_Awards_DB]
GO

/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 25.09.2020 11:22:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserById]
	@Id uniqueidentifier
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * 
	FROM Users
	Where Id = @Id
END
GO

USE [Users_and_Awards_DB]
GO

/****** Object:  StoredProcedure [dbo].[GetUserByName]    Script Date: 25.09.2020 11:22:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserByName]
	@Name nvarchar(25)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 1 * 
	FROM Users
	Where Name = @Name
END
GO

USE [Users_and_Awards_DB]
GO

/****** Object:  StoredProcedure [dbo].[GetUserRoles]    Script Date: 25.09.2020 11:22:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserRoles]
	@Name nvarchar(25)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT COUNT(*)
	FROM Users
	WHERE Name = @Name AND IsAdmin = 1
END
GO

USE [Users_and_Awards_DB]
GO

/****** Object:  StoredProcedure [dbo].[IsInRole]    Script Date: 25.09.2020 11:23:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[IsInRole]
	@Name nvarchar(25),
	@Role nvarchar(20)
AS
BEGIN
	SET NOCOUNT ON;

	IF @Role = 'admin' 
		SELECT COUNT(*)
		FROM Users
		WHERE Name = @Name AND IsAdmin = 1
	ELSE
		SELECT COUNT(*)
		FROM Users
		WHERE Name = @Name AND IsAdmin = 0
		
END
GO

USE [Users_and_Awards_DB]
GO

/****** Object:  StoredProcedure [dbo].[IsRegistered]    Script Date: 25.09.2020 11:23:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[IsRegistered]
	@Name nvarchar(25),
	@Password nvarchar(32)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT COUNT(*)
	FROM Users
	WHERE Name = @Name AND Password = @Password
END
GO

USE [Users_and_Awards_DB]
GO

/****** Object:  StoredProcedure [dbo].[SaveAward]    Script Date: 25.09.2020 11:23:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SaveAward]
	@Id uniqueidentifier,
	@Title nvarchar(25),
	@Avatar nvarchar(MAX) = NULL
AS
BEGIN
	SET NOCOUNT OFF;

	INSERT INTO Awards(Id, Title, Avatar)
	VALUES (@Id, @Title, @Avatar)
END
GO

USE [Users_and_Awards_DB]
GO

/****** Object:  StoredProcedure [dbo].[SaveNexus]    Script Date: 25.09.2020 11:23:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SaveNexus]
	@Id uniqueidentifier,
	@UserId uniqueidentifier,
	@AwardId uniqueidentifier
AS
BEGIN
	SET NOCOUNT OFF;

	INSERT INTO Nexuses(Id, UserId, AwardId)
	VALUES (@Id, @UserId, @AwardId)
END
GO

USE [Users_and_Awards_DB]
GO

/****** Object:  StoredProcedure [dbo].[SaveUser]    Script Date: 25.09.2020 11:23:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SaveUser]
	@Id uniqueidentifier,
	@Name nvarchar(25),
	@Password nvarchar(32) = NULL,
	@DateOfBirth datetime,
	@Age int,
	@IsAdmin bit,
	@Avatar nvarchar(MAX) = NULL
AS
BEGIN
	SET NOCOUNT OFF;

	INSERT INTO Users (Id, Name, Password, DateOfBirth, Age, IsAdmin, Avatar)
	VALUES (@Id, @Name, @Password, @DateOfBirth, @Age, @IsAdmin, @Avatar)
END
GO

USE [Users_and_Awards_DB]
GO

/****** Object:  StoredProcedure [dbo].[SetPassword]    Script Date: 25.09.2020 11:23:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SetPassword]
	@Id uniqueidentifier,
	@Password nvarchar(32)
AS
BEGIN
	SET NOCOUNT OFF;

	UPDATE Users
	SET Password = @Password
	WHERE Id = @Id
END
GO

USE [Users_and_Awards_DB]
GO

/****** Object:  StoredProcedure [dbo].[UpdateAward]    Script Date: 25.09.2020 11:24:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateAward]
	@Id uniqueidentifier,
	@Avatar nvarchar(MAX) = NULL
AS
BEGIN
	SET NOCOUNT OFF;

	UPDATE Awards
	SET Avatar = @Avatar
	WHERE Id = @Id
END
GO

USE [Users_and_Awards_DB]
GO

/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 25.09.2020 11:24:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateUser]
	@Id uniqueidentifier,
	@Name nvarchar(25),
	@Password nvarchar(32) = NULL,
	@DateOfBirth datetime,
	@Age int,
	@IsAdmin bit,
	@Avatar nvarchar(MAX) = NULL
AS
BEGIN
	SET NOCOUNT OFF;

	UPDATE Users
	SET Name = @Name, Password = @Password, DateOfBirth = @DateOfBirth, Age = @Age, IsAdmin = @IsAdmin, Avatar = @Avatar
	WHERE Id = @Id
END
GO

