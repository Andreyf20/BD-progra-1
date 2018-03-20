USE [master]
GO
/****** Object:  Database [BBD1]    Script Date: 19/3/2018 08:40:59 ******/
CREATE DATABASE [BBD1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BBD1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\BBD1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BBD1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\BBD1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BBD1] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BBD1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BBD1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BBD1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BBD1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BBD1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BBD1] SET ARITHABORT OFF 
GO
ALTER DATABASE [BBD1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BBD1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BBD1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BBD1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BBD1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BBD1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BBD1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BBD1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BBD1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BBD1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BBD1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BBD1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BBD1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BBD1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BBD1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BBD1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BBD1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BBD1] SET RECOVERY FULL 
GO
ALTER DATABASE [BBD1] SET  MULTI_USER 
GO
ALTER DATABASE [BBD1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BBD1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BBD1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BBD1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BBD1] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BBD1', N'ON'
GO
ALTER DATABASE [BBD1] SET QUERY_STORE = OFF
GO
USE [BBD1]
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
USE [BBD1]
GO
/****** Object:  Table [dbo].[EstadoGrupo]    Script Date: 19/3/2018 08:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoGrupo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoGxE]    Script Date: 19/3/2018 08:41:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoGxE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EstadoGxE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estudiante]    Script Date: 19/3/2018 08:41:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estudiante](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Correo] [varchar](50) NOT NULL,
	[Contraseña] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Estudiante] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Evaluacion]    Script Date: 19/3/2018 08:41:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evaluacion](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdGrupoxRubro] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Fecha] [date] NOT NULL,
	[ValorPorcentual] [int] NOT NULL,
 CONSTRAINT [PK_Evaluacion] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EvaluacionesxEstudiantes]    Script Date: 19/3/2018 08:41:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EvaluacionesxEstudiantes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdGrupoxEstudiante] [int] NOT NULL,
	[IdEvaluacion] [int] NOT NULL,
	[Nota] [int] NOT NULL,
 CONSTRAINT [PK_EvaluacionesxEstudiantes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grupo]    Script Date: 19/3/2018 08:41:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grupo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdEstado] [int] NULL,
	[IdPeriodo] [int] NULL,
	[NombreCurso] [varchar](50) NULL,
	[CodigoGrupo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GrupoxEstudiante]    Script Date: 19/3/2018 08:41:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GrupoxEstudiante](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdGrupo] [int] NOT NULL,
	[IdEstadoGxE] [int] NOT NULL,
	[IdEstudiante] [int] NOT NULL,
	[NotaAcumulada] [int] NOT NULL,
 CONSTRAINT [PK_GrupoxEstudiante] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GrupoxRubro]    Script Date: 19/3/2018 08:41:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GrupoxRubro](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdGrupo] [int] NOT NULL,
	[IdRubro] [int] NOT NULL,
	[ValorPorcentual] [int] NOT NULL,
	[Esfijo] [bit] NOT NULL,
	[Cantidad] [int] NOT NULL,
 CONSTRAINT [PK_GrupoxRubro] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Periodo]    Script Date: 19/3/2018 08:41:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Periodo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FechaInicio] [date] NOT NULL,
	[FechaFInal] [date] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Periodo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rubro]    Script Date: 19/3/2018 08:41:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rubro](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Rubro] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EvaluacionesxEstudiantes]  WITH CHECK ADD  CONSTRAINT [FK_EvaluacionesxEstudiantes_IdEvaluacion] FOREIGN KEY([IdEvaluacion])
REFERENCES [dbo].[Evaluacion] ([ID])
GO
ALTER TABLE [dbo].[EvaluacionesxEstudiantes] CHECK CONSTRAINT [FK_EvaluacionesxEstudiantes_IdEvaluacion]
GO
ALTER TABLE [dbo].[EvaluacionesxEstudiantes]  WITH CHECK ADD  CONSTRAINT [FK_EvaluacionesxEstudiantes_IdGrupoxEstudiante] FOREIGN KEY([IdGrupoxEstudiante])
REFERENCES [dbo].[GrupoxEstudiante] ([ID])
GO
ALTER TABLE [dbo].[EvaluacionesxEstudiantes] CHECK CONSTRAINT [FK_EvaluacionesxEstudiantes_IdGrupoxEstudiante]
GO
ALTER TABLE [dbo].[Grupo]  WITH CHECK ADD  CONSTRAINT [FK_Grupo_IdEstado] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[EstadoGrupo] ([ID])
GO
ALTER TABLE [dbo].[Grupo] CHECK CONSTRAINT [FK_Grupo_IdEstado]
GO
ALTER TABLE [dbo].[Grupo]  WITH CHECK ADD  CONSTRAINT [FK_Grupo_IdPeriodo] FOREIGN KEY([IdPeriodo])
REFERENCES [dbo].[Periodo] ([ID])
GO
ALTER TABLE [dbo].[Grupo] CHECK CONSTRAINT [FK_Grupo_IdPeriodo]
GO
ALTER TABLE [dbo].[GrupoxEstudiante]  WITH CHECK ADD  CONSTRAINT [FK_GrupoxEstudiante_IdEstadoGxE] FOREIGN KEY([IdEstadoGxE])
REFERENCES [dbo].[EstadoGxE] ([ID])
GO
ALTER TABLE [dbo].[GrupoxEstudiante] CHECK CONSTRAINT [FK_GrupoxEstudiante_IdEstadoGxE]
GO
ALTER TABLE [dbo].[GrupoxEstudiante]  WITH CHECK ADD  CONSTRAINT [FK_GrupoxEstudiante_IdEstudiante] FOREIGN KEY([IdEstudiante])
REFERENCES [dbo].[Estudiante] ([ID])
GO
ALTER TABLE [dbo].[GrupoxEstudiante] CHECK CONSTRAINT [FK_GrupoxEstudiante_IdEstudiante]
GO
ALTER TABLE [dbo].[GrupoxEstudiante]  WITH CHECK ADD  CONSTRAINT [FK_GrupoxEstudiante_IdGrupo] FOREIGN KEY([IdGrupo])
REFERENCES [dbo].[Grupo] ([ID])
GO
ALTER TABLE [dbo].[GrupoxEstudiante] CHECK CONSTRAINT [FK_GrupoxEstudiante_IdGrupo]
GO
ALTER TABLE [dbo].[GrupoxRubro]  WITH CHECK ADD  CONSTRAINT [FK_GrupoxRubro_IdGrupo] FOREIGN KEY([IdGrupo])
REFERENCES [dbo].[Grupo] ([ID])
GO
ALTER TABLE [dbo].[GrupoxRubro] CHECK CONSTRAINT [FK_GrupoxRubro_IdGrupo]
GO
ALTER TABLE [dbo].[GrupoxRubro]  WITH CHECK ADD  CONSTRAINT [FK_GrupoxRubro_IdRubro] FOREIGN KEY([IdRubro])
REFERENCES [dbo].[Rubro] ([ID])
GO
ALTER TABLE [dbo].[GrupoxRubro] CHECK CONSTRAINT [FK_GrupoxRubro_IdRubro]
GO
USE [master]
GO
ALTER DATABASE [BBD1] SET  READ_WRITE 
GO
