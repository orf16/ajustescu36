var urlBase = utils.getBaseUrl();
var urlUsuario = '/AdminUsuarios';
$(document).ready(function () {
    $('#emp_asesorSST').hide();
    $('#container_recursos').find('ul').hide();
    //configuracion inicial
    $('a[data-link="pn"]').find('span').attr('class', 'glyphicon glyphicon-plus');
    $('a[data-link="pn"]').siblings('ul').find('li').hide();
    //manejo de check para el primer nivel
    $('input[data-tipo="pn"]').on('change', function (evt) {
        evt.preventDefault();
        if ($(this).is(':checked')) {
            $(this).parent().find('input[type="checkbox"]').each(function (index, value) {
                $(this).prop('checked', true);
            });
        } else {
            $(this).parent().find('input[type="checkbox"]').each(function (index, value) {
                $(this).prop('checked', false);
            });
        }
    });
    $('a[data-link="pn"]').on('click', function (evt) {
        var clase = $(this).find('span').attr('class');
        if (clase == 'glyphicon glyphicon-minus') {
            $(this).find('span').removeClass('glyphicon glyphicon-minus');
            $(this).find('span').addClass('glyphicon glyphicon-plus');
            $(this).siblings('ul').find('li').hide();
        } else if (clase == 'glyphicon glyphicon-plus') {
            $(this).find('span').removeClass('glyphicon glyphicon-plus');
            $(this).find('span').addClass('glyphicon glyphicon-minus');
            $(this).siblings('ul').find('li').show();
        }
    });
    //manejo de check para el segundo nivel
    $('input[data-tipo="sn"]').on('change', function (evt) {
        evt.preventDefault();
        if ($(this).is(':checked')) {
            $(this).parent().find('input[type="checkbox"]').each(function (index, value) {
                $(this).prop('checked', true);
            });
        } else {
            $(this).parent().find('input[type="checkbox"]').each(function (index, value) {
                $(this).prop('checked', false);
            });
        }
    });
    $('a[data-link="sn"]').on('click', function (evt) {
        var clase = $(this).find('span').attr('class');
        if (clase == 'glyphicon glyphicon-minus') {
            $(this).find('span').removeClass('glyphicon glyphicon-minus');
            $(this).find('span').addClass('glyphicon glyphicon-plus');
            $(this).siblings('ul').find('li').hide();
        } else if (clase == 'glyphicon glyphicon-plus') {
            $(this).find('span').removeClass('glyphicon glyphicon-plus');
            $(this).find('span').addClass('glyphicon glyphicon-minus');
            $(this).siblings('ul').find('li').show();
        }
    });
    //se obtienen las empresas asociadas al usuario
    $('#busarAsesorSST').on('click', function () {
        $('.titulo_rec').css('display', 'none');
        $('#recursos_sx').html('');
        var numDocumento = $('#NumDocumentoAsesorSST').val();
        if (numDocumento != '') {
            PopupPosition();
            $.ajax({
                url: urlBase + urlUsuario + '/BuscarUsuarioAsesorSST',
                type: 'post',
                data: { 'numDocumento': numDocumento },
            }).done(function (response) {
                if (response != '' && response.Status == 200) {
                    //var empresas = response.Data.EmpresasAsesorSST;
                    if (response.CantidadEmpresas > 0) {
                        $('#emp_asesorSST').html('');
                        $('#emp_asesorSST').html(response.Data);
                        //$.each(empresas, function (i, v) {
                        //    $('#emp_asesorSST').append('<li><input id="' + v.Value + '" type="radio" name="radio_emp" data-radio="radio_emp"/>&nbsp;&nbsp;<label>' + v.Text + '</label></li>');
                        //});
                        $('#emp_asesorSST').show();
                        $('#container_recursos').find('ul').show();
                    } else {
                        $('#emp_asesorSST').hide();
                        $('#container_recursos').find('ul').hide();
                        swal({
                            title: 'Atención',
                            text: 'No se encontró información asociada al documento ingresado.',
                            type: 'info',
                            confirmButtonColor: "#7E8A97",
                            confirmButtonText: "OK",
                            closeOnConfirm: false,
                            closeOnCancel: false
                        });
                    }
                } else if (response != '' && response.Status == 501) {
                    swal({
                        title: 'Atención',
                        text: response.Mensaje,
                        type: 'error',
                        confirmButtonText: "Aceptar",
                        closeOnConfirm: false,
                        closeOnCancel: false,
                        html: true
                    }, function () {
                        window.location.href = '../Home/Index';
                    });
                    console.log(response.Mensaje);
                }
                OcultarPopupposition();
            }).fail(function (response) {
                console.log(response);
                OcultarPopupposition();
            });
        } else {
            swal({
                title: 'Atención',
                text: 'Debe ingresar un número de documento válido.',
                type: 'warning',
                confirmButtonColor: "#7E8A97",
                confirmButtonText: "OK",
                closeOnConfirm: false,
                closeOnCancel: false
            });
        }
    });
    //logica de guardado
    $('#btnGuardarConfRecSx').on('click', function () {
        var empresas = new Array();
        var arrayObjectos = new Array();
        if ($('#NumDocumentoAsesorSST').val() != '') {
            $('#emp_asesorSST').find('input[type="radio"][data-radio="radio_emp"]').each(function () {
                var empresa = new Object();
                if ($(this).is(':checked')) {
                    empresa.IdEmpresa = $(this).attr('id');
                    empresa.DocumentoAsesorSST = $('#NumDocumentoAsesorSST').val();
                    empresa.CodRol = $(this).data('rol');
                    empresa.Activo = true;
                    empresas.push(empresa);
                }
                //else
                //    empresa.Activo = false;
            });
            $('#recursos_sx').find('input[type="checkbox"]').each(function (index, value) {
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
                url: urlBase + urlUsuario + '/ConfigurarRecursosSistemaAsesorSST',
                data: { 'recursosConf': arrayObjectos, 'empresas': empresas },
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
                text: 'Debe ingresar un número de documento válido.',
                type: 'warning',
                confirmButtonColor: "#7E8A97",
                confirmButtonText: "OK",
                closeOnConfirm: false,
                closeOnCancel: false
            });
        }
    });
});