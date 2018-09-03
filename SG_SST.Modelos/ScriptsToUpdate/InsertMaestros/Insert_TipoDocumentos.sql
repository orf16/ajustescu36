USE [SGSST]
GO
delete from Tbl_Tipo_Documento;
DBCC CHECKIDENT ('Tbl_Tipo_Documento', RESEED, 0);
insert into Tbl_Tipo_Documento
values ('CÉDULA DE CIUDADANIA', 'CC', 0, 0);
--insert into Tbl_Tipo_Documento
--values ('CARNET DIPLOMÁTICO', 'CD', 0, 0);
insert into Tbl_Tipo_Documento
values ('NIT', 'NI', 0, 0);
insert into Tbl_Tipo_Documento
values ('CÉDULA DE EXTRANJERÍA', 'CE', 0, 0);
insert into Tbl_Tipo_Documento
values ('NUIP', 'NU', 0, 0);
insert into Tbl_Tipo_Documento
values ('PASAPORTE', 'PA', 0, 0);
--insert into Tbl_Tipo_Documento
--values ('REGISTRO CIVIL', 'RC', 0, 0);
--insert into Tbl_Tipo_Documento
--values ('SALVOCONDUCTO DE PER', 'SC', 0, 0);
insert into Tbl_Tipo_Documento
values ('TARJETA DE IDENTIDAD', 'TI', 0, 0);