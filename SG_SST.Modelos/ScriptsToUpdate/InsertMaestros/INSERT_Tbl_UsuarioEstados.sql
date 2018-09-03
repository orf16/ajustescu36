insert into TBL_USUARIOESTADOS values ('Activo');
insert into TBL_USUARIOESTADOS values ('Suspendido');
insert into TBL_USUARIOESTADOS values ('Bloqueado');
insert into TBL_USUARIOESTADOS values ('Eliminado');

update Tbl_UsuarioSistema
set FK_Id_EstadoUsuario = 1
where Activo = 1;