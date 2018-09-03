CREATE Procedure [dbo].[SP_Cargos_Comunicaciones]

@nitEmpresa nvarchar(50)   
as
SELECT     DISTINCT  NitEmpresa, 
PK_Id_Comunicado,

	SUBSTRING(DESTINATARIOS,0,patindex('%,%', Destinatarios)) as cargo,
	CASE WHEN 	ltrim(rtrim(
	
	SUBSTRING(ltrim(rtrim(
	
	SUBSTRING(DESTINATARIOS,charindex(',',DESTINATARIOS,1)+1,len(SUBSTRING(SUBSTRING(DESTINATARIOS,0,patindex('%,%', Destinatarios)),0,patindex('%,%', Destinatarios))))))
	
	,1,charindex(',',DESTINATARIOS,1)-1)))<>'' THEN 
	
	ltrim(rtrim(
	
	SUBSTRING(ltrim(rtrim(
	
	SUBSTRING(DESTINATARIOS,charindex(',',DESTINATARIOS,1)+1,len(SUBSTRING(SUBSTRING(DESTINATARIOS,0,patindex('%,%', Destinatarios)),0,patindex('%,%', Destinatarios))))))
	
	,1,charindex(',',DESTINATARIOS,1)-1))) end as cargo2,

	ltrim(rtrim(SUBSTRING(DESTINATARIOS,charindex(',',DESTINATARIOS,1)+1,len(DESTINATARIOS))))  as cargo3,
ltrim(rtrim(SUBSTRING(ltrim(rtrim(SUBSTRING(DESTINATARIOS,charindex(',',DESTINATARIOS,1)+1,len(DESTINATARIOS)))),charindex('-',ltrim(rtrim(SUBSTRING(DESTINATARIOS,charindex(',',DESTINATARIOS,1)+1,len(DESTINATARIOS)))),1)+1,len(ltrim(rtrim(SUBSTRING(DESTINATARIOS,charindex(',',DESTINATARIOS,1)+1,len(DESTINATARIOS)))))))) as cargo4,
	
Destinatarios
                         
FROM            dbo.Tbl_ComunicacionesExternas 

WHERE 

--DESTINATARIOS not like '%@%' AND

 --SUBSTRING(DESTINATARIOS,0,patindex('%-%', Destinatarios))<>'C' and
SUBSTRING(DESTINATARIOS,0,patindex('%-%', Destinatarios))<>'N/A' and 
SUBSTRING(DESTINATARIOS,0,patindex('%,%', Destinatarios)) not in (


SELECT        dbo.Tbl_GruposComunicaciones.NombreGrupo
FROM            dbo.Tbl_GrupoUsuariosComunicaciones INNER JOIN
                         dbo.Tbl_GruposComunicaciones ON dbo.Tbl_GrupoUsuariosComunicaciones.fk_id_grupo_comunicaciones = dbo.Tbl_GruposComunicaciones.pk_id_grupo





where NitEmpresa=nitEmpresa

)


GO

