DBCC CHECKIDENT (Tbl_Contingencias, RESEED, 12)

USE [SGSST]
GO
SET IDENTITY_INSERT [dbo].[Tbl_Contingencias] ON 

GO
INSERT [dbo].[Tbl_Contingencias] ([PK_Id_Contingencia], [Detalle], [Fecha_Ingreso], [Fecha_Modificacion], [FK_Tipo_Contingencia]) VALUES (13, N'Licencia de Maternidad Parto Múltiple', CAST(N'2017-03-15 16:57:20.203' AS DateTime), CAST(N'2017-03-15 16:57:20.203' AS DateTime), 2)
GO
INSERT [dbo].[Tbl_Contingencias] ([PK_Id_Contingencia], [Detalle], [Fecha_Ingreso], [Fecha_Modificacion], [FK_Tipo_Contingencia]) VALUES (14, N'Licencia de Maternidad Nacimiento Prematuro', CAST(N'2017-03-15 16:57:20.203' AS DateTime), CAST(N'2017-03-15 16:57:20.203' AS DateTime), 2)
GO
SET IDENTITY_INSERT [dbo].[Tbl_Contingencias] OFF
GO
