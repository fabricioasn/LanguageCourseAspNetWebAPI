USE [master]
GO

/****** Object:  Database [dbo.CursoDeIdiomas]    Script Date: 14/09/2020 01:55:18 ******/
CREATE DATABASE [dbo.CursoDeIdiomas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbo.CursoDeIdiomas', FILENAME = N'C:\Program Files\MSSQL14.SQLEXPRESS\MSSQL\DATA\dbo.CursoDeIdiomas.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbo.CursoDeIdiomas_log', FILENAME = N'C:\Program Files\MSSQL14.SQLEXPRESS\MSSQL\DATA\dbo.CursoDeIdiomas_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbo.CursoDeIdiomas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [dbo.CursoDeIdiomas] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [dbo.CursoDeIdiomas] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [dbo.CursoDeIdiomas] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [dbo.CursoDeIdiomas] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [dbo.CursoDeIdiomas] SET ARITHABORT OFF 
GO

ALTER DATABASE [dbo.CursoDeIdiomas] SET AUTO_CLOSE ON 
GO

ALTER DATABASE [dbo.CursoDeIdiomas] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [dbo.CursoDeIdiomas] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [dbo.CursoDeIdiomas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [dbo.CursoDeIdiomas] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [dbo.CursoDeIdiomas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [dbo.CursoDeIdiomas] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [dbo.CursoDeIdiomas] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [dbo.CursoDeIdiomas] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [dbo.CursoDeIdiomas] SET  ENABLE_BROKER 
GO

ALTER DATABASE [dbo.CursoDeIdiomas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [dbo.CursoDeIdiomas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [dbo.CursoDeIdiomas] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [dbo.CursoDeIdiomas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [dbo.CursoDeIdiomas] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [dbo.CursoDeIdiomas] SET READ_COMMITTED_SNAPSHOT ON 
GO

ALTER DATABASE [dbo.CursoDeIdiomas] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [dbo.CursoDeIdiomas] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [dbo.CursoDeIdiomas] SET  MULTI_USER 
GO

ALTER DATABASE [dbo.CursoDeIdiomas] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [dbo.CursoDeIdiomas] SET DB_CHAINING OFF 
GO

ALTER DATABASE [dbo.CursoDeIdiomas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [dbo.CursoDeIdiomas] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [dbo.CursoDeIdiomas] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [dbo.CursoDeIdiomas] SET QUERY_STORE = OFF
GO

ALTER DATABASE [dbo.CursoDeIdiomas] SET  READ_WRITE 
GO

