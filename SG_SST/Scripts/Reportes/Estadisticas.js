





function SeleccionarReporteDesempeñoDelSistema() {

    var TipoEstadistica = $("#TipoEstadisticaSis").val();

    switch (TipoEstadistica) {
        case "DesempeñoDelSistema":
            $("#divAnio").show();
            $("#IDReportes").hide();
            break;
        case "GestiónDelRiesgo":
            $("#divAnio").show();
            $("#IDReportes").hide();
            break;
        case "EntrenamientoSGSST":
            $("#divAnio").show();
            $("#IDReportes").hide();
            break;
    }
}

function SeleccionarReporteDesempeñoSistema() {

    var anio = $("#anio").val();
    var TipoEstadistica = $("#TipoEstadisticaSis").val();


    if (anio == "") {

        swal({
            type: 'warning',
            title: 'Estimado Usuario:',
            text: 'El párametro año es obligatorio',
            confirmButtonColor: '#7E8A97'
        });

        return false;
    }

    switch (TipoEstadistica) {
        case "DesempeñoDelSistema":

            $.ajax({

                data: { anio: anio },
                url: urlBase + '/ReportesAplicacion/ReporteDesempeñoDelSistema',
                type: 'POST',

            });
            location.reload(true);
            OcultarPopupposition();
            break;

        case "GestiónDelRiesgo":

            $.ajax({

                data: { anio: anio },
                url: urlBase + '/ReportesAplicacion/ReporteGestionDelRiesgo',
                type: 'POST',

            });
            location.reload(true);
            OcultarPopupposition();
            break;

        case "EntrenamientoSGSST":

            $.ajax({

                data: { anio: anio },
                url: urlBase + '/ReportesAplicacion/ReporteEntrenamientoSGSST',
                type: 'POST',

            });
            location.reload(true);
            OcultarPopupposition();
            break;
    }


}

function SeleccionarEstadisticasComunicaciones() {

    var TipoEstadistica = $("#estadisticasComunicaciones").val();

    switch (TipoEstadistica) {
        case "Comunicaciones":
            $("#divEstadisticasComunicaciones").hide();
            $("#paramCom").show();
            $("#divAnioCom").show();
            $("#divEncuesta").hide();
            break;

        case "Encuestas":
            $("#divEstadisticasComunicaciones").hide();
            $("#paramCom").show();
            $("#divAnioCom").show();
            $("#divEncuesta").hide();
            break;

        case "TabulacionDeEncuestas":
            $("#divEstadisticasComunicaciones").hide();
            $("#paramCom").show();
            $("#divAnioCom").hide();
            $("#divEncuesta").show();
            break;

        case "TabulacionDeEncuestasDatos":
            $("#divEstadisticasComunicaciones").hide();
            $("#paramCom").show();
            $("#divAnioCom").hide();
            $("#divEncuesta").show();
            break;

        case "ComunicacionesDatos":
            $("#divEstadisticasComunicaciones").hide();
            $("#paramCom").show();
            $("#divAnioCom").show();
            $("#divEncuesta").hide();
            break;

        case "EncuestasDatos":
            $("#divEstadisticasComunicaciones").hide();
            $("#paramCom").show();
            $("#divAnioCom").show();
            $("#divEncuesta").hide();
            break;

    }
}

function MostrarEstadisticasComunicaciones() {

    var TipoEstadistica = $("#estadisticasComunicaciones").val();
    var anio = $("#anioCom").val();
    var encuesta = $("#Encuesta").val();
    var encuestaTexto = $("#Encuesta option:selected").html();
    switch (TipoEstadistica) {
        case "Comunicaciones":

            if (anio == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El párametro año es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }
            break;

        case "Encuestas":

            if (anio == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El párametro año es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }
            break;

        case "TabulacionDeEncuestas":


            if (encuesta == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El párametro Encuesta es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }
            break;

        case "TabulacionDeEncuestasDatos":


            if (encuesta == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El párametro Encuesta es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }
            break;

        case "ComunicacionesDatos":

            if (anio == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El párametro año es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }
            break;

        case "EncuestasDatos":

            if (anio == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El párametro año es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }
            break;

    }
    if ($("#formEstadisticasComunicaciones").valid()) {
        PopupPosition();
        switch (TipoEstadistica) {
            case "Comunicaciones":
                $.ajax({
                    data: { anio: anio },
                    url: urlBase + '/ReportesAplicacion/EstadisticaComunicaciones',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;

            case "Encuestas":
                $.ajax({
                    data: { anio: anio },
                    url: urlBase + '/ReportesAplicacion/EstadisticasEncuestas',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;

            case "TabulacionDeEncuestas":
                $.ajax({
                    data: { encuesta: encuesta },
                    url: urlBase + '/ReportesAplicacion/EstadisticasTabulacionEncuestas',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;

            case "TabulacionDeEncuestasDatos":
                $.ajax({
                    data: { encuesta: encuesta, encuestaTexto: encuestaTexto },
                    url: urlBase + '/ReportesAplicacion/EstadisticasTabulacionEncuestasDatos',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;

            case "ComunicacionesDatos":
                $.ajax({
                    data: { anio: anio },
                    url: urlBase + '/ReportesAplicacion/EstadisticaComunicacionesDatos',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;

            case "EncuestasDatos":
                $.ajax({
                    data: { anio: anio },
                    url: urlBase + '/ReportesAplicacion/EstadisticasEncuestasDatos',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;
        }
    }
}