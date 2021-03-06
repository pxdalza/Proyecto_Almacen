USE [master]
GO
/****** Object:  Database [BDPrueba]    Script Date: 17/03/2022 1:15:57 ******/
CREATE DATABASE [BDPrueba]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BDPrueba', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BDPrueba.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BDPrueba_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BDPrueba_log.ldf' , SIZE = 5120KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BDPrueba] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BDPrueba].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BDPrueba] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BDPrueba] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BDPrueba] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BDPrueba] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BDPrueba] SET ARITHABORT OFF 
GO
ALTER DATABASE [BDPrueba] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BDPrueba] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BDPrueba] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BDPrueba] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BDPrueba] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BDPrueba] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BDPrueba] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BDPrueba] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BDPrueba] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BDPrueba] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BDPrueba] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BDPrueba] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BDPrueba] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BDPrueba] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BDPrueba] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BDPrueba] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BDPrueba] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BDPrueba] SET RECOVERY FULL 
GO
ALTER DATABASE [BDPrueba] SET  MULTI_USER 
GO
ALTER DATABASE [BDPrueba] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BDPrueba] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BDPrueba] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BDPrueba] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BDPrueba] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BDPrueba', N'ON'
GO
ALTER DATABASE [BDPrueba] SET QUERY_STORE = OFF
GO
USE [BDPrueba]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 17/03/2022 1:15:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[CategoriaId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](250) NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[CategoriaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 17/03/2022 1:15:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[ProductoId] [int] IDENTITY(1,1) NOT NULL,
	[CategoriaId] [int] NOT NULL,
	[Nombe] [varchar](250) NOT NULL,
	[Descripcion] [varchar](max) NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([CategoriaId], [Nombre]) VALUES (1, N'Gaseosa')
INSERT [dbo].[Categoria] ([CategoriaId], [Nombre]) VALUES (2, N'Chocolate')
INSERT [dbo].[Categoria] ([CategoriaId], [Nombre]) VALUES (3, N'Caramelo')
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([ProductoId], [CategoriaId], [Nombe], [Descripcion], [Precio]) VALUES (2, 1, N'Coca Cola', N'Gaseosa importada', CAST(2.50 AS Decimal(18, 2)))
INSERT [dbo].[Producto] ([ProductoId], [CategoriaId], [Nombe], [Descripcion], [Precio]) VALUES (3, 2, N'Sublime', N'Chocolate nacional', CAST(1.50 AS Decimal(18, 2)))
INSERT [dbo].[Producto] ([ProductoId], [CategoriaId], [Nombe], [Descripcion], [Precio]) VALUES (4, 1, N'Inka Cola', N'gaseosa inka cola', CAST(2.50 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY([CategoriaId])
REFERENCES [dbo].[Categoria] ([CategoriaId])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Categoria]
GO
/****** Object:  StoredProcedure [dbo].[SP_Delete_Product]    Script Date: 17/03/2022 1:15:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		DA
-- Create date: 09/03/22
-- Description:	SP_Delete_Product
-- =============================================
CREATE PROCEDURE [dbo].[SP_Delete_Product]
	-- Add the parameters for the stored procedure here
	@ProductId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    
		DELETE FROM Producto 
		where ProductoId = @ProductId

END
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_Category]    Script Date: 17/03/2022 1:15:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GET_Category]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select c.CategoriaId, c.Nombre
	from Categoria c

END
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_Product]    Script Date: 17/03/2022 1:15:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		DA
-- Create date: 09/03/22
-- Description:	SP_GET_Product
-- =============================================
CREATE PROCEDURE [dbo].[SP_GET_Product]
	-- Add the parameters for the stored procedure here
	@ProductId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    
		Select p.ProductoId, p.Nombe, p.CategoriaId,  c.Nombre as 'Categoria' , p.Descripcion, p.Precio
		From Producto p 
		inner join Categoria c on p.CategoriaId = c.CategoriaId
		where p.ProductoId = @ProductId

END
GO
/****** Object:  StoredProcedure [dbo].[SP_Insert_Product]    Script Date: 17/03/2022 1:15:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		DA
-- Create date: 09/03/22
-- Description:	SP_ Insert_Product
-- =============================================
CREATE PROCEDURE [dbo].[SP_Insert_Product]
	-- Add the parameters for the stored procedure here

	@CategoriaId int, @Nombre varchar(250), @Descripcion varchar(250), @Precio decimal(18,2)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    
	INSERT INTO [dbo].[Producto]
           ([CategoriaId]
           ,[Nombe]
           ,[Descripcion]
           ,[Precio])
     VALUES
           (@CategoriaId
           ,@Nombre
           ,@Descripcion
           ,@Precio)

END
GO
/****** Object:  StoredProcedure [dbo].[SP_List_Product]    Script Date: 17/03/2022 1:15:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		DA
-- Create date: 09/03/22
-- Description:	SP_List_Product
-- =============================================
CREATE PROCEDURE [dbo].[SP_List_Product]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    
		Select p.ProductoId, p.Nombe,  c.Nombre as 'Categoria' , p.Descripcion, p.Precio
		From Producto p 
		inner join Categoria c on p.CategoriaId = c.CategoriaId
		

END
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Product]    Script Date: 17/03/2022 1:15:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		DA
-- Create date: 09/03/22
-- Description:	SP_Update_Product
-- =============================================
CREATE PROCEDURE [dbo].[SP_Update_Product]
	-- Add the parameters for the stored procedure here
	@ProductoId int,
	@CategoriaId int, @Nombre varchar(250), @Descripcion varchar(250), @Precio decimal(18,2)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    
		UPDATE [dbo].[Producto]
		   SET [CategoriaId] = @CategoriaId
			  ,[Nombe] = @Nombre
			  ,[Descripcion] = @Descripcion
			  ,[Precio] = @Precio
		 WHERE ProductoId = @ProductoId

END
GO
USE [master]
GO
ALTER DATABASE [BDPrueba] SET  READ_WRITE 
GO
