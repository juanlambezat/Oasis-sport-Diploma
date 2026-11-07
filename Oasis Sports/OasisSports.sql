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
SET IDENTITY_INSERT [dbo].[Permiso] OFF
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
INSERT [dbo].[DVVertical] ([Tabla], [ValorDVV]) VALUES (N'Cliente', 0)
GO
INSERT [dbo].[DVVertical] ([Tabla], [ValorDVV]) VALUES (N'DetalleFactura', 0)
GO
INSERT [dbo].[DVVertical] ([Tabla], [ValorDVV]) VALUES (N'Envio', 0)
GO
INSERT [dbo].[DVVertical] ([Tabla], [ValorDVV]) VALUES (N'Factura', 0)
GO
INSERT [dbo].[DVVertical] ([Tabla], [ValorDVV]) VALUES (N'Pedido', 0)
GO
INSERT [dbo].[DVVertical] ([Tabla], [ValorDVV]) VALUES (N'Producto', 5)
GO
INSERT [dbo].[DVVertical] ([Tabla], [ValorDVV]) VALUES (N'Usuarios', 6)
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
INSERT [dbo].[UsuarioPermiso] ([UsuarioId], [PermisoId]) VALUES (9, 24)
GO
INSERT [dbo].[UsuarioPermiso] ([UsuarioId], [PermisoId]) VALUES (11, 24)
GO
INSERT [dbo].[UsuarioPermiso] ([UsuarioId], [PermisoId]) VALUES (1015, 12)
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
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[Permiso] ADD  CONSTRAINT [UQ_Permiso_Codigo] UNIQUE NONCLUSTERED 
(
	[Codigo] ASC
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
ALTER TABLE [dbo].[ZonaCobertura] ADD UNIQUE NONCLUSTERED 
(
	[CodigoPostal] ASC
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
ALTER TABLE [dbo].[Producto] ADD  DEFAULT ((0)) FOR [DVH]
GO
ALTER TABLE [dbo].[Cliente] ADD  DEFAULT ((0)) FOR [DVH]
GO
ALTER TABLE [dbo].[Cliente] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[DVVertical] ADD  DEFAULT ((0)) FOR [ValorDVV]
GO
ALTER TABLE [dbo].[usuarios] ADD  DEFAULT ((0)) FOR [bloqueado]
GO
ALTER TABLE [dbo].[usuarios] ADD  DEFAULT ((0)) FOR [eliminado]
GO
ALTER TABLE [dbo].[usuarios] ADD  DEFAULT ((0)) FOR [DVH]
GO
ALTER TABLE [dbo].[Factura] ADD  DEFAULT ((0)) FOR [DVH]
GO
ALTER TABLE [dbo].[Pedido] ADD  DEFAULT ((0)) FOR [DVH]
GO
ALTER TABLE [dbo].[DetalleFactura] ADD  DEFAULT ((0)) FOR [DVH]
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
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD FOREIGN KEY([IdFactura])
REFERENCES [dbo].[Factura] ([IdFactura])
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
SET NOEXEC OFF;
GO
