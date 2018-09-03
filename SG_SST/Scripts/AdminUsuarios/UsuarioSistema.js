var urlBase = utils.getBaseUrl();
var urlUsuario = '/AdminUsuarios';
$(document).ready(function () {
    $("#FrmConsulUsuSistema").validate({
        rules: {
            DocumentoEmpresa: {
                required: true
            },
            IdEstado: {
                required: true, min: 1
            }            
        },
        messages: {
            DocumentoEmpresa: {
                required: "Este compo es obligatorio",
            },
            IdEstado: {
                required: "Este compo es obligatorio",
                min: "Este compo es obligatorio"
            }            
        }
    });
    $('#DocumentoEmpresa').keypress(function (tecla) {
        if (tecla.charCode < 48 || tecla.charCode > 57) return false;
    });
    $(document).on("input", "#DocumentoEmpresa", function () {
        var limite = 15;
        var textreal = $(this).val();
        var text;

        if ($(this).val().length > limite) {
            text = textreal.substr(0, limite);
            $(this).val(text);
        }
    });
    $('#ConsultarUsuariosSistema').on("click", function () {
        var idEstado = $("#IdEstado").val();
        var nitEmpresa = $("#DocumentoEmpresa").val();
        var i = 0;
        PopupPosition();
        if ($("#FrmConsulUsuSistema").valid() != false) {
            $.ajax({
                type: "POST",
                data: { idEstado: idEstado, NitEmpresa: nitEmpresa, numPagina: i },
                url: urlBase + urlUsuario + '/ConsultaUsuariosSistema'
            }).done(function (response) {
                if (response != undefined && response != '' && response.Mensaje == 'Success') {
                    $('#Contenedor').empty();
                    $('#Contenedor').html(response.Data);
                }
                else if (response.Mensaje == 'Fail') {
                    swal({
                        type: 'warning',
                        title: 'Estimado Usuario',
                        text: 'No existen datos registros para los parametros de busqueda.',
                        confirmButtonColor: '#7E8A97',
                        confirmButtonText: "Aceptar",
                    });                    
                    $('#Contenedor').empty();
                }
                OcultarPopupposition();
            }).fail(function (response) {
                console.log("Error en la peticion: " + response.Data);
                OcultarPopupposition();
            });
        }
       
    })

    $('#Limpiar').on("click", function () {
        $("#DocumentoEmpresa").val('');
        $('#IdEstado option:contains(Estados Usuarios)').prop('selected', true);
    })
});


function SiguientePagina(i) {

    var idEstado = $("#IdEstado").val();
    var nitEmpresa = $("#DocumentoEmpresa").val();
    PopupPosition();
    if ($("#FrmConsulUsuSistema").valid() != false) {
        $.ajax({
            type: "POST",
            data: { idEstado: idEstado, NitEmpresa: nitEmpresa, numPagina: i },
            url: urlBase + urlUsuario + '/ConsultaUsuariosSistema'
        }).done(function (response) {
            if (response != undefined && response != '' && response.Mensaje == 'Success') {
                $('#Contenedor').empty();
                $('#Contenedor').html(response.Data);
                OcultarPopupposition();
            }
            else if (response.Mensaje == 'Fail') {
                swal("Estimado Usuario", 'No existen datos registros para los parametros de busqueda.');
                $('#Contenedor').empty();
                OcultarPopupposition();
            }
        }).fail(function (response) {
            console.log("Error en la peticion: " + response.Data);
            OcultarPopupposition();
        });
    }
}
