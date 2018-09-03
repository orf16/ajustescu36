function editar_criterioev() {
    console.log('editar1');
    var idEval = $('#ideval').val();
    var idReg = $('#IdReg').val();
    var idCiclo = $("#Ciclo").val();
    var probar = true;


    var calificacion = 0;
    var opcionNoAplica = 0;
    var actividades = new Array();
    var justificacion = '';

    var tableBody = $('#gridacts tbody');

    //Obtiene calificación
    $('.opc-calificacion').each(function (elem) {
        if ($(this).is(':checked'))
            calificacion = $(this).attr('id');
    });

    if (calificacion <= 0) {
        swal({
            title: "Atención",
            text: 'Debe realizar una calificación para editar el registro.',
            showCancelButton: false,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "OK",
            type: "warning",
            closeOnConfirm: true
        })
        //swal('Atención', 'Debe realizar una calificación para editar el registro.');
        return false;
    } else if (calificacion == 2) {
        //Captar Actvidades nuevas
        var ListaActividades = new Array();
        var contActs = 0;
        $('#gridacts > tbody').find('tr.nueva_fila').each(function () {
            var row = $(this);
            var nuevaActividad = '';
            var responsable = '';
            var fechaFin = '';


            var n = 0;
            row.find('td').each(function () {
                row1 = $(this);
                if (n == 0) {
                    nuevaActividad = row1[0].innerText;
                }
                if (n == 1) {
                    responsable = row1[0].innerText;
                }
                if (n == 2) {
                    fechaFin = row1[0].innerText;
                }
                n++;
            });

            var idrow = row.attr('name');


            var datos = {
                Descripcion: nuevaActividad,
                Responsable: responsable,
                FechaFin: fechaFin,
                Accion: 'nuevo',
                Id_Actividad_String: idrow
            };

            ListaActividades.push(datos);
            contActs++;
        });

        $('#gridacts > tbody').find('tr.fila_existente').each(function () {
            var row = $(this);
            var nuevaActividad = '';
            var responsable = '';
            var fechaFin = '';

            var n = 0;
            row.find('td').each(function () {
                row1 = $(this);
                if (n == 0) {
                    nuevaActividad = row1[0].innerText;
                }
                if (n == 1) {
                    responsable = row1[0].innerText;
                }
                if (n == 2) {
                    fechaFin = row1[0].innerText;
                }
                n++;
            });


            var idrow = row.attr('name');
            var edicion = row.attr('estado');
            if (edicion == 'sin') {
                contActs++;
            }
            var accion = 'sin';


            if (edicion == 'editado') {
                accion = 'editado';
                contActs++;
            }
            if (edicion == 'eliminado') {
                accion = 'eliminado';
            }
            var datos = {
                Descripcion: nuevaActividad,
                Responsable: responsable,
                FechaFin: fechaFin,
                Accion: accion,
                Id_Actividad_String: idrow
            };


            ListaActividades.push(datos);

        });

        if (contActs <= 0) {
            swal({
                title: "Atención",
                text: 'Debe agregar al menos una actividad para continuar.',
                showCancelButton: false,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "OK",
                type: "warning",
                closeOnConfirm: true
            })
            //swal('Atención', 'Debe agregar al menos una actividad para continuar.');
            $('.opc-calificacion').prop('checked', false);
            return false;
        }

    } else if (calificacion == 3) {
        $('.opc-opcionnoaplica').each(function (elem) {
            if ($(this).is(':checked'))
                opcionNoAplica = $(this).attr('id');
        });

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

            var justreplace = '';
            if (justificacion != null) {
                justreplace = $.trim(justificacion);
            }
            if (justreplace == '') {
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
    //var cicloGuardo = sessionStorage.getItem('CicloActual');


    var archivo_n1 = $("#Archivo1").val();
    var archivo_n2 = $("#Archivo2").val();
    var archivo_n3 = $("#Archivo3").val();

    var archivo_d1 = $("#Archivo_s1").val();
    var archivo_d2 = $("#Archivo_s2").val();
    var archivo_d3 = $("#Archivo_s3").val();

    var archivo_r1 = $("#Archivo1_c").val();
    var archivo_r2 = $("#Archivo2_c").val();
    var archivo_r3 = $("#Archivo3_c").val();

    var objCalificacion = {
        IdCiclo: idCiclo,
        IdCriterio: idReg,
        IdValoracionCriterio: calificacion,
        Justificacion: justificacion,
        Actividades: ListaActividades,
        IdEvaluacion: idEval,
        NombreArchivo1: archivo_n1,
        NombreArchivo2: archivo_n2,
        NombreArchivo3: archivo_n3,
        Filedownload1: archivo_d1,
        Filedownload2: archivo_d2,
        Filedownload3: archivo_d3,
        Ruta1: archivo_r1,
        Ruta2: archivo_r2,
        Ruta3: archivo_r3
    };

    if (probar) {
        PopupPosition();
        $.ajax({
            url: '../EvaluacionEstandarMinimo/EdicionCalificacion',
            type: 'post',
            data: { objCalificacion: objCalificacion }
        }).done(function (response) {
            if (response != null && response.Mensaje == 'OK') {

                swal({
                    title: 'Estimado Usuario',
                    text: response.MensajeVal,
                    type: "success",
                    closeOnConfirm: true
                },
    function () {
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
    });
            }
            else {
                    swal('Atención', response.MensajeVal);
            }
            OcultarPopupposition();
        }).fail(function (responde) {
            OcultarPopupposition();
        });
    }
    






}
function editar_criterioev1() {
    console.log('editar2');
    var idEval = $('#ideval').val();
    var idReg = $('#IdReg').val();
    var idCiclo = $("#Ciclo").val();
    var probar = true;


    var calificacion = 0;
    var opcionNoAplica = 0;
    var actividades = new Array();
    var justificacion = '';

    var tableBody = $('#gridacts tbody');

    //Obtiene calificación
    $('.opc-calificacion').each(function (elem) {
        if ($(this).is(':checked'))
            calificacion = $(this).attr('id');
    });

    if (calificacion <= 0) {
        swal({
            title: "Atención",
            text: 'Debe realizar una calificación para editar el registro.',
            showCancelButton: false,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "OK",
            type: "warning",
            closeOnConfirm: true
        })
        //swal('Atención', 'Debe realizar una calificación para editar el registro.');
        return false;
    } else if (calificacion == 2) {
        //Captar Actvidades nuevas
        var ListaActividades = new Array();
        var contActs = 0;
        $('#gridacts > tbody').find('tr.nueva_fila').each(function () {
            var row = $(this);
            var nuevaActividad = '';
            var responsable = '';
            var fechaFin = '';


            var n = 0;
            row.find('td').each(function () {
                row1 = $(this);
                if (n == 0) {
                    nuevaActividad = row1[0].innerText;
                }
                if (n == 1) {
                    responsable = row1[0].innerText;
                }
                if (n == 2) {
                    fechaFin = row1[0].innerText;
                }
                n++;
            });

            var idrow = row.attr('name');


            var datos = {
                Descripcion: nuevaActividad,
                Responsable: responsable,
                FechaFin: fechaFin,
                Accion: 'nuevo',
                Id_Actividad_String: idrow
            };

            ListaActividades.push(datos);
            contActs++;
        });

        $('#gridacts > tbody').find('tr.fila_existente').each(function () {
            var row = $(this);
            var nuevaActividad = '';
            var responsable = '';
            var fechaFin = '';

            var n = 0;
            row.find('td').each(function () {
                row1 = $(this);
                if (n == 0) {
                    nuevaActividad = row1[0].innerText;
                }
                if (n == 1) {
                    responsable = row1[0].innerText;
                }
                if (n == 2) {
                    fechaFin = row1[0].innerText;
                }
                n++;
            });


            var idrow = row.attr('name');
            var edicion = row.attr('estado');
            if (edicion == 'sin') {
                contActs++;
            }
            var accion = 'sin';


            if (edicion == 'editado') {
                accion = 'editado';
                contActs++;
            }
            if (edicion == 'eliminado') {
                accion = 'eliminado';
            }
            var datos = {
                Descripcion: nuevaActividad,
                Responsable: responsable,
                FechaFin: fechaFin,
                Accion: accion,
                Id_Actividad_String: idrow
            };


            ListaActividades.push(datos);

        });

        if (contActs <= 0) {
            swal({
                title: "Atención",
                text: 'Debe agregar al menos una actividad para continuar.',
                showCancelButton: false,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "OK",
                type: "warning",
                closeOnConfirm: true
            })
            //swal('Atención', 'Debe agregar al menos una actividad para continuar.');
            $('.opc-calificacion').prop('checked', false);
            return false;
        }

    } else if (calificacion == 3) {
        $('.opc-opcionnoaplica').each(function (elem) {
            if ($(this).is(':checked'))
                opcionNoAplica = $(this).attr('id');
        });

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

            var justreplace = '';
            if (justificacion != null) {
                justreplace = $.trim(justificacion);
            }
            if (justreplace == '') {
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
    //var cicloGuardo = sessionStorage.getItem('CicloActual');


    var archivo_n1 = $("#Archivo1").val();
    var archivo_n2 = $("#Archivo2").val();
    var archivo_n3 = $("#Archivo3").val();

    var archivo_d1 = $("#Archivo_s1").val();
    var archivo_d2 = $("#Archivo_s2").val();
    var archivo_d3 = $("#Archivo_s3").val();

    var archivo_r1 = $("#Archivo1_c").val();
    var archivo_r2 = $("#Archivo2_c").val();
    var archivo_r3 = $("#Archivo3_c").val();

    var objCalificacion = {
        IdCiclo: idCiclo,
        IdCriterio: idReg,
        IdValoracionCriterio: calificacion,
        Justificacion: justificacion,
        Actividades: ListaActividades,
        IdEvaluacion: idEval,
        NombreArchivo1: archivo_n1,
        NombreArchivo2: archivo_n2,
        NombreArchivo3: archivo_n3,
        Filedownload1: archivo_d1,
        Filedownload2: archivo_d2,
        Filedownload3: archivo_d3,
        Ruta1: archivo_r1,
        Ruta2: archivo_r2,
        Ruta3: archivo_r3
    };

    if (probar) {
        PopupPosition();
        $.ajax({
            url: '../EvaluacionEstandarMinimo/EdicionCalificacion',
            type: 'post',
            data: { objCalificacion: objCalificacion }
        }).done(function (response) {
            if (response != null && response.Mensaje == 'OK') {

                swal({
                    title: 'Estimado Usuario',
                    text: response.MensajeVal,
                    type: "success",
                    closeOnConfirm: true
                },
    function () {
        if (response.CicloCalificado)
            window.location.href = '../EvaluacionEstandarMinimo/Editar?ideval=' + idEval
        if (response.TerminaCalfEstMin)
            window.location.href = '../EvaluacionEstandarMinimo/Editar?ideval=' + idEval
        window.location.href = '../EvaluacionEstandarMinimo/Editar?ideval=' + idEval
    });
            }
            else {
                swal('Atención', response.MensajeVal);
            }
            OcultarPopupposition();
        }).fail(function (responde) {
            OcultarPopupposition();
        });
    }
}
$(document).ready(function () { 
    var edicion = $('#edicion').val();
    if (edicion == "edicion") {
        $('.fromedicion').hide();
        $('.fromedicion1').show();
    }
});











