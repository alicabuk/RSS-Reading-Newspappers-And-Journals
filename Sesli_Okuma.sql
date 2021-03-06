USE [master]
GO
/****** Object:  Database [Sesli_Okuma]    Script Date: 10.12.2020 15:52:41 ******/
CREATE DATABASE [Sesli_Okuma]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Sesli_Okuma', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Sesli_Okuma.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Sesli_Okuma_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Sesli_Okuma_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Sesli_Okuma] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Sesli_Okuma].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Sesli_Okuma] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Sesli_Okuma] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Sesli_Okuma] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Sesli_Okuma] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Sesli_Okuma] SET ARITHABORT OFF 
GO
ALTER DATABASE [Sesli_Okuma] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Sesli_Okuma] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Sesli_Okuma] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Sesli_Okuma] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Sesli_Okuma] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Sesli_Okuma] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Sesli_Okuma] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Sesli_Okuma] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Sesli_Okuma] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Sesli_Okuma] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Sesli_Okuma] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Sesli_Okuma] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Sesli_Okuma] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Sesli_Okuma] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Sesli_Okuma] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Sesli_Okuma] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Sesli_Okuma] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Sesli_Okuma] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Sesli_Okuma] SET  MULTI_USER 
GO
ALTER DATABASE [Sesli_Okuma] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Sesli_Okuma] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Sesli_Okuma] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Sesli_Okuma] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Sesli_Okuma] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Sesli_Okuma] SET QUERY_STORE = OFF
GO
USE [Sesli_Okuma]
GO
/****** Object:  Table [dbo].[Dergiler]    Script Date: 10.12.2020 15:52:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dergiler](
	[DergiID] [int] IDENTITY(1,1) NOT NULL,
	[DergiAD] [varchar](150) NULL,
	[DergiRSS] [varchar](200) NULL,
	[DergiLOGO] [image] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gazeteler]    Script Date: 10.12.2020 15:52:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gazeteler](
	[GazeteID] [int] IDENTITY(1,1) NOT NULL,
	[GazeteAD] [varchar](50) NULL,
	[GazeteRSS] [varchar](150) NULL,
	[GazeteLOGO] [image] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Dergiler] ON 

INSERT [dbo].[Dergiler] ([DergiID], [DergiAD], [DergiRSS], [DergiLOGO]) VALUES (1, N'Cumhuriyet Science Journal', N'https://dergipark.org.tr/tr/pub/csj/rss/lastissue/en', NULL)
INSERT [dbo].[Dergiler] ([DergiID], [DergiAD], [DergiRSS], [DergiLOGO]) VALUES (2, N'European Journal of Engineering and Applied Sciences', N'https://dergipark.org.tr/tr/pub/ejeas/rss/lastissue/en', NULL)
INSERT [dbo].[Dergiler] ([DergiID], [DergiAD], [DergiRSS], [DergiLOGO]) VALUES (3, N'UEADER', N'https://dergipark.org.tr/tr/pub/ueader/rss/lastissue/en', NULL)
INSERT [dbo].[Dergiler] ([DergiID], [DergiAD], [DergiRSS], [DergiLOGO]) VALUES (4, N'Journal of Ekonomi', N'https://dergipark.org.tr/tr/pub/ekonomi/rss/lastissue/en', NULL)
INSERT [dbo].[Dergiler] ([DergiID], [DergiAD], [DergiRSS], [DergiLOGO]) VALUES (5, N'International Journal of Agriculture Environment and Food Sciences', N'https://dergipark.org.tr/tr/pub/jaefs/rss/lastissue/en', NULL)
INSERT [dbo].[Dergiler] ([DergiID], [DergiAD], [DergiRSS], [DergiLOGO]) VALUES (6, N'International Anatolia Academic Online Journal Health Sciences', N'https://dergipark.org.tr/tr/pub/iaaojh/rss/lastissue/en', NULL)
INSERT [dbo].[Dergiler] ([DergiID], [DergiAD], [DergiRSS], [DergiLOGO]) VALUES (7, N'Cankaya University Journal of Science and Engineering', N'https://dergipark.org.tr/tr/pub/cankujse/rss/lastissue/en', NULL)
INSERT [dbo].[Dergiler] ([DergiID], [DergiAD], [DergiRSS], [DergiLOGO]) VALUES (8, N'Electronic Letters on Science and Engineering', N'https://dergipark.org.tr/tr/pub/else/rss/lastissue/en', NULL)
INSERT [dbo].[Dergiler] ([DergiID], [DergiAD], [DergiRSS], [DergiLOGO]) VALUES (9, N'Galatasaray Universitesi İletisim', N'http://iletisimdergisi.gsu.edu.tr/tr/pub/rss/lastissue/tr', NULL)
SET IDENTITY_INSERT [dbo].[Dergiler] OFF
GO
SET IDENTITY_INSERT [dbo].[Gazeteler] ON 

INSERT [dbo].[Gazeteler] ([GazeteID], [GazeteAD], [GazeteRSS], [GazeteLOGO]) VALUES (1, N'New York Times', N'https://rss.nytimes.com/services/xml/rss/nyt/World.xml', NULL)
INSERT [dbo].[Gazeteler] ([GazeteID], [GazeteAD], [GazeteRSS], [GazeteLOGO]) VALUES (2, N'RT News', N'https://www.rt.com/rss/news/', NULL)
INSERT [dbo].[Gazeteler] ([GazeteID], [GazeteAD], [GazeteRSS], [GazeteLOGO]) VALUES (3, N'BBC News', N'http://feeds.bbci.co.uk/news/rss.xml', NULL)
INSERT [dbo].[Gazeteler] ([GazeteID], [GazeteAD], [GazeteRSS], [GazeteLOGO]) VALUES (4, N'The Guardian', N'https://www.theguardian.com/uk/rss', NULL)
INSERT [dbo].[Gazeteler] ([GazeteID], [GazeteAD], [GazeteRSS], [GazeteLOGO]) VALUES (5, N'Mail Online', N'https://www.dailymail.co.uk/news/index.rss', NULL)
INSERT [dbo].[Gazeteler] ([GazeteID], [GazeteAD], [GazeteRSS], [GazeteLOGO]) VALUES (6, N'BuzzFeed', N'https://www.buzzfeed.com/world.xml', NULL)
INSERT [dbo].[Gazeteler] ([GazeteID], [GazeteAD], [GazeteRSS], [GazeteLOGO]) VALUES (7, N'NPR Topics ', N'https://feeds.npr.org/1001/rss.xml', NULL)
INSERT [dbo].[Gazeteler] ([GazeteID], [GazeteAD], [GazeteRSS], [GazeteLOGO]) VALUES (8, N'The Times Of India', N'https://economictimes.indiatimes.com/rssfeeds/1373380680.cms', NULL)
INSERT [dbo].[Gazeteler] ([GazeteID], [GazeteAD], [GazeteRSS], [GazeteLOGO]) VALUES (9, N'Miliyet', N'https://www.milliyet.com.tr/rss/rssnew/gundemrss.xml', NULL)
SET IDENTITY_INSERT [dbo].[Gazeteler] OFF
GO
USE [master]
GO
ALTER DATABASE [Sesli_Okuma] SET  READ_WRITE 
GO
