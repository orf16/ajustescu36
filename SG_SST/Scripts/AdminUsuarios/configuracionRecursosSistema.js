var urlBase = utils.getBaseUrl();
var urlUsuario = '/AdminUsuarios';

$(document).ready(function () {

    //se cargan las empresas para el autocomplete
    $("#EmpresaSeleccionada").autocomplete({
        minLength: 3,
        source: function (request, response) {
            $.ajax({
                url: urlBase + urlUsuario + "/AutoCompletarEmpresas",
                type: "POST",
                dataType: "json",
                data: { prefijo: request.term },
            }).done(function (data) {
                $("#IdEmpresaSeleccionada").val(0);
                $("#NitEmpresa").val('');
                response($.map(data, function (item) {
                    return { label: item.Razon_Social, value: item.Id_Empresa, text: item.Nit_Empresa };
                }))
            })
        },
        focus: function (event, ui) {
            $("#NitEmpresa").val('');
            event.preventDefault();
            $(this).val(ui.item.Id_Empresa);
        },
        select: function (event, ui) {
            event.preventDefault();
            $(this).val(ui.item.label);
            $("#IdEmpresaSeleccionada").val(ui.item.value);
            $("#NitEmpresa").val(ui.item.text);
            $('#errorempresa').hide();
        }
    });
    //logica para cargar los recursos del sistema
    $('#btnBuscarRecursos').on('click', function () {
        var rolSistemaEscogido = $('#Roles_del_sistema :selected').val();
        var idEmpresa = $('#IdEmpresaSeleccionada').val();
        if (rolSistemaEscogido.length > 0 && idEmpresa > 0) {
            PopupPosition();
            $.ajax({
                url: urlBase + urlUsuario + '/ObtenerRecursosSistemaParaAccesos',
                data: { 'codRol': rolSistemaEscogido, 'codEmpresa': idEmpresa },
                type: 'post'
            }).done(function (response) {
                if (response != '' && response.Status == 'OK') {
                    $('#recursos_sx').html('');
                    $('#recursos_sx').html(response.Data);
                } else {
                    swal({
                        title: 'Atención',
                        text: response.Data,
                        type: 'warnig',
                        confirmButtonColor: "#7E8A97",
                        confirmButtonText: "OK",
                        closeOnConfirm: false,
                        closeOnCancel: false,
                        html: true
                    }, function () {
                        window.location.href = '../Home/Index';
                    });
                }
                OcultarPopupposition();
            }).faild(function (response) {
                swal({
                    title: 'Atención',
                    text: 'Ocurrió un error el proceso. Intente nuevamente.',
                    type: 'warnig',
                    confirmButtonColor: "#7E8A97",
                    confirmButtonText: "OK",
                    closeOnConfirm: false,
                    closeOnCancel: false,
                    html: true
                }, function () {
                    window.location.href = '../Home/Index';
                });
                OcultarPopupposition();
            });
        } else {
            swal({
                title: 'Atención',
                text: 'Debe seleccionar un Rol y una Empresa para poder continuar.',
                type: 'warning',
                confirmButtonColor: "#7E8A97",
                confirmButtonText: "OK",
                closeOnConfirm: false,
                closeOnCancel: false
            });
            return false;
        }
    });
    //logica de guardado
    $('#btnGuardarConfRecSx').on('click', function () {
        var rolSistemaEscogido = $('#Roles_del_sistema :selected').val();
        var idEmpresa = $('#IdEmpresaSeleccionada').val();
        if (rolSistemaEscogido.length > 0 && idEmpresa > 0) {
            var arrayObjectos = new Array();
            $('#containerRecSx').find('input[type="checkbox"]').each(function (index, value) {
                if (!$(this).is(':checked')) {
                    var objRecursoSx = new Object();
                    objRecursoSx.IdRecursoSistema = $(this).data('id');
                    objRecursoSx.CodRecursoSistemaPadre = $(this).data('idpadre');
                    objRecursoSx.Activo = $(this).prop('checked');
                    arrayObjectos.push(objRecursoSx);
                }
            });
            PopupPosition();
            $.ajax({
                url: urlBase + urlUsuario + '/ConfigurarRecursosSistema',
                data: { 'recursosConf': arrayObjectos, 'codRolSistema': rolSistemaEscogido, 'codEmpresa': idEmpresa },
                type: 'post'
            }).done(function (response) {
                if (response != '' && response.Status == 'OK') {
                    swal({
                        title: 'Atención',
                        text: response.Data,
                        type: 'success',
                        confirmButtonColor: "#7E8A97",
                        confirmButtonText: "OK",
                        closeOnConfirm: false,
                        closeOnCancel: false,
                        html: true
                    }, function () {
                        window.location.href = '../Home/Index';
                    });
                } else {
                    swal({
                        title: 'Atención',
                        text: response.Data,
                        type: 'warnig',
                        confirmButtonColor: "#7E8A97",
                        confirmButtonText: "OK",
                        closeOnConfirm: false,
                        closeOnCancel: false,
                        html: true
                    }, function () {
                        window.location.href = '../Home/Index';
                    });
                }
                OcultarPopupposition();
            }).faild(function (response) {
                swal({
                    title: 'Atención',
                    text: 'Ocurrió un error el proceso. Intente nuevamente.',
                    type: 'warnig',
                    confirmButtonColor: "#7E8A97",
                    confirmButtonText: "OK",
                    closeOnConfirm: false,
                    closeOnCancel: false,
                    html: true
                }, function () {
                    window.location.href = '../Home/Index';
                });
                OcultarPopupposition();
            });
        } else {
            swal({
                title: 'Atención',
                text: 'Debe seleccionar un Rol y una Empresa para poder continuar.',
                type: 'warning',
                confirmButtonColor: "#7E8A97",
                confirmButtonText: "OK",
                closeOnConfirm: false,
                closeOnCancel: false
            });
            return false;
        }
    });

    //recursos denegados por rol por defecto

    $('#idRecursosDefault').click(function () {
        var form_data = new FormData();
        var filedata = $("#file").prop("files")[0];
        if (filedata != undefined)
            form_data.append("cargarArchivo", filedata);
        else {
            swal({
                type: 'warning',
                title: 'Estimado usuario:',
                text: 'Debe seleccionar un archivo',

                confirmButtonColor: '#7E8A97'
            });
            return
        }
        PopupPosition();

        $.ajax({
            type: "POST",
            data: form_data,
            url: urlBase + urlUsuario + '/CargarExcelRecursosDefault',
            processData: false,
            dataType: 'json',
            contentType: false
        }).done(function (response) {
            if (response != undefined && response.Mensaje == 'Success') {
                swal({
                    type: 'success',
                    title: 'Estimado usuario:',
                    text: response.Data,

                    confirmButtonColor: '#7E8A97'
                });
                OcultarPopupposition();
                $("#listadoCargue").show();
            }
            else if (response != undefined && response.Mensaje == 'ERROR') {
                swal({
                    type: 'warning',
                    title: 'Estimado usuario:',
                    text: response.Data,

                    confirmButtonColor: '#7E8A97'
                });
                OcultarPopupposition();
            }
            else if (response != undefined && response.Mensaje == 'CONEXION') {
                swal("Estimado Usuario",
                      response.Data,
                      'warning');


                swal({
                    type: 'warning',
                    title: 'Estimado usuario:',
                    text: response.Data,

                    confirmButtonColor: '#7E8A97'
                });
                OcultarPopupposition();
            }
        }).fail(function (response) {
            $("#Documento").val('');
            swal("Estimado Usuario",
                "No se logró obtener los datos. Intente más tarde.",
                'warning');
            OcultarPopupposition();
        });
    });
});
