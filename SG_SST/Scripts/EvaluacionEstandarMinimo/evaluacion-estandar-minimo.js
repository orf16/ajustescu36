
$(document).ready(function () {




    $(document).on('click', '#regresarLista', function () {
        var idEval = $(this).attr('name');
        window.location.href = "/EvaluacionEstandarMinimo/Editar?ideval=" + idEval;
    });


    //Editar Criterio
    $('#editar_ciclo1').on('click', function () {

    });


    //Eliminar fila de actividades
    $(document).on('click', '.btn-elim-activ-edit', function () {
        var idboton = $(this).attr('id');
        var operacion = $(this).attr('edicion');
        var tableBody = $('#gridacts tbody');


        if (operacion == 'nuevo') {

            tableBody.find('tr').each(function () {
                var row = $(this);
                if (row.attr('name') == idboton) {

                    row.remove();
                }
            });
        }
        if (operacion == 'existente') {

            tableBody.find('tr').each(function () {
                var row = $(this);
                if (row.attr('name') == idboton) {
                    row.attr('estado', 'eliminado');
                    row.css('display', 'none');
                }
            });
        }
    });
    //Editar fila de actividades
    $(document).on('click', '#btn_edit_act_edit', function () {
        var opcion = $('#tipoEdicion').val();
        var actividad = $('#Actividad').val();
        var responsable = $('#Responsable').val();
        var fechafin = $('#FechaFin').val();
        var id = $('#IdAusenciaModal').val();

        var tableBody = $('#gridacts tbody');

        tableBody.find('tr').each(function () {
            var row = $(this);
            if (row.attr('name') == id) {
                row.attr('estado', 'editado');
                var n = 0;

                row.find('td').each(function () {
                    row1 = $(this);
                    if (n == 0) {
                        row1[0].innerText = actividad;
                    }
                    if (n == 1) {
                        row1[0].innerText = responsable;
                    }
                    if (n == 2) {
                        row1[0].innerText = fechafin;
                    }
                    n++;
                });


            }
        });

        $('#CrearNuevaActividad').modal('hide');
    });
    // Cargar actividad en modal
    $(document).on('click', '.btn-edit-activ-edit', function () {

        $('#IdAusenciaModal').val(null);
        $('#IdAusenciaModal').text(null);
        $('#Actividad').val(null);
        $('#Actividad').text(null);
        $('#Responsable').val(null);
        $('#Responsable').text(null);
        $('#tipoEdicion').val(null);
        $('#tipoEdicion').text(null);
        $('#FechaFin').val(null);
        $('#btn_crear_act_edit').show();
        $('#btn_edit_act_edit').hide();


        console.log('editar actividad');
        var idboton = $(this).attr('id');
        var tableBody = $('#gridacts tbody');

        var idact = idboton;
        var actividad = "";
        var responsable = "";
        var fechafin = "";
        var edicion = $(this).attr('edicion');

        tableBody.find('tr').each(function () {
            var row = $(this);
            if (row.attr('name') == idboton) {
                var n = 0;

                row.find('td').each(function () {
                    row1 = $(this);
                    if (n == 0) {
                        actividad = row1[0].innerText;
                    }
                    if (n == 1) {
                        responsable = row1[0].innerText;
                    }
                    if (n == 2) {
                        fechafin = row1[0].innerText;
                    }
                    n++;
                });


            }
        });

        $('#IdAusenciaModal').val(idact);
        $('#IdAusenciaModal').text(idact);
        $('#Actividad').val(actividad);
        $('#Actividad').text(actividad);
        $('#Responsable').val(responsable);
        $('#Responsable').text(responsable);

        $('#tipoEdicion').val(edicion);
        $('#tipoEdicion').text(edicion);


        $('#FechaFin').val(fechafin);
        $('#btn_crear_act_edit').hide();
        $('#btn_edit_act_edit').show();

        $('#CrearNuevaActividad').modal('show');



    });
    // Crear actividades en modo edicion
    $('#btn_crear_act_edit').on('click', function () {
        console.log('1');

        var fechaahora = new Date(Date.now());
        var fechaahora1 = new Date(Date.now());
        fechaahora.setHours(0, 0, 0, 0);
        var dateRegistro = moment(fechaahora1).format("YYYY_MM_DD_HH_mm_ss");
        actividades = new Array();
        var validado = true;
        var nuevaActividad = $('#Actividad').val();
        var responsable = $('#Responsable').val();
        var fechaFin = $('#FechaFin').val();


        var splitfecha1 = fechaFin.split("/");
        var splitfecha2 = fechaFin.split("-");
        var parsefecha1 = new Date(splitfecha1[2], splitfecha1[1] - 1, splitfecha1[0]);
        var parsefecha2 = new Date(splitfecha2[2], splitfecha2[1] - 1, splitfecha2[0]);
        var fechacomparar = null;

        if (parsefecha1 != 'Invalid Date') {
            fechacomparar = parsefecha1;
        }
        if (parsefecha2 != 'Invalid Date') {
            fechacomparar = parsefecha2;
        }
        if (fechacomparar < fechaahora) {
            swal({
                title: "Atención",
                text: 'La fecha de creación de la actividad debe ser superior a la fecha actual, por favor cambie la fecha y vuelva a intentar',
                showCancelButton: false,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "OK",
                type: "warning",
                closeOnConfirm: true
            })
            //swal('Atención', 'La fecha de creación de la actividad debe ser superior a la fecha actual, por favor cambie la fecha y vuelva a intentar');
            return;
        }

        if (nuevaActividad == null || nuevaActividad == undefined || nuevaActividad == '') {
            $('#Actividad').siblings().show();
            validado = false;
        }
        if (responsable == null || responsable == undefined || responsable == '') {
            $('#Responsable').siblings().show();
            validado = false;
        }
        if (fechaFin == null || fechaFin == undefined || fechaFin == '') {
            $('#FechaFin').parent().siblings().show();
            validado = false;
        }
        if (validado) {

            var idRegistro = dateRegistro;
            var Descripcion = nuevaActividad;
            var Resonsable = responsable;
            var FechaFin = fechaFin;

            PopupPosition();

            var html = "<tr class=\"nueva_fila\" name=\"" + idRegistro + "\" edicion=\"nuevo\" estado=\"sin\">";
            html += "<td style=\"border-right: 2px solid lightslategray; vertical-align:middle; text-align:center;font-weight: normal;\">" + Descripcion + "</td>";
            html += "<td style=\"border-right: 2px solid lightslategray; vertical-align:middle; text-align:center;font-weight: normal;\">" + Resonsable + "</td>";
            html += "<td style=\"border-right: 2px solid lightslategray; vertical-align:middle; text-align:center;font-weight: normal;\">" + FechaFin + "</td>";
            html += '<td style=\"border-right: 2px solid lightslategray; vertical-align:middle; text-align:center\"><button id=' + idRegistro + ' type="button" data-id=' + idRegistro + ' edicion="nuevo" class="btn-edit-activ-edit btn-popup-activ btn btn-default btn-sm"><span class="glyphicon glyphicon-pencil"></span></button></td>';
            html += '<td style=\"border-right: 2px solid lightslategray; vertical-align:middle; text-align:center\"><button id=' + idRegistro + ' type="button" data-id=' + idRegistro + ' edicion="nuevo" class="btn-elim-activ-edit btn-popup-activ btn btn-default btn-sm"><span class="glyphicon glyphicon-erase"></span></button></td></tr>';

            $("#gridacts tbody").append(html);
            $('#CrearNuevaActividad').modal('hide');

            $('#Actividad').val(null);
            $('#Responsable').val(null);
            $('#FechaFin').val(null);


            OcultarPopupposition();
        } else
            return false;

    });
    //Función para cargar un registro anterior


    $('.editcrit').on('click', function () {
        console.log('editcritclick');
        var boton = $(this);
        var idCriterio = boton.attr("name");
        var idEval = $('#ideval').val();
        var idciclo = $('#Ciclo').val();
        PopupPosition();
        $.ajax({
            url: '../EvaluacionEstandarMinimo/ObtenerCriteriosPorCicloEditar',
            data: { idCiclo: idciclo, idEval: idEval, idElemento: idCriterio },
            type: 'post',
            success: function (response) {
                if (response != null && response.Mensaje == 'OK') {
                    $('#container_est_min').empty();
                    $('#container_est_min').html(response.Datos);
                    OcultarPopupposition();
                    return false;
                }
                else {
                    if (response.Mensaje == 'El usuario no ha iniciado sesión en el sistema') {
                        location.reload(true);
                    }
                }
                OcultarPopupposition();
            },
            error: function (xhr, ajaxOptions, thrownError) {
                OcultarPopupposition();
            }
        });
        event.preventDefault ? event.preventDefault() : event.returnValue = false;
    });
    $('.editpage').on('click', function () {
        console.log('editpageclick');
        var boton = $(this);
        var idCriterio = boton.attr("name");
        var idEval = $('#ideval').val();
        var idciclo = $('#Ciclo').val();



        PopupPosition();
        $.ajax({
            url: '../EvaluacionEstandarMinimo/ObtenerCriteriosPorCicloEditar',
            data: { idCiclo: idciclo, idEval: idEval, idElemento: idCriterio },
            type: 'post'
        }).done(function (response) {
            if (response != null && response.Mensaje == 'OK') {
                $('#container_est_min').empty();
                $('#container_est_min').html(response.Datos);
            }
            else {
                if (response.Mensaje == 'El usuario no ha iniciado sesión en el sistema') {
                    location.reload(true);
                }
            }
            OcultarPopupposition();
        }).fail(function (response) {
            OcultarPopupposition();
        });
    });

    //valores iniciales
    $('.radio_no_aplica').css('display', 'none');
    $('#justificacion').hide();
    $('#container_archivos').hide();
    $('#container_archivos_edit').hide();
    //Funcion carga el ciclo actual (cambio)
    $('.btn_est_min').on('click', function (e) {
        console.log('4');
        var idEval = $('#ideval').val();

        var idElemento = $(this).attr('id');
        PopupPosition();
        $.ajax({
            url: '../EvaluacionEstandarMinimo/ObtenerCriteriosPorCiclo',
            data: { idCiclo: idElemento, idEval: idEval },
            type: 'post'
        }).done(function (response) {
            if (response != null && response.Mensaje == 'OK') {
                $('#container_est_min').empty();
                $('#container_est_min').html(response.Datos);
            }
            OcultarPopupposition();
        }).fail(function (response) {
            OcultarPopupposition();
        });
    });
    //Muestra el modal de actividades segun la respuesta
    $('.opc-calificacion').on('change', function (event) {
        console.log('5');
        //alert('opc-calificacion');
        var opcionCalificada = $(this).attr('id');
        $(this).prop('checked', true);
        if (opcionCalificada == 3) {

            $('#Actividad').val(null);
            $('#Responsable').val(null);
            $('#FechaFin').val(null);
            $('#IdAusenciaModal').val(null);

            $('#Actividad').text(null);
            $('#Responsable').text(null);
            $('#FechaFin').text(null);
            $('#IdAusenciaModal').text(null);

            $('.radio_no_aplica').css('display', 'inline-block');
            $('#container_actividades').hide();
        } else {
            $('.radio_no_aplica').css('display', 'none');
            $('#justificacion').hide();
            $('#container_archivos').hide();
            $('#container_archivos_edit').hide();
            $('.opc-opcionnoaplica').each(function (elem) {
                $(this).prop('checked', false);
            });
            if (opcionCalificada == 1) {
                $('#Actividad').val(null);
                $('#Responsable').val(null);
                $('#FechaFin').val(null);
                $('#IdAusenciaModal').val(null);

                $('#Actividad').text(null);
                $('#Responsable').text(null);
                $('#FechaFin').text(null);
                $('#IdAusenciaModal').text(null);
                $('#container_actividades').hide();
            }
            if (opcionCalificada == 2) {
                $('#CrearNuevaActividad').modal('show');
                var edicion= $('#IdReg').val();
                if (edicion==null) {
                    GestionarActividadesGeneradas();
                }
                
            }
        }
        event.preventDefault ? event.preventDefault() : event.returnValue = false;
    });
    //Radio de no aplica
    $('.opc-opcionnoaplica').on('change', function (e) {
        console.log('6');
        var opcionJustifica = $(this).attr('id');
        if (opcionJustifica == 4) {
            $('#justificacion').show();
            $('#container_archivos').show();
            $('#container_archivos_edit').show();
        }
        else {
            $('#container_archivos').hide();
            $('#container_archivos_edit').hide();
            $('#justificacion').hide();
        }

    });
    //botón para guardar la calificación de un estandar 
    $('#guardar_calif_actual').on('click', function (e) {
        console.log('7');
        ValidarCriterioAGuardar();
    });
    //botón para guardar la calificación de un estandar
    $('#guardar_ciclo').on('click', function (e) {
        console.log('8');
        var cicloval = $('#Ciclo').val();
        if (cicloval == '4') {
            swal({
                title: "Estimado Usuario",
                text: "Una vez guardada la evaluación el usuario no podra modificar sus resultados, está seguro que desea guardar este último ciclo?",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Si",
                cancelButtonText: "No",
                type: "warning",
                closeOnConfirm: false
            },
                        function () {
                            ValidarCriterioAGuardar();
                        });
        }
        else {
            if (cicloval == '1' || cicloval == '2' || cicloval == '3') {
                swal({
                    title: "Estimado Usuario",
                    text: "Está seguro que desea guardar este ciclo?",
                    showCancelButton: true,
                    confirmButtonColor: "#DD6B55",
                    confirmButtonText: "Si",
                    cancelButtonText: "No",
                    type: "warning",
                    closeOnConfirm: false
                },
                              function () {
                                  ValidarCriterioAGuardar();
                              });
            }

        }

    });
    //Informe parcial
    $('#btn_inf_parcial').on('click', function () {
        console.log('9');
        var ideval = $('#ideval').val();
        PopupPosition();
        $.ajax({
            type: "POST",
            url: '../EvaluacionEstandarMinimo/ObtenerInformeParcial',
            data: '{ideval: "' + ideval + '" }',
            contentType: "application/json; charset=utf-8",
            cache: false,
            dataType: "json",
        }).done(function (response) {
            if (response != undefined && response.Mensaje == 'OK') {
                $('#container_est_min').empty();
                $('#container_est_min').html(response.Datos);
                //$.fancybox(response.Datos);
            }
            OcultarPopupposition();
        }).fail(function (response) {
            OcultarPopupposition();
        });
    });
    //Informe Final
    $('#inf_final').on('click', function (e) {
        console.log('10');
        var ideval = $('#ideval').val();
        PopupPosition();
        $.ajax({
            type: "POST",
            url: '/EvaluacionEstandarMinimo/ObtenerInformeFinal',
            data: '{ideval: "' + ideval + '" }',
            contentType: "application/json; charset=utf-8",
            cache: false,
            dataType: "json",
        }).done(function (response) {
            if (response != undefined && response.Mensaje == 'OK') {
                $('#container_est_min').empty();
                $('#container_est_min').html(response.Datos);
                //$.fancybox(response.Datos);
            }
            OcultarPopupposition();
        }).fail(function (response) {
            OcultarPopupposition();
        });
        //DescargarExcelEstandesMinimosFinla();
    });
    //Limita a 500 los carateres digitados en la activida de plande accion
    $(document).on("input", "#Actividad", function () {
        var limite = 500;
        var textreal = $(this).val();
        var text;

        if ($(this).val().length > limite) {
            text = textreal.substr(0, limite);
            $(this).val(text);
        }
    });
    //Limita a 50 los caracteres digitados del responsable en el plan de accion
    $(document).on("input", "#Responsable", function () {
        var limite = 50;
        var textreal = $(this).val();
        var text;

        if ($(this).val().length > limite) {
            text = textreal.substr(0, limite);
            $(this).val(text);
        }
    });
    $("#_planAccion").on('click', function (event) {
        console.log('planacc');
        var Idval = $('#ideval').val();
        PopupPosition();
        $.ajax({
            url: '../EvaluacionEstandarMinimo/PlanDeAccion',
            data: '{ideval: "' + Idval + '" }',
            type: "POST",
            contentType: "application/json; charset=utf-8",
            cache: false,
            dataType: "json"
        }).done(function (response) {
            if (response.Mensaje == 'OK') {
                $('#containeplanaccion').empty();
                $('#containeplanaccion').html(response.Data);
                $('#PlanAccionModal').modal('show');
            }
            else {
                swal({
                    title: "Atención",
                    text: 'No existen planes de mejora disponibles para esta evaluación',
                    showCancelButton: false,
                    confirmButtonColor: "#DD6B55",
                    confirmButtonText: "OK",
                    type: "warning",
                    closeOnConfirm: true
                })
            }
            OcultarPopupposition();
        }).fail(function (response) {
            OcultarPopupposition();
        });
    });
    $('#FechaFin').datepicker({
        firstDay: 1,
        format: "dd/mm/yyyy",
        language: 'es',
        autoclose: true
    });
    $('#form_agr_actv input[type="text"]').on('focus', function () {
        console.log('12');
        if ($(this).attr('id') === 'FechaFin')
            $(this).parent().siblings().hide();
        else
            $(this).siblings().hide();
    });
    $('#btn_crear_act').on('click', function (event) {
        console.log('13');
        //llama a función para guardar nueva actividad
        //alert('btn_crear_act');
        GuardarNuevaActividad();
        event.preventDefault ? event.preventDefault() : event.returnValue = false;
    });
    $('.btn_cerrarProrroga').on('click', function (e) {
        console.log('14');
        var actividades = new Array();
        var actividadesGuardadas = sessionStorage.getItem('Actividades');
        if (!actividadesGuardadas) {
            $('.calif_crit').find('input[type=radio]').each(function () {
                $(this).prop('checked', false);
            });
        } else {
            actividades = JSON.parse(actividadesGuardadas);
            if (actividades.length == 0) {
                $('.calif_crit').find('input[type=radio]').each(function () {
                    $(this).prop('checked', false);
                });
            }
        }
    });
    $('#btn_agr_actv').on('click', function () {
        $('#IdAusenciaModal').val(null);
        $('#IdAusenciaModal').text(null);
        $('#Actividad').val(null);
        $('#Actividad').text(null);
        $('#Responsable').val(null);
        $('#Responsable').text(null);
        $('#tipoEdicion').val(null);
        $('#tipoEdicion').text(null);
        $('#FechaFin').val(null);
        $('#btn_crear_act_edit').show();
        $('#btn_edit_act_edit').hide();
        $('#form_agr_actv input[type="text"]').each(function () {
            $(this).val('');
        });
        $('#btn_crear_act').show();
        $('#btn_edit_act').hide();
    });
    $('#regresar').on('click', function () {
        console.log('17');
        var idEval = $('#ideval').val();
        var boton = $(this);

        var idElemento = boton.attr('name');
        PopupPosition();
        $.ajax({
            url: '../EvaluacionEstandarMinimo/ObtenerCriteriosPorCiclo',
            data: { idCiclo: idElemento, idEval: idEval },
            type: 'post'
        }).done(function (response) {
            if (response != null && response.Mensaje == 'OK') {
                $('#container_est_min').empty();
                $('#container_est_min').html(response.Datos);
            }
            OcultarPopupposition();
        }).fail(function (response) {
            OcultarPopupposition();
        });
    });


});

function ConstruirDatePickerBoton() {
    $("#FechaFin").triggerHandler("focus");
}


//controla la adición de una nueva actividad
function GuardarNuevaActividad() {

    var fechaahora = new Date(Date.now());
    fechaahora.setHours(0, 0, 0, 0);

    actividades = new Array();
    var validado = true;
    var nuevaActividad = $('#Actividad').val();
    var responsable = $('#Responsable').val();
    var fechaFin = $('#FechaFin').val();


    var splitfecha1 = fechaFin.split("/");
    var splitfecha2 = fechaFin.split("-");
    var parsefecha1 = new Date(splitfecha1[2], splitfecha1[1] - 1, splitfecha1[0]);
    var parsefecha2 = new Date(splitfecha2[2], splitfecha2[1] - 1, splitfecha2[0]);
    var fechacomparar = null;

    if (parsefecha1 != 'Invalid Date') {
        fechacomparar = parsefecha1;
    }
    if (parsefecha2 != 'Invalid Date') {
        fechacomparar = parsefecha2;
    }

    if (fechacomparar < fechaahora) {
        swal({
            title: "Atención",
            text: 'La fecha de creación de la actividad debe ser superior a la fecha actual, por favor cambie la fecha y vuelva a intentar',
            showCancelButton: false,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "OK",
            type: "warning",
            closeOnConfirm: true
        })
        //swal('Atención', 'La fecha de creación de la actividad debe ser superior a la fecha actual, por favor cambie la fecha y vuelva a intentar');
        return;
    }

    //123cambio


    if (nuevaActividad == null || nuevaActividad == undefined || nuevaActividad == '') {
        $('#Actividad').siblings().show();
        validado = false;
    }
    if (responsable == null || responsable == undefined || responsable == '') {
        $('#Responsable').siblings().show();
        validado = false;
    }
    if (fechaFin == null || fechaFin == undefined || fechaFin == '') {
        $('#FechaFin').parent().siblings().show();
        validado = false;
    }
    if (validado) {
        var actividades;
        var actividadesGuardadas = sessionStorage.getItem('Actividades');
        if (actividadesGuardadas) {
            actividades = JSON.parse(actividadesGuardadas);
            var ultimoId = actividades.length;
            var datos = {
                Id_Actividad: ultimoId + 1,
                Descripcion: nuevaActividad,
                Responsable: responsable,
                FechaFin: fechaFin
            };
            actividades.push(datos);
        } else {
            var datos = {
                Id_Actividad: 1,
                Descripcion: nuevaActividad,
                Responsable: responsable,
                FechaFin: fechaFin
            };
            actividades.push(datos);
        }
        sessionStorage.setItem('Actividades', JSON.stringify(actividades));
        PopupPosition();
        $.ajax({
            url: '../EvaluacionEstandarMinimo/AgregarNuevaActividad',
            data: { nuevaActividad: datos },
            type: 'post'
        }).done(function (response) {
            if (response.Mensaje == 'OK') {
                $('#container_actividades').show();
                $('#inner_actividades_agr').append(response.Data);
                $('#CrearNuevaActividad').modal('hide');
                //swal('Atención', 'La Actividad se creó con éxito.');
            }
            OcultarPopupposition();
        }).fail(function (response) {
            OcultarPopupposition();
        });
    } else
        return false;
}

function ValidarCriterioAGuardar() {
    console.log('validarCriterio2');
    var calificacion = 0;
    var opcionNoAplica = 0;
    var actividades = new Array();
    var justificacion = '';
    $('.opc-calificacion').each(function (elem) {
        if ($(this).is(':checked'))
            calificacion = $(this).attr('id');
    });
    if (calificacion <= 0) {
        swal({
            title: "Atención",
            text: "Debe realizar una calificación para continuar.",
            showCancelButton: false,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "OK",
            type: "warning",
            closeOnConfirm: true
        })
        //swal('Atención', 'Debe realizar una calificación para continuar.');
        return false;
    } else if (calificacion == 2) {
        var actividadesGuardadas = sessionStorage.getItem('Actividades');
        if (actividadesGuardadas) {
            actividades = JSON.parse(actividadesGuardadas);
            if (actividades.length == 0) {
                swal({
                    title: "Atención",
                    text: "Debe agregar al menos una actividad para continuar.",
                    showCancelButton: false,
                    confirmButtonColor: "#DD6B55",
                    confirmButtonText: "OK",
                    type: "warning",
                    closeOnConfirm: true
                })
                //swal('Atención', 'Debe agregar al menos una actividad para continuar.');
                return false;
            }
        } else {
            swal({
                title: "Atención",
                text: "Debe agregar al menos una actividad para continuar.",
                showCancelButton: false,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "OK",
                type: "warning",
                closeOnConfirm: true
            })
            //swal('Atención', 'Debe agregar al menos una actividad para continuar.');
            return false;
        }
    } else if (calificacion == 3) {
        $('.opc-opcionnoaplica').each(function (elem) {
            if ($(this).is(':checked'))
                opcionNoAplica = $(this).attr('id');
        });
        console.log(opcionNoAplica);
        if (opcionNoAplica <= 0) {
            swal({
                title: "Atención",
                text: 'Debe seleccionar una de las opciones para la calificación "No Aplica".',
                showCancelButton: false,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "OK",
                type: "warning",
                closeOnConfirm: true
            })
            //swal('Atención', 'Debe seleccionar una de las opciones para la calificación "No Aplica".');
            return false;
        } else if (opcionNoAplica == 4) {
            var justificacion = $('#textarea_justif').val();
            console.log(justificacion);
            if (justificacion == '') {
                swal({
                    title: "Atención",
                    text: 'Debe ingresar una justificación para la calificación "No Aplica".',
                    showCancelButton: false,
                    confirmButtonColor: "#DD6B55",
                    confirmButtonText: "OK",
                    type: "warning",
                    closeOnConfirm: true
                })
                //swal('Atención', 'Debe ingresar una justificación para la calificación "No Aplica".');
                return false;
            }
        }
    }
    var cicloGuardo = sessionStorage.getItem('CicloActual');
    var idEval = $('#ideval').val();

    //Archivos
    var archivo_n1 = $("#Archivo1").val();
    var archivo_n2 = $("#Archivo2").val();
    var archivo_n3 = $("#Archivo3").val();

    var archivo_d1 = $("#Archivo_s1").val();
    var archivo_d2 = $("#Archivo_s2").val();
    var archivo_d3 = $("#Archivo_s3").val();

    if (cicloGuardo) {
        var cicloActual = JSON.parse(cicloGuardo);
        var datos = {
            IdCiclo: cicloActual.IdCiclo,
            IdCriterio: cicloActual.IdCriterio,
            IdEmpresaEvaluar: cicloActual.IdEmpresaEvaluar,
            IdEvalEstandarMinimo: 0,
            IdValoracionCriterio: calificacion,
            Justificacion: justificacion,
            Actividades: actividades,
            IdEvaluacion: idEval,
            NombreArchivo1: archivo_n1,
            NombreArchivo2: archivo_n2,
            NombreArchivo3: archivo_n3,
            Filedownload1: archivo_d1,
            Filedownload2: archivo_d2,
            Filedownload3: archivo_d3
        };
        GuardarCalificacionCriterio(datos);
        return true;
    }
}
//guarda la calificacion de un criterio
function GuardarCalificacionCriterio(datos) {
    var idEval = $('#ideval').val();
    PopupPosition();
    $.ajax({
        url: '../EvaluacionEstandarMinimo/CalificarCriterioPorCiclo',
        type: 'post',
        data: { objCalificacion: datos }
    }).done(function (response) {
        if (response != null && response.Mensaje == 'OK') {
            if (response.CicloCalificado)
                window.location.href = '../EvaluacionEstandarMinimo/Index?ideval=' + idEval
            if (response.TerminaCalfEstMin)
                window.location.href = '../EvaluacionEstandarMinimo/Index?ideval=' + idEval
            $('#container_est_min').empty();
            $('#container_est_min').html(response.Datos);
            var actividades = sessionStorage.getItem('Actividades');
            if (actividades != null && actividades != 'undefined' && actividades != '') {
                sessionStorage.removeItem('Actividades');
            }
        }
        else {
            $('#ideval').val(null);
            location.reload(true);
        }        
        OcultarPopupposition();
    }).fail(function (responde) {
        OcultarPopupposition();
    });
}
//
function GestionarActividadesGeneradas() {
    var actividades = new Array();
    var actividadesGuardadas = sessionStorage.getItem('Actividades');
    if (!actividadesGuardadas)
        return false;
    actividades = JSON.parse(actividadesGuardadas);
    if (actividades.length > 0) {
        PopupPosition();
        $.ajax({
            url: '../EvaluacionEstandarMinimo/Renderizarctividades',
            data: { actividades: actividades },
            type: 'post'
        }).done(function (response) {
            if (response.Mensaje == 'OK') {
                $('#container_actividades').show();
                $('#inner_actividades_agr').empty();
                $('#inner_actividades_agr').append($('.head-activ').html());
                $('#inner_actividades_agr').append(response.Data);
            }
            OcultarPopupposition();
        }).fail(function (response) {
            OcultarPopupposition();
        });
        return true;
    } else
        return false;
}
//descargar informe en excel
function DescargarExcelEstandesMinimosFinla() {
    var datos = 1;
    $.ajax({
        url: '../EvaluacionEstandarMinimo/ObtenerInformeExccel',
        type: 'post',
        data: { idEmpresa: datos },
    }).done(function (response) {
        if (response != undefined && response.Mensaje == 'OK') {
            window.location.href = '../EvaluacionEstandarMinimo/DescargarInformeExccel';
        }
    });
}


function jsFunctioncargar(elemento) {
    console.log('jsFunctioncargar');
    var boton = elemento;
    var idCriterio = elemento;

    var idEval = $('#ideval').val();
    var idciclo = $('#Ciclo').val();
    PopupPosition();
    $.ajax({
        url: '../EvaluacionEstandarMinimo/ObtenerCriteriosPorCicloEditar',
        data: { idCiclo: idciclo, idEval: idEval, idElemento: idCriterio },
        type: 'post',
        success: function (response) {
            if (response != null && response.Mensaje == 'OK') {
                $('#container_est_min').empty();
                $('#container_est_min').html(response.Datos);
                OcultarPopupposition();
                return false;
            }
            else {
                if (response.Mensaje == 'El usuario no ha iniciado sesión en el sistema') {
                    location.reload(true);
                }
            }
            OcultarPopupposition();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            OcultarPopupposition();
        }
    });
    //event.preventDefault ? event.preventDefault() : event.returnValue = false;
}

//Archivos
//Agregar Archivo
$(function () {
    $('#btn-add-file').click(function () {
        $("#msj_novedad_archivo").text(null);
        $("#div_novedad_archivo").removeClass("alert alert-info alert-warning alert-danger alert-success");
        var LimiteMb = $('#MB_limit').val();
        if (window.FormData !== undefined) {
            var fileUpload = $("#input-file").get(0);
            var files = fileUpload.files;
            if (files != null) {
                var filesize = files[0].size;
                var mb = 1048576;
                var convertmb = (filesize / mb);
                if (convertmb > 3) {
                    $("#msj_novedad_archivo").text("Error al cargar el archivo, la imagen debe tener un tamaño máximo de " + "3" + "MB");
                    $("#div_novedad_archivo").removeClass("alert alert-info alert-warning alert-danger alert-success").addClass("alert alert-warning");
                }
                else {
                    var fileData = new FormData();
                    for (var i = 0; i < files.length; i++) {
                        fileData.append(files[i].name, files[i]);
                        fileData.append('extraParam1', $("#Archivo1").val());
                        fileData.append('extraParam2', $("#Archivo2").val());
                        fileData.append('extraParam3', $("#Archivo3").val());
                        fileData.append('extraParam4', $("#Archivo_s1").val());
                        fileData.append('extraParam5', $("#Archivo_s2").val());
                        fileData.append('extraParam6', $("#Archivo_s3").val());
                    }
                    PopupPosition();
                    $.ajax({
                        url: '/EvaluacionEstandarMinimo/UploadFiles',
                        type: "POST",
                        contentType: false,
                        processData: false,
                        data: fileData,
                        success: function (result) {
                            $("#msj_novedad_archivo").text('');
                            $("#div_novedad_archivo").removeClass("alert alert-info alert-warning alert-danger alert-success");
                            if (result.probar == false) {
                                $("#msj_novedad_archivo").text(result.resultado);
                                $("#div_novedad_archivo").removeClass("alert alert-info alert-warning alert-danger alert-success").addClass("alert alert-warning");
                            }
                            else {
                                $("#Grid2 > tbody").html("");
                                var table_id = document.getElementById('Grid2');
                                table_id.style.display = "none";




                                if (result.display[0] == true) {
                                    $("#Archivo1").val(result.NuevoNombreArchivos[0]);
                                    $("#Archivo_s1").val(result.NuevoNombreArchivos_short[0]);
                                    table_id.style.display = "table";
                                    var html = "<tr id=\"csfile1\">";
                                    html += "<td style=\"border-right: 2px solid lightslategray; vertical-align:middle; text-align:justify\">" + result.NuevoNombreArchivos_short[0] + "</td>";
                                    html += "<td style=\"vertical-align:middle; text-align:center\">" + "<a onclick=\"jsFunction1();\" id=\"delete-file1\" class=\"btn btn-sm btn-positiva btnEliminarArchivo\" title=\"Eliminar Archivo\"><span class=\"glyphicon glyphicon-erase\"></span></a>" + "</td>";
                                    $("#Grid2 tbody").append(html);
                                }
                                else {
                                    $("#Archivo1").val(null);
                                    $("#Archivo_s1").val(null);
                                }
                                if (result.display[1] == true) {
                                    $("#Archivo2").val(result.NuevoNombreArchivos[1]);
                                    $("#Archivo_s2").val(result.NuevoNombreArchivos_short[1]);
                                    table_id.style.display = "table";
                                    var html = "<tr id=\"csfile2\">";
                                    html += "<td style=\"border-right: 2px solid lightslategray; vertical-align:middle; text-align:justify\">" + result.NuevoNombreArchivos_short[1] + "</td>";
                                    html += "<td style=\"vertical-align:middle; text-align:center\">" + "<a onclick=\"jsFunction2();\" id=\"delete-file2\" class=\"btn btn-sm btn-positiva btnEliminarArchivo\" title=\"Eliminar Archivo\"><span class=\"glyphicon glyphicon-erase\"></span></a>" + "</td>";
                                    $("#Grid2 tbody").append(html);
                                }
                                else {
                                    $("#Archivo2").val(null);
                                    $("#Archivo_s2").val(null);
                                }
                                if (result.display[2] == true) {
                                    $("#Archivo3").val(result.NuevoNombreArchivos[2]);
                                    $("#Archivo_s3").val(result.NuevoNombreArchivos_short[2]);
                                    table_id.style.display = "table";
                                    var html = "<tr id=\"csfile3\">";
                                    html += "<td style=\"border-right: 2px solid lightslategray; vertical-align:middle; text-align:justify\">" + result.NuevoNombreArchivos_short[2] + "</td>";
                                    html += "<td style=\"vertical-align:middle; text-align:center\">" + "<a onclick=\"jsFunction3();\" id=\"delete-file3\" class=\"btn btn-sm btn-positiva btnEliminarArchivo\" title=\"Eliminar Archivo\"><span class=\"glyphicon glyphicon-erase\"></span></a>" + "</td>";
                                    $("#Grid2 tbody").append(html);
                                }
                                else {
                                    $("#Archivo3").val(null);
                                    $("#Archivo_s3").val(null);
                                }

                            }
                            OcultarPopupposition();
                        }
                        ,
                        error: function (err) {
                            var Error_response = err.responseText;
                            if (Error_response.indexOf("la longitud") >= 0) {
                                OcultarPopupposition();
                                $("#msj_novedad_archivo").text("Error al cargar el archivo, la imagen debe tener un tamaño máximo de " + "3" + "MB");
                                $("#div_novedad_archivo").removeClass("alert alert-info alert-warning alert-danger alert-success").addClass("alert alert-warning");
                            }
                            else {
                                OcultarPopupposition();
                                $("#msj_novedad_archivo").text("Error al cargar el archivo");
                                $("#div_novedad_archivo").removeClass("alert alert-info alert-warning alert-danger alert-success").addClass("alert alert-warning");
                            }

                        }
                    });
                }
            }







        }
        else {

        }
    });
});
//Eliminar Archivos
function jsFunction1() {
    $("#msj_novedad_archivo").text(null);
    $("#div_novedad_archivo").removeClass("alert alert-info alert-warning alert-danger alert-success");
    PopupPosition();
    $.ajax({
        type: "POST",
        url: "/EvaluacionEstandarMinimo/EliminarArchivoTemp",
        data: '{ruta: "' + $("#Archivo1").val() + '" }',
        contentType: "application/json; charset=utf-8",
        cache: false,
        dataType: "json",
        success: function (response) {
            OcultarPopupposition();
            if (response.probar == false) {
            }
            else {
                $("#Archivo1").val(null);
                $("#Archivo_s1").val(null);
                $("#csfile1").remove();
                if ($("#Archivo1").val().length === 0) {
                    if ($("#Archivo2").val().length === 0) {
                        if ($("#Archivo3").val().length === 0) {
                            var table_id = document.getElementById('Grid2');
                            table_id.style.display = "none";
                        }
                    }
                }
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            OcultarPopupposition();
        }
    });
}
function jsFunction2() {
    $("#msj_novedad_archivo").text(null);
    $("#div_novedad_archivo").removeClass("alert alert-info alert-warning alert-danger alert-success");
    PopupPosition();
    $.ajax({
        type: "POST",
        url: "/EvaluacionEstandarMinimo/EliminarArchivoTemp",
        data: '{ruta: "' + $("#Archivo2").val() + '" }',
        contentType: "application/json; charset=utf-8",
        cache: false,
        dataType: "json",
        success: function (response) {
            OcultarPopupposition();
            if (response.probar == false) {
            }
            else {
                $("#Archivo2").val(null);
                $("#Archivo_s2").val(null);
                $("#csfile2").remove();
                if ($("#Archivo1").val().length === 0) {
                    if ($("#Archivo2").val().length === 0) {
                        if ($("#Archivo3").val().length === 0) {
                            var table_id = document.getElementById('Grid2');
                            table_id.style.display = "none";
                        }
                    }
                }
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            OcultarPopupposition();
        }
    });
}
function jsFunction3() {
    $("#msj_novedad_archivo").text(null);
    $("#div_novedad_archivo").removeClass("alert alert-info alert-warning alert-danger alert-success");
    PopupPosition();
    $.ajax({
        type: "POST",
        url: "/EvaluacionEstandarMinimo/EliminarArchivoTemp",
        data: '{ruta: "' + $("#Archivo3").val() + '" }',
        contentType: "application/json; charset=utf-8",
        cache: false,
        dataType: "json",
        success: function (response) {
            OcultarPopupposition();
            if (response.probar == false) {
            }
            else {
                $("#Archivo3").val(null);
                $("#Archivo_s3").val(null);
                $("#csfile3").remove();
                if ($("#Archivo1").val() == null) {
                    if ($("#Archivo2").val().length == null) {
                        if ($("#Archivo3").val().length == null) {
                            var table_id = document.getElementById('Grid2');
                            table_id.style.display = "none";
                        }
                    }
                }
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            OcultarPopupposition();
        }
    });
}
//Descargar Archivo
function jsFunction11() {
    var stringArray = new Array();
    stringArray[0] = $("#Archivo1").val();
    stringArray[1] = $("#Archivo_s1").val();
    stringArray[2] = $("#IdReg").val();
    stringArray[3] = "1";
    stringArray[4] = $("#ideval").val();
    stringArray[5] = $("#Ciclo").val();

    var postData = { values: stringArray };
    PopupPosition();
    $.ajax({
        type: "POST",
        url: "/EvaluacionEstandarMinimo/DescargarArchivo",
        data: postData,
        dataType: "json",
        traditional: true,
        success: function (data) {
            OcultarPopupposition();
            if (data.probar == false) {

            }
            else {
                window.location.href = "/EvaluacionEstandarMinimo/Download?Nombre=" + data.NombreArchivo + "&Proviene=" + data.proviene + "&Numero=1" + "&Ndownload=" + data.nombre_download + "&ruta=" + data.ruta;

            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            OcultarPopupposition();
        }
    });
}
function jsFunction12() {
    var stringArray = new Array();

    stringArray[0] = $("#Archivo2").val();
    stringArray[1] = $("#Archivo_s2").val();
    stringArray[2] = $("#IdReg").val();
    stringArray[3] = "2";
    stringArray[4] = $("#ideval").val();
    stringArray[5] = $("#Ciclo").val();



    var postData = { values: stringArray };
    PopupPosition();
    $.ajax({
        type: "POST",
        url: "/EvaluacionEstandarMinimo/DescargarArchivo",
        data: postData,
        dataType: "json",
        traditional: true,
        success: function (data) {
            OcultarPopupposition();
            if (data.probar == false) {

            }
            else {
                window.location.href = "/EvaluacionEstandarMinimo/Download?Nombre=" + data.NombreArchivo + "&Proviene=" + data.proviene + "&Numero=1" + "&Ndownload=" + data.nombre_download + "&ruta=" + data.ruta;

            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            OcultarPopupposition();
        }
    });
}
function jsFunction13() {
    var stringArray = new Array();
    stringArray[0] = $("#Archivo3").val();
    stringArray[1] = $("#Archivo_s3").val();
    stringArray[2] = $("#IdReg").val();
    stringArray[3] = "3";
    stringArray[4] = $("#ideval").val();
    stringArray[5] = $("#Ciclo").val();
    var postData = { values: stringArray };
    PopupPosition();
    $.ajax({
        type: "POST",
        url: "/EvaluacionEstandarMinimo/DescargarArchivo",
        data: postData,
        dataType: "json",
        traditional: true,
        success: function (data) {
            OcultarPopupposition();
            if (data.probar == false) {

            }
            else {
                window.location.href = "/EvaluacionEstandarMinimo/Download?Nombre=" + data.NombreArchivo + "&Proviene=" + data.proviene + "&Numero=1" + "&Ndownload=" + data.nombre_download + "&ruta=" + data.ruta;

            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            OcultarPopupposition();
        }
    });
}


//Cargar Archivos Edicion
$(function () {
    $('#btn-add-file-edit').click(function () {
        $("#msj_novedad_archivo").text(null);
        $("#div_novedad_archivo").removeClass("alert alert-info alert-warning alert-danger alert-success");
        if (window.FormData !== undefined) {
            var fileUpload = $("#input-file-edit").get(0);
            var files = fileUpload.files;
            if (files != null) {
                var filesize = files[0].size;
                var mb = 1048576;
                var convertmb = (filesize / mb);
                if (convertmb > 3) {
                    $("#msj_novedad_archivo").text("Error al cargar el archivo, la imagen debe tener un tamaño máximo de " + "3" + "MB");
                    $("#div_novedad_archivo").removeClass("alert alert-info alert-warning alert-danger alert-success").addClass("alert alert-warning");
                }
                else {
                    var fileData = new FormData();
                    for (var i = 0; i < files.length; i++) {
                        fileData.append(files[i].name, files[i]);
                        fileData.append('extraParam1', $("#Archivo1").val());
                        fileData.append('extraParam2', $("#Archivo2").val());
                        fileData.append('extraParam3', $("#Archivo3").val());
                        fileData.append('extraParam4', $("#Archivo_s1").val());
                        fileData.append('extraParam5', $("#Archivo_s2").val());
                        fileData.append('extraParam6', $("#Archivo_s3").val());
                        fileData.append('extraParam7', $("#Archivo1_c").val());
                        fileData.append('extraParam8', $("#Archivo2_c").val());
                        fileData.append('extraParam9', $("#Archivo3_c").val());


                        fileData.append('extraParam10', $("#Ciclo").val());
                        fileData.append('extraParam11', $("#ideval").val());
                        fileData.append('extraParam12', $("#IdReg").val());
                    }
                    PopupPosition();
                    $.ajax({
                        url: '/EvaluacionEstandarMinimo/UploadFiles_ed',
                        type: "POST",
                        contentType: false,
                        processData: false,
                        data: fileData,
                        success: function (result) {
                            $("#msj_novedad_archivo").text('');
                            $("#div_novedad_archivo").removeClass("alert alert-info alert-warning alert-danger alert-success");
                            if (result.probar == false) {
                                $("#msj_novedad_archivo").text(result.resultado);
                                $("#div_novedad_archivo").removeClass("alert alert-info alert-warning alert-danger alert-success").addClass("alert alert-warning");
                            }
                            else {
                                $("#Grid2 > tbody").html("");
                                var table_id = document.getElementById('Grid2');
                                table_id.style.display = "none";




                                if (result.display[0] == true) {
                                    $("#Archivo1").val(result.NuevoNombreArchivos[0]);
                                    $("#Archivo_s1").val(result.NuevoNombreArchivos_short[0]);
                                    table_id.style.display = "table";
                                    var html = "<tr id=\"csfile1\">";
                                    html += "<td style=\"border-right: 2px solid lightslategray; vertical-align:middle; text-align:justify\">" + result.NuevoNombreArchivos_short[0] + "</td>";
                                    html += "<td style=\"vertical-align:middle; text-align:center\">" + "<a style=\"height:35px;margin-bottom:5px;margin-left:2px\" onclick=\"jsFunction1();\" id=\"delete-file1\" class=\"btn btn-sm btn-positiva btnEliminarArchivo\" title=\"Eliminar Archivo\"><span class=\"glyphicon glyphicon-erase\"></span></a>" + "<a style=\"height:35px;margin-bottom:5px;margin-left:2px\" onclick=\"jsFunction11();\" id=\"donwload-file1\" class=\"btn btn-sm btn-positiva btnEliminarArchivo\" title=\"Descargar Archivo\"><span class=\"glyphicon glyphicon-download-alt\"></span></a>" + "</td>";
                                    $("#Grid2 tbody").append(html);
                                }
                                else {
                                    $("#Archivo1").val(null);
                                    $("#Archivo_s1").val(null);
                                }
                                if (result.display[1] == true) {
                                    $("#Archivo2").val(result.NuevoNombreArchivos[1]);
                                    $("#Archivo_s2").val(result.NuevoNombreArchivos_short[1]);
                                    table_id.style.display = "table";
                                    var html = "<tr id=\"csfile2\">";
                                    html += "<td style=\"border-right: 2px solid lightslategray; vertical-align:middle; text-align:justify\">" + result.NuevoNombreArchivos_short[1] + "</td>";


                                    html += "<td style=\"vertical-align:middle; text-align:center\">" + "<a style=\"height:35px;margin-bottom:5px;margin-left:2px\" onclick=\"jsFunction2();\" id=\"delete-file2\" class=\"btn btn-sm btn-positiva btnEliminarArchivo\" title=\"Eliminar Archivo\"><span class=\"glyphicon glyphicon-erase\"></span></a>" + "<a style=\"height:35px;margin-bottom:5px;margin-left:2px\" onclick=\"jsFunction12();\" id=\"donwload-file2\" class=\"btn btn-sm btn-positiva btnEliminarArchivo\" title=\"Descargar Archivo\"><span class=\"glyphicon glyphicon-download-alt\"></span></a>" + "</td>";

                                    $("#Grid2 tbody").append(html);
                                }
                                else {
                                    $("#Archivo2").val(null);
                                    $("#Archivo_s2").val(null);
                                }
                                if (result.display[2] == true) {
                                    $("#Archivo3").val(result.NuevoNombreArchivos[2]);
                                    $("#Archivo_s3").val(result.NuevoNombreArchivos_short[2]);
                                    table_id.style.display = "table";
                                    var html = "<tr id=\"csfile3\">";
                                    html += "<td style=\"border-right: 2px solid lightslategray; vertical-align:middle; text-align:justify\">" + result.NuevoNombreArchivos_short[2] + "</td>";
                                    html += "<td style=\"vertical-align:middle; text-align:center\">" + "<a style=\"height:35px;margin-bottom:5px;margin-left:2px\" onclick=\"jsFunction3();\" id=\"delete-file3\" class=\"btn btn-sm btn-positiva btnEliminarArchivo\" title=\"Eliminar Archivo\"><span class=\"glyphicon glyphicon-erase\"></span></a>" + "<a style=\"height:35px;margin-bottom:5px;margin-left:2px\" onclick=\"jsFunction13();\" id=\"donwload-file3\" class=\"btn btn-sm btn-positiva btnEliminarArchivo\" title=\"Descargar Archivo\"><span class=\"glyphicon glyphicon-download-alt\"></span></a>" + "</td>";
                                    $("#Grid2 tbody").append(html);
                                }
                                else {
                                    $("#Archivo3").val(null);
                                    $("#Archivo_s3").val(null);
                                }

                            }
                            OcultarPopupposition();
                        }
                        ,
                        error: function (err) {
                            $("#msj_novedad_archivo").text("Error al cargar el archivo");
                            $("#div_novedad_archivo").removeClass("alert alert-info alert-warning alert-danger alert-success").addClass("alert alert-warning");
                            OcultarPopupposition();
                        }
                    });
                }
            }


        }
        else {

        }
    });
});


//Eliminar Archivos
function jsFunction1ed() {
    $("#msj_novedad_archivo").text(null);
    $("#div_novedad_archivo").removeClass("alert alert-info alert-warning alert-danger alert-success");
    PopupPosition();
    $.ajax({
        type: "POST",
        url: "/EvaluacionEstandarMinimo/EliminarArchivoTemp",
        data: '{ruta: "' + $("#Archivo1").val() + '" }',
        contentType: "application/json; charset=utf-8",
        cache: false,
        dataType: "json",
        success: function (response) {
            OcultarPopupposition();
            if (response.probar == false) {
            }
            else {
                $("#Archivo1").val(null);
                $("#Archivo_s1").val(null);
                $("#Archivo1_c").val("");
                $("#csfile1").remove();
                if ($("#Archivo1").val().length === 0) {
                    if ($("#Archivo2").val().length === 0) {
                        if ($("#Archivo3").val().length === 0) {
                            var table_id = document.getElementById('Grid2');
                            table_id.style.display = "none";
                        }
                    }
                }
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            OcultarPopupposition();
        }
    });
}
function jsFunction2ed() {
    $("#msj_novedad_archivo").text(null);
    $("#div_novedad_archivo").removeClass("alert alert-info alert-warning alert-danger alert-success");
    PopupPosition();
    $.ajax({
        type: "POST",
        url: "/EvaluacionEstandarMinimo/EliminarArchivoTemp",
        data: '{ruta: "' + $("#Archivo2").val() + '" }',
        contentType: "application/json; charset=utf-8",
        cache: false,
        dataType: "json",
        success: function (response) {
            OcultarPopupposition();
            if (response.probar == false) {
            }
            else {
                $("#Archivo2").val(null);
                $("#Archivo_s2").val(null);
                $("#Archivo2_c").val("");
                $("#csfile2").remove();
                if ($("#Archivo1").val().length === 0) {
                    if ($("#Archivo2").val().length === 0) {
                        if ($("#Archivo3").val().length === 0) {
                            var table_id = document.getElementById('Grid2');
                            table_id.style.display = "none";
                        }
                    }
                }
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            OcultarPopupposition();
        }
    });
}
function jsFunction3ed() {
    $("#msj_novedad_archivo").text(null);
    $("#div_novedad_archivo").removeClass("alert alert-info alert-warning alert-danger alert-success");
    PopupPosition();
    $.ajax({
        type: "POST",
        url: "/EvaluacionEstandarMinimo/EliminarArchivoTemp",
        data: '{ruta: "' + $("#Archivo3").val() + '" }',
        contentType: "application/json; charset=utf-8",
        cache: false,
        dataType: "json",
        success: function (response) {
            OcultarPopupposition();
            if (response.probar == false) {
            }
            else {
                $("#Archivo3").val(null);
                $("#Archivo_s3").val(null);
                $("#Archivo3_c").val("");
                $("#csfile3").remove();
                if ($("#Archivo1").val() == null) {
                    if ($("#Archivo2").val().length == null) {
                        if ($("#Archivo3").val().length == null) {
                            var table_id = document.getElementById('Grid2');
                            table_id.style.display = "none";
                        }
                    }
                }
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            OcultarPopupposition();
        }
    });
}


$(document).ready(function () {
        $('#regresarinicio').on('click', function () {
            window.location.href = "/EvaluacionEstandarMinimo/inicio"
        });
});


