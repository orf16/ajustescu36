var jqXHRData;
var class_css_header = 'style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center; vertical-align:middle; text-transform:uppercase"';
var class_css = '' + class_css_btxt + '';
var class_css_btxt = 'style="border-right: 2px solid lightslategray; vertical-align:middle; text-align:center"';
var class_css_btxtobser = 'style="border-right: 2px solid lightslategray; vertical-align:middle; text-align:center; color:#888"';
var tamanoPersona=0;
var tamanoRecurso=0;
var tamanoSistemasProcesos=0;
$(function () {


   
    darFormatoSoloNumeros("documentoBI");
	obtenerTamanoPersona();
	obtenerTamanoRecurso();
	obtenerTamanoSistemasProcesos();
    $("#identificacion_sede").css("background-color", "whitesmoke").css("color", "#black").css("border", "groove");;
    $("#razon_social").css("background-color", "whitesmoke").css("color", "#black").css("border", "groove");;
    $("#direccion_sede").css("background-color", "whitesmoke").css("color", "#black").css("border", "groove");;
    $("#telefono_sede").css("background-color", "whitesmoke").css("color", "#black").css("border", "groove");;
    $("#correo_electronico").css("background-color", "whitesmoke").css("color", "#black").css("border", "groove");;
    $("#departamento_sede").css("background-color", "whitesmoke").css("color", "#black").css("border", "groove");;
    $("#municipio_sede").css("background-color", "whitesmoke").css("color", "#black").css("border", "groove");;
    $("#actividad_economica").css("background-color", "whitesmoke").css("color", "#black").css("border", "groove");;
    $("#representante").css("background-color", "whitesmoke").css("color", "#black").css("border", "groove");;


    $("#tabs").tabs();
    $("#tabs").tabs("enable", 0);
    $("#tabs").tabs("disable", 1);
    $("#tabs").tabs("disable", 2);
    $("#tabs").tabs("disable", 3);
    $("#tabs").tabs("disable", 4);
    $("#tabs").tabs("disable", 5);
    $("#tabs").tabs("disable", 6);
    $("#tabs").tabs("disable", 7);
    $("#tabs").tabs("disable", 8);

    $('#trabajadores_hdesde').timepicker({ 'step': 15 });
    $('#trabajadore_hhasta').timepicker({ 'step': 15 });

    $('#contratista_hdesde').timepicker({ 'step': 15 });
    $('#contratista_hhasta').timepicker({ 'step': 15 });

    $('#visitante_hdesde').timepicker({ 'step': 15 });
    $('#visitantte_hhasta').timepicker({ 'step': 15 });

    $('#cliente_hdesde').timepicker({ 'step': 15 });
    $('#cliente_hhasta').timepicker({ 'step': 15 });

    //CargaMasiva();
    //CargarBDMasiva();
    //CargarBDMasiva3();

    CargarEstructuraOrg();
    //Handler for "Start upload" button 
    $("#hl-start-upload").on('click', function () {
        if (jqXHRData) {
            jqXHRData.submit();
        }
        return false;
    });

    //$("#hl-start-upload1").on('click', function () {
    //	if (jqXHRData) {
    //		jqXHRData.submit();
    //	}
    //	return false;
    //}); 

    //$("#hl-start-upload2").on('click', function () {
    //	if (jqXHRData) {
    //		jqXHRData.submit();
    //	}
    //	return false;
    //}); 

    //$("#hl-start-upload3").on('click', function () {
    //	if (jqXHRData) {
    //		jqXHRData.submit();
    //	}
    //	return false;
    //}); 

    ////////////////////////////////////
    CargrPlanSeguridadFisica();
    $("#hl-start-upload_frenteaccion_adjunto1").on('click', function () {
        if (jqXHRData) {
            jqXHRData.submit();
        }
        return false;
    });
    CargarPlanAtencion();
    $("#hl-start-upload_frenteaccion_adjunto2").on('click', function () {
        if (jqXHRData) {
            jqXHRData.submit();
        }
        return false;
    });
    CargarPlanContraincendios();
    $("#hl-start-upload_frenteaccion_adjunto3").on('click', function () {
        if (jqXHRData) {
            jqXHRData.submit();
        }
        return false;
    });
    CargarPlanEvacuacion();
    $("#hl-start-upload_frenteaccion_adjunto4").on('click', function () {
        if (jqXHRData) {
            jqXHRData.submit();
        }
        return false;
    });
    CargarRutasEvacuacion();
    $("#hl-start-upload_frenteaccion_adjunto5").on('click', function () {
        if (jqXHRData) {
            jqXHRData.submit();
        }
        return false;
    });


    CargarGeoInterno();
    $("#hl-start-upload_adjuntos").on('click', function () {
        if (jqXHRData) {
            jqXHRData.submit();
        }       
        return false;
    });

    //////////////////////////////////////////////
    CargarEncuentro();
    $("#hl-start-upload_adjuntos1").on('click', function () {
        if (jqXHRData) {
            jqXHRData.submit();
        }        
        return false;
    });

    CargarHidrantes();
    $("#hl-start-upload_adjuntos2").on('click', function () {
        if (jqXHRData) {
            jqXHRData.submit();
        }       
        return false;
    });

    //Plan de Ayuda
    CargarPlanAyuda();
    $("#hl-start-upload_adjuntoPAM").on('click', function () {
        if (jqXHRData) {
            jqXHRData.submit();
        }
        return false;
    });



});

//function fileValidation() {
//    var fileInput = $('#upload_adjuntos').val();
//    //var filePath = fileInput.value;
//    if (fileInput.name == "" || fileInput.name == null) {
//        swal("Estimado Usuario", 'Por favor cargue un archivo', "warning");
//    }
//}

function CargarEncuentro() {
    'use strict';
    $('#upload_adjuntos1').fileupload({
        url: '/PlanEmergencias/CargarEncuentro',
        dataType: 'json',
        add: function (e, data) {
            jqXHRData = data
        },
        done: function (event, data) {
            if (data.result.isUploaded) {

            }
            else {

            }
            //alert(data.result.message);
            $("#upload_adjuntos1_tmp").val(data.result.message);
            if (data.result.message != "error") {
                GeoreferenciacionEncuentro();
                $("#upload_adjuntos1").val("");
                swal("Estimado Usuario", 'El archivo ha sido cargado satisfactoriamente', "success");
            }
            else {
                swal("Estimado Usuario", 'Solo se admiten archivos de tipo Imagen', "warning");
            }
        },
        fail: function (event, data) {
            if (data.files[0].error) {
                //alert(data.files[0].error);
            }
        }
    });
}

function CargarHidrantes() {
    'use strict';
    $('#upload_adjuntos2').fileupload({
        url: '/PlanEmergencias/CargarHidrantes',
        dataType: 'json',
        add: function (e, data) {
            jqXHRData = data
        },
        done: function (event, data) {
            if (data.result.isUploaded) {

            }
            else {

            }
            //alert(data.result.message);
            $("#upload_adjuntos2_tmp").val(data.result.message);
            if (data.result.message != "error") {
                GeoreferenciacionHidrantes();
                $('#upload_adjuntos2').val("");
                swal("Estimado Usuario", 'El archivo ha sido cargado satisfactoriamente', "success");
            }
            else {
                swal("Estimado Usuario", 'Solo se admiten archivos de Imagen', "warning");
            }
        },
        fail: function (event, data) {
            if (data.files[0].error) {
                //alert(data.files[0].error);
            }
        }
    });
}

function ActualizarEncuentro() {
    $.ajax({
        type: 'GET',
        url: '/PlanEmergencias/ActualizarEncuentro',
        data: { isede: $("#IdSede").val(), adjunto: $("#upload_adjuntos1_tmp").val() },
        traditional: true,
        success: function (result) {


        }
    });
}

function ActualizarHidrantes() {
    $.ajax({
        type: 'GET',
        url: '/PlanEmergencias/ActualizarHidrantes',
        data: { isede: $("#IdSede").val(), adjunto: $("#upload_adjuntos2_tmp").val() },
        traditional: true,
        success: function (result) {


        }
    });
}

$("#cargar_img1").click(function () {
    $.ajax({
        type: 'GET',
        url: '/PlanEmergencias/ObtenerImagenIMG1',
        data: { IdSede: $("#IdSede").val() },
        traditional: true,
        success: function (Thumbnails) {
            if (Thumbnails != "") {
                $('#myModalimg').modal('show');
                $('#ImgCarga').attr("src", Thumbnails);
            } else
                swal("Estimado Usuario", "No se ha guardado ninguna Imagen.", "warning");

        }
    });
});

$("#cargar_img2").click(function () {
    $.ajax({
        type: 'GET',
        url: '/PlanEmergencias/ObtenerImagenIMG2',
        data: { IdSede: $("#IdSede").val() },
        traditional: true,
        success: function (Thumbnails) {
            if (Thumbnails != "") {
                $('#myModalimg').modal('show');
                $('#ImgCarga').attr("src", Thumbnails);
            } else
                swal("Estimado Usuario", "No se ha guardado ninguna Imagen.", "warning");

        }
    });
});

function CargarGeoInterno() {
    'use strict';
    $('#upload_adjuntos').fileupload({
        url: '/PlanEmergencias/SubirArchivoIMG',
        dataType: 'json',
        add: function (e, data) {
            jqXHRData = data
        },
        done: function (event, data) {
            if (data.result.isUploaded) {

            }
            else {

            }
            //alert(data.result.message);
            $("#upload_adjuntos_tmp").val(data.result.message);
            if (data.result.message != "error") {
                GeoreferenciacionIMG();
                $('#upload_adjuntos').val("");
                swal("Estimado Usuario", 'El archivo ha sido cargado satisfactoriamente', "success");
            }
            else {
                swal("Estimado Usuario", 'Solo se admiten archivos de Imagen', "warning");
            }
        },
        fail: function (event, data) {
            if (data.files[0].error) {
                //alert(data.files[0].error);
            }
        }
    });
}

$("#cargar_img").click(function () {
    $.ajax({
        type: 'GET',
        url: '/PlanEmergencias/ObtenerImagenIMG',
        data: { IdSede: $("#IdSede").val() },
        traditional: true,
        success: function (Thumbnails) {
            if (Thumbnails != "") {
                $('#myModalimg').modal('show');
                $('#ImgCarga').attr("src", Thumbnails);
            } else
                swal("Estimado Usuario", "No se ha guardado ninguna Imagen.", "warning");

        }
    });
});

function CargrPlanSeguridadFisica() {
    $('#upload_frenteaccion_adjunto1').fileupload({
        url: '/PlanEmergencias/CargrPlanSeguridadFisica',
        dataType: 'json',
        add: function (e, data) { jqXHRData = data },
        done: function (event, data) {
            if (data.result.message != "error") {
                $("#adjunto_tmp_upload_frenteaccion_adjunto1").val(data.result.message);
                CargarFrentesAccionAdjuntos();
                $('#upload_frenteaccion_adjunto1').val("");
                swal("Estimado Usuario", 'El archivo ha sido cargado satisfactoriamente', "success");
            }
            else

                swal("Estimado Usuario", 'Recuerde que solo se permiten archivos con lo siguientes formatos PDF, WORD ,EXCEl', "warning");

        },
        fail: function (event, data) { }
    });
}

function CargarPlanAtencion() {
    $('#upload_frenteaccion_adjunto2').fileupload({
        url: '/PlanEmergencias/CargarPlanAtencion',
        dataType: 'json',
        add: function (e, data) { jqXHRData = data },
        done: function (event, data) {
            if (data.result.message != "error") {
                $("#adjunto_tmp_upload_frenteaccion_adjunto2").val(data.result.message);
                CargarFrentesAccionAdjuntos();
                $('#upload_frenteaccion_adjunto2').val("");
                swal("Estimado Usuario", 'El archivo ha sido cargado satisfactoriamente', "success");
            }
            else

                swal("Estimado Usuario", 'Recuerde que solo se permiten archivos con lo siguientes formatos PDF, WORD ,EXCEl', "warning");

        },
        fail: function (event, data) { }
    });
}

function CargarPlanContraincendios() {
    $('#upload_frenteaccion_adjunto3').fileupload({
        url: '/PlanEmergencias/CargarPlanContraincendios',
        dataType: 'json',
        add: function (e, data) { jqXHRData = data },
        done: function (event, data) {
            if (data.result.message != "error") {
                $("#adjunto_tmp_upload_frenteaccion_adjunto3").val(data.result.message);
                CargarFrentesAccionAdjuntos();
                $('#upload_frenteaccion_adjunto3').val("");
                swal("Estimado Usuario", 'El archivo ha sido cargado satisfactoriamente', "success");
            }
            else
                swal("Estimado Usuario", 'Recuerde que solo se permiten archivos con lo siguientes formatos PDF, WORD ,EXCEl', "warning");



        },
        fail: function (event, data) { }
    });

}

function CargarPlanEvacuacion() {
    $('#upload_frenteaccion_adjunto4').fileupload({
        url: '/PlanEmergencias/CargarPlanEvacuacion',
        dataType: 'json',
        add: function (e, data) { jqXHRData = data },
        done: function (event, data) {
            if (data.result.message != "error") {
                $("#adjunto_tmp_upload_frenteaccion_adjunto4").val(data.result.message);
                CargarFrentesAccionAdjuntos();
                $('#upload_frenteaccion_adjunto4').val("");
                swal("Estimado Usuario", 'El archivo ha sido cargado satisfactoriamente', "success");
            }
            else
                swal("Estimado Usuario", 'Recuerde que solo se permiten archivos con lo siguientes formatos PDF, WORD ,EXCEl', "warning");

        },
        fail: function (event, data) { }
    });
}

function CargarRutasEvacuacion() {
    $('#upload_frenteaccion_adjunto5').fileupload({
        url: '/PlanEmergencias/CargarRutasEvacuacion',
        dataType: 'json',
        add: function (e, data) { jqXHRData = data },
        done: function (event, data) {
            if (data.result.message != "error") {
                $("#adjunto_tmp_upload_frenteaccion_adjunto5").val(data.result.message);
                CargarFrentesAccionAdjuntos();
                $('#upload_frenteaccion_adjunto5').val("");
                swal("Estimado Usuario", 'El archivo ha sido cargado satisfactoriamente', "success");
            }
            else
                swal("Estimado Usuario", 'Recuerde que solo se permiten archivos con lo siguientes formatos PDF, WORD ,EXCEl', "warning");

        },
        fail: function (event, data) { }
    });

}

function CargarPlanAyuda() {
    $('#upload_adjuntoPAM').fileupload({
        url: '/PlanEmergencias/CargarPlanAyuda',
        dataType: 'json',
        add: function (e, data) { jqXHRData = data },
        done: function (event, data) {
            if (data.result.message != "error") {
                $("#adjunto_tmp_upload_adjuntoPAM").val(data.result.message);
                swal("Estimado Usuario", 'El archivo ha sido cargado satisfactoriamente', "success");
                cargarAdjuntoPAM();
            }
            else
                swal("Estimado Usuario", 'Recuerde que solo se permiten archivos con lo siguientes formatos PDF, WORD ,EXCEl', "warning");

        },
        fail: function (event, data) { }
    });
}

function cargarAdjuntoPAM() {
    var adjuntoPAM = $("#adjunto_tmp_upload_adjuntoPAM").val();
  

    $.ajax({
        type: 'GET',
        url: '/PlanEmergencias/CargarAdjuntoPAM',
        data: { isede: $("#IdSede").val(), adjuntoPAM: adjuntoPAM},
        traditional: true,
        success: function (result) {
            //$('#pk_id_soporte').val(result);
            swal("Estimado Usuario", 'Los archivos han sido guardados satisfactoriamente', "success");
        }
    });

}

function CargarFrentesAccionAdjuntos() {
    var adjunto1 = $("#adjunto_tmp_upload_frenteaccion_adjunto1").val();
    var adjunto2 = $("#adjunto_tmp_upload_frenteaccion_adjunto2").val();
    var adjunto3 = $("#adjunto_tmp_upload_frenteaccion_adjunto3").val();
    var adjunto4 = $("#adjunto_tmp_upload_frenteaccion_adjunto4").val();
    var adjunto5 = $("#adjunto_tmp_upload_frenteaccion_adjunto5").val();

    $.ajax({
        type: 'GET',
        url: '/PlanEmergencias/CargarFrentesAccionAdjuntos',
        data: { isede: $("#IdSede").val(), adjunto1: adjunto1, adjunto2: adjunto2, adjunto3: adjunto3, adjunto4: adjunto4, adjunto5: adjunto5 },
        traditional: true,
        success: function (result) {
            //$('#pk_id_soporte').val(result);
            swal("Estimado Usuario", 'Los archivos han sido guardados satisfactoriamente', "success");
        }
    });

}

function DescargarArchivoFrente(tipo) {
    $.ajax({
        type: 'POST',
        url: '/PlanEmergencias/DescargarArchivoFrente',
        data: { isede: $("#IdSede").val(), tipo: tipo },
        success: function (result) {
            if (result) {

                window.location = '/PlanEmergencias/Download?file=' + result;
            }

            else {

                swal("Estimado Usuario", 'No existe un archivo para descargar', "warning");
            }

        }

    });

}

function DescargarArchivoPlanAyuda() {
    $.ajax({
        type: 'POST',
        url: '/PlanEmergencias/DescargarArchivoPlanAyuda',
        data: { isede: $("#IdSede").val() },
        success: function (result) {
            if (result) {

                window.location = '/PlanEmergencias/Download?file=' + result;
            }

            else {

                swal("Estimado Usuario", 'No existe un archivo para descargar', "warning");
            }

        }

    });

}
///////////////////////////////////////////////////

//function CargaMasiva() {
//    $('#upload1').fileupload({
//        url: '/PlanEmergencias/SubirArchivoMasivo',
//        dataType: 'json',
//        add: function (e, data) {jqXHRData = data },
//        done: function (event, data) {
//			if(data.result.message!="error"){
//			    swal("Estimado Usuario", 'El archivo ha sido cargado satisfactoriamente', "success");
//				ListarBDInterna($("#IdSede").val());
//			}
//			else
//				swal("Estimado Usuario", 'Solo se admiten archivos de Excel',"warning");

//        },
//        fail: function (event, data) {}
//    });
//}

function CargaMasiva() {

    // e.preventDefault();
    var idSede = $("#IdSede").val();
    var formData = new FormData(document.getElementById("frmEsquemaOrganizacion"));
    formData.append("idSede", idSede);
    //formData.append(f.attr("name"), $(this)[0].files[0]);
    $.ajax({
        url: '/PlanEmergencias/SubirArchivoMasivo',
        type: "post",
        dataType: "html",
        data: formData,
        cache: false,
        contentType: false,
        processData: false
    })
        .done(function (res) {
            $("#mensaje").html("Respuesta: " + res);
        });
}

//function CargarBDMasiva() {
//    $('#upload2').fileupload({
//        url: '/PlanEmergencias/SubirArchivoMasivo2',
//        dataType: 'json',
//        add: function (e, data) {jqXHRData = data },
//        done: function (event, data) {
//			if(data.result.message!="error"){
//			    swal("Estimado Usuario", 'El archivo ha sido cargado satisfactoriamente', "success");
//				ListarBDExterna($("#IdSede").val());
//			}
//			else
//				swal("Estimado Usuario", 'Solo se admiten archivos de Excel',"warning");

//        },
//        fail: function (event, data) {}
//    });
//}

//function CargarBDMasiva3() {
//    $('#upload3').fileupload({
//        url: '/PlanEmergencias/SubirArchivoMasivo3',
//        dataType: 'json',
//        add: function (e, data) {jqXHRData = data },
//        done: function (event, data) {
//			if(data.result.message!="error"){
//			    swal("Estimado Usuario", 'El archivo ha sido cargado satisfactoriamente', "success");
//				ListarBDPlanAyuda($("#IdSede").val());
//			}
//			else
//				swal("Estimado Usuario", 'Solo se admiten archivos de Excel',"warning");

//        },
//        fail: function (event, data) {}
//    });
//}

function CargarEstructuraOrg() {
    'use strict';
    $('#upload').fileupload({
        url: '/PlanEmergencias/CargarEstructuraOrg',
        dataType: 'json',
        add: function (e, data) {
            jqXHRData = data
        },
        done: function (event, data) {
            if (data.result.isUploaded) {

            }
            else {

            }
            //alert(data.result.message);
            if (data.result.message != "error") {
                $("#adjunto_tmp").val(data.result.message);
                $.ajax({
                    type: 'GET',
                    url: '/PlanEmergencias/ActualizarAdjuntos',
                    data: { isede: $("#IdSede").val(), adjunto: $("#adjunto_tmp").val(),adjuntoPAM:$("#adjunto_tmp_upload_adjuntoPAM").val()},
                    traditional: true,
                    success: function (result) {
                        //$('#pk_id_soporte').val(result);
                        swal("Estimado Usuario", 'El archivo ha sido cargado satisfactoriamente', "success");
                    }
                });
            }
            else {
                swal("Estimado Usuario", 'Solo se admiten archivos de Imagen', "warning");
            }
        },
        fail: function (event, data) {
            if (data.files[0].error) {
                //alert(data.files[0].error);
            }
        }
    });
}

$("#cargar").click(function () {
    $.ajax({
        type: 'GET',
        url: '/PlanEmergencias/ObtenerImagen',
        data: { IdSede: $("#IdSede").val() },
        traditional: true,
        success: function (Thumbnails) {
            if (Thumbnails != "") {
                $('#myModalimg').modal('show');
                $('#ImgCarga').attr("src", Thumbnails);
            } else
                swal("Estimado Usuario", "Debe adjuntar una imagen primero", "warning");

        }
    });
});

function GenerarPlanEmergenciaSede() {
    var sede = $("#IdSede").val();
    $.ajax({
        type: 'GET',
        url: '/PlanEmergencias/ObtenerInfoSede',
        data: { isede: sede },
        success: function (result) {
            $("#objetivos").val(result.objetivos);
            $("#alcance").val(result.alcance);
            $("#razon_social").val(result.razon_social);
            $("#identificacion_sede").val(result.identificacion_sede);
            $("#direccion_sede").val(result.direccion_sede);
            $("#telefono_sede").val(result.telefono_sede);
            $("#correo_electronico").val(result.correo_electronico);
            $("#departamento_sede").val(result.departamento_sede);
            $("#municipio_sede").val(result.municipio_sede);
            $("#actividad_economica").val(result.actividad_economica);
            $("#representante").val(result.representante);
            $("#lindero_norte").val(result.lindero_norte);
            $("#lindero_sur").val(result.lindero_sur);
            $("#lindero_occidente").val(result.lindero_occidente);
            $("#lindero_oriente").val(result.lindero_oriente);
            $("#acceso_principales").val(result.acceso_principales);
            $("#acceso_alternas").val(result.acceso_alternas);
            $("#trabajadores_cantidad").val(result.trabajadores_cantidad);
            $("#trabajadores_hdesde").val(result.trabajadores_hdesde);
            $("#trabajadore_hhasta").val(result.trabajadore_hhasta);
            $("#contratista_cantidad").val(result.contratista_cantidad);
            $("#contratista_hdesde").val(result.contratista_hdesde);
            $("#contratista_hhasta").val(result.contratista_hhasta);

            // Visitante
            $("#visitante_cantidad").val(result.visitante_cantidad);
            $("#visitante_hdesde").val(result.visitante_hdesde);
            $("#visitantte_hhasta").val(result.visitantte_hhasta);

            $("#cliente_cantidad").val(result.cliente_cantidad);
            $("#cliente_hdesde").val(result.cliente_hdesde);
            $("#cliente_hhasta").val(result.cliente_hhasta);
            $("#bo_tratamiento_especial").prop("checked", result.bo_tratamiento_especial);

            $("#cual").val(result.cual);
            $("#ventilacion_mecanica").val(result.ventilacion_mecanica);
            $("#ascensores").val(result.ascensores);
            $("#sotanos").val(result.sotanos);
            $("#red_hidraulica").val(result.red_hidraulica);
            $("#transformadores").val(result.transformadores);
            $("#plantas_electricas").val(result.plantas_electricas);
            $("#escaleras").val(result.escaleras);
            $("#zonas_parqueo").val(result.zonas_parqueo);
            $("#areas_especiales").val(result.areas_especiales);
            $("#estructurales_descripcion").val(result.estructurales_descripcion);
            $("#estructurales_ubicacion").val(result.estructurales_ubicacion);
            $("#equipos_descripcion").val(result.equipos_descripcion);
            $("#equipos_ubicacion").val(result.equipos_ubicacion);
            $("#insumos_descripcion").val(result.insumos_descripcion);
            $("#insumos_ubicacion").val(result.insumos_ubicacion);
            $("#bo_externo").prop("checked", result.bo_externo);
            $("#bo_colegio").prop("checked", result.bo_colegio);
            $("#bo_iglesia").prop("checked", result.bo_iglesia);
            $("#bo_comercial").prop("checked", result.bo_comercial);
            $("#bo_centro_atencion").prop("checked", result.bo_centro_atencion);
            $("#bo_parque").prop("checked", result.bo_parque);
            $("#bo_otro").prop("checked", result.bo_otro);
            $("#tab3_cual").val(result.tab3_cual);
            $("#bo_ZonaIndustrial").prop("checked", result.bo_ZonaIndustrial);
            $("#bo_ZonaResidencial").prop("checked", result.bo_ZonaResidencial);
            $("#bo_ZonaComercial").prop("checked", result.bo_ZonaComercial);
            $("#bo_ZonaMixta").prop("checked", result.bo_ZonaMixta);

            $("#punto_encuentro").val(result.ubicacion_hidrantes);
            $("#ubicacion_hidrantes").val(result.punto_encuentro);

            $("#plan_seguridadfisica").val(result.plan_seguridadfisica);
            $("#plan_primerosaux").val(result.plan_primerosaux);
            $("#plan_contraincendios").val(result.plan_contraincendios);
            $("#plan_Evacuacion").val(result.plan_Evacuacion);
            $("#nombrecoordinador").val(result.nombrecoordinador);
            $("#tab7_objetivos").val(result.tab7_objetivos);
            $("#estructura").val(result.estructura);
            $("#proc_coordinacion").val(result.proc_coordinacion);
            $("#proc_internos").val(result.proc_internos);
            $("#proc_externos").val(result.proc_externos);
            $("#mecanismos_alarma").val(result.mecanismos_alarma);
            $("#simulacros").val(result.simulacros);
            $("#instructivo_evacuacion").val(result.instructivo_evacuacion);
            $("#proc_retorno").val(result.proc_retorno);
            $("#fk_id_sede_generalidades").val(sede);
            $("#fk_id_sede_infogeneral").val(sede);
            $("#fk_id_sede_descocupacion").val(sede);
            $("#fk_id_sede_cinstalaciones").val(sede);
            $("#fk_id_sede_elementos").val(sede);
            $("#fk_id_sede_georeferenciacion").val(sede);
            $("#fk_id_sede_roles").val(sede);
            $("#fk_id_sede_frenteaccion").val(sede);
            $("#fk_id_sede_proc_normalizados").val(sede);
            $("#fk_id_sede_nivelemergencia").val(sede);
            $("#fk_id_sede_recursosh").val(sede);
            $("#fk_id_sede_recursostecnicos").val(sede);

            borrarContenidoLabel();

            var upUn = result.interno_img;
            if (upUn == null) {
                $("#nombreUpload").text("");
            }
            else {
                var titl = upUn.substring(upUn.indexOf("_") + 1, upUn.length);
                $("#nombreUpload").text(titl);
            }
            var upUn1 = result.punto_encuentro_img;
            if (upUn1 == null) {
                $("#nombreUpload1").text("");
            }
            else {
                var titl1 = upUn1.substring(upUn1.indexOf("_") + 1, upUn1.length);
                $("#nombreUpload1").text(titl1);
            }
            var upUn2 = result.ubicacion_hidrantes_img;
            if (upUn2 == null) {
                $("#nombreUpload2").text("");
            }
            else {
                var titl2 = upUn2.substring(upUn2.indexOf("_") + 1, upUn2.length);
                $("#nombreUpload2").text(titl2);
            }            

            var pl1 = result.plan_seguridadfisica_img;
            if (pl1 == null) {
                $("#nombreUploadSeguridadBasica").text("");
            }
            else {
                var nom1 = pl1.substring(pl1.indexOf("_") + 1, pl1.length);
                $("#nombreUploadSeguridadBasica").text(nom1);
            }

            var pl2 = result.plan_AtencionMedica_img;
            if (pl2 == null) {
                $("#nombreUploadPlanAtencionMedica").text("");
            }
            else {
                var nom2 = pl2.substring(pl2.indexOf("_") + 1, pl2.length);
                $("#nombreUploadPlanAtencionMedica").text(nom2);
            }

            var pl3 = result.plan_contraincendios_img;
            if (pl3 == null) {
                $("#nombreUploadContraIncendios").text("");
            }
            else {
                var nom3 = pl3.substring(pl3.indexOf("_") + 1, pl3.length);
                $("#nombreUploadContraIncendios").text(nom3);
            }

            var pl4 = result.plan_Evacuacion_img;
            if (pl4 == null) {
                $("#nombreUploadPlanEvacuacion").text("");
            }
            else {
                var nom4 = pl4.substring(pl4.indexOf("_") + 1, pl4.length);
                $("#nombreUploadPlanEvacuacion").text(nom4);
            }

            var pl5 = result.plan_rutas_evac_img;
            if (pl5 == null) {
                $("#nombreRutaEvacuacion").text("");
            }
            else {
                var nom5 = pl5.substring(pl5.indexOf("_") + 1, pl5.length);
                $("#nombreRutaEvacuacion").text(nom5);
            }

            ListarRTecnicos(sede);
            ListarHR(sede);
            ListarProcedimientosOperativosNormalizados(sede);
            ListarRoles(sede);
            ListarNivelesEmergencia(sede);
            ListarBDInterna(sede);
            ListarBDExterna(sede);
            ListarBDPlanAyuda(sede);
            AnalisisRiesgo();
		

            for (i = 0; i <= 7; i++) {
                $("#tabs").tabs("enable", i);
            }

            swal("Estimado Usuario", "La interfaz de la Sede ha sido generada satisfactoriamente", "success");
            $("#tabs").tabs({ active: 0 });
        }
    });
}

function Siguiente(numtab) {
    if ($("#IdSede").val() == "") {
        swal("Estimado Usuario", "Debe seleccionar una Sede", "warning");
        return;
    }

    switch (numtab) {
        case 1:
            $("#tabs").tabs("enable", 0);
            $("#tabs").tabs("enable", numtab);
            //Generalidades(numtab);
            InformacionGeneral(numtab);
            break;
        case 2:
            $("#tabs").tabs("enable", numtab);
            //InformacionGeneral(numtab);
            Generalidades(numtab);
            break;
        case 3:
            $("#tabs").tabs("enable", numtab);
            $("#tabs").tabs({ active: numtab });
            LimpiarInputGeo();
            GeoreferenzacionTab(numtab);
            break;
        case 4:
            $("#tabs").tabs("enable", numtab);
            $("#tabs").tabs({ active: numtab });
            guardarriesgo(numtab);
            break;
        case 5:
            $("#tabs").tabs("enable", numtab);
            $("#tabs").tabs({ active: numtab });
            break;
        case 6:
            $("#tabs").tabs("enable", numtab);
            $("#tabs").tabs({ active: numtab });
            break;
        case 7:
            $("#tabs").tabs("enable", numtab);
            $("#tabs").tabs({ active: numtab });
            LimpiarInputFrentesA();
            FrentesAccion(numtab);
            break;
        case 8:
            $("#tabs").tabs("enable", numtab);
            ProcedimientosOperativosNormalizados();
            break;
    }
}



function InformacionGeneral(numtab) {
    $.ajax({
        type: 'POST',
        url: '/PlanEmergencias/GuardarInformacionGeneral',
        data: $("#frmInformacionGeneral").serialize(),
        traditional: true,
        success: function (result) {
            DescripcionOcupacion();
            $("#tabs").tabs({ active: numtab });
        }
    });
}


function DescripcionOcupacion() {
    $.ajax({
        type: 'POST',
        url: '/PlanEmergencias/GuardarDescripcionOcupacion',
        data: $("#frmDescripcionOcupacion").serialize(),
        traditional: true,
        success: function (result) {
            CaracteristicasInstalacion();
        }
    });
}

function CaracteristicasInstalacion() {
    $.ajax({
        type: 'POST',
        url: '/PlanEmergencias/GuardarCaracteristicasInstalacion',
        data: $("#frmCaracteristicasInstalacion").serialize(),
        traditional: true,
        success: function (result) {
            GuardarElementos();
        }
    });
}

function GuardarElementos() {
    $.ajax({
        type: 'POST',
        url: '/PlanEmergencias/GuardarElementos',
        data: $("#frmelementos").serialize(),
        traditional: true,
        success: function (result) {
            //CaracteristicasInstalacion();
            $("#tabs").tabs({ active: numtab });
        }
    });
}

function Generalidades(numtab) {
    $.ajax({
        type: 'POST',
        url: '/PlanEmergencias/GuardarGeneralidades',
        data: $("#frmgeneralidades").serialize(),
        traditional: true,
        success: function (result) {
            $("#tabs").tabs({ active: numtab });
        }
    });
}
function Georeferenciacion() {
    $.ajax({
        type: 'POST',
        url: '/PlanEmergencias/GuardarGeoreferenciacion',
        data: $("#frmGeoreferenciacion").serialize(),
        traditional: true,
        success: function (result) {
            //ActualizarIMG();
            //ActualizarEncuentro();
            //ActualizarHidrantes();
            swal("Estimado Usuario", "La Georeferenciación se ha guardado satisfactoriamente", "success");
            //$( "#tabs" ).tabs({ active: 3 });
        }
    });
}

function GeoreferenciacionIMG() {
    $.ajax({
        type: 'POST',
        url: '/PlanEmergencias/GuardarGeoreferenciacion',
        data: $("#frmGeoreferenciacion").serialize(),
        traditional: true,
        success: function (result) {
            ActualizarIMG();            
        }
    });
}

function GeoreferenciacionEncuentro() {
    $.ajax({
        type: 'POST',
        url: '/PlanEmergencias/GuardarGeoreferenciacion',
        data: $("#frmGeoreferenciacion").serialize(),
        traditional: true,
        success: function (result) {
            ActualizarEncuentro();
        }
    });
}

function GeoreferenciacionHidrantes() {
    $.ajax({
        type: 'POST',
        url: '/PlanEmergencias/GuardarGeoreferenciacion',
        data: $("#frmGeoreferenciacion").serialize(),
        traditional: true,
        success: function (result) {
            ActualizarHidrantes();
        }
    });
}

function ActualizarIMG() {
    $.ajax({
        type: 'GET',
        url: '/PlanEmergencias/ActualizarAdjuntosIMG',
        data: { isede: $("#IdSede").val(), adjunto: $("#upload_adjuntos_tmp").val() },
        traditional: true,
        success: function (result) {
        }
    });
}

function FrentesAccion(numtab) {
    $.ajax({
        type: 'POST',
        url: '/PlanEmergencias/GuardarFrentesAccion',
        data: $("#frmFrentesAccion").serialize(),
        traditional: true,
        success: function (result) {
            $("#tabs").tabs({ active: numtab });
        }
    });
}

function GeoreferenzacionTab(numtab) {
    $.ajax({
        type: 'POST',
        url: '/PlanEmergencias/GuardarGeoreferenciacion',
        data: $("#frmGeoreferenciacion").serialize(),
        traditional: true,
        success: function (result) {
            $("#tabs").tabs({ active: numtab });
        }
    });
}

function ProcedimientosOperativosNormalizados() {
    var sede = $("#IdSede").val();
    $.ajax({
        type: 'POST',
        url: '/PlanEmergencias/GuardarProcedimientosOperativosNormalizados',
        data: $("#frmProcedimientosOperativosNormalizados").serialize(),
        traditional: true,
        success: function (result) {
            $('#myModal0').modal('hide');
            ListarProcedimientosOperativosNormalizados(sede);
        }
    });

}

//function GuardarNivelEmergencia() {
//    var sede = $("#IdSede").val();
//    $.ajax({
//        type: 'POST',
//        url: '/PlanEmergencias/GuardarNivelEmergencia',
//        data: $("#frmNivelEmergencia").serialize(),
//        traditional: true,
//        success: function (result) {
//            $('#myModal2').modal('hide');
//            ListarNivelesEmergencia(sede);
//        }
//    });
//}

function ListarNivelesEmergencia(isede) {
    $.ajax({
        type: 'GET',
        url: '/PlanEmergencias/ListarNivelesEmergencia',
        data: { isede: isede },
        success: function (result) {
            var tHtml = "";
            $("#gridemergencia").empty();
            tHtml += '<tr class="titulos_tabla">';
            tHtml += '<th ' + class_css_header + '>Nivel</td>';
            tHtml += '<th ' + class_css_header + '>Tipo de Emergencia</th>';
            tHtml += '<th ' + class_css_header + '>Acción</th>';

            ///tHtml += '<th style="border-right: 2px solid lightslategray; text-align:center">Acciones</th>';
            tHtml += '</tr>';
            $.each(result, function (key, val) {
                var id = val.pk_id_nivelemergencia;
                tHtml += "<tr>";
                tHtml += '<td ' + class_css_btxt + '>' + val.nivel + '</td>';
                tHtml += '<td ' + class_css_btxt + '>' + val.emergencia + '</td>';
                //tHtml += '<td>&nbsp;<a href="#" class="btn btn-search btn-md" title="Editar"><span class="glyphicon glyphicon-pencil"></span></a>&nbsp;';
                tHtml += '<td align="center"><a onclick="eliminarNivelDeEmergencia(' + id + ')" href="#" class="btn btn-search btn-md" title="Eliminar"><span class="glyphicon glyphicon-erase"></span></a></td>';
                tHtml += '</tr>';
            });
            $("#gridemergencia").append(tHtml);
        }
    });
}

function ListarBDInterna(isede) {
    $.ajax({
        type: 'GET',
        url: '/PlanEmergencias/ListarBDInterna',
        data: { isede: isede },
        success: function (result) {
            var tHtml = "";
            $("#gridinterna").empty();
            tHtml += '<thead>';
            tHtml += '<tr class="titulos_tabla"><th ' + class_css_header + ' colspan="5">&nbsp;</th>';
            tHtml += '<th colspan="3" ' + class_css_header + '>Información del Contacto</th>';
            tHtml += '<th ' + class_css_header + 'colspan="3">&nbsp;</th></tr>';
            tHtml += '<tr class="titulos_tabla">';
            tHtml += '<th ' + class_css_header + '>Nombre</th>';
            tHtml += '<th ' + class_css_header + '>Número de Documento</th>';
            tHtml += '<th ' + class_css_header + '>Género</th>';
            tHtml += '<th ' + class_css_header + '>EPS</th>';
            tHtml += '<th ' + class_css_header + '>RH</th>';
            tHtml += '<th ' + class_css_header + '>Nombre</th>';
            tHtml += '<th ' + class_css_header + '>Teléfono</th>';
            tHtml += '<th ' + class_css_header + '>Parentesco</th>';
            tHtml += '<th ' + class_css_header + '>Requiere Manejo Especial</th>';
            tHtml += '<th ' + class_css_header + '>Cuál</th>';
            tHtml += '<th ' + class_css_header + '>Acción</th></tr></thead>';
            $.each(result, function (key, val) {
                var id = val.pk_id_bd_interna;
                tHtml += '<tbody><tr>';
                tHtml += '<td ' + class_css_btxt + '>' + val.nombre + '</td>';
                tHtml += '<td ' + class_css_btxt + '>' + val.numdocumento + '</td>';
                tHtml += '<td ' + class_css_btxt + '>' + val.genero + '</td>';
                tHtml += '<td ' + class_css_btxt + '>' + val.eps + '</td>';
                tHtml += '<td ' + class_css_btxt + '>' + val.rh + '</td>';
                tHtml += '<td ' + class_css_btxt + '>' + val.contacto_nombre + '</td>';
                tHtml += '<td ' + class_css_btxt + '>' + val.contacto_telefono + '</td>';
                tHtml += '<td ' + class_css_btxt + '>' + val.contacto_parentesco + '</td>';
                tHtml += '<td ' + class_css_btxt + '>' + val.requiere_manejo + '</td>';
                tHtml += '<td ' + class_css_btxt + '>' + val.cual_manejo + '</td>';
                tHtml += '<td align="center"><a href="#" onclick="eliminarBDInterna(' + id + ')" class="btn btn-search btn-md" title="Eliminar"><span class="glyphicon glyphicon-erase"></span></a></td>';

                tHtml += '</tr></tbody>';
            });
            $("#gridinterna").append(tHtml);
        }
    });
}

function ListarBDExterna(isede) {
    $.ajax({
        type: 'GET',
        url: '/PlanEmergencias/ListarBDExterna',
        data: { isede: isede },
        success: function (result) {
            var tHtml = "";
            $("#gridbdexterna").empty();
            tHtml += '<tr class="titulos_tabla">';
            tHtml += '<th ' + class_css_header + '>Entidad</th>';
            tHtml += '<th ' + class_css_header + '>Dirección</th>';
            tHtml += '<th ' + class_css_header + '>Teléfono</th>';
            tHtml += '<th ' + class_css_header + '>Nombre del Contacto</th>';
            tHtml += '<th ' + class_css_header + '>Acción</th>';
            tHtml += '</tr>';
            $.each(result, function (key, val) {
                var id = val.pk_id_bd_externa;
                tHtml += '<tr>';
                tHtml += '<td ' + class_css_btxt + '>' + val.entidad + '</td>';
                tHtml += '<td ' + class_css_btxt + '>' + val.direccion + '</td>';
                tHtml += '<td ' + class_css_btxt + '>' + val.telefono + '</td>';
                tHtml += '<td ' + class_css_btxt + '>' + val.nombre_contacto + '</td>';
                tHtml += '<td align="center"><a onclick="eliminarBDExterna(' + id + ')" href="#" class="btn btn-search btn-md" title="Eliminar"><span class="glyphicon glyphicon-erase"></span></a></td>';

                tHtml += '</tr>';
            });
            $("#gridbdexterna").append(tHtml);
        }
    });
}


function ListarBDPlanAyuda(isede) {
    $.ajax({
        type: 'GET',
        url: '/PlanEmergencias/ListarBDPlanAyuda',
        data: { isede: isede },
        success: function (result) {
            var tHtml = "";
            $("#gridplanayuda").empty();
            tHtml += '<thead>';
            tHtml += '<tr class="titulos_tabla">';
            tHtml += '<th ' + class_css_header + '>&nbsp;</th>';
            tHtml += '<th ' + class_css_header + '>&nbsp;</th>';
            tHtml += '<th ' + class_css_header + '>&nbsp;</th>';
            tHtml += '<th ' + class_css_header + '>&nbsp;</th>';
            tHtml += '<th ' + class_css_header + ' colspan="3">Información de Contacto</th></tr>';
          
           
            tHtml += '<tr class="titulos_tabla">';
            tHtml += '<th ' + class_css_header + '>Empresa Participante</th>';
            tHtml += '<th ' + class_css_header + '>Recursos a Disposición</th>';
            tHtml += '<th ' + class_css_header + '>Compensación económica por uso del recurso</th>';
            tHtml += '<th ' + class_css_header + '>Reintegro del recurso</th>';
            tHtml += '<th ' + class_css_header + '>Nombre</th>';
            tHtml += '<th ' + class_css_header + '>Teléfono</th>';
            tHtml += '<th ' + class_css_header + '>Acción</th>';

            tHtml += '</tr></thead>';
            $.each(result, function (key, val) {
                var id = val.pk_id_planayuda;
                tHtml += '<tbody><tr>';
                tHtml += '<td ' + class_css_btxt + '>' + val.empresa + '</td>';
                tHtml += '<td ' + class_css_btxt + '>' + val.recurso + '</td>';
                tHtml += '<td ' + class_css_btxt + '>' + val.compensacion + '</td>';
                tHtml += '<td ' + class_css_btxt + '>' + val.reintegro + '</td>';
                tHtml += '<td ' + class_css_btxt + '>' + val.nombre_contacto + '</td>';
                tHtml += '<td ' + class_css_btxt + '>' + val.telefono_contacto + '</td>';
                tHtml += '<td align="center"><a   onclick="eliminarBDPlanAyuda(' + id + ')" href="#" class="btn btn-search btn-md" title="Eliminar"><span class="glyphicon glyphicon-erase"></span></a></td>';

                tHtml += '</tr></tbody>';
            });
            $("#gridplanayuda").append(tHtml);
        }
    });
}


function ListarRoles(isede) {
    $.ajax({
        type: 'GET',
        url: '/PlanEmergencias/ListarRoles',
        data: { isede: isede },
        success: function (result) {
            var tHtml = "";
            $("#gridroles").empty();
            tHtml += '<tr class="titulos_tabla">';
            tHtml += '<th ' + class_css_header + '>Rol</th>';
            tHtml += '<th ' + class_css_header + '>Antes</th>';
            tHtml += '<th ' + class_css_header + '>Durante</th>';
            tHtml += '<th ' + class_css_header + '>Después</th>';
            tHtml += '<th ' + class_css_header + '>Acción</th>';

            //tHtml += '<th style="border-right: 2px solid lightslategray; text-align:center">Acciones</th>';
            tHtml += '</tr>';
            $.each(result, function (key, val) {
                var id = val.pk_id_roles;
                tHtml += "<tr>";
                tHtml += '<td ' + class_css_btxt + '>' + val.nombre + '</td>';
                tHtml += '<td ' + class_css_btxt + '>' + val.antes + '</td>';
                tHtml += '<td ' + class_css_btxt + '>' + val.durante + '</td>';
                tHtml += '<td ' + class_css_btxt + '>' + val.despues + '</td>';
                //tHtml += '<td>&nbsp;<a href="#" class="btn btn-search btn-md" title="Editar"><span class="glyphicon glyphicon-pencil"></span></a>&nbsp;';
                tHtml += '<td align="center"><a href="#" onclick="eliminarFuncYResp(' + id + ')"   class="btn btn-search btn-md" title="Eliminar"><span class="glyphicon glyphicon-erase"></span></a></td>';
                tHtml += '</tr>';
            });
            $("#gridroles").append(tHtml);
        }
    });
}

function ListarProcedimientosOperativosNormalizados(isede) {
    $.ajax({
        type: 'GET',
        url: '/PlanEmergencias/ListarProcedimientosOperativosNormalizados',
        data: { isede: isede },
        success: function (result) {
            var tHtml = "";
            $("#procopera").empty();
            tHtml += '<tr class="titulos_tabla">';
            tHtml += '<th ' + class_css_header + '>Nombre del Procedimiento</th>';
            tHtml += '<th ' + class_css_header + '>Responsable</th>';
            tHtml += '<th ' + class_css_header + '>Antes</th>';
            tHtml += '<th ' + class_css_header + '>Durante</th>';
            tHtml += '<th ' + class_css_header + '>Después</th>';
            tHtml += '<th ' + class_css_header + '>Recursos</th>';
           
            tHtml += '<th ' + class_css_header + '>Acciones</th>';
            tHtml += '</tr>';
            $.each(result, function (key, val) {
                var id = val.pk_id_proc_normalizados;
                tHtml += "<tr>";
                tHtml += '<td ' + class_css_btxt + '>' + val.nombre_proc + '</td>';
                tHtml += '<td ' + class_css_btxt + '>' + val.responsable + '</td>';
                tHtml += '<td ' + class_css_btxt + '>' + val.proc_antes + '</td>';
                tHtml += '<td ' + class_css_btxt + '>' + val.proc_durante + '</td>';
                tHtml += '<td ' + class_css_btxt + '>' + val.proc_despues + '</td>';
                tHtml += '<td ' + class_css_btxt + '>' + val.proc_recursos + '</td>';
                
                tHtml += '<td  align="center">&nbsp;<a href="#" onclick="modificarProcedimiento('+id+')" class="btn btn-search btn-md" title="Editar"><span class="glyphicon glyphicon-pencil"></span></a>&nbsp;';
                tHtml += '<a href="#" onclick="eliminarProcedimiento('+id+')" class="btn btn-search btn-md" title="Eliminar"><span class="glyphicon glyphicon-erase"></span></a></td>';
                tHtml += '</tr>';
            });
            $("#procopera").append(tHtml);
        }
    });
}

//function GuardarHR() {
//    var sede = $("#IdSede").val();
//    $.ajax({
//        type: 'POST',
//        url: '/PlanEmergencias/GuardarHR',
//        data: $("#frmHR").serialize(),
//        traditional: true,
//        success: function (result) {
//            $('#myModal3').modal('hide');
//            ListarHR(sede);
//        }
//    });
//}

function ListarHR(isede) {
    $.ajax({
        type: 'GET',
        url: '/PlanEmergencias/ListarHR',
        data: { isede: isede },
        success: function (result) {
            var tHtml = "";
            $("#gridHR").empty();
            tHtml += '<tr class="titulos_tabla">';
            tHtml += '<th ' + class_css_header + '>Brigadistas Primeros Auxilios</th>';
            tHtml += '<th ' + class_css_header + '>Brigadistas Contraincendios</th>';
            tHtml += '<th ' + class_css_header + '>Brigadistas de Evacuación y Rescate</th>';
            tHtml += '<th ' + class_css_header + '>Acción</th>';
            //tHtml += '<th style="border-right: 2px solid lightslategray; text-align:center">&nbsp</th>';
            tHtml += '</tr>';
            tHtml += '<tr class="titulos_tabla">';
            tHtml += '<th ' + class_css_header + '>Nombre</th>';
            tHtml += '<th ' + class_css_header + '>Nombre</th>';
            tHtml += '<th ' + class_css_header + '>Nombre</th>';
            tHtml += '<th ' + class_css_header + '></th>';
            //tHtml += '<th style="border-right: 2px solid lightslategray; text-align:center">Acciones</th>';
            tHtml += '</tr>';
            $.each(result, function (key, val) {
                var id = val.pk_id_recursosh;
                tHtml += "<tr>";
                tHtml += '<td ' + class_css_btxt + '>' + val.bpaux_nombre + '</td>';
                tHtml += '<td ' + class_css_btxt + '>' + val.bcontra_nombre + '</td>';
                tHtml += '<td ' + class_css_btxt + '>' + val.bevalresc_nombre + '</td>';
                //tHtml += '<td>&nbsp;<a href="#" class="btn btn-search btn-md" title="Editar"><span class="glyphicon glyphicon-pencil"></span></a>&nbsp;';
                tHtml += '<td align="center"><a  onclick="eliminarRecursoHumanos(' + id + ')" href="#" class="btn btn-search btn-md" title="Eliminar"><span class="glyphicon glyphicon-erase"></span></a></td>';
                tHtml += '</tr>';
            });
            $("#gridHR").append(tHtml);
        }
    });
}


//function GuardarRTecnicos() {
//    var sede = $("#IdSede").val();
//    $.ajax({
//        type: 'POST',
//        url: '/PlanEmergencias/GuardarRTecnicos',
//        data: $("#frmRTecnicos").serialize(),
//        traditional: true,
//        success: function (result) {
//            $('#myModal4').modal('hide');
//            ListarRTecnicos(sede);
//        }
//    });
//}

function ListarRTecnicos(isede) {
    $.ajax({
        type: 'GET',
        url: '/PlanEmergencias/ListarRTecnicos',
        data: { isede: isede },
        success: function (result) {
            var tHtml = "";
            $("#gridRT").empty();
            tHtml += '<tr class="titulos_tabla">';
            tHtml += '<th ' + class_css_header + '>Tipo</td>';
            tHtml += '<th ' + class_css_header + '>Cantidad</th>';
            tHtml += '<th ' + class_css_header + '>Ubicación</th>';
            tHtml += '<th ' + class_css_header + '>Acción</th>';

            //tHtml += '<th style="border-right: 2px solid lightslategray; text-align:center">&nbsp</th>';
            tHtml += '</tr>';
            $.each(result, function (key, val) {
                var id = val.pk_id_recursostecnicos;
                tHtml += "<tr>";
                tHtml += '<td ' + class_css_btxt + '>' + val.tipo + '</td>';
                tHtml += '<td style="border-right: 2px solid lightslategray; vertical-align:middle; text-align:center">' + val.cantidad + '</td>';
                tHtml += '<td ' + class_css_btxt + '>' + val.ubicacion + '</td>';
                //tHtml += '<td>&nbsp;<a href="#" class="btn btn-search btn-md" title="Editar"><span class="glyphicon glyphicon-pencil"></span></a>&nbsp;';
                tHtml += '<td align="center"><a  onclick="eliminarRecursosFisicos(' + id + ')"  href="#" class="btn btn-search btn-md" title="Eliminar"><span class="glyphicon glyphicon-erase"></span></a></td>';
                tHtml += '</tr>';
            });
            $("#gridRT").append(tHtml);
        }
    });
}

function CrearRolesFuncion() {
    $('#myModal1').modal('show');
    reiniciarFuncionesResponsabilidades();
   

}

function CrearNivelEmergencia() {
    $('#myModal2').modal('show');
    reiniciarNivelesEmergencia();
}

function CrearHR() {
    $('#myModal3').modal('show');
    reiniciarRecursoHumano();
}

function CrearRecursosFisico() {
    $('#myModal4').modal('show');
    reiniciarRecursoTecnico();
}


function CrearProcOperativos() {
    $('#myModal0').modal('show');
    reiniciarProcOperativosNormalizados();
}
////////////////////////////// ////////////////////////////// ////////////////////////////// ////////////////////////////// ////////////////////////////// //////////////////////////////


$(function () {
    $("#tabs_vulneravilidades").tabs({
        activate: function (event, ui) {
            ObtenerIdentificacionAmenaza();
            ObtenerPersona();
            ObtenerRecurso();
            ObtenerSistemaProceso();
            ObtenerConsolidado();
        }
    });
    $("#tabs_vulneravilidades").tabs("enable", 0);
    $("#tabs_vulneravilidades").tabs("disable", 1);
    $("#tabs_vulneravilidades").tabs("disable", 2);
    $("#tabs_vulneravilidades").tabs("disable", 3);
    $("#tabs_vulneravilidades").tabs("disable", 4);
    $("#tabs_vulneravilidades").tabs("disable", 5);
});

function ColorRombo(param, id) {
    switch (param) {
        case "P": $("#color_" + id).css("background", "#009E11");
            break;
        case "PR": $("#color_" + id).css("background", "#FFFF00");
            break;
        case "I": $("#color_" + id).css("background", "#CC0000");
            break;
        default: $("#color_" + id).css("background", "#FFFFFF");
            break;
    }
}

function CrearVulnerabilidad() {

    var sedeTexto = $("#IdSede  option:selected").html();
 
    $("#sedevultexto").text(sedeTexto);
 
    ListarPreguntasIdentificacionAmenazas();
    ListaPersonas();
    ListaRecursos();
    ListaSistemasProcesos();
    $('#myModal5').modal('show');
	$("#tabs_vulneravilidades").tabs({ active: 0 });

}

function tabs_vulneravilidades_Siguiente(numtab) {
    var sede = $("#IdSede").val();
    switch (numtab) {
        case 1:
            if (ValidarVulnerabilidadesAmenazas() == true) {
                GuardarIdentificacionAmenazas(sede);
                $("#tabs_vulneravilidades").tabs("enable", numtab);
                $("#tabs_vulneravilidades").tabs({ active: numtab });
                break;
            }
            else {
                return false;
            }
        case 2:
            GuardarPersonas(sede);
            $("#tabs_vulneravilidades").tabs("enable", numtab);
            $("#tabs_vulneravilidades").tabs({ active: numtab });
            //ObtenerPersona();
          
            break;
        case 3:
            GuardarRecursos(sede);
            $("#tabs_vulneravilidades").tabs("enable", numtab);
            $("#tabs_vulneravilidades").tabs({ active: numtab });
            //ObtenerRecurso();
           
            break;
        case 4:
            GuardarSistemasProcesos(sede);
            ObtenerConsolidado();
            $("#tabs_vulneravilidades").tabs("enable", numtab);
            $("#tabs_vulneravilidades").tabs({ active: numtab });
            //ObtenerSistemaProceso();
			
         
            break;
        case 5:
            ObtenerNivelesRiesgo();
            $("#tabs_vulneravilidades").tabs("enable", numtab);
            $("#tabs_vulneravilidades").tabs({ active: numtab });
           
          
            break;
    }
}

function ListarPreguntasIdentificacionAmenazas() {
    $.ajax({
        type: 'POST',
        url: '/PlanEmergencias/ListarPreguntasIdentificacionAmenazas',
        success: function (result) {
            var tHtml = "";
            $("#grid_ident_amenaza").empty();
            tHtml += '<tr class="titulos_tabla">';
            tHtml += '<th ' + class_css_header + ' width="10"></th>';
            tHtml += '<th ' + class_css_header + ' width="76">Amenaza</th>';
            tHtml += '<th ' + class_css_header + ' width="56">Origen</th>';
            tHtml += '<th ' + class_css_header + ' width="142">Fuente de Riesgo</th>';
            tHtml += '<th ' + class_css_header + ' width="95">Calificación</th>';
            tHtml += '<th ' + class_css_header + ' width="64">Color</th>';
            tHtml += '</tr>';
            tHtml += '<tr class="titulos_tabla">';
            tHtml += '<th ' + class_css_header + ' colspan="6">Naturales</th>';
            tHtml += '</tr>';
            $.each(result, function (key, val) {
                if (val.tipo == "N") {
                    tHtml += '<tr>';
                    tHtml += '<th align="center"><input id="chk_' + val.pk_id_identificacion_amenazas + '" type="checkbox" name="chk_Name" onchange="QuitarErrorCheck(this)" value="' + val.pk_id_identificacion_amenazas + '"/></th>';
                    tHtml += '<th align="center">' + val.amenaza + '</th>';                    
                    tHtml += '<th align="center"><select id="origen_' + val.pk_id_identificacion_amenazas + '" name="origen_" id="select" disabled><option value="I">Interno</option><option value="E">Externo</option></select></th>';
                    tHtml += '<th align="center"><input id="text_' + val.pk_id_identificacion_amenazas + '" name="text_" type="text" disabled></th>';
                    tHtml += '<th align="center"><select id="calificacion_' + val.pk_id_identificacion_amenazas + '" name="calificacion_" disabled onchange="ColorRombo(this.value,' + val.pk_id_identificacion_amenazas + '),quitarlabelErrorSelect(this)"><option value="0">-Seleccione-</option><option value="P">Posible</option><option value="PR">Probable</option><option value="I">Inminente</option></select></th>';                
                    tHtml += '<th align="center"><div id="color_' + val.pk_id_identificacion_amenazas + '" class="rombo"></div></th>';
                    tHtml += '</tr>';
                }
            });
            tHtml += '<tr class ="titulos_tabla">';
            tHtml += '<th ' + class_css_header + ' colspan="6">Tecnológico</th>';
            tHtml += '</tr>';
            $.each(result, function (key, val) {
                if (val.tipo == "T") {
                    tHtml += '<tr>';
                    tHtml += '<th align="center"><input id="chk_' + val.pk_id_identificacion_amenazas + '" type="checkbox" name="chk_Name" onchange="QuitarErrorCheck(this)" value="' + val.pk_id_identificacion_amenazas + '"/></th>';
                    tHtml += '<th align="center">' + val.amenaza + '</th>';
                    tHtml += '<th align="center"><select id="origen_' + val.pk_id_identificacion_amenazas + '" name="origen_" disabled><option value="I">Interno</option><option value="E">Externo</option></select></th>';
                    tHtml += '<th align="center"><input id="text_' + val.pk_id_identificacion_amenazas + '" name="text_" type="text" disabled></th>';
                    tHtml += '<th align="center"><select id="calificacion_' + val.pk_id_identificacion_amenazas + '" name="calificacion_" disabled onchange="ColorRombo(this.value,' + val.pk_id_identificacion_amenazas + '),quitarlabelErrorSelect(this)"><option value="0">-Seleccione-</option><option value="P">Posible</option><option value="PR">Probable</option><option value="I">Inminente</option></select></th>';
                    tHtml += '<th align="center"><div id="color_' + val.pk_id_identificacion_amenazas + '" class="rombo"></div></th>';
                    tHtml += '</tr>';
                }
            });
            tHtml += '<tr class ="titulos_tabla">';
            tHtml += '<th ' + class_css_header + ' colspan="6">Sociales</th>';
            tHtml += '</tr>';
            $.each(result, function (key, val) {
                if (val.tipo == "S") {
                    tHtml += '<tr>';
                    tHtml += '<th align="center"><input id="chk_' + val.pk_id_identificacion_amenazas + '" type="checkbox" name="chk_Name" onchange="QuitarErrorCheck(this)" value="' + val.pk_id_identificacion_amenazas + '"/></th>';
                    tHtml += '<th align="center">' + val.amenaza + '</th>';
                    tHtml += '<th align="center"><select id="origen_' + val.pk_id_identificacion_amenazas + '" name="origen_" disabled><option value="I">Interno</option><option value="E">Externo</option></select></th>';
                    tHtml += '<th align="center"><input id="text_' + val.pk_id_identificacion_amenazas + '" name="text_" type="text" disabled></th>';
                    tHtml += '<th align="center"><select id="calificacion_' + val.pk_id_identificacion_amenazas + '" name="calificacion_" disabled onchange="ColorRombo(this.value,' + val.pk_id_identificacion_amenazas + '),quitarlabelErrorSelect(this)"><option value="0">-Seleccione-</option><option value="P">Posible</option><option value="PR">Probable</option><option value="I">Inminente</option></select></th>';
                    tHtml += '<th align="center"><div id="color_' + val.pk_id_identificacion_amenazas + '" class="rombo"></div></th>';
                    tHtml += '</tr>';
                }
            });
            $("#grid_ident_amenaza").append(tHtml);
        }
    });

    ObtenerIdentificacionAmenaza();
}

function ListaPersonas() {
    var isede = $("#IdSede").val();
    $.ajax({

        type: 'POST',
        url: '/PlanEmergencias/ListaPersonas',
   
    data: { isede: isede },
        success: function (result) {
            var tHtml = "";
			var tHtml1 = "";
			var tHtml1A= "";
			var tHtml2 = "";
			var tHtml2A= "";
		    var tHtml3 = "";
			var tHtml3A= "";
			$("#grid_personas").empty();
            $("#grid_personas1").empty();
			$("#grid_personas2").empty();
			$("#grid_personas3").empty();
			$("#grid_personas1A").empty();
			$("#grid_personas2A").empty();
			$("#grid_personas3A").empty();
            tHtml += '<tr class="titulos_tabla">';
            tHtml += '<th ' + class_css_header + '  width="199" >Aspecto Vulnerable</th>';
            tHtml += '<th ' + class_css_header + ' width="150" >Observación</th>';
            tHtml += '<th ' + class_css_header + ' width="150" >Recomendación</th>';
            tHtml += '<th ' + class_css_header + ' width="70">Calificación</th>';
            tHtml += '</tr>';
			
		    $("#grid_personas").append(tHtml);
			
            tHtml1+= '<tr class="titulos_tabla" >';
            tHtml1+= '<th ' + class_css_header + ' colspan="4">Organización</th>';
            tHtml1+= '</tr>';
            $.each(result, function (key, val) {
                if (val.tipo == "O") {
                    tHtml1 += '<tr>';
                    tHtml1 += '<td ' + class_css_btxt + ' width="258" >' + val.aspectos + ' </td>';
                    tHtml1 += '<td ' + class_css_btxtobser + 'width="84"><input id="p_observacion_' + val.pk_id_personas + '" type="text"></td>';
                    tHtml1 += '<td ' + class_css_btxtobser + ' width="84"><input id="p_recomendacion_' + val.pk_id_personas + '" type="text"></td>';
                    tHtml1 += '<td style="border-right: 2px solid lightslategray; vertical-align:middle; text-align:center" width="125" ><select onchange="obtenerSubtotalOrg()" id="p_calificacion_' + val.pk_id_personas + '" name="p_calificacionO_' + val.pk_id_personas + '" ><option value="">Seleccione</option><option value="0.0">0.0</option><option value="0.5">0.5</option><option value="1.0">1.0</option></select><input id="p_tipo_' + val.pk_id_personas + '" value="O" type="hidden"></td>';
                    tHtml1 += '</tr>';
                }
            });
			$("#grid_personas1").append(tHtml1);
			
            tHtml1A += '<tr class="noborder">><td width="30%" align="center" class="noborder"><input name="menuOrg" id="menuOrg" type="button"class="boton botonactive" style="text-decoration:none; margin-left:30px" value="AGREGAR"  onclick="llamarMenuPersonas(1)"/><td width="54%" align="right" colspan="2" ' + class_css_btxt + 'class="noborder">Subtotal</td><td width="16%" align="center"  class="noborder" style="border-right: 2px solid lightslategray; vertical-align:middle;"><input name="subtotal_o" id="subtotal_o" type="text" style="border:none;width:40%;background-color:transparent;" readonly /></td></tr></td> ';
            $("#grid_personas1A").append(tHtml1A);
            
            tHtml2 += '<tr class="titulos_tabla">';
            tHtml2 += '<th ' + class_css_header + ' colspan="4">Capacitación</th>';
            tHtml2 += '</tr>';
            $.each(result, function (key, val) {
                if (val.tipo == "C") {
                    tHtml2 += '<tr>';
                    tHtml2+= '<td ' + class_css_btxt + ' width="258">' + val.aspectos + '</td>';
                    tHtml2 += '<td ' + class_css_btxtobser + ' width="84" ><input id="p_observacion_' + val.pk_id_personas + '" type="text"></td>';
                    tHtml2 += '<td ' + class_css_btxtobser + ' width="84"  ><input id="p_recomendacion_' + val.pk_id_personas + '" type="text"></td>';
                    tHtml2 += '<td style="border-right: 2px solid lightslategray; vertical-align:middle; text-align:center" width="125" ><select onchange="obtenerSubtotalCap()" id="p_calificacion_' + val.pk_id_personas + '" name="p_calificacionC_' + val.pk_id_personas + '" ><option value="">Seleccione</option><option value="0.0">0.0</option><option value="0.5">0.5</option><option value="1.0">1.0</option></select><input id="p_tipo_' + val.pk_id_personas + '" value="C" type="hidden"></td>';
                    tHtml2 += '</tr>';
                }
            });
           
            tHtml2A += '<tr><td width="30%" align="center" class="noborder" ><input name="menuCap" id="menuCap" type="button" class="boton botonactive" style="text-decoration:none; margin-left:30px" value="AGREGAR" onclick="llamarMenuPersonas(2)"/><td width="54%" align="right" colspan="2" ' + class_css_btxt + 'class="noborder" >Subtotal</td><td width="16%" align="center" class="noborder" style="border-right: 2px solid lightslategray; vertical-align:middle;"><input name="subtotal_c" id="subtotal_c"  type="text" style="border:none;width:40%;background-color:transparent;" readonly /></td></tr></td>';
              $("#grid_personas2").append(tHtml2);
			 $("#grid_personas2A").append(tHtml2A);
            tHtml3 += '<tr class="titulos_tabla">';
            tHtml3 += '<th ' + class_css_header + ' colspan="4">Dotación</th>';
            tHtml3 += '</tr>';
            $.each(result, function (key, val) {
                if (val.tipo == "D") {
                    tHtml3 += '<tr>';
                    tHtml3 += '<td ' + class_css_btxt + ' width="258">' + val.aspectos + '</td>';
                    tHtml3 += '<td ' + class_css_btxtobser + ' width="84" ><input id="p_observacion_' + val.pk_id_personas + '" type="text"></td>';
                    tHtml3 += '<td ' + class_css_btxtobser + ' width="84" ><input id="p_recomendacion_' + val.pk_id_personas + '" type="text"></td>';
                    tHtml3 += '<td style="border-right: 2px solid lightslategray; vertical-align:middle; text-align:center" width="125" ><select onchange="obtenerSubtotalDot()" id="p_calificacion_' + val.pk_id_personas + '" name="p_calificacionD_' + val.pk_id_personas + '"><option value="">Seleccione</option> <option value="0.0">0.0</option><option value="0.5">0.5</option><option value="1.0">1.0</option></select><input id="p_tipo_' + val.pk_id_personas + '" value="D" type="hidden"></td>';
                    tHtml3 += '</tr>';
                }
            });


            tHtml3A += '<tr><td width="30%" align="center" class="noborder"  ><input name="menuDot" id="menuDot" type="button"class="boton botonactive" style="text-decoration:none; margin-left:30px" value="AGREGAR" onclick="llamarMenuPersonas(3)"/></td><td width="54%" align="right" colspan="2" ' + class_css_btxt + ' class="noborder" >Subtotal</td><td width="16%" align="center" class="noborder"  style="border-right: 2px solid lightslategray; vertical-align:middle;"><input name="subtotal_d" id="subtotal_d" type="text" style="border:none;width:40%;background-color:transparent;" readonly /></td></tr></td>';

            $("#grid_personas3").append(tHtml3);
            $("#grid_personas3A").append(tHtml3A);
         
        }
    });
    ObtenerIdentificacionAmenaza();
}


function ListaRecursos() {
    var isede = $("#IdSede").val();
    $.ajax({
        type: 'POST',
        url: '/PlanEmergencias/ListaRecursos',
        data: { isede: isede },
        success: function (result) {
            var tHtml = "";
			var tHtml1 = "";
			var tHtml1A= "";
			var tHtml2 = "";
			var tHtml2A= "";
		    var tHtml3 = "";
			var tHtml3A= "";
			
			 $("#grid_recursos").empty();
            $("#grid_recursos1").empty();
			$("#grid_recursos2").empty();
			$("#grid_recursos3").empty();
			$("#grid_recursos1A").empty();
			$("#grid_recursos2A").empty();
			$("#grid_recursos3A").empty();
			
			
            tHtml += '<tr class="titulos_tabla">';
            tHtml += '<th ' + class_css_header + ' width="199">Aspecto Vulnerable</th>';
            tHtml += '<th ' + class_css_header + ' width="150">Observación</th>';
            tHtml += '<th ' + class_css_header + ' width="150">Recomendación</th>';
            tHtml += '<th ' + class_css_header + ' width="70">Calificación</th>';
            tHtml += '</tr>';
			
		    $("#grid_recursos").append(tHtml);
			
            tHtml1 += '<tr class="titulos_tabla">';
            tHtml1 += '<th ' + class_css_header + ' colspan="4">Materiales</th>';
            tHtml1 += '</tr>';
            $.each(result, function (key, val) {
                if (val.tipo == "M") {
                    tHtml1 += '<tr>';
                    tHtml1 += '<td ' + class_css_btxt + ' width="258" >' + val.aspectos + '</td>';
                    tHtml1 += '<td ' + class_css_btxtobser + ' width="84"><input id="r_observacion_' + val.pk_id_recursos + '" type="text"></td>';
                    tHtml1 += '<td ' + class_css_btxtobser + ' width="84"><input id="r_recomendacion_' + val.pk_id_recursos + '" type="text"></td>';
                    tHtml1 += '<td style="border-right: 2px solid lightslategray; vertical-align:middle; text-align:center" width="125" ><select onchange="obtenerSubtotalMat()" id="r_calificacion_' + val.pk_id_recursos + '" id="select"  name="r_calificacionMat_' + val.pk_id_recursos + '"><option value="">Seleccione</option><option value="0.0">0.0</option><option value="0.5">0.5</option><option value="1.0">1.0</option></select><input id="r_tipo_' + val.pk_id_recursos + '" value="M" type="hidden"></td>';
                    tHtml1 += '</tr>';
                }
            });
			
			  $("#grid_recursos1").append(tHtml1);
			
            tHtml1A += '<tr><td width="30%" align="center" class="noborder"><input name="menuMat" id="menuMat" type="button"class="boton botonactive" style="text-decoration:none; margin-left:30px" value="AGREGAR"  onclick="llamarMenuRecursos(1)"/><td width="54%" align="right" colspan="2" ' + class_css_btxt + ' class="noborder">Subtotal</td><td width="16%" align="center" style="border-right: 2px solid lightslategray; vertical-align:middle;"  class="noborder"><input name="subtotal_m" id="subtotal_m" type="text" style="border:none;width:40%;background-color:transparent;" readonly /></td></tr></td>';
            $("#grid_recursos1A").append(tHtml1A);
			
			
            tHtml2 += '<tr class="titulos_tabla">';
            tHtml2 += '<th ' + class_css_header + ' colspan="4">Edificaciones</th>';
            tHtml2 += '</tr>';
            $.each(result, function (key, val) {
                if (val.tipo == "E") {
                    tHtml2 += '<tr>';
                    tHtml2 += '<td ' + class_css_btxt + 'width="258"  >' + val.aspectos + '</td>';
                    tHtml2 += '<td ' + class_css_btxtobser + ' width="84"><input id="r_observacion_' + val.pk_id_recursos + '" type="text"></td>';
                    tHtml2 += '<td ' + class_css_btxtobser + 'width="84" ><input id="r_recomendacion_' + val.pk_id_recursos + '" type="text"></td>';
                    tHtml2 += '<td style="border-right: 2px solid lightslategray; vertical-align:middle; text-align:center" width="125" ><select onchange="obtenerSubtotalEdi()"  id="r_calificacion_' + val.pk_id_recursos + '" name="r_calificacionEdi_' + val.pk_id_recursos + '" id="select"><option value="">Seleccione</option><option value="0.0">0.0</option><option value="0.5">0.5</option><option value="1.0">1.0</option></select><input id="r_tipo_' + val.pk_id_recursos + '" value="E" type="hidden"></td>';
                    tHtml2 += '</tr>';
                }
            });
           $("#grid_recursos2").append(tHtml2);
  
            tHtml2A += '<tr><td width="30%" align="center" class="noborder" ><input name="menuEdi" id="menuEdi" type="button"class="boton botonactive" style="text-decoration:none; margin-left:30px" value="AGREGAR"  onclick="llamarMenuRecursos(2)"/><td width="54%" align="right" colspan="2" ' + class_css_btxt + ' class="noborder">Subtotal</td><td width="16%" align="center" style="border-right: 2px solid lightslategray; vertical-align:middle;" class="noborder" ><input name="subtotal_e" id="subtotal_e" type="text" style="border:none;width:40%;background-color:transparent;" readonly /></td></tr></td>';
           
		   $("#grid_recursos2A").append(tHtml2A);
			


            tHtml3 += '<tr class="titulos_tabla">';
            tHtml3 += '<th style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center; vertical-align:middle; text-transform:uppercase" colspan="4">Equipos</th>';
            tHtml3 += '</tr>';
            $.each(result, function (key, val) {
                if (val.tipo == "EQ") {
                    tHtml3 += '<tr class="titulos_filas">';
                    tHtml3 += '<td ' + class_css_btxt + 'width="258"  >' + val.aspectos + '</td>';
                    tHtml3 += '<td ' + class_css_btxtobser + 'width="84" ><input id="r_observacion_' + val.pk_id_recursos + '" type="text"></td>';
                    tHtml3 += '<td ' + class_css_btxtobser + 'width="84" ><input id="r_recomendacion_' + val.pk_id_recursos + '" type="text"></td>';
                    tHtml3 += '<td style="border-right: 2px solid lightslategray; vertical-align:middle; text-align:center" width="125"><select onchange="obtenerSubtotalEqui()"  id="r_calificacion_' + val.pk_id_recursos + '"  name="r_calificacionEqui_' + val.pk_id_recursos + '"  id="select"><option value="">Seleccione</option><option value="0.0">0.0</option><option value="0.5">0.5</option><option value="1.0">1.0</option></select><input id="r_tipo_' + val.pk_id_recursos + '" value="EQ" type="hidden"></td>';
                    tHtml3 += '</tr>';
                }
            });

			  $("#grid_recursos3").append(tHtml3);
            tHtml3A += '<tr><td width="30%" align="center" class="noborder"><input name="menuEqui" id="menuEqui" type="button"class="boton botonactive" style="text-decoration:none; margin-left:30px" value="AGREGAR"  onclick="llamarMenuRecursos(3)"/><td width="54%" align="right" colspan="2" ' + class_css_btxt + ' class="noborder" >Subtotal</td><td width="16%" align="center" style="border-right: 2px solid lightslategray; vertical-align:middle;" class="noborder" ><input name="subtotal_eq" id="subtotal_eq" type="text" style="border:none;width:40%;background-color:transparent;" readonly /></td></td></tr>';

			  $("#grid_recursos3A").append(tHtml3A);

        }
    });
    ObtenerIdentificacionAmenaza();
}

function ListaSistemasProcesos() {

    var isede = $("#IdSede").val();
    $.ajax({
        type: 'POST',
        url: '/PlanEmergencias/ListaSistemasProcesos',
        data: { isede: isede },
        success: function (result) {
            var tHtml = "";
				var tHtml1 = "";
			var tHtml1A= "";
			var tHtml2 = "";
			var tHtml2A= "";
		    var tHtml3 = "";
			var tHtml3A= "";
			 $("#grid_sistemasprocesos").empty();
            $("#grid_sistemasprocesos1").empty();
			$("#grid_sistemasprocesos2").empty();
			$("#grid_sistemasprocesos3").empty();
			$("#grid_sistemasprocesos1A").empty();
			$("#grid_sistemasprocesos2A").empty();
			$("#grid_sistemasprocesos3A").empty();
           
            tHtml += '<tr class="titulos_tabla">';
            tHtml += '<th style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center; vertical-align:middle; text-transform:uppercase" width="199">Aspecto Vulnerable</th>';
            tHtml += '<th style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center; vertical-align:middle; text-transform:uppercase" width="150">Observación</th>';
            tHtml += '<th style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center; vertical-align:middle; text-transform:uppercase" width="150">Recomendación</th>';
            tHtml += '<th style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center; vertical-align:middle; text-transform:uppercase" width="70">Calificación</th>';
            tHtml += '</tr>';
			$("#grid_sistemasprocesos").append(tHtml);
			
            tHtml1 += '<tr class="titulos_tabla">';
            tHtml1 += '<th style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center; vertical-align:middle; text-transform:uppercase" colspan="4">Servicios Públicos</th>';
            tHtml1 += '</tr>';
            $.each(result, function (key, val) {
                if (val.tipo == "SP") {
                    tHtml1 += '<tr>';
                    tHtml1 += '<td ' + class_css_btxt + ' width="258">' + val.aspectos + '</td>';
                    tHtml1 += '<td ' + class_css_btxtobser + ' width="84"><input id="sp_observacion_' + val.pk_id_sistemas_procesos + '" type="text"></td>';
                    tHtml1 += '<td ' + class_css_btxtobser + ' width="84"><input id="sp_recomendacion_' + val.pk_id_sistemas_procesos + '" type="text"></td>';
                    tHtml1 += '<td style="border-right: 2px solid lightslategray; vertical-align:middle; text-align:center" width="125" ><select  onchange="obtenerSubtotalSP()"  id="sp_calificacion_' + val.pk_id_sistemas_procesos + '" name="sp_calificacionSP_' + val.pk_id_sistemas_procesos + '"   id="select"><option value="">Seleccione</option><option value="0.0">0.0</option><option value="0.5">0.5</option><option value="1.0">1.0</option></select><input id="sp_tipo_' + val.pk_id_sistemas_procesos + '" value="SP" type="hidden"></td>';
                    tHtml1 += '</tr>';
                }
            });
	        $("#grid_sistemasprocesos1").append(tHtml1);
			
            tHtml1A += '<tr><td width="30%" align="center" class="noborder"><input name="menuSerPub" id="menuSerPub" type="button"class="boton botonactive" style="text-decoration:none; margin-left:30px" value="AGREGAR"  onclick="llamarMenuSistemasProcesos(1)"/><td width="54%" align="right" colspan="2" ' + class_css_btxt + ' class="noborder" >Subtotal</td><td width="16%" align="center" style="border-right: 2px solid lightslategray; vertical-align:middle;" class="noborder"><input name="subtotal_sp" id="subtotal_sp" type="text" style="border:none;width:40%;background-color:transparent;" readonly /></td></td></tr>';

            $("#grid_sistemasprocesos1A").append(tHtml1A);

            tHtml2 += '<tr class="titulos_tabla">';
            tHtml2 += '<th style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center; vertical-align:middle; text-transform:uppercase" colspan="4">Sistemas Alternos</th>';
            tHtml2 += '</tr>';
            $.each(result, function (key, val) {
                if (val.tipo == "SA") {
                    tHtml2 += '<tr>';
                    tHtml2 += '<td ' + class_css_btxt + 'width="258" >' + val.aspectos + '</td>';
                    tHtml2 += '<td ' + class_css_btxtobser + 'width="84" ><input id="sp_observacion_' + val.pk_id_sistemas_procesos + '" type="text"></td>';
                    tHtml2 += '<td ' + class_css_btxtobser + 'width="84" ><input id="sp_recomendacion_' + val.pk_id_sistemas_procesos + '" type="text"></td>';
                    tHtml2 += '<td style="border-right: 2px solid lightslategray; vertical-align:middle; text-align:center" width="125" ><select onchange="obtenerSubtotalSAlt()"  id="sp_calificacion_' + val.pk_id_sistemas_procesos + '" name="sp_calificacionSA_' + val.pk_id_sistemas_procesos + '" id="select"><option value="">Seleccione</option><option value="0.0">0.0</option><option value="0.5">0.5</option><option value="1.0">1.0</option></select><input id="sp_tipo_' + val.pk_id_sistemas_procesos + '" value="SA" type="hidden"></td>';
                    tHtml2 += '</tr>';
                }
            });
            $("#grid_sistemasprocesos2").append(tHtml2);
            tHtml2A += '<tr><td width="30%" align="center" class="noborder"><input name="menuSisAlt" id="menuSisAlt" type="button"class="boton botonactive" style="text-decoration:none; margin-left:30px" value="AGREGAR"  onclick="llamarMenuSistemasProcesos(2)"/><td width="54%" align="right" colspan="2" ' + class_css_btxt + 'class="noborder" >Subtotal</td><td width="16%" align="center" style="border-right: 2px solid lightslategray; vertical-align:middle;" class="noborder" ><input name="subtotal_sa" id="subtotal_sa" type="text" style="border:none;width:40%;background-color:transparent;" readonly /></td></tr>';
            $("#grid_sistemasprocesos2A").append(tHtml2A);

            tHtml3 += '<tr class="titulos_tabla">';
            tHtml3 += '<th style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center; vertical-align:middle; text-transform:uppercase" colspan="4">Recuperación</th>';
            tHtml3 += '</tr>';
            $.each(result, function (key, val) {
                if (val.tipo == "R") {
                    tHtml3 += '<tr>';
                    tHtml3 += '<td ' + class_css_btxt + '  width="258" >' + val.aspectos + '</td>';
                    tHtml3 += '<td ' + class_css_btxtobser + ' width="84" ><input id="sp_observacion_' + val.pk_id_sistemas_procesos + '" type="text"></td>';
                    tHtml3 += '<td ' + class_css_btxtobser + ' width="84"><input id="sp_recomendacion_' + val.pk_id_sistemas_procesos + '" type="text"></td>';
                    tHtml3 += '<td style="border-right: 2px solid lightslategray; vertical-align:middle; text-align:center" width="125" ><select onchange="obtenerSubtotalRec()"  id="sp_calificacion_' + val.pk_id_sistemas_procesos + '" name="sp_calificacionRec_' + val.pk_id_sistemas_procesos + '" id="select"><option value="">Seleccione</option><option value="0.0">0.0</option><option value="0.5">0.5</option><option value="1.0">1.0</option></select><input id="sp_tipo_' + val.pk_id_sistemas_procesos + '" value="R" type="hidden"></td>';
                    tHtml3 += '</tr>';
                }
            });
           $("#grid_sistemasprocesos3").append(tHtml3);
            tHtml3A += '<tr><td width="30%" align="center"class="noborder" ><input name="menuRecup" id="menuRecup" type="button"class="boton botonactive" style="text-decoration:none; margin-left:30px" value="AGREGAR"  onclick="llamarMenuSistemasProcesos(3)"/><td width="54%" align="right" colspan="2" ' + class_css_btxt + 'class="noborder" >Subtotal</td><td width="16%" align="center" style="border-right: 2px solid lightslategray; vertical-align:middle;"class="noborder" ><input name="subtotal_r" id="subtotal_r" type="text" style="border:none;width:40%;background-color:transparent;" readonly /></td></tr>';
            $("#grid_sistemasprocesos3A").append(tHtml3A);
        }
    });
    ObtenerIdentificacionAmenaza();

}

var arIdentAmenazas = new Array();
function GuardarIdentificacionAmenazas(sede) {
    var isede = $("#IdSede").val();
    arIdentAmenazas = new Array();
    var table = document.getElementById('grid_ident_amenaza');
    var checkboxes = table.querySelectorAll('input[type=checkbox]');
    for (var i = 0; i < checkboxes.length; i++) {
        if (checkboxes[i].checked) {
            arIdentAmenazas.push(sede + '|' + checkboxes[i].value + '|' + $("#origen_" + checkboxes[i].value).val() + '|' + $("#text_" + checkboxes[i].value).val() + '|' + $("#calificacion_" + checkboxes[i].value).val());
        }
    }
    GuardarVulnerabilidades(1, arIdentAmenazas, isede);
}

var arPersonas = new Array();
var arOrganizacion = new Array();
var arCapacitacion = new Array();
var arDotacion = new Array();
function GuardarPersonas(sede) {
	 var isede = $("#IdSede").val();
    arPersonas = new Array();
    // var table = document.getElementById('grid_personas1');
    // var table1 = document.getElementById('grid_personas2');
    // var table2 = document.getElementById('grid_personas3');
    // var total=table.rows.length+table1.rows.length+table2.rows.length;
   
 
    for (var i = 1; i <=tamanoPersona ; i++) {
		
        if ($("#p_calificacion_" + i).val() != undefined)
            if ($("#p_calificacion_" + i).val() != "") {
                arPersonas.push(sede + '|' + i + '|' + $("#p_observacion_" + i).val() + '|' + $("#p_recomendacion_" + i).val() + '|' + $("#p_calificacion_" + i).val() + '|' + $("#p_tipo_" + i).val());
                if ($("#p_tipo_" + i).val() == "O")
                    arOrganizacion.push($("#p_calificacion_" + i).val());

                if ($("#p_tipo_" + i).val() == "C")
                    arCapacitacion.push($("#p_calificacion_" + i).val());

                if ($("#p_tipo_" + i).val() == "D")
                    arDotacion.push($("#p_calificacion_" + i).val());

            }
    }


    GuardarVulnerabilidades(2, arPersonas,isede);
}

var arRecursos = new Array();
var arMateriales = new Array();
var arEdificacion = new Array();
var arEquipos = new Array();
function GuardarRecursos(sede) {
    var isede = $("#IdSede").val();
    arRecursos = new Array();
    // var table = document.getElementById('grid_recursos');
    for (var i = 1; i <= tamanoRecurso; i++) {
        if ($("#r_calificacion_" + i).val() != undefined)
            if ($("#r_calificacion_" + i).val() != "") {
                arRecursos.push(sede + '|' + i + '|' + $("#r_observacion_" + i).val() + '|' + $("#r_recomendacion_" + i).val() + '|' + $("#r_calificacion_" + i).val() + '|' + $("#r_tipo_" + i).val());
                if ($("#r_tipo_" + i).val() == "M")
                    arMateriales.push($("#r_calificacion_" + i).val());

                if ($("#r_tipo_" + i).val() == "E")
                    arEdificacion.push($("#r_calificacion_" + i).val());

                if ($("#r_tipo_" + i).val() == "EQ")
                    arEquipos.push($("#r_calificacion_" + i).val());

            }
    }

    GuardarVulnerabilidades(3, arRecursos,isede);
}

var arSP = new Array();
var arServiciosPublicos = new Array();
var arSistemasAlternos = new Array();
var arRecuperacion = new Array();
function GuardarSistemasProcesos(sede) {
	var isede = $("#IdSede").val();
    arSP = new Array();
    // var table = document.getElementById('grid_sistemasprocesos');
    for (var i = 1; i <= tamanoSistemasProcesos; i++) {
        if ($("#sp_calificacion_" + i).val() != undefined)
            if ($("#sp_calificacion_" + i).val() != "") {
                arSP.push(sede + '|' + i + '|' + $("#sp_observacion_" + i).val() + '|' + $("#sp_recomendacion_" + i).val() + '|' + $("#sp_calificacion_" + i).val() + '|' + $("#sp_tipo_" + i).val());
                if ($("#sp_tipo_" + i).val() == "SP")
                    arServiciosPublicos.push($("#sp_calificacion_" + i).val());

                if ($("#sp_tipo_" + i).val() == "SA")
                    arSistemasAlternos.push($("#sp_calificacion_" + i).val());

                if ($("#sp_tipo_" + i).val() == "R")
                    arRecuperacion.push($("#sp_calificacion_" + i).val());

            }
    }

    GuardarVulnerabilidades(4, arSP,isede);
    GuardarConsolidado(sede);
}

function GuardarVulnerabilidades(num, arreglo,isede) {
    $.ajax({
        type: 'GET',
        url: '/PlanEmergencias/GuardarVulnerabilidades',
        data: { num: num, arreglo: arreglo,isede:isede },
        traditional: true,
        success: function (result) {
            /*
			arIdentAmenazas = new Array();
			arPersonas = new Array();
			arRecursos = new Array();
			arSP = new Array();*/
        }
    });
}

function GuardarConsolidado(sede) {
    $.ajax({
        type: 'GET',
        url: '/PlanEmergencias/GuardarConsolidado',
        data: { sede: sede, arOrganizacion: arOrganizacion, arCapacitacion: arCapacitacion, arDotacion: arDotacion, arMateriales: arMateriales, arEdificacion: arEdificacion, arEquipos: arEquipos, arServiciosPublicos: arServiciosPublicos, arSistemasAlternos: arSistemasAlternos, arRecuperacion: arRecuperacion },
        traditional: true,
        success: function (result) {
            arOrganizacion = new Array();
            arCapacitacion = new Array();
            arDotacion = new Array();
            arMateriales = new Array();
            arEdificacion = new Array();
            arEquipos = new Array();
            arServiciosPublicos = new Array();
            arSistemasAlternos = new Array();
            arRecuperacion = new Array();
        }
    });
}

var calper = 0;
function ObtenerConsolidado() {
    $.ajax({
        type: 'POST',
        url: '/PlanEmergencias/ObtenerConsolidado',
        data: { sede: $("#IdSede").val() },
        success: function (result) {
            $("#grid_consolidados").empty();
            var Html = "";
            Html += '<thead style="border-left:2px solid lightslategray;"><tr class="titulos_tabla">';
            Html += '<th width="136" rowspan="2">Aspecto Vulnerable a Calificar</th>';
            Html += '<th colspan="3" align="center">Riesgo</th>';
            Html += '<th width="70" rowspan="2"  align="center">Calificación</th>';
            Html += '<th width="6" rowspan="2"  align="center">Interpretación</th>';
            Html += '<th width="17" rowspan="2"  align="center">Color</th>';
            Html += '</tr>';
            Html += '<tr class="titulos_tabla">';
            Html += '<th width="50">Bueno 0.0</th>';
            Html += '<th width="50">Regular 0.5</th>';
            Html += '<th width="50">Malo 1.0</th>';
            Html += '</tr></thead>';
            Html += '<tr class="titulos_tabla">';
            Html += '<td colspan="7" align="center">Personas</td>';
            Html += '</tr>';
            Html += '<tr>';
            Html += '<td>Organización</td>';
            var subb = 0; subm = 0; subr = 0;
            var b1 = 0; m1 = 0; r1 = 0;
            var b2 = 0; m2 = 0; r2 = 0;
            var b3 = 0; m3 = 0; r3 = 0;
            if (ValidarRiesgo(result.organizacion) == "B") {
                Html += '<td>' + result.organizacion + '</td>';
                b1 = result.organizacion;
            } else
                Html += '<td>0.0</td>';

            if (ValidarRiesgo(result.organizacion) == "R") {
                Html += '<td>' + result.organizacion + '</td>';
                r1 = result.organizacion;
            } else
                Html += '<td>0.0</td>';

            if (ValidarRiesgo(result.organizacion) == "M") {
                Html += '<td>' + result.organizacion + '</td>';
                m1 = result.organizacion;
            } else
                Html += '<td>0.0</td>';

            Html += '<td rowspan="4" style="vertical-align:middle; text-align:center; font-size:30px">' + result.calificacion_personas + '</td>';
            Html += '<td rowspan="4" align="center">' + result.interpretacion_personas + '</td>';
            Html += '<td rowspan="4"><div class="rombo" style="background:' + result.color_personas + ';"></div></td>';
            Html += '</tr>';
            Html += '<tr>';
            Html += '<td >Capacitación</td>';
            if (ValidarRiesgo(result.capacitacion) == "B") {
                Html += '<td>' + result.capacitacion + '</td>';
                b2 = result.capacitacion;
            } else
                Html += '<td>0.0</td>';

            if (ValidarRiesgo(result.capacitacion) == "R") {
                Html += '<td>' + result.capacitacion + '</td>';
                r2 = result.capacitacion;
            } else
                Html += '<td>0.0</td>';

            if (ValidarRiesgo(result.capacitacion) == "M") {
                Html += '<td>' + result.capacitacion + '</td>';
                m2 = result.capacitacion;
            } else
                Html += '<td>0.0</td>';

            Html += '</tr>';
            Html += '<tr>';
            Html += '<td>Dotación</td>';
            if (ValidarRiesgo(result.dotacion) == "B") {
                Html += '<td>' + result.dotacion + '</td>';
                b3 = result.dotacion;
            } else
                Html += '<td>0.0</td>';

            if (ValidarRiesgo(result.dotacion) == "R") {
                Html += '<td>' + result.dotacion + '</td>';
                r3 = result.dotacion;
            } else
                Html += '<td>0.0</td>';

            if (ValidarRiesgo(result.dotacion) == "M") {
                Html += '<td>' + result.dotacion + '</td>';
                m3 = result.dotacion;
            } else
                Html += '<td>0.0</td>';


            subb = b1 + b2 + b3;
            subr = r1 + r2 + r3;
            subm = m1 + m2 + m3;
            Html += '</tr>';
            Html += '<tr class="titulos_tabla">';
            Html += '<td>Subtotal</td>';
            Html += '<td>' + subb.toFixed(2) + '</td>';
            Html += '<td>' + subr.toFixed(2) + '</td>';
            Html += '<td>' + subm.toFixed(2) + '</td>';
            Html += '</tr>';
            Html += '<tr class="titulos_tabla">';
            Html += '<td colspan="7" align="center">Recursos</td>';
            Html += '</tr>';
            Html += '<tr>';
            Html += '<td>Materiales</td>';
            var subb1 = 0; subm1 = 0; subr1 = 0;
            var bb1 = 0; mm1 = 0; rr1 = 0;
            var bb2 = 0; mm2 = 0; rr2 = 0;
            var bb3 = 0; mm3 = 0; rr3 = 0;

            if (ValidarRiesgo(result.materiales) == "B") {
                Html += '<td>' + result.materiales + '</td>';
                bb1 = result.materiales;
            } else
                Html += '<td>0.0</td>';

            if (ValidarRiesgo(result.materiales) == "R") {
                Html += '<td>' + result.materiales + '</td>';
                rr1 = result.materiales;
            } else
                Html += '<td>0.0</td>';

            if (ValidarRiesgo(result.materiales) == "M") {
                Html += '<td>' + result.materiales + '</td>';
                mm1 = result.materiales;
            } else
                Html += '<td>0.0</td>';


            Html += '<td rowspan="4" style="vertical-align:middle; text-align:center; font-size:30px">' + result.calificacion_recursos + '</td>';
            Html += '<td rowspan="4" align="center">' + result.interpretacion_recursos + '</td>';
            Html += '<td rowspan="4"><div class="rombo" style="background:' + result.color_recursos + ';"></div></td>';
            Html += '</tr>';
            Html += '<tr>';
            Html += '<td>Edificación</td>';
            if (ValidarRiesgo(result.edificacion) == "B") {
                Html += '<td>' + result.edificacion + '</td>';
                bb2 = result.edificacion;
            } else
                Html += '<td>0.0</td>';

            if (ValidarRiesgo(result.edificacion) == "R") {
                Html += '<td>' + result.edificacion + '</td>';
                rr2 = result.edificacion;
            } else
                Html += '<td>0.0</td>';

            if (ValidarRiesgo(result.edificacion) == "M") {
                Html += '<td>' + result.edificacion + '</td>';
                mm2 = result.edificacion;
            } else
                Html += '<td>0.0</td>';


            Html += '</tr>';
            Html += '<tr>';
            Html += '<td>Equipos</td>';
            if (ValidarRiesgo(result.equipos) == "B") {
                Html += '<td>' + result.equipos + '</td>';
                bb3 = result.equipos;
            } else
                Html += '<td>0.0</td>';

            if (ValidarRiesgo(result.equipos) == "R") {
                Html += '<td>' + result.equipos + '</td>';
                rr3 = result.equipos;
            } else
                Html += '<td>0.0</td>';

            if (ValidarRiesgo(result.equipos) == "M") {
                Html += '<td>' + result.equipos + '</td>';
                mm3 = result.equipos;
            } else
                Html += '<td>0.0</td>';

            subb1 = bb1 + bb2 + bb3;
            subr1 = rr1 + rr2 + rr3;
            subm1 = mm1 + mm2 + mm3;
            Html += '</tr>';
            Html += '<tr class="titulos_tabla">';
            Html += '<td>Subtotal</td>';
            Html += '<td>' + subb1.toFixed(2) + '</td>';
            Html += '<td>' + subr1.toFixed(2) + '</td>';
            Html += '<td>' + subm1.toFixed(2) + '</td>';
            Html += '</tr>';
            Html += '<tr class="titulos_tabla">';
            Html += '<td colspan="7" align="center">Sistemas y Procesos</td>';
            Html += '</tr>';
            Html += '<tr>';
            Html += '<td>Servicios Públicos</td>';
            var subb2 = 0; subm2 = 0; subr2 = 0;
            var bbb1 = 0; mmm1 = 0; rrr1 = 0;
            var bbb2 = 0; mmm2 = 0; rrr2 = 0;
            var bbb3 = 0; mmm3 = 0; rrr3 = 0;

            if (ValidarRiesgo(result.servicios_publicos) == "B") {
                Html += '<td>' + result.servicios_publicos + '</td>';
                bbb1 = result.servicios_publicos;
            } else
                Html += '<td>0.0</td>';

            if (ValidarRiesgo(result.servicios_publicos) == "R") {
                Html += '<td>' + result.servicios_publicos + '</td>';
                rrr1 = result.servicios_publicos;
            } else
                Html += '<td>0.0</td>';

            if (ValidarRiesgo(result.servicios_publicos) == "M") {
                Html += '<td>' + result.servicios_publicos + '</td>';
                mmm1 = result.servicios_publicos;
            } else
                Html += '<td>0.0</td>';

            Html += '<td rowspan="4" style="vertical-align:middle; text-align:center; font-size:30px">' + result.calificacion_sistemas_procesos + '</td>';
            Html += '<td rowspan="4" align="center">' + result.interpretacion_sistemas_procesos + '</td>';
            Html += '<td rowspan="4"><div class="rombo" style="background:' + result.color_sistemas_procesos + ';"></div></td>';
            Html += '</tr>';
            Html += '<tr>';
            Html += '<td>Sistemas Alternos</td>';
            if (ValidarRiesgo(result.sistemas_alternos) == "B") {
                Html += '<td>' + result.sistemas_alternos + '</td>';
                bbb2 = result.sistemas_alternos;
            } else
                Html += '<td>0.0</td>';

            if (ValidarRiesgo(result.sistemas_alternos) == "R") {
                Html += '<td>' + result.sistemas_alternos + '</td>';
                rrr2 = result.sistemas_alternos;
            } else
                Html += '<td>0.0</td>';

            if (ValidarRiesgo(result.sistemas_alternos) == "M") {
                Html += '<td>' + result.sistemas_alternos + '</td>';
                mmm2 = result.sistemas_alternos;
            } else
                Html += '<td>0.0</td>';

            Html += '</tr>';
            Html += '<tr>';
            Html += '<td>Recuperación</td>';
            if (ValidarRiesgo(result.recuperacion) == "B") {
                Html += '<td>' + result.recuperacion + '</td>';
                bbb3 = result.recuperacion;
            } else
                Html += '<td>0.0</td>';

            if (ValidarRiesgo(result.recuperacion) == "R") {
                Html += '<td>' + result.recuperacion + '</td>';
                rrr3 = result.recuperacion;
            } else
                Html += '<td>0.0</td>';

            if (ValidarRiesgo(result.recuperacion) == "M") {
                Html += '<td>' + result.recuperacion + '</td>';
                mmm3 = result.recuperacion;
            } else
                Html += '<td>0.0</td>';

            subb3 = bbb1 + bbb2 + bbb3;
            subr3 = rrr1 + rrr2 + rrr3;
            subm3 = mmm1 + mmm2 + mmm3;
            Html += '</tr>';
            Html += '<tr class="titulos_tabla">';
            Html += '<td>Subtotal</td>';
            Html += '<td>' + subb3.toFixed(2) + '</td>';
            Html += '<td>' + subr3.toFixed(2) + '</td>';
            Html += '<td>' + subm3.toFixed(2) + '</td>';
            Html += '</tr>';
            Html += '<tr>';
            Html += '<td>&nbsp;</td>';
            Html += '<td>&nbsp;</td>';
            Html += '<td>&nbsp;</td>';
            Html += '<td>&nbsp;</td>';
            Html += '<td>&nbsp;</td>';
            Html += '<td>&nbsp;</td>';
            Html += '<td>&nbsp;</td>';
            Html += '</tr>';
            $("#grid_consolidados").append(Html);
        }
    });

}

function ValidarRiesgo(param) {
    if (param >= 0.0 && param < 0.5)
        return "B";

    if (param >= 0.5 && param < 1.0)
        return "R";

    if (param >= 1.0)
        return "M";

}


function ObtenerIdentificacionAmenaza() {
    $.ajax({
        type: 'GET',
        url: '/PlanEmergencias/ObtenerIdentificacionAmenaza',
        data: { pk_id_sede: $("#IdSede").val() },
        success: function (result) {
            $.each(result, function (key, val) {
                $("#chk_" + val.fk_id_amenaza + "").prop("checked", true);
                $("#origen_" + val.fk_id_amenaza + "").val(val.origen);
                $("#origen_" + val.fk_id_amenaza + "").removeAttr('disabled');
                $("#text_" + val.fk_id_amenaza + "").val(val.fuenteriesgo);
                $("#text_" + val.fk_id_amenaza + "").removeAttr('disabled');
                $("#calificacion_" + val.fk_id_amenaza + "").val(val.calificacion);
                $("#calificacion_" + val.fk_id_amenaza + "").removeAttr('disabled');
                $("#color_" + val.fk_id_amenaza + "").css("background", val.color);

            });
        }
    });
}

function ObtenerPersona() {
    var subtotal_o = 0;
    var subtotal_c = 0;
    var subtotal_d = 0;
    var contadorO = 0;
    var contadorC = 0;
    var contadorD = 0;
    var promedioO=0;
	var promedioC=0;
	var promedioD=0;
	
    $.ajax({
        type: 'GET',
        url: '/PlanEmergencias/ObtenerPersona',
        data: { pk_id_sede: $("#IdSede").val() },
        success: function (result) {
            $.each(result, function (key, val) {
                $("#p_observacion_" + val.fk_id_aspecto + "").val(val.observacion);
                $("#p_recomendacion_" + val.fk_id_aspecto + "").val(val.recomendacion);
                $("#p_calificacion_" + val.fk_id_aspecto + "").val(val.calificacion);
                
               
                if (val.tipo == "O"){
                    contadorO++;
                    subtotal_o += parseFloat($("#p_calificacion_" + val.fk_id_aspecto).val());
				
				}
                    if (val.tipo == "C"){
                     contadorC++;
                    subtotal_c += parseFloat($("#p_calificacion_" + val.fk_id_aspecto).val());
					}
                    if (val.tipo == "D"){
                    contadorD++;
                    subtotal_d += parseFloat($("#p_calificacion_" + val.fk_id_aspecto).val());
					}

            });
			
				
			promedioO=(subtotal_o/contadorO).toFixed(2);
			promedioC=(subtotal_c/contadorC).toFixed(2);
			promedioD = (subtotal_d / contadorD).toFixed(2);
			if(promedioO=="NaN")
			{
			    promedioO = 0;
			}

			if (promedioC == "NaN") {
			    promedioC = 0;
			}

			if (promedioD == "NaN") {
			    promedioD = 0;
			}
        },
        complete: function (result) {
            $("#subtotal_o").val(promedioO);
            $("#subtotal_c").val(promedioC);
            $("#subtotal_d").val(promedioD);
        }
    });


}

function ObtenerRecurso() {
    var subtotal_m = 0;
    var subtotal_e = 0;
    var subtotal_eq = 0;
	var contadorM = 0;
    var contadorE = 0;
    var contadorEQ = 0;
    var promedioM=0;
	var promedioE=0;
	var promedioEQ=0;
	
    $.ajax({
        type: 'GET',
        url: '/PlanEmergencias/ObtenerRecurso',
        data: { pk_id_sede: $("#IdSede").val() },
        success: function (result) {
            $.each(result, function (key, val) {
                $("#r_observacion_" + val.fk_id_aspecto + "").val(val.observacion);
                $("#r_recomendacion_" + val.fk_id_aspecto + "").val(val.recomendacion);
                $("#r_calificacion_" + val.fk_id_aspecto + "").val(val.calificacion);
                if (val.tipo == "M"){
                    subtotal_m += parseFloat($("#r_calificacion_" + val.fk_id_aspecto).val());
					contadorM++;
				}
                if (val.tipo == "E"){
                    subtotal_e += parseFloat($("#r_calificacion_" + val.fk_id_aspecto).val());
					contadorE++;
				}
                if (val.tipo == "EQ"){
                    subtotal_eq += parseFloat($("#r_calificacion_" + val.fk_id_aspecto).val());
					contadorEQ++;
				}
            });
			
		    promedioM=(subtotal_m/contadorM).toFixed(2);
			promedioE=(subtotal_e/contadorE).toFixed(2);
			promedioEQ = (subtotal_eq / contadorEQ).toFixed(2);
			if (promedioM == "NaN") {
			    promedioM = 0;
			}

			if (promedioE == "NaN") {
			    promedioE = 0;
			}

			if (promedioEQ == "NaN") {
			    promedioEQ = 0;
			}
        },
        complete: function (result) {
            $("#subtotal_m").val(promedioM);
            $("#subtotal_e").val(promedioE);
            $("#subtotal_eq").val(promedioEQ);
        }
    });
}

function ObtenerSistemaProceso() {
    var subtotal_sp = 0;
    var subtotal_sa = 0;
    var subtotal_r = 0;
	
	var subtotal_sp = 0;
    var subtotal_sa = 0;
    var subtotal_r = 0;
    var contadorSP = 0;
    var contadorSA = 0;
    var contadorR = 0;
    var promedioSP=0;
	var promedioSA=0;
	var promedioR=0;
    $.ajax({
        type: 'GET',
        url: '/PlanEmergencias/ObtenerSistemaProceso',
        data: { pk_id_sede: $("#IdSede").val() },
        success: function (result) {
            $.each(result, function (key, val) {
                $("#sp_observacion_" + val.fk_id_aspecto + "").val(val.observacion);
                $("#sp_recomendacion_" + val.fk_id_aspecto + "").val(val.recomendacion);
                $("#sp_calificacion_" + val.fk_id_aspecto + "").val(val.calificacion);

                if (val.tipo == "SP"){
                    subtotal_sp += parseFloat($("#sp_calificacion_" + val.fk_id_aspecto).val());
                   contadorSP++;
				}
                if (val.tipo == "SA"){
                    subtotal_sa += parseFloat($("#sp_calificacion_" + val.fk_id_aspecto).val());
					contadorSA++;
				}
                if (val.tipo == "R"){
                    subtotal_r += parseFloat($("#sp_calificacion_" + val.fk_id_aspecto).val());
					contadorR++;
				}
            });
			
			 promedioSP=(subtotal_sp/contadorSP).toFixed(2);
			promedioSA=(subtotal_sa/contadorSA).toFixed(2);
			promedioR = (subtotal_r / contadorR).toFixed(2);

			if (promedioSP == "NaN") {
			    promedioSP = 0;
			}

			if (promedioSA == "NaN") {
			    promedioSA = 0;
			}

			if (promedioR == "NaN") {
			    promedioR = 0;
			}
        },
        complete: function (result) {
            $("#subtotal_sp").val(promedioSP);
            $("#subtotal_sa").val(promedioSA);
            $("#subtotal_r").val(promedioR);
        }
    });
}

function AnalisisRiesgo() {
    $.ajax({
        type: 'GET',
        url: '/PlanEmergencias/AnalisisRiesgo',
        data: { pk_id_sede: $("#IdSede").val() },
        success: function (result) {
            var tHtml = "";
            $("#gridriesgo").empty();
            tHtml += '<thead style="border-left:2px solid lightslategray;"><tr class="titulos_tabla">';
            tHtml += '<th ' + class_css_header + '>Amenazas</td>';
            tHtml += '<th ' + class_css_header + '>Generar Intervención</th>';
            tHtml += '<th ' + class_css_header + '>Plan de Acción</th>';
            tHtml += '</tr></thead>';
            $.each(result, function (key, val) {
                tHtml += '<tbody style="border-left:2px solid lightslategray;"><tr class="titulos_filas">';
                tHtml += '<td ' + class_css_btxt + '>' + val.amenaza + '</td>';
                tHtml += '<td ' + class_css_btxt + '><input id="archk_' + val.pk_id_amenazas + '" type="checkbox" value="' + val.pk_id_amenazas + '"/></td>';
                tHtml += '<td ' + class_css_btxt + '><input id="riesgo_' + val.pk_id_amenazas + '" type="text" class="form-control"></td>';
                tHtml += '</tr></tbody>';
            });
            $("#gridriesgo").append(tHtml);
        }
    });

    ObtenerAnalisisRiesgo();
}

function ObtenerAnalisisRiesgo() {
    $.ajax({
        type: 'GET',
        url: '/PlanEmergencias/ObtenerAnalisisRiesgo',
        data: { pk_id_sede: $("#IdSede").val() },
        success: function (result) {
            $.each(result, function (key, val) {
                $("#archk_" + val.fk_id_identamenaza + "").prop('checked', true);
                $("#riesgo_" + val.fk_id_identamenaza + "").val(val.plan_de_accion);
            });
        }
    });
}


function guardarriesgo(numtab) {
    var arAmenazas = new Array();
    var table = document.getElementById('gridriesgo');
    var checkboxes = table.querySelectorAll('input[type=checkbox]');
    for (var i = 0; i < checkboxes.length; i++) {
        if (checkboxes[i].checked) {
            arAmenazas.push(checkboxes[i].value + '|' + $("#riesgo_" + checkboxes[i].value).val());
        }
    }

    $.ajax({
        type: 'GET',
        url: '/PlanEmergencias/GuardarAnalisisRiesgos',
        data: { sede: $("#IdSede").val(), arAmenazas: arAmenazas },
        traditional: true,
        success: function (result) {
            arAmenazas = new Array();
            $("#tabs").tabs({ active: numtab });
        }
    });
}

function tabs_vulneravilidades_Guardar() {
    $('#myModal5').modal('hide');
    AnalisisRiesgo();
}

function soloNumeros(e) {
    var key = window.Event ? e.which : e.keyCode
    return (key >= 48 && key <= 57)
}


function ObtenerNivelesRiesgo() {
    $.ajax({
        type: 'GET',
        url: '/PlanEmergencias/ObtenerNivelesRiesgo',
        data: { isede: $("#IdSede").val() },
        success: function (result) {
            var tHtml = "";
            $("#grid_nivel_riesgo").empty();
            tHtml += '<thead style="border-left:2px solid lightslategray;"><tr class="titulos_tabla"><td colspan="3" align="center">Naturales</td></tr>';
            tHtml += '<tr class="titulos_tabla">';
            tHtml += '<th ' + class_css_header + '>Amenaza</th>';
            tHtml += '<th ' + class_css_header + '>Diamante de Riesgo</th>';
            tHtml += '<th ' + class_css_header + '>Interpretación</th>';
            tHtml += '</tr></thead>';
            $.each(result, function (key, val) {
                if (val.tipo == 'N') {
                    tHtml += '<tbody style="border-left:2px solid lightslategray;"><tr class="titulos_filas">';
                    tHtml += '<td>&nbsp;' + val.amenaza + '</td>';
                    tHtml += '<td ' + class_css_btxt + '>';
                    tHtml += '<div class="animation-1">';
                    tHtml += '<div class="box1" style="background-color:' + val.color_r + ';"><div class="rdiv" style="border:none;text-align:center;">R</div></div>';
                    tHtml += '<div class="box2" style="background-color:' + val.color_s + ';"><div class="rdiv" style="border:none;text-align:center;">S</div></div>';
                    tHtml += '<div class="box3" style="background-color:' + val.color_p + ';"><div class="rdiv" style="border:none;text-align:center;">P</div></div>';
                    tHtml += '<div class="box4" style="background-color:' + val.color_a + ';"><div class="rdiv" style="border:none;text-align:center;">A</div></div>';
                    tHtml += '</div>';
                    tHtml += '</td>';
                    tHtml += '<td align="center">&nbsp;' + val.interpretacion + '</td>';
                    tHtml += '</tr></thead>';
                }
            });
            tHtml += '<thead style="border-left:2px solid lightslategray;"><tr class="titulos_tabla"><td colspan="3" align="center">Tecnológicos</td></tr>';
            tHtml += '<tr class="titulos_tabla">';
            tHtml += '<th ' + class_css_header + '>Amenaza</th>';
            tHtml += '<th ' + class_css_header + '>Diamante de Riesgo</th>';
            tHtml += '<th ' + class_css_header + '>Interpretación</th>';
            tHtml += '</tr>';
            $.each(result, function (key, val) {
                if (val.tipo == 'T') {
                    tHtml += '<tbody style="border-left:2px solid lightslategray;"><tr class="titulos_filas">';
                    tHtml += '<td>&nbsp;' + val.amenaza + '</td>';
                    tHtml += '<td ' + class_css_btxt + '>';
                    tHtml += '<div class="animation-1">';
                    tHtml += '<div class="box1" style="background-color:' + val.color_r + ';"><div class="rdiv" style="border:none;text-align:center;">R</div></div>';
                    tHtml += '<div class="box2" style="background-color:' + val.color_s + ';"><div class="rdiv" style="border:none;text-align:center;">S</div></div>';
                    tHtml += '<div class="box3" style="background-color:' + val.color_p + ';"><div class="rdiv" style="border:none;text-align:center;">P</div></div>';
                    tHtml += '<div class="box4" style="background-color:' + val.color_a + ';"><div class="rdiv" style="border:none;text-align:center;">A</div></div>';
                    tHtml += '</div>';
                    tHtml += '</td>';
                    tHtml += '<td align="center">&nbsp;' + val.interpretacion + '</td>';
                    tHtml += '</tr></thead>';
                }
            });
            tHtml += '<thead style="border-left:2px solid lightslategray;"><tr class="titulos_tabla"><td colspan="3" align="center">Sociales</td></tr>';
            tHtml += '<tr class="titulos_tabla">';
            tHtml += '<th ' + class_css_header + '>Amenaza</th>';
            tHtml += '<th ' + class_css_header + '>Diamante de Riesgo</th>';
            tHtml += '<th ' + class_css_header + '>Interpretación</th>';
            tHtml += '</tr>';
            $.each(result, function (key, val) {
                if (val.tipo == 'S') {
                    tHtml += '<tbody style="border-left:2px solid lightslategray;"><tr class="titulos_filas">';
                    tHtml += '<td>&nbsp;' + val.amenaza + '</td>';
                    tHtml += '<td ' + class_css_btxt + '>';
                    tHtml += '<div class="animation-1">';
                    tHtml += '<div class="box1" style="background-color:' + val.color_r + ';"><div class="rdiv" style="border:none;text-align:center;">R</div></div>';
                    tHtml += '<div class="box2" style="background-color:' + val.color_s + ';"><div class="rdiv" style="border:none;text-align:center;">S</div></div>';
                    tHtml += '<div class="box3" style="background-color:' + val.color_p + ';"><div class="rdiv" style="border:none;text-align:center;">P</div></div>';
                    tHtml += '<div class="box4" style="background-color:' + val.color_a + ';"><div class="rdiv" style="border:none;text-align:center;">A</div></div>';
                    tHtml += '</div>';
                    tHtml += '</td>';
                    tHtml += '<td align="center">&nbsp;' + val.interpretacion + '</td>';
                    tHtml += '</tr></thead>';
                }
            });

            $("#grid_nivel_riesgo").append(tHtml);
        }
    });
}


function DescargarExcel(parametro) {
    $.ajax({
        type: 'POST',
        url: '/PlanEmergencias/DescargarExcel',
        data: { parametro: parametro },
        success: function (result) {
            window.location = '/PlanEmergencias/DownloadExcel?file=' + result;
        }
    });

}
function obtenerNombreAdjunto() {
    var texto = document.getElementById('upload_adjuntos').files[0].name;
    $("#nombreUpload").text(texto)
}
function obtenerNombreAdjunto1() {
    var texto = document.getElementById('upload_adjuntos1').files[0].name;
    $("#nombreUpload1").text(texto)
}

function obtenerNombreAdjunto2() {
    var texto = document.getElementById('upload_adjuntos2').files[0].name;
    $("#nombreUpload2").text(texto)
}

function obtenerNombreEstructuraOrg() {
    var texto = document.getElementById('upload').files[0].name;
    $("#cargarEstOrganizacional").text(texto)
}

function obtenerNombreInformacionTrabajador() {
    var texto = document.getElementById('upload1').files[0].name;
    $("#nombreUploadInfTrabajador").text(texto)
}

function obtenerNombreBDExterna() {
    var texto = document.getElementById('upload2').files[0].name;
    $("#nombreUploadBDExterna").text(texto)
}
function obtenerNombrePlanAyuda() {
    var texto = document.getElementById('upload3').files[0].name;
    $("#nombreUploadPlanAyuda").text(texto)
}

function obtenerNombrePlanSeguridadFisica() {
    var texto = document.getElementById('upload_frenteaccion_adjunto1').files[0].name;
    $("#nombreUploadSeguridadBasica").text(texto)
}

function obtenerPlanAtencionMedica() {
    var texto = document.getElementById('upload_frenteaccion_adjunto2').files[0].name;
    $("#nombreUploadPlanAtencionMedica").text(texto)
}

function obtenerPlanContraIncendios() {
    var texto = document.getElementById('upload_frenteaccion_adjunto3').files[0].name;
    $("#nombreUploadContraIncendios").text(texto)
}

function obtenerPlanContraIncendios() {
    var texto = document.getElementById('upload_frenteaccion_adjunto3').files[0].name;
    $("#nombreUploadContraIncendios").text(texto)
}

function obtenerNombrePlanEvaluacion() {
    var texto = document.getElementById('upload_frenteaccion_adjunto4').files[0].name;
    $("#nombreUploadPlanEvacuacion").text(texto)
}

function obtenerNombreRutaEvacuacion() {
    var texto = document.getElementById('upload_frenteaccion_adjunto5').files[0].name;
    $("#nombreRutaEvacuacion").text(texto)
}

function obtenerPlanAyudaMutua() {
    var texto = document.getElementById('upload_adjuntoPAM').files[0].name;
    $("#nombrePlanAyudaMutua").text(texto)
}

$('#hl-start-upload1').click(function () {
    //   var formData = new FormData(document.getElementById("frmEsquemaOrganizacion"));




    var idSede = $("#IdSede").val();
    var formData = new FormData(document.getElementById("frmEsquemaOrganizacion"));
    formData.append("idSede", idSede);
    var filedata = $("#upload1").prop("files")[0];
    if (filedata != undefined)
        formData.append("cargarArchivo", filedata);
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
        data: formData,
        url: urlBase + '/PlanEmergencias/CargueMasivoBDInterna',
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
            ListarBDInterna($("#IdSede").val());

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






$('#hl-start-upload2').click(function () {
    //   var formData = new FormData(document.getElementById("frmEsquemaOrganizacion"));




    var idSede = $("#IdSede").val();
    var formData = new FormData(document.getElementById("frmEsquemaOrganizacion"));
    formData.append("idSede", idSede);
    var filedata = $("#upload2").prop("files")[0];
    if (filedata != undefined)
        formData.append("cargarArchivo", filedata);
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
        data: formData,
        url: urlBase + '/PlanEmergencias/CargueMasivoBDExterna',
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
            ListarBDExterna($("#IdSede").val());

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

$('#hl-start-upload3').click(function () {
    //   var formData = new FormData(document.getElementById("frmEsquemaOrganizacion"));
    var idSede = $("#IdSede").val();
    var formData = new FormData(document.getElementById("frmEsquemaOrganizacion"));
    formData.append("idSede", idSede);
    var filedata = $("#upload3").prop("files")[0];
    if (filedata != undefined)
        formData.append("cargarArchivo", filedata);
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
        data: formData,
        url: urlBase + '/PlanEmergencias/CargueMasivoBDPlanAyuda',
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
            ListarBDPlanAyuda($("#IdSede").val());

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

function CrearEstructuraOrganizacional() {
    var isede = $("#IdSede").val();
    $.ajax({
        type: 'POST',
        url: '/PlanEmergencias/CrearEstructuraOrganizacional',
        data: { isede: isede },
        success: function (result) {
            if (result) {


                window.location.href = "CrearEstructuraOrganizacional?isede=" + isede;
            }

            else {
            }

        }


    });
}

function VerEstructuraOrganizacional() {
    var isede = $("#IdSede").val();
    $.ajax({
        type: 'POST',
        url: '/PlanEmergencias/Organigrama',
        data: { isede: isede },
        success: function (result) {
            if (result) {


                window.location.href = "Organigrama?isede=" + isede;
            }

            else {
            }

        }


    });
}

function volverIndex() {


    window.location.href = "Index";
}

$("#guardarCargoEmergencia").click(function () {
    var cargo = $("#cargo_Empleado").val();
    var form = $("#formEstructuraOrganizacional");

    if (cargo == "") {
        swal({
            type: 'warning',
            title: 'Estimado Usuario:',
            text: 'Debe seleccionar un Cargo de Emergencia',
            confirmButtonColor: '#7E8A97'
        });
        return false;
    }
    else {
        form.submit();
    }


});

$("#editarEstructura").click(function () {

    var cargo = $("#cargo_Empleado").val();
    var form = $("#formEditarEstructuraOrganizacional");

    if (cargo == "") {
        swal({
            type: 'warning',
            title: 'Estimado Usuario:',
            text: 'Debe seleccionar un Cargo de Emergencia',
            confirmButtonColor: '#7E8A97'
        });
        return false;
    }
    else {
        form.submit();
    }

});


function ListarEstructura() {
    var isede = $("#fk_id_sede").val();

    $.ajax({
        type: 'POST',
        url: '/PlanEmergencias/Listado',
        data: { isede: isede },
        success: function (result) {
            if (result) {


                window.location.href = "listado?isede=" + isede;
            }

            else {
            }

        }


    });
}



function generarNuevo(idSede) {
 

    var sede = idSede;
    $.ajax({
        type: 'GET',
        url: '/PlanEmergencias/ObtenerInfoSede',
        data: { isede: sede },
        success: function (result) {

            $("#objetivos").val(result.objetivos);
            $("#alcance").val(result.alcance);
            $("#razon_social").val(result.razon_social);
            $("#identificacion_sede").val(result.identificacion_sede);
            $("#direccion_sede").val(result.direccion_sede);
            $("#telefono_sede").val(result.telefono_sede);
            $("#correo_electronico").val(result.correo_electronico);
            $("#departamento_sede").val(result.departamento_sede);
            $("#municipio_sede").val(result.municipio_sede);
            $("#actividad_economica").val(result.actividad_economica);
            $("#representante").val(result.representante);
            $("#lindero_norte").val(result.lindero_norte);
            $("#lindero_sur").val(result.lindero_sur);
            $("#lindero_occidente").val(result.lindero_occidente);
            $("#lindero_oriente").val(result.lindero_oriente);
            $("#acceso_principales").val(result.acceso_principales);
            $("#acceso_alternas").val(result.acceso_alternas);
            $("#trabajadores_cantidad").val(result.trabajadores_cantidad);
            $("#trabajadores_hdesde").val(result.trabajadores_hdesde);
            $("#trabajadore_hhasta").val(result.trabajadore_hhasta);
            $("#contratista_cantidad").val(result.contratista_cantidad);
            $("#contratista_hdesde").val(result.contratista_hdesde);
            $("#contratista_hhasta").val(result.contratista_hhasta);

            // Visitante
            $("#visitante_cantidad").val(result.visitante_cantidad);
            $("#visitante_hdesde").val(result.visitante_hdesde);
            $("#visitantte_hhasta").val(result.visitantte_hhasta);

            $("#cliente_cantidad").val(result.cliente_cantidad);
            $("#cliente_hdesde").val(result.cliente_hdesde);
            $("#cliente_hhasta").val(result.cliente_hhasta);
            $("#bo_tratamiento_especial").prop("checked", result.bo_tratamiento_especial);

            $("#cual").val(result.cual);
            $("#ventilacion_mecanica").val(result.ventilacion_mecanica);
            $("#ascensores").val(result.ascensores);
            $("#sotanos").val(result.sotanos);
            $("#red_hidraulica").val(result.red_hidraulica);
            $("#transformadores").val(result.transformadores);
            $("#plantas_electricas").val(result.plantas_electricas);
            $("#escaleras").val(result.escaleras);
            $("#zonas_parqueo").val(result.zonas_parqueo);
            $("#areas_especiales").val(result.areas_especiales);
            $("#estructurales_descripcion").val(result.estructurales_descripcion);
            $("#estructurales_ubicacion").val(result.estructurales_ubicacion);
            $("#equipos_descripcion").val(result.equipos_descripcion);
            $("#equipos_ubicacion").val(result.equipos_ubicacion);
            $("#insumos_descripcion").val(result.insumos_descripcion);
            $("#insumos_ubicacion").val(result.insumos_ubicacion);
            $("#bo_externo").prop("checked", result.bo_externo);
            $("#bo_colegio").prop("checked", result.bo_colegio);
            $("#bo_iglesia").prop("checked", result.bo_iglesia);
            $("#bo_comercial").prop("checked", result.bo_comercial);
            $("#bo_centro_atencion").prop("checked", result.bo_centro_atencion);
            $("#bo_parque").prop("checked", result.bo_parque);
            $("#bo_otro").prop("checked", result.bo_otro);
            $("#tab3_cual").val(result.tab3_cual);
            $("#bo_ZonaIndustrial").prop("checked", result.bo_ZonaIndustrial);
            $("#bo_ZonaResidencial").prop("checked", result.bo_ZonaResidencial);
            $("#bo_ZonaComercial").prop("checked", result.bo_ZonaComercial);
            $("#bo_ZonaMixta").prop("checked", result.bo_ZonaMixta);


            //$("#punto_encuentro").val(result.punto_encuentro_img);
            //$("#ubicacion_hidrantes").val(result.ubicacion_hidrantes_img);
            $("#punto_encuentro").val(result.ubicacion_hidrantes);
            $("#ubicacion_hidrantes").val(result.punto_encuentro);


            $("#plan_seguridadfisica").val(result.plan_seguridadfisica);
            $("#plan_primerosaux").val(result.plan_primerosaux);
            $("#plan_contraincendios").val(result.plan_contraincendios);
            $("#plan_Evacuacion").val(result.plan_Evacuacion);
            $("#nombrecoordinador").val(result.nombrecoordinador);
            $("#tab7_objetivos").val(result.tab7_objetivos);
            $("#estructura").val(result.estructura);
            $("#proc_coordinacion").val(result.proc_coordinacion);
            $("#proc_internos").val(result.proc_internos);
            $("#proc_externos").val(result.proc_externos);
            $("#mecanismos_alarma").val(result.mecanismos_alarma);
            $("#simulacros").val(result.simulacros);
            $("#instructivo_evacuacion").val(result.instructivo_evacuacion);
            $("#proc_retorno").val(result.proc_retorno);
            $("#fk_id_sede_generalidades").val(sede);
            $("#fk_id_sede_infogeneral").val(sede);
            $("#fk_id_sede_descocupacion").val(sede);
            $("#fk_id_sede_cinstalaciones").val(sede);
            $("#fk_id_sede_elementos").val(sede);
            $("#fk_id_sede_georeferenciacion").val(sede);
            $("#fk_id_sede_roles").val(sede);
            $("#fk_id_sede_frenteaccion").val(sede);
            $("#fk_id_sede_proc_normalizados").val(sede);
            $("#fk_id_sede_nivelemergencia").val(sede);
            $("#fk_id_sede_recursosh").val(sede);
            $("#fk_id_sede_recursostecnicos").val(sede);



            ListarRTecnicos(sede);
            ListarHR(sede);
            ListarProcedimientosOperativosNormalizados(sede);
            ListarRoles(sede);
            ListarNivelesEmergencia(sede);
            ListarBDInterna(sede);
            ListarBDExterna(sede);
            ListarBDPlanAyuda(sede);
            AnalisisRiesgo();

            for (i = 0; i <= 7; i++) {
                $("#tabs").tabs("enable", i);
            }

            $("#tabs").tabs({ active: 4 });

        }
    });
}

function llamarMenuPersonas(tipo) {
    $("#nuevoAspectoVulPer").val("");
    var tipoSel = "";
    var sede = $("#IdSede").val();
    if (tipo == 1) {
        tipoSel = "O";
    }
    else if (tipo == 2) {
        tipoSel = "C";
    }
    else {
        tipoSel = "D";
    }
   
    
    $('#myModAnalVulPer').modal('show');
    $("#tipoVulPer").val(tipoSel);
    $("#Fk_SedeVulPer").val(sede);

}


    


function llamarMenuRecursos(tipo) {
    $("#nuevoAspectoVulRec").val("");
    var sede = $("#IdSede").val();
    var tipoSel = "";
    if (tipo == 1) {
        tipoSel = "M";
    }
    else if (tipo == 2) {
        tipoSel = "E";
    }
    else {
        tipoSel = "EQ";
    }
  
    $('#myModAnalVulReursos').modal('show');
    $("#tipoVulRec").val(tipoSel);
    $("#Fk_SedeVulRec").val(sede);
}

function llamarMenuSistemasProcesos(tipo) {
    $("#nuevoAspectoVulSYP").val("");
    var sede = $("#IdSede").val();
    var tipoSel = "";
    if (tipo == 1) {
        tipoSel = "SP";
    }
    else if (tipo == 2) {
        tipoSel = "SA";
    }
    else {
        tipoSel = "R";
    }
    
   
    $('#myModAnalVulSistemasYProcesos').modal('show');
    $("#tipoVulSYP").val(tipoSel);
    $("#Fk_SedeVulSYP").val(sede);
}

//function GuardarNivelVulPersona() {

//    var form = $('#formAnalVulPersona');

//    $.ajax({
//        type: 'POST',
//        url: '/PlanEmergencias/GuardarAspVulnerabilidadPersonas',
//        data: form.serialize(),
//        traditional: true,
//        success: function (result) {
//            $('#myModAnalVulPer').modal('hide');
//            //ListarPreguntasIdentificacionAmenazas();
//            ListaPersonas();
//            //ListaRecursos();
//            //ListaSistemasProcesos();
//        }
//    });

//}

//function GuardarNivelVulRecursos() {

//    var form = $('#formAnalVulRecursos');

//    $.ajax({
//        type: 'POST',
//        url: '/PlanEmergencias/GuardarAspVulnerabilidadRecursos',
//        data: form.serialize(),
//        traditional: true,
//        success: function (result) {
//            $('#myModAnalVulReursos').modal('hide');
//            //ListarPreguntasIdentificacionAmenazas();
//           // ListaPersonas();
//            ListaRecursos();
//            //ListaSistemasProcesos();
//        }
//    });

//}

//function GuardarNivelVulSistemasYProcesos() {

//    var form = $('#formAnalVulSistemasYProcesos');

//    $.ajax({
//        type: 'POST',
//        url: '/PlanEmergencias/GuardarAspVulnerabilidadSistemasYProcesos',
//        data: form.serialize(),
//        traditional: true,
//        success: function (result) {
//            $('#myModAnalVulSistemasYProcesos').modal('hide');
//            //ListarPreguntasIdentificacionAmenazas();
//            // ListaPersonas();
//            //ListaRecursos();
//            ListaSistemasProcesos();
//        }
//    });

//}

function CrearPlanAyudaMutua() {
    reiniciarCamposPlanAyuda();
    var sede = $("#IdSede").val();
    $('#myModBDPlanAyuda').modal('show');
    $("#Fk_SedePlanAyuda").val(sede);
}



function validarBDAyuda(){

    $('#formularioBDPlanAyudaMutua').validate({
        rules: {
            empresaParticipante: { required: true },
            recursosDisposicion: { required: true },

            compesacionEconomica: { required: true },
            reintegroDelRecurso: { required: true },
            nombreDelContactoAM: { required: true },
            telefonoDeContactoAM: { required: true },

        },
        messages: {
            empresaParticipante: {
                required: "El campo Empresa Participante es obligatorio"
            },
            recursosDisposicion: {
                required: "EL Campo Recursos a Disposición es obligatorio"
            },

            compesacionEconomica: {
                required: "El campo Compesación Económica es obligatorio"
            },
            reintegroDelRecurso: {
                required: "El campo Reintegro del Recurso es obligatorio"
            },
            nombreDelContactoAM: {
                required: "ELcampo  Nombre del Contacto es obligatorio"
            },
            telefonoDeContactoAM: {
                required: "El campo Teléfono del Contacto es obligatorio"
            },

        }

    });
}

$('#guardarPlanAyuda').click(function () {
    var form = $("#formularioBDPlanAyudaMutua");
    if (!$("#formularioBDPlanAyudaMutua").valid()) {
        validacion = false;
    }
    else {
        validacion = true;
    }
    
    if(validacion)
    {
        var form = $('#formularioBDPlanAyudaMutua');

        $.ajax({
            type: 'POST',
            url: '/PlanEmergencias/GuardarPlanAyudaMutua',
            data: form.serialize(),
            traditional: true,
            success: function (result) {

                swal("Estimado Usuario", 'Registro guardado Exitosamente', "success");
                $('#myModBDPlanAyuda').modal('hide');

                ListarBDPlanAyuda($("#IdSede").val());
            }
        });
    }

});

function CrearBDExterna() {
    reiniciarCamposBDExterna();
    var sede = $("#IdSede").val();
    $('#myModBDExterna').modal('show');
    $("#Fk_SedeBDExterna").val(sede);
}

$('#guardarBDExterna').click(function () {
    var form = $("#formularioBDExterna");
    if (!$("#formularioBDExterna").valid()) {
        validacion = false;
    }
    else {
        validacion = true;
    }

    if (validacion) {
        var form = $('#formularioBDExterna');

        $.ajax({
            type: 'POST',
            url: '/PlanEmergencias/GuardarBDExterna',
            data: form.serialize(),
            traditional: true,
            success: function (result) {


                swal("Estimado Usuario", 'Registro guardado Exitosamente', "success");
                $('#myModBDExterna').modal('hide');

                ListarBDExterna($("#IdSede").val());
            }
        });
    }

});




function validarBDExterna() {

    $('#formularioBDExterna').validate({
        rules: {
            entidadBE: { required: true },
            direccionBE: { required: true },
            telefonoBE: { required: true },
            contactoBE: { required: true },
        },
        messages: {
            entidadBE: {
                required: "El campo Entidad es obligatorio"
            },
            direccionBE: {
                required: "EL Campo Dirección es obligatorio"
            },

            telefonoBE: {
                required: "El campo Teléfono es obligatorio"
            },
            contactoBE: {
                required: "El  campo Nombre del Contacto es obligatorio"
            },
        }

    });
}


function CrearBDInterna() {
    reiniciarCamposBDInterna();
   
    var sede = $("#IdSede").val();
    $('#myModBDInterna').modal('show');
    $("#Fk_SedeBDInterna").val(sede);
    $("#nombreBI").css("background-color", "whitesmoke").css("color", "#black").css("border", "groove");;
    $("#sexoBI").css("background-color", "whitesmoke").css("color", "#black").css("border", "groove");;
    $("#epsBI").css("background-color", "whitesmoke").css("color", "#black").css("border", "groove");;

}

function validarBDInterna() {

    $('#formularioBDInterna').validate({
        rules: {
            documentoBI: { required: true },
            nombreBI: { required: true },
            sexoBI: { required: true },
            epsBI: { required: true },
            grupoRHBI:{required:true},
            nombreContactoBI: { required: true },
            telefonoContactoBI: { required: true },
            ParentescoBI: { required: true },
            requiereManejoBI: { required: true },


        },
        messages: {
            documentoBI: {
                required: "El campo Documento es obligatorio"
            },
            nombreBI: {
                required: "EL Campo nombre es obligatorio"
            },

            sexoBI: {
                required: "El campo Sexo es obligatorio"
            },

            epsBI:{
                required:"El campo EPS es obligatorio"
            },
            grupoRHBI: {
                required: "Se debe Seleccionar un tipo de RH"
            },

            nombreContactoBI: {
                required: "El  campo Nombre del Contacto es obligatorio"
            },

            telefonoContactoBI: {
                required: "El  campo  Teléfono de contacto es obligatorio"
            },

            ParentescoBI: {
                required: "Se debe seleccionar un tipo de parentesco"
            },

            requiereManejoBI: {
                required: "Se debe seleccionar si se requiere manejo"
            },
        }

    });
}


function reiniciarCamposPlanAyuda() {

    $("#empresaParticipante").val("");
    $("#recursosDisposicion").val("");
    $("#compesacionEconomica").val("");
    $("#reintegroDelRecurso").val("");
    $("#nombreDelContactoAM").val("");
    $("#telefonoDeContactoAM").val("");

}

function reiniciarCamposBDExterna() {

    $("#entidadBE").val("");
    $("#direccionBE").val("");
    $("#telefonoBE").val("");
    $("#contactoBE").val("");
}

function reiniciarCamposBDInterna() {

    $("#documentoBI").val("");
    $("#nombreBI").val("");
    $("#epsBI").val("");
    $("#sexoBI").val("");
    $("#grupoRHBI").val("");
    $("#nombreContactoBI").val("");
    $("#telefonoContactoBI").val("");
    $("#ParentescoBI").val("");
    $("#requiereManejoBI").val("");
    $("#CualBI").val("");
}

$('#guardarBDInterna').click(function () {
    var form = $("#formularioBDInterna");
    if (!$("#formularioBDInterna").valid()) {
        validacion = false;
    }
    else {
        validacion = true;
    }

    if (validacion) {
        var form = $('#formularioBDInterna');

        $.ajax({
            type: 'POST',
            url: '/PlanEmergencias/GuardarBDInterna',
            data: form.serialize(),
            traditional: true,
            success: function (result) {
                if (result) {
                    $('#myModBDInterna').modal('hide');
                    swal("Estimado Usuario", 'Registro guardado Exitosamente', "success");
                    ListarBDInterna($("#IdSede").val());
                } else {
                    swal("Estimado Usuario", 'Ya existe un registro con esa identificación', "warning");
                }
            }
        });
    }

});

function obtenerCamposBDInterna() {

    utils.showLoading();
    $.ajax({
        url: '/PlanEmergencias/ObtenerDatosDelTrabajador',
        data: {                                           // se colocan los parametros a enviar... en este caso no porque los voy es a obtener.
            Documento: $("#documentoBI").val()
        },
        type: 'POST',
    }).done(function (result) {
        var nombreCompleto;
        utils.closeLoading();
        if (result.Mensaje == 'OK') {

            var sexoMod = "";
            var sexo = result.Data[0].sexoPersona;

            if (sexo == "M")
            {
                sexoMod = "Masculino";
            }
            else {
                sexoMod = "Femenino";
            }

            
            nombreCompleto = result.Data[0].nombre1 + " " + result.Data[0].nombre2 + " " + result.Data[0].apellido1 + " " + result.Data[0].apellido2;
            $("#nombreBI").val(nombreCompleto);
            $("#epsBI").val(result.Data[0].nombreEps);
            $("#sexoBI").val(sexoMod);
       
        } else if (result.Mensaje == 'ERROR') {
            swal({
                type: 'warning',
                title: 'Estimado usuario:',
                text: result.Data,

                confirmButtonColor: '#7E8A97'
            });
        }
        else if (result.Mensaje == 'VACIO') {
            swal({
                type: 'warning',
                title: 'Estimado usuario:',
                text: result.Data,

                confirmButtonColor: '#7E8A97'
            });
        }
        else if (result.Mensaje == 'CONEXION') {

            swal({
                type: 'warning',
                title: 'Estimado usuario:',
                text: result.Data,

                confirmButtonColor: '#7E8A97'
            });
        }
    }).fail(function (result) {
        console.log("Error en la peticion: " + result.Data);
    });
}

function requiereManejo() {

    var rm = $("#requiereManejoBI").val();
    if(rm=="SI")
    {
        $("#cualBasInt").show();
    }
    else if (rm=="NO") {
        $("#cualBasInt").hide();
    }
}

function ValidarRoles() {

    $('#frmRolFunciones').validate({
        rules: {
            nombre: { required: true },
            antes: { required: true },
            durante: { required: true },
            despues: { required: true },     
        },
        messages: {
            nombre: {
                required: "El campo Rol es obligatorio"
            },
            antes: {
                required: "El campo Antes es obligatorio"
            },

            durante: {
                required: "El campo Durante es obligatorio"
            },
            despues: {
                required: "El campo Después es obligatorio"
            },
        }

    });
}

$('#guardarRoles').click(function () {
    var sede = $("#IdSede").val();
    var form = $("#frmRolFunciones");
    if (!$("#frmRolFunciones").valid()) {
        validacion = false;
    }
    else {
        validacion = true;
    }

    if (validacion) {
        var form = $('#frmRolFunciones');

        $.ajax({
            type: 'POST',
            url: '/PlanEmergencias/GuardarRoles',
            data: form.serialize(),
            traditional: true,
            success: function (result) {

                $('#myModal1').modal('hide');
                swal("Estimado Usuario", 'Registro guardado Exitosamente', "success");
                ListarRoles(sede);
            }
        });
    }

});

function reiniciarFuncionesResponsabilidades() {

    $("#nombre").val("");
    $("#antes").val("");
    $("#durante").val("");
    $("#despues").val("");
}


function validadNivelEmergencia() {
  
    $('#frmNivelEmergencia').validate({
        rules: {
            nivel: { required: true },
            emergencia: { required: true },

        },
        messages: {
            nivel: {
                required: "El campo Nivel es obligatorio"
            },
            emergencia: {
                required: "El campo tipo de Emergencia es obligatorio"
            },
        }

    });
}

$('#guardarNivelEmergencia').click(function () {
    var sede = $("#IdSede").val();
    var form = $("#frmNivelEmergencia");
    if (!$("#frmNivelEmergencia").valid()) {
        validacion = false;
    }
    else {
        validacion = true;
    }

    if (validacion) {
        var form = $('#frmNivelEmergencia');


        $.ajax({
            type: 'POST',
            url: '/PlanEmergencias/GuardarNivelEmergencia',
            data: form.serialize(),
            traditional: true,
            success: function (result) {

                $('#myModal2').modal('hide');
                swal("Estimado Usuario", 'Registro guardado Exitosamente', "success");
                ListarNivelesEmergencia(sede);
            }
        });
    }

});

function reiniciarNivelesEmergencia() {

    $("#nivel").val("");
    $("#emergencia").val("");

}




$('#guardarRecursosHumanos').click(function () {
    var sede = $("#IdSede").val();
    var form = $("#frmHR");
    if ($("#bpaux_nombre").val() == "" && $("#bcontra_nombre").val() == "" && $("#bevalresc_nombre").val() == "") {

        swal("Estimado Usuario", 'Debes Ingresar un tipo de Brigadista', "warning");
        return false;
    }

        $.ajax({
            type: 'POST',
            url: '/PlanEmergencias/GuardarHR',
            data: form.serialize(),
            traditional: true,
            success: function (result) {

             
                $('#myModal3').modal('hide');
                swal("Estimado Usuario", 'Registro guardado Exitosamente', "success");
               ListarHR(sede);
            }
        });
  

});

function reiniciarRecursoHumano() {

    $("#bpaux_nombre").val("");
    $("#bcontra_nombre").val("");
    $("#bevalresc_nombre").val("");

}

function validarRecursosTecnicos() {

    $('#frmRTecnicos').validate({
        rules: {
            tipo: { required: true },
            cantidad: { required: true },
            ubicacion: { required: true },
        },
        messages: {
            tipo: {
                required: "El campo Tipo es obligatorio"
            },
            cantidad: {
                required: "El campo Cantidad es obligatorio"
            },
            ubicacion: {
                required: "El campo Ubicación es obligatorio"
            },
        }

    });
}

$('#guardarRecursosTecnicos').click(function () {
    var sede = $("#IdSede").val();
    var form = $("#frmRTecnicos");
    if (!$("#frmRTecnicos").valid()) {
        validacion = false;
    }
    else {
        validacion = true;
    }

    if (validacion) {
        var form = $('#frmRTecnicos');


        $.ajax({
            type: 'POST',
            url: '/PlanEmergencias/GuardarRTecnicos',
            data: form.serialize(),
            traditional: true,
            success: function (result) {

                $('#myModal4').modal('hide');

                swal("Estimado Usuario", 'Registro guardado Exitosamente', "success");

                ListarRTecnicos(sede);
            }
        });
    }

});


function reiniciarRecursoTecnico() {

    $("#tipo").val("");
    $("#cantidad").val("");
    $("#ubicacion").val("");

}

function validarProcedimientoOperativos() {

    $('#frmProcedimientosOperativosNormalizados').validate({
        rules: {
            nombre_proc: { required: true },
            responsable: { required: true },
            proc_antes: { required: true },
            proc_durante: { required: true },
            proc_despues: { required: true },
            proc_recursos: { required: true },

        },
        messages: {
            nombre_proc: {
                required: "El campo Nombre del Procedimiento Obligatorio"
            },
            responsable: {
                required: "El campo Responsable es obligatorio"
            },
            proc_antes: {
                required: "El campo Antes es obligatorio"
            },

            proc_durante: {
                required: "El campo Durante es obligatorio"
            },
            proc_despues: {
                required: "El campo Después es obligatorio"
            },
            proc_recursos: {
                required: "El campo Recursos es obligatorio"
            },
        }
    });
}

$('#guardarProcOperNormalizados').click(function () {
    var sede = $("#IdSede").val();
    var form = $("#frmProcedimientosOperativosNormalizados");
    if (!$("#frmProcedimientosOperativosNormalizados").valid()) {
        validacion = false;
    }
    else {
        validacion = true;
    }

    if (validacion) {
        var form = $('#frmProcedimientosOperativosNormalizados');


        $.ajax({
            type: 'POST',
            url: '/PlanEmergencias/GuardarProcedimientosOperativosNormalizados',
            data: form.serialize(),
            traditional: true,
            success: function (result) {
                $('#myModal0').modal('hide');
                ListarProcedimientosOperativosNormalizados(sede);
            }
        });
    }

});

function reiniciarProcOperativosNormalizados() {
    $("#pk_id_proc_normalizados").val("");
    $("#nombre_proc").val("");
    $("#responsable").val("");
    $("#proc_antes").val("");
    $("#proc_durante").val("");
    $("#proc_despues").val("");
    $("#proc_recursos").val("");

}

function validarNivelVulPersona() {

    $('#formAnalVulPersona').validate({
        rules: {
            nuevoAspectoVulPer: { required: true },
        },
        messages: {
            nuevoAspectoVulPer: {
                required: "El campo nuevo aspecto obligatorio"
            },
        }
    });
}

$('#GuardarNivelVulPersona').click(function () {
  
    var form = $("#formAnalVulPersona");
    if (!$("#formAnalVulPersona").valid()) {
        validacion = false;
    }
    else {
        validacion = true;
    }

    if (validacion) {
        var form = $('#formAnalVulPersona');


        $.ajax({
            type: 'POST',
            url: '/PlanEmergencias/GuardarAspVulnerabilidadPersonas',
            data: form.serialize(),
            traditional: true,
            success: function (result) {
				
				
                var tHtml1 = "";
                var tHtml2 = "";
                var tHtml3 = "";

                $.each(result, function (key, val) {
                    if (val.tipo == "O") {
                        tHtml1 += '<tr>';
                        tHtml1 += '<td ' + class_css_btxt + '>' + val.aspectos + '</td>';
                        tHtml1 += '<td ' + class_css_btxtobser + '><input id="p_observacion_' + val.pk_id_personas + '" type="text"></td>';
                        tHtml1 += '<td ' + class_css_btxtobser + '><input id="p_recomendacion_' + val.pk_id_personas + '" type="text"></td>';
                        tHtml1 += '<td style="border-right: 2px solid lightslategray; vertical-align:middle; text-align:center"><select  onchange="obtenerSubtotalOrg()" id="p_calificacion_' + val.pk_id_personas + '" name="p_calificacionO_' + val.pk_id_personas + '" ><option value="">Seleccione</option><option value="0.0">0.0</option><option value="0.5">0.5</option><option value="1.0">1.0</option></select><input id="p_tipo_' + val.pk_id_personas + '" value="O" type="hidden"></td>';
                        tHtml1 += '</tr>';
                    }
                    $("#grid_personas1").append(tHtml1);

                    if (val.tipo == "C") {
                        tHtml2 += '<tr>';
                        tHtml2 += '<td ' + class_css_btxt + '>' + val.aspectos + '</td>';
                        tHtml2 += '<td ' + class_css_btxtobser + '><input id="p_observacion_' + val.pk_id_personas + '" type="text"></td>';
                        tHtml2 += '<td ' + class_css_btxtobser + '><input id="p_recomendacion_' + val.pk_id_personas + '" type="text"></td>';
                        tHtml2 += '<td style="border-right: 2px solid lightslategray; vertical-align:middle; text-align:center"><select  onchange="obtenerSubtotalCap()"  id="p_calificacion_' + val.pk_id_personas + '"  name="p_calificacionC_' + val.pk_id_personas + '"  ><option value="">Seleccione</option><option value="0.0">0.0</option><option value="0.5">0.5</option><option value="1.0">1.0</option></select><input id="p_tipo_' + val.pk_id_personas + '" value="C" type="hidden"></td>';
                        tHtml2 += '</tr>';
                    }
                    $("#grid_personas2").append(tHtml2);

                    if (val.tipo == "D") {
                        tHtml3 += '<tr>';
                        tHtml3 += '<td ' + class_css_btxt + '>' + val.aspectos + '</td>';
                        tHtml3 += '<td ' + class_css_btxtobser + '><input id="p_observacion_' + val.pk_id_personas + '" type="text"></td>';
                        tHtml3 += '<td ' + class_css_btxtobser + '><input id="p_recomendacion_' + val.pk_id_personas + '" type="text"></td>';
                        tHtml3 += '<td style="border-right: 2px solid lightslategray; vertical-align:middle; text-align:center"><select onchange="obtenerSubtotalDot()"  id="p_calificacion_' + val.pk_id_personas + '" name="p_calificacionD_' + val.pk_id_personas + '" ><option value="">Seleccione</option><option value="0.0">0.0</option><option value="0.5">0.5</option><option value="1.0">1.0</option></select><input id="p_tipo_' + val.pk_id_personas + '" value="D" type="hidden"></td>';
                        tHtml3 += '</tr>';
                    }


                    $("#grid_personas3").append(tHtml3);


                });

                $('#myModAnalVulPer').modal('hide');
             
            }
        });
		obtenerTamanoPersona();
    }

});

function validadNivelVulRecursos() {

    $('#formAnalVulRecursos').validate({
        rules: {
            nuevoAspectoVulRec: { required: true },
        },
        messages: {
            nuevoAspectoVulRec: {
                required: "El campo nuevo aspecto obligatorio"
            },
        }
    });
}

$('#GuardarNivelVulRecursos').click(function () {

    var form = $("#formAnalVulRecursos");
    if (!$("#formAnalVulRecursos").valid()) {
        validacion = false;
    }
    else {
        validacion = true;
    }

    if (validacion) {
        var form = $('#formAnalVulRecursos');


        $.ajax({
            type: 'POST',
            url: '/PlanEmergencias/GuardarAspVulnerabilidadRecursos',
            data: form.serialize(),
            traditional: true,
            success: function (result) {
               
				      var tHtml1 = "";
                var tHtml2 = "";
                var tHtml3 = "";
                $.each(result, function (key, val) {
                   if (val.tipo == "M") {
                    tHtml1 += '<tr>';
                    tHtml1 += '<td ' + class_css_btxt + ' width="258" >' + val.aspectos + '</td>';
                    tHtml1 += '<td ' + class_css_btxtobser + ' width="84"><input id="r_observacion_' + val.pk_id_recursos + '" type="text"></td>';
                    tHtml1 += '<td ' + class_css_btxtobser + ' width="84" ><input id="r_recomendacion_' + val.pk_id_recursos + '" type="text"></td>';
                    tHtml1 += '<td style="border-right: 2px solid lightslategray; vertical-align:middle; text-align:center" width="125" ><select onchange="obtenerSubtotalMat()"   id="r_calificacion_' + val.pk_id_recursos + '" id="select"  name="r_calificacionMat_' + val.pk_id_recursos + '" ><option value="">Seleccione</option><option value="0.0">0.0</option><option value="0.5">0.5</option><option value="1.0">1.0</option></select><input id="r_tipo_' + val.pk_id_recursos + '" value="M" type="hidden"></td>';
                    tHtml1 += '</tr>';
                }
                    $("#grid_recursos1").append(tHtml1);

              	  if (val.tipo == "E") {
                    tHtml2 += '<tr>';
                    tHtml2 += '<td ' + class_css_btxt + 'width="258"  >' + val.aspectos + '</td>';
                    tHtml2 += '<td ' + class_css_btxtobser + ' width="84"><input id="r_observacion_' + val.pk_id_recursos + '" type="text"></td>';
                    tHtml2 += '<td ' + class_css_btxtobser + 'width="84" ><input id="r_recomendacion_' + val.pk_id_recursos + '" type="text"></td>';
                    tHtml2 += '<td style="border-right: 2px solid lightslategray; vertical-align:middle; text-align:center" width="125" ><select  onchange="obtenerSubtotalEdi()" id="r_calificacion_' + val.pk_id_recursos + '"  name="r_calificacionEdi_' + val.pk_id_recursos + '" id="select"><option value="">Seleccione</option><option value="0.0">0.0</option><option value="0.5">0.5</option><option value="1.0">1.0</option></select><input id="r_tipo_' + val.pk_id_recursos + '" value="E" type="hidden"></td>';
                    tHtml2 += '</tr>';
                }
                    $("#grid_recursos2").append(tHtml2);

				 if (val.tipo == "EQ") {
                    tHtml3 += '<tr class="titulos_filas">';
                    tHtml3 += '<td ' + class_css_btxt + 'width="258"  >' + val.aspectos + '</td>';
                    tHtml3 += '<td ' + class_css_btxtobser + 'width="84" ><input id="r_observacion_' + val.pk_id_recursos + '" type="text"></td>';
                    tHtml3 += '<td ' + class_css_btxtobser + 'width="84" ><input id="r_recomendacion_' + val.pk_id_recursos + '" type="text"></td>';
                    tHtml3 += '<td style="border-right: 2px solid lightslategray; vertical-align:middle; text-align:center" width="125"><select onchange="obtenerSubtotalEqui()"   id="r_calificacion_' + val.pk_id_recursos + '"   name="r_calificacionEqui_' + val.pk_id_recursos + '"  id="select"><option value="">Seleccione</option><option value="0.0">0.0</option><option value="0.5">0.5</option><option value="1.0">1.0</option></select><input id="r_tipo_' + val.pk_id_recursos + '" value="EQ" type="hidden"></td>';
                    tHtml3 += '</tr>';
                }

                    $("#grid_recursos3").append(tHtml3);
	                });
					
			

                $('#myModAnalVulReursos').modal('hide');
             
            }
        });
		obtenerTamanoRecurso();
    }

});

function validadNivelVulSistemasYProcesos() {

    $('#formAnalVulSistemasYProcesos').validate({
        rules: {
            nuevoAspectoVulSYP: { required: true },
        },
        messages: {
            nuevoAspectoVulSYP: {
                required: "El campo nuevo aspecto obligatorio"
            },
        }
    });
}

$('#GuardarNivelVulSistemasYProcesos').click(function () {

    var form = $("#formAnalVulSistemasYProcesos");
    if (!$("#formAnalVulSistemasYProcesos").valid()) {
        validacion = false;
    }
    else {
        validacion = true;
    }

    if (validacion) {
        var form = $('#formAnalVulSistemasYProcesos');


        $.ajax({
            type: 'POST',
            url: '/PlanEmergencias/GuardarAspVulnerabilidadSistemasYProcesos',
            data: form.serialize(),
            traditional: true,
            success: function (result) {
     	      var tHtml1 = "";
                var tHtml2 = "";
                var tHtml3 = "";
				  $.each(result, function (key, val) {
                  if (val.tipo == "SP") {
                    tHtml1 += '<tr>';
                    tHtml1 += '<td ' + class_css_btxt + ' width="258">' + val.aspectos + '</td>';
                    tHtml1 += '<td ' + class_css_btxtobser + ' width="84" ><input id="sp_observacion_' + val.pk_id_sistemas_procesos + '" type="text"></td>';
                    tHtml1 += '<td ' + class_css_btxtobser + ' width="84" ><input id="sp_recomendacion_' + val.pk_id_sistemas_procesos + '" type="text"></td>';
                    tHtml1 += '<td style="border-right: 2px solid lightslategray; vertical-align:middle; text-align:center" width="125" ><select onchange="obtenerSubtotalSP()"  id="sp_calificacion_' + val.pk_id_sistemas_procesos + '"  name="sp_calificacionSP_' + val.pk_id_sistemas_procesos + '"  id="select"  ><option value="">Seleccione</option><option value="0.0">0.0</option><option value="0.5">0.5</option><option value="1.0">1.0</option></select><input id="sp_tipo_' + val.pk_id_sistemas_procesos + '" value="SP" type="hidden"></td>';
                    tHtml1 += '</tr>';
                }
                    $("#grid_sistemasprocesos1").append(tHtml1);

              if (val.tipo == "SA") {
                    tHtml2 += '<tr>';
                    tHtml2 += '<td ' + class_css_btxt + 'width="258" >' + val.aspectos + '</td>';
                    tHtml2 += '<td ' + class_css_btxtobser + 'width="84" ><input id="sp_observacion_' + val.pk_id_sistemas_procesos + '" type="text"></td>';
                    tHtml2 += '<td ' + class_css_btxtobser + 'width="84" ><input id="sp_recomendacion_' + val.pk_id_sistemas_procesos + '" type="text"></td>';
                    tHtml2 += '<td style="border-right: 2px solid lightslategray; vertical-align:middle; text-align:center" width="125" ><select onchange="obtenerSubtotalSAlt()"  id="sp_calificacion_' + val.pk_id_sistemas_procesos + '"  name="sp_calificacionSA_' + val.pk_id_sistemas_procesos + '" id="select"><option value="">Seleccione</option><option value="0.0">0.0</option><option value="0.5">0.5</option><option value="1.0">1.0</option></select><input id="sp_tipo_' + val.pk_id_sistemas_procesos + '" value="SA" type="hidden"></td>';
                    tHtml2 += '</tr>';
                }
                    $("#grid_sistemasprocesos2").append(tHtml2);

			   if (val.tipo == "R") {
                    tHtml3 += '<tr>';
                    tHtml3 += '<td ' + class_css_btxt + '  width="258" >' + val.aspectos + '</td>';
                    tHtml3 += '<td ' + class_css_btxtobser + ' width="84" ><input id="sp_observacion_' + val.pk_id_sistemas_procesos + '" type="text"></td>';
                    tHtml3 += '<td ' + class_css_btxtobser + ' width="84"><input id="sp_recomendacion_' + val.pk_id_sistemas_procesos + '" type="text"></td>';
                    tHtml3 += '<td style="border-right: 2px solid lightslategray; vertical-align:middle; text-align:center" width="125" ><select onchange="obtenerSubtotalRec()" id="sp_calificacion_' + val.pk_id_sistemas_procesos + '" name="sp_calificacionRec_' + val.pk_id_sistemas_procesos + '"  id="select"><option value="">Seleccione</option><option value="0.0">0.0</option><option value="0.5">0.5</option><option value="1.0">1.0</option></select><input id="sp_tipo_' + val.pk_id_sistemas_procesos + '" value="R" type="hidden"></td>';
                    tHtml3 += '</tr>';
                }

                    $("#grid_sistemasprocesos3").append(tHtml3);
	                  });
					
			

                $('#myModAnalVulSistemasYProcesos').modal('hide');
             
            }
        });
		
		obtenerTamanoSistemasProcesos();
    }

});

function borrarContenidoLabel() {
      $("#nombreUploadPlanAyuda").text("");
	  $("#nombrePlanAyudaMutua").text("");
	  $("#nombreUploadSeguridadBasica").text("");  
	  $("#nombreUploadPlanAtencionMedica").text("");
	  $("#nombreUploadContraIncendios").text("");
	  $("#nombreUploadPlanEvacuacion").text("");  
	  $("#nombreRutaEvacuacion").text("");
	  $("#nombreUpload").text("");  
	  $("#nombreUpload1").text("");
	  $("#nombreUpload2").text("");
	  $("#cargarEstOrganizacional").text("");  
	  $("#nombreUploadInfTrabajador").text("");
	  $("#nombreUploadBDExterna").text("");
	  $("#upload_frenteaccion_adjunto1").val("");
	  $("#upload_frenteaccion_adjunto2").val("");
	  $("#upload_frenteaccion_adjunto3").val("");
	  $("#upload_frenteaccion_adjunto4").val("");
	  $("#upload_frenteaccion_adjunto5").val("");
	  $("#upload_adjuntos").val("");
	  $("#upload_adjuntos1").val("");
	  $("#upload_adjuntos2").val("");	  
}



//funcion que solo permite el ingreso de numero en los campos 
function darFormatoSoloNumeros(idCampo) {
    $('#' + idCampo).on('input', function () {
        this.value = this.value.replace(/[^0-9]/g, '');
    });
}

function obtenerTamanoPersona(){
	    var form = $('#formAnalVulSistemasYProcesos');
	
  var isede = $("#IdSede").val();
    $.ajax({
            type: 'POST',
            url: '/PlanEmergencias/obtenerTamanoPersona',
            data: form.serialize(),
            traditional: true,
            success: function (result) {
            
              tamanoPersona=result;
			
            }
	});
	
}

function obtenerTamanoRecurso(){
	    var form = $('#formAnalVulSistemasYProcesos');
	
  var isede = $("#IdSede").val();
    $.ajax({
            type: 'POST',
            url: '/PlanEmergencias/obtenerTamanoRecurso',
            data: form.serialize(),
            traditional: true,
            success: function (result) {
            
              tamanoRecurso=result;
			
            }
	});
	
}


function obtenerTamanoSistemasProcesos(){
	    var form = $('#formAnalVulSistemasYProcesos');
	
  var isede = $("#IdSede").val();
    $.ajax({
            type: 'POST',
            url: '/PlanEmergencias/obtenerTamanoSistemasProcesos',
            data: form.serialize(),
            traditional: true,
            success: function (result) {
            
              tamanoSistemasProcesos=result;
			
            }
	});
	
}

function eliminarProcedimiento(id) {
    $("#eliProcNor").val(id);
    $('#modEliminarProcedimientosNorm').modal('show');
    
}

$("#eliminarProcOpNorm").click(function () {
    var sede = $("#IdSede").val();
    var idProceso = $("#eliProcNor").val();

    $.ajax({
        type: 'POST',
        url: '/PlanEmergencias/EliminarProcesosOperativos',
        data: {idProceso:idProceso},
        traditional: true,
        success: function (result) {
            if (result) {
                $('#modEliminarProcedimientosNorm').modal('hide');
                swal("Estimado Usuario", 'El registro ha sido eliminado correctamente', "success");

                ListarProcedimientosOperativosNormalizados(sede);
            }

        }
        
    });
});

function modificarProcedimiento(id) {
    var sede = $("#IdSede").val();
    var idProceso =id;

    $.ajax({
        type: 'POST',
        url: '/PlanEmergencias/EditarProcesosOperativos',
        data: { idProceso: idProceso },
        traditional: true,
        success: function (result) {
            $("#pk_id_proc_normalizados").val(idProceso);
            $("#fk_id_sede_proc_normalizados").val(sede);
            $("#nombre_proc").val(result.nombre_proc);
            $("#responsable").val(result.responsable);
            $("#proc_antes").val(result.proc_antes);
            $("#proc_durante").val(result.proc_durante);
            $("#proc_despues").val(result.proc_despues);
            $("#proc_recursos").val(result.proc_despues);
            $('#myModal0').modal('show');

             }
        });

}

function obtenerSubtotalOrg() {
    var totalOrg = 0;
    var contOrg = 0;
    var promedio = 0;
    $("select[name*='p_calificacionO']").each(function () {
        if (this.value != "")
        {
            totalOrg += +this.value;
            contOrg++;
        }
       
    });
    promedio = (totalOrg / contOrg).toFixed(2);
    if (promedio == "NaN")
    {
        promedio = 0;
    }
    else {
        promedio = promedio;
    }
    $("#subtotal_o").val(promedio);
}

function obtenerSubtotalCap() {
    var totalCap = 0;
    var contCap = 0;
    var promedio = 0;
    $("select[name*='p_calificacionC']").each(function () {
        if (this.value != "") {
            totalCap += +this.value;
            contCap++;
        }

    });
    promedio = (totalCap / contCap).toFixed(2);
    if (promedio == "NaN") {
        promedio = 0;
    }
    else {
        promedio = promedio;
    }
    $("#subtotal_c").val(promedio);
}

function obtenerSubtotalDot() {
    var totalDot = 0;
    var contDot = 0;
    var promedio = 0;
    $("select[name*='p_calificacionD']").each(function () {
        if (this.value != "") {
            totalDot += +this.value;
            contDot++;
        }

    });
    promedio = (totalDot / contDot).toFixed(2);
    if (promedio == "NaN") {
        promedio = 0;
    }
    else {
        promedio = promedio;
    }
    $("#subtotal_d").val(promedio);
}

function obtenerSubtotalMat() {
    var totalMat = 0;
    var contMat = 0;
    var promedio = 0;
    $("select[name*='r_calificacionMat']").each(function () {
        if (this.value != "") {
            totalMat += +this.value;
            contMat++;
        }

    });
    promedio = (totalMat / contMat).toFixed(2);
    if (promedio == "NaN") {
        promedio = 0;
    }
    else {
        promedio = promedio;
    }
    $("#subtotal_m").val(promedio);
}

function obtenerSubtotalEdi() {
    var totalEdi = 0;
    var contEdi = 0;
    var promedio = 0;
    $("select[name*='r_calificacionEdi']").each(function () {
        if (this.value != "") {
            totalEdi += +this.value;
            contEdi++;
        }

    });
    promedio = (totalEdi / contEdi).toFixed(2);
    if (promedio == "NaN") {
        promedio = 0;
    }
    else {
        promedio = promedio;
    }
    $("#subtotal_e").val(promedio);
    
 

}
function obtenerSubtotalEqui() {
    var totalEqui = 0;
    var contEqui = 0;
    var promedio = 0;
    $("select[name*='r_calificacionEqui']").each(function () {
        if (this.value != "") {
            totalEqui += +this.value;
            contEqui++;
        }

    });
    promedio = (totalEqui / contEqui).toFixed(2);
    if (promedio == "NaN") {
        promedio = 0;
    }
    else {
        promedio = promedio;
    }
 

    $("#subtotal_eq").val(promedio);

}
function obtenerSubtotalSP() {
    var totalSP = 0;
    var contSP = 0;
    var promedio = 0;
    $("select[name*='sp_calificacionSP']").each(function () {
        if (this.value != "") {
            totalSP += +this.value;
            contSP++;
        }

    });
    promedio = (totalSP / contSP).toFixed(2);
    if (promedio == "NaN") {
        promedio = 0;
    }
    else {
        promedio = promedio;
    }

    $("#subtotal_sp").val(promedio);
   
}

function obtenerSubtotalSAlt() {
    var totalSAlt = 0;
    var contSAlt = 0;
    var promedio = 0;
    $("select[name*='sp_calificacionSA']").each(function () {
        if (this.value != "") {
            totalSAlt += +this.value;
            contSAlt++;
        }

    });
    promedio = (totalSAlt / contSAlt).toFixed(2);
    if (promedio == "NaN") {
        promedio = 0;
    }
    else {
        promedio = promedio;
    }

    $("#subtotal_sa").val(promedio);
    //$("#subtotal_r").val(promedioR);
}

function obtenerSubtotalRec() {
    var totalRec = 0;
    var contRec = 0;
    var promedio = 0;
    $("select[name*='sp_calificacionRec']").each(function () {
        if (this.value != "") {
            totalRec += +this.value;
            contRec++;
        }

    });
    promedio = (totalRec / contRec).toFixed(2);
    if (promedio == "NaN") {
        promedio = 0;
    }
    else {
        promedio = promedio;
    }
    $("#subtotal_r").val(promedio);
}


function eliminarRecursosFisicos(id) {
    $("#eliRecuFis").val(id);
    $('#modEliminarRecursosFisTec').modal('show');

}

$("#eliminarRecursoFisico").click(function () {
    var sede = $("#IdSede").val();
    var idRecursoFis = $("#eliRecuFis").val();

    $.ajax({
        type: 'POST',
        url: '/PlanEmergencias/EliminarRecursoFisico',
        data: { idRecursoFis: idRecursoFis },
        traditional: true,
        success: function (result) {
            if (result) {
                $('#modEliminarRecursosFisTec').modal('hide');
                swal("Estimado Usuario", 'El registro ha sido eliminado correctamente', "success");

                ListarRTecnicos(sede);
            }

        }

    });
});

function eliminarRecursoHumanos(id) {
    $("#eliRecuHum").val(id);
    $('#modEliminarRecursosHumanos').modal('show');

}

$("#eliminarRecursoHumano").click(function () {
    var sede = $("#IdSede").val();
    var idRecursoHum = $("#eliRecuHum").val();

    $.ajax({
        type: 'POST',
        url: '/PlanEmergencias/EliminarRecursoHumano',
        data: { idRecursoHum: idRecursoHum },
        traditional: true,
        success: function (result) {
            if (result) {
                $('#modEliminarRecursosHumanos').modal('hide');
                swal("Estimado Usuario", 'El registro ha sido eliminado correctamente', "success");

                ListarHR(sede);
            }

        }

    });
});


function eliminarBDPlanAyuda(id) {
    $("#eliPlanAyuda").val(id);
    $('#modEliminarBDPlanAyuda').modal('show');

}

$("#eliminarPlanAyuda").click(function () {
    var sede = $("#IdSede").val();
    var idPlanAyuda = $("#eliPlanAyuda").val();

    $.ajax({
        type: 'POST',
        url: '/PlanEmergencias/EliminarPlanAyuda',
        data: { idPlanAyuda: idPlanAyuda },
        traditional: true,
        success: function (result) {
            if (result) {
                $('#modEliminarBDPlanAyuda').modal('hide');
                swal("Estimado Usuario", 'El registro ha sido eliminado correctamente', "success");

                ListarBDPlanAyuda(sede);
            }

        }

    });
});

function eliminarNivelDeEmergencia(id) {
    $("#eliNivelEmergencia").val(id);
    $('#modEliminarNivelEmergencia').modal('show');

}

$("#eliminarNivelEmergencia").click(function () {
    var sede = $("#IdSede").val();
    var idNivelEmergenia = $("#eliNivelEmergencia").val();

    $.ajax({
        type: 'POST',
        url: '/PlanEmergencias/EliminarNivelEmergencia',
        data: { idNivelEmergenia: idNivelEmergenia },
        traditional: true,
        success: function (result) {
            if (result) {
                $('#modEliminarNivelEmergencia').modal('hide');
                swal("Estimado Usuario", 'El registro ha sido eliminado correctamente', "success");

                ListarNivelesEmergencia(sede);
            }

        }

    });
});


function eliminarBDExterna(id) {
    $("#eliBDExterna").val(id);
    $('#modEliminarBDExterna').modal('show');

}

$("#eliminarBDExterna").click(function () {
    var sede = $("#IdSede").val();
    var idBDExterna = $("#eliBDExterna").val();

    $.ajax({
        type: 'POST',
        url: '/PlanEmergencias/EliminarBDExterna',
        data: { idBDExterna: idBDExterna },
        traditional: true,
        success: function (result) {
            if (result) {
                $('#modEliminarBDExterna').modal('hide');
                swal("Estimado Usuario", 'El registro ha sido eliminado correctamente', "success");

                ListarBDExterna(sede);
            }

        }

    });
});


function eliminarBDInterna(id) {
    $("#eliBDInterna").val(id);
    $('#modEliminarBDInterna').modal('show');

}

$("#modEliminarBDInterna").click(function () {
    var sede = $("#IdSede").val();
    var idBDInterna = $("#eliBDInterna").val();

    $.ajax({
        type: 'POST',
        url: '/PlanEmergencias/EliminarBDInterna',
        data: { idBDInterna: idBDInterna },
        traditional: true,
        success: function (result) {
            if (result) {
                $('#modEliminarBDInterna').modal('hide');
                swal("Estimado Usuario", 'El registro ha sido eliminado correctamente', "success");

                ListarBDInterna(sede);
            }

        }

    });
});

function eliminarFuncYResp(id) {
    $("#eliFuncYResp").val(id);
    $('#modEliminarFuncYResp').modal('show');

}

$("#eliminarFuncYRespons").click(function () {
    var sede = $("#IdSede").val();
    var idFuncYResp = $("#eliFuncYResp").val();

    $.ajax({
        type: 'POST',
        url: '/PlanEmergencias/EliminarFuncYRespo',
        data: { idFuncYResp: idFuncYResp },
        traditional: true,
        success: function (result) {
            if (result) {
                $('#modEliminarFuncYResp').modal('hide');
                swal("Estimado Usuario", 'El registro ha sido eliminado correctamente', "success");

                ListarRoles(sede);
            }

        }

    });
});

function ValidarVulnerabilidadesAmenazas() {
    var respuestaValidacion = false;
    var valido = false;
    var validarRespuesta = true;
    var validarRespuestaVal = true;
    $("#grid_ident_amenaza").find("input[name=chk_Name]:checked").each(function (ind, element) {
        var contenedor = $(element).closest("tr");
        respuestaValidacion = validarCamposDinamicos(contenedor, "text_", "input");
        if (respuestaValidacion == false) {
            validarRespuesta = false;
        }
        //validarCamposDinamicos(contenedor, "calificacion_", "select")        
        var nameElementoAValidar = "calificacion_";
        var tipoElemento = "select";
        if (contenedor != undefined && nameElementoAValidar != undefined)
        {
            var formulario = $(contenedor);
            stringElementoBuscar = tipoElemento + "[name=" + nameElementoAValidar + "]";
            valido = true;
            var labelError = '<label class="error-dinamico">Debe seleccionar una opción</label>';
            formulario.find(stringElementoBuscar).each(function (ind, element) {
                var label = $(element).next("label");
                if ($(element).val().trim() === '0') {
                    if (label != undefined) {
                        label.remove();
                    }
                    $(element).after(labelError);
                    //$(element).attr("onchange", "quitarlabelErrorSelect(this)");
                    valido = false;
                } else {
                    label.remove();
                }
            })
        }
        else {
            valido = false;
        }
        if (valido == false) {
            validarRespuestaVal = false;
        }
    });
    if (validarRespuesta == true & validarRespuestaVal == true) {
        return true;
    }
    else {
        return false;
    }
}

function quitarlabelError(element) {
    var label = $(element).next("label");
    if ($(element).val().trim() === '') {
        if (label != undefined) {
            label.remove();
        }
    } else {
        label.remove();
    }
}

function QuitarErrorCheck(element) {
    if (element.checked == false) {
        var label = $(element).closest("tr").find("label");
        if ($(element).val().trim() === '') {
            if (label != undefined) {
                label.remove();
            }
        } else {
            //$('#selectid option:-Seleccione-(:selected)').attr('disabled', true);
            $(element).closest("tr").find("select[name=origen_]").attr('disabled', 'disabled');
            $(element).closest("tr").find("select[name=origen_]").val("I");
            $(element).closest("tr").find("select[name=calificacion_]").attr('disabled', 'disabled');
            $(element).closest("tr").find("select[name=calificacion_]").val("0");
            $(element).closest("tr").find("input[name=text_]").val("");
            $(element).closest("tr").find("input[name=text_]").attr('disabled', 'disabled');
            $(element).closest("tr").find("div[class=rombo]").css("background", "#FFFFFF");
            label.remove();
        }
    }
    else {
        $(element).closest("tr").find("select").removeAttr('disabled');
        $(element).closest("tr").find("input[name=text_]").removeAttr('disabled');
    }
}

function quitarlabelErrorSelect(element)
{
    if ($(element).closest("tr").find("label").length > 0) {
        var label = $(element).next("label");
        var labelRombo = $(element).closest("tr").find("label");
        if ($(element).val().trim() === '0') {
            if (label != undefined) {
                label.remove();
            //    ColorRombo(this.value, ' + val.pk_id_identificacion_amenazas + ');
            }
        }
        else {
            //ColorRombo($(element).val(), 1);
            label.remove();
        }
    }
}

function LimpiarInputGeo()
{
    $("#upload_adjuntos").val("").clone(true);
    $("#upload_adjuntos1").val("").clone(true);
    $("#upload_adjuntos2").val("").clone(true);
}

function LimpiarInputFrentesA()
{
    $("#upload_frenteaccion_adjunto1").val("").clone(true);
    $("#upload_frenteaccion_adjunto2").val("").clone(true);
    $("#upload_frenteaccion_adjunto3").val("").clone(true);
    $("#upload_frenteaccion_adjunto4").val("").clone(true);
    $("#upload_frenteaccion_adjunto5").val("").clone(true);
}