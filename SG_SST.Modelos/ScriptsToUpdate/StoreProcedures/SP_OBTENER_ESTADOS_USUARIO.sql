CREATE PROCEDURE [dbo].[SP_OBTENER_ESTADOS_USUARIO] 
AS
BEGIN   
   SELECT pk_id_usuarioestados AS IdEstado, ESTADOUSUARIO AS NombreEstado FROM Tbl_UsuarioEstados;
END;