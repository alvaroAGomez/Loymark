USE [master]
GO
/****** Object:  Database [Loymark]    Script Date: 1/4/2023 18:22:34 ******/
CREATE DATABASE [Loymark]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Loymark', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Loymark.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Loymark_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Loymark_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Loymark] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Loymark].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Loymark] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Loymark] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Loymark] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Loymark] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Loymark] SET ARITHABORT OFF 
GO
ALTER DATABASE [Loymark] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Loymark] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Loymark] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Loymark] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Loymark] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Loymark] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Loymark] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Loymark] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Loymark] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Loymark] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Loymark] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Loymark] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Loymark] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Loymark] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Loymark] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Loymark] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Loymark] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Loymark] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Loymark] SET  MULTI_USER 
GO
ALTER DATABASE [Loymark] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Loymark] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Loymark] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Loymark] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Loymark] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Loymark] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Loymark] SET QUERY_STORE = ON
GO
ALTER DATABASE [Loymark] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Loymark]
GO
/****** Object:  Table [dbo].[Actividades]    Script Date: 1/4/2023 18:22:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actividades](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[create_date] [datetime] NOT NULL,
	[id_usuario] [int] NOT NULL,
	[actividad] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Actividadess] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 1/4/2023 18:22:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[apellido] [nvarchar](50) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[fecha_nacimiento] [date] NOT NULL,
	[telefono] [numeric](18, 0) NULL,
	[pais_referencia] [nvarchar](150) NOT NULL,
	[recibir_info] [bit] NOT NULL,
	[fecha_baja] [date] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Actividades] ON 

INSERT [dbo].[Actividades] ([id], [create_date], [id_usuario], [actividad]) VALUES (1, CAST(N'2023-03-31T23:27:51.727' AS DateTime), 11, N'Creación de Usuario')
INSERT [dbo].[Actividades] ([id], [create_date], [id_usuario], [actividad]) VALUES (2, CAST(N'2023-03-31T23:28:10.967' AS DateTime), 12, N'Creación de Usuario')
INSERT [dbo].[Actividades] ([id], [create_date], [id_usuario], [actividad]) VALUES (3, CAST(N'2023-03-31T23:28:26.513' AS DateTime), 12, N'Eliminacion de usuario')
INSERT [dbo].[Actividades] ([id], [create_date], [id_usuario], [actividad]) VALUES (4, CAST(N'2023-03-31T23:29:01.273' AS DateTime), 11, N'Actualizacion de Usuario')
INSERT [dbo].[Actividades] ([id], [create_date], [id_usuario], [actividad]) VALUES (5, CAST(N'2023-04-01T15:38:47.247' AS DateTime), 13, N'Creación de Usuario')
INSERT [dbo].[Actividades] ([id], [create_date], [id_usuario], [actividad]) VALUES (6, CAST(N'2023-04-01T15:39:56.513' AS DateTime), 13, N'Actualizacion de Usuario')
INSERT [dbo].[Actividades] ([id], [create_date], [id_usuario], [actividad]) VALUES (7, CAST(N'2023-04-01T16:18:32.433' AS DateTime), 25, N'Creación de Usuario')
INSERT [dbo].[Actividades] ([id], [create_date], [id_usuario], [actividad]) VALUES (8, CAST(N'2023-04-01T16:20:42.527' AS DateTime), 26, N'Creación de Usuario')
INSERT [dbo].[Actividades] ([id], [create_date], [id_usuario], [actividad]) VALUES (9, CAST(N'2023-04-01T16:21:07.977' AS DateTime), 27, N'Creación de Usuario')
INSERT [dbo].[Actividades] ([id], [create_date], [id_usuario], [actividad]) VALUES (10, CAST(N'2023-04-01T16:24:25.503' AS DateTime), 13, N'Eliminacion de usuario')
INSERT [dbo].[Actividades] ([id], [create_date], [id_usuario], [actividad]) VALUES (11, CAST(N'2023-04-01T16:34:54.540' AS DateTime), 26, N'Actualizacion de Usuario')
INSERT [dbo].[Actividades] ([id], [create_date], [id_usuario], [actividad]) VALUES (12, CAST(N'2023-04-01T16:35:20.483' AS DateTime), 25, N'Actualizacion de Usuario')
INSERT [dbo].[Actividades] ([id], [create_date], [id_usuario], [actividad]) VALUES (13, CAST(N'2023-04-01T16:41:56.563' AS DateTime), 28, N'Creación de Usuario')
INSERT [dbo].[Actividades] ([id], [create_date], [id_usuario], [actividad]) VALUES (14, CAST(N'2023-04-01T16:44:07.070' AS DateTime), 29, N'Creación de Usuario')
INSERT [dbo].[Actividades] ([id], [create_date], [id_usuario], [actividad]) VALUES (15, CAST(N'2023-04-01T16:47:15.107' AS DateTime), 30, N'Creación de Usuario')
INSERT [dbo].[Actividades] ([id], [create_date], [id_usuario], [actividad]) VALUES (16, CAST(N'2023-04-01T16:47:35.183' AS DateTime), 31, N'Creación de Usuario')
INSERT [dbo].[Actividades] ([id], [create_date], [id_usuario], [actividad]) VALUES (17, CAST(N'2023-04-01T16:49:04.897' AS DateTime), 11, N'Actualizacion de Usuario')
INSERT [dbo].[Actividades] ([id], [create_date], [id_usuario], [actividad]) VALUES (18, CAST(N'2023-04-01T18:06:37.660' AS DateTime), 26, N'Actualizacion de Usuario')
INSERT [dbo].[Actividades] ([id], [create_date], [id_usuario], [actividad]) VALUES (19, CAST(N'2023-04-01T18:12:48.083' AS DateTime), 11, N'Actualizacion de Usuario')
INSERT [dbo].[Actividades] ([id], [create_date], [id_usuario], [actividad]) VALUES (20, CAST(N'2023-04-01T18:12:57.847' AS DateTime), 29, N'Eliminacion de usuario')
INSERT [dbo].[Actividades] ([id], [create_date], [id_usuario], [actividad]) VALUES (21, CAST(N'2023-04-01T18:13:14.817' AS DateTime), 31, N'Eliminacion de usuario')
INSERT [dbo].[Actividades] ([id], [create_date], [id_usuario], [actividad]) VALUES (22, CAST(N'2023-04-01T18:13:31.043' AS DateTime), 32, N'Creación de Usuario')
SET IDENTITY_INSERT [dbo].[Actividades] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([id], [nombre], [apellido], [email], [fecha_nacimiento], [telefono], [pais_referencia], [recibir_info], [fecha_baja]) VALUES (11, N'alvaro', N'gomez', N'alvaro@gmail.com', CAST(N'1992-02-13' AS Date), CAST(3513072365 AS Numeric(18, 0)), N'EC', 0, NULL)
INSERT [dbo].[Usuarios] ([id], [nombre], [apellido], [email], [fecha_nacimiento], [telefono], [pais_referencia], [recibir_info], [fecha_baja]) VALUES (12, N'andres', N'gomez', N'alvaro@gmail.com', CAST(N'1992-02-13' AS Date), CAST(3513072365 AS Numeric(18, 0)), N'AR- Argentina', 1, CAST(N'2023-03-31' AS Date))
INSERT [dbo].[Usuarios] ([id], [nombre], [apellido], [email], [fecha_nacimiento], [telefono], [pais_referencia], [recibir_info], [fecha_baja]) VALUES (13, N'string', N'string', N'string', CAST(N'2023-04-01' AS Date), CAST(0 AS Numeric(18, 0)), N'string', 0, CAST(N'2023-04-01' AS Date))
INSERT [dbo].[Usuarios] ([id], [nombre], [apellido], [email], [fecha_nacimiento], [telefono], [pais_referencia], [recibir_info], [fecha_baja]) VALUES (25, N'update', N'update', N'alvaro11122@gmail.com', CAST(N'0001-01-01' AS Date), CAST(3513072365 AS Numeric(18, 0)), N'US', 0, NULL)
INSERT [dbo].[Usuarios] ([id], [nombre], [apellido], [email], [fecha_nacimiento], [telefono], [pais_referencia], [recibir_info], [fecha_baja]) VALUES (26, N'test', N'test', N'alvaro@fdjd.com', CAST(N'0001-01-01' AS Date), CAST(12345484 AS Numeric(18, 0)), N'BR', 0, NULL)
INSERT [dbo].[Usuarios] ([id], [nombre], [apellido], [email], [fecha_nacimiento], [telefono], [pais_referencia], [recibir_info], [fecha_baja]) VALUES (27, N'opoopasd', N'adasd', N'asdasdas@qejkasd', CAST(N'0001-01-01' AS Date), CAST(4545445 AS Numeric(18, 0)), N'EC', 0, NULL)
INSERT [dbo].[Usuarios] ([id], [nombre], [apellido], [email], [fecha_nacimiento], [telefono], [pais_referencia], [recibir_info], [fecha_baja]) VALUES (28, N'qwe', N'asdasda', N'1223123', CAST(N'0001-01-01' AS Date), CAST(445 AS Numeric(18, 0)), N'BR', 0, NULL)
INSERT [dbo].[Usuarios] ([id], [nombre], [apellido], [email], [fecha_nacimiento], [telefono], [pais_referencia], [recibir_info], [fecha_baja]) VALUES (29, N'eee', N'eeeeee', N'qweq', CAST(N'0001-01-01' AS Date), CAST(1212 AS Numeric(18, 0)), N'BR', 0, CAST(N'2023-04-01' AS Date))
INSERT [dbo].[Usuarios] ([id], [nombre], [apellido], [email], [fecha_nacimiento], [telefono], [pais_referencia], [recibir_info], [fecha_baja]) VALUES (30, N'qwe', N'eeee', N'alvaro.gomez@dicsys.com', CAST(N'0001-01-01' AS Date), CAST(54351307236 AS Numeric(18, 0)), N'AR', 0, NULL)
INSERT [dbo].[Usuarios] ([id], [nombre], [apellido], [email], [fecha_nacimiento], [telefono], [pais_referencia], [recibir_info], [fecha_baja]) VALUES (31, N'qweqwe', N'qweee', N'ewwe', CAST(N'2023-04-07' AS Date), CAST(12312312 AS Numeric(18, 0)), N'CL', 0, CAST(N'2023-04-01' AS Date))
INSERT [dbo].[Usuarios] ([id], [nombre], [apellido], [email], [fecha_nacimiento], [telefono], [pais_referencia], [recibir_info], [fecha_baja]) VALUES (32, N'frewrew', N'ewrrr', N'ewrewrwe', CAST(N'2023-04-10' AS Date), CAST(13123123 AS Numeric(18, 0)), N'CL', 0, NULL)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
ALTER TABLE [dbo].[Actividades]  WITH CHECK ADD  CONSTRAINT [FK_Actividadess_Usuarios] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[Usuarios] ([id])
GO
ALTER TABLE [dbo].[Actividades] CHECK CONSTRAINT [FK_Actividadess_Usuarios]
GO
USE [master]
GO
ALTER DATABASE [Loymark] SET  READ_WRITE 
GO
