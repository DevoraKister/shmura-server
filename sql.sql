USE [master]
GO
/****** Object:  Database [idial]    Script Date: 17/02/2020 02:20:58 ******/
CREATE DATABASE [idial]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'idial', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\idial.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'idial_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\idial_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [idial] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [idial].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [idial] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [idial] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [idial] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [idial] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [idial] SET ARITHABORT OFF 
GO
ALTER DATABASE [idial] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [idial] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [idial] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [idial] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [idial] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [idial] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [idial] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [idial] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [idial] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [idial] SET  DISABLE_BROKER 
GO
ALTER DATABASE [idial] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [idial] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [idial] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [idial] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [idial] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [idial] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [idial] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [idial] SET RECOVERY FULL 
GO
ALTER DATABASE [idial] SET  MULTI_USER 
GO
ALTER DATABASE [idial] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [idial] SET DB_CHAINING OFF 
GO
ALTER DATABASE [idial] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [idial] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [idial] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'idial', N'ON'
GO
ALTER DATABASE [idial] SET QUERY_STORE = OFF
GO
USE [idial]
GO
/****** Object:  Table [dbo].[Adv]    Script Date: 17/02/2020 02:20:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adv](
	[AdvId] [int] IDENTITY(1,1) NOT NULL,
	[AdvStatus] [bit] NULL,
	[AdvLink] [nvarchar](max) NULL,
	[AdvTitle] [nvarchar](50) NULL,
	[AdvContent] [nvarchar](max) NULL,
	[AdvMail] [nvarchar](50) NULL,
	[AdvPhone] [nvarchar](10) NULL,
	[CountUsers] [int] NULL,
 CONSTRAINT [PK_Adv] PRIMARY KEY CLUSTERED 
(
	[AdvId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Area]    Script Date: 17/02/2020 02:20:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Area](
	[AreaId] [int] IDENTITY(1,1) NOT NULL,
	[AreaName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED 
(
	[AreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Boss]    Script Date: 17/02/2020 02:20:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Boss](
	[BossId] [int] IDENTITY(1,1) NOT NULL,
	[BossName] [nvarchar](50) NULL,
	[BossTel] [nvarchar](50) NULL,
	[BossMail] [nvarchar](50) NULL,
	[BossSubId] [int] NULL,
	[BossPassword] [nvarchar](64) NULL,
	[BossIsConnection] [bit] NULL,
	[BossCompanyId] [int] NULL,
 CONSTRAINT [PK_Boss] PRIMARY KEY CLUSTERED 
(
	[BossId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City]    Script Date: 17/02/2020 02:20:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[CityId] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](50) NULL,
	[CityAreaId] [int] NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 17/02/2020 02:20:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[CompanyId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](50) NULL,
	[CompanyStreet] [nvarchar](50) NULL,
	[CompanyCityId] [int] NULL,
	[CompanyNumBuild] [int] NULL,
	[CompanyTel] [nvarchar](10) NULL,
	[CompanyMail] [nvarchar](50) NULL,
	[CompanyAreaId] [int] NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Count]    Script Date: 17/02/2020 02:20:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Count](
	[Counts] [int] IDENTITY(1,1) NOT NULL,
	[CountUser] [int] NULL,
 CONSTRAINT [PK_Count] PRIMARY KEY CLUSTERED 
(
	[Counts] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cv]    Script Date: 17/02/2020 02:20:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cv](
	[CvId] [int] IDENTITY(1,1) NOT NULL,
	[CvLink] [nvarchar](50) NULL,
	[CvUserId] [int] NULL,
 CONSTRAINT [PK_Cv] PRIMARY KEY CLUSTERED 
(
	[CvId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Job]    Script Date: 17/02/2020 02:20:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Job](
	[JobId] [int] IDENTITY(1,1) NOT NULL,
	[JobDateAdv] [datetime] NULL,
	[JobSubId] [int] NULL,
	[JobRole] [nvarchar](max) NULL,
	[JobPartId] [int] NULL,
	[JobPartOutNetId] [int] NULL,
	[JobWorkspaceId] [int] NULL,
	[JobExperience] [int] NULL,
	[JobCVId] [int] NULL,
	[JobOfferId] [int] NULL,
	[JobStars] [int] NULL,
	[JobBossId] [int] NULL,
	[JobStatus] [bit] NULL,
	[JobDateCaughtJob] [date] NULL,
	[JobIsByUs] [bit] NULL,
	[JobDescribe] [nvarchar](max) NULL,
	[JobCompanyId] [int] NULL,
	[JobRequire] [nvarchar](max) NULL,
 CONSTRAINT [PK_Job] PRIMARY KEY CLUSTERED 
(
	[JobId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OutNet]    Script Date: 17/02/2020 02:20:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OutNet](
	[OutNetId] [int] IDENTITY(1,1) NOT NULL,
	[OutNetName] [nvarchar](50) NULL,
 CONSTRAINT [PK_OutNet] PRIMARY KEY CLUSTERED 
(
	[OutNetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Part]    Script Date: 17/02/2020 02:20:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Part](
	[PartId] [int] IDENTITY(1,1) NOT NULL,
	[PartName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Part] PRIMARY KEY CLUSTERED 
(
	[PartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PutInJob]    Script Date: 17/02/2020 02:20:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PutInJob](
	[PutId] [int] IDENTITY(1,1) NOT NULL,
	[PutJobId] [int] NULL,
	[PutUserId] [int] NULL,
	[PutDate] [date] NULL,
 CONSTRAINT [PK_PutInJob] PRIMARY KEY CLUSTERED 
(
	[PutId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 17/02/2020 02:20:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[QueId] [int] IDENTITY(1,1) NOT NULL,
	[QueUserId] [int] NULL,
	[Question] [nvarchar](max) NULL,
	[Answer] [nvarchar](max) NULL,
	[RavId] [int] NULL,
	[QueTopicId] [int] NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[QueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rav]    Script Date: 17/02/2020 02:20:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rav](
	[RavId] [int] IDENTITY(1,1) NOT NULL,
	[RavName] [nchar](10) NULL,
 CONSTRAINT [PK_Rav] PRIMARY KEY CLUSTERED 
(
	[RavId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recomend]    Script Date: 17/02/2020 02:20:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recomend](
	[RecomendId] [int] IDENTITY(1,1) NOT NULL,
	[RecomendUserId] [int] NULL,
	[RecomemdCompanyId] [int] NULL,
	[RecomendInfo] [nvarchar](max) NULL,
 CONSTRAINT [PK_Recomend] PRIMARY KEY CLUSTERED 
(
	[RecomendId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Request]    Script Date: 17/02/2020 02:20:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Request](
	[ReqId] [int] IDENTITY(1,1) NOT NULL,
	[ReqUserId] [int] NULL,
	[ReqContents] [nvarchar](max) NULL,
	[ReqTypeConectId] [int] NULL,
 CONSTRAINT [PK_Request] PRIMARY KEY CLUSTERED 
(
	[ReqId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sign]    Script Date: 17/02/2020 02:20:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sign](
	[SignId] [int] IDENTITY(1,1) NOT NULL,
	[SignJobId] [int] NULL,
	[SignUserId] [int] NULL,
	[SignDate] [date] NULL,
	[SignStatusSend] [bit] NULL,
 CONSTRAINT [PK_Sign] PRIMARY KEY CLUSTERED 
(
	[SignId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubjectJob]    Script Date: 17/02/2020 02:20:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectJob](
	[SubId] [int] IDENTITY(1,1) NOT NULL,
	[SubName] [nvarchar](50) NULL,
 CONSTRAINT [PK_SubjectJob] PRIMARY KEY CLUSTERED 
(
	[SubId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Survey]    Script Date: 17/02/2020 02:20:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Survey](
	[SurveyId] [int] IDENTITY(1,1) NOT NULL,
	[SurveySubLearnId] [int] NULL,
	[SurveyIsWork] [bit] NULL,
	[SurveySubTodayId] [int] NULL,
	[SurveySeminar] [nvarchar](50) NULL,
	[SurveySubLearnedTxt] [nvarchar](50) NULL,
	[SurveySubTodayTxt] [nvarchar](50) NULL,
 CONSTRAINT [PK_Survey] PRIMARY KEY CLUSTERED 
(
	[SurveyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TopicQuestion]    Script Date: 17/02/2020 02:20:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TopicQuestion](
	[TopicId] [int] IDENTITY(1,1) NOT NULL,
	[TopicName] [nvarchar](max) NULL,
 CONSTRAINT [PK_TopicQuestion] PRIMARY KEY CLUSTERED 
(
	[TopicId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeConnect]    Script Date: 17/02/2020 02:20:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeConnect](
	[TypeConnectId] [int] IDENTITY(1,1) NOT NULL,
	[TypeConnectName] [nvarchar](max) NULL,
 CONSTRAINT [PK_TypeConnect] PRIMARY KEY CLUSTERED 
(
	[TypeConnectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 17/02/2020 02:20:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[UserTel] [nvarchar](50) NULL,
	[UserMail] [nvarchar](50) NULL,
	[UserCityId] [int] NULL,
	[UserSubId] [int] NULL,
	[UserIsChizuk] [bit] NULL,
	[UserIsUpdate] [bit] NULL,
	[UserPartId] [int] NULL,
	[UserPassword] [nvarchar](64) NULL,
	[UserIsSmartAgent] [bit] NULL,
	[UserSmartAgentTime] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Workspace]    Script Date: 17/02/2020 02:20:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workspace](
	[WSId] [int] IDENTITY(1,1) NOT NULL,
	[WSName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Workspace] PRIMARY KEY CLUSTERED 
(
	[WSId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Adv] ON 

INSERT [dbo].[Adv] ([AdvId], [AdvStatus], [AdvLink], [AdvTitle], [AdvContent], [AdvMail], [AdvPhone], [CountUsers]) VALUES (1, 0, N'https://image.freepik.com/free-vector/job-hunt-concept-illustration_114360-436.jpg', N'יועצת', N'יועצת מדהימה תשלומים נוחים.', N'5656@gmail.com', N'0553264879', 1)
INSERT [dbo].[Adv] ([AdvId], [AdvStatus], [AdvLink], [AdvTitle], [AdvContent], [AdvMail], [AdvPhone], [CountUsers]) VALUES (2, 0, N'https://image.freepik.com/free-vector/job-hunt-concept-illustration_114360-436.jpg', N'מטפלת ריגשית', N'סי בי טי , אנאלפי, שלושת המימדים, שלושת הכוכבים...', N'798@guyguy.cd', N'789654123', 1)
INSERT [dbo].[Adv] ([AdvId], [AdvStatus], [AdvLink], [AdvTitle], [AdvContent], [AdvMail], [AdvPhone], [CountUsers]) VALUES (3, 0, NULL, N'יועצת עסקית', N'בעלת ותק של 15 שנה בתחום תלווה אתכם בחיפוש עבודה, עד לההשמה בס"ד.', N'ascas@ftyfty', N'099654231', 1)
INSERT [dbo].[Adv] ([AdvId], [AdvStatus], [AdvLink], [AdvTitle], [AdvContent], [AdvMail], [AdvPhone], [CountUsers]) VALUES (6, 1, N'http://localhost:53790/UploadFile/Adv/1043.jpg', NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Adv] ([AdvId], [AdvStatus], [AdvLink], [AdvTitle], [AdvContent], [AdvMail], [AdvPhone], [CountUsers]) VALUES (8, 1, N'http://localhost:53790/UploadFile/Adv/adv2.jpg', NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Adv] ([AdvId], [AdvStatus], [AdvLink], [AdvTitle], [AdvContent], [AdvMail], [AdvPhone], [CountUsers]) VALUES (15, 1, N'http://localhost:53790/UploadFile/Adv/smart-agaent.png', NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Adv] ([AdvId], [AdvStatus], [AdvLink], [AdvTitle], [AdvContent], [AdvMail], [AdvPhone], [CountUsers]) VALUES (16, 0, NULL, N'מפקחת חינוכית', N'גם את מאלה שנמלטות מסוגיות חינוכיות?
עושה בשבילך את העבודה!', N'nmv@gmail.com', N'036185928', 0)
INSERT [dbo].[Adv] ([AdvId], [AdvStatus], [AdvLink], [AdvTitle], [AdvContent], [AdvMail], [AdvPhone], [CountUsers]) VALUES (17, 1, N'http://localhost:53790/UploadFile/Adv/adv3.png', NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Adv] ([AdvId], [AdvStatus], [AdvLink], [AdvTitle], [AdvContent], [AdvMail], [AdvPhone], [CountUsers]) VALUES (19, 1, N'http://localhost:53790/UploadFile/Adv/adv.jpg', NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Adv] ([AdvId], [AdvStatus], [AdvLink], [AdvTitle], [AdvContent], [AdvMail], [AdvPhone], [CountUsers]) VALUES (20, 0, NULL, N'יועצת פיננסית', N'כל שירותי היעוץ במחיר אפסי לאנ"ש', N'4562@465', N'089654723', 0)
INSERT [dbo].[Adv] ([AdvId], [AdvStatus], [AdvLink], [AdvTitle], [AdvContent], [AdvMail], [AdvPhone], [CountUsers]) VALUES (21, 0, NULL, N'ג', N'גג', N'kmk@kmk', N'058784949', 0)
SET IDENTITY_INSERT [dbo].[Adv] OFF
SET IDENTITY_INSERT [dbo].[Area] ON 

INSERT [dbo].[Area] ([AreaId], [AreaName]) VALUES (1, N'כל הארץ')
INSERT [dbo].[Area] ([AreaId], [AreaName]) VALUES (2, N'דרום')
INSERT [dbo].[Area] ([AreaId], [AreaName]) VALUES (3, N'ירושלים והרי יהודה')
INSERT [dbo].[Area] ([AreaId], [AreaName]) VALUES (4, N'מרכז')
INSERT [dbo].[Area] ([AreaId], [AreaName]) VALUES (5, N'צפון')
SET IDENTITY_INSERT [dbo].[Area] OFF
SET IDENTITY_INSERT [dbo].[Boss] ON 

INSERT [dbo].[Boss] ([BossId], [BossName], [BossTel], [BossMail], [BossSubId], [BossPassword], [BossIsConnection], [BossCompanyId]) VALUES (1, N'מירי', N'036763626', N'054@gmail.com', 1, N'd4735e3a265e16eee03f59718b9b5d03019c07d8b6c51f90da3a666eec13ab35', 0, 1)
INSERT [dbo].[Boss] ([BossId], [BossName], [BossTel], [BossMail], [BossSubId], [BossPassword], [BossIsConnection], [BossCompanyId]) VALUES (2, N'נחמה', N'039876543', N'mo@mo', NULL, N'06c973e49be9fdbfdaa84a397b35b05baceec93d5ea35e4cba2d6eaecf97700f', 1, 30)
INSERT [dbo].[Boss] ([BossId], [BossName], [BossTel], [BossMail], [BossSubId], [BossPassword], [BossIsConnection], [BossCompanyId]) VALUES (4, N'מירית', N'095432147', N'uio@uio', NULL, N'1ec63275753fb19a54e664a8d11e7e1529bcd074375e8e06cee38af6e3a5bb9a', 0, 31)
INSERT [dbo].[Boss] ([BossId], [BossName], [BossTel], [BossMail], [BossSubId], [BossPassword], [BossIsConnection], [BossCompanyId]) VALUES (5, N'שרון', N'8657', N'dfs@sdd', NULL, N'50ffa7e6f8419c27922016248a158aa4e131eb3d3173333005b16510a2352baf', 1, 32)
INSERT [dbo].[Boss] ([BossId], [BossName], [BossTel], [BossMail], [BossSubId], [BossPassword], [BossIsConnection], [BossCompanyId]) VALUES (6, N'דבורה קיסטר', N'0583235540', N'kister1010@gmail.com', NULL, N'd9e15de4e0195b8c5f737669f0294ff313c29af095e3df6f1f78c7dc809802cc', 1, 33)
INSERT [dbo].[Boss] ([BossId], [BossName], [BossTel], [BossMail], [BossSubId], [BossPassword], [BossIsConnection], [BossCompanyId]) VALUES (7, N'יהודית כהן', N'0556788614', N'cyehudit10@gmail.com', NULL, N'5255a1ccb34ec1af03e04ae770d03c6edde4db02e6137684ecac8fb51dd9c48b', 0, 18)
INSERT [dbo].[Boss] ([BossId], [BossName], [BossTel], [BossMail], [BossSubId], [BossPassword], [BossIsConnection], [BossCompanyId]) VALUES (8, N'יהודית', N'0556779615', N'jk@h', NULL, N'331151c4dd86b7f196f2936cd3838a9e90c503f5b53d75b13cca9b93f077e2ea', NULL, 15)
INSERT [dbo].[Boss] ([BossId], [BossName], [BossTel], [BossMail], [BossSubId], [BossPassword], [BossIsConnection], [BossCompanyId]) VALUES (9, N'bluma', N'0589786584', N'ppf@cmk', NULL, N'd9e15de4e0195b8c5f737669f0294ff313c29af095e3df6f1f78c7dc809802cc', NULL, 34)
INSERT [dbo].[Boss] ([BossId], [BossName], [BossTel], [BossMail], [BossSubId], [BossPassword], [BossIsConnection], [BossCompanyId]) VALUES (10, N'יהודית לוי', N'059465321', N'fc@cdc', NULL, N'4ae09a19876d6b84782691d8fe9cb9d9d8e0d60a0798d9062fc6bdf35254e34e', NULL, 35)
INSERT [dbo].[Boss] ([BossId], [BossName], [BossTel], [BossMail], [BossSubId], [BossPassword], [BossIsConnection], [BossCompanyId]) VALUES (11, N'MANAGER', N'0504183482', N'idealToJob@gmail.com', NULL, N'a3eb9ed009efb94edea41f0869f1238d534d12a6f5d628dd15ce806b8171ebf4', 0, 36)
INSERT [dbo].[Boss] ([BossId], [BossName], [BossTel], [BossMail], [BossSubId], [BossPassword], [BossIsConnection], [BossCompanyId]) VALUES (12, N'DevoraKister', N'0583235540', N'kister1010@gmail.com', NULL, N'06c973e49be9fdbfdaa84a397b35b05baceec93d5ea35e4cba2d6eaecf97700f', 1, 21)
INSERT [dbo].[Boss] ([BossId], [BossName], [BossTel], [BossMail], [BossSubId], [BossPassword], [BossIsConnection], [BossCompanyId]) VALUES (13, N'sarit', N'035785928', N'kis@gmail.com', NULL, N'b9ed651d072c0048f16c04a098d01c5cd04d9d4ad05bb8f9847914e1708b0093', 1, 27)
INSERT [dbo].[Boss] ([BossId], [BossName], [BossTel], [BossMail], [BossSubId], [BossPassword], [BossIsConnection], [BossCompanyId]) VALUES (14, N'noa', N'0583235640', N'noale1010@gmail.com', NULL, N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 1, 15)
INSERT [dbo].[Boss] ([BossId], [BossName], [BossTel], [BossMail], [BossSubId], [BossPassword], [BossIsConnection], [BossCompanyId]) VALUES (15, N'tali', N'0583235999', N'kistertali@gmail.com', NULL, N'6de34128f654b603384efa7068c4effdb7e9e42f9aa0ee94f962fc3991de9b5d', 1, 19)
INSERT [dbo].[Boss] ([BossId], [BossName], [BossTel], [BossMail], [BossSubId], [BossPassword], [BossIsConnection], [BossCompanyId]) VALUES (16, N'taia', N'7894563521', N'idealllllll@gmail.com', NULL, N'b428ab64360194b09deab9c23d9f429a0c8eaa2860805fa2fc7a65223a5b2748', 1, 27)
INSERT [dbo].[Boss] ([BossId], [BossName], [BossTel], [BossMail], [BossSubId], [BossPassword], [BossIsConnection], [BossCompanyId]) VALUES (17, N'shosh dror', N'0549876566', N'shoshoshosh@gmail.com', NULL, N'4ae09a19876d6b84782691d8fe9cb9d9d8e0d60a0798d9062fc6bdf35254e34e', 1, 16)
INSERT [dbo].[Boss] ([BossId], [BossName], [BossTel], [BossMail], [BossSubId], [BossPassword], [BossIsConnection], [BossCompanyId]) VALUES (18, N'shosh', N'0549876566', N'shoshoshosh@gmail.com', NULL, N'd4f73129fd13c3351954a3d46bee81ada967a0e156f7bf9b72746d936691683f', 1, 2)
INSERT [dbo].[Boss] ([BossId], [BossName], [BossTel], [BossMail], [BossSubId], [BossPassword], [BossIsConnection], [BossCompanyId]) VALUES (19, N'ora', N'05832355', N'kister10789@gmail.com', NULL, N'1ec63275753fb19a54e664a8d11e7e1529bcd074375e8e06cee38af6e3a5bb9a', 1, 15)
INSERT [dbo].[Boss] ([BossId], [BossName], [BossTel], [BossMail], [BossSubId], [BossPassword], [BossIsConnection], [BossCompanyId]) VALUES (20, N'נעמה', N'432345654', N'rtrytyutyrt@jhjhjh', NULL, N'0766fa0a0cd628539962c6464ec047994482dc5dee9a1cb77847abefc3e88a1c', 1, 17)
INSERT [dbo].[Boss] ([BossId], [BossName], [BossTel], [BossMail], [BossSubId], [BossPassword], [BossIsConnection], [BossCompanyId]) VALUES (21, N'גילת', N'0583235540', N'kister1010@gmail.com', NULL, N'5255a1ccb34ec1af03e04ae770d03c6edde4db02e6137684ecac8fb51dd9c48b', 1, 29)
INSERT [dbo].[Boss] ([BossId], [BossName], [BossTel], [BossMail], [BossSubId], [BossPassword], [BossIsConnection], [BossCompanyId]) VALUES (22, N'dasi', N'0583235540', N'dasi@dasi', NULL, N'331151c4dd86b7f196f2936cd3838a9e90c503f5b53d75b13cca9b93f077e2ea', 1, 21)
INSERT [dbo].[Boss] ([BossId], [BossName], [BossTel], [BossMail], [BossSubId], [BossPassword], [BossIsConnection], [BossCompanyId]) VALUES (23, N'ביתיה', N'0583235540', N'lkjnm,@l;', NULL, N'efb9525cafa8e47265049a8c7936475ee53a1f13020815051f64fa1094aa98b5', 1, 32)
INSERT [dbo].[Boss] ([BossId], [BossName], [BossTel], [BossMail], [BossSubId], [BossPassword], [BossIsConnection], [BossCompanyId]) VALUES (24, N'מרים', N'0583235540', N'kister1010@gmail.com', NULL, N'f300345794ce8cb78f6cad0e9ac399ad7fb075e0e3c839d9c75313f1a1003182', 1, 38)
INSERT [dbo].[Boss] ([BossId], [BossName], [BossTel], [BossMail], [BossSubId], [BossPassword], [BossIsConnection], [BossCompanyId]) VALUES (25, N'מרים', N'0583235540', N'kister1010@gmail.com', NULL, N'50ffa7e6f8419c27922016248a158aa4e131eb3d3173333005b16510a2352baf', 0, 38)
INSERT [dbo].[Boss] ([BossId], [BossName], [BossTel], [BossMail], [BossSubId], [BossPassword], [BossIsConnection], [BossCompanyId]) VALUES (26, N'רותי', N'0583235540', N'kister1010@g', NULL, N'd9e15de4e0195b8c5f737669f0294ff313c29af095e3df6f1f78c7dc809802cc', 1, 37)
INSERT [dbo].[Boss] ([BossId], [BossName], [BossTel], [BossMail], [BossSubId], [BossPassword], [BossIsConnection], [BossCompanyId]) VALUES (27, N'מנהל האתר', N'036150802', N'idealToJob@gmail.com', NULL, N'cbd6f5f91e9a1c4871be8f7858f8896fcbbd84f384a6696283172fc65483336b', 1, NULL)
INSERT [dbo].[Boss] ([BossId], [BossName], [BossTel], [BossMail], [BossSubId], [BossPassword], [BossIsConnection], [BossCompanyId]) VALUES (28, N'חוה קיסטר', N'0527176794', N'kister052@gmail.com', NULL, N'c4e642518b56280eed6de019466a13e874e2457ed25b43e2dfa349ba890399a6', 1, 40)
INSERT [dbo].[Boss] ([BossId], [BossName], [BossTel], [BossMail], [BossSubId], [BossPassword], [BossIsConnection], [BossCompanyId]) VALUES (29, N'moria', N'0777110410', N'moria@moria', NULL, N'd60570762d540c88e46f4f43c0b5d8a9c53f95cf42c1f35e4da40ccc6a6c8d88', 1, 21)
INSERT [dbo].[Boss] ([BossId], [BossName], [BossTel], [BossMail], [BossSubId], [BossPassword], [BossIsConnection], [BossCompanyId]) VALUES (30, N'pnina', N'0777110410', N'pnina@pnina', NULL, N'8faa4d02fe09cc858e161fd85ce6a21af9983c4e727d0cb2d2266624fa8c4bb6', 1, 42)
INSERT [dbo].[Boss] ([BossId], [BossName], [BossTel], [BossMail], [BossSubId], [BossPassword], [BossIsConnection], [BossCompanyId]) VALUES (31, N'pnina p', N'0777110410', N'kister1010@gmail.comdds', NULL, N'138d278cf9ac02ec75ec6119034db65cdf29690ab880d8ad7547b12fc931f67e', 1, 19)
INSERT [dbo].[Boss] ([BossId], [BossName], [BossTel], [BossMail], [BossSubId], [BossPassword], [BossIsConnection], [BossCompanyId]) VALUES (32, N'fdf df p', N'0777110410', N're2@de', NULL, N'138d278cf9ac02ec75ec6119034db65cdf29690ab880d8ad7547b12fc931f67e', 1, NULL)
INSERT [dbo].[Boss] ([BossId], [BossName], [BossTel], [BossMail], [BossSubId], [BossPassword], [BossIsConnection], [BossCompanyId]) VALUES (36, N'shoshita@shoshita', N'', N'', NULL, N'03490664cca7b610ecb51a164b08558b83b732f3c34b07329482f821475763e8', 1, NULL)
INSERT [dbo].[Boss] ([BossId], [BossName], [BossTel], [BossMail], [BossSubId], [BossPassword], [BossIsConnection], [BossCompanyId]) VALUES (37, N'shoshita@shoshita', N'0777110410', N'kister1010@gmaצךil.com', NULL, N'03490664cca7b610ecb51a164b08558b83b732f3c34b07329482f821475763e8', 1, NULL)
INSERT [dbo].[Boss] ([BossId], [BossName], [BossTel], [BossMail], [BossSubId], [BossPassword], [BossIsConnection], [BossCompanyId]) VALUES (38, N'ygygy', N'0777110410', N'ubu@rtcrvyb', NULL, N'5100477a8ddfb798f6b9e703c9c8f031ac0cbd66a53d39542298a9e4df2b08ea', 1, 37)
SET IDENTITY_INSERT [dbo].[Boss] OFF
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (1, N'הכל', 1)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (2, N'אופקים', 2)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (3, N'אור יהודה', 4)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (4, N'אור עקיבא', 5)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (15, N'אילת', 2)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (16, N'אלעד', 4)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (17, N'אריאל', 3)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (18, N'אשקלון', 2)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (19, N'אשדוד', 2)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (21, N'באר שבע', 2)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (22, N'בית שאן', 5)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (23, N'בית שמש', 3)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (24, N'ביתר עילית', 3)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (25, N'בני ברק', 4)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (26, N'בת ים', 4)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (27, N'גבעתיים', 4)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (28, N'דימונה', 2)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (29, N'הוד השרון', 4)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (30, N'הרצליה', 4)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (31, N'חדרה', 5)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (32, N'חולון', 4)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (33, N'חיפה', 5)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (34, N'טבריה', 5)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (35, N'טירת כרמל', 5)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (36, N'יבנה', 4)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (37, N'יהוד', 4)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (38, N'ירוחם', 2)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (39, N'ירושלים', 3)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (40, N'כפר סבא', 4)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (41, N'כרמיאל', 5)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (42, N'לוד', 4)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (43, N'מגדל העמק', 5)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (44, N'מודיעין', 3)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (45, N'מודיעין עילית', 3)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (46, N'מעלה אדומים ', 3)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (48, N'נהריה', 5)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (49, N'נס ציונה', 4)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (50, N'נצרת', 5)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (51, N'נצרת עילית', 5)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (52, N'נשר', 5)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (53, N'נתיבות', 2)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (54, N'נתניה', 4)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (55, N'עכו', 5)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (56, N'עפולה', 5)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (57, N'ערד', 2)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (58, N'פתח תקווה ', 4)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (59, N'צפת', 5)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (60, N'קרית אונו', 4)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (61, N'קרית אתא', 5)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (62, N'קרית ביאליק', 5)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (63, N'קרית גת', 2)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (64, N'קרית ים', 5)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (65, N'קרית מוצקין', 5)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (66, N'קרית מלאכי', 2)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (67, N'קרית שמונה', 5)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (68, N'ראש העין', 4)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (69, N'ראשון לציון', 4)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (70, N'רחובות', 4)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (71, N'רמלה', 4)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (72, N'רמת גן', 4)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (73, N'רמת השרון', 4)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (74, N'רעננה', 4)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (75, N'שדרות', 2)
INSERT [dbo].[City] ([CityId], [CityName], [CityAreaId]) VALUES (76, N'תל אביב יפו ', 4)
SET IDENTITY_INSERT [dbo].[City] OFF
SET IDENTITY_INSERT [dbo].[Company] ON 

INSERT [dbo].[Company] ([CompanyId], [CompanyName], [CompanyStreet], [CompanyCityId], [CompanyNumBuild], [CompanyTel], [CompanyMail], [CompanyAreaId]) VALUES (1, N'טריבייס', N'עזרא', 1, 25, N'036182559', N'08@gmail.com', 1)
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [CompanyStreet], [CompanyCityId], [CompanyNumBuild], [CompanyTel], [CompanyMail], [CompanyAreaId]) VALUES (2, N'irox', N'גה', 23, 56, N'039685474', N'as@c', 5)
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [CompanyStreet], [CompanyCityId], [CompanyNumBuild], [CompanyTel], [CompanyMail], [CompanyAreaId]) VALUES (15, N'פנימיה', N'וסרמן', 39, 39, N'0505', N'nknk@gmail.com', 3)
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [CompanyStreet], [CompanyCityId], [CompanyNumBuild], [CompanyTel], [CompanyMail], [CompanyAreaId]) VALUES (16, N'דבורהההההה', N'ארזים', 44, 44, N'05326451', N'44@44', 3)
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [CompanyStreet], [CompanyCityId], [CompanyNumBuild], [CompanyTel], [CompanyMail], [CompanyAreaId]) VALUES (17, N'בית ספר החדש', N'חידוש', 76, 19, N'05326451', N'44@444', 4)
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [CompanyStreet], [CompanyCityId], [CompanyNumBuild], [CompanyTel], [CompanyMail], [CompanyAreaId]) VALUES (18, N'מעון שירת הטף', N'פיזמון', 59, 8, NULL, N'dc@wef', 5)
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [CompanyStreet], [CompanyCityId], [CompanyNumBuild], [CompanyTel], [CompanyMail], [CompanyAreaId]) VALUES (19, N'יש חסד', N'הכל לטובה', 58, 4, N'098765414', N'yesh@yesh', 4)
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [CompanyStreet], [CompanyCityId], [CompanyNumBuild], [CompanyTel], [CompanyMail], [CompanyAreaId]) VALUES (21, N'כללית', N'לנדא', 21, 5, N'035785928', N'lando@clalit', 2)
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [CompanyStreet], [CompanyCityId], [CompanyNumBuild], [CompanyTel], [CompanyMail], [CompanyAreaId]) VALUES (27, N'GRTH', N'טובמאד', 75, 32, N'058595948', N'fewf@wfw', 2)
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [CompanyStreet], [CompanyCityId], [CompanyNumBuild], [CompanyTel], [CompanyMail], [CompanyAreaId]) VALUES (29, N'אירוקס', N'השומר', 53, 16, N'035984765', N'inrox@gmail.gt', 2)
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [CompanyStreet], [CompanyCityId], [CompanyNumBuild], [CompanyTel], [CompanyMail], [CompanyAreaId]) VALUES (30, N'מטלטלה', N'טלטל', 45, 45, N'059876542', N'taltal@koko.gve', 3)
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [CompanyStreet], [CompanyCityId], [CompanyNumBuild], [CompanyTel], [CompanyMail], [CompanyAreaId]) VALUES (31, N'edea', N'נגב', 4, 4, N'085785928', N'edea@edea', 5)
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [CompanyStreet], [CompanyCityId], [CompanyNumBuild], [CompanyTel], [CompanyMail], [CompanyAreaId]) VALUES (32, N'Western Digital', N'עתיר ידע', 40, 14, N'038649758', N'Digital@Digital', 4)
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [CompanyStreet], [CompanyCityId], [CompanyNumBuild], [CompanyTel], [CompanyMail], [CompanyAreaId]) VALUES (33, N'max מבית לאומי קארד', N'דרך בן גוריון', 25, 11, N'035785928', N'max@max', 4)
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [CompanyStreet], [CompanyCityId], [CompanyNumBuild], [CompanyTel], [CompanyMail], [CompanyAreaId]) VALUES (34, N'סלקום', N'הגביש', 54, 10, NULL, N'cellcom@cellcom', 4)
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [CompanyStreet], [CompanyCityId], [CompanyNumBuild], [CompanyTel], [CompanyMail], [CompanyAreaId]) VALUES (35, N'עזר מציון', N'הרב רבינוב', 25, 5, N'035421233', N'ezer@ezer', 4)
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [CompanyStreet], [CompanyCityId], [CompanyNumBuild], [CompanyTel], [CompanyMail], [CompanyAreaId]) VALUES (36, N'מאוחדת צפון', N'זית', 48, 32, N'088569745', N'axa@d', 5)
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [CompanyStreet], [CompanyCityId], [CompanyNumBuild], [CompanyTel], [CompanyMail], [CompanyAreaId]) VALUES (37, N'אנחנו וצאצאינו', N'נחמיה', 25, 15, N'09554654', N'cds@03695874dc', 4)
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [CompanyStreet], [CompanyCityId], [CompanyNumBuild], [CompanyTel], [CompanyMail], [CompanyAreaId]) VALUES (38, N'סמינר הרב וולף', N'בעל התניא', 25, 12, N'036175978', N'wolf@wolf', 4)
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [CompanyStreet], [CompanyCityId], [CompanyNumBuild], [CompanyTel], [CompanyMail], [CompanyAreaId]) VALUES (39, N'moovit', N'אילן רמון', 49, 2, N'088669487', N'MOOVIT@MOO', 2)
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [CompanyStreet], [CompanyCityId], [CompanyNumBuild], [CompanyTel], [CompanyMail], [CompanyAreaId]) VALUES (40, N'זוהר & זוהר', N'הרקון ', 72, 6, NULL, N'hava@zoharzohar.co.il', 4)
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [CompanyStreet], [CompanyCityId], [CompanyNumBuild], [CompanyTel], [CompanyMail], [CompanyAreaId]) VALUES (41, N'BDO', N'אהרונוביץ ', 25, 9, N'035785928', N'BDO@BDO.co', 4)
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [CompanyStreet], [CompanyCityId], [CompanyNumBuild], [CompanyTel], [CompanyMail], [CompanyAreaId]) VALUES (42, N'Q-nomy', N'ריב"ל', 76, 7, N'039785546', N'Qnomy@Qnomy.com', 4)
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [CompanyStreet], [CompanyCityId], [CompanyNumBuild], [CompanyTel], [CompanyMail], [CompanyAreaId]) VALUES (44, N'3base', N'עזרא', 25, 12, N'035785928', N'3base@3base', 4)
SET IDENTITY_INSERT [dbo].[Company] OFF
SET IDENTITY_INSERT [dbo].[Count] ON 

INSERT [dbo].[Count] ([Counts], [CountUser]) VALUES (1, 1094)
SET IDENTITY_INSERT [dbo].[Count] OFF
SET IDENTITY_INSERT [dbo].[Cv] ON 

INSERT [dbo].[Cv] ([CvId], [CvLink], [CvUserId]) VALUES (1, N'', 1)
INSERT [dbo].[Cv] ([CvId], [CvLink], [CvUserId]) VALUES (2, N'a.pdf', 2)
INSERT [dbo].[Cv] ([CvId], [CvLink], [CvUserId]) VALUES (3, N'dfhgk@et.pdf', 27)
INSERT [dbo].[Cv] ([CvId], [CvLink], [CvUserId]) VALUES (4, N'dfhgk@et.docx', 40)
INSERT [dbo].[Cv] ([CvId], [CvLink], [CvUserId]) VALUES (5, N'dfhgk@et.docx', 12)
INSERT [dbo].[Cv] ([CvId], [CvLink], [CvUserId]) VALUES (6, N'dfhgk@et.pdf', 10)
INSERT [dbo].[Cv] ([CvId], [CvLink], [CvUserId]) VALUES (7, N'http://localhost:53790/UploadFile/dfhgk@et.pdf', 3)
INSERT [dbo].[Cv] ([CvId], [CvLink], [CvUserId]) VALUES (8, N'e0527655638@hsx.jpg', 57)
INSERT [dbo].[Cv] ([CvId], [CvLink], [CvUserId]) VALUES (9, N'kjio@fhgj.pdf', 58)
INSERT [dbo].[Cv] ([CvId], [CvLink], [CvUserId]) VALUES (10, N's0504183482@gmail.com.pdf', 61)
INSERT [dbo].[Cv] ([CvId], [CvLink], [CvUserId]) VALUES (11, N'kister1010@gmail.com.docx', 64)
INSERT [dbo].[Cv] ([CvId], [CvLink], [CvUserId]) VALUES (12, N'11@gmail.com.docx', 66)
INSERT [dbo].[Cv] ([CvId], [CvLink], [CvUserId]) VALUES (13, N'poi@poi.jpg', 69)
INSERT [dbo].[Cv] ([CvId], [CvLink], [CvUserId]) VALUES (14, N'shoshita@shoshita.pdf', 70)
INSERT [dbo].[Cv] ([CvId], [CvLink], [CvUserId]) VALUES (15, N'kister1010@gmail.pdf', 71)
INSERT [dbo].[Cv] ([CvId], [CvLink], [CvUserId]) VALUES (16, N'kister1010@gma.jpg', 73)
INSERT [dbo].[Cv] ([CvId], [CvLink], [CvUserId]) VALUES (17, N'kister1010@gma.jpg', 68)
INSERT [dbo].[Cv] ([CvId], [CvLink], [CvUserId]) VALUES (18, N'kister10100@gmail.com.pdf', 78)
INSERT [dbo].[Cv] ([CvId], [CvLink], [CvUserId]) VALUES (19, N'd@fdds.docx', 80)
INSERT [dbo].[Cv] ([CvId], [CvLink], [CvUserId]) VALUES (20, N'n@nknkk.cds.pdf', 81)
INSERT [dbo].[Cv] ([CvId], [CvLink], [CvUserId]) VALUES (21, N'skister1010@gmail.com.pdf', 82)
INSERT [dbo].[Cv] ([CvId], [CvLink], [CvUserId]) VALUES (22, N'racheli@sdv.pdf', 83)
INSERT [dbo].[Cv] ([CvId], [CvLink], [CvUserId]) VALUES (23, N'd@fdhi.docx', 84)
INSERT [dbo].[Cv] ([CvId], [CvLink], [CvUserId]) VALUES (24, N'moria@moriakkh.docx', 85)
INSERT [dbo].[Cv] ([CvId], [CvLink], [CvUserId]) VALUES (25, N'kister1010@gmail.cocm.pdf', 86)
INSERT [dbo].[Cv] ([CvId], [CvLink], [CvUserId]) VALUES (26, N'kister101ft0@gmail.com.docx', 87)
SET IDENTITY_INSERT [dbo].[Cv] OFF
SET IDENTITY_INSERT [dbo].[Job] ON 

INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (3, CAST(N'2020-01-10T15:11:47.343' AS DateTime), 19, N'מפתתחת תוכנה ', 1, 1, 1, 2, 1, 1, 2, 9, 1, NULL, NULL, N'עבודה מטריחפה שווה לכל נפפש תבואו מהר לפננננננננננננננננננננננננננננננננננננננננ שיתפס וניתן למשהי אחר ה', 34, N'עובדת ולא מתבטלת')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (9, CAST(N'2019-06-11T00:00:00.000' AS DateTime), 40, N'מנקה רחובות', 2, 3, 3, 100, NULL, NULL, 1, 4, 1, NULL, NULL, N'אעיעי', 31, N'כלום ')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (11, CAST(N'2019-06-12T00:00:00.000' AS DateTime), 3, N'בודקת מבחנים', 3, 4, 4, 2, NULL, NULL, 2, 2, 1, NULL, NULL, N'יודעת מתמט', 30, N'יושר')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (12, CAST(N'2020-01-13T15:11:47.343' AS DateTime), 7, N'פרופסור', 2, 8, 2, 5, NULL, NULL, 5, 18, 1, NULL, NULL, N'בית התוכנה של סלע מציע לבעלי רקע וידע בתכנות מסלול הכשרה ותעסוקה ייחודי ומאתגר ולתפקידי פיתוח תוכנה בסביבה טכנולוגית מעודכנת וחזקה
לפרטים נוספים נא לשלוח קורות חיים ולציין ציון פסיכומטרי במידה וקיים', 2, N'ניסיון של שנתיים בניהול פרויקטים בתחום מחשוב וטכנולוגיה - חובה
ניסיון בניתוח מערכות
ניסיון של 4 שנים בc#, vb.net, asp.net
ניסיון של 3 שנים בשפת SQL
ניסיון של 3 שנים בעבודה עם XML, JSON
עבודה במתודולוגיית AGILE- יתרון')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (18, CAST(N'2019-06-12T00:00:00.000' AS DateTime), 10, N'מורה מנחה מוצלחת!!!', 1, 1, 1, 5, NULL, NULL, 4, 2, 1, NULL, NULL, N'sftsf', 30, N'stfs')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (19, CAST(N'2019-06-12T00:00:00.000' AS DateTime), 33, N'שומר', 4, 1, 2, 0, NULL, NULL, 2, 11, 1, NULL, NULL, N'ךחךלע', 36, N'בגב')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (20, CAST(N'2019-11-21T00:00:00.000' AS DateTime), 18, N'בודקת תוכנה', 1, 1, 1, 1, NULL, NULL, 2, 5, 1, NULL, NULL, N'יודעת כחלך לחךל חלך חלך חלך חלך חלך חלך ', 32, N'משופשפת, ביעחדו וןםוד גדחןחן חןדםחןג חםןחןדג')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (21, CAST(N'2019-06-16T00:00:00.000' AS DateTime), 23, N'זבנית', 2, 1, 1, 0, NULL, NULL, 1, 2, 1, NULL, NULL, N'חינניות שופעת', 30, N'כושר עמידה בלחצים')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (22, CAST(N'2019-06-16T00:00:00.000' AS DateTime), 7, N'מזכירה רפואית', 1, 3, 3, 2, NULL, NULL, 4, 1, 1, NULL, NULL, N'בעלת משמעת עצמית ', 1, N'זריזה, אחראית ומנוסה')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (23, CAST(N'2019-06-07T00:00:00.000' AS DateTime), 19, N'מפתתחת תוכנה ', 1, 5, 1, 2, 1, 1, 2, 20, 1, NULL, NULL, N'עובדת חרוצה למשרד גדול', 17, N'עובדת ולא מתבטלת')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (24, CAST(N'2019-11-25T13:36:32.960' AS DateTime), 19, N'מפתחת FULL STACK DOT NET WEB לארגון מוביל במרכז', 1, 1, 1, 3, 1, 1, 4, 1, 1, NULL, NULL, N'מפתח/ת FULL STACK DOT NET WEB לארגון מוביל במרכז, ניהול תשתיות פיתוח לאתר החברה
שדרוג טכנולוגיות תוכנה.
פיתוח ent to dend', 1, N'חובה ניסיון של לפחות שלוש שנים בפיתוח . . .net web
חובה ניסיון כמפתח/ת full stack 50% server - js,css,angular2+
ובצד הclient - mvc
ניסיון בעבודה עם sql - חובה
ניסיון בעבודה עם angularjs - יתרון משמעותי')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (25, CAST(N'2019-06-07T00:00:00.000' AS DateTime), 19, N'SYSTEM LINUX
חסוי
', 1, 2, 5, 4, 1, 1, 5, 18, 1, NULL, NULL, N'לארגון ממשלתי בירושלים דרוש/ה איש/ת סיסטם לצוות Linux', 2, N'ניסיון מעל 4 שנים- חובה
ניסיון מעשי של מעל שנתיים עם מערכות הפעלה Linux- חובה
ניסיון בכתיבת תסריטים (Perl,Python,BASH)-שנתיים
הכרת מערכות הפעלה ומוצרים מבית Microsoft- מעל שנתיים
היכרות טובה של תחום ה- Active Directory- שנה עד שנתיים
הכרת מערכות אחסון וגיבוי ו/או תחום בסיסי נתונים SQL , Non-SQL- שנה עד שנתיים')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (26, CAST(N'2019-10-02T00:00:00.000' AS DateTime), 19, N'מנתחת מערכות WEB', 1, 5, 4, 2, 1, 1, 3, 2, 1, NULL, NULL, N'לארגון ממשלתי בירושלים דרוש/ה מנתח/ת מערכות WEB', 30, N'ניסיון של שנתיים בניתוח מערכות - חובה
יתרון לבעל/ת רקע כמפתח/ת
שליטה ב-CSS, HTML, JAVASCRIPT- יתרון משמעותי
ניסיון של שנתיים ב-ANGULAR גרסה 8
ניסיון של 3 שנים בשפת SQL, עבודה מול SQL SERVER')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (27, CAST(N'2019-10-02T00:00:00.000' AS DateTime), 19, N'מנהלת פרויקטים', 1, 1, 5, 2, 1, 1, 4, 4, 1, NULL, NULL, N'למשרד ממשלתי בירושלים דרוש/ה מנהל/ת פרויקטים להובלת פרויקט דגל באגף התקשוב', 31, N'ניסיון של שנתיים בניהול פרויקטים בתחום מחשוב וטכנולוגיה - חובה
ניסיון בניתוח מערכות
ניסיון של 4 שנים בc#, vb.net, asp.net
ניסיון של 3 שנים בשפת SQL
ניסיון של 3 שנים בעבודה עם XML, JSON
עבודה במתודולוגיית AGILE- יתרון')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (28, CAST(N'2019-10-02T00:00:00.000' AS DateTime), 19, N'מפתחת .NET לגוף ביטחוני בירושלים', 2, 3, 3, 2, 1, 1, 1, 6, 1, NULL, NULL, N'גוף ביטחוני מחפש מפתח תכנה בכיר/ה, שיצטרף/תצטרף לצוות פיתוח בפרויקט מאתגר.
התפקיד כולל פיתוח תכנה עפ"י מפרטים, ביצוע עבודות תכנות ועיצוב מורכבות, הנחיית תכניתנים בצוות, כתיבת תכניות מורכבות ו/או מרכזיות בפרויקט, תכנון וביצוע בדיקות ומבחנים סופיים תוך היכרות יסודית עם טכנולוגיות שרלוונטיות לסביבת העבודה של הפרויקט.', 33, N'•ניסיון של 4 שנים לפחות בפיתוח תוכנה.
•ניסיון בעבודה בפרויקטים מרכזיים, בארגונים בינוניים / גדולים.
•ניסיון בפיתוח ב- Microsoft .Net C#.
•ניסיון בפיתוח באחד או יותר מהסביבות Com+, WCF, Web Services,')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (29, CAST(N'2020-01-13T15:11:47.343' AS DateTime), 19, N'מפתח/ת PHP', 1, 4, 1, 2, 1, 1, 5, 1, 1, NULL, NULL, N'חברת הייטק הממוקמת באשקלון, מחפשת מפתח/ת FullStack להצטרף אלינו לתחזוק פרויקטים שונים קיימים, מבוססי PHP, ביצוע שינויים, התאמות, שדרוגים, תחזוקה ועוד.', 1, N'ידע בפיתוח FRONTEND ו- BACKEND
ידע רחב: PHP, JS, HTML5, SASS, OOP, MVC, WordPress Codex, Laravel, git
ניסיון בפיתוח מודרני- webpack, gulp, sass, composer, blade, twig, vagrant/docker, CI/CD, AWS, webhook/api
ניסיון בLINUX
ניסיון ב- PAYMENT API ו- REST API
ניסיון ב- Integration/Automation')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (30, CAST(N'2019-10-02T00:00:00.000' AS DateTime), 19, N'מפתתחת תוכנה ', 1, 5, 4, 2, 1, 1, 1, 1, 1, CAST(N'2019-11-10' AS Date), 1, N'בית התוכנה של סלע מציע לבעלי רקע וידע בתכנות מסלול הכשרה ותעסוקה ייחודי ומאתגר ולתפקידי פיתוח תוכנה בסביבה טכנולוגית מעודכנת וחזקה
לפרטים נוספים נא לשלוח קורות חיים ולציין ציון פסיכומטרי במידה וקיים', 1, N'ידע בתכנות ויכולת מוכחת באחת משפות התכנות C# ,JAVA, CPP
אוהבי טכנולוגיות ומעוניינים לעבוד בסביבה מאתגרת מאד
סיוג בטחוני יהווה יתרון')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (31, CAST(N'2020-01-12T15:11:47.343' AS DateTime), 19, N'תוכניתן/ית JAVA - משרה זמנית!', 6, 2, 2, 2, 1, 1, 4, 2, 1, NULL, NULL, N'לארגון גדול וגלובלי באזור המרכז דרוש/ה תוכניתן/ית JAVA
משרה זמנית לשישה חודשים', 30, N'ניסיון של שנתיים בפיתוח JAVA
ניסיון בתחום האוטומציה
ניסיון בעבודה בסביבת ענן (AWS, Google Cloud, etc.) - יתרון
ניסיון בעבודה עם מתודולוגיית AGILE/SCRUM - יתרון')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (32, CAST(N'2019-10-01T00:00:00.000' AS DateTime), 19, N'מהנדסת וריפקציה', 1, 3, 6, 2, 1, 1, 5, 4, 1, CAST(N'2019-11-10' AS Date), 1, N'עיצוב, פיתוח ובניית דפים בשפת HTML ו-CSS, שימוש ב- FrameWorks וספריות של JS, עבודה מול צוותי פיתוח BackEnd, הקמת אתרי CMS וכו’.', 31, N'עובדת ולא מתבטלת')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (33, CAST(N'2019-10-01T00:00:00.000' AS DateTime), 19, N'fhfhf', 1, 5, 3, 2, 1, 1, 3, 5, 1, NULL, NULL, N'עבודה כעובד/ת חברה אל מול לקוח מאוד גדול, ניתוח מערכות מאפס ואחריות מקצה לקצה החל משלב איסוף דרישות, כתיבת מסמכי אפיון מפורטים, עבודה מול צוות פיתוח ועד לעליה לאוויר.', 32, N'עובדת ולא מתבטלת')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (34, CAST(N'2019-10-01T00:00:00.000' AS DateTime), 19, N'מפתתחת תוכנה ', 1, 3, 1, 2, 1, 1, 1, 2, 1, NULL, NULL, N'דרוש מתכנת/ת WPF לעבודת פיתוח בפרויקט קיים. אפשרי מהבית.', 30, N'עובדת ולא מתבטלת')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (35, CAST(N'2019-10-01T00:00:00.000' AS DateTime), 19, N'מפתתחת תוכנה ', 1, 5, 6, 2, 1, 1, 4, 17, 1, CAST(N'2019-11-10' AS Date), 1, N'פתוח מערכות CRM , עיצוב ובנית בסיסי נתונים. מספר AT 9699.', 16, N'עובדת ולא מתבטלת')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (36, CAST(N'2020-01-12T15:11:47.343' AS DateTime), 19, N'מפתתחת תוכנה ', 2, 2, 5, 2, 1, 1, 4, 20, 1, NULL, NULL, N'מפתח/ת GIS לארגון ממשלתי גדול.', 17, N'עובדת ולא מתבטלת')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (37, CAST(N'2019-10-01T00:00:00.000' AS DateTime), 19, N'מפתתחת תוכנה ', 1, 4, 5, 2, 1, 1, 3, 7, 1, CAST(N'2019-11-10' AS Date), 1, N'חברה המתמחה בפיתוח פתרונות למוסדות פיננסיים בארץ דרוש/ה מתכנת database ו- DevOps לעבודה מעניינת ויציבה בירושלים. תיאור עיקרי תפקיד: אחריות מלאה על ניהול מגוון מערכות במגוון טכנולוגיות, אפיון טכני, אינטגרציות והתקנות. עבודת פיתוח ותחזוקה של בסיסי הנתונים של החברה. עבודה חלקית בתחזוקת ה- Front End של מערכות החבר', 18, N'תואר/השכלה רלוונטית + ניסיון של לפחות 3 שנים בתחום – חובה. ניסיון עם Git בסביבת פיתוח ווינדוס, התקנות ואינטגרציות- חובה. ניסיון עם IIS - חובה. ידע וניסיון בעבודה עם MSSQL – חובה. ניסיון בעבודה עם node.js - יתרון. ידע וניסיון של לפחות שנתיים בפיתוח ב- ASP.NET, linq , entity framework – יתרון. ידע וניסיון בעבודה עם NoSQL – יתרון. ידע וניסיון עם טכנולוגיות front-end כגון: +Angular2, HTML5/CSS, jquery – יתרון.')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (38, CAST(N'2019-10-01T00:00:00.000' AS DateTime), 19, N'c...תוכנה ', 1, 1, 4, 2, 1, 1, 5, 15, 1, NULL, NULL, N'התקנה, ניהול, תפעול ותחזוקה של מוצרי הגנת סייבר, יישום תהליכי אבטחה שגרתיים, זיהוי וטיפול ראשוני באירועי אבטחה ועוד.', 19, N'עובדת ולא מתבטלת')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (39, CAST(N'2019-10-01T00:00:00.000' AS DateTime), 19, N'מפתתחת תוכנה ', 1, 3, 1, 2, 1, 1, 4, 2, 1, NULL, 1, N'פיתוח IOS, פיתוח SWIFT, עבודה עם בסיסי נתונים לוקלים במובייל, פיתוח WEB ועוד . מספר cd 10433.', 30, N'עובדת ולא מתבטלת')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (40, CAST(N'2019-10-01T00:00:00.000' AS DateTime), 19, N'מפתתחת תוכנה ', 1, 4, 1, 2, 1, 1, 3, 1, 1, CAST(N'2019-11-10' AS Date), NULL, N'עבודה מטריחפה שווה לכל נפפש תבואו מהר לפננננננננננננננננננננננננננננננננננננננננ שיתפס וניתן למשהי אחר ה', 1, N'עובדת ולא מתבטלת')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (41, CAST(N'2019-11-21T00:00:00.000' AS DateTime), 19, N'מפתתחת תוכנה ', 1, 2, 6, 2, 1, 1, 1, 5, 1, NULL, NULL, N'לחברה ביטחונית בירושלים דרוש מפתח תשתיות אוטומציה לטווח ארוך.', 32, N'עובדת ולא מתבטלת')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (42, CAST(N'2020-01-13T15:11:47.343' AS DateTime), 19, N'מפתתחת תוכנה ', 1, 5, 2, 2, 1, 1, 4, 1, 1, CAST(N'2019-11-10' AS Date), 1, N'תרשמו מהר לפני שיתפס', 1, N'עובדת ולא מתבטלת')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (43, CAST(N'2019-11-21T00:00:00.000' AS DateTime), 19, N'מפתתחת תוכנה ', 1, 1, 3, 2, 1, 1, 5, 11, 1, NULL, NULL, N'עבודה מטריחפה שווה לכל נפפש תבואו מהר לפננננננננננננננננננננננננננננננננננננננננ שיתפס וניתן למשהי אחר ה', 36, N'עובדת ולא מתבטלת')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (44, CAST(N'2019-11-25T13:36:32.960' AS DateTime), 19, N'מפתתחת תוכנה ', 4, 3, 3, 2, 1, 1, 2, 1, 1, NULL, NULL, N'לחברה ביטחונית בירושלים דרוש מפתח תשתיות אוטומציה לטווח ארוך.', 1, N'עובדת ולא מתבטלת')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (45, CAST(N'2020-01-12T15:11:47.343' AS DateTime), 23, N'דרושה מזכירה לעבודות משרד + תיאום פגישות בירושלים משרת אם', 1, 4, 4, 2, 1, 1, 4, 10, 1, NULL, NULL, N'למשרד שיווק ותיווך נדל"ן דרושה מזכירה לתיאום פגישות וקידום מכירות אם יכולת וורבלית גבוהה.. שעות עבודה מ-9:00 עד 14:00 משרת אם !!. שכר ותנאים טובים למתאימות.', 35, N'שליטה בתוכנות האופיס, עבודה בימים א''-ה'', נדרשת זמינות מיידית, נסיון מכירתי יתרון . יכולת וורבלית גבוהה.')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (46, CAST(N'2019-08-07T00:00:00.000' AS DateTime), 23, N'דרושה אשת מכירות ועוזרת אישית למשרד תיווך ברמות בירושלים!', 1, 4, 5, 7, 1, 1, 1, 9, 1, NULL, NULL, N'דרוש/ה עובד/ת משרד עם ראש גדול למשרה חלקית ו/או לפי שעות (אפשרות למשרה מלאה בהמשך). כעת, מחפשים עובדת טובה ומסורה הן לתפעול וניהול צרכי המשרד בשילוב מכירות (טלמרקטינג), הצעת דירות ללקוחות ממאגר,קביעת פגישות. אסרטיביות ובעלת ביטחון עצמי. בעלת ניסיון בתחום המכירות.', 34, N'כישרון בשיחות טלפון כולל טלמרקטינג (להציע דירות ללקוחות במאגר), שכנוע, ביטחון עצמי, וקביעת פגישות. שליטה מלאה בשימוש במחשב באינטרנט, EXCEL, WORD וכו'' . אסרטיביות ובעלת ניסיון במכירות. כתב יד נאה,ברור וקריא. ראש גדול עם קליטה מהירה. עדיפות לדוברת אנגלית ברמת שפת אם. ניסיון במשרד תיווך יתרון גדול - אבל לא חובה.')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (47, CAST(N'2019-08-07T00:00:00.000' AS DateTime), 1, N'yjtfyj', 1, 1, 6, 8, 1, 1, 5, 6, 1, NULL, NULL, N'fgj', 33, N'ytj')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (51, CAST(N'2019-11-21T00:00:00.000' AS DateTime), 1, N'st', 1, 1, 3, 6, 1, 1, 4, 2, 1, NULL, NULL, N'jghjk', 30, N'gf')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (60, CAST(N'2019-08-07T00:00:00.000' AS DateTime), 34, N'למחלקת יעוץ מס במשרד רו"ח בת"א דרושה מזכירה', 1, 1, 1, 5, 1, 1, 5, 17, 1, NULL, NULL, N'למחלקת יעוץ מס במשרד רו"ח בת"א דרושה מזכירה.', 35, N'דרוש ידע בסיסי בתפעול מחשב. אין צורך בניסיון קודם')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (61, CAST(N'2019-08-07T00:00:00.000' AS DateTime), 24, N'מורה מ"מ לכלכלת בית למוסדות לחינוך מיוחד', 1, 3, 4, 5, 1, 1, 5, 5, 1, NULL, NULL, N'למוסדות לחינוך מיוחד דרושה מורה למ"מ לכלכלת בית, מס'' משרה 120', 18, N'למוסדות לחינוך מיוחד דרושה מורה למ"מ לכלכלת בית, מס'' ')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (62, CAST(N'2019-11-21T00:00:00.000' AS DateTime), 24, N'מדריכות וסייעות לצהרונים ומועדוניות בכל הארץ! תנאים מהטובים בשוק!', 1, 1, 3, 5, 1, 1, 1, 6, 1, NULL, NULL, N'לצהרונים ומועדניות ברחבי הארץ דרושות: סייעות, מובילות, גננות, מפעילות לעבודה בגני הילדים. העבודה עם ילדים מתוקים בגילאי 3-6, או א-ב. שעות עבודה – שעות הצהריים (12:30 או 13:30 ועד 16:30 או 17:30). מתאים גם לסטודנטים/יות, למורות/גננות, גימלאים פעילים. עבודה בסביבה דתית לאומית או חילונית. עבודה 5 ימים בשבוע, ניתן גם פחות. שכר מצוין + כל התנאים הסוציאליים!.', 18, N'אהבה לילדים - חובה כמובן :), ניסיון בתחום – יתרון. מתאים לנשים וגברים כאחד.')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (63, CAST(N'2020-01-13T15:11:47.343' AS DateTime), 1, N'gytuחדש', 1, 4, 1, 5, 1, 1, 4, 9, 1, NULL, NULL, N'gfhחדש', 34, N'fghtyuחדש')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (64, CAST(N'2019-08-07T00:00:00.000' AS DateTime), 1, N'חדששששש', 1, 1, 1, 1, 1, 1, 5, 10, 1, NULL, NULL, N'חדששששש', 35, N'חדששששש')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (75, CAST(N'2019-11-07T21:50:56.953' AS DateTime), 19, N'דרוש/ה מפתח/ת Angular לצוות R&D', 2, 3, 2, 2, 1, 1, 4, 22, 1, CAST(N'2019-11-20' AS Date), 1, N'רוצים להיות חלק בפיתוחים החדישים והמשמעותיים ביותר של מקום העבודה שלכם?
להגיע כל בוקר לצוות מגובש ומשפחתי עם מנהל שחשובה לו ההתקדמות האישית שלכם וגם החיוך על הבוקר?
אנו מחפשים מפתח/ת Angular להשתלבות בצוות תשתיתי קיים הנותן מענה לצוותים הרוחביים בחברה.
העובדה כוללת פיתוח מודלים תשתיתיים בAgular מאפס (משלב האפיון ועד העלאה לאוויר) וכן שדרוג/פיתוח מוצרים עפ"י דרישות השטח.
אתגר ועשייה משמעותית מובטחים!+ ', 21, N'- התמחות בפיתוח Angular2 -חובה . (יתרון משמעותי ל +5 Angular)
- ניסיון בעבודה עם Node.JS, GIT -חובה
- היכרות עם NET.- יתרון
- יכולת עמידה במצבי לחץ - חובה
- נכונות לשעות נוספות בעת הצורך+ CHAR(13)+CHAR(10) + - חובה
- יכולת מציאת פתרונות יצירתיים וחשיבה מחוץ לקופסה+ CHAR(13)+CHAR(10) +
משרה מלאה, לטווח ארוך , לוד')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (76, CAST(N'2019-11-07T16:25:15.690' AS DateTime), 23, N'דרוש/ה סוכן/ת שיווק שטח', 2, 1, 3, 2, 1, 1, 2, 22, 1, CAST(N'2019-11-12' AS Date), 1, N'לחברת שיווק משקאות ותבלינים, דרוש/ה סוכן/ת שיווק דינאמיים לניהול קו חלוקה והרחבתו.
* הוצאת הזמנות עבודה
* גיוס לקוחות חדשים וטיפול בלקוחות קיימים
* ניהול מערך הזמנות
* משרה מלאה / חלקית
* תנאים טובים למתאימים/ות
* אפשרות לעבוד כנגד חשבונית', 21, N'- ניסיון של שנתיים ומעלה בתפקיד רכז/ת משאבי אנוש חובה.
- ידע וניסיון בדיני עבודה וחוזים חובה.
- ניסיון בקליטת עובדים, ניודים, תהליכי סיום העסקה.
- ידעו ניסיון בעולם ה-Outsource יתרון משמעותי.
- תואר ראשון רלוונטי במשאבי אנוש / מדעי ההתנהגות / מדעי החברה.
- ניסיון ברתימת עובדים והנעת תהליכים.
* תנאים מעולים! המשרה מיועדת לנשים וגברים כאחד.')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId], [JobExperience], [JobCVId], [JobOfferId], [JobStars], [JobBossId], [JobStatus], [JobDateCaughtJob], [JobIsByUs], [JobDescribe], [JobCompanyId], [JobRequire]) VALUES (77, CAST(N'2019-11-12T13:13:50.090' AS DateTime), 29, N'Deloitte הפירמה המובילה בעולם דרוש/ה יועצ/ת מס מוסמך', 2, 2, 2, 0, 1, 1, 5, 22, 1, CAST(N'2020-02-12' AS Date), 1, N'מסגרת התפקיד:
ביצוע והכנת דוחות אישיים והצהרות הון.
יכולת התנהלות מול רשויות המס.
סיוע במטלות השוטפות בעניין הגשת הדוחות, שימוש בתוכנות, שימוש בשע"מ, דיווחים לרשויות, פתיחת לקוחות במערכת והגשת בקשות לרשויות המס.', 21, N'יועץ/ת מס מוסמך לאחר סיום לימודים והתמחות.
אנגלית ברמה גבוהה מאוד
יכולת עבודה בצוות
דרושים בתחומים')
INSERT [dbo].[Job] ([JobId], [JobDateAdv], [JobSubId], [JobRole], [JobPartId], [JobPartOutNetId], [JobWorkspaceId
