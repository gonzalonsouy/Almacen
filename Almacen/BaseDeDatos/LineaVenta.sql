USE [Almacen]
GO

/****** Objeto: Table [dbo].[LineaVenta] Fecha de script: 24/11/2026 21:47:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LineaVenta](
	[id] [int] NOT NULL,
	[idVenta] [int] NOT NULL,
	[idProducto] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[subtotal] [decimal](11, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[LineaVenta]  WITH CHECK ADD  CONSTRAINT [FK_LineaVenta_Producto] FOREIGN KEY([idProducto])
REFERENCES [dbo].[Producto] ([id])
GO

ALTER TABLE [dbo].[LineaVenta] CHECK CONSTRAINT [FK_LineaVenta_Producto]
GO

ALTER TABLE [dbo].[LineaVenta]  WITH CHECK ADD  CONSTRAINT [FK_LineaVenta_Venta] FOREIGN KEY([idVenta])
REFERENCES [dbo].[Venta] ([id])
GO

ALTER TABLE [dbo].[LineaVenta] CHECK CONSTRAINT [FK_LineaVenta_Venta]
GO


