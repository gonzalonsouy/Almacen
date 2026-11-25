USE [Almacen]
GO

/****** Objeto: Table [dbo].[Producto] Fecha de script: 24/11/2026 21:47:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Producto](
	[id] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[tipo] [varchar](50) NOT NULL,
	[stock] [int] NOT NULL,
	[precio] [decimal](11, 2) NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [CK_Producto_Tipo] CHECK  (([Tipo]='Higiene' OR [Tipo]='Limpieza' OR [Tipo]='Bebidas' OR [Tipo]='Comestibles'))
GO

ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [CK_Producto_Tipo]
GO


