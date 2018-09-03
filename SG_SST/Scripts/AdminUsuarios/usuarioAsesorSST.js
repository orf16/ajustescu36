var urlBase = utils.getBaseUrl();
var urlUsuario = '/AdminUsuarios';

$(document).ready(function () {
    //configuracion inicial
    //configura el datepicker para el elemneto dado
    ConstruirDatePickerPorElemento('FechaInicioContrato');
    ConstruirDatePickerPorElemento('FechaFinContrato');
    $('#formAsesorSST input[type="text"], input[type="file"], select').on('focus', function () {
        $(this).siblings('span').hide();
    });
    //consulta la información asociada a la empresa
    $('#busarRLAsesorSST').on('click', function() {
        var tipoDocumentoEmpresa = $("#TipoDocumentoEmpresa").val();
        var documentoEmpresa = $("#DocumentoEmpresa").val();
        if (tipoDocumentoEmpresa != '' && documentoEmpresa != '') {
            ConsultarInformacionEmpresa(tipoDocumentoEmpresa, documentoEmpresa);
            $(this).siblings('span').hide();
        } else {
            swal('Atención', 'Antes de continuar debe diligenciar los anteriores campos.');
            evt.preventDefault();
            //return false;
        }
    });
    //$('#DocumentoEmpresa').on('change', function (evt) {
    //    var tipoDocumentoEmpresa = $("#TipoDocumentoEmpresa").val();
    //    var documentoEmpresa = $("#DocumentoEmpresa").val();
    //    if (tipoDocumentoEmpresa != '' && documentoEmpresa != '') {
    //        ConsultarInformacionEmpresa(tipoDocumentoEmpresa, documentoEmpresa);
    //        $(this).siblings('span').hide();
    //    } else {
    //        swal('Atención', 'Antes de continuar debe diligenciar los anteriores campos.');
    //        evt.preventDefault();
    //        //return false;
    //    }
    //});
    //
    $('#formAsesorSST').on('submit', function (evt) {
        evt.preventDefault();
        var strfehaIniContrato = $('#FechaInicioContrato').val();
        var strfehaFinContrato = $('#FechaFinContrato').val();
        var fechaIniContrato = new Date(strfehaIniContrato.split('/')[2], strfehaIniContrato.split('/')[1] - 1, strfehaIniContrato.split('/')[0]).getTime();
        var fechaFinContrato = new Date(strfehaFinContrato.split('/')[2], strfehaFinContrato.split('/')[1] - 1, strfehaFinContrato.split('/')[0]).getTime();
        var fechaActual = new Date().getTime();
        if (fechaFinContrato <= fechaIniContrato) {
            swal({
                title: 'Información!',
                text: 'La fecha fin de autorización no puede ser menor o igual a la fecha inicio de autorización.',
                type: 'error'
            });
            event.stopPropagation();
            return false;
        } if (fechaIniContrato <= fechaActual) {
            swal({
                title: 'Información!',
                text: 'La fecha de Inicio de autorización no puede ser menor o igual a la fecha de registro de la solicitud de usuario.',
                type: 'error'
            });
            event.stopPropagation();
            return false;
        }
        $('#formAsesorSST input[id="RazonSocialEmpresa"]').val($('#RazonSocialEmpresa').val());
        $('#formAsesorSST input[id="Nombres"]').val($('#Nombres').val());
        $('#formAsesorSST input[id="Apellidos"]').val($('#Apellidos').val());
        $('#formAsesorSST input[id="EmailPersona"]').val($('#EmailPersona').val());
        $('#formAsesorSST input[id="MunicipioSedePpalEmpresa"]').val($('#MunicipioSedePpalEmpresa').val());
        this.submit();
    });
});
//Consulta la informacion del trabajador
function ConsultarInformacionEmpresa(tipoDocumentoEmpresa, documentoEmpresa) {
    PopupPosition();
    $.ajax({
        type: "post",
        data: { tipoDocumentoEmp: tipoDocumentoEmpresa, numDocumentoEmp: documentoEmpresa },
        url: urlBase + urlUsuario + '/ConsultarInformacionEmpresaSiarp'
    }).done(function (response) {
        if (response != undefined && response != '' && response.Estado == 'OK' && response.MensajeError == '') {
            var nombres = response.NombresUsuario;
            var apellidos = response.ApellidosUsuario;
            var razonSocial = response.RazonSocialEmpresa;
            var municipioEmpresa = response.MunicipioSedePpalEmrpresa;
            if (response.PreguntasSeguridad != 'undefined' && response.PreguntasSeguridad != null && response.PreguntasSeguridad.length > 0) {
                var preguntaUno = response.PreguntasSeguridad[0].NombrePregunta;
                var preguntaDos = response.PreguntasSeguridad[1].NombrePregunta;
                var preguntaTres = response.PreguntasSeguridad[2].NombrePregunta;
                if ($('#ConfiguracionPreguntasSeguridad_NombrePreguntaUno').length > 0) {
                    $('#ConfiguracionPreguntasSeguridad_NombrePreguntaUno').val(preguntaUno);
                }
                if ($('#ConfiguracionPreguntasSeguridad_NombrePreguntaDos').length > 0) {
                    $('#ConfiguracionPreguntasSeguridad_NombrePreguntaDos').val(preguntaDos);
                }
                if ($('#ConfiguracionPreguntasSeguridad_NombrePreguntaTres').length > 0) {
                    $('#ConfiguracionPreguntasSeguridad_NombrePreguntaTres').val(preguntaTres);
                }
            }
            $('#Nombres').val(nombres);
            $('#Apellidos').val(apellidos);
            $('#RazonSocialEmpresa').val(razonSocial);
            $('#MunicipioSedePpalEmpresa').val(municipioEmpresa);
        } else if (response != undefined && response != '' && response.Estado == 'OK' && response.MensajeError != '') {
            $("#TipoDocumentoEmpresa").val('');
            $("#DocumentoEmpresa").val('');
            $("#Documento").val('');
            $('#Nombres').val('');
            $('#Apellidos').val('');
            $('#RazonSocialEmpresa').val('');
            $('#MunicipioSedePpalEmpresa').val('');
            swal("Atención", response.MensajeError);
        }
        OcultarPopupposition();
    }).fail(function (response) {
        $("#TipoDocumentoEmpresa").val('');
        $("#DocumentoEmpresa").val('');
        $("#Documento").val('');
        $('#Nombres').val('');
        $('#Apellidos').val('');
        $('#RazonSocialEmpresa').val('');
        $('#MunicipioSedePpalEmpresa').val('');
        swal("Atención", "No se logró obtener datos del Usuario. Intente nuevamente.");
        OcultarPopupposition();
    });
}
