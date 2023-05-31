CREATE DATABASE EXAMEN_NEWXPLORA;
GO

USE [EXAMEN_NEWXPLORA]
GO


/****** Object:  Table [dbo].[TB_LIBROS]    Script Date: 31/05/2023 11:09:20 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_LIBROS](
	[id_libro] [int] IDENTITY(1,1) NOT NULL,
	[nom_libro] [varchar](50) NULL,
	[autor_libro] [varchar](50) NULL,
	[categoria] [varchar](50) NULL,
	[fecha_lanzamiento] [varchar](50) NULL,
	[estado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_libro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TB_LIBROS] ON 
GO
INSERT [dbo].[TB_LIBROS] ([id_libro], [nom_libro], [autor_libro], [categoria], [fecha_lanzamiento], [estado]) VALUES (3, N'Carliño', N'Veriño', N'Torriño', N'2023-09-09', 1)
GO
INSERT [dbo].[TB_LIBROS] ([id_libro], [nom_libro], [autor_libro], [categoria], [fecha_lanzamiento], [estado]) VALUES (5, N'Power Xplora', N'Bi xplora', N'Xtrategia xplora', N'2005-05-05', 1)
GO
SET IDENTITY_INSERT [dbo].[TB_LIBROS] OFF
GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCA_LIBRO]    Script Date: 31/05/2023 11:09:20 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_BUSCA_LIBRO]
@id_libro int

as
	BEGIN
		
	select * from TB_LIBROS where id_libro = @id_libro
		

	END
GO
/****** Object:  StoredProcedure [dbo].[SP_EDITA_LIBRO]    Script Date: 31/05/2023 11:09:20 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_EDITA_LIBRO]
@id_libro int,
@nom_libro varchar(50),
@autor_libro varchar(50),
@categoria varchar(50),
@fecha_lanzamiento varchar(50),
@estado int
AS

	BEGIN
			UPDATE TB_LIBROS
			SET  nom_libro = @nom_libro,
				 autor_libro = @autor_libro,
				 categoria = @categoria,
				 fecha_lanzamiento = @fecha_lanzamiento,
				 estado = @estado
			where id_libro = @id_libro
	END
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINA_LIBRO]    Script Date: 31/05/2023 11:09:20 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_ELIMINA_LIBRO]
@id_libro int

as
	BEGIN
		
	delete from TB_LIBROS where id_libro = @id_libro
		

	END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTA_LIBRO]    Script Date: 31/05/2023 11:09:20 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_INSERTA_LIBRO]
@nom_libro varchar(50),
@autor_libro varchar(50),
@categoria varchar(50),
@fecha_lanzamiento varchar(50)

as
	BEGIN
		
INSERT INTO TB_LIBROS (nom_libro,autor_libro,categoria,fecha_lanzamiento,estado) values (@nom_libro,@autor_libro,@categoria,@fecha_lanzamiento,1)
		

	END
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTA_LIBROS]    Script Date: 31/05/2023 11:09:20 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_LISTA_LIBROS]
as
begin
	select * from TB_LIBROS
end
GO
