USE [SICAIE_UB]
GO
/****** Object:  Table [dbo].[tblUB_Usuarios_Tipos]    Script Date: 09/01/2016 10:20:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUB_Usuarios_Tipos](
	[ID_Tipo] [int] NULL,
	[Descripcion] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblUB_Usuarios_Tipos] ([ID_Tipo], [Descripcion]) VALUES (0, N'Administrador')
INSERT [dbo].[tblUB_Usuarios_Tipos] ([ID_Tipo], [Descripcion]) VALUES (1, N'Docente')
INSERT [dbo].[tblUB_Usuarios_Tipos] ([ID_Tipo], [Descripcion]) VALUES (2, N'No docente')
INSERT [dbo].[tblUB_Usuarios_Tipos] ([ID_Tipo], [Descripcion]) VALUES (3, N'Alumno')
INSERT [dbo].[tblUB_Usuarios_Tipos] ([ID_Tipo], [Descripcion]) VALUES (4, N'Ex Alumno')
/****** Object:  Table [dbo].[tblUB_Usuarios_Estados]    Script Date: 09/01/2016 10:20:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUB_Usuarios_Estados](
	[Estado] [int] NULL,
	[Descripcion] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblUB_Usuarios_Estados] ([Estado], [Descripcion]) VALUES (0, N'Inactivo')
INSERT [dbo].[tblUB_Usuarios_Estados] ([Estado], [Descripcion]) VALUES (1, N'Activo')
/****** Object:  Table [dbo].[tblUB_SYSUsuarios]    Script Date: 09/01/2016 10:20:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUB_SYSUsuarios](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[Nombre] [varchar](500) NULL,
	[Clave] [varchar](20) NULL,
	[Perfil] [int] NULL,
	[Facultad] [int] NULL,
	[Email] [varchar](100) NULL,
	[Estado] [int] NULL,
 CONSTRAINT [PK_tblUB_SYSUsuarios] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblUB_RedesSociales]    Script Date: 09/01/2016 10:20:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUB_RedesSociales](
	[ID_RS] [varchar](50) NULL,
	[Nombre] [varchar](100) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblUB_Publicaciones_Tipos]    Script Date: 09/01/2016 10:20:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUB_Publicaciones_Tipos](
	[ID_Tipo] [int] NULL,
	[Descripcion] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblUB_Publicaciones_Tipos] ([ID_Tipo], [Descripcion]) VALUES (1, N'Academica')
INSERT [dbo].[tblUB_Publicaciones_Tipos] ([ID_Tipo], [Descripcion]) VALUES (2, N'Solidaria')
INSERT [dbo].[tblUB_Publicaciones_Tipos] ([ID_Tipo], [Descripcion]) VALUES (3, N'Noticia')
/****** Object:  Table [dbo].[tblUB_Publicaciones_RS_Linker]    Script Date: 09/01/2016 10:20:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUB_Publicaciones_RS_Linker](
	[ID_Linker] [int] IDENTITY(1,1) NOT NULL,
	[ID_RS] [varchar](50) NULL,
	[ID_Publicacion] [varchar](50) NULL,
 CONSTRAINT [PK_tblUB_Publicaciones_RS_Linker] PRIMARY KEY CLUSTERED 
(
	[ID_Linker] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblUB_Publicaciones_Estados]    Script Date: 09/01/2016 10:20:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUB_Publicaciones_Estados](
	[ID_Estado] [int] NULL,
	[Descripcion] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblUB_Publicaciones_Estados] ([ID_Estado], [Descripcion]) VALUES (0, N'Eliminada')
INSERT [dbo].[tblUB_Publicaciones_Estados] ([ID_Estado], [Descripcion]) VALUES (1, N'Pendiente')
INSERT [dbo].[tblUB_Publicaciones_Estados] ([ID_Estado], [Descripcion]) VALUES (2, N'Aprobada')
INSERT [dbo].[tblUB_Publicaciones_Estados] ([ID_Estado], [Descripcion]) VALUES (3, N'Revision')
INSERT [dbo].[tblUB_Publicaciones_Estados] ([ID_Estado], [Descripcion]) VALUES (4, N'Rechazada')
/****** Object:  Table [dbo].[tblUB_Publicaciones]    Script Date: 09/01/2016 10:20:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUB_Publicaciones](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](50) NULL,
	[Texto_Corto] [varchar](500) NULL,
	[Texto_Largo] [varchar](8000) NULL,
	[Foto] [varchar](50) NULL,
	[Tags] [varchar](500) NULL,
	[Orden] [int] NULL,
	[Estado] [int] NULL,
	[Fecha_Alta] [datetime] NULL,
	[Fecha_Modificacion] [datetime] NULL,
	[ID_Creador] [varchar](20) NULL,
	[ID_Modificador] [varchar](20) NULL,
 CONSTRAINT [PK_tblUB_Publicaciones] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblUB_Publicaciones] ON
INSERT [dbo].[tblUB_Publicaciones] ([ID], [Titulo], [Texto_Corto], [Texto_Largo], [Foto], [Tags], [Orden], [Estado], [Fecha_Alta], [Fecha_Modificacion], [ID_Creador], [ID_Modificador]) VALUES (1, N'HOLA MUNDO', N'lala', N'lololo', N'fotitoo', N'tags', 1, 1, CAST(0x0000A673013360FC AS DateTime), CAST(0x0000A673013360FC AS DateTime), N'1001011', N'')
SET IDENTITY_INSERT [dbo].[tblUB_Publicaciones] OFF
/****** Object:  Table [dbo].[tblUB_Perfiles]    Script Date: 09/01/2016 10:20:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUB_Perfiles](
	[Perfil] [int] NOT NULL,
	[Descripcion] [varchar](100) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblUB_Facultades]    Script Date: 09/01/2016 10:20:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUB_Facultades](
	[Codigo_Secretaria] [int] NULL,
	[Nombre_Secretaria] [varchar](200) NULL,
	[Codigo_Facultad] [int] NULL,
	[Nombre_Facultad] [varchar](200) NULL,
	[ID] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[SP_UB_SYSUsuarios_Alta]    Script Date: 09/01/2016 10:20:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_UB_SYSUsuarios_Alta]
@Usuario varchar(50),
@Nombre varchar(500),
@Clave  varchar(20),
@Perfil int,
@Facultad int,
@Email varchar(100)

as

begin
INSERT INTO tblUB_SYSUsuarios
           ([Usuario]   
           ,[Nombre] 
           ,[Clave]             
           ,[Perfil] 
           ,[Facultad] 
           ,[Email] 
           ,[Estado] 
           )
          
     VALUES
           (@Usuario 
           ,@Nombre 
           ,@Clave 
           ,@Perfil 
           ,@Facultad 
           ,@Email 
           ,1 --Usuario activo
           )
          
            
select 'OK',@@IDENTITY

end
GO
/****** Object:  StoredProcedure [dbo].[SP_UB_Publicaciones_RS_Linker_Alta]    Script Date: 09/01/2016 10:20:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_UB_Publicaciones_RS_Linker_Alta]
@ID_RS varchar(50),
@ID_Publicacion varchar(50)
as

begin
INSERT INTO tblUB_Publicaciones_RS_Linker 
           ([ID_Publicacion]  
           ,[ID_RS]            
           )
          
     VALUES
           (@ID_Publicacion 
           ,@ID_RS 
           )
          
            
select 'OK',@@IDENTITY

end
GO
/****** Object:  StoredProcedure [dbo].[SP_UB_Publicaciones_Baja]    Script Date: 09/01/2016 10:20:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_UB_Publicaciones_Baja]
@ID_Publicacion int,
@ID_Modificador varchar(50)

as

begin
update tblUB_Publicaciones   set Estado=0,ID_Modificador=@ID_Modificador ,Fecha_Modificacion =GETDATE()  where ID  =@ID_Publicacion 

            
select 'OK'

end
GO
/****** Object:  StoredProcedure [dbo].[SP_UB_Publicaciones_Alta]    Script Date: 09/01/2016 10:20:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_UB_Publicaciones_Alta]

@Titulo varchar(50),
@Texto_Corto varchar(500),
@Texto_Largo varchar(8000),
@Foto varchar(1000),
@Tags varchar(2000),
@Orden int,
@ID_Creador  varchar(20)

as

begin
INSERT INTO tblUB_Publicaciones
           ([Titulo] 
           ,[Texto_Corto] 
           ,[Texto_Largo] 
           ,[Foto] 
           ,[Tags] 
           ,[Orden] 
           ,[Estado] 
           ,[Fecha_Alta]
           ,[Fecha_Modificacion] 
           ,[ID_Creador] 
           ,[ID_Modificador]     
           )
          
     VALUES
           (@Titulo
           ,@Texto_Corto
           ,@Texto_Largo
           ,@Foto
           ,@Tags
           ,@Orden
           ,1 --Estado pendiente 
           ,GETDATE()--fecha actual
           ,GETDATE ()
           ,@ID_Creador
           ,'' --todavia no la modifico nadie , se pone vacio o el id del creador
           )
          
            
select 'OK',@@IDENTITY

end
GO
