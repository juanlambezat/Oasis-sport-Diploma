IF DB_ID(N'OasisSports') IS NULL CREATE DATABASE [OasisSports];
GO
USE [OasisSports];
GO
IF OBJECT_ID(N'dbo.usuarios', N'U') IS NOT NULL SET NOEXEC ON;
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZonaCobertura](
	[IdZona] [int] IDENTITY(1,1) NOT NULL,
	[Localidad] [varchar](100) NOT NULL,
	[CodigoPostal] [varchar](10) NOT NULL,
	[CostoEnvio] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdZona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DVVertical](
	[Tabla] [varchar](50) NOT NULL,
	[ValorDVV] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Tabla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](20) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Categoria] [varchar](50) NULL,
	[Precio] [decimal](10, 2) NOT NULL,
	[DVH] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transportista](
	[IdTransportista] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTransportista] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[DNI] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Email] [varchar](100) NULL,
	[Telefono] [varchar](30) NULL,
	[Direccion] [varchar](150) NULL,
	[DVH] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BitacoraEventos](
	[IdEvento] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](50) NULL,
	[Modulo] [varchar](50) NULL,
	[Descripcion] [varchar](200) NULL,
	[Fecha] [datetime] NULL,
	[Criticidad] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEvento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioPermiso](
	[UsuarioId] [int] NOT NULL,
	[PermisoId] [int] NOT NULL,
 CONSTRAINT [PK_UsuarioPermiso] PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permiso](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Codigo] [nvarchar](100) NOT NULL,
	[EsGrupo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios_C](
	[IdVersion] [int] IDENTITY(1,1) NOT NULL,
	[id_usuario] [int] NOT NULL,
	[nomUsuario] [nvarchar](100) NULL,
	[contraseña] [varchar](100) NULL,
	[bloqueado] [bit] NOT NULL,
	[eliminado] [bit] NOT NULL,
	[Fecha] [date] NOT NULL,
	[Hora] [time](0) NOT NULL,
	[Usuario] [nvarchar](100) NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdVersion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nomUsuario] [nvarchar](50) NULL,
	[contraseña] [varchar](100) NULL,
	[bloqueado] [bit] NOT NULL,
	[eliminado] [bit] NOT NULL,
	[DVH] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Idioma](
	[IdIdioma] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdIdioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistorialCambios](
	[IdHistorial] [int] IDENTITY(1,1) NOT NULL,
	[EntidadId] [int] NULL,
	[NombreEntidad] [varchar](50) NULL,
	[NombreCampo] [varchar](100) NULL,
	[ValorAnterior] [varchar](200) NULL,
	[ValorNuevo] [varchar](200) NULL,
	[Usuario] [varchar](50) NULL,
	[Fecha] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdHistorial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[IdFactura] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Total] [decimal](10, 2) NOT NULL,
	[MedioPago] [varchar](20) NOT NULL,
	[DVH] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Traduccion](
	[IdTraduccion] [int] IDENTITY(1,1) NOT NULL,
	[IdIdioma] [int] NULL,
	[Clave] [varchar](100) NULL,
	[Texto] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTraduccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermisoRelacion](
	[PadreId] [int] NOT NULL,
	[HijoId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PadreId] ASC,
	[HijoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleFactura](
	[IdDetalle] [int] IDENTITY(1,1) NOT NULL,
	[IdFactura] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioUnitario] [decimal](10, 2) NOT NULL,
	[DVH] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[IdPedido] [int] IDENTITY(1,1) NOT NULL,
	[IdFactura] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Estado] [varchar](20) NOT NULL,
	[DVH] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Envio](
	[IdEnvio] [int] IDENTITY(1,1) NOT NULL,
	[IdPedido] [int] NOT NULL,
	[IdZona] [int] NOT NULL,
	[Direccion] [varchar](150) NOT NULL,
	[Telefono] [varchar](20) NOT NULL,
	[CostoEnvio] [decimal](10, 2) NOT NULL,
	[MedioPago] [varchar](20) NOT NULL,
	[DVH] [int] NOT NULL,
	[IdTransportista] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEnvio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ZonaCobertura] ON
GO
INSERT [dbo].[ZonaCobertura] ([IdZona], [Localidad], [CodigoPostal], [CostoEnvio]) VALUES (1, N'Almagro', N'1200', CAST(0.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[ZonaCobertura] ([IdZona], [Localidad], [CodigoPostal], [CostoEnvio]) VALUES (2, N'Caballito', N'1405', CAST(0.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[ZonaCobertura] ([IdZona], [Localidad], [CodigoPostal], [CostoEnvio]) VALUES (3, N'Avellaneda', N'1870', CAST(3000.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[ZonaCobertura] ([IdZona], [Localidad], [CodigoPostal], [CostoEnvio]) VALUES (4, N'Lanus', N'1824', CAST(3500.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[ZonaCobertura] ([IdZona], [Localidad], [CodigoPostal], [CostoEnvio]) VALUES (5, N'Quilmes', N'1878', CAST(4500.00 AS Decimal(10, 2)))
GO
SET IDENTITY_INSERT [dbo].[ZonaCobertura] OFF
GO
INSERT [dbo].[DVVertical] ([Tabla], [ValorDVV]) VALUES (N'Cliente', 0)
GO
INSERT [dbo].[DVVertical] ([Tabla], [ValorDVV]) VALUES (N'DetalleFactura', 6)
GO
INSERT [dbo].[DVVertical] ([Tabla], [ValorDVV]) VALUES (N'Envio', 9)
GO
INSERT [dbo].[DVVertical] ([Tabla], [ValorDVV]) VALUES (N'Factura', 1)
GO
INSERT [dbo].[DVVertical] ([Tabla], [ValorDVV]) VALUES (N'Pedido', 0)
GO
INSERT [dbo].[DVVertical] ([Tabla], [ValorDVV]) VALUES (N'Producto', 5)
GO
INSERT [dbo].[DVVertical] ([Tabla], [ValorDVV]) VALUES (N'Usuarios', 6)
GO
SET IDENTITY_INSERT [dbo].[Producto] ON
GO
INSERT [dbo].[Producto] ([IdProducto], [Codigo], [Nombre], [Categoria], [Precio], [DVH]) VALUES (1, N'P001', N'Pelota de futbol N5', N'Pelotas', CAST(15000.00 AS Decimal(10, 2)), 5)
GO
INSERT [dbo].[Producto] ([IdProducto], [Codigo], [Nombre], [Categoria], [Precio], [DVH]) VALUES (2, N'P002', N'Camiseta Boca Juniors', N'Indumentaria', CAST(45000.00 AS Decimal(10, 2)), 9)
GO
INSERT [dbo].[Producto] ([IdProducto], [Codigo], [Nombre], [Categoria], [Precio], [DVH]) VALUES (3, N'P003', N'Botines Nike Mercurial', N'Calzado', CAST(89000.00 AS Decimal(10, 2)), 3)
GO
INSERT [dbo].[Producto] ([IdProducto], [Codigo], [Nombre], [Categoria], [Precio], [DVH]) VALUES (4, N'P004', N'Short deportivo', N'Indumentaria', CAST(12000.00 AS Decimal(10, 2)), 3)
GO
INSERT [dbo].[Producto] ([IdProducto], [Codigo], [Nombre], [Categoria], [Precio], [DVH]) VALUES (5, N'P005', N'Medias de futbol', N'Indumentaria', CAST(5000.00 AS Decimal(10, 2)), 5)
GO
INSERT [dbo].[Producto] ([IdProducto], [Codigo], [Nombre], [Categoria], [Precio], [DVH]) VALUES (6, N'P006', N'Pelota de basquet', N'Pelotas', CAST(18000.00 AS Decimal(10, 2)), 9)
GO
INSERT [dbo].[Producto] ([IdProducto], [Codigo], [Nombre], [Categoria], [Precio], [DVH]) VALUES (7, N'P007', N'Mochila deportiva', N'Accesorios', CAST(22000.00 AS Decimal(10, 2)), 4)
GO
INSERT [dbo].[Producto] ([IdProducto], [Codigo], [Nombre], [Categoria], [Precio], [DVH]) VALUES (8, N'P008', N'Buzo de entrenamiento', N'Indumentaria', CAST(38000.00 AS Decimal(10, 2)), 7)
GO
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
SET IDENTITY_INSERT [dbo].[Transportista] ON
GO
INSERT [dbo].[Transportista] ([IdTransportista], [Nombre], [Apellido]) VALUES (1, N'Carlos', N'Medina')
GO
INSERT [dbo].[Transportista] ([IdTransportista], [Nombre], [Apellido]) VALUES (2, N'Sofia', N'Ramirez')
GO
INSERT [dbo].[Transportista] ([IdTransportista], [Nombre], [Apellido]) VALUES (3, N'Diego', N'Castro')
GO
INSERT [dbo].[Transportista] ([IdTransportista], [Nombre], [Apellido]) VALUES (4, N'Marina', N'Lopez')
GO
SET IDENTITY_INSERT [dbo].[Transportista] OFF
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON
GO
INSERT [dbo].[Cliente] ([IdCliente], [DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion], [DVH], [Activo]) VALUES (1, 44966506, N'Juan Ignacio', N'Lambezat', N'juanlambezat@gmail.com', N'1137566849', N'schell 559', 1, 1)
GO
INSERT [dbo].[Cliente] ([IdCliente], [DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion], [DVH], [Activo]) VALUES (2, 24353416, N'Gabriel', N'Lambezat', N'glambezat@gmail.com', N'1158546639', N'schell', 4, 1)
GO
INSERT [dbo].[Cliente] ([IdCliente], [DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion], [DVH], [Activo]) VALUES (3, 45736232, N'Lucas', N'Gomez', N'lucasgomez2805@gmail.com', N'1154633831', N'Santa ana 850', 1, 1)
GO
INSERT [dbo].[Cliente] ([IdCliente], [DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion], [DVH], [Activo]) VALUES (4, 34398745, N'Martin', N'Terrazino', N'Martin@gmail.com', N'1123212342', N'las piedras 334', 8, 1)
GO
INSERT [dbo].[Cliente] ([IdCliente], [DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion], [DVH], [Activo]) VALUES (5, 24353411, N'Gaston', N'Banc', N'gastonbanc@gmail.com', N'1176337485', N'arenales 31', 4, 1)
GO
INSERT [dbo].[Cliente] ([IdCliente], [DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion], [DVH], [Activo]) VALUES (6, 38451276, N'Sofia', N'Herrera', N'sofia.herrera@mail.com', N'1145123987', N'Av. Mitre 1520', 4, 1)
GO
INSERT [dbo].[Cliente] ([IdCliente], [DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion], [DVH], [Activo]) VALUES (7, 41236985, N'Tomas', N'Aguirre', N'tomas.aguirre@mail.com', N'1162457813', N'Hipolito Yrigoyen 4300', 4, 1)
GO
INSERT [dbo].[Cliente] ([IdCliente], [DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion], [DVH], [Activo]) VALUES (8, 39874521, N'Valentina', N'Rios', N'valentina.rios@mail.com', N'1133658741', N'Rivadavia 6100', 3, 1)
GO
INSERT [dbo].[Cliente] ([IdCliente], [DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion], [DVH], [Activo]) VALUES (9, 36521478, N'Nicolas', N'Paz', N'nicolas.paz@mail.com', N'1159874123', N'Av. Calchaqui 900', 0, 1)
GO
INSERT [dbo].[Cliente] ([IdCliente], [DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion], [DVH], [Activo]) VALUES (10, 42365874, N'Camila', N'Ortiz', N'camila.ortiz@mail.com', N'1147852369', N'Belgrano 350', 1, 1)
GO
INSERT [dbo].[Cliente] ([IdCliente], [DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion], [DVH], [Activo]) VALUES (11, 37458962, N'Federico', N'Luna', N'federico.luna@mail.com', N'1128963574', N'Medrano 820', 0, 1)
GO
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
INSERT [dbo].[UsuarioPermiso] ([UsuarioId], [PermisoId]) VALUES (9, 24)
GO
INSERT [dbo].[UsuarioPermiso] ([UsuarioId], [PermisoId]) VALUES (11, 24)
GO
INSERT [dbo].[UsuarioPermiso] ([UsuarioId], [PermisoId]) VALUES (1015, 12)
GO
SET IDENTITY_INSERT [dbo].[Permiso] ON
GO
INSERT [dbo].[Permiso] ([Id], [Nombre], [Codigo], [EsGrupo]) VALUES (1, N'Bitacora de eventos', N'SE001', 0)
GO
INSERT [dbo].[Permiso] ([Id], [Nombre], [Codigo], [EsGrupo]) VALUES (2, N'Gestion de usuarios', N'SE002', 0)
GO
INSERT [dbo].[Permiso] ([Id], [Nombre], [Codigo], [EsGrupo]) VALUES (3, N'Gestion de perfiles', N'SE003', 0)
GO
INSERT [dbo].[Permiso] ([Id], [Nombre], [Codigo], [EsGrupo]) VALUES (5, N'Ventas', N'VE001', 0)
GO
INSERT [dbo].[Permiso] ([Id], [Nombre], [Codigo], [EsGrupo]) VALUES (7, N'Crear idioma', N'ID001', 0)
GO
INSERT [dbo].[Permiso] ([Id], [Nombre], [Codigo], [EsGrupo]) VALUES (11, N'Bitacora de cambios', N'SE004', 0)
GO
INSERT [dbo].[Permiso] ([Id], [Nombre], [Codigo], [EsGrupo]) VALUES (12, N'Vendedor', N'AA001', 1)
GO
INSERT [dbo].[Permiso] ([Id], [Nombre], [Codigo], [EsGrupo]) VALUES (13, N'Pedidos', N'DE001', 0)
GO
INSERT [dbo].[Permiso] ([Id], [Nombre], [Codigo], [EsGrupo]) VALUES (14, N'Gestion de clientes', N'VE002', 0)
GO
INSERT [dbo].[Permiso] ([Id], [Nombre], [Codigo], [EsGrupo]) VALUES (15, N'Facturas', N'VE003', 0)
GO
INSERT [dbo].[Permiso] ([Id], [Nombre], [Codigo], [EsGrupo]) VALUES (16, N'Envios', N'VE004', 0)
GO
INSERT [dbo].[Permiso] ([Id], [Nombre], [Codigo], [EsGrupo]) VALUES (17, N'Reporte de envios', N'VE005', 0)
GO
INSERT [dbo].[Permiso] ([Id], [Nombre], [Codigo], [EsGrupo]) VALUES (18, N'Asignar transportista', N'DE002', 0)
GO
INSERT [dbo].[Permiso] ([Id], [Nombre], [Codigo], [EsGrupo]) VALUES (19, N'Gestion de seguridad', N'GE050', 1)
GO
INSERT [dbo].[Permiso] ([Id], [Nombre], [Codigo], [EsGrupo]) VALUES (20, N'Gestion de ventas', N'GE051', 1)
GO
INSERT [dbo].[Permiso] ([Id], [Nombre], [Codigo], [EsGrupo]) VALUES (21, N'Gestion de despacho', N'GE052', 1)
GO
INSERT [dbo].[Permiso] ([Id], [Nombre], [Codigo], [EsGrupo]) VALUES (22, N'Gestion de idiomas', N'GE053', 1)
GO
INSERT [dbo].[Permiso] ([Id], [Nombre], [Codigo], [EsGrupo]) VALUES (23, N'Despachante', N'AA002', 1)
GO
INSERT [dbo].[Permiso] ([Id], [Nombre], [Codigo], [EsGrupo]) VALUES (24, N'Administrador', N'AA099', 1)
GO
INSERT [dbo].[Permiso] ([Id], [Nombre], [Codigo], [EsGrupo]) VALUES (27, N'Reporte inteligente', N'VE006', 0)
GO
SET IDENTITY_INSERT [dbo].[Permiso] OFF
GO
SET IDENTITY_INSERT [dbo].[usuarios_C] ON
GO
INSERT [dbo].[usuarios_C] ([IdVersion], [id_usuario], [nomUsuario], [contraseña], [bloqueado], [eliminado], [Fecha], [Hora], [Usuario], [Activo]) VALUES (1, 5, N'juancho', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 0, 0, CAST(N'2026-11-18' AS Date), CAST(N'19:34:23' AS Time), N'sistema', 1)
GO
INSERT [dbo].[usuarios_C] ([IdVersion], [id_usuario], [nomUsuario], [contraseña], [bloqueado], [eliminado], [Fecha], [Hora], [Usuario], [Activo]) VALUES (2, 8, N'juan', N'624c5afc34bef1ddf26fa6a3cfb661e630b5224726de471c24d8aaccd2f155ee', 0, 0, CAST(N'2026-11-18' AS Date), CAST(N'19:34:23' AS Time), N'sistema', 1)
GO
INSERT [dbo].[usuarios_C] ([IdVersion], [id_usuario], [nomUsuario], [contraseña], [bloqueado], [eliminado], [Fecha], [Hora], [Usuario], [Activo]) VALUES (3, 9, N'jondem', N'03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 0, 0, CAST(N'2026-11-18' AS Date), CAST(N'19:34:23' AS Time), N'sistema', 1)
GO
INSERT [dbo].[usuarios_C] ([IdVersion], [id_usuario], [nomUsuario], [contraseña], [bloqueado], [eliminado], [Fecha], [Hora], [Usuario], [Activo]) VALUES (4, 11, N'martin', N'e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855', 0, 0, CAST(N'2026-11-18' AS Date), CAST(N'19:34:23' AS Time), N'sistema', 1)
GO
INSERT [dbo].[usuarios_C] ([IdVersion], [id_usuario], [nomUsuario], [contraseña], [bloqueado], [eliminado], [Fecha], [Hora], [Usuario], [Activo]) VALUES (5, 12, N'1', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 0, 1, CAST(N'2026-11-18' AS Date), CAST(N'19:34:23' AS Time), N'sistema', 1)
GO
INSERT [dbo].[usuarios_C] ([IdVersion], [id_usuario], [nomUsuario], [contraseña], [bloqueado], [eliminado], [Fecha], [Hora], [Usuario], [Activo]) VALUES (6, 1015, N'gabriel', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 0, 0, CAST(N'2026-11-18' AS Date), CAST(N'19:34:23' AS Time), N'sistema', 1)
GO
INSERT [dbo].[usuarios_C] ([IdVersion], [id_usuario], [nomUsuario], [contraseña], [bloqueado], [eliminado], [Fecha], [Hora], [Usuario], [Activo]) VALUES (7, 1016, N'Diego', N'ef51306214d9a6361ee1d5b452e6d2bb70dc7ebb85bf9e02c3d4747fb57d6bec', 0, 0, CAST(N'2026-11-18' AS Date), CAST(N'19:34:23' AS Time), N'sistema', 1)
GO
SET IDENTITY_INSERT [dbo].[usuarios_C] OFF
GO
SET IDENTITY_INSERT [dbo].[usuarios] ON
GO
INSERT [dbo].[usuarios] ([id_usuario], [nomUsuario], [contraseña], [bloqueado], [eliminado], [DVH]) VALUES (5, N'juancho', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 0, 0, 7)
GO
INSERT [dbo].[usuarios] ([id_usuario], [nomUsuario], [contraseña], [bloqueado], [eliminado], [DVH]) VALUES (8, N'juan', N'624c5afc34bef1ddf26fa6a3cfb661e630b5224726de471c24d8aaccd2f155ee', 0, 0, 9)
GO
INSERT [dbo].[usuarios] ([id_usuario], [nomUsuario], [contraseña], [bloqueado], [eliminado], [DVH]) VALUES (9, N'jondem', N'03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 0, 0, 8)
GO
INSERT [dbo].[usuarios] ([id_usuario], [nomUsuario], [contraseña], [bloqueado], [eliminado], [DVH]) VALUES (11, N'martin', N'e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855', 0, 0, 9)
GO
INSERT [dbo].[usuarios] ([id_usuario], [nomUsuario], [contraseña], [bloqueado], [eliminado], [DVH]) VALUES (12, N'1', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 0, 1, 9)
GO
INSERT [dbo].[usuarios] ([id_usuario], [nomUsuario], [contraseña], [bloqueado], [eliminado], [DVH]) VALUES (1015, N'gabriel', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 0, 0, 0)
GO
INSERT [dbo].[usuarios] ([id_usuario], [nomUsuario], [contraseña], [bloqueado], [eliminado], [DVH]) VALUES (1016, N'Diego', N'ef51306214d9a6361ee1d5b452e6d2bb70dc7ebb85bf9e02c3d4747fb57d6bec', 0, 0, 4)
GO
SET IDENTITY_INSERT [dbo].[usuarios] OFF
GO
SET IDENTITY_INSERT [dbo].[Idioma] ON
GO
INSERT [dbo].[Idioma] ([IdIdioma], [Nombre]) VALUES (1, N'Español')
GO
INSERT [dbo].[Idioma] ([IdIdioma], [Nombre]) VALUES (2, N'Inglés')
GO
INSERT [dbo].[Idioma] ([IdIdioma], [Nombre]) VALUES (3, N'Aleman')
GO
INSERT [dbo].[Idioma] ([IdIdioma], [Nombre]) VALUES (4, N'Portugues')
GO
SET IDENTITY_INSERT [dbo].[Idioma] OFF
GO
SET IDENTITY_INSERT [dbo].[HistorialCambios] ON
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1, 9, N'Usuario', N'Username', N'jondem', N'jondem1', N'jondem', CAST(N'2026-06-29T13:29:10.503' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (2, 9, N'Usuario', N'Password', N'***', N'***', N'jondem', CAST(N'2026-06-29T13:29:10.503' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (3, 9, N'Usuario', N'Username', N'(restauración)', N'jondem', N'jondem', CAST(N'2026-06-29T13:29:20.723' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (4, 6, N'Usuario', N'Password', N'***', N'***', N'jondem', CAST(N'2026-06-29T13:32:53.253' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (5, 6, N'Usuario', N'Username', N'ferni', N'ferni1', N'jondem', CAST(N'2026-06-29T13:33:09.813' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (6, 6, N'Usuario', N'Password', N'***', N'***', N'jondem', CAST(N'2026-06-29T13:33:09.813' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (7, 9, N'Usuario', N'Username', N'jondem', N'jondem123', N'jondem', CAST(N'2026-06-29T13:33:46.490' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (8, 9, N'Usuario', N'Password', N'***', N'***', N'jondem', CAST(N'2026-06-29T13:33:46.493' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (9, 9, N'Usuario', N'Username', N'(restauración)', N'jondem', N'jondem123', CAST(N'2026-06-29T13:34:11.620' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (10, 11, N'Usuario', N'Password', N'***', N'***', N'jondem', CAST(N'2026-06-29T14:19:26.347' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (11, 11, N'Usuario', N'Password', N'***', N'***', N'jondem', CAST(N'2026-06-29T14:19:35.623' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (12, 9, N'Usuario', N'Username', N'jondem', N'jondem123', N'jondem', CAST(N'2026-06-29T14:19:52.437' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (13, 9, N'Usuario', N'Password', N'***', N'***', N'jondem', CAST(N'2026-06-29T14:19:52.437' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (14, 9, N'Usuario', N'Username', N'jondem123', N'jondem', N'jondem', CAST(N'2026-06-29T14:20:05.510' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (15, 9, N'Usuario', N'Password', N'***', N'***', N'jondem', CAST(N'2026-06-29T14:20:05.510' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (16, 9, N'Usuario', N'Username', N'(restauración)', N'jondem123', N'jondem', CAST(N'2026-06-29T14:20:33.830' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (17, 9, N'Usuario', N'Username', N'(restauración)', N'jondem', N'jondem123', CAST(N'2026-06-29T14:21:08.870' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (18, 5, N'Usuario', N'Password', N'***', N'***', N'jondem', CAST(N'2026-06-29T14:26:45.460' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (19, 9, N'Usuario', N'Username', N'(restauración)', N'jondem123', N'jondem', CAST(N'2026-06-29T14:28:04.023' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (20, 9, N'Usuario', N'Username', N'jondem123', N'jondem', N'jondem123', CAST(N'2026-06-29T14:28:38.157' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (21, 9, N'Usuario', N'Password', N'***', N'***', N'jondem123', CAST(N'2026-06-29T14:28:38.160' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (22, 9, N'Usuario', N'Password', N'***', N'***', N'jondem', CAST(N'2026-06-29T16:20:04.317' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (23, 9, N'Usuario', N'Password', N'***', N'***', N'jondem', CAST(N'2026-06-29T16:21:08.653' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (24, 9, N'Usuario', N'Password', N'***', N'***', N'jondem', CAST(N'2026-06-29T16:21:16.810' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (25, 9, N'Usuario', N'Password', N'***', N'***', N'jondem', CAST(N'2026-06-29T16:21:27.633' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (26, 11, N'Usuario', N'Password', N'***', N'***', N'jondem', CAST(N'2026-06-29T16:21:49.047' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (27, 11, N'Usuario', N'Password', N'***', N'***', N'martin', CAST(N'2026-06-29T16:22:59.203' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (28, 11, N'Usuario', N'Username', N'martin', N'martin111', N'martin', CAST(N'2026-06-29T16:23:30.457' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (29, 11, N'Usuario', N'Password', N'***', N'***', N'martin', CAST(N'2026-06-29T16:23:30.457' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (30, 11, N'Usuario', N'Username', N'martin111', N'martin', N'jondem', CAST(N'2026-06-29T16:24:12.597' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (31, 11, N'Usuario', N'Password', N'***', N'***', N'jondem', CAST(N'2026-06-29T16:24:12.597' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (32, 11, N'Usuario', N'Username', N'martin', N'martin1', N'martin', CAST(N'2026-06-29T16:24:34.487' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (33, 11, N'Usuario', N'Password', N'***', N'***', N'martin', CAST(N'2026-06-29T16:24:34.490' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (34, 6, N'Usuario', N'Username', N'ferni1', N'ferni', N'jondem', CAST(N'2026-06-29T21:43:06.753' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (35, 6, N'Usuario', N'Password', N'***', N'***', N'jondem', CAST(N'2026-06-29T21:43:06.757' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (36, 6, N'Usuario', N'Password', N'***', N'***', N'jondem', CAST(N'2026-06-29T21:43:40.357' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (37, 6, N'Usuario', N'Username', N'ferni', N'ferni1', N'jondem', CAST(N'2026-06-29T21:43:46.580' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (38, 6, N'Usuario', N'Password', N'***', N'***', N'jondem', CAST(N'2026-06-29T21:43:46.580' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (39, 6, N'Usuario', N'Username', N'ferni1', N'ferni', N'jondem', CAST(N'2026-06-29T21:44:25.980' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (40, 6, N'Usuario', N'Password', N'***', N'***', N'jondem', CAST(N'2026-06-29T21:44:25.980' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (41, 11, N'Usuario', N'Username', N'martin1', N'martin', N'jondem', CAST(N'2026-06-29T21:45:05.723' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (42, 11, N'Usuario', N'Password', N'***', N'***', N'jondem', CAST(N'2026-06-29T21:45:05.727' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (43, 11, N'Usuario', N'Username', N'martin', N'martin1', N'martin', CAST(N'2026-06-29T21:45:38.527' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (44, 11, N'Usuario', N'Password', N'***', N'***', N'martin', CAST(N'2026-06-29T21:45:38.527' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (45, 11, N'Usuario', N'Username', N'martin1', N'martin', N'martin1', CAST(N'2026-06-29T21:45:58.600' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (46, 11, N'Usuario', N'Password', N'***', N'***', N'martin1', CAST(N'2026-06-29T21:45:58.600' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (47, 9, N'Usuario', N'Username', N'(restauración)', N'jondem123', N'jondem', CAST(N'2026-06-29T21:56:08.983' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (48, 9, N'Usuario', N'Username', N'(restauración)', N'jondem', N'jondem123', CAST(N'2026-06-29T21:56:55.043' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1034, 9, N'Usuario', N'Username', N'jondem', N'jondem1', N'jondem', CAST(N'2026-07-01T00:06:12.267' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1035, 9, N'Usuario', N'Password', N'***', N'***', N'jondem', CAST(N'2026-07-01T00:06:12.270' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1036, 9, N'Usuario', N'Username', N'(restauración)', N'jondem', N'jondem1', CAST(N'2026-07-01T00:06:46.587' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1037, 9, N'Usuario', N'Password', N'***', N'***', N'jondem', CAST(N'2026-07-01T15:48:38.857' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1038, 1, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-10-24T13:21:05.887' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1039, 1, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-10-24T13:21:07.217' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1040, 1, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-10-24T13:21:08.513' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1041, 1, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-10-24T13:21:09.870' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1042, 2, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-10-24T13:24:30.697' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1043, 2, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-10-24T13:24:34.577' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1044, 2, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-10-24T13:24:44.443' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1045, 2, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-10-24T13:24:46.943' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1046, 3, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-10-25T21:36:55.153' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1047, 3, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-10-25T21:36:56.350' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1048, 3, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-10-25T21:36:57.303' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1049, 3, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-10-25T21:36:58.187' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1050, 4, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-10-26T18:26:50.387' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1051, 4, N'Pedido', N'Transportista', N'Sin asignar', N'Marina Lopez', N'jondem', CAST(N'2026-10-26T18:27:04.557' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1052, 4, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-10-26T18:27:14.620' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1053, 4, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-10-26T18:27:16.967' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1054, 4, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-10-26T18:27:19.270' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1055, 5, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-10-26T19:19:20.160' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1056, 5, N'Pedido', N'Transportista', N'Sin asignar', N'Diego Castro', N'jondem', CAST(N'2026-10-26T19:19:34.117' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1057, 5, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-10-26T19:19:44.930' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1058, 5, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-10-26T19:19:46.137' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1059, 5, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-10-26T19:19:47.540' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1060, 6, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-10-26T19:20:28.850' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1061, 6, N'Pedido', N'Transportista', N'Sin asignar', N'Carlos Medina', N'jondem', CAST(N'2026-10-26T19:20:35.037' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1062, 6, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-10-26T19:20:46.560' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1063, 6, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-10-26T19:20:47.900' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1064, 6, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-10-26T19:20:50.003' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1065, 12, N'Usuario', N'Password', N'***', N'***', N'jondem', CAST(N'2026-11-03T21:42:30.223' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1066, 7, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-06-01T19:58:58.787' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1067, 7, N'Pedido', N'Transportista', N'Sin asignar', N'Marina Lopez', N'jondem', CAST(N'2026-06-01T20:42:07.500' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1068, 7, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-06-01T21:33:52.610' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1069, 7, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-06-01T22:19:25.767' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1070, 7, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-06-03T04:23:51.280' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1071, 8, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-06-01T21:19:47.597' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1072, 8, N'Pedido', N'Transportista', N'Sin asignar', N'Carlos Medina', N'jondem', CAST(N'2026-06-01T22:44:22.570' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1073, 8, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-06-01T23:21:56.363' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1074, 8, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-06-02T00:49:49.420' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1075, 8, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-06-03T12:58:07.557' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1076, 9, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-06-08T19:53:42.110' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1077, 9, N'Pedido', N'Transportista', N'Sin asignar', N'Sofia Ramirez', N'jondem', CAST(N'2026-06-08T21:48:03.290' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1078, 9, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-06-08T22:46:24.627' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1079, 9, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-06-08T23:26:47.613' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1080, 9, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-06-10T04:46:37.803' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1081, 10, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-06-19T15:23:32.943' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1082, 10, N'Pedido', N'Transportista', N'Sin asignar', N'Carlos Medina', N'jondem', CAST(N'2026-06-19T16:46:43.503' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1083, 10, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-06-19T17:39:13.343' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1084, 10, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-06-19T19:07:57.083' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1085, 10, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-06-20T17:44:30.077' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1086, 11, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-06-28T13:51:52.127' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1087, 11, N'Pedido', N'Transportista', N'Sin asignar', N'Sofia Ramirez', N'jondem', CAST(N'2026-06-28T14:23:09.867' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1088, 11, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-06-28T14:36:00.827' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1089, 11, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-06-28T15:35:17.943' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1090, 11, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-06-29T14:02:35.910' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1091, 12, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-07-07T18:58:09.513' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1092, 12, N'Pedido', N'Transportista', N'Sin asignar', N'Sofia Ramirez', N'jondem', CAST(N'2026-07-07T20:18:14.250' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1093, 12, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-07-07T21:16:30.093' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1094, 12, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-07-07T22:42:56.900' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1095, 12, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-07-08T18:29:38.600' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1096, 13, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-07-26T14:51:31.273' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1097, 13, N'Pedido', N'Transportista', N'Sin asignar', N'Diego Castro', N'jondem', CAST(N'2026-07-26T16:06:13.990' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1098, 13, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-07-26T16:25:24.527' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1099, 13, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-07-26T17:40:38.287' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1100, 13, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-07-27T18:25:23.220' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1101, 14, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-07-27T16:42:22.243' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1102, 14, N'Pedido', N'Transportista', N'Sin asignar', N'Sofia Ramirez', N'jondem', CAST(N'2026-07-27T18:02:30.667' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1103, 14, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-07-27T18:53:37.393' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1104, 14, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-07-27T20:51:24.610' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1105, 14, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-07-29T11:01:43.913' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1106, 15, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-07-28T14:01:23.233' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1107, 15, N'Pedido', N'Transportista', N'Sin asignar', N'Diego Castro', N'jondem', CAST(N'2026-07-28T15:20:00.997' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1108, 15, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-07-28T16:10:40.357' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1109, 15, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-07-28T18:04:39.690' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1110, 15, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-07-30T09:37:52.923' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1111, 16, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-07-30T15:00:07.047' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1112, 16, N'Pedido', N'Transportista', N'Sin asignar', N'Sofia Ramirez', N'jondem', CAST(N'2026-07-30T16:06:33.583' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1113, 16, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-07-30T17:06:21.467' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1114, 16, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-07-30T18:21:12.947' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1115, 16, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-08-03T14:08:03.797' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1116, 17, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-07-31T18:25:57.013' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1117, 17, N'Pedido', N'Transportista', N'Sin asignar', N'Sofia Ramirez', N'jondem', CAST(N'2026-07-31T19:59:16.040' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1118, 17, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-07-31T20:32:11.430' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1119, 17, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-07-31T21:50:48.153' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1120, 17, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-08-01T15:19:57.507' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1121, 18, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-08-10T17:33:52.310' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1122, 18, N'Pedido', N'Transportista', N'Sin asignar', N'Carlos Medina', N'jondem', CAST(N'2026-08-10T18:15:25.470' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1123, 18, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-08-10T18:51:33.450' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1124, 18, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-08-10T20:40:26.177' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1125, 18, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-08-12T06:48:07.470' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1126, 19, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-08-13T17:15:28.120' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1127, 19, N'Pedido', N'Transportista', N'Sin asignar', N'Marina Lopez', N'jondem', CAST(N'2026-08-13T18:43:18.390' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1128, 19, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-08-13T19:38:45.887' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1129, 19, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-08-13T20:12:30.107' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1130, 19, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-08-18T11:54:22.737' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1131, 20, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-08-23T17:39:11.677' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1132, 20, N'Pedido', N'Transportista', N'Sin asignar', N'Marina Lopez', N'jondem', CAST(N'2026-08-23T19:20:05.603' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1133, 20, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-08-23T19:54:19.600' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1134, 20, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-08-23T21:36:36.463' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1135, 20, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-08-25T05:42:22.383' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1136, 21, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-08-25T22:34:35.097' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1137, 21, N'Pedido', N'Transportista', N'Sin asignar', N'Carlos Medina', N'jondem', CAST(N'2026-08-26T00:14:25.547' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1138, 21, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-08-26T01:08:06.203' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1139, 21, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-08-26T01:47:26.990' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1140, 21, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-08-26T15:14:25.253' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1141, 22, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-09-09T13:05:48.600' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1142, 22, N'Pedido', N'Transportista', N'Sin asignar', N'Carlos Medina', N'jondem', CAST(N'2026-09-09T13:54:37.537' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1143, 22, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-09-09T14:10:40.853' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1144, 22, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-09-09T14:44:47.057' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1145, 22, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-09-11T01:20:04.210' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1146, 23, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-09-09T15:57:08.433' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1147, 23, N'Pedido', N'Transportista', N'Sin asignar', N'Carlos Medina', N'jondem', CAST(N'2026-09-09T17:17:35.893' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1148, 23, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-09-09T17:51:56.280' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1149, 23, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-09-09T18:37:21.347' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1150, 23, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-09-11T05:24:08.220' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1151, 24, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-09-11T17:16:55.217' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1152, 24, N'Pedido', N'Transportista', N'Sin asignar', N'Diego Castro', N'jondem', CAST(N'2026-09-11T17:52:24.077' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1153, 24, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-09-11T18:33:39.027' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1154, 24, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-09-11T19:34:31.413' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1155, 24, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-09-15T22:38:21.160' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1156, 25, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-09-14T18:49:03.923' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1157, 25, N'Pedido', N'Transportista', N'Sin asignar', N'Marina Lopez', N'jondem', CAST(N'2026-09-14T19:23:57.383' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1158, 25, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-09-14T20:20:59.990' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1159, 25, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-09-14T22:19:51.733' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1160, 25, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-09-15T11:37:35.260' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1161, 26, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-09-26T17:26:58.697' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1162, 26, N'Pedido', N'Transportista', N'Sin asignar', N'Marina Lopez', N'jondem', CAST(N'2026-09-26T18:54:07.403' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1163, 26, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-09-26T19:42:47.177' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1164, 26, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-09-26T20:24:11.197' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1165, 26, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-09-28T05:12:14.980' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1166, 27, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-09-27T17:27:31.187' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1167, 27, N'Pedido', N'Transportista', N'Sin asignar', N'Sofia Ramirez', N'jondem', CAST(N'2026-09-27T19:22:16.487' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1168, 27, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-09-27T19:43:31.373' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1169, 27, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-09-27T20:52:47.220' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1170, 27, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-10-02T20:38:19.860' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1171, 28, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-10-02T12:37:49.117' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1172, 28, N'Pedido', N'Transportista', N'Sin asignar', N'Marina Lopez', N'jondem', CAST(N'2026-10-02T14:22:59.413' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1173, 28, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-10-02T14:50:55.717' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1174, 28, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-10-02T16:02:38.460' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1175, 28, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-10-03T15:24:25.040' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1176, 29, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-10-03T21:00:33.433' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1177, 29, N'Pedido', N'Transportista', N'Sin asignar', N'Carlos Medina', N'jondem', CAST(N'2026-10-03T21:34:30.377' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1178, 29, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-10-03T22:08:27.047' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1179, 29, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-10-03T23:53:50.367' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1180, 29, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-10-04T22:06:57.593' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1181, 30, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-10-05T13:02:02.200' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1182, 30, N'Pedido', N'Transportista', N'Sin asignar', N'Sofia Ramirez', N'jondem', CAST(N'2026-10-05T13:47:59.243' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1183, 30, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-10-05T14:35:13.373' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1184, 30, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-10-05T15:49:42.767' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1185, 30, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-10-07T02:36:19.080' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1186, 31, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-10-11T22:52:02.953' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1187, 31, N'Pedido', N'Transportista', N'Sin asignar', N'Marina Lopez', N'jondem', CAST(N'2026-10-11T23:38:06.353' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1188, 31, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-10-11T23:55:52.407' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1189, 31, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-10-12T00:26:58.303' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1190, 31, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-10-12T15:23:14.863' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1191, 32, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-10-13T13:32:23.180' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1192, 32, N'Pedido', N'Transportista', N'Sin asignar', N'Carlos Medina', N'jondem', CAST(N'2026-10-13T15:17:46.240' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1193, 32, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-10-13T16:12:03.303' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1194, 32, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-10-13T16:53:26.200' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1195, 32, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-10-14T18:48:21.463' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1196, 33, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-10-14T15:53:14.187' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1197, 33, N'Pedido', N'Transportista', N'Sin asignar', N'Sofia Ramirez', N'jondem', CAST(N'2026-10-14T17:03:18.547' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1198, 33, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-10-14T18:01:17.053' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1199, 33, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-10-14T19:41:50.680' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1200, 33, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-10-16T11:09:41.517' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1201, 34, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-10-16T15:10:12.837' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1202, 34, N'Pedido', N'Transportista', N'Sin asignar', N'Diego Castro', N'jondem', CAST(N'2026-10-16T16:13:19.883' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1203, 34, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-10-16T16:26:43.820' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1204, 34, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-10-16T17:17:09.690' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1205, 34, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-10-17T21:46:21.450' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1206, 35, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-10-17T16:14:48.623' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1207, 35, N'Pedido', N'Transportista', N'Sin asignar', N'Sofia Ramirez', N'jondem', CAST(N'2026-10-17T17:50:24.413' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1208, 35, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-10-17T18:09:24.567' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1209, 35, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-10-17T19:06:18.383' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1210, 35, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-10-19T07:08:17.987' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1211, 36, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-10-20T16:27:04.040' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1212, 36, N'Pedido', N'Transportista', N'Sin asignar', N'Sofia Ramirez', N'jondem', CAST(N'2026-10-20T17:50:48.737' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1213, 36, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-10-20T18:07:38.910' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1214, 36, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-10-20T19:41:24.893' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1215, 36, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-10-20T20:55:39.510' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1216, 37, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-10-22T19:46:33.610' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1217, 37, N'Pedido', N'Transportista', N'Sin asignar', N'Marina Lopez', N'jondem', CAST(N'2026-10-22T21:37:38.323' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1218, 37, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-10-22T22:02:34.423' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1219, 37, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-10-22T22:46:07.230' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1220, 37, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-10-28T02:39:05.177' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1221, 38, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-10-23T18:20:09.390' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1222, 38, N'Pedido', N'Transportista', N'Sin asignar', N'Sofia Ramirez', N'jondem', CAST(N'2026-10-23T20:04:05.837' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1223, 38, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-10-23T20:24:45.580' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1224, 38, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-10-23T21:24:47.750' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1225, 38, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-10-24T17:07:43.147' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1226, 39, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-10-27T19:53:39.993' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1227, 39, N'Pedido', N'Transportista', N'Sin asignar', N'Sofia Ramirez', N'jondem', CAST(N'2026-10-27T21:49:33.300' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1228, 39, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-10-27T22:11:25.393' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1229, 39, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-10-28T00:08:26.510' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1230, 39, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-10-29T01:04:29.510' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1231, 40, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-10-27T22:05:48.717' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1232, 40, N'Pedido', N'Transportista', N'Sin asignar', N'Diego Castro', N'jondem', CAST(N'2026-10-27T22:43:33.457' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1233, 40, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-10-27T23:27:52.197' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1234, 40, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-10-28T00:22:03.197' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1235, 40, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-11-01T15:27:53.143' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1236, 41, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-10-28T16:16:14.107' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1237, 41, N'Pedido', N'Transportista', N'Sin asignar', N'Diego Castro', N'jondem', CAST(N'2026-10-28T16:59:33.770' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1238, 41, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-10-28T17:35:54.103' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1239, 41, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-10-28T18:26:12.223' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1240, 41, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-10-29T11:15:08.193' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1241, 42, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-10-29T19:11:30.370' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1242, 42, N'Pedido', N'Transportista', N'Sin asignar', N'Marina Lopez', N'jondem', CAST(N'2026-10-29T19:44:25.983' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1243, 42, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-10-29T20:35:51.337' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1244, 42, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-10-29T21:53:52.480' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1245, 42, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-11-02T20:30:41.973' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1246, 43, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-11-01T19:05:48.787' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1247, 43, N'Pedido', N'Transportista', N'Sin asignar', N'Carlos Medina', N'jondem', CAST(N'2026-11-01T20:42:07.777' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1248, 43, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-11-01T21:02:24.310' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1249, 43, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-11-01T21:46:46.920' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1250, 43, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-11-03T03:16:08.677' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1251, 44, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-11-03T14:14:22.763' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1252, 44, N'Pedido', N'Transportista', N'Sin asignar', N'Carlos Medina', N'jondem', CAST(N'2026-11-03T15:00:11.933' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1253, 44, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-11-03T15:50:56.943' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1254, 44, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-11-03T17:04:07.470' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1255, 44, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-11-04T14:37:43.377' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1256, 45, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-11-05T16:43:16.943' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1257, 45, N'Pedido', N'Transportista', N'Sin asignar', N'Sofia Ramirez', N'jondem', CAST(N'2026-11-05T17:30:09.473' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1258, 45, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-11-05T18:15:32.250' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1259, 45, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-11-05T19:52:08.020' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1260, 45, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-11-06T18:19:08.300' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1261, 46, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-11-06T17:16:39.010' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1262, 46, N'Pedido', N'Transportista', N'Sin asignar', N'Marina Lopez', N'jondem', CAST(N'2026-11-06T18:33:44.630' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1263, 46, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-11-06T18:54:20.190' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1264, 46, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-11-06T20:30:29.523' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1265, 46, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-11-07T16:37:50.003' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1266, 47, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-11-13T15:23:51.557' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1267, 47, N'Pedido', N'Transportista', N'Sin asignar', N'Diego Castro', N'jondem', CAST(N'2026-11-13T17:17:01.117' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1268, 47, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-11-13T18:08:57.420' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1269, 47, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-11-13T18:56:42.070' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1270, 47, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-11-14T19:48:14.780' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1271, 48, N'Pedido', N'Estado', N'Pendiente', N'Preparando', N'jondem', CAST(N'2026-11-13T15:37:46.287' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1272, 48, N'Pedido', N'Transportista', N'Sin asignar', N'Sofia Ramirez', N'jondem', CAST(N'2026-11-13T16:43:12.873' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1273, 48, N'Pedido', N'Estado', N'Preparando', N'Despachado', N'jondem', CAST(N'2026-11-13T16:57:19.310' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1274, 48, N'Pedido', N'Estado', N'Despachado', N'En camino', N'jondem', CAST(N'2026-11-13T17:42:34.720' AS DateTime))
GO
INSERT [dbo].[HistorialCambios] ([IdHistorial], [EntidadId], [NombreEntidad], [NombreCampo], [ValorAnterior], [ValorNuevo], [Usuario], [Fecha]) VALUES (1275, 48, N'Pedido', N'Estado', N'En camino', N'Entregado', N'jondem', CAST(N'2026-11-14T21:34:12.483' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[HistorialCambios] OFF
GO
SET IDENTITY_INSERT [dbo].[Factura] ON
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (1, 1, CAST(N'2026-09-22T11:59:58.717' AS DateTime), CAST(164000.00 AS Decimal(10, 2)), N'Transferencia', 9)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (2, 1, CAST(N'2026-09-22T12:00:47.627' AS DateTime), CAST(108000.00 AS Decimal(10, 2)), N'Efectivo', 2)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (3, 1, CAST(N'2026-09-22T15:07:05.840' AS DateTime), CAST(93000.00 AS Decimal(10, 2)), N'Transferencia', 1)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (4, 3, CAST(N'2026-09-24T16:02:48.267' AS DateTime), CAST(73000.00 AS Decimal(10, 2)), N'Transferencia', 4)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (5, 1, CAST(N'2026-09-25T23:33:07.263' AS DateTime), CAST(27000.00 AS Decimal(10, 2)), N'Transferencia', 2)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (6, 1, CAST(N'2026-09-25T23:33:38.987' AS DateTime), CAST(15000.00 AS Decimal(10, 2)), N'Efectivo', 5)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (7, 1, CAST(N'2026-09-26T00:41:08.600' AS DateTime), CAST(120000.00 AS Decimal(10, 2)), N'Efectivo', 9)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (8, 1, CAST(N'2026-10-24T13:19:21.290' AS DateTime), CAST(15000.00 AS Decimal(10, 2)), N'Efectivo', 4)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (9, 2, CAST(N'2026-06-01T17:04:33.000' AS DateTime), CAST(27000.00 AS Decimal(10, 2)), N'Transferencia', 7)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (10, 3, CAST(N'2026-06-01T19:23:48.000' AS DateTime), CAST(55000.00 AS Decimal(10, 2)), N'Transferencia', 1)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (11, 4, CAST(N'2026-06-05T12:55:59.000' AS DateTime), CAST(121000.00 AS Decimal(10, 2)), N'Efectivo', 9)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (12, 10, CAST(N'2026-06-05T17:08:06.000' AS DateTime), CAST(15000.00 AS Decimal(10, 2)), N'Transferencia', 6)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (13, 2, CAST(N'2026-06-08T16:49:00.000' AS DateTime), CAST(89000.00 AS Decimal(10, 2)), N'Efectivo', 4)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (14, 6, CAST(N'2026-06-13T15:07:18.000' AS DateTime), CAST(5000.00 AS Decimal(10, 2)), N'Transferencia', 0)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (15, 4, CAST(N'2026-06-16T11:31:47.000' AS DateTime), CAST(50000.00 AS Decimal(10, 2)), N'Efectivo', 6)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (16, 10, CAST(N'2026-06-19T13:54:11.000' AS DateTime), CAST(55000.00 AS Decimal(10, 2)), N'Transferencia', 2)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (17, 6, CAST(N'2026-06-28T10:40:51.000' AS DateTime), CAST(39000.00 AS Decimal(10, 2)), N'Transferencia', 8)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (18, 6, CAST(N'2026-07-01T12:51:15.000' AS DateTime), CAST(56000.00 AS Decimal(10, 2)), N'Transferencia', 8)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (19, 1, CAST(N'2026-07-03T19:37:11.000' AS DateTime), CAST(90000.00 AS Decimal(10, 2)), N'Transferencia', 0)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (20, 7, CAST(N'2026-07-03T19:47:50.000' AS DateTime), CAST(194000.00 AS Decimal(10, 2)), N'Efectivo', 1)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (21, 1, CAST(N'2026-07-07T17:11:37.000' AS DateTime), CAST(42000.00 AS Decimal(10, 2)), N'Transferencia', 4)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (22, 7, CAST(N'2026-07-08T16:42:53.000' AS DateTime), CAST(60000.00 AS Decimal(10, 2)), N'Transferencia', 6)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (23, 10, CAST(N'2026-07-09T10:17:19.000' AS DateTime), CAST(10000.00 AS Decimal(10, 2)), N'Efectivo', 1)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (24, 1, CAST(N'2026-07-14T15:02:24.000' AS DateTime), CAST(27000.00 AS Decimal(10, 2)), N'Efectivo', 0)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (25, 9, CAST(N'2026-07-19T18:43:17.000' AS DateTime), CAST(27000.00 AS Decimal(10, 2)), N'Transferencia', 8)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (26, 1, CAST(N'2026-07-26T11:56:25.000' AS DateTime), CAST(60000.00 AS Decimal(10, 2)), N'Efectivo', 8)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (27, 7, CAST(N'2026-07-27T15:17:32.000' AS DateTime), CAST(100000.00 AS Decimal(10, 2)), N'Efectivo', 0)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (28, 7, CAST(N'2026-07-28T11:44:18.000' AS DateTime), CAST(18000.00 AS Decimal(10, 2)), N'Transferencia', 2)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (29, 4, CAST(N'2026-07-30T13:05:45.000' AS DateTime), CAST(117000.00 AS Decimal(10, 2)), N'Transferencia', 0)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (30, 10, CAST(N'2026-07-31T16:56:09.000' AS DateTime), CAST(45000.00 AS Decimal(10, 2)), N'Efectivo', 4)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (31, 10, CAST(N'2026-08-10T14:38:02.000' AS DateTime), CAST(97000.00 AS Decimal(10, 2)), N'Transferencia', 0)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (32, 7, CAST(N'2026-08-12T19:04:12.000' AS DateTime), CAST(45000.00 AS Decimal(10, 2)), N'Efectivo', 0)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (33, 4, CAST(N'2026-08-13T14:18:38.000' AS DateTime), CAST(22000.00 AS Decimal(10, 2)), N'Transferencia', 3)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (34, 4, CAST(N'2026-08-22T14:42:36.000' AS DateTime), CAST(45000.00 AS Decimal(10, 2)), N'Efectivo', 3)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (35, 1, CAST(N'2026-08-23T15:56:55.000' AS DateTime), CAST(77000.00 AS Decimal(10, 2)), N'Transferencia', 6)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (36, 5, CAST(N'2026-08-25T19:46:30.000' AS DateTime), CAST(18000.00 AS Decimal(10, 2)), N'Transferencia', 5)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (37, 2, CAST(N'2026-08-28T14:19:17.000' AS DateTime), CAST(39000.00 AS Decimal(10, 2)), N'Transferencia', 6)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (38, 11, CAST(N'2026-08-28T18:02:48.000' AS DateTime), CAST(50000.00 AS Decimal(10, 2)), N'Transferencia', 4)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (39, 10, CAST(N'2026-08-29T18:40:09.000' AS DateTime), CAST(103000.00 AS Decimal(10, 2)), N'Transferencia', 5)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (40, 9, CAST(N'2026-08-30T13:01:50.000' AS DateTime), CAST(45000.00 AS Decimal(10, 2)), N'Efectivo', 8)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (41, 4, CAST(N'2026-09-04T17:32:12.000' AS DateTime), CAST(87000.00 AS Decimal(10, 2)), N'Efectivo', 6)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (42, 1, CAST(N'2026-09-06T16:45:55.000' AS DateTime), CAST(82000.00 AS Decimal(10, 2)), N'Transferencia', 2)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (43, 2, CAST(N'2026-09-09T11:38:03.000' AS DateTime), CAST(24000.00 AS Decimal(10, 2)), N'Transferencia', 5)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (44, 3, CAST(N'2026-09-09T12:27:29.000' AS DateTime), CAST(50000.00 AS Decimal(10, 2)), N'Efectivo', 1)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (45, 3, CAST(N'2026-09-10T12:42:34.000' AS DateTime), CAST(38000.00 AS Decimal(10, 2)), N'Transferencia', 3)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (46, 4, CAST(N'2026-09-11T13:38:27.000' AS DateTime), CAST(57000.00 AS Decimal(10, 2)), N'Efectivo', 2)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (47, 8, CAST(N'2026-09-14T14:35:20.000' AS DateTime), CAST(15000.00 AS Decimal(10, 2)), N'Transferencia', 2)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (48, 6, CAST(N'2026-09-16T14:30:59.000' AS DateTime), CAST(44000.00 AS Decimal(10, 2)), N'Efectivo', 5)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (49, 3, CAST(N'2026-09-21T14:29:20.000' AS DateTime), CAST(90000.00 AS Decimal(10, 2)), N'Transferencia', 0)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (50, 6, CAST(N'2026-09-26T14:12:34.000' AS DateTime), CAST(55000.00 AS Decimal(10, 2)), N'Efectivo', 7)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (51, 9, CAST(N'2026-09-27T14:30:57.000' AS DateTime), CAST(50000.00 AS Decimal(10, 2)), N'Efectivo', 0)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (52, 2, CAST(N'2026-09-29T13:46:17.000' AS DateTime), CAST(33000.00 AS Decimal(10, 2)), N'Efectivo', 6)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (53, 10, CAST(N'2026-10-02T10:19:42.000' AS DateTime), CAST(27000.00 AS Decimal(10, 2)), N'Efectivo', 0)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (54, 6, CAST(N'2026-10-03T11:07:41.000' AS DateTime), CAST(98000.00 AS Decimal(10, 2)), N'Transferencia', 0)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (55, 6, CAST(N'2026-10-03T15:54:05.000' AS DateTime), CAST(18000.00 AS Decimal(10, 2)), N'Efectivo', 3)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (56, 7, CAST(N'2026-10-03T18:59:21.000' AS DateTime), CAST(56000.00 AS Decimal(10, 2)), N'Transferencia', 5)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (57, 10, CAST(N'2026-10-05T11:44:07.000' AS DateTime), CAST(76000.00 AS Decimal(10, 2)), N'Efectivo', 3)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (58, 1, CAST(N'2026-10-11T18:35:44.000' AS DateTime), CAST(118000.00 AS Decimal(10, 2)), N'Transferencia', 3)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (59, 3, CAST(N'2026-10-13T10:30:11.000' AS DateTime), CAST(22000.00 AS Decimal(10, 2)), N'Efectivo', 8)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (60, 6, CAST(N'2026-10-13T11:00:05.000' AS DateTime), CAST(117000.00 AS Decimal(10, 2)), N'Transferencia', 6)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (61, 3, CAST(N'2026-10-14T13:07:46.000' AS DateTime), CAST(69000.00 AS Decimal(10, 2)), N'Transferencia', 1)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (62, 9, CAST(N'2026-10-15T13:56:11.000' AS DateTime), CAST(57000.00 AS Decimal(10, 2)), N'Efectivo', 5)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (63, 1, CAST(N'2026-10-16T11:14:04.000' AS DateTime), CAST(50000.00 AS Decimal(10, 2)), N'Transferencia', 3)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (64, 3, CAST(N'2026-10-16T11:22:04.000' AS DateTime), CAST(105000.00 AS Decimal(10, 2)), N'Transferencia', 0)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (65, 3, CAST(N'2026-10-17T11:41:41.000' AS DateTime), CAST(45000.00 AS Decimal(10, 2)), N'Efectivo', 6)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (66, 11, CAST(N'2026-10-20T12:26:14.000' AS DateTime), CAST(82000.00 AS Decimal(10, 2)), N'Efectivo', 0)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (67, 4, CAST(N'2026-10-22T17:02:03.000' AS DateTime), CAST(87000.00 AS Decimal(10, 2)), N'Efectivo', 6)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (68, 9, CAST(N'2026-10-23T10:59:31.000' AS DateTime), CAST(165000.00 AS Decimal(10, 2)), N'Efectivo', 5)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (69, 1, CAST(N'2026-10-23T16:21:42.000' AS DateTime), CAST(177000.00 AS Decimal(10, 2)), N'Transferencia', 0)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (70, 1, CAST(N'2026-10-27T17:05:19.000' AS DateTime), CAST(105000.00 AS Decimal(10, 2)), N'Efectivo', 5)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (71, 4, CAST(N'2026-10-27T18:02:45.000' AS DateTime), CAST(77000.00 AS Decimal(10, 2)), N'Efectivo', 5)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (72, 10, CAST(N'2026-10-28T12:44:33.000' AS DateTime), CAST(38000.00 AS Decimal(10, 2)), N'Efectivo', 7)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (73, 4, CAST(N'2026-10-29T16:58:23.000' AS DateTime), CAST(127000.00 AS Decimal(10, 2)), N'Transferencia', 1)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (74, 9, CAST(N'2026-11-01T14:21:22.000' AS DateTime), CAST(128000.00 AS Decimal(10, 2)), N'Efectivo', 5)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (75, 6, CAST(N'2026-11-01T14:58:00.000' AS DateTime), CAST(76000.00 AS Decimal(10, 2)), N'Transferencia', 5)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (76, 3, CAST(N'2026-11-03T11:00:04.000' AS DateTime), CAST(165000.00 AS Decimal(10, 2)), N'Transferencia', 3)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (77, 6, CAST(N'2026-11-05T12:26:01.000' AS DateTime), CAST(27000.00 AS Decimal(10, 2)), N'Transferencia', 9)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (78, 1, CAST(N'2026-11-06T16:03:18.000' AS DateTime), CAST(5000.00 AS Decimal(10, 2)), N'Transferencia', 8)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (79, 6, CAST(N'2026-11-11T13:31:44.000' AS DateTime), CAST(38000.00 AS Decimal(10, 2)), N'Transferencia', 9)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (80, 7, CAST(N'2026-11-13T11:29:31.000' AS DateTime), CAST(65000.00 AS Decimal(10, 2)), N'Efectivo', 1)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (81, 2, CAST(N'2026-11-13T13:38:55.000' AS DateTime), CAST(104000.00 AS Decimal(10, 2)), N'Transferencia', 5)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (82, 11, CAST(N'2026-11-14T18:58:11.000' AS DateTime), CAST(50000.00 AS Decimal(10, 2)), N'Efectivo', 8)
GO
INSERT [dbo].[Factura] ([IdFactura], [IdCliente], [Fecha], [Total], [MedioPago], [DVH]) VALUES (83, 9, CAST(N'2026-11-19T12:30:02.000' AS DateTime), CAST(65000.00 AS Decimal(10, 2)), N'Transferencia', 6)
GO
SET IDENTITY_INSERT [dbo].[Factura] OFF
GO
SET IDENTITY_INSERT [dbo].[Traduccion] ON
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (6, 1, N'button1', N'Restaurar valor anterior')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (7, 1, N'button2', N'Cerrar')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (10, 1, N'label1', N'Nombre de grupo: ')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (19, 3, N'button1', N'al')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (20, 3, N'button2', N'alo')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (21, 3, N'label1', N'ali')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (27, 1, N'btnEliminar', N'ELIMINAR')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (28, 1, N'btnModificar', N'MODIFICAR')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (29, 1, N'btnAñadir', N'AÑADIR')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (31, 1, N'lblAlquilerCanchas', N'Alquiler de canchas de fútbol')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (32, 1, N'lblContraseña', N'CONTRASEÑA : ')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (34, 1, N'btnIniciarSesion', N'INICIAR SESION')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (35, 1, N'lblRepetirContraseña', N'REPETIR CONTRASEÑA: ')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (36, 1, N'lblCriticidad', N'Criticidad')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (37, 1, N'lblHasta', N'Hasta')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (38, 1, N'lblDesde', N'Desde')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (39, 1, N'lblBitacora', N'Bitacora de eventos')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (41, 1, N'btnBuscar', N'Buscar')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (42, 2, N'btnAñadir', N'Add')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (43, 2, N'btnBuscar', N'Search')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (44, 2, N'btnEliminar', N'Delete')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (45, 2, N'btnIniciarSesion', N'Login')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (49, 2, N'lblBitacora', N'Event Log')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (50, 2, N'lblContraseña', N'Password :')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (51, 2, N'lblCriticidad', N'Criticality')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (52, 2, N'lblDesde', N'From')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (53, 2, N'lblHasta', N'Until')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (54, 2, N'lblRepetirContraseña', N'Repeat password:')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (56, 2, N'lblAlquilerCanchas', N'Soccer Field Rental')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (57, 2, N'btnQuitar', N'Remove')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (58, 2, N'btnAgregar', N'Add')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (60, 2, N'menuStrip1', N'menuStrip1')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (61, 1, N'btnQuitar', N'QUITAR')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (62, 1, N'btnAgregar', N'AGREGAR')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (64, 1, N'menuStrip1', N'menuStrip1')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (65, 4, N'lblAlquilerCanchas', N'Portugal')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (76, 1, N'uSUARIOToolStripMenuItem', N'USUARIO')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (77, 1, N'lOGINToolStripMenuItem', N'LOGIN')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (78, 1, N'lOGOUTToolStripMenuItem', N'LOGOUT')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (79, 1, N'bitacoraToolStripMenuItem', N'ADMIN')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (80, 1, N'bITACORAToolStripMenuItem1', N'BITACORA DE EVENTOS')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (81, 1, N'gESTIONDEUSUARIOSToolStripMenuItem', N'GESTION DE USUARIOS')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (82, 1, N'gESTIONDEPERFILESToolStripMenuItem', N'GESTION DE PERFILES')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (83, 1, N'bITACORADECAMBIOSToolStripMenuItem', N'BITACORA DE CAMBIOS')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (85, 1, N'gESTIONDEIDIOMASToolStripMenuItem', N'IDIOMAS')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (86, 1, N'sALIRToolStripMenuItem', N'SALIR')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (87, 2, N'uSUARIOToolStripMenuItem', N'USER')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (88, 2, N'lOGINToolStripMenuItem', N'LOGIN')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (89, 2, N'lOGOUTToolStripMenuItem', N'LOGOUT')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (90, 2, N'bitacoraToolStripMenuItem', N'ADMIN')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (91, 2, N'bITACORAToolStripMenuItem1', N'EVENT LOG')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (92, 2, N'gESTIONDEUSUARIOSToolStripMenuItem', N'USER MANAGEMENT')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (93, 2, N'gESTIONDEPERFILESToolStripMenuItem', N'PROFILE MANAGEMENT')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (94, 2, N'bITACORADECAMBIOSToolStripMenuItem', N'CHANGE LOG')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (96, 2, N'gESTIONDEIDIOMASToolStripMenuItem', N'LANGUAGES')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (97, 2, N'sALIRToolStripMenuItem', N'EXIT')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (98, 1, N'btnIdiomaInicio', N'Idioma')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (101, 1, N'sELECCIONARIDIOMAToolStripMenuItem', N'SELECCIONAR IDIOMA')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (102, 1, N'cREARIDIOMAToolStripMenuItem', N'CREAR IDIOMA')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (103, 1, N'btnCrearGP', N'CREAR GRUPO DE PERMISOS')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (107, 1, N'groupBox2', N'Permisos del grupo')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (108, 1, N'groupBox1', N'Permisos disponibles')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (110, 1, N'vENTASToolStripMenuItem', N'VENTAS')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (111, 1, N'rEGISTRARCLIENTEToolStripMenuItem', N'REGISTRAR CLIENTE')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (119, 1, N'lblDNI', N'DNI')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (120, 1, N'btnBuscarCliente', N'Buscar')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (122, 1, N'btnSeleccionarProductos', N'Seleccionar productos')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (124, 1, N'btnCobrarVenta', N'Cobrar venta')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (126, 1, N'btnGenerar', N'Generar factura')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (182, 1, N'cAMBIARCONTRASEÑAToolStripMenuItem', N'CAMBIAR CONTRASEÑA')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (183, 1, N'lblTituloContrasenia', N'Cambiar contraseña')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (184, 1, N'lblActual', N'Contraseña actual')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (185, 1, N'lblNueva', N'Contraseña nueva')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (186, 1, N'lblRepetir', N'Repetir contraseña nueva')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (187, 1, N'btnGuardarContrasenia', N'GUARDAR')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (188, 1, N'btnCancelarContrasenia', N'CANCELAR')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (372, 1, N'btnNuevo', N'NUEVO GRUPO')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (373, 1, N'lblmodo', N'MODO: ')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (374, 1, N'vENDEDORToolStripMenuItem', N'VENDEDOR')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (429, 3, N'lblSeleccionarIdioma', N'Selecciona el idioma')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (430, 3, N'lblBienvenido', N'Bienvenido')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (431, 3, N'btnConfirmar', N'Confirmar')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (509, 1, N'fACTURASToolStripMenuItem', N'FACTURAS')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (510, 1, N'lblTituloFacturas', N'Consultar facturas')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (511, 1, N'lblDNIConsulta', N'DNI')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (512, 1, N'btnBuscarFacturas', N'Buscar')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (514, 1, N'lblFacturasCliente', N'Facturas del cliente')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (515, 1, N'lblDetalleFactura', N'Detalle de la factura seleccionada')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (517, 1, N'btnExportarPDF', N'Exportar factura a PDF')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (518, 1, N'btnExportarExcel', N'Exportar listado a Excel')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (519, 1, N'btnVolverFacturas', N'Volver')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (520, 1, N'lblProductos', N'Productos')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (521, 1, N'lblCantidad', N'Cantidad')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (522, 1, N'btnAgregarProducto', N'Agregar')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (523, 1, N'lblCarrito', N'Carrito')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (524, 1, N'btnConfirmarProductos', N'Confirmar productos')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (525, 1, N'btnQuitarProducto', N'Quitar')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (526, 1, N'btnCerrar', N'Cerrar')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (527, 1, N'lblNombre', N'NOMBRE : ')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (528, 1, N'lblApellido', N'APELLIDO : ')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (529, 1, N'lblEmail', N'EMAIL : ')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (530, 1, N'lblTelefono', N'TELEFONO : ')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (531, 1, N'lblDireccion', N'DIRECCION : ')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (532, 1, N'btnRegistrar', N'REGISTRAR')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (533, 1, N'btnVolverCancelar', N'VOLVER')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (534, 1, N'lblTituloCobro', N'Cobrar venta')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (535, 1, N'lblTotalTexto', N'Total a cobrar:')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (536, 1, N'lblMedioPago', N'Medio de pago')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (537, 1, N'radioEfectivo', N'Efectivo')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (538, 1, N'radioTransferencia', N'Transferencia')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (539, 1, N'lblBanco', N'Banco')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (540, 1, N'lblNumeroCuenta', N'Numero de cuenta')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (541, 1, N'lblTitular', N'Titular')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (542, 1, N'btnCobrar', N'Cobrar')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (543, 1, N'btnCancelarPago', N'Cancelar')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (544, 1, N'lblTituloFactura', N'Generar factura')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (545, 1, N'lblDNIVenta', N'DNI')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (546, 1, N'btnVolverVentas', N'Volver')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (547, 2, N'lblProductos', N'Products')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (548, 2, N'lblCantidad', N'Quantity')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (549, 2, N'btnAgregarProducto', N'Add')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (550, 2, N'lblCarrito', N'Cart')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (551, 2, N'btnConfirmarProductos', N'Confirm products')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (552, 2, N'btnQuitarProducto', N'Remove')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (553, 2, N'btnCerrar', N'Close')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (554, 2, N'lblDNI', N'ID number : ')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (555, 2, N'lblNombre', N'FIRST NAME : ')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (556, 2, N'lblApellido', N'LAST NAME : ')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (557, 2, N'lblEmail', N'EMAIL : ')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (558, 2, N'lblTelefono', N'PHONE : ')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (559, 2, N'lblDireccion', N'ADDRESS : ')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (560, 2, N'btnRegistrar', N'REGISTER')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (561, 2, N'btnModificar', N'EDIT')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (562, 2, N'btnVolverCancelar', N'BACK')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (563, 2, N'lblTituloCobro', N'Charge sale')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (564, 2, N'lblTotalTexto', N'Total to charge:')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (565, 2, N'lblMedioPago', N'Payment method')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (566, 2, N'radioEfectivo', N'Cash')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (567, 2, N'radioTransferencia', N'Bank transfer')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (568, 2, N'lblBanco', N'Bank')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (569, 2, N'lblNumeroCuenta', N'Account number')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (570, 2, N'lblTitular', N'Account holder')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (571, 2, N'btnCobrar', N'Charge')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (572, 2, N'btnCancelarPago', N'Cancel')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (573, 2, N'lblTituloFactura', N'Generate invoice')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (574, 2, N'lblDNIVenta', N'ID number')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (575, 2, N'btnBuscarCliente', N'Search')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (576, 2, N'btnSeleccionarProductos', N'Select products')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (577, 2, N'btnCobrarVenta', N'Charge sale')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (578, 2, N'btnGenerar', N'Generate invoice')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (579, 2, N'btnVolverVentas', N'Back')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (580, 2, N'lblTituloContrasenia', N'Change password')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (581, 2, N'lblActual', N'Current password')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (582, 2, N'lblNueva', N'New password')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (583, 2, N'lblRepetir', N'Repeat new password')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (584, 2, N'btnGuardarContrasenia', N'SAVE')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (585, 2, N'btnCancelarContrasenia', N'CANCEL')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (591, 2, N'lblTituloFacturas', N'View invoices')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (592, 2, N'lblDNIConsulta', N'ID number')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (593, 2, N'btnBuscarFacturas', N'Search')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (594, 2, N'lblFacturasCliente', N'Customer invoices')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (595, 2, N'lblDetalleFactura', N'Selected invoice detail')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (596, 2, N'btnExportarPDF', N'Export invoice to PDF')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (597, 2, N'btnExportarExcel', N'Export list to Excel')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (598, 2, N'btnVolverFacturas', N'Back')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (599, 2, N'vENDEDORToolStripMenuItem', N'SELLER')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (600, 2, N'vENTASToolStripMenuItem', N'SALES')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (601, 2, N'rEGISTRARCLIENTEToolStripMenuItem', N'CUSTOMER MANAGEMENT')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (602, 2, N'fACTURASToolStripMenuItem', N'INVOICES')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (603, 2, N'cREARIDIOMAToolStripMenuItem', N'CREATE LANGUAGE')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (604, 2, N'sELECCIONARIDIOMAToolStripMenuItem', N'SELECT LANGUAGE')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (605, 2, N'cAMBIARCONTRASEÑAToolStripMenuItem', N'CHANGE PASSWORD')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (606, 2, N'btnCrearGP', N'CREATE PERMISSION GROUP')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (607, 2, N'btnNuevo', N'NEW GROUP')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (608, 2, N'groupBox1', N'Available permissions')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (609, 2, N'groupBox2', N'Group permissions')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (610, 2, N'lblmodo', N'MODE: ')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (611, 2, N'btnIdiomaInicio', N'Language')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (620, 2, N'button1', N'Restore previous value')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (621, 2, N'button2', N'Close')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (622, 2, N'label1', N'Group name: ')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (655, 1, N'eNVIOSToolStripMenuItem', N'ENVIOS')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (656, 1, N'dESPACHADORToolStripMenuItem', N'DESPACHADOR')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (657, 1, N'pEDIDOSToolStripMenuItem', N'PEDIDOS')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (658, 1, N'lblTituloEnvio', N'Registrar envio')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (659, 1, N'lblDNIEnvio', N'DNI')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (660, 1, N'lblFacturasEnvio', N'Facturas sin envio')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (661, 1, N'lblZonaEnvio', N'Zona de cobertura')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (662, 1, N'lblCostoTexto', N'Costo del envio:')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (663, 1, N'lblDireccionEnvio', N'Direccion de entrega')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (664, 1, N'lblTelefonoEnvio', N'Telefono de contacto')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (665, 1, N'btnConfirmarEnvio', N'Confirmar envio')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (666, 1, N'btnVolverEnvios', N'Volver')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (667, 1, N'lblTituloPedidos', N'Pedidos a entregar')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (668, 1, N'lblDetalleTexto', N'Detalle del pedido')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (669, 1, N'btnAvanzarEstado', N'Avanzar estado')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (670, 1, N'btnVolverPedidos', N'Volver')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (671, 1, N'rEPORTEDEENVIOSToolStripMenuItem', N'REPORTE DE ENVIOS')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (672, 1, N'lblTituloReporte', N'Reporte de envios')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (673, 1, N'lblDesdeReporte', N'Desde')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (674, 1, N'lblHastaReporte', N'Hasta')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (675, 1, N'lblEstadoReporte', N'Estado')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (676, 1, N'lblZonaReporte', N'Zona')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (677, 1, N'btnBuscarEnvios', N'Buscar')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (678, 1, N'btnExportarPDFEnvios', N'Exportar a PDF')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (679, 1, N'btnExportarExcelEnvios', N'Exportar a Excel')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (680, 1, N'btnVolverReporte', N'Volver')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (681, 2, N'eNVIOSToolStripMenuItem', N'SHIPMENTS')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (682, 2, N'dESPACHADORToolStripMenuItem', N'DISPATCHER')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (683, 2, N'pEDIDOSToolStripMenuItem', N'ORDERS')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (684, 2, N'lblTituloEnvio', N'Register shipment')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (685, 2, N'lblDNIEnvio', N'ID number')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (686, 2, N'lblFacturasEnvio', N'Invoices without shipment')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (687, 2, N'lblZonaEnvio', N'Coverage zone')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (688, 2, N'lblCostoTexto', N'Shipping cost:')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (689, 2, N'lblDireccionEnvio', N'Delivery address')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (690, 2, N'lblTelefonoEnvio', N'Contact phone')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (691, 2, N'btnConfirmarEnvio', N'Confirm shipment')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (692, 2, N'btnVolverEnvios', N'Back')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (693, 2, N'lblTituloPedidos', N'Orders to deliver')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (694, 2, N'lblDetalleTexto', N'Order detail')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (695, 2, N'btnAvanzarEstado', N'Advance status')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (696, 2, N'btnVolverPedidos', N'Back')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (697, 2, N'rEPORTEDEENVIOSToolStripMenuItem', N'SHIPMENT REPORT')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (698, 2, N'lblTituloReporte', N'Shipment report')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (699, 2, N'lblDesdeReporte', N'From')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (700, 2, N'lblHastaReporte', N'To')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (701, 2, N'lblEstadoReporte', N'Status')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (702, 2, N'lblZonaReporte', N'Zone')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (703, 2, N'btnBuscarEnvios', N'Search')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (704, 2, N'btnExportarPDFEnvios', N'Export to PDF')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (705, 2, N'btnExportarExcelEnvios', N'Export to Excel')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (706, 2, N'btnVolverReporte', N'Back')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (717, 1, N'aSIGNARTRANSPORTISTAToolStripMenuItem', N'ASIGNAR TRANSPORTISTA')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (718, 1, N'lblTituloAsignar', N'Asignar transportista')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (719, 1, N'lblPedidosAsignar', N'Pedidos preparados')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (720, 1, N'lblTransportistasAsignar', N'Transportistas')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (721, 1, N'btnAsignarTransportista', N'Asignar')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (722, 1, N'btnVolverAsignar', N'Volver')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (723, 2, N'aSIGNARTRANSPORTISTAToolStripMenuItem', N'ASSIGN CARRIER')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (724, 2, N'lblTituloAsignar', N'Assign carrier')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (725, 2, N'lblPedidosAsignar', N'Prepared orders')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (726, 2, N'lblTransportistasAsignar', N'Carriers')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (727, 2, N'btnAsignarTransportista', N'Assign')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (728, 2, N'btnVolverAsignar', N'Back')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (737, 1, N'grpSerializacion', N'SERIALIZACION')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (738, 1, N'btnSerializar', N'SERIALIZAR')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (739, 1, N'btnDeserializar', N'DES-SERIALIZAR')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (740, 1, N'btnRutaSerializar', N'...')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (741, 1, N'btnRutaDeserializar', N'...')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (742, 1, N'btnActualizarGrilla', N'ACTUALIZAR')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (743, 1, N'btnLimpiarGrilla', N'LIMPIAR')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (744, 1, N'lblMensaje', N'MENSAJE : ')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (745, 2, N'grpSerializacion', N'SERIALIZATION')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (746, 2, N'btnSerializar', N'SERIALIZE')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (747, 2, N'btnDeserializar', N'DESERIALIZE')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (748, 2, N'btnRutaSerializar', N'...')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (749, 2, N'btnRutaDeserializar', N'...')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (750, 2, N'btnActualizarGrilla', N'REFRESH')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (751, 2, N'btnLimpiarGrilla', N'CLEAR')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (752, 2, N'lblMensaje', N'MESSAGE : ')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (753, 1, N'lblUsuario', N'USUARIO')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (755, 1, N'btnLimpiar', N'Limpiar')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (756, 1, N'lblTituloHistorial', N'Historial de Cambios')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (757, 1, N'lblUsuarioHistorial', N'Usuario:')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (758, 2, N'lblUsuario', N'User')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (760, 2, N'btnLimpiar', N'Clear')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (761, 2, N'lblTituloHistorial', N'Change History')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (762, 2, N'lblUsuarioHistorial', N'User:')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (765, 1, N'lblPerfilUsuario', N'PERFIL DEL USUARIO')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (766, 1, N'lblPerfiles', N'PERFILES')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (767, 1, N'btnAsignarPerfil', N'ASIGNAR PERFIL')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (768, 1, N'btnQuitarPerfil', N'QUITAR PERFIL')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (769, 1, N'lblCodigoGrupo', N'Codigo de grupo: ')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (770, 2, N'lblPerfilUsuario', N'USER PROFILE')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (771, 2, N'lblPerfiles', N'PROFILES')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (772, 2, N'btnAsignarPerfil', N'ASSIGN PROFILE')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (773, 2, N'btnQuitarPerfil', N'REMOVE PROFILE')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (774, 2, N'lblCodigoGrupo', N'Group code: ')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (775, 1, N'btnGuardar', N'GUARDAR')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (776, 1, N'btnGuardarTraduccion', N'Guardar traducción')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (777, 1, N'btnVolver', N'Volver')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (778, 1, N'btnCambiarIdioma', N'Aplicar idioma')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (779, 1, N'btnNuevoIdioma', N'Crear idioma')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (780, 1, N'btnConfirmar', N'Confirmar')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (781, 1, N'lblBienvenido', N'Bienvenido')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (782, 1, N'lblSeleccionarIdioma', N'Selecciona el idioma')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (783, 1, N'lblIdioma', N'Gestion de Idiomas')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (784, 1, N'lblIdiomaActivo', N'Idioma')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (785, 1, N'lblNuevoIdioma', N'Nuevo idioma')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (786, 1, N'lblClaves', N'Claves')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (787, 1, N'lblClave', N'Clave')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (788, 1, N'lblTexto', N'Traducción')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (789, 2, N'btnGuardar', N'Save')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (790, 2, N'btnGuardarTraduccion', N'Save translation')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (791, 2, N'btnVolver', N'Back')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (792, 2, N'btnCambiarIdioma', N'Apply language')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (793, 2, N'btnNuevoIdioma', N'Create language')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (794, 2, N'btnConfirmar', N'Confirm')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (795, 2, N'lblBienvenido', N'Welcome')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (796, 2, N'lblSeleccionarIdioma', N'Select the language')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (797, 2, N'lblIdioma', N'Language management')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (798, 2, N'lblIdiomaActivo', N'Language')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (799, 2, N'lblNuevoIdioma', N'New language')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (800, 2, N'lblClaves', N'Keys')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (801, 2, N'lblClave', N'Key')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (802, 2, N'lblTexto', N'Translation')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (819, 1, N'mAESTROSToolStripMenuItem', N'MAESTROS')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (820, 1, N'lblTituloCambios', N'Bitacora de cambios')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (821, 1, N'lblUsuarioCambios', N'Usuario')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (822, 1, N'lblNombreCambios', N'Nombre')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (823, 1, N'lblFechaInicioCambios', N'Fecha inicio')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (824, 1, N'lblFechaFinCambios', N'Fecha fin')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (825, 1, N'btnAplicarCambios', N'Aplicar')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (826, 1, N'btnLimpiarCambios', N'Limpiar')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (827, 1, N'btnActivarCambios', N'Activar')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (828, 1, N'btnSalirCambios', N'Salir')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (829, 2, N'mAESTROSToolStripMenuItem', N'MASTERS')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (830, 2, N'lblTituloCambios', N'Change log')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (831, 2, N'lblUsuarioCambios', N'User')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (832, 2, N'lblNombreCambios', N'Name')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (833, 2, N'lblFechaInicioCambios', N'Start date')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (834, 2, N'lblFechaFinCambios', N'End date')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (835, 2, N'btnAplicarCambios', N'Apply')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (836, 2, N'btnLimpiarCambios', N'Clear')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (837, 2, N'btnActivarCambios', N'Activate')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (838, 2, N'btnSalirCambios', N'Exit')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (841, 1, N'aYUDAToolStripMenuItem', N'AYUDA')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (842, 1, N'btnAyuda', N'?')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (843, 2, N'aYUDAToolStripMenuItem', N'HELP')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (844, 2, N'btnAyuda', N'?')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (845, 1, N'rEPORTEINTELIGENTEToolStripMenuItem', N'REPORTE INTELIGENTE')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (846, 1, N'lblTituloInteligente', N'Reporte inteligente')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (847, 1, N'lblDesdeInteligente', N'Desde')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (848, 1, N'lblHastaInteligente', N'Hasta')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (849, 1, N'btnAnalizar', N'Analizar')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (850, 1, N'lblIndicadores', N'Indicadores')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (851, 1, N'lblConclusiones', N'Conclusiones y recomendaciones')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (852, 1, N'btnExportarPDFInteligente', N'Exportar a PDF')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (853, 1, N'btnVolverInteligente', N'Volver')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (854, 2, N'rEPORTEINTELIGENTEToolStripMenuItem', N'SMART REPORT')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (855, 2, N'lblTituloInteligente', N'Smart report')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (856, 2, N'lblDesdeInteligente', N'From')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (857, 2, N'lblHastaInteligente', N'To')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (858, 2, N'btnAnalizar', N'Analyze')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (859, 2, N'lblIndicadores', N'Indicators')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (860, 2, N'lblConclusiones', N'Conclusions and recommendations')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (861, 2, N'btnExportarPDFInteligente', N'Export to PDF')
GO
INSERT [dbo].[Traduccion] ([IdTraduccion], [IdIdioma], [Clave], [Texto]) VALUES (862, 2, N'btnVolverInteligente', N'Back')
GO
SET IDENTITY_INSERT [dbo].[Traduccion] OFF
GO
INSERT [dbo].[PermisoRelacion] ([PadreId], [HijoId]) VALUES (12, 20)
GO
INSERT [dbo].[PermisoRelacion] ([PadreId], [HijoId]) VALUES (19, 1)
GO
INSERT [dbo].[PermisoRelacion] ([PadreId], [HijoId]) VALUES (19, 2)
GO
INSERT [dbo].[PermisoRelacion] ([PadreId], [HijoId]) VALUES (19, 3)
GO
INSERT [dbo].[PermisoRelacion] ([PadreId], [HijoId]) VALUES (19, 11)
GO
INSERT [dbo].[PermisoRelacion] ([PadreId], [HijoId]) VALUES (20, 5)
GO
INSERT [dbo].[PermisoRelacion] ([PadreId], [HijoId]) VALUES (20, 14)
GO
INSERT [dbo].[PermisoRelacion] ([PadreId], [HijoId]) VALUES (20, 15)
GO
INSERT [dbo].[PermisoRelacion] ([PadreId], [HijoId]) VALUES (20, 16)
GO
INSERT [dbo].[PermisoRelacion] ([PadreId], [HijoId]) VALUES (20, 17)
GO
INSERT [dbo].[PermisoRelacion] ([PadreId], [HijoId]) VALUES (20, 27)
GO
INSERT [dbo].[PermisoRelacion] ([PadreId], [HijoId]) VALUES (21, 13)
GO
INSERT [dbo].[PermisoRelacion] ([PadreId], [HijoId]) VALUES (21, 18)
GO
INSERT [dbo].[PermisoRelacion] ([PadreId], [HijoId]) VALUES (22, 7)
GO
INSERT [dbo].[PermisoRelacion] ([PadreId], [HijoId]) VALUES (23, 21)
GO
INSERT [dbo].[PermisoRelacion] ([PadreId], [HijoId]) VALUES (24, 19)
GO
INSERT [dbo].[PermisoRelacion] ([PadreId], [HijoId]) VALUES (24, 20)
GO
INSERT [dbo].[PermisoRelacion] ([PadreId], [HijoId]) VALUES (24, 21)
GO
INSERT [dbo].[PermisoRelacion] ([PadreId], [HijoId]) VALUES (24, 22)
GO
SET IDENTITY_INSERT [dbo].[DetalleFactura] ON
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (1, 1, 1, 2, CAST(15000.00 AS Decimal(10, 2)), 8)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (2, 1, 6, 2, CAST(18000.00 AS Decimal(10, 2)), 4)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (3, 1, 7, 1, CAST(22000.00 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (4, 1, 8, 2, CAST(38000.00 AS Decimal(10, 2)), 2)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (5, 2, 4, 1, CAST(12000.00 AS Decimal(10, 2)), 4)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (6, 2, 6, 2, CAST(18000.00 AS Decimal(10, 2)), 8)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (7, 2, 7, 1, CAST(22000.00 AS Decimal(10, 2)), 5)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (8, 2, 8, 1, CAST(38000.00 AS Decimal(10, 2)), 9)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (9, 3, 2, 1, CAST(45000.00 AS Decimal(10, 2)), 2)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (10, 3, 5, 1, CAST(5000.00 AS Decimal(10, 2)), 2)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (11, 3, 8, 1, CAST(38000.00 AS Decimal(10, 2)), 2)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (12, 3, 5, 1, CAST(5000.00 AS Decimal(10, 2)), 4)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (13, 4, 1, 1, CAST(15000.00 AS Decimal(10, 2)), 3)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (14, 4, 5, 4, CAST(5000.00 AS Decimal(10, 2)), 7)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (15, 4, 8, 1, CAST(38000.00 AS Decimal(10, 2)), 6)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (16, 5, 1, 1, CAST(15000.00 AS Decimal(10, 2)), 6)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (17, 5, 4, 1, CAST(12000.00 AS Decimal(10, 2)), 6)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (18, 6, 1, 1, CAST(15000.00 AS Decimal(10, 2)), 8)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (19, 7, 1, 1, CAST(15000.00 AS Decimal(10, 2)), 9)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (20, 7, 2, 1, CAST(45000.00 AS Decimal(10, 2)), 3)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (21, 7, 4, 2, CAST(12000.00 AS Decimal(10, 2)), 7)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (22, 7, 6, 2, CAST(18000.00 AS Decimal(10, 2)), 4)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (23, 8, 1, 1, CAST(15000.00 AS Decimal(10, 2)), 3)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (24, 9, 1, 1, CAST(15000.00 AS Decimal(10, 2)), 4)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (25, 9, 4, 1, CAST(12000.00 AS Decimal(10, 2)), 4)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (26, 10, 2, 1, CAST(45000.00 AS Decimal(10, 2)), 9)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (27, 10, 5, 2, CAST(5000.00 AS Decimal(10, 2)), 6)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (28, 11, 2, 1, CAST(45000.00 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (29, 11, 8, 2, CAST(38000.00 AS Decimal(10, 2)), 7)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (30, 12, 1, 1, CAST(15000.00 AS Decimal(10, 2)), 0)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (31, 13, 3, 1, CAST(89000.00 AS Decimal(10, 2)), 7)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (32, 14, 5, 1, CAST(5000.00 AS Decimal(10, 2)), 4)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (33, 15, 2, 1, CAST(45000.00 AS Decimal(10, 2)), 6)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (34, 15, 5, 1, CAST(5000.00 AS Decimal(10, 2)), 6)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (35, 16, 2, 1, CAST(45000.00 AS Decimal(10, 2)), 8)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (36, 16, 5, 2, CAST(5000.00 AS Decimal(10, 2)), 5)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (37, 17, 1, 1, CAST(15000.00 AS Decimal(10, 2)), 7)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (38, 17, 4, 2, CAST(12000.00 AS Decimal(10, 2)), 4)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (39, 18, 4, 1, CAST(12000.00 AS Decimal(10, 2)), 8)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (40, 18, 7, 2, CAST(22000.00 AS Decimal(10, 2)), 5)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (41, 19, 2, 2, CAST(45000.00 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (42, 20, 2, 2, CAST(45000.00 AS Decimal(10, 2)), 2)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (43, 20, 5, 3, CAST(5000.00 AS Decimal(10, 2)), 9)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (44, 20, 3, 1, CAST(89000.00 AS Decimal(10, 2)), 0)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (45, 21, 1, 2, CAST(15000.00 AS Decimal(10, 2)), 2)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (46, 21, 4, 1, CAST(12000.00 AS Decimal(10, 2)), 5)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (47, 22, 2, 1, CAST(45000.00 AS Decimal(10, 2)), 0)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (48, 22, 5, 3, CAST(5000.00 AS Decimal(10, 2)), 4)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (49, 23, 5, 2, CAST(5000.00 AS Decimal(10, 2)), 8)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (50, 24, 1, 1, CAST(15000.00 AS Decimal(10, 2)), 0)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (51, 24, 4, 1, CAST(12000.00 AS Decimal(10, 2)), 0)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (52, 25, 1, 1, CAST(15000.00 AS Decimal(10, 2)), 2)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (53, 25, 4, 1, CAST(12000.00 AS Decimal(10, 2)), 2)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (54, 26, 2, 1, CAST(45000.00 AS Decimal(10, 2)), 7)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (55, 26, 5, 3, CAST(5000.00 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (56, 27, 2, 2, CAST(45000.00 AS Decimal(10, 2)), 6)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (57, 27, 5, 2, CAST(5000.00 AS Decimal(10, 2)), 6)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (58, 28, 6, 1, CAST(18000.00 AS Decimal(10, 2)), 3)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (59, 29, 1, 1, CAST(15000.00 AS Decimal(10, 2)), 9)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (60, 29, 4, 1, CAST(12000.00 AS Decimal(10, 2)), 9)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (61, 29, 2, 2, CAST(45000.00 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (62, 30, 2, 1, CAST(45000.00 AS Decimal(10, 2)), 5)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (63, 31, 2, 1, CAST(45000.00 AS Decimal(10, 2)), 6)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (64, 31, 5, 2, CAST(5000.00 AS Decimal(10, 2)), 3)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (65, 31, 1, 2, CAST(15000.00 AS Decimal(10, 2)), 2)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (66, 31, 4, 1, CAST(12000.00 AS Decimal(10, 2)), 5)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (67, 32, 2, 1, CAST(45000.00 AS Decimal(10, 2)), 0)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (68, 33, 7, 1, CAST(22000.00 AS Decimal(10, 2)), 6)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (69, 34, 2, 1, CAST(45000.00 AS Decimal(10, 2)), 2)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (70, 35, 2, 1, CAST(45000.00 AS Decimal(10, 2)), 3)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (71, 35, 5, 2, CAST(5000.00 AS Decimal(10, 2)), 0)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (72, 35, 7, 1, CAST(22000.00 AS Decimal(10, 2)), 0)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (73, 36, 6, 1, CAST(18000.00 AS Decimal(10, 2)), 8)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (74, 37, 1, 1, CAST(15000.00 AS Decimal(10, 2)), 4)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (75, 37, 4, 2, CAST(12000.00 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (76, 38, 8, 1, CAST(38000.00 AS Decimal(10, 2)), 7)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (77, 38, 4, 1, CAST(12000.00 AS Decimal(10, 2)), 6)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (78, 39, 2, 1, CAST(45000.00 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (79, 39, 5, 2, CAST(5000.00 AS Decimal(10, 2)), 8)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (80, 39, 6, 1, CAST(18000.00 AS Decimal(10, 2)), 5)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (81, 39, 1, 2, CAST(15000.00 AS Decimal(10, 2)), 8)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (82, 40, 2, 1, CAST(45000.00 AS Decimal(10, 2)), 5)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (83, 41, 2, 1, CAST(45000.00 AS Decimal(10, 2)), 6)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (84, 41, 5, 3, CAST(5000.00 AS Decimal(10, 2)), 0)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (85, 41, 1, 1, CAST(15000.00 AS Decimal(10, 2)), 5)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (86, 41, 4, 1, CAST(12000.00 AS Decimal(10, 2)), 5)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (87, 42, 2, 1, CAST(45000.00 AS Decimal(10, 2)), 0)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (88, 42, 5, 3, CAST(5000.00 AS Decimal(10, 2)), 4)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (89, 42, 7, 1, CAST(22000.00 AS Decimal(10, 2)), 7)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (90, 43, 4, 2, CAST(12000.00 AS Decimal(10, 2)), 6)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (91, 44, 2, 1, CAST(45000.00 AS Decimal(10, 2)), 4)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (92, 44, 5, 1, CAST(5000.00 AS Decimal(10, 2)), 4)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (93, 45, 8, 1, CAST(38000.00 AS Decimal(10, 2)), 4)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (94, 46, 1, 1, CAST(15000.00 AS Decimal(10, 2)), 4)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (95, 46, 4, 2, CAST(12000.00 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (96, 46, 6, 1, CAST(18000.00 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (97, 47, 1, 1, CAST(15000.00 AS Decimal(10, 2)), 7)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (98, 48, 7, 2, CAST(22000.00 AS Decimal(10, 2)), 3)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (99, 49, 1, 2, CAST(15000.00 AS Decimal(10, 2)), 6)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (100, 49, 4, 2, CAST(12000.00 AS Decimal(10, 2)), 6)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (101, 49, 6, 2, CAST(18000.00 AS Decimal(10, 2)), 3)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (102, 50, 2, 1, CAST(45000.00 AS Decimal(10, 2)), 5)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (103, 50, 5, 2, CAST(5000.00 AS Decimal(10, 2)), 2)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (104, 51, 2, 1, CAST(45000.00 AS Decimal(10, 2)), 7)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (105, 51, 5, 1, CAST(5000.00 AS Decimal(10, 2)), 7)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (106, 52, 6, 1, CAST(18000.00 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (107, 52, 1, 1, CAST(15000.00 AS Decimal(10, 2)), 7)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (108, 53, 1, 1, CAST(15000.00 AS Decimal(10, 2)), 8)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (109, 53, 4, 1, CAST(12000.00 AS Decimal(10, 2)), 8)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (110, 54, 2, 1, CAST(45000.00 AS Decimal(10, 2)), 3)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (111, 54, 5, 3, CAST(5000.00 AS Decimal(10, 2)), 7)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (112, 54, 8, 1, CAST(38000.00 AS Decimal(10, 2)), 3)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (113, 55, 6, 1, CAST(18000.00 AS Decimal(10, 2)), 8)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (114, 56, 8, 1, CAST(38000.00 AS Decimal(10, 2)), 5)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (115, 56, 6, 1, CAST(18000.00 AS Decimal(10, 2)), 0)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (116, 57, 8, 2, CAST(38000.00 AS Decimal(10, 2)), 4)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (117, 58, 2, 2, CAST(45000.00 AS Decimal(10, 2)), 7)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (118, 58, 5, 2, CAST(5000.00 AS Decimal(10, 2)), 7)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (119, 58, 6, 1, CAST(18000.00 AS Decimal(10, 2)), 4)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (120, 59, 7, 1, CAST(22000.00 AS Decimal(10, 2)), 8)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (121, 60, 2, 2, CAST(45000.00 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (122, 60, 5, 1, CAST(5000.00 AS Decimal(10, 2)), 4)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (123, 60, 7, 1, CAST(22000.00 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (124, 61, 2, 1, CAST(45000.00 AS Decimal(10, 2)), 7)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (125, 61, 4, 2, CAST(12000.00 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (126, 62, 4, 1, CAST(12000.00 AS Decimal(10, 2)), 5)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (127, 62, 2, 1, CAST(45000.00 AS Decimal(10, 2)), 0)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (128, 63, 2, 1, CAST(45000.00 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (129, 63, 5, 1, CAST(5000.00 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (130, 64, 2, 1, CAST(45000.00 AS Decimal(10, 2)), 3)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (131, 64, 5, 3, CAST(5000.00 AS Decimal(10, 2)), 7)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (132, 64, 1, 1, CAST(15000.00 AS Decimal(10, 2)), 2)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (133, 64, 4, 1, CAST(12000.00 AS Decimal(10, 2)), 2)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (134, 64, 6, 1, CAST(18000.00 AS Decimal(10, 2)), 9)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (135, 65, 2, 1, CAST(45000.00 AS Decimal(10, 2)), 8)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (136, 66, 2, 1, CAST(45000.00 AS Decimal(10, 2)), 9)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (137, 66, 5, 2, CAST(5000.00 AS Decimal(10, 2)), 6)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (138, 66, 1, 1, CAST(15000.00 AS Decimal(10, 2)), 8)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (139, 66, 4, 1, CAST(12000.00 AS Decimal(10, 2)), 8)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (140, 67, 2, 1, CAST(45000.00 AS Decimal(10, 2)), 3)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (141, 67, 5, 3, CAST(5000.00 AS Decimal(10, 2)), 7)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (142, 67, 1, 1, CAST(15000.00 AS Decimal(10, 2)), 2)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (143, 67, 4, 1, CAST(12000.00 AS Decimal(10, 2)), 2)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (144, 68, 3, 1, CAST(89000.00 AS Decimal(10, 2)), 0)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (145, 68, 8, 2, CAST(38000.00 AS Decimal(10, 2)), 3)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (146, 69, 2, 1, CAST(45000.00 AS Decimal(10, 2)), 9)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (147, 69, 5, 1, CAST(5000.00 AS Decimal(10, 2)), 9)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (148, 69, 8, 1, CAST(38000.00 AS Decimal(10, 2)), 9)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (149, 69, 3, 1, CAST(89000.00 AS Decimal(10, 2)), 5)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (150, 70, 2, 2, CAST(45000.00 AS Decimal(10, 2)), 0)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (151, 70, 5, 3, CAST(5000.00 AS Decimal(10, 2)), 7)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (152, 71, 1, 1, CAST(15000.00 AS Decimal(10, 2)), 2)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (153, 71, 4, 2, CAST(12000.00 AS Decimal(10, 2)), 9)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (154, 71, 8, 1, CAST(38000.00 AS Decimal(10, 2)), 5)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (155, 72, 8, 1, CAST(38000.00 AS Decimal(10, 2)), 6)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (156, 73, 8, 1, CAST(38000.00 AS Decimal(10, 2)), 7)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (157, 73, 3, 1, CAST(89000.00 AS Decimal(10, 2)), 3)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (158, 74, 1, 1, CAST(15000.00 AS Decimal(10, 2)), 8)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (159, 74, 4, 2, CAST(12000.00 AS Decimal(10, 2)), 5)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (160, 74, 3, 1, CAST(89000.00 AS Decimal(10, 2)), 6)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (161, 75, 8, 2, CAST(38000.00 AS Decimal(10, 2)), 9)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (162, 76, 3, 1, CAST(89000.00 AS Decimal(10, 2)), 8)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (163, 76, 8, 2, CAST(38000.00 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (164, 77, 1, 1, CAST(15000.00 AS Decimal(10, 2)), 4)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (165, 77, 4, 1, CAST(12000.00 AS Decimal(10, 2)), 4)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (166, 78, 5, 1, CAST(5000.00 AS Decimal(10, 2)), 8)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (167, 79, 8, 1, CAST(38000.00 AS Decimal(10, 2)), 8)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (168, 80, 1, 1, CAST(15000.00 AS Decimal(10, 2)), 8)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (169, 80, 4, 1, CAST(12000.00 AS Decimal(10, 2)), 8)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (170, 80, 8, 1, CAST(38000.00 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (171, 81, 1, 1, CAST(15000.00 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (172, 81, 3, 1, CAST(89000.00 AS Decimal(10, 2)), 8)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (173, 82, 2, 1, CAST(45000.00 AS Decimal(10, 2)), 6)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (174, 82, 5, 1, CAST(5000.00 AS Decimal(10, 2)), 6)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (175, 83, 2, 1, CAST(45000.00 AS Decimal(10, 2)), 8)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (176, 83, 5, 1, CAST(5000.00 AS Decimal(10, 2)), 8)
GO
INSERT [dbo].[DetalleFactura] ([IdDetalle], [IdFactura], [IdProducto], [Cantidad], [PrecioUnitario], [DVH]) VALUES (177, 83, 1, 1, CAST(15000.00 AS Decimal(10, 2)), 7)
GO
SET IDENTITY_INSERT [dbo].[DetalleFactura] OFF
GO
SET IDENTITY_INSERT [dbo].[Pedido] ON
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (1, 8, CAST(N'2026-10-24T13:20:37.943' AS DateTime), N'Entregado', 4)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (2, 7, CAST(N'2026-10-24T13:23:25.183' AS DateTime), N'Entregado', 2)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (3, 1, CAST(N'2026-10-25T21:36:40.253' AS DateTime), N'Entregado', 2)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (4, 6, CAST(N'2026-10-26T18:26:34.513' AS DateTime), N'Entregado', 5)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (5, 5, CAST(N'2026-10-26T19:18:59.130' AS DateTime), N'Entregado', 3)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (6, 2, CAST(N'2026-10-26T19:20:10.027' AS DateTime), N'Entregado', 5)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (7, 9, CAST(N'2026-06-01T17:22:33.000' AS DateTime), N'Entregado', 2)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (8, 10, CAST(N'2026-06-01T19:56:48.000' AS DateTime), N'Entregado', 6)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (9, 13, CAST(N'2026-06-08T17:21:00.000' AS DateTime), N'Entregado', 5)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (10, 16, CAST(N'2026-06-19T14:11:11.000' AS DateTime), N'Entregado', 2)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (11, 17, CAST(N'2026-06-28T10:53:51.000' AS DateTime), N'Entregado', 9)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (12, 21, CAST(N'2026-07-07T17:37:37.000' AS DateTime), N'Entregado', 5)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (13, 26, CAST(N'2026-07-26T12:15:25.000' AS DateTime), N'Entregado', 4)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (14, 27, CAST(N'2026-07-27T15:26:32.000' AS DateTime), N'Entregado', 5)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (15, 28, CAST(N'2026-07-28T12:21:18.000' AS DateTime), N'Entregado', 6)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (16, 29, CAST(N'2026-07-30T13:13:45.000' AS DateTime), N'Entregado', 4)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (17, 30, CAST(N'2026-07-31T17:16:09.000' AS DateTime), N'Entregado', 5)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (18, 31, CAST(N'2026-08-10T15:00:02.000' AS DateTime), N'Entregado', 2)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (19, 33, CAST(N'2026-08-13T14:32:38.000' AS DateTime), N'Entregado', 0)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (20, 35, CAST(N'2026-08-23T16:35:55.000' AS DateTime), N'Entregado', 7)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (21, 36, CAST(N'2026-08-25T20:02:30.000' AS DateTime), N'Entregado', 5)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (22, 43, CAST(N'2026-09-09T11:45:03.000' AS DateTime), N'Entregado', 5)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (23, 44, CAST(N'2026-09-09T12:49:29.000' AS DateTime), N'Entregado', 9)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (24, 46, CAST(N'2026-09-11T13:47:27.000' AS DateTime), N'Entregado', 0)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (25, 47, CAST(N'2026-09-14T14:56:20.000' AS DateTime), N'Entregado', 5)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (26, 50, CAST(N'2026-09-26T14:42:34.000' AS DateTime), N'Entregado', 9)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (27, 51, CAST(N'2026-09-27T15:02:57.000' AS DateTime), N'Entregado', 0)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (28, 53, CAST(N'2026-10-02T10:47:42.000' AS DateTime), N'Entregado', 2)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (29, 56, CAST(N'2026-10-03T19:04:21.000' AS DateTime), N'Entregado', 9)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (30, 57, CAST(N'2026-10-05T12:00:07.000' AS DateTime), N'Entregado', 7)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (31, 58, CAST(N'2026-10-11T18:59:44.000' AS DateTime), N'Entregado', 3)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (32, 60, CAST(N'2026-10-13T11:10:05.000' AS DateTime), N'Entregado', 4)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (33, 61, CAST(N'2026-10-14T13:26:46.000' AS DateTime), N'Entregado', 5)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (34, 63, CAST(N'2026-10-16T11:52:04.000' AS DateTime), N'Entregado', 6)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (35, 65, CAST(N'2026-10-17T12:15:41.000' AS DateTime), N'Entregado', 0)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (36, 66, CAST(N'2026-10-20T12:42:14.000' AS DateTime), N'Entregado', 5)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (37, 67, CAST(N'2026-10-22T17:34:03.000' AS DateTime), N'Entregado', 3)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (38, 69, CAST(N'2026-10-23T16:27:42.000' AS DateTime), N'Entregado', 7)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (39, 70, CAST(N'2026-10-27T17:34:19.000' AS DateTime), N'Entregado', 9)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (40, 71, CAST(N'2026-10-27T18:29:45.000' AS DateTime), N'Entregado', 3)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (41, 72, CAST(N'2026-10-28T13:20:33.000' AS DateTime), N'Entregado', 4)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (42, 73, CAST(N'2026-10-29T17:30:23.000' AS DateTime), N'Entregado', 5)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (43, 75, CAST(N'2026-11-01T15:31:00.000' AS DateTime), N'Entregado', 6)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (44, 76, CAST(N'2026-11-03T11:30:04.000' AS DateTime), N'Entregado', 4)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (45, 77, CAST(N'2026-11-05T12:53:01.000' AS DateTime), N'Entregado', 2)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (46, 78, CAST(N'2026-11-06T16:09:18.000' AS DateTime), N'Entregado', 3)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (47, 80, CAST(N'2026-11-13T11:54:31.000' AS DateTime), N'Entregado', 9)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (48, 81, CAST(N'2026-11-13T13:51:55.000' AS DateTime), N'Entregado', 3)
GO
INSERT [dbo].[Pedido] ([IdPedido], [IdFactura], [Fecha], [Estado], [DVH]) VALUES (49, 83, CAST(N'2026-11-19T12:54:02.000' AS DateTime), N'Pendiente', 5)
GO
SET IDENTITY_INSERT [dbo].[Pedido] OFF
GO
SET IDENTITY_INSERT [dbo].[Envio] ON
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (1, 1, 4, N'Arenales', N'1127454549', CAST(3500.00 AS Decimal(10, 2)), N'Efectivo', 9, NULL)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (2, 2, 3, N'arenales 345', N'54565445', CAST(3000.00 AS Decimal(10, 2)), N'Transferencia', 3, NULL)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (3, 3, 4, N'Arenales 545', N'1122323454', CAST(3500.00 AS Decimal(10, 2)), N'Efectivo', 6, NULL)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (4, 4, 3, N'arenales', N'112312312321332', CAST(3000.00 AS Decimal(10, 2)), N'Efectivo', 7, 4)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (5, 5, 3, N'flores 324', N'112332323232323', CAST(3000.00 AS Decimal(10, 2)), N'Efectivo', 5, 3)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (6, 6, 3, N'flores', N'114324324324324', CAST(3000.00 AS Decimal(10, 2)), N'Efectivo', 0, 1)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (7, 7, 3, N'Schell 559', N'1158546639', CAST(3000.00 AS Decimal(10, 2)), N'Efectivo', 3, 4)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (8, 8, 4, N'Santa Ana 850', N'1154633831', CAST(3500.00 AS Decimal(10, 2)), N'Transferencia', 9, 1)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (9, 9, 3, N'Schell 559', N'1158546639', CAST(3000.00 AS Decimal(10, 2)), N'Efectivo', 7, 2)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (10, 10, 3, N'Belgrano 350', N'1147852369', CAST(3000.00 AS Decimal(10, 2)), N'Transferencia', 5, 1)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (11, 11, 3, N'Av. Mitre 1520', N'1145123987', CAST(3000.00 AS Decimal(10, 2)), N'Transferencia', 4, 2)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (12, 12, 3, N'Schell 559', N'1137566849', CAST(3000.00 AS Decimal(10, 2)), N'Efectivo', 2, 2)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (13, 13, 3, N'Schell 559', N'1137566849', CAST(3000.00 AS Decimal(10, 2)), N'Efectivo', 2, 3)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (14, 14, 4, N'Hipolito Yrigoyen 4300', N'1162457813', CAST(3500.00 AS Decimal(10, 2)), N'Transferencia', 4, 2)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (15, 15, 4, N'Hipolito Yrigoyen 4300', N'1162457813', CAST(3500.00 AS Decimal(10, 2)), N'Efectivo', 8, 3)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (16, 16, 5, N'Las Piedras 334', N'1123212342', CAST(4500.00 AS Decimal(10, 2)), N'Efectivo', 3, 2)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (17, 17, 3, N'Belgrano 350', N'1147852369', CAST(3000.00 AS Decimal(10, 2)), N'Transferencia', 1, 2)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (18, 18, 3, N'Belgrano 350', N'1147852369', CAST(3000.00 AS Decimal(10, 2)), N'Efectivo', 7, 1)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (19, 19, 5, N'Las Piedras 334', N'1123212342', CAST(4500.00 AS Decimal(10, 2)), N'Efectivo', 4, 4)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (20, 20, 3, N'Schell 559', N'1137566849', CAST(3000.00 AS Decimal(10, 2)), N'Transferencia', 4, 4)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (21, 21, 1, N'Arenales 31', N'1176337485', CAST(0.00 AS Decimal(10, 2)), N'Sin costo', 3, 1)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (22, 22, 3, N'Schell 559', N'1158546639', CAST(3000.00 AS Decimal(10, 2)), N'Efectivo', 1, 1)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (23, 23, 4, N'Santa Ana 850', N'1154633831', CAST(3500.00 AS Decimal(10, 2)), N'Efectivo', 8, 1)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (24, 24, 5, N'Las Piedras 334', N'1123212342', CAST(4500.00 AS Decimal(10, 2)), N'Transferencia', 6, 3)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (25, 25, 2, N'Rivadavia 6100', N'1133658741', CAST(0.00 AS Decimal(10, 2)), N'Sin costo', 0, 4)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (26, 26, 3, N'Av. Mitre 1520', N'1145123987', CAST(3000.00 AS Decimal(10, 2)), N'Efectivo', 1, 4)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (27, 27, 5, N'Av. Calchaqui 900', N'1159874123', CAST(4500.00 AS Decimal(10, 2)), N'Efectivo', 9, 2)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (28, 28, 3, N'Belgrano 350', N'1147852369', CAST(3000.00 AS Decimal(10, 2)), N'Efectivo', 4, 4)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (29, 29, 4, N'Hipolito Yrigoyen 4300', N'1162457813', CAST(3500.00 AS Decimal(10, 2)), N'Efectivo', 4, 1)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (30, 30, 3, N'Belgrano 350', N'1147852369', CAST(3000.00 AS Decimal(10, 2)), N'Transferencia', 4, 2)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (31, 31, 3, N'Schell 559', N'1137566849', CAST(3000.00 AS Decimal(10, 2)), N'Efectivo', 9, 4)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (32, 32, 3, N'Av. Mitre 1520', N'1145123987', CAST(3000.00 AS Decimal(10, 2)), N'Transferencia', 6, 1)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (33, 33, 4, N'Santa Ana 850', N'1154633831', CAST(3500.00 AS Decimal(10, 2)), N'Transferencia', 3, 2)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (34, 34, 3, N'Schell 559', N'1137566849', CAST(3000.00 AS Decimal(10, 2)), N'Efectivo', 3, 3)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (35, 35, 4, N'Santa Ana 850', N'1154633831', CAST(3500.00 AS Decimal(10, 2)), N'Efectivo', 9, 2)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (36, 36, 1, N'Medrano 820', N'1128963574', CAST(0.00 AS Decimal(10, 2)), N'Sin costo', 9, 2)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (37, 37, 5, N'Las Piedras 334', N'1123212342', CAST(4500.00 AS Decimal(10, 2)), N'Transferencia', 8, 4)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (38, 38, 3, N'Schell 559', N'1137566849', CAST(3000.00 AS Decimal(10, 2)), N'Efectivo', 8, 2)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (39, 39, 3, N'Schell 559', N'1137566849', CAST(3000.00 AS Decimal(10, 2)), N'Efectivo', 9, 2)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (40, 40, 5, N'Las Piedras 334', N'1123212342', CAST(4500.00 AS Decimal(10, 2)), N'Efectivo', 6, 3)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (41, 41, 3, N'Belgrano 350', N'1147852369', CAST(3000.00 AS Decimal(10, 2)), N'Transferencia', 4, 3)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (42, 42, 5, N'Las Piedras 334', N'1123212342', CAST(4500.00 AS Decimal(10, 2)), N'Transferencia', 3, 4)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (43, 43, 3, N'Av. Mitre 1520', N'1145123987', CAST(3000.00 AS Decimal(10, 2)), N'Efectivo', 1, 1)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (44, 44, 4, N'Santa Ana 850', N'1154633831', CAST(3500.00 AS Decimal(10, 2)), N'Transferencia', 5, 1)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (45, 45, 3, N'Av. Mitre 1520', N'1145123987', CAST(3000.00 AS Decimal(10, 2)), N'Transferencia', 8, 2)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (46, 46, 3, N'Schell 559', N'1137566849', CAST(3000.00 AS Decimal(10, 2)), N'Transferencia', 0, 4)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (47, 47, 4, N'Hipolito Yrigoyen 4300', N'1162457813', CAST(3500.00 AS Decimal(10, 2)), N'Transferencia', 6, 3)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (48, 48, 3, N'Schell 559', N'1158546639', CAST(3000.00 AS Decimal(10, 2)), N'Efectivo', 6, 2)
GO
INSERT [dbo].[Envio] ([IdEnvio], [IdPedido], [IdZona], [Direccion], [Telefono], [CostoEnvio], [MedioPago], [DVH], [IdTransportista]) VALUES (49, 49, 5, N'Av. Calchaqui 900', N'1159874123', CAST(4500.00 AS Decimal(10, 2)), N'Efectivo', 3, NULL)
GO
SET IDENTITY_INSERT [dbo].[Envio] OFF
GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[ZonaCobertura] ADD UNIQUE NONCLUSTERED 
(
	[CodigoPostal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[Producto] ADD  CONSTRAINT [UQ_Producto_Codigo] UNIQUE NONCLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cliente] ADD  CONSTRAINT [UQ_Cliente_DNI] UNIQUE NONCLUSTERED 
(
	[DNI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[Permiso] ADD  CONSTRAINT [UQ_Permiso_Codigo] UNIQUE NONCLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Pedido] ADD UNIQUE NONCLUSTERED 
(
	[IdFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Envio] ADD UNIQUE NONCLUSTERED 
(
	[IdPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DVVertical] ADD  DEFAULT ((0)) FOR [ValorDVV]
GO
ALTER TABLE [dbo].[Producto] ADD  DEFAULT ((0)) FOR [DVH]
GO
ALTER TABLE [dbo].[Cliente] ADD  DEFAULT ((0)) FOR [DVH]
GO
ALTER TABLE [dbo].[Cliente] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[usuarios] ADD  DEFAULT ((0)) FOR [bloqueado]
GO
ALTER TABLE [dbo].[usuarios] ADD  DEFAULT ((0)) FOR [eliminado]
GO
ALTER TABLE [dbo].[usuarios] ADD  DEFAULT ((0)) FOR [DVH]
GO
ALTER TABLE [dbo].[Factura] ADD  DEFAULT ((0)) FOR [DVH]
GO
ALTER TABLE [dbo].[DetalleFactura] ADD  DEFAULT ((0)) FOR [DVH]
GO
ALTER TABLE [dbo].[Pedido] ADD  DEFAULT ((0)) FOR [DVH]
GO
ALTER TABLE [dbo].[Envio] ADD  DEFAULT ((0)) FOR [DVH]
GO
ALTER TABLE [dbo].[UsuarioPermiso]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioPermiso_Permiso] FOREIGN KEY([PermisoId])
REFERENCES [dbo].[Permiso] ([Id])
GO
ALTER TABLE [dbo].[UsuarioPermiso] CHECK CONSTRAINT [FK_UsuarioPermiso_Permiso]
GO
ALTER TABLE [dbo].[UsuarioPermiso]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioPermiso_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[usuarios] ([id_usuario])
GO
ALTER TABLE [dbo].[UsuarioPermiso] CHECK CONSTRAINT [FK_UsuarioPermiso_Usuario]
GO
ALTER TABLE [dbo].[usuarios_C]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_C_usuarios] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuarios] ([id_usuario])
GO
ALTER TABLE [dbo].[usuarios_C] CHECK CONSTRAINT [FK_usuarios_C_usuarios]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Cliente]
GO
ALTER TABLE [dbo].[Traduccion]  WITH CHECK ADD FOREIGN KEY([IdIdioma])
REFERENCES [dbo].[Idioma] ([IdIdioma])
GO
ALTER TABLE [dbo].[PermisoRelacion]  WITH CHECK ADD FOREIGN KEY([HijoId])
REFERENCES [dbo].[Permiso] ([Id])
GO
ALTER TABLE [dbo].[PermisoRelacion]  WITH CHECK ADD FOREIGN KEY([PadreId])
REFERENCES [dbo].[Permiso] ([Id])
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD  CONSTRAINT [FK_DetalleFactura_Factura] FOREIGN KEY([IdFactura])
REFERENCES [dbo].[Factura] ([IdFactura])
GO
ALTER TABLE [dbo].[DetalleFactura] CHECK CONSTRAINT [FK_DetalleFactura_Factura]
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD  CONSTRAINT [FK_DetalleFactura_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[DetalleFactura] CHECK CONSTRAINT [FK_DetalleFactura_Producto]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD FOREIGN KEY([IdFactura])
REFERENCES [dbo].[Factura] ([IdFactura])
GO
ALTER TABLE [dbo].[Envio]  WITH CHECK ADD FOREIGN KEY([IdPedido])
REFERENCES [dbo].[Pedido] ([IdPedido])
GO
ALTER TABLE [dbo].[Envio]  WITH CHECK ADD FOREIGN KEY([IdZona])
REFERENCES [dbo].[ZonaCobertura] ([IdZona])
GO
ALTER TABLE [dbo].[Envio]  WITH CHECK ADD  CONSTRAINT [FK_Envio_Transportista] FOREIGN KEY([IdTransportista])
REFERENCES [dbo].[Transportista] ([IdTransportista])
GO
ALTER TABLE [dbo].[Envio] CHECK CONSTRAINT [FK_Envio_Transportista]
GO
ALTER TABLE [dbo].[PermisoRelacion]  WITH CHECK ADD  CONSTRAINT [CK_PermisoRelacion_Distinto] CHECK  (([PadreId]<>[HijoId]))
GO
ALTER TABLE [dbo].[PermisoRelacion] CHECK CONSTRAINT [CK_PermisoRelacion_Distinto]
GO
CREATE OR ALTER TRIGGER dbo.usuario_actualizado
ON dbo.usuarios
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF TRIGGER_NESTLEVEL(OBJECT_ID('dbo.usuario_c_actualizado')) > 0
        RETURN;

    DECLARE @Usuario NVARCHAR(100) = CONVERT(NVARCHAR(100), SESSION_CONTEXT(N'usuario'));
    IF @Usuario IS NULL
        SET @Usuario = 'sistema';

    DECLARE @Cambiados TABLE (id_usuario INT);

    INSERT INTO @Cambiados (id_usuario)
    SELECT i.id_usuario
    FROM inserted i
    LEFT JOIN deleted d ON d.id_usuario = i.id_usuario
    WHERE d.id_usuario IS NULL
       OR EXISTS (SELECT i.nomUsuario, i.contraseña, i.bloqueado, i.eliminado
                  EXCEPT
                  SELECT d.nomUsuario, d.contraseña, d.bloqueado, d.eliminado);

    UPDATE dbo.usuarios_C
    SET Activo = 0
    WHERE Activo = 1 AND id_usuario IN (SELECT id_usuario FROM @Cambiados);

    INSERT INTO dbo.usuarios_C (id_usuario, nomUsuario, contraseña, bloqueado, eliminado, Fecha, Hora, Usuario, Activo)
    SELECT i.id_usuario, i.nomUsuario, i.contraseña, i.bloqueado, i.eliminado,
           CAST(GETDATE() AS DATE), CAST(GETDATE() AS TIME(0)), @Usuario, 1
    FROM inserted i
    WHERE i.id_usuario IN (SELECT id_usuario FROM @Cambiados);
END
GO

CREATE OR ALTER TRIGGER dbo.usuario_eliminado
ON dbo.usuarios
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.usuarios
    SET eliminado = 1
    WHERE id_usuario IN (SELECT id_usuario FROM deleted);
END
GO

CREATE OR ALTER TRIGGER dbo.usuario_c_actualizado
ON dbo.usuarios_C
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE u
    SET u.nomUsuario = i.nomUsuario,
        u.contraseña = i.contraseña,
        u.bloqueado = i.bloqueado,
        u.eliminado = i.eliminado
    FROM dbo.usuarios u
    INNER JOIN inserted i ON i.id_usuario = u.id_usuario
    INNER JOIN deleted d ON d.IdVersion = i.IdVersion
    WHERE i.Activo = 1 AND d.Activo = 0;
END
GO
SET NOEXEC OFF;
GO
