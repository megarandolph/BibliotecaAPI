USE [master]
GO
/****** Object:  Database [biblioteca]    Script Date: 10/9/2024 1:46:19 PM ******/
CREATE DATABASE [biblioteca]
GO
USE [biblioteca]
GO
/****** Object:  Table [dbo].[Autor]    Script Date: 10/9/2024 1:46:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autor](
	[AutorId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[AutorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 10/9/2024 1:46:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[CategoriaId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoriaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libro]    Script Date: 10/9/2024 1:46:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libro](
	[LibroId] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](200) NULL,
	[Descripcion] [varchar](max) NULL,
	[Fecha_publicacion] [datetime] NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[LibroId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LibroAutor]    Script Date: 10/9/2024 1:46:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LibroAutor](
	[LibroAutorId] [int] IDENTITY(1,1) NOT NULL,
	[LibroId] [int] NULL,
	[AutorId] [int] NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[LibroAutorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LibroCategoria]    Script Date: 10/9/2024 1:46:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LibroCategoria](
	[LibroCategoriaId] [int] IDENTITY(1,1) NOT NULL,
	[LibroId] [int] NULL,
	[CategoriaId] [int] NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[LibroCategoriaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 10/9/2024 1:46:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[UsuarioId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](200) NULL,
	[RolId] [int] NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Autor] ON 
GO
INSERT [dbo].[Autor] ([AutorId], [Nombre], [Status]) VALUES (1, N'Gabriel Garcia Marquez', 1)
GO
INSERT [dbo].[Autor] ([AutorId], [Nombre], [Status]) VALUES (2, N'Pedro Sosa', 1)
GO
INSERT [dbo].[Autor] ([AutorId], [Nombre], [Status]) VALUES (3, N'Manuel Medrano', 1)
GO
INSERT [dbo].[Autor] ([AutorId], [Nombre], [Status]) VALUES (4, N'Juan Perez', 1)
GO
SET IDENTITY_INSERT [dbo].[Autor] OFF
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 
GO
INSERT [dbo].[Categoria] ([CategoriaId], [Nombre], [Status]) VALUES (1, N'Fantasia', 1)
GO
INSERT [dbo].[Categoria] ([CategoriaId], [Nombre], [Status]) VALUES (2, N'Horror', 1)
GO
INSERT [dbo].[Categoria] ([CategoriaId], [Nombre], [Status]) VALUES (3, N'Ciencia', 1)
GO
INSERT [dbo].[Categoria] ([CategoriaId], [Nombre], [Status]) VALUES (4, N'Historia', 1)
GO
INSERT [dbo].[Categoria] ([CategoriaId], [Nombre], [Status]) VALUES (5, N'Geografia', 1)
GO
INSERT [dbo].[Categoria] ([CategoriaId], [Nombre], [Status]) VALUES (6, N'Accion', 1)
GO
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Libro] ON 
GO
INSERT [dbo].[Libro] ([LibroId], [Titulo], [Descripcion], [Fecha_publicacion], [Status]) VALUES (1, N'El mejor de 2', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur ex ligula, cursus nec blandit eu, lobortis vitae velit. Donec convallis convallis libero, a fringilla turpis mollis id. Suspendisse accumsan nisi et sapien vulputate imperdiet. Maecenas in aliquet augue. Ut bibendum sed libero a laoreet. Sed a condimentum ligula, a ultricies arcu. Donec a tincidunt nisi. Nam in nibh eleifend, vestibulum felis ut, euismod mi.', CAST(N'2000-05-01T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Libro] ([LibroId], [Titulo], [Descripcion], [Fecha_publicacion], [Status]) VALUES (2, N'Una tarde soleada', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur ex ligula, cursus nec blandit eu, lobortis vitae velit. Donec convallis convallis libero, a fringilla turpis mollis id. Suspendisse accumsan nisi et sapien vulputate imperdiet. Maecenas in aliquet augue. Ut bibendum sed libero a laoreet. Sed a condimentum ligula, a ultricies arcu. Donec a tincidunt nisi. Nam in nibh eleifend, vestibulum felis ut, euismod mi.', CAST(N'2022-01-01T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Libro] ([LibroId], [Titulo], [Descripcion], [Fecha_publicacion], [Status]) VALUES (3, N'El coronel no tiene quien le escriba', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur ex ligula, cursus nec blandit eu, lobortis vitae velit. Donec convallis convallis libero, a fringilla turpis mollis id. Suspendisse accumsan nisi et sapien vulputate imperdiet. Maecenas in aliquet augue. Ut bibendum sed libero a laoreet. Sed a condimentum ligula, a ultricies arcu. Donec a tincidunt nisi. Nam in nibh eleifend, vestibulum felis ut, euismod mi.', CAST(N'1995-12-02T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Libro] ([LibroId], [Titulo], [Descripcion], [Fecha_publicacion], [Status]) VALUES (4, N'La llorona', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur ex ligula, cursus nec blandit eu, lobortis vitae velit. Donec convallis convallis libero, a fringilla turpis mollis id. Suspendisse accumsan nisi et sapien vulputate imperdiet. Maecenas in aliquet augue. Ut bibendum sed libero a laoreet. Sed a condimentum ligula, a ultricies arcu. Donec a tincidunt nisi. Nam in nibh eleifend, vestibulum felis ut, euismod mi.', CAST(N'1980-01-05T00:00:00.000' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Libro] OFF
GO
SET IDENTITY_INSERT [dbo].[LibroAutor] ON 
GO
INSERT [dbo].[LibroAutor] ([LibroAutorId], [LibroId], [AutorId], [Status]) VALUES (3, 3, 4, 1)
GO
INSERT [dbo].[LibroAutor] ([LibroAutorId], [LibroId], [AutorId], [Status]) VALUES (4, 4, 4, 1)
GO
INSERT [dbo].[LibroAutor] ([LibroAutorId], [LibroId], [AutorId], [Status]) VALUES (5, 4, 3, 1)
GO
INSERT [dbo].[LibroAutor] ([LibroAutorId], [LibroId], [AutorId], [Status]) VALUES (6, 1, 2, 1)
GO
INSERT [dbo].[LibroAutor] ([LibroAutorId], [LibroId], [AutorId], [Status]) VALUES (7, 2, 3, 1)
GO
INSERT [dbo].[LibroAutor] ([LibroAutorId], [LibroId], [AutorId], [Status]) VALUES (8, 3, 3, 1)
GO
SET IDENTITY_INSERT [dbo].[LibroAutor] OFF
GO
SET IDENTITY_INSERT [dbo].[LibroCategoria] ON 
GO
INSERT [dbo].[LibroCategoria] ([LibroCategoriaId], [LibroId], [CategoriaId], [Status]) VALUES (1, 1, 2, 0)
GO
INSERT [dbo].[LibroCategoria] ([LibroCategoriaId], [LibroId], [CategoriaId], [Status]) VALUES (2, 2, 2, 0)
GO
INSERT [dbo].[LibroCategoria] ([LibroCategoriaId], [LibroId], [CategoriaId], [Status]) VALUES (3, 3, 2, 1)
GO
INSERT [dbo].[LibroCategoria] ([LibroCategoriaId], [LibroId], [CategoriaId], [Status]) VALUES (4, 3, 4, 1)
GO
INSERT [dbo].[LibroCategoria] ([LibroCategoriaId], [LibroId], [CategoriaId], [Status]) VALUES (5, 3, 5, 1)
GO
INSERT [dbo].[LibroCategoria] ([LibroCategoriaId], [LibroId], [CategoriaId], [Status]) VALUES (6, 4, 2, 1)
GO
INSERT [dbo].[LibroCategoria] ([LibroCategoriaId], [LibroId], [CategoriaId], [Status]) VALUES (7, 4, 4, 1)
GO
INSERT [dbo].[LibroCategoria] ([LibroCategoriaId], [LibroId], [CategoriaId], [Status]) VALUES (8, 4, 5, 1)
GO
INSERT [dbo].[LibroCategoria] ([LibroCategoriaId], [LibroId], [CategoriaId], [Status]) VALUES (9, 1, 6, 1)
GO
INSERT [dbo].[LibroCategoria] ([LibroCategoriaId], [LibroId], [CategoriaId], [Status]) VALUES (10, 1, 1, 1)
GO
INSERT [dbo].[LibroCategoria] ([LibroCategoriaId], [LibroId], [CategoriaId], [Status]) VALUES (11, 2, 4, 1)
GO
INSERT [dbo].[LibroCategoria] ([LibroCategoriaId], [LibroId], [CategoriaId], [Status]) VALUES (12, 2, 3, 1)
GO
SET IDENTITY_INSERT [dbo].[LibroCategoria] OFF
GO
SET IDENTITY_INSERT [dbo].[usuario] ON 
GO
INSERT [dbo].[usuario] ([UsuarioId], [Email], [RolId], [Status]) VALUES (1, N'administrador@biblioteca.com', 2, 1)
GO
INSERT [dbo].[usuario] ([UsuarioId], [Email], [RolId], [Status]) VALUES (2, N'bibliotecario@biblioteca.com', 1, 1)
GO
SET IDENTITY_INSERT [dbo].[usuario] OFF
GO
ALTER TABLE [dbo].[LibroAutor]  WITH CHECK ADD FOREIGN KEY([AutorId])
REFERENCES [dbo].[Autor] ([AutorId])
GO
ALTER TABLE [dbo].[LibroAutor]  WITH CHECK ADD FOREIGN KEY([LibroId])
REFERENCES [dbo].[Libro] ([LibroId])
GO
ALTER TABLE [dbo].[LibroCategoria]  WITH CHECK ADD FOREIGN KEY([CategoriaId])
REFERENCES [dbo].[Categoria] ([CategoriaId])
GO
ALTER TABLE [dbo].[LibroCategoria]  WITH CHECK ADD FOREIGN KEY([LibroId])
REFERENCES [dbo].[Libro] ([LibroId])

