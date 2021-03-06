USE [master]
GO
/****** Object:  Database [KompShop]    Script Date: 15.06.2022 11:50:32 ******/
CREATE DATABASE [KompShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KompShop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\KompShop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'KompShop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\KompShop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [KompShop] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KompShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KompShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KompShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KompShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KompShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KompShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [KompShop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [KompShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KompShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KompShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KompShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KompShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KompShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KompShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KompShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KompShop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [KompShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KompShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KompShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KompShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KompShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KompShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [KompShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KompShop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [KompShop] SET  MULTI_USER 
GO
ALTER DATABASE [KompShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KompShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KompShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KompShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [KompShop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [KompShop] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [KompShop] SET QUERY_STORE = OFF
GO
USE [KompShop]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 15.06.2022 11:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[IDClient] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](30) NULL,
	[Name] [nvarchar](30) NULL,
	[Patronymic] [nvarchar](30) NULL,
	[Phone] [nvarchar](11) NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[IDClient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Delivery]    Script Date: 15.06.2022 11:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Delivery](
	[IDDelivery] [int] IDENTITY(1,1) NOT NULL,
	[IDVendor] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Notes] [nvarchar](150) NULL,
 CONSTRAINT [PK_Delivery] PRIMARY KEY CLUSTERED 
(
	[IDDelivery] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeliveryComposition]    Script Date: 15.06.2022 11:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveryComposition](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDDelivery] [int] NULL,
	[IDProduct] [int] NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_DeliveryComposition] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 15.06.2022 11:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[IDOrder] [int] IDENTITY(1,1) NOT NULL,
	[IDPersonal] [int] NOT NULL,
	[IDClient] [int] NOT NULL,
	[Date] [date] NULL,
	[Tips] [nvarchar](100) NULL,
	[IsFinily] [bit] NULL,
	[IsProcess] [bit] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[IDOrder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderComposition]    Script Date: 15.06.2022 11:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderComposition](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDOrder] [int] NULL,
	[IDProduct] [int] NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_OrderComposition] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personal]    Script Date: 15.06.2022 11:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personal](
	[IDPersonal] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](150) NOT NULL,
	[Name] [nvarchar](30) NULL,
	[Patronymic] [nvarchar](30) NULL,
	[DateBirth] [date] NULL,
	[Phone] [nvarchar](18) NULL,
	[Position] [nvarchar](50) NULL,
	[Login] [nvarchar](40) NOT NULL,
	[Password] [nvarchar](40) NOT NULL,
	[Tips] [nvarchar](50) NULL,
 CONSTRAINT [PK_Personal] PRIMARY KEY CLUSTERED 
(
	[IDPersonal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Price]    Script Date: 15.06.2022 11:50:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Price](
	[IDPrice] [int] IDENTITY(1,1) NOT NULL,
	[IDProduct] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_Price] PRIMARY KEY CLUSTERED 
(
	[IDPrice] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vendor]    Script Date: 15.06.2022 11:50:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendor](
	[IDVendor] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Maneger] [nvarchar](150) NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Adress] [nvarchar](150) NULL,
	[Tips] [nvarchar](150) NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[IDVendor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WareHouse]    Script Date: 15.06.2022 11:50:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WareHouse](
	[IDProduct] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Description] [nvarchar](150) NULL,
	[FullQuantity] [int] NOT NULL,
 CONSTRAINT [PK_Nomenclature] PRIMARY KEY CLUSTERED 
(
	[IDProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([IDClient], [Surname], [Name], [Patronymic], [Phone]) VALUES (1, N'Фролов', N'Михей', N'  Юриевич ', N'786-85-18')
INSERT [dbo].[Client] ([IDClient], [Surname], [Name], [Patronymic], [Phone]) VALUES (2, N'Мещеряков', N'Натанович', N'Тарас     ', N'213-39-63')
INSERT [dbo].[Client] ([IDClient], [Surname], [Name], [Patronymic], [Phone]) VALUES (3, N'Чигракова', N'Степановна', N'Эльвира   ', N'630-44-03')
INSERT [dbo].[Client] ([IDClient], [Surname], [Name], [Patronymic], [Phone]) VALUES (4, N'Жиганова', N'Ксения', N'Адаповна  ', N'096-27-89')
INSERT [dbo].[Client] ([IDClient], [Surname], [Name], [Patronymic], [Phone]) VALUES (5, N'Веденина', N'Агата', N'Николаевна', N'929-15-85')
INSERT [dbo].[Client] ([IDClient], [Surname], [Name], [Patronymic], [Phone]) VALUES (6, N'Ижутина', N'Любовь', N'Юлиевна   ', N'669-80-08')
INSERT [dbo].[Client] ([IDClient], [Surname], [Name], [Patronymic], [Phone]) VALUES (7, N'Сайбаталов', N'Карл', N'Артемович ', N'742-67-57')
INSERT [dbo].[Client] ([IDClient], [Surname], [Name], [Patronymic], [Phone]) VALUES (8, N'Макаркина', N'Агния', N'Тимофеевна', N'818-42-00')
INSERT [dbo].[Client] ([IDClient], [Surname], [Name], [Patronymic], [Phone]) VALUES (9, N'Урусов ', N'Кондратий', N'Юриевич   ', N'038-09-17')
INSERT [dbo].[Client] ([IDClient], [Surname], [Name], [Patronymic], [Phone]) VALUES (10, N'Панюшкина', N'Яна', N'Володовна ', N'141-80-17')
INSERT [dbo].[Client] ([IDClient], [Surname], [Name], [Patronymic], [Phone]) VALUES (11, N'Авдеев', N'Кирил', N'Мефодьевич', N'123-456-789')
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[Delivery] ON 

INSERT [dbo].[Delivery] ([IDDelivery], [IDVendor], [Date], [Notes]) VALUES (1, 1, CAST(N'2020-12-18' AS Date), NULL)
INSERT [dbo].[Delivery] ([IDDelivery], [IDVendor], [Date], [Notes]) VALUES (2, 2, CAST(N'2020-12-18' AS Date), NULL)
INSERT [dbo].[Delivery] ([IDDelivery], [IDVendor], [Date], [Notes]) VALUES (3, 3, CAST(N'2020-12-18' AS Date), NULL)
INSERT [dbo].[Delivery] ([IDDelivery], [IDVendor], [Date], [Notes]) VALUES (4, 4, CAST(N'2020-12-18' AS Date), NULL)
INSERT [dbo].[Delivery] ([IDDelivery], [IDVendor], [Date], [Notes]) VALUES (5, 5, CAST(N'2020-12-18' AS Date), NULL)
INSERT [dbo].[Delivery] ([IDDelivery], [IDVendor], [Date], [Notes]) VALUES (6, 6, CAST(N'2020-12-18' AS Date), NULL)
INSERT [dbo].[Delivery] ([IDDelivery], [IDVendor], [Date], [Notes]) VALUES (7, 7, CAST(N'2020-12-18' AS Date), NULL)
INSERT [dbo].[Delivery] ([IDDelivery], [IDVendor], [Date], [Notes]) VALUES (8, 8, CAST(N'2020-12-18' AS Date), NULL)
INSERT [dbo].[Delivery] ([IDDelivery], [IDVendor], [Date], [Notes]) VALUES (9, 9, CAST(N'2020-12-18' AS Date), NULL)
INSERT [dbo].[Delivery] ([IDDelivery], [IDVendor], [Date], [Notes]) VALUES (10, 10, CAST(N'2020-12-18' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[Delivery] OFF
GO
SET IDENTITY_INSERT [dbo].[DeliveryComposition] ON 

INSERT [dbo].[DeliveryComposition] ([ID], [IDDelivery], [IDProduct], [Quantity], [Price]) VALUES (1, 1, 1, 2, CAST(400.00 AS Decimal(18, 2)))
INSERT [dbo].[DeliveryComposition] ([ID], [IDDelivery], [IDProduct], [Quantity], [Price]) VALUES (2, 1, 2, 1, CAST(100.00 AS Decimal(18, 2)))
INSERT [dbo].[DeliveryComposition] ([ID], [IDDelivery], [IDProduct], [Quantity], [Price]) VALUES (3, 2, 4, 1, CAST(200.00 AS Decimal(18, 2)))
INSERT [dbo].[DeliveryComposition] ([ID], [IDDelivery], [IDProduct], [Quantity], [Price]) VALUES (4, 2, 10, 2, CAST(5000.00 AS Decimal(18, 2)))
INSERT [dbo].[DeliveryComposition] ([ID], [IDDelivery], [IDProduct], [Quantity], [Price]) VALUES (5, 3, 3, 1, CAST(100.00 AS Decimal(18, 2)))
INSERT [dbo].[DeliveryComposition] ([ID], [IDDelivery], [IDProduct], [Quantity], [Price]) VALUES (6, 4, 4, 1, CAST(200.00 AS Decimal(18, 2)))
INSERT [dbo].[DeliveryComposition] ([ID], [IDDelivery], [IDProduct], [Quantity], [Price]) VALUES (7, 5, 5, 1, CAST(300.00 AS Decimal(18, 2)))
INSERT [dbo].[DeliveryComposition] ([ID], [IDDelivery], [IDProduct], [Quantity], [Price]) VALUES (8, 6, 6, 1, CAST(400.00 AS Decimal(18, 2)))
INSERT [dbo].[DeliveryComposition] ([ID], [IDDelivery], [IDProduct], [Quantity], [Price]) VALUES (9, 7, 7, 1, CAST(150.00 AS Decimal(18, 2)))
INSERT [dbo].[DeliveryComposition] ([ID], [IDDelivery], [IDProduct], [Quantity], [Price]) VALUES (10, 8, 8, 1, CAST(170.30 AS Decimal(18, 2)))
INSERT [dbo].[DeliveryComposition] ([ID], [IDDelivery], [IDProduct], [Quantity], [Price]) VALUES (11, 9, 1, 1, CAST(200.00 AS Decimal(18, 2)))
INSERT [dbo].[DeliveryComposition] ([ID], [IDDelivery], [IDProduct], [Quantity], [Price]) VALUES (12, 10, 4, 1, CAST(120.35 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[DeliveryComposition] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([IDOrder], [IDPersonal], [IDClient], [Date], [Tips], [IsFinily], [IsProcess]) VALUES (1, 1, 1, CAST(N'1991-02-01' AS Date), NULL, 0, 1)
INSERT [dbo].[Order] ([IDOrder], [IDPersonal], [IDClient], [Date], [Tips], [IsFinily], [IsProcess]) VALUES (2, 2, 2, CAST(N'2020-10-20' AS Date), NULL, 0, 0)
INSERT [dbo].[Order] ([IDOrder], [IDPersonal], [IDClient], [Date], [Tips], [IsFinily], [IsProcess]) VALUES (3, 3, 3, CAST(N'2020-05-05' AS Date), NULL, 0, 0)
INSERT [dbo].[Order] ([IDOrder], [IDPersonal], [IDClient], [Date], [Tips], [IsFinily], [IsProcess]) VALUES (4, 4, 4, CAST(N'2020-05-11' AS Date), NULL, 0, 0)
INSERT [dbo].[Order] ([IDOrder], [IDPersonal], [IDClient], [Date], [Tips], [IsFinily], [IsProcess]) VALUES (5, 5, 5, CAST(N'2020-05-11' AS Date), NULL, 1, 1)
INSERT [dbo].[Order] ([IDOrder], [IDPersonal], [IDClient], [Date], [Tips], [IsFinily], [IsProcess]) VALUES (6, 6, 6, CAST(N'2020-01-14' AS Date), NULL, 0, 0)
INSERT [dbo].[Order] ([IDOrder], [IDPersonal], [IDClient], [Date], [Tips], [IsFinily], [IsProcess]) VALUES (7, 7, 7, CAST(N'2020-05-11' AS Date), NULL, 0, 0)
INSERT [dbo].[Order] ([IDOrder], [IDPersonal], [IDClient], [Date], [Tips], [IsFinily], [IsProcess]) VALUES (8, 8, 8, CAST(N'2020-10-20' AS Date), NULL, 0, 0)
INSERT [dbo].[Order] ([IDOrder], [IDPersonal], [IDClient], [Date], [Tips], [IsFinily], [IsProcess]) VALUES (9, 9, 9, CAST(N'2020-05-11' AS Date), NULL, 0, 0)
INSERT [dbo].[Order] ([IDOrder], [IDPersonal], [IDClient], [Date], [Tips], [IsFinily], [IsProcess]) VALUES (10, 10, 10, CAST(N'2020-10-20' AS Date), NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderComposition] ON 

INSERT [dbo].[OrderComposition] ([ID], [IDOrder], [IDProduct], [Quantity]) VALUES (1, 1, 1, 1)
INSERT [dbo].[OrderComposition] ([ID], [IDOrder], [IDProduct], [Quantity]) VALUES (2, 2, 2, 4)
INSERT [dbo].[OrderComposition] ([ID], [IDOrder], [IDProduct], [Quantity]) VALUES (3, 2, 1, 2)
INSERT [dbo].[OrderComposition] ([ID], [IDOrder], [IDProduct], [Quantity]) VALUES (4, 3, 3, 1)
INSERT [dbo].[OrderComposition] ([ID], [IDOrder], [IDProduct], [Quantity]) VALUES (5, 4, 4, 1)
INSERT [dbo].[OrderComposition] ([ID], [IDOrder], [IDProduct], [Quantity]) VALUES (6, 5, 5, 1)
INSERT [dbo].[OrderComposition] ([ID], [IDOrder], [IDProduct], [Quantity]) VALUES (7, 6, 6, 1)
INSERT [dbo].[OrderComposition] ([ID], [IDOrder], [IDProduct], [Quantity]) VALUES (8, 7, 7, 1)
INSERT [dbo].[OrderComposition] ([ID], [IDOrder], [IDProduct], [Quantity]) VALUES (9, 8, 8, 1)
INSERT [dbo].[OrderComposition] ([ID], [IDOrder], [IDProduct], [Quantity]) VALUES (10, 9, 9, 1)
INSERT [dbo].[OrderComposition] ([ID], [IDOrder], [IDProduct], [Quantity]) VALUES (11, 10, 10, 2)
SET IDENTITY_INSERT [dbo].[OrderComposition] OFF
GO
SET IDENTITY_INSERT [dbo].[Personal] ON 

INSERT [dbo].[Personal] ([IDPersonal], [Surname], [Name], [Patronymic], [DateBirth], [Phone], [Position], [Login], [Password], [Tips]) VALUES (1, N'Курбанова', N'Зинаида', N'Всеволодовна', CAST(N'1991-11-13' AS Date), N'021-46-47', N'Кладовщик', N'WareMan1', N'WareMan1', NULL)
INSERT [dbo].[Personal] ([IDPersonal], [Surname], [Name], [Patronymic], [DateBirth], [Phone], [Position], [Login], [Password], [Tips]) VALUES (2, N'Огурцова', N'Полина', N'Александровна', CAST(N'2020-11-18' AS Date), N'543-33-42', N'Кладовщик', N'WareMan2', N'WareMan2', NULL)
INSERT [dbo].[Personal] ([IDPersonal], [Surname], [Name], [Patronymic], [DateBirth], [Phone], [Position], [Login], [Password], [Tips]) VALUES (3, N'Абакумов', N'Мефодий', N'Тихонович', CAST(N'2020-11-23' AS Date), N'982-22-25', N'Директор', N'Admin', N'Admin', NULL)
INSERT [dbo].[Personal] ([IDPersonal], [Surname], [Name], [Patronymic], [DateBirth], [Phone], [Position], [Login], [Password], [Tips]) VALUES (4, N'Богуна', N'Арина', N'Ивановна', CAST(N'1993-07-09' AS Date), N'959-91-24', N'Продавец', N'SaleMan1', N'SaleMan', NULL)
INSERT [dbo].[Personal] ([IDPersonal], [Surname], [Name], [Patronymic], [DateBirth], [Phone], [Position], [Login], [Password], [Tips]) VALUES (5, N'Гриневеца', N'Эмилия', N'Данилевна', CAST(N'1994-12-15' AS Date), N'193-75-13', N'Продавец', N'SaleMan2', N'SaleMan', NULL)
INSERT [dbo].[Personal] ([IDPersonal], [Surname], [Name], [Patronymic], [DateBirth], [Phone], [Position], [Login], [Password], [Tips]) VALUES (6, N'Ярцов', N'Игнатий', N'Федотович', CAST(N'1997-01-07' AS Date), N'826-54-50', N'Продавец', N'SaleMan3', N'SaleMan', NULL)
INSERT [dbo].[Personal] ([IDPersonal], [Surname], [Name], [Patronymic], [DateBirth], [Phone], [Position], [Login], [Password], [Tips]) VALUES (7, N'Бархотов', N'Наум', N'Самсонович', CAST(N'1998-01-30' AS Date), N'279-86-99', N'Продавец', N'SaleMan4', N'SaleMan', NULL)
INSERT [dbo].[Personal] ([IDPersonal], [Surname], [Name], [Patronymic], [DateBirth], [Phone], [Position], [Login], [Password], [Tips]) VALUES (8, N'Рязанова', N'Стела', N'Всеволодовна', CAST(N'1999-01-26' AS Date), N'893-46-53', N'Продавец', N'SaleMan5', N'SaleMan', NULL)
INSERT [dbo].[Personal] ([IDPersonal], [Surname], [Name], [Patronymic], [DateBirth], [Phone], [Position], [Login], [Password], [Tips]) VALUES (9, N'Истомин', N'Кондрат', N'Ефремович', CAST(N'2001-02-16' AS Date), N'790-02-28', N'Продавец', N'SaleMan6', N'SaleMan', NULL)
INSERT [dbo].[Personal] ([IDPersonal], [Surname], [Name], [Patronymic], [DateBirth], [Phone], [Position], [Login], [Password], [Tips]) VALUES (10, N'Громова', N'Анисья', N'Олеговна', CAST(N'1999-12-09' AS Date), N'029-27-35', N'Кладовщик', N'WareMan3', N'WareMan3', NULL)
SET IDENTITY_INSERT [dbo].[Personal] OFF
GO
SET IDENTITY_INSERT [dbo].[Price] ON 

INSERT [dbo].[Price] ([IDPrice], [IDProduct], [Price], [Date]) VALUES (1, 1, 100, CAST(N'2020-12-21' AS Date))
INSERT [dbo].[Price] ([IDPrice], [IDProduct], [Price], [Date]) VALUES (2, 2, 200, CAST(N'2020-12-21' AS Date))
INSERT [dbo].[Price] ([IDPrice], [IDProduct], [Price], [Date]) VALUES (3, 3, 300, CAST(N'2020-12-21' AS Date))
INSERT [dbo].[Price] ([IDPrice], [IDProduct], [Price], [Date]) VALUES (4, 4, 400, CAST(N'2020-12-21' AS Date))
INSERT [dbo].[Price] ([IDPrice], [IDProduct], [Price], [Date]) VALUES (5, 5, 500, CAST(N'2020-12-21' AS Date))
INSERT [dbo].[Price] ([IDPrice], [IDProduct], [Price], [Date]) VALUES (6, 6, 600, CAST(N'2020-12-21' AS Date))
INSERT [dbo].[Price] ([IDPrice], [IDProduct], [Price], [Date]) VALUES (7, 7, 700, CAST(N'2020-12-21' AS Date))
INSERT [dbo].[Price] ([IDPrice], [IDProduct], [Price], [Date]) VALUES (8, 8, 800, CAST(N'2020-12-21' AS Date))
INSERT [dbo].[Price] ([IDPrice], [IDProduct], [Price], [Date]) VALUES (9, 9, 900, CAST(N'2020-12-21' AS Date))
INSERT [dbo].[Price] ([IDPrice], [IDProduct], [Price], [Date]) VALUES (10, 10, 11000, CAST(N'2020-12-21' AS Date))
INSERT [dbo].[Price] ([IDPrice], [IDProduct], [Price], [Date]) VALUES (11, 1, 150, CAST(N'2022-05-26' AS Date))
INSERT [dbo].[Price] ([IDPrice], [IDProduct], [Price], [Date]) VALUES (12, 11, 234, CAST(N'2027-05-22' AS Date))
SET IDENTITY_INSERT [dbo].[Price] OFF
GO
SET IDENTITY_INSERT [dbo].[Vendor] ON 

INSERT [dbo].[Vendor] ([IDVendor], [Name], [Maneger], [Phone], [Adress], [Tips]) VALUES (1, N'Intel', N'Рытин Рюрик Никанорович', N'985-61-18', N'3 Internatsionala, bld. 65, appt. 174', N'Дорого')
INSERT [dbo].[Vendor] ([IDVendor], [Name], [Maneger], [Phone], [Adress], [Tips]) VALUES (2, N'AMD', N'Акинфеева Кира Леонидовна', N'398-85-23', N'Kommuny, bld. 10, appt. 19', NULL)
INSERT [dbo].[Vendor] ([IDVendor], [Name], [Maneger], [Phone], [Adress], [Tips]) VALUES (3, N'MSI', N'Дворецкова Ефросинья Емельяновна', N'327-98-41', N'Mira Prosp., bld. 50, appt. 121', NULL)
INSERT [dbo].[Vendor] ([IDVendor], [Name], [Maneger], [Phone], [Adress], [Tips]) VALUES (4, N'Seageyt', N'Лагутин Василий Эрнстович', N'750-57-50', N' Kalarasha Ul., bld. 2/А, appt. 3', NULL)
INSERT [dbo].[Vendor] ([IDVendor], [Name], [Maneger], [Phone], [Adress], [Tips]) VALUES (5, N'3DFX', N'Муравьева Владислава Евгениевна', N'018-04-64', N'Obezdnaya Ul., bld. 15, appt. 34', NULL)
INSERT [dbo].[Vendor] ([IDVendor], [Name], [Maneger], [Phone], [Adress], [Tips]) VALUES (6, N'ATI', N'Кирхенштейна Вероника Георгиевна', N'915-39-38', N'Pugachevskiy Trakt, bld. 29, appt. 51', NULL)
INSERT [dbo].[Vendor] ([IDVendor], [Name], [Maneger], [Phone], [Adress], [Tips]) VALUES (7, N'NVIDIA', N'Абалышева Любовь Степановна', N'393-15-42', N'Pr.oktyabrskiy, bld. 4, appt. 81

', NULL)
INSERT [dbo].[Vendor] ([IDVendor], [Name], [Maneger], [Phone], [Adress], [Tips]) VALUES (8, N'OKLICK', N'Позона Эльвира Святославовна', N'451-93-69', N'Kommunisticheskiy, bld. 42/1, appt. 21', NULL)
INSERT [dbo].[Vendor] ([IDVendor], [Name], [Maneger], [Phone], [Adress], [Tips]) VALUES (9, N'DEXP', N'Блинова Зинаида Антониновна', N'153-70-33', N'Vostochnoe SHosse, bld. 42, appt. 55', NULL)
INSERT [dbo].[Vendor] ([IDVendor], [Name], [Maneger], [Phone], [Adress], [Tips]) VALUES (10, N'S3', N'Валуева Агния Святославовна', N'282-65-33', N'Ibragimova, bld. 47/1, appt. 46', NULL)
INSERT [dbo].[Vendor] ([IDVendor], [Name], [Maneger], [Phone], [Adress], [Tips]) VALUES (11, N'D3', N'Бесидова Зинаида Антониновна', N'282-65-24', N'Батурдинская', NULL)
INSERT [dbo].[Vendor] ([IDVendor], [Name], [Maneger], [Phone], [Adress], [Tips]) VALUES (12, N'MED-X', N'Абалгунова Настасья Ивановна', N'282-64-30', N'Vostokokamenskay st 4', NULL)
SET IDENTITY_INSERT [dbo].[Vendor] OFF
GO
SET IDENTITY_INSERT [dbo].[WareHouse] ON 

INSERT [dbo].[WareHouse] ([IDProduct], [Name], [Description], [FullQuantity]) VALUES (1, N'Цилиндр', NULL, 3)
INSERT [dbo].[WareHouse] ([IDProduct], [Name], [Description], [FullQuantity]) VALUES (2, N'Процессор', NULL, 1)
INSERT [dbo].[WareHouse] ([IDProduct], [Name], [Description], [FullQuantity]) VALUES (3, N'Модуль памяти', NULL, 1)
INSERT [dbo].[WareHouse] ([IDProduct], [Name], [Description], [FullQuantity]) VALUES (4, N'Жесткий диск', NULL, 1)
INSERT [dbo].[WareHouse] ([IDProduct], [Name], [Description], [FullQuantity]) VALUES (5, N'Мышь', NULL, 1)
INSERT [dbo].[WareHouse] ([IDProduct], [Name], [Description], [FullQuantity]) VALUES (6, N'Микрофон', NULL, 1)
INSERT [dbo].[WareHouse] ([IDProduct], [Name], [Description], [FullQuantity]) VALUES (7, N'Материнская плата', NULL, 1)
INSERT [dbo].[WareHouse] ([IDProduct], [Name], [Description], [FullQuantity]) VALUES (8, N'Клавиатура', NULL, 1)
INSERT [dbo].[WareHouse] ([IDProduct], [Name], [Description], [FullQuantity]) VALUES (9, N'Накопитель', NULL, 1)
INSERT [dbo].[WareHouse] ([IDProduct], [Name], [Description], [FullQuantity]) VALUES (10, N'Сетевой шнур', NULL, 1)
INSERT [dbo].[WareHouse] ([IDProduct], [Name], [Description], [FullQuantity]) VALUES (11, N'Монитор', NULL, 2)
SET IDENTITY_INSERT [dbo].[WareHouse] OFF
GO
ALTER TABLE [dbo].[Delivery]  WITH CHECK ADD  CONSTRAINT [FK_Delivery_Vendor] FOREIGN KEY([IDVendor])
REFERENCES [dbo].[Vendor] ([IDVendor])
GO
ALTER TABLE [dbo].[Delivery] CHECK CONSTRAINT [FK_Delivery_Vendor]
GO
ALTER TABLE [dbo].[DeliveryComposition]  WITH CHECK ADD  CONSTRAINT [FK_DeliveryComposition_Delivery] FOREIGN KEY([IDDelivery])
REFERENCES [dbo].[Delivery] ([IDDelivery])
GO
ALTER TABLE [dbo].[DeliveryComposition] CHECK CONSTRAINT [FK_DeliveryComposition_Delivery]
GO
ALTER TABLE [dbo].[DeliveryComposition]  WITH CHECK ADD  CONSTRAINT [FK_DeliveryComposition_WareHouse] FOREIGN KEY([IDProduct])
REFERENCES [dbo].[WareHouse] ([IDProduct])
GO
ALTER TABLE [dbo].[DeliveryComposition] CHECK CONSTRAINT [FK_DeliveryComposition_WareHouse]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Client] FOREIGN KEY([IDClient])
REFERENCES [dbo].[Client] ([IDClient])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Client]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Personal] FOREIGN KEY([IDPersonal])
REFERENCES [dbo].[Personal] ([IDPersonal])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Personal]
GO
ALTER TABLE [dbo].[OrderComposition]  WITH CHECK ADD  CONSTRAINT [FK_OrderComposition_Order] FOREIGN KEY([IDOrder])
REFERENCES [dbo].[Order] ([IDOrder])
GO
ALTER TABLE [dbo].[OrderComposition] CHECK CONSTRAINT [FK_OrderComposition_Order]
GO
ALTER TABLE [dbo].[OrderComposition]  WITH CHECK ADD  CONSTRAINT [FK_OrderComposition_WareHouse] FOREIGN KEY([IDProduct])
REFERENCES [dbo].[WareHouse] ([IDProduct])
GO
ALTER TABLE [dbo].[OrderComposition] CHECK CONSTRAINT [FK_OrderComposition_WareHouse]
GO
ALTER TABLE [dbo].[Price]  WITH CHECK ADD  CONSTRAINT [FK_Price_WareHouse] FOREIGN KEY([IDProduct])
REFERENCES [dbo].[WareHouse] ([IDProduct])
GO
ALTER TABLE [dbo].[Price] CHECK CONSTRAINT [FK_Price_WareHouse]
GO
USE [master]
GO
ALTER DATABASE [KompShop] SET  READ_WRITE 
GO
