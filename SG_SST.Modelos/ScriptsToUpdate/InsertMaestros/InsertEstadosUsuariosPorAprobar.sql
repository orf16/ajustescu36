DBCC CHECKIDENT (Tbl_UsuarioEstados, RESEED, 4)
insert into Tbl_UsuarioEstados values ('Rechazado');
insert into Tbl_UsuarioEstados values ('Pendiente');

update Tbl_UsuariosParaAprobar
set FK_Id_EstadoUsuario = 6
from Tbl_UsuariosParaAprobar ua
left join Tbl_UsuariosRechazadosSitema ur on ua.Pk_id_UsuarioParaAprobar = ur.Fk_Id_UsuarioParaActivar
where ur.Pk_Id_UsuarioRechazadoSistema is null;

update Tbl_UsuariosParaAprobar
set FK_Id_EstadoUsuario = 5
from Tbl_UsuariosParaAprobar ua
left join Tbl_UsuariosRechazadosSitema ur on ua.Pk_id_UsuarioParaAprobar = ur.Fk_Id_UsuarioParaActivar
where ur.Pk_Id_UsuarioRechazadoSistema is not null;
