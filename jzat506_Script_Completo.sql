
USE [OasisSports]
GO


CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[DNI] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Email] [varchar](100) NULL,
	[Telefono] [varchar](30) NULL,
	[Direccion] [varchar](150) NULL,
	[Activo] [bit] NOT NULL DEFAULT ((1)),
	[DVH] [int] NOT NULL DEFAULT ((0)),
	PRIMARY KEY CLUSTERED ([IdCliente] ASC)
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cliente] ADD CONSTRAINT [UQ_Cliente_DNI] UNIQUE ([DNI])
GO


CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](20) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Categoria] [varchar](50) NULL,
	[Precio] [decimal](10,2) NOT NULL,
	[DVH] [int] NOT NULL DEFAULT ((0)),
	PRIMARY KEY CLUSTERED ([IdProducto] ASC)
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Producto] ADD CONSTRAINT [UQ_Producto_Codigo] UNIQUE ([Codigo])
GO


CREATE TABLE [dbo].[Factura](
	[IdFactura] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Total] [decimal](10,2) NOT NULL,
	[MedioPago] [varchar](20) NOT NULL,
	[DVH] [int] NOT NULL DEFAULT ((0)),
	PRIMARY KEY CLUSTERED ([IdFactura] ASC),
	CONSTRAINT [FK_Factura_Cliente] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Cliente] ([IdCliente])
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[DetalleFactura](
	[IdDetalle] [int] IDENTITY(1,1) NOT NULL,
	[IdFactura] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioUnitario] [decimal](10,2) NOT NULL,
	[DVH] [int] NOT NULL DEFAULT ((0)),
	PRIMARY KEY CLUSTERED ([IdDetalle] ASC),
	CONSTRAINT [FK_DetalleFactura_Factura] FOREIGN KEY ([IdFactura]) REFERENCES [dbo].[Factura] ([IdFactura]),
	CONSTRAINT [FK_DetalleFactura_Producto] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Producto] ([IdProducto])
) ON [PRIMARY]
GO


INSERT INTO [dbo].[DVVertical] ([Tabla], [ValorDVV]) VALUES ('Cliente', 0)
INSERT INTO [dbo].[DVVertical] ([Tabla], [ValorDVV]) VALUES ('Factura', 0)
INSERT INTO [dbo].[DVVertical] ([Tabla], [ValorDVV]) VALUES ('DetalleFactura', 0)

INSERT INTO [dbo].[DVVertical] ([Tabla], [ValorDVV]) VALUES ('Producto', 5)
GO


UPDATE [dbo].[Permiso] SET Nombre = 'Ventas', Codigo = 'VEN' WHERE Id = 5
GO


SET IDENTITY_INSERT [dbo].[Producto] ON
INSERT INTO [dbo].[Producto] ([IdProducto], [Codigo], [Nombre], [Categoria], [Precio], [DVH]) VALUES
(1, 'P001', N'Pelota de futbol N5', 'Pelotas', 15000, 5),
(2, 'P002', N'Camiseta Boca Juniors', 'Indumentaria', 45000, 9),
(3, 'P003', N'Botines Nike Mercurial', 'Calzado', 89000, 3),
(4, 'P004', N'Short deportivo', 'Indumentaria', 12000, 3),
(5, 'P005', N'Medias de futbol', 'Indumentaria', 5000, 5),
(6, 'P006', N'Pelota de basquet', 'Pelotas', 18000, 9),
(7, 'P007', N'Mochila deportiva', 'Accesorios', 22000, 4),
(8, 'P008', N'Buzo de entrenamiento', 'Indumentaria', 38000, 7)
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
