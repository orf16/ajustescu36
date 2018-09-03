DBCC CHECKIDENT (Tbl_CausalesRechazoUsuariosSistema, RESEED, 5)
USE [SGSST]
SET IDENTITY_INSERT [dbo].[Tbl_CausalesRechazoUsuariosSistema] ON 

--INSERT [dbo].[Tbl_CausalesRechazoUsuariosSistema] ([Pk_Id_CausalRechazo], [Nombre], [Descripcion]) VALUES (5, N'Validación de Información', N'Validación de Información')

INSERT [dbo].[Tbl_CausalesRechazoUsuariosSistema] ([Pk_Id_CausalRechazo], [Nombre], [Descripcion]) VALUES (6, N'Formato de autorización errado', N'Formato de autorización errado')

INSERT [dbo].[Tbl_CausalesRechazoUsuariosSistema] ([Pk_Id_CausalRechazo], [Nombre], [Descripcion]) VALUES (7, N'Formato de autorización ilegible.', N'Formato de autorización ilegible')

INSERT [dbo].[Tbl_CausalesRechazoUsuariosSistema] ([Pk_Id_CausalRechazo], [Nombre], [Descripcion]) VALUES (8, N'Formato de autorización incompleto', N'Formato de autorización incompleto')

INSERT [dbo].[Tbl_CausalesRechazoUsuariosSistema] ([Pk_Id_CausalRechazo], [Nombre], [Descripcion]) VALUES (9, N'Formato de autorización sin diligenciar', N'Formato de autorización sin diligenciar')

SET IDENTITY_INSERT [dbo].[Tbl_CausalesRechazoUsuariosSistema] OFF

