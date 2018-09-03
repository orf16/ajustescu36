CREATE PROCEDURE InactivarUsuariosSistema 
AS
BEGIN
	update Tbl_UsuarioSistema
	set PrimerAcceso = 1
	where cast(PeriodoInactivacionCuenta as date) = cast(getdate() as Date)
END