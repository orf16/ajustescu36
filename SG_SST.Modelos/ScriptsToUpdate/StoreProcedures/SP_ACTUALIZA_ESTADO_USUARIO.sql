CREATE PROCEDURE [dbo].[SP_ACTUALIZA_ESTADO_USUARIO](@idEstado INT, @IdUsuario INT) 
AS
BEGIN   
   if(@idEstado = 1)
   begin
	UPDATE Tbl_UsuarioSistema SET FK_Id_EstadoUsuario = @idEstado, Activo = 1 WHERE Pk_Id_UsuarioSistema = @IdUsuario;
   end
   else
   begin
	UPDATE Tbl_UsuarioSistema SET FK_Id_EstadoUsuario = @idEstado, Activo = 0 WHERE Pk_Id_UsuarioSistema = @IdUsuario;
   end
   
END;