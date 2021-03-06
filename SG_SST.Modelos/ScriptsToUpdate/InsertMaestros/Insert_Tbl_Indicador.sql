delete from Tbl_Indicador
DBCC CHECKIDENT (Tbl_Indicador, RESEED, 0)
USE [SGSST]
GO

SET IDENTITY_INSERT [dbo].[Tbl_Indicador] ON 

GO
INSERT [dbo].[Tbl_Indicador] ([PK_Id_Indicador], [Nombre], [Tipo], [Unidad], [Frecuencia]) VALUES (1, N'Indicador de ejecución del plan de trabajo anual en SST', N'Proceso', N'%', N'Mensual')
GO
INSERT [dbo].[Tbl_Indicador] ([PK_Id_Indicador], [Nombre], [Tipo], [Unidad], [Frecuencia]) VALUES (2, N'Indicador de gestión de la mejora continua en el SG de SST', N'Proceso', N'%', N'Semestral')
GO
INSERT [dbo].[Tbl_Indicador] ([PK_Id_Indicador], [Nombre], [Tipo], [Unidad], [Frecuencia]) VALUES (3, N'Indicador de gestión sobre las condiciones y actos inseguros', N'Proceso', N'%', N'Semestral')
GO
INSERT [dbo].[Tbl_Indicador] ([PK_Id_Indicador], [Nombre], [Tipo], [Unidad], [Frecuencia]) VALUES (4, N'Indicador de comité Copasst', N'Estructura', N'?', N'Mensual')
GO
INSERT [dbo].[Tbl_Indicador] ([PK_Id_Indicador], [Nombre], [Tipo], [Unidad], [Frecuencia]) VALUES (5, N'Indicador diagnóstico de condiciones de salud', N'Estructura', N'?', N'Puntual')
GO
INSERT [dbo].[Tbl_Indicador] ([PK_Id_Indicador], [Nombre], [Tipo], [Unidad], [Frecuencia]) VALUES (6, N'Indicador de perfil sociodemográfico', N'Estructura', N'?', N'Puntual')
GO
INSERT [dbo].[Tbl_Indicador] ([PK_Id_Indicador], [Nombre], [Tipo], [Unidad], [Frecuencia]) VALUES (7, N'Indicador de comunicaciones internas', N'Estructura', N'#', N'Mensual')
GO
INSERT [dbo].[Tbl_Indicador] ([PK_Id_Indicador], [Nombre], [Tipo], [Unidad], [Frecuencia]) VALUES (8, N'Indicador de comunicaciones APP', N'Estructura', N'#', N'Mensual')
GO
INSERT [dbo].[Tbl_Indicador] ([PK_Id_Indicador], [Nombre], [Tipo], [Unidad], [Frecuencia]) VALUES (9, N'Severidad de los accidentes laborales', N'Resultado', N'Días/HHT', N'Anual')
GO
INSERT [dbo].[Tbl_Indicador] ([PK_Id_Indicador], [Nombre], [Tipo], [Unidad], [Frecuencia]) VALUES (10, N'Frecuencia de los accidentes laborales', N'Resultado', N'Veces', N'Anual')
GO
INSERT [dbo].[Tbl_Indicador] ([PK_Id_Indicador], [Nombre], [Tipo], [Unidad], [Frecuencia]) VALUES (11, N'Mortalidad de los accidentes laborales', N'Resultado', N'# Accidentes', N'Anual')
GO
INSERT [dbo].[Tbl_Indicador] ([PK_Id_Indicador], [Nombre], [Tipo], [Unidad], [Frecuencia]) VALUES (12, N'Prevalencia de la enfermedad laboral', N'Resultado', N'Casos', N'Anual')
GO
INSERT [dbo].[Tbl_Indicador] ([PK_Id_Indicador], [Nombre], [Tipo], [Unidad], [Frecuencia]) VALUES (13, N'Incidencia de la enfermedad laboral', N'Resultado', N'Casos', N'Anual')
GO
INSERT [dbo].[Tbl_Indicador] ([PK_Id_Indicador], [Nombre], [Tipo], [Unidad], [Frecuencia]) VALUES (14, N'Ausentismo por incapacidad médica', N'Resultado', N'Días', N'Anual')
GO

INSERT [dbo].[Tbl_Indicador] ([PK_Id_Indicador], [Nombre], [Tipo], [Unidad], [Frecuencia]) VALUES (15, N'Tasa accidentalidad', N'Resultado', N'%', N'Mensual')
GO
INSERT [dbo].[Tbl_Indicador] ([PK_Id_Indicador], [Nombre], [Tipo], [Unidad], [Frecuencia]) VALUES (16, N'Cumplimiento programa de capacitación y entrenamiento', N'Resultado', N'%', N'Mensual')
GO
INSERT [dbo].[Tbl_Indicador] ([PK_Id_Indicador], [Nombre], [Tipo], [Unidad], [Frecuencia]) VALUES (17, N'Índice de severidad del ausentismo', N'Resultado', N'#', N'Anual')
GO
INSERT [dbo].[Tbl_Indicador] ([PK_Id_Indicador], [Nombre], [Tipo], [Unidad], [Frecuencia]) VALUES (18, N'Índice de lesiones incapacitantes por A.T', N'Resultado', N'#', N'Anual')
GO
INSERT [dbo].[Tbl_Indicador] ([PK_Id_Indicador], [Nombre], [Tipo], [Unidad], [Frecuencia]) VALUES (19, N'Indicador del cumplimiento de los requisitos legales', N'Resultado', N'%', N'Anual')
GO
INSERT [dbo].[Tbl_Indicador] ([PK_Id_Indicador], [Nombre], [Tipo], [Unidad], [Frecuencia]) VALUES (20, N'Indicador ánalisis vulnerabilidad', N'Resultado', N'?', N'Puntual')
GO
INSERT [dbo].[Tbl_Indicador] ([PK_Id_Indicador], [Nombre], [Tipo], [Unidad], [Frecuencia]) VALUES (21, N'Indicador de identificación y valoración de peligros y riesgos', N'Resultado', N'?', N'Puntual')
GO
INSERT [dbo].[Tbl_Indicador] ([PK_Id_Indicador], [Nombre], [Tipo], [Unidad], [Frecuencia]) VALUES (22, N'Indicador de eficacia de cierre de planes de acción', N'Resultado', N'%', N'Puntual')
GO
SET IDENTITY_INSERT [dbo].[Tbl_Indicador] OFF
GO
