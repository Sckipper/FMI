USE [master]
GO
/****** Object:  Database [ShopApp]    Script Date: 11-Aug-17 7:59:34 PM ******/
CREATE DATABASE [ShopApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShopApp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\ShopApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ShopApp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\ShopApp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ShopApp] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShopApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShopApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShopApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShopApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShopApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShopApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShopApp] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ShopApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShopApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShopApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShopApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShopApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShopApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShopApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShopApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShopApp] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ShopApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShopApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShopApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShopApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShopApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShopApp] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ShopApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShopApp] SET RECOVERY FULL 
GO
ALTER DATABASE [ShopApp] SET  MULTI_USER 
GO
ALTER DATABASE [ShopApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShopApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShopApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShopApp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ShopApp] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ShopApp', N'ON'
GO
ALTER DATABASE [ShopApp] SET QUERY_STORE = OFF
GO
USE [ShopApp]
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
USE [ShopApp]
GO
/****** Object:  User [Sckipper]    Script Date: 11-Aug-17 7:59:34 PM ******/
CREATE USER [Sckipper] FOR LOGIN [Sckipper] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [IIS APPPOOL\DefaultAppPool]    Script Date: 11-Aug-17 7:59:35 PM ******/
CREATE USER [IIS APPPOOL\DefaultAppPool] FOR LOGIN [IIS APPPOOL\DefaultAppPool] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [admin]    Script Date: 11-Aug-17 7:59:35 PM ******/
CREATE USER [admin] FOR LOGIN [admin] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [Sckipper]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [Sckipper]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [Sckipper]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [Sckipper]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [Sckipper]
GO
ALTER ROLE [db_datareader] ADD MEMBER [Sckipper]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [Sckipper]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [Sckipper]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [Sckipper]
GO
ALTER ROLE [db_owner] ADD MEMBER [IIS APPPOOL\DefaultAppPool]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [IIS APPPOOL\DefaultAppPool]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [IIS APPPOOL\DefaultAppPool]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [IIS APPPOOL\DefaultAppPool]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [IIS APPPOOL\DefaultAppPool]
GO
ALTER ROLE [db_datareader] ADD MEMBER [IIS APPPOOL\DefaultAppPool]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [IIS APPPOOL\DefaultAppPool]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [IIS APPPOOL\DefaultAppPool]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [IIS APPPOOL\DefaultAppPool]
GO
ALTER ROLE [db_owner] ADD MEMBER [admin]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [admin]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [admin]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [admin]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [admin]
GO
ALTER ROLE [db_datareader] ADD MEMBER [admin]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [admin]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [admin]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [admin]
GO
/****** Object:  Table [dbo].[Angajat]    Script Date: 11-Aug-17 7:59:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Angajat](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MagazinID] [int] NOT NULL,
	[Nume] [nvarchar](50) NULL,
	[Prenume] [nvarchar](50) NOT NULL,
	[CNP] [numeric](13, 0) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Parola] [nvarchar](512) NOT NULL,
	[DataAngajare] [date] NOT NULL,
	[Salariu] [int] NOT NULL,
	[Functie] [nvarchar](50) NULL,
 CONSTRAINT [PK_Angajat] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categorie]    Script Date: 11-Aug-17 7:59:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorie](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategorieID] [int] NULL,
	[Nume] [nvarchar](50) NOT NULL,
	[Cod] [nvarchar](50) NOT NULL,
	[Descriere] [nvarchar](1024) NULL,
	[Imagine] [nvarchar](50) NULL,
 CONSTRAINT [PK_Categorie] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Furnizor]    Script Date: 11-Aug-17 7:59:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Furnizor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nume] [nvarchar](50) NOT NULL,
	[Adresa] [nvarchar](50) NOT NULL,
	[Oras] [nvarchar](50) NOT NULL,
	[Telefon] [numeric](10, 0) NOT NULL,
 CONSTRAINT [PK_Furnizor] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Livrare]    Script Date: 11-Aug-17 7:59:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Livrare](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FurnizorID] [int] NOT NULL,
	[MagazinID] [int] NOT NULL,
	[DataSolicitare] [date] NOT NULL,
	[DataLivrare] [date] NULL,
	[Status] [nvarchar](50) NOT NULL,
	[Descriere] [nvarchar](512) NULL,
	[Pret] [int] NOT NULL,
 CONSTRAINT [PK_Livrare] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Magazin]    Script Date: 11-Aug-17 7:59:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Magazin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Adresa] [nvarchar](128) NULL,
	[Denumire] [nvarchar](50) NOT NULL,
	[Imagine] [nvarchar](50) NOT NULL,
	[Oras] [nvarchar](50) NULL,
 CONSTRAINT [PK_Magazin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produs]    Script Date: 11-Aug-17 7:59:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategorieID] [int] NOT NULL,
	[MagazinID] [int] NOT NULL,
	[Denumire] [nvarchar](50) NOT NULL,
	[Greutate] [nvarchar](50) NULL,
	[Pret] [float] NULL,
	[Cantitate] [int] NOT NULL,
	[DataExpirate] [date] NULL,
	[Descriere] [nvarchar](1024) NULL,
	[Imagine] [nvarchar](50) NULL,
 CONSTRAINT [PK_Produs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Angajat]  WITH CHECK ADD  CONSTRAINT [FK_Angajat_Magazin] FOREIGN KEY([MagazinID])
REFERENCES [dbo].[Magazin] ([ID])
GO
ALTER TABLE [dbo].[Angajat] CHECK CONSTRAINT [FK_Angajat_Magazin]
GO
ALTER TABLE [dbo].[Livrare]  WITH CHECK ADD  CONSTRAINT [FK_Livrare_Furnizor] FOREIGN KEY([FurnizorID])
REFERENCES [dbo].[Furnizor] ([ID])
GO
ALTER TABLE [dbo].[Livrare] CHECK CONSTRAINT [FK_Livrare_Furnizor]
GO
ALTER TABLE [dbo].[Livrare]  WITH CHECK ADD  CONSTRAINT [FK_Livrare_Magazin] FOREIGN KEY([MagazinID])
REFERENCES [dbo].[Magazin] ([ID])
GO
ALTER TABLE [dbo].[Livrare] CHECK CONSTRAINT [FK_Livrare_Magazin]
GO
ALTER TABLE [dbo].[Produs]  WITH CHECK ADD  CONSTRAINT [FK_Produs_Magazin] FOREIGN KEY([MagazinID])
REFERENCES [dbo].[Magazin] ([ID])
GO
ALTER TABLE [dbo].[Produs] CHECK CONSTRAINT [FK_Produs_Magazin]
GO
ALTER TABLE [dbo].[Produs]  WITH CHECK ADD  CONSTRAINT [FK_Produs_Produs] FOREIGN KEY([CategorieID])
REFERENCES [dbo].[Categorie] ([ID])
GO
ALTER TABLE [dbo].[Produs] CHECK CONSTRAINT [FK_Produs_Produs]
GO
USE [master]
GO
ALTER DATABASE [ShopApp] SET  READ_WRITE 
GO

insert into Categorie 
(CategorieID, Nume, Cod, Descriere, Imagine)
values 
(null, 'Legume, fructe si flori', '1', 'Legume, fructe si flori', ''),
(null, 'Bauturi alcoolice si nealcoolice', '10', 'Bauturi alcoolice si nealcoolice', 'img_bauturi_alcoolice_si_nealcoolice'),
(null, 'Dulciuri', '2', '', ''),
(null, 'Pescarie, Branzeturi, Mezeluri', '2', '', ''),
(1, 'Rosii', '1-1-3', '', ''),
(2, 'Suc', '10-2-2', '', 'img_suc'),
(3, 'Chipsuri', '2-3-4', '', ''),
(1, 'Mere', '1-2-3', '', ''),
(1, 'Portocale', '1-2-3', '', ''),
(1, 'Margarete', '1-3-3', '', ''),
(2, 'Whiskey', '10-1-2', '', ''),
(2, 'Bere', '10-1-2', 'Descriere Bere', 'img_bere'),
(2, 'Apa', '10-1-2', '', 'img_apa'),
(3, 'Ciocolata', '10-1-2', '', ''),
(3, 'Biscuiti', '2-2-4', '', ''),
(3, 'Croissant', '2-4-4', '', ''),
(4, 'Pesti', '6-1-3', '', ''),
(4, 'Branza', '6-2-3', '', ''),
(4, 'Mezeluri', '6-3-3', '', '');

Insert into Magazin
values ('Bucuresti', 'ShopZapp', 'img_ShopZapp', 'Bucuresti')

Insert into Angajat (MagazinID, Nume, Prenume, CNP, Email, Parola, DataAngajare, Salariu, Functie)
values (1, 'Radut', 'Daniel', '1231231231231', 'admin@ShopZapp.com', 'admin', GETDATE(), 2300, 'Admin')

insert into Produs
(CategorieID, MagazinID, Denumire, Greutate, Pret, Cantitate, DataExpirate, Descriere, Imagine)
values
(10, 1, 'Margarete de gradina', null, 4, 40, null, 'Margarete decorative', null),
(10, 1, 'Margarete de ocazie', null, 5, 20, null, 'Margarete', null),
(11, 1, 'Jack Daniel''s', '500 ml', 60, 20, null, 'Bautura Alcoolica', null),
(11, 1, 'Ballentines', '500 ml', 50, 22, null, 'Bautura Alcoolica', null),
(13, 1, 'Bucovina', '1 L', 2.8, 50, '2019-08-24', 'Apa plata', null),
(14, 1, 'Milka', '100 g', 3.8, 50,'2018-04-04', 'Apa minerala naturala carbogazificata Bucovina are un continut redus de sodiu, gust placut si echilibrat, precum si proprietati deosebite de a lega si retine dioxidul de carbon, asigurand tranzitul de electroliti in organism, esentiali functionarii normale a acestuia', 'img_bucovina'),
(14, 1, 'Poiana', '500 g', 20, 30, '2019-08-24', '', null),
(8, 1, 'Mere rosii', null, 3, 50, null, '', null),
(8, 1, 'Mere verzi', null, 4, 50, null, '', null),
(17, 1, 'Somn', null, 12, 50, null, '', null),
(5, 1, 'Rosii', null, 4, 90, '2017-07-13', 'Rosii romanesti', null),
(6, 1, 'Pepsi', '2 L', 6.5, 60, '2018-04-05', 'Bautura carbogazoasa', 'img_pepsi'),
(6, 1, 'Coca-Cola', '1 L', 4.5, 60, '2019-01-07', 'Bautura carbogazoasa', 'img_coca_cola'),
(12, 1, 'Stella Artois', '2 L', 7, 40, '2020-04-21', 'Bautura alcoolica', 'img_stella_artois'),
(15, 1, 'Biscuiti Petit Beurre', '100 g', 5, 20, '2018-04-06', 'Biscuiti', null),
(16, 1, '7 Days', '60 g', 2.5, 40, '2018-10-10', '', null),
(18, 1, 'Branza de oaie', null, 10, 60, '2017-08-10', '', null),
(9, 1, 'Portocale', null, 3, 50, '2017-09-01', '', null),
(18, 1, 'Cod', null, 11, 50, null, '', null),
(6, 1, 'Prigat', '2 L', 4.9, 50, '2018-10-10', 'Suc de portocale necarbogazos', 'img_prigat'),
(7, 1, 'Lay''s', '240 g', 5, 40, '2018-07-12', 'Chipsuri sarate', null);




