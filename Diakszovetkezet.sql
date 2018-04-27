USE [Diakszovetkezet]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 2018. 04. 27. 21:26:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[c_id] [int] NOT NULL,
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
/****** Object:  Table [dbo].[StudentJobs]    Script Date: 2018. 04. 27. 21:26:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentJobs](
	[student_id] [varchar](50) NOT NULL,
	[work_id] [int] NOT NULL,
	[sj_del] [int] NULL,
 CONSTRAINT [PK_StudentJobs] PRIMARY KEY CLUSTERED 
(
	[student_id] ASC,
	[work_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentTime]    Script Date: 2018. 04. 27. 21:26:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentTime](
	[s_id] [int] NOT NULL,
	[s_username] [varchar](50) NOT NULL,
	[datestart] [datetime] NOT NULL,
	[dateend] [datetime] NOT NULL,
 CONSTRAINT [PK_StudentTime_1] PRIMARY KEY CLUSTERED 
(
	[s_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_StudentTime] UNIQUE NONCLUSTERED 
(
	[s_username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentWork]    Script Date: 2018. 04. 27. 21:26:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentWork](
	[student_id] [varchar](50) NOT NULL,
	[work_id] [int] NOT NULL,
	[sw_date] [datetime] NOT NULL,
	[sw_del] [int] NOT NULL,
 CONSTRAINT [PK_StudentWork] PRIMARY KEY CLUSTERED 
(
	[student_id] ASC,
	[work_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2018. 04. 27. 21:26:34 ******/
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
/****** Object:  Table [dbo].[Work]    Script Date: 2018. 04. 27. 21:26:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Work](
	[w_id] [int] NOT NULL,
	[company_id] [int] NOT NULL,
	[w_datestart] [datetime] NOT NULL,
	[w_dateend] [datetime] NOT NULL,
	[w_description] [varchar](300) NULL,
	[w_name] [varchar](50) NOT NULL,
	[s_number] [int] NOT NULL,
 CONSTRAINT [PK_Work] PRIMARY KEY CLUSTERED 
(
	[w_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
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
