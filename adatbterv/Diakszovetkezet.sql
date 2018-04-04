USE [master]
GO
/****** Object:  Database [Diakszovetkezet]    Script Date: 2018. 03. 27. 8:45:16 ******/
CREATE DATABASE [Diakszovetkezet]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Diakszovetkezet', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Diakszovetkezet.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Diakszovetkezet_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Diakszovetkezet_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Diakszovetkezet] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Diakszovetkezet].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Diakszovetkezet] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Diakszovetkezet] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Diakszovetkezet] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Diakszovetkezet] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Diakszovetkezet] SET ARITHABORT OFF 
GO
ALTER DATABASE [Diakszovetkezet] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Diakszovetkezet] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Diakszovetkezet] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Diakszovetkezet] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Diakszovetkezet] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Diakszovetkezet] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Diakszovetkezet] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Diakszovetkezet] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Diakszovetkezet] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Diakszovetkezet] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Diakszovetkezet] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Diakszovetkezet] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Diakszovetkezet] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Diakszovetkezet] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Diakszovetkezet] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Diakszovetkezet] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Diakszovetkezet] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Diakszovetkezet] SET RECOVERY FULL 
GO
ALTER DATABASE [Diakszovetkezet] SET  MULTI_USER 
GO
ALTER DATABASE [Diakszovetkezet] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Diakszovetkezet] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Diakszovetkezet] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Diakszovetkezet] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Diakszovetkezet] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Diakszovetkezet', N'ON'
GO
ALTER DATABASE [Diakszovetkezet] SET QUERY_STORE = OFF
GO
USE [Diakszovetkezet]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Diakszovetkezet]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 2018. 03. 27. 8:45:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[c_id] [int] IDENTITY(1,1) NOT NULL,
	[c_name] [varchar](130) NOT NULL,
	[location] [varchar](180) NOT NULL,
	[c_description] [varchar](300) NULL,
	[c_del] [int] NOT NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[c_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentTime]    Script Date: 2018. 03. 27. 8:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentTime](
	[s_id] [int] IDENTITY(1,1) NOT NULL,
	[s_username] [varchar](50) NOT NULL,
	[datestart] [date] NOT NULL,
	[dateend] [date] NOT NULL,
 CONSTRAINT [PK_StudentTime_1] PRIMARY KEY CLUSTERED 
(
	[s_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentWork]    Script Date: 2018. 03. 27. 8:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentWork](
	[student_id] [varchar](50) NOT NULL,
	[work_id] [int] NOT NULL,
 CONSTRAINT [PK_StudentWork] PRIMARY KEY CLUSTERED 
(
	[student_id] ASC,
	[work_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2018. 03. 27. 8:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[fname] [varchar](50) NULL,
	[lname] [varchar](50) NULL,
	[role] [int] NOT NULL,
	[del] [int] NOT NULL,
 CONSTRAINT [PK_Users_1] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Work]    Script Date: 2018. 03. 27. 8:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Work](
	[w_id] [int] IDENTITY(1,1) NOT NULL,
	[company_id] [int] NOT NULL,
	[w_datestart] [date] NOT NULL,
	[w_dateend] [date] NOT NULL,
	[w_description] [varchar](300) NULL,
	[w_name] [varchar](50) NOT NULL,
	[s_number] [int] NOT NULL,
 CONSTRAINT [PK_Work] PRIMARY KEY CLUSTERED 
(
	[w_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Users] ([username], [password], [email], [fname], [lname], [role], [del]) VALUES (N'diak', N'diak', N'diak@diak.com', N'elso', N'diak', 1, 0)
INSERT [dbo].[Users] ([username], [password], [email], [fname], [lname], [role], [del]) VALUES (N'root', N'root', N'root@root.com', N'root', N'root', 0, 0)
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_StudentTime]    Script Date: 2018. 03. 27. 8:45:17 ******/
ALTER TABLE [dbo].[StudentTime] ADD  CONSTRAINT [IX_StudentTime] UNIQUE NONCLUSTERED 
(
	[s_username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users]    Script Date: 2018. 03. 27. 8:45:17 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users] ON [dbo].[Users]
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[StudentTime]  WITH CHECK ADD  CONSTRAINT [FK_StudentTime_Users] FOREIGN KEY([s_username])
REFERENCES [dbo].[Users] ([username])
GO
ALTER TABLE [dbo].[StudentTime] CHECK CONSTRAINT [FK_StudentTime_Users]
GO
ALTER TABLE [dbo].[StudentWork]  WITH CHECK ADD  CONSTRAINT [FK_StudentWork_Users] FOREIGN KEY([student_id])
REFERENCES [dbo].[Users] ([username])
GO
ALTER TABLE [dbo].[StudentWork] CHECK CONSTRAINT [FK_StudentWork_Users]
GO
ALTER TABLE [dbo].[StudentWork]  WITH CHECK ADD  CONSTRAINT [FK_StudentWork_Work] FOREIGN KEY([work_id])
REFERENCES [dbo].[Work] ([w_id])
GO
ALTER TABLE [dbo].[StudentWork] CHECK CONSTRAINT [FK_StudentWork_Work]
GO
ALTER TABLE [dbo].[Work]  WITH CHECK ADD  CONSTRAINT [FK_Work_Companies] FOREIGN KEY([company_id])
REFERENCES [dbo].[Companies] ([c_id])
GO
ALTER TABLE [dbo].[Work] CHECK CONSTRAINT [FK_Work_Companies]
GO
USE [master]
GO
ALTER DATABASE [Diakszovetkezet] SET  READ_WRITE 
GO
