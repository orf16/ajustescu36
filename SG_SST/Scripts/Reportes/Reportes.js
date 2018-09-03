var $idSede = $("#FKSedePeligro");
var $idMetodologia = $("#Fk_Metodologia");
var $idProceso = $("#Fk_Proceso");
var $idZonaLugar = $("#Fk_ZonaLugar");
var $idActividad = $("#Fk_Actividad");
var $idTipoPeligro = $("#Fk_TipoDePeligro");
var cont = 0;
var contP = 0;

//var urlBase = ""
//try {
//    urlBase = utils.getBaseUrl();
//} catch (e) {
//    console.error(e.message);
//    throw new Error("El modulo utilidades es requerido");
//};

$(document).ready(function () {
 
 
    darFormatoSoloNumeros("num_documento");
    $('#descargarExcelComparativo').hide();
    var indi = $("#frmindicadores")
    indi.validate({
        rules: {
            AnioSeleccionado: {
                required: true
            },
            PrimerAnio: {
                required: true
            },
            SegundoAnio: {
                required: true
            },
            ConstanteSeleccionada: {
                required: true
            }           
        },
        messages: {
            AnioSeleccionado: {
                required: "Debe seleccionar un año de gestion"
            },
            PrimerAnio: {
                required: "Debe seleccionar un año de gestion"
            },
            SegundoAnio: {
                required: "Debe seleccionar un año de gestion"
            },
            ConstanteSeleccionada: {
                required: "Debe seleccionar un valor de constante"
            }           
        }
    });
    var constante = $("#ConstanteSeleccionada").val();
    var anioSel = $("#AnioSeleccionado").val();

    $('#4').change(function () {
        if ($(this).is(":checked")) {
            $("#descargarTablaExcel").hide();
            $('.campos-comparacion-indicadores').show();
            $('.campos-consultar-comparacion-indicadores').show();
            $('#consultarIndicador').hide();
            $('#AnioSeleccionado').hide();
            $('#agestion').hide();
            $('#descargarExcelComparativo').hide();
            $('#panelAcumulado').hide();
            $('#banneracumulado').hide();               
            $('#panelIndicador').hide();
            $('#bannerindicador').hide();            
        }
        else {
            $('#Indicadores').empty();
            $('#consultarIndicador').show();
            $('.campos-comparacion-indicadores').hide();
            $('.campos-consultar-comparacion-indicadores').hide();
            $('#AnioSeleccionado').show();
            $('#agestion').show();
            $('#descargarExcelComparativo').hide();
            $('#panelAcumulado').hide();
            $('#banneracumulado').hide();            
            $('#panelIndicador').hide();
            $('#bannerindicador').hide();            
        }
    });
});

function MostrarIndicadorAusentismo() {

   
    var IdContingencia = $('input:radio[id=tipoComparacion]:checked').val();
    var  AnioSeleccionado= $("#AnioSeleccionado").val();
    var ConstanteSeleccionada= $("#ConstanteSeleccionada").val();
    var IdEmpresaUsuaria = $('#IdEmpresaUsuaria').val();
    var  PrimerAnio= $("#PrimerAnio").val();
    var SegundoAnio = $("#SegundoAnio").val();

    if (IdContingencia == 1) {
        contigenciaTexto = "ENFERMEDAD GENERAL";
    }
    else if (IdContingencia == 2) {
        contigenciaTexto = "ENFERMEDAD LABORAL";
    }
    else if (IdContingencia == 3) {
        contigenciaTexto = "ACCIDENTE DE TRABAJO";
    }


    if (AnioSeleccionado == "") {
        swal({
            type: 'warning',
            title: 'Estimado Usuario:',
            text: 'El párametro año gestión es obligatorio',
            confirmButtonColor: '#7E8A97'
        });

        return false;
    }


    if (ConstanteSeleccionada == "") {
        swal({
            type: 'warning',
            title: 'Estimado Usuario:',
            text: 'El párametro Constante K es obligatorio',
            confirmButtonColor: '#7E8A97'
        });

        return false;
    }

    if (IdContingencia == null)
    {
        swal({
            type: 'warning',
            title: 'Estimado Usuario:',
            text: 'Por favor seleccione una  contigencia',
            confirmButtonColor: '#7E8A97'
        });

        return false;
    }

  

    $.ajax({
        data: { AnioSeleccionado: AnioSeleccionado, IdContingencia: IdContingencia,contigenciaTexto:contigenciaTexto, ConstanteSeleccionada: ConstanteSeleccionada, IdEmpresaUsuaria: IdEmpresaUsuaria },
        url: urlBase + '/ReportesAplicacion/IndicadoresAusentismo',
        type: 'POST'
    });
    location.reload(true);
    OcultarPopupposition();
   

}

function MostrarIndicadorAusComparar() {


    var IdContingencia = $('input:radio[id=tipoComparacion]:checked').val();
    var AnioSeleccionado = $("#AnioSeleccionado").val();
    var ConstanteSeleccionada = $("#ConstanteSeleccionada").val();
    var IdEmpresaUsuaria = $('#IdEmpresaUsuaria').val();
    var PrimerAnio = $("#PrimerAnio").val();
    var SegundoAnio = $("#SegundoAnio").val();
    var contigenciaTexto = "";


    if (IdContingencia == 1)
    {
        contigenciaTexto = "ENFERMEDAD GENERAL";
    }
    else if (IdContingencia == 2) {
        contigenciaTexto = "ENFERMEDAD LABORAL";
    }
    else if (IdContingencia == 3) {
        contigenciaTexto = "ACCIDENTE DE TRABAJO";
    }

    if (ConstanteSeleccionada == "") {
        swal({
            type: 'warning',
            title: 'Estimado Usuario:',
            text: 'El párametro Constante K es obligatorio',
            confirmButtonColor: '#7E8A97'
        });

        return false;
    }

    if (IdContingencia == null) {
        swal({
            type: 'warning',
            title: 'Estimado Usuario:',
            text: 'Por favor seleccione una  contigencia',
            confirmButtonColor: '#7E8A97'
        });

        return false;
    }

    if (PrimerAnio == "") {
        swal({
            type: 'warning',
            title: 'Estimado Usuario:',
            text: 'El párametro primer año es obligatorio',
            confirmButtonColor: '#7E8A97'
        });

        return false;
    }

    if (SegundoAnio == "") {
        swal({
            type: 'warning',
            title: 'Estimado Usuario:',
            text: 'El párametro según año es obligatorio',
            confirmButtonColor: '#7E8A97'
        });

        return false;
    }
    $.ajax({
        data: { PrimerAnio: PrimerAnio,SegundoAnio:SegundoAnio, IdContingencia: IdContingencia,contigenciaTexto:contigenciaTexto, ConstanteSeleccionada: ConstanteSeleccionada, IdEmpresaUsuaria: IdEmpresaUsuaria },
        url: urlBase + '/ReportesAplicacion/IndicadoresAusentismoComparacion',
        type: 'POST'
    });
    location.reload(true);
    OcultarPopupposition();

}
  
function SeleccionarReporteIndicador(tipo) {

    var TipoIndicador = tipo;
    $("#TipoReporteInd").val(tipo);
 cont=0;

    switch (TipoIndicador) {
        case "ReporteSST":
            $("#divParametros").show();
            $("#IDReportesPro").hide();
            $("#SedeInd").hide();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#divAnio").show();
            $("#divEstado").hide();
            $("#divParametrosEst").show();

            break;
        case "CondicionActosInseguros":
            $("#divParametros").show();
            $("#IDReportesPro").hide();
            $("#SedeInd").hide();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#procesoInd").hide();
            $("#divAnio").show();
            $("#divEstado").hide();
            $("#divParametrosEst").show();
            break;

        case "PlanTrabajoAnual":
            $("#divParametros").show();
            $("#IDReportesPro").hide();
            $("#SedeInd").show();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#procesoInd").hide();
            $("#divAnio").show();
            $("#divEstado").hide();
            $("#divParametrosEst").show();

     
            break;

        case "EstandaresMinimos":
            $("#divParametros").show();
            $("#IDReportesPro").hide();
            $("#SedeInd").hide();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#procesoInd").hide();
            $("#divAnio").show();
            $("#divEstado").hide();
            $("#divParametrosEst").show();
            break;


        case "AccidentesDeTrabajo":
            $("#IDReportesRes").hide();
            $("#divConstanteK").hide();
            $("#SedeInd").hide();
            $("#divContigencia").hide();
            $("#procesoInd").hide();
            $("#divAnio").show();
            $("#divEstado").hide();
            $("#divSedePeligro").hide();
            $("#divMetodologia").hide();
            $("#divProceso").hide();
            $("#divZona").hide();
            $("#divActividad").hide();
            $("#divTipoDePeligro").hide();
            $('#divModulo').hide();
            $("#divParametrosRes").show();

            break;

        case "TasaAccidentalidad":
            $("#IDReportesRes").hide();
            $("#SedeInd").hide();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#procesoInd").hide();
            $("#divAnio").show();
            $("#divEstado").hide();
            $("#divSedePeligro").hide();
            $("#divMetodologia").hide();
            $("#divProceso").hide();
            $("#divZona").hide();
            $("#divActividad").hide();
            $("#divTipoDePeligro").hide();
            $('#divModulo').hide();
            $("#divParametrosRes").show();
            break;

        case "CapacitacionEntrenamiento":
            $("#IDReportesRes").hide();
            $("#SedeInd").hide();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#procesoInd").hide();
            $("#divAnio").show();
            $("#divEstado").hide();
            $("#divSedePeligro").hide();
            $("#divMetodologia").hide();
            $("#divProceso").hide();
            $("#divZona").hide();
            $("#divActividad").hide();
            $("#divTipoDePeligro").hide();
            $('#divModulo').hide();
            $("#divParametrosRes").show();
            break;

        case "FrecuenciaAusentismo":
            $("#IDReportesRes").hide();
            $("#SedeInd").hide();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#procesoInd").hide();
            $("#divAnio").show();
            $("#divEstado").hide();
            $("#divSedePeligro").hide();
            $("#divMetodologia").hide();
            $("#divProceso").hide();
            $("#divZona").hide();
            $("#divActividad").hide();
            $("#divTipoDePeligro").hide();
            $('#divModulo').hide();
            $("#divParametrosRes").show();
            break;

        case "SeveridadAusentismo":
            $("#IDReportesRes").hide();
            $("#SedeInd").hide();
            $("#divConstanteK").hide();
            $("#divContigencia").show();
            $("#procesoInd").hide();
            $("#divAnio").show();
            $("#divEstado").hide();
            $("#divSedePeligro").hide();
            $("#divMetodologia").hide();
            $("#divProceso").hide();
            $("#divZona").hide();
            $("#divActividad").hide();
            $("#divTipoDePeligro").hide();
            $('#divModulo').hide();
            $("#divParametrosRes").show();
            break;


        case "SeveridadAccidenteTrabajo":
            $("#IDReportesRes").hide();
            $("#SedeInd").hide();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#procesoInd").hide();
            $("#divAnio").show();
            $("#divEstado").hide();
            $("#divSedePeligro").hide();
            $("#divMetodologia").hide();
            $("#divProceso").hide();
            $("#divZona").hide();
            $("#divActividad").hide();
            $("#divTipoDePeligro").hide();
            $('#divModulo').hide();
            $("#divParametrosRes").show();
            break;

        case "LesionesIncapacitantes":
            $("#IDReportesRes").hide();
            $("#SedeInd").hide();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#procesoInd").hide();
            $("#divAnio").show();
            $("#divEstado").hide();
            $("#divSedePeligro").hide();
            $("#divMetodologia").hide();
            $("#divProceso").hide();
            $("#divZona").hide();
            $("#divActividad").hide();
            $("#divTipoDePeligro").hide();
            $('#divModulo').hide();
            $("#divParametrosRes").show();
            break;

        case "CumplimientoRequisitosLegales":
            $("#IDReportesRes").hide();
            $("#SedeInd").hide();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#procesoInd").hide();
            $("#divAnio").show();
            $("#divEstado").hide();
            $("#divSedePeligro").hide();
            $("#divMetodologia").hide();
            $("#divProceso").hide();
            $("#divZona").hide();
            $("#divActividad").hide();
            $("#divTipoDePeligro").hide();
            $('#divModulo').hide();
            $("#divParametrosRes").show();
            break;

        case "AnalisisVulnerabilidad":
            $("#IDReportesRes").hide();
            $("#divAnio").hide();
            $("#SedeInd").show();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#procesoInd").hide();
            $("#divEstado").hide();
            $("#divSedePeligro").hide();
            $("#divMetodologia").hide();
            $("#divProceso").hide();
            $("#divZona").hide();
            $("#divActividad").hide();
            $("#divTipoDePeligro").hide();
            $('#divModulo').hide();
            $("#divParametrosRes").show();

            break;

        case "PeligroYRiesgos":
            $("#IDReportesRes").hide();
            $("#SedeInd").hide();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#procesoInd").hide();
            $("#divAnio").hide();
            $("#divEstado").hide();
            $("#divSedePeligro").show();
            $("#divMetodologia").hide();
            $("#divProceso").hide();
            $("#divZona").hide();
            $("#divActividad").hide();
            $("#divTipoDePeligro").hide();
            $('#divModulo').hide();
            $("#divParametrosRes").show();
            break;

        case "PlanesDeAccion":
            $("#IDReportesRes").hide();
            $("#SedeInd").hide();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#procesoInd").hide();
            $("#divAnio").show();
            $("#divEstado").hide();
            $("#divSedePeligro").hide();
            $("#divMetodologia").hide();
            $("#divProceso").hide();
            $("#divZona").hide();
            $("#divActividad").hide();
            $("#divTipoDePeligro").hide();
            $('#divModulo').show();
            $("#divParametrosRes").show();
            break;


        case "ComiteConvivencia":

            $("#IDReportesEst").hide();
            $("#SedeInd").show();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#procesoInd").hide();
            $("#divAnio").show();
            $("#divEstado").hide();
            $("divTipoComunicacion").hide();
            $("#divGrupo").hide();
            $("#divCargo").hide();
            $("#divDocumento").hide();
            $('#divTipoComunicacionAPP').hide();
            break;


        case "ComiteCoppast":

            $("#IDReportesEst").hide();
            $("#SedeInd").show();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#procesoInd").hide();
            $("#divAnio").show();
            $("#divEstado").hide();
            $("divTipoComunicacion").hide();
            $("#divGrupo").hide();
            $("#divCargo").hide();
            $("#divDocumento").hide();
            $('#divTipoComunicacionAPP').hide();
            break;



        case "DxSalud":
            $("#IDReportesEst").hide();
            $("#SedeInd").show();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#procesoInd").show();
            $("#divAnio").show();
            $("#divEstado").hide();
            $("#divTipoComunicacion").hide();
            $("#divGrupo").hide();
            $("#divCargo").hide();
            $("#divDocumento").hide();
            $('#divTipoComunicacionAPP').hide();
            break;

        case "PerfilSocioD":
            $("#IDReportesEst").hide();
            $("#divAnio").hide();
            $("#SedeInd").show();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#procesoInd").show();
            $("#divEstado").hide();
            $("#divTipoComunicacion").hide();
            $("#divGrupo").hide();
            $("#divCargo").hide();
            $("#divDocumento").hide();
            $('#divTipoComunicacionAPP').hide();
            break;


        case "ComunicacionesInternas":
            $("#IDReportesEst").hide();
            $("#SedeInd").hide();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#procesoInd").hide();
            $("#divAnio").hide();
            $("#divEstado").hide();
            $("#divTipoComunicacion").show();
            $("#divGrupo").hide();
            $("#divCargo").hide();
            $("#divCargoAPP").hide();
            $("#divDocumento").hide();
            $('#divTipoComunicacionAPP').hide();
            break;

        case "ComunicacionesAPP":
            $("#IDReportesEst").hide();
            $("#SedeInd").hide();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#procesoInd").hide();
            $("#divAnio").hide();
            $("#divEstado").hide();
            $("#divTipoComunicacion").hide();
            $("#divGrupo").hide();
            $("#divCargo").hide();
            $("#divCargoAPP").hide();
            $("#divDocumento").hide();
            $('#divTipoComunicacionAPP').show();
          

            break;

        case "ComunicacionesAPP":
            $("#IDReportesEst").hide();
            $("#SedeInd").hide();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#procesoInd").hide();
            $("#divAnio").show();
            $("#divEstado").hide();
            $("#divTipoComunicacion").hide();
            $("#divGrupo").hide();
            $("#divCargo").hide();
            $("#divCargoAPP").hide();
            $("#divDocumento").hide();
            $('#divTipoComunicacionAPP').hide();
          

            break;





  
    }

}


function SeleccionarReporteIndicadorDatos() {

    var TipoIndicador = $("#TipoReporteInd").val();

    switch (TipoIndicador) {
        case "ReporteSST":
            $("#SedeInd").hide();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#divTipoReporte").hide();
            $("#procesoInd").hide();
            $("#divAnio").show();
            $("#divTipoComunicacionAPP").hide();
            $("#divTipoComunicacion").hide();
            $("#divCargoAPP").hide();
            $("#divCargo").hide();
            $("#divGrupo").hide();
            $("#divDocumento").hide();
            $("#divModulo").hide();
            $("#divSedePeligro").hide();
            $("#divMetodologia").hide();
            $("#divProceso").hide();
            $("#divZona").hide();
            $("#divActividad").hide();
            $("#divTipoDePeligro").hide();
            break;
        case "CondicionActosInseguros":
            $("#SedeInd").show();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#divTipoReporte").show();
            $("#procesoInd").hide();
            $("#divAnio").show();
            $("#divTipoComunicacionAPP").hide();
            $("#divTipoComunicacion").hide();
            $("#divCargoAPP").hide();
            $("#divCargo").hide();
            $("#divGrupo").hide();
            $("#divDocumento").hide();
            $("#divModulo").hide();
            $("#divSedePeligro").hide();
            $("#divMetodologia").hide();
            $("#divProceso").hide();
            $("#divZona").hide();
            $("#divActividad").hide();
            $("#divTipoDePeligro").hide();
            break;

        case "PlanTrabajoAnual":

            $("#SedeInd").show();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#divTipoReporte").hide();
            $("#procesoInd").hide();
            $("#divAnio").show();
            $("#divTipoComunicacionAPP").hide();
            $("#divTipoComunicacion").hide();
            $("#divCargoAPP").hide();
            $("#divCargo").hide();
            $("#divGrupo").hide();
            $("#divDocumento").hide();
            $("#divModulo").hide();
            $("#divSedePeligro").hide();
            $("#divMetodologia").hide();
            $("#divProceso").hide();
            $("#divZona").hide();
            $("#divActividad").hide();
            $("#divTipoDePeligro").hide();
            break;

        case "EstandaresMinimos":
            $("#SedeInd").hide();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#divTipoReporte").hide();
            $("#procesoInd").hide();
            $("#divAnio").show();
            $("#divTipoComunicacionAPP").hide();
            $("#divTipoComunicacion").hide();
            $("#divCargoAPP").hide();
            $("#divCargo").hide();
            $("#divGrupo").hide();
            $("#divDocumento").hide();
            $("#divModulo").hide();
            $("#divSedePeligro").hide();
            $("#divMetodologia").hide();
            $("#divProceso").hide();
            $("#divZona").hide();
            $("#divActividad").hide();
            $("#divTipoDePeligro").hide();
            break;


        case "AccidentesDeTrabajo":
            $("#divConstanteK").hide();
            $("#SedeInd").show();
            $("#divContigencia").hide();
            $("#divTipoReporte").hide();
            $("#procesoInd").hide();
            $("#divAnio").show();
            $("#divTipoComunicacionAPP").hide();
            $("#divTipoComunicacion").hide();
            $("#divCargoAPP").hide();
            $("#divCargo").hide();
            $("#divGrupo").hide();
            $("#divDocumento").hide();
            $("#divModulo").hide();

            $("#divSedePeligro").hide();
            $("#divMetodologia").hide();
            $("#divProceso").hide();
            $("#divZona").hide();
            $("#divActividad").hide();
            $("#divTipoDePeligro").hide();
            break;

        case "TasaAccidentalidad":
            $("#SedeInd").show();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#divTipoReporte").hide();
            $("#procesoInd").hide();
            $("#divAnio").show();
            $("#divTipoComunicacionAPP").hide();
            $("#divTipoComunicacion").hide();
            $("#divCargoAPP").hide();
            $("#divCargo").hide();
            $("#divGrupo").hide();
            $("#divDocumento").hide();
            $("#divModulo").hide();

            $("#divSedePeligro").hide();
            $("#divMetodologia").hide();
            $("#divProceso").hide();
            $("#divZona").hide();
            $("#divActividad").hide();
            $("#divTipoDePeligro").hide();
            break;

        case "CapacitacionEntrenamiento":
            $("#SedeInd").hide();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#divTipoReporte").hide();
            $("#procesoInd").hide();
            $("#divAnio").show();
            $("#divTipoComunicacionAPP").hide();
            $("#divTipoComunicacion").hide();
            $("#divCargoAPP").hide();
            $("#divCargo").hide();
            $("#divGrupo").hide();
            $("#divDocumento").hide();
            $("#divModulo").hide();

            $("#divSedePeligro").hide();
            $("#divMetodologia").hide();
            $("#divProceso").hide();
            $("#divZona").hide();
            $("#divActividad").hide();
            $("#divTipoDePeligro").hide();
            break;

        case "FrecuenciaAusentismo":
         
            $("#divConstanteK").hide();
            $("#divContigencia").show();
            $("#SedeInd").show();
            $("#divTipoReporte").hide();
            $("#procesoInd").hide();
            $("#divAnio").show();
            $("#divTipoComunicacionAPP").hide();
            $("#divTipoComunicacion").hide();
            $("#divCargoAPP").hide();
            $("#divCargo").hide();
            $("#divGrupo").hide();
            $("#divDocumento").hide();
            $("#divModulo").hide();

            $("#divSedePeligro").hide();
            $("#divMetodologia").hide();
            $("#divProceso").hide();
            $("#divZona").hide();
            $("#divActividad").hide();
            $("#divTipoDePeligro").hide();
            break;

        case "SeveridadAusentismo":
     
            $("#divConstanteK").hide();
            $("#divContigencia").show();
            $("#SedeInd").show();
            $("#divTipoReporte").hide();
            $("#procesoInd").hide();
            $("#divAnio").show();
            $("#divTipoComunicacionAPP").hide();
            $("#divTipoComunicacion").hide();
            $("#divCargoAPP").hide();
            $("#divCargo").hide();
            $("#divGrupo").hide();
            $("#divDocumento").hide();
            $("#divModulo").hide();


            $("#divSedePeligro").hide();
            $("#divMetodologia").hide();
            $("#divProceso").hide();
            $("#divZona").hide();
            $("#divActividad").hide();
            $("#divTipoDePeligro").hide();
           

            break;


        case "AccidenteDeTrabajo":
            $("#SedeInd").show();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#divTipoReporte").hide();
            $("#procesoInd").hide();
            $("#divAnio").show();
            $("#divTipoComunicacionAPP").hide();
            $("#divTipoComunicacion").hide();
            $("#divCargoAPP").hide();
            $("#divCargo").hide();
            $("#divGrupo").hide();
            $("#divDocumento").hide();
            $("#divModulo").hide();


            $("#divSedePeligro").hide();
            $("#divMetodologia").hide();
            $("#divProceso").hide();
            $("#divZona").hide();
            $("#divActividad").hide();
            $("#divTipoDePeligro").hide();
           
            break;

        case "LesionesIncapacitantes":
            $("#SedeInd").show();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#divTipoReporte").hide();
            $("#procesoInd").hide();
            $("#divAnio").show();
            $("#divTipoComunicacionAPP").hide();
            $("#divTipoComunicacion").hide();
            $("#divCargoAPP").hide();
            $("#divCargo").hide();
            $("#divGrupo").hide();
            $("#divDocumento").hide();
            $("#divModulo").hide();

            $("#divSedePeligro").hide();
            $("#divMetodologia").hide();
            $("#divProceso").hide();
            $("#divZona").hide();
            $("#divActividad").hide();
            $("#divTipoDePeligro").hide();
           
            break;

        case "CumplimientoRequisitosLegales":
            $("#SedeInd").hide();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#divTipoReporte").hide();
            $("#procesoInd").hide();
            $("#divAnio").show();
            $("#divTipoComunicacionAPP").hide();
            $("#divTipoComunicacion").hide();
            $("#divCargoAPP").hide();
            $("#divCargo").hide();
            $("#divGrupo").hide();
            $("#divDocumento").hide();
            $("#divModulo").hide();

            $("#divSedePeligro").hide();
            $("#divMetodologia").hide();
            $("#divProceso").hide();
            $("#divZona").hide();
            $("#divActividad").hide();
            $("#divTipoDePeligro").hide();
           
            break;

        case "RequisitosLegales":
            $("#SedeInd").hide();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#divTipoReporte").hide();
            $("#procesoInd").hide();
            $("#divAnio").show();
            $("#divTipoComunicacionAPP").hide();
            $("#divTipoComunicacion").hide();
            $("#divCargoAPP").hide();
            $("#divCargo").hide();
            $("#divGrupo").hide();
            $("#divDocumento").hide();
            $("#divModulo").hide();

            $("#divSedePeligro").hide();
            $("#divMetodologia").hide();
            $("#divProceso").hide();
            $("#divZona").hide();
            $("#divActividad").hide();
            $("#divTipoDePeligro").hide();
          
            break;

        case "DxCondicionesSalud":
            $("#SedeInd").show();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#divTipoReporte").hide();
            $("#procesoInd").show();
            $("#divAnio").show();
            $("#divTipoComunicacionAPP").hide();
            $("#divTipoComunicacion").hide();
            $("#divCargoAPP").hide();
            $("#divCargo").hide();
            $("#divGrupo").hide();
            $("#divDocumento").hide();
            $("#divModulo").hide();

            $("#divSedePeligro").hide();
            $("#divMetodologia").hide();
            $("#divProceso").hide();
            $("#divZona").hide();
            $("#divActividad").hide();
            $("#divTipoDePeligro").hide();
           
            break;
            


        case "AnalisisVulnerabilidadDatos":
            $("#divAnio").hide();
            
            $("#SedeInd").show();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#procesoInd").hide();
            $("#divEstado").hide();
            $("#divTipoComunicacionAPP").hide();
            $("#divTipoComunicacion").hide();
            $("#divCargoAPP").hide();
            $("#divCargo").hide();
            $("#divGrupo").hide();
            $("#divDocumento").hide();
            $("#divModulo").hide();

            $("#divSedePeligro").hide();
            $("#divMetodologia").hide();
            $("#divProceso").hide();
            $("#divZona").hide();
            $("#divActividad").hide();
            $("#divTipoDePeligro").hide();
    
            break;

        case "PerfilSociodemografico":
            $("#divAnio").hide();

            $("#SedeInd").show();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#procesoInd").show();
            $("#divEstado").hide();
            $("#divTipoComunicacionAPP").hide();
            $("#divTipoComunicacion").hide();
            $("#divCargoAPP").hide();
            $("#divCargo").hide();
            $("#divGrupo").hide();
            $("#divDocumento").hide();
            $("#divModulo").hide();
            $("#divSedePeligro").hide();
            $("#divMetodologia").hide();
            $("#divProceso").hide();
            $("#divZona").hide();
            $("#divActividad").hide();
            $("#divTipoDePeligro").hide();
            $('#divModulo').hide();


            $("#divSedePeligro").hide();
            $("#divMetodologia").hide();
            $("#divProceso").hide();
            $("#divZona").hide();
            $("#divActividad").hide();
            $("#divTipoDePeligro").hide();
           
            break;

        case "ComunicacionesInternas":
            $("#divAnio").hide();

            $("#SedeInd").hide();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#procesoInd").hide();
            $("#divEstado").hide();
            $("#divTipoComunicacion").show();
            $("#divTipoComunicacionAPP").hide();
            $("#divCargoAPP").hide();
            $("#divCargo").hide();
            $("#divGrupo").hide();
            $("#divDocumento").hide();
            $("#divModulo").hide();
            $("#divSedePeligro").hide();
            $("#divMetodologia").hide();
            $("#divProceso").hide();
            $("#divZona").hide();
            $("#divActividad").hide();
            $("#divTipoDePeligro").hide();
          
            break;
        
        case "ComunicacionesAPP":
            $("#divAnio").hide();

            $("#SedeInd").hide();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#procesoInd").hide();
            $("#divEstado").hide();
            $("#divTipoComunicacionAPP").show();
            $("#divTipoComunicacion").hide();
            $("#divCargoAPP").hide();
            $("#divCargo").hide();
            $("#divGrupo").hide();
            $("#divDocumento").hide();
            $("#divModulo").hide();
            $("#divSedePeligro").hide();
            $("#divMetodologia").hide();
            $("#divProceso").hide();
            $("#divZona").hide();
            $("#divActividad").hide();
            $("#divTipoDePeligro").hide();
           
            break;


        case "PlanesDeAccion":
            $("#divAnio").show();

            $("#SedeInd").hide();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#procesoInd").hide();
            $("#divEstado").hide();
            $("#divTipoComunicacionAPP").hide();
            $("#divTipoComunicacion").hide();
            $("#divCargoAPP").hide();
            $("#divCargo").hide();
            $("#divGrupo").hide();
            $("#divDocumento").hide();
            $("#divModulo").show();

            $("#divSedePeligro").hide();
            $("#divMetodologia").hide();
            $("#divProceso").hide();
            $("#divZona").hide();
            $("#divActividad").hide();
            $("#divTipoDePeligro").hide();
        
            break;

        case "PeligroYRiesgos":
            $("#divAnio").hide();
            $("#SedeInd").hide();
            $("#divConstanteK").hide();
            $("#divContigencia").hide();
            $("#procesoInd").hide();
            $("#divEstado").hide();
            $("#divTipoComunicacionAPP").hide();
            $("#divTipoComunicacion").hide();
            $("#divCargoAPP").hide();
            $("#divCargo").hide();
            $("#divGrupo").hide();
            $("#divDocumento").hide();
            $("#divModulo").hide();

            $("#divSedePeligro").show();
            $("#divMetodologia").hide();
            $("#divProceso").hide();
            $("#divZona").hide();
            $("#divActividad").hide();
            $("#divTipoDePeligro").hide();
      

            break;

    }

}

function SeleccionarDatosInd() {

    var anio = $("#anio").val();

    var idSede = $("#FKSede").val();
    var sedeTexto = $("#FKSede option:selected").html();
    var TipoIndicador = $("#TipoReporteInd").val();
    var constanteK = $("#ConstanteK").val();
    var contigencia = $("#Contigencia").val();
    var contigenciaTexto = $("#Contigencia option:selected").html();
    var tipoReporte = $("#TipoReporte").val();
    var idProceso = $("#Procesos").val();
    var tipoCom = $("#tipoCom").val();
    var tipoComTexto = $("#tipoCom  option:selected").html();
    var documento = $("#num_documento").val();
    var grupo = $("#Grupo").val();
    var cargo = $("#Cargo").val();
    var grupoTexto = $("#Grupo option:selected").html();
    var cargoTexto = $("#Cargo option:selected").html();
    var cargoAPP = $("#CargoAPP").val();
    var cargoTextoAPP = $("#CargoAPP option:selected").html();
    var tipoComAPP = $("#tipoComAPP").val();
    var tipoComTextoAPP = $("#tipoComAPP  option:selected").html();
    var modulo = $("#modulo").val();

    var sedePeligro = $("#FKSedePeligro").val();

    var metodologia = $("#Fk_Metodologia").val();

    var procesoPel = $("#Fk_Proceso").val();

    var zonaLugar = $("#Fk_ZonaLugar").val();
    var actividad = $("#Fk_Actividad").val();

    var zonaLugarTexto = $("#Fk_ZonaLugar  option:selected").html();
    var actividadTexto = $("#Fk_Actividad  option:selected").html();
    var tipoPeligro = $("#Fk_TipoDePeligro").val();

    // var contigenciaTexto = $("#Contigencia").text();

    if (TipoIndicador == "") {

        swal({
            type: 'warning',
            title: 'Estimado Usuario:',
            text: 'Por favor seleccione un tipo de reporte',
            confirmButtonColor: '#7E8A97'
        });

        return false;
    }

    switch (TipoIndicador) {

    

        case "ReporteSST":


            if (anio == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El parámetro año es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }
            break;

   

      

        case "CondicionActosInseguros":


            if (anio == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El parámetro año es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }
            break;
            
        case "PlanTrabajoAnual":


            if (anio == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El parámetro año es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }
            break;

        case "EstandaresMinimos":


            if (anio == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El parámetro año es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }
            break;


        case "AccidentesDeTrabajo":


            if (anio == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El parámetro año es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }
            break;

        case "TasaAccidentalidad":


            if (anio == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El parámetro año es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }
            break;

        case "CapacitacionEntrenamiento":


            if (anio == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El parámetro año es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }
            break;


        case "AccidenteDeTrabajo":


            if (anio == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El parámetro año es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }
            break;

        case "LesionesIncapacitantes":


            if (anio == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El parámetro año es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }
            break;

        case "RequisitosLegales":


            if (anio == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El parámetro año es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }
            break;

        case "DxCondicionesSalud":


            if (anio == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El parámetro año es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }
            break;

            
        case "FrecuenciaAusentismo":


            if (anio == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El parámetro año es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }

            if (contigencia == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El parámetro contingencia es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }

            
            break;


        case "SeveridadAusentismo":


            if (anio == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El parámetro año es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }

            if (contigencia == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El parámetro contingencia es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }

            
            break;


        case "AnalisisVulnerabilidadDatos":


            if (idSede == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El parámetro sede es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }
            break;

        case "ComunicacionesInternas":

            if (tipoCom == "") {
                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'Por favor seleccione un tipo de comunicado',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }

            if (tipoCom == 1) {


                if (documento == "") {

                    swal({
                        type: 'warning',
                        title: 'Estimado Usuario:',
                        text: 'El parametro documento es obligatorio',
                        confirmButtonColor: '#7E8A97'
                    });

                    return false;
                }


                if (anio == "") {

                    swal({
                        type: 'warning',
                        title: 'Estimado Usuario:',
                        text: 'El parametro año es obligatorio',
                        confirmButtonColor: '#7E8A97'
                    });

                    return false;
                }


            } else if (tipoCom == 2) {
                if (cargo == "") {
                    swal({
                        type: 'warning',
                        title: 'Estimado Usuario:',
                        text: 'El parametro Destinatarios es obligatorio',
                        confirmButtonColor: '#7E8A97'
                    });
                    return false;
                }

                if (anio == "") {

                    swal({
                        type: 'warning',
                        title: 'Estimado Usuario:',
                        text: 'El parametro año es obligatorio',
                        confirmButtonColor: '#7E8A97'
                    });

                    return false;
                }


            } else {

                if (grupo == "") {
                    swal({
                        type: 'warning',
                        title: 'Estimado Usuario:',
                        text: 'El parametro grupo es obligatorio',
                        confirmButtonColor: '#7E8A97'
                    });

                    return false;

                }


                if (anio == "") {

                    swal({
                        type: 'warning',
                        title: 'Estimado Usuario:',
                        text: 'El parametro año es obligatorio',
                        confirmButtonColor: '#7E8A97'
                    });

                    return false;
                }


            }

            break;

        case "ComunicacionesAPP":

            if (tipoComAPP == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'Por favor seleccione un tipo de comunicado',
                    confirmButtonColor: '#7E8A97'
                });

                return false;

            }

            if (tipoComAPP == 1) {


                if (documento == "") {

                    swal({
                        type: 'warning',
                        title: 'Estimado Usuario:',
                        text: 'El parametro documento es obligatorio',
                        confirmButtonColor: '#7E8A97'
                    });

                    return false;
                }


                if (anio == "") {

                    swal({
                        type: 'warning',
                        title: 'Estimado Usuario:',
                        text: 'El parametro año es obligatorio',
                        confirmButtonColor: '#7E8A97'
                    });

                    return false;
                }


            } else if (tipoComAPP == 2) {
                if (cargoAPP == "") {
                    swal({
                        type: 'warning',
                        title: 'Estimado Usuario:',
                        text: 'El parametro Destinatarios es obligatorio',
                        confirmButtonColor: '#7E8A97'
                    });

                    return false;
                }

                if (anio == "") {

                    swal({
                        type: 'warning',
                        title: 'Estimado Usuario:',
                        text: 'El parametro año es obligatorio',
                        confirmButtonColor: '#7E8A97'
                    });

                    return false;
                }


            }
            break;

        case "PlanesDeAccion":




            if (modulo == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El parametro módulo es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });
                return false;
            }

            if (anio == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El parametro año es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }


            break;

        case "PeligroYRiesgos":



            if (sedePeligro == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El parametro Sede es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }


            if (metodologia == "" || metodologia == null) {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El parametro Metodología es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }

            if (tipoPeligro == "" || tipoPeligro == null) {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El parametro Tipo de peligro es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }
            break;
   


    }


    







    if ($("#formReportesIndicadores").valid()) {
        PopupPosition();
        switch (TipoIndicador) {
            case "ReporteSST":
                $.ajax({
                    data: { anio: anio },
                    url: urlBase + '/ReportesAplicacion/ReporteAccionCorrectivaPreventivaDatos',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;

            case "CondicionActosInseguros":
                $.ajax({
                    data: { anio: anio, tipoReporte: tipoReporte, idSede: idSede },
                    url: urlBase + '/ReportesAplicacion/IndicadorCondicionesInsegurasDatos',
                    type: 'POST'
                });
                location.reload();
                OcultarPopupposition(true);
                break;

            case "PlanTrabajoAnual":


                $.ajax({
                    data: { anio: anio, idSede: idSede },
                    url: urlBase + '/ReportesAplicacion/IndicadorPlanTrabajoAnualDatos',
                    type: 'POST'
                });
                location.reload();
                OcultarPopupposition(true);
                break;

            case "EstandaresMinimos":
                $.ajax({
                    data: { anio: anio },
                    url: urlBase + '/ReportesAplicacion/IndicadorEstandaresMinimosDatos',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;

            case "AccidentesDeTrabajo":
                $.ajax({
                    data: { anio: anio,idSede:idSede },
                    url: urlBase + '/ReportesAplicacion/IndicadorAccidentesDeTrabajoDatos',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;

            case "TasaAccidentalidad":
                $.ajax({
                    data: { anio: anio,idSede:idSede },
                    url: urlBase + '/ReportesAplicacion/IndicadorTasaAccidentalidadDatos',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;

            case "CapacitacionEntrenamiento":
                $.ajax({
                    data: { anio: anio },
                    url: urlBase + '/ReportesAplicacion/IndicadorCapacitacionEntrenamientoDatos',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;

            case "FrecuenciaAusentismo":
                $.ajax({
                    data: { anio: anio, idSede: idSede, contigencia: contigencia },
                    url: urlBase + '/ReportesAplicacion/IndicadorFrecuenciaAusentismoDatos',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;

            case "SeveridadAusentismo":
                $.ajax({
                    data: { anio: anio, contigencia: contigencia,idSede:idSede },
                    url: urlBase + '/ReportesAplicacion/IndicadorSeveridadAusentismoDatos',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;

            case "AccidenteDeTrabajo":
                $.ajax({
                    data: { anio: anio,idSede:idSede },
                    url: urlBase + '/ReportesAplicacion/IndicadorAccidenteDeTrabajoDatos',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;

            case "RequisitosLegales":
                $.ajax({
                    data: { anio: anio},
                    url: urlBase + '/ReportesAplicacion/IndicadorCumplimientoRequisitosLegalesDatos',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;

            case "LesionesIncapacitantes":
                $.ajax({
                    data: { anio: anio, idSede:idSede },
                    url: urlBase + '/ReportesAplicacion/IndicadorLesionesIncapacitantesDatos',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;

            case "DxCondicionesSalud":
                $.ajax({
                    data: { anio: anio, idSede: idSede,idProceso:idProceso },
                    url: urlBase + '/ReportesAplicacion/IndicadorDxCondicionesSaludDatos',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;


            case "AnalisisVulnerabilidadDatos":
                $.ajax({
                    data: { sedeTexto: sedeTexto },
                    url: urlBase + '/ReportesAplicacion/IndicadorAnalisisVulnerabilidadDatos',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;


                
            case "PerfilSociodemografico":
                $.ajax({
                    data: { idSede:idSede,idProceso:idProceso},
                    url: urlBase + '/ReportesAplicacion/IndicadorPerfilSociodemograficoDatos',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;


            case "ComunicacionesInternas":

                if (tipoCom == 1) {
                    $.ajax({
                        data: { anio: anio, documento: documento, tipoComTexto: tipoComTexto },
                        url: urlBase + '/ReportesAplicacion/IndicadorComunicacionesInternasPersonasDatos',
                        type: 'POST'
                    });
                    location.reload(true);
                    OcultarPopupposition();
                }
                else if (tipoCom == 2) {

                    $.ajax({
                        data: { anio: anio, cargoTexto: cargoTexto, tipoComTexto: tipoComTexto },
                        url: urlBase + '/ReportesAplicacion/IndicadorComunicacionesInternasCargoDatos',
                        type: 'POST'
                    });
                    location.reload(true);
                    OcultarPopupposition();

                }
                else {
                    $.ajax({
                        data: { anio: anio, grupoTexto: grupoTexto, tipoComTexto: tipoComTexto },
                        url: urlBase + '/ReportesAplicacion/IndicadorComunicacionesInternasGruposDatos',
                        type: 'POST'
                    });
                    location.reload(true);
                    OcultarPopupposition();
                }
                break;
            case "ComunicacionesAPP":

                if (tipoComAPP == 1) {
                    $.ajax({
                        data: { anio: anio, documento: documento, tipoComTextoAPP: tipoComTextoAPP },
                        url: urlBase + '/ReportesAplicacion/IndicadorComunicacionesInternasPersonasAPPDatos',
                        type: 'POST'
                    });
                    location.reload(true);
                    OcultarPopupposition();
                }
                else {
                    $.ajax({
                        data: { anio: anio, cargoTextoAPP: cargoTextoAPP, tipoComTextoAPP: tipoComTextoAPP },
                        url: urlBase + '/ReportesAplicacion/IndicadorComunicacionesInternasCargoAPPDatos',
                        type: 'POST'
                    });
                    location.reload(true);
                    OcultarPopupposition();
                }
                break;

            case "PlanesDeAccion":

                switch (modulo) {

                    case "1":
                        $.ajax({
                            data: { anio: anio},
                            url: urlBase + '/ReportesAplicacion/IndicadorPlanesDeAccionEvaluacionSGSSTDatos',
                            type: 'POST'
                        });
                        location.reload(true);
                        OcultarPopupposition();

                        break;
                    case "2":
                        $.ajax({
                            data: { anio: anio },
                            url: urlBase + '/ReportesAplicacion/IndicadorPlanesDeAccionAccionesPrevCorrectivasDatos',
                            type: 'POST'
                        });
                        location.reload(true);
                        OcultarPopupposition();
                        break;
                    case "3":
                        $.ajax({
                            data: { anio: anio },
                            url: urlBase + '/ReportesAplicacion/IndicadorPlanesDeAccionAuditoriasDatos',
                            type: 'POST'
                        });
                        location.reload();
                        OcultarPopupposition();
                        break;
                    case "4":
                        $.ajax({
                            data: { anio: anio },
                            url: urlBase + '/ReportesAplicacion/IndicadorPlanesDeAccionInspeccionDatos',
                            type: 'POST'
                        });
                        location.reload(true);
                        OcultarPopupposition();
                        break;
                    case "5":
                        $.ajax({
                            data: { anio: anio },
                            url: urlBase + '/ReportesAplicacion/IndicadorPlanesDeAccionActosInsegurosDatos',
                            type: 'POST'
                        });
                        location.reload(true);
                        OcultarPopupposition();
                        break;
                    case "6":
                        $.ajax({
                            data: { anio: anio },
                            url: urlBase + '/ReportesAplicacion/IndicadorPlanesDeAccionCoppastDatos',
                            type: 'POST'
                        });
                        location.reload(true);
                        OcultarPopupposition();
                        break;
                    case "7":
                        $.ajax({
                            data: { anio: anio },
                            url: urlBase + '/ReportesAplicacion/IndicadorPlanesDeAccionComiteConvivenciaDatos',
                            type: 'POST'
                        });
                        location.reload(true);
                        OcultarPopupposition();
                        break;
                    default:
                        $.ajax({
                            data: { anio: anio },
                            url: urlBase + '/ReportesAplicacion/IndicadorPlanesDeAccionRevisionSGSSTDatos',
                            type: 'POST'
                        });
                        location.reload(true);
                        OcultarPopupposition();

                }



                break;

            case "PeligroYRiesgos":

                if (procesoPel == null) {
                    procesoPel = "";
                }
                if (zonaLugar == null) {
                    zonaLugar = "";
                }
                if (actividad == null) {
                    actividad = "";
                }
                if (sedePeligro != "" && metodologia != "" && procesoPel != "" && zonaLugar != "" && actividad != "" && tipoPeligro != "") {

                    $.ajax({
                        data: {
                            sedePeligro: sedePeligro, metodologia: metodologia,
                            procesoPel: procesoPel, zonaLugarTexto: zonaLugarTexto, actividadTexto: actividadTexto,
                            tipoPeligro: tipoPeligro

                        },
                        url: urlBase + '/ReportesAplicacion/identificacionPeligrosFiltroSedeMetodologiaProcesoLugarActividadValoracionDatos',
                        type: 'POST'
                    });
                    location.reload(true);
                    OcultarPopupposition();
                }
                else if (sedePeligro != "" && metodologia != "" && procesoPel != "" && zonaLugar != "" && tipoPeligro != "") {

                    $.ajax({
                        data: {
                            sedePeligro: sedePeligro, metodologia: metodologia,
                            procesoPel: procesoPel, zonaLugarTexto: zonaLugarTexto,
                            tipoPeligro: tipoPeligro
                        },
                        url: urlBase + '/ReportesAplicacion/identificacionPeligrosFiltroSedeMetodologiaProcesoLugarValoracionDatos',
                        type: 'POST'
                    });
                    location.reload(true);
                    OcultarPopupposition();
                } else if (sedePeligro != "" && metodologia != "" && procesoPel != "" && tipoPeligro != "") {
                    $.ajax({
                        data: {
                            sedePeligro: sedePeligro, metodologia: metodologia,
                            procesoPel: procesoPel,
                            tipoPeligro: tipoPeligro

                        },
                        url: urlBase + '/ReportesAplicacion/identificacionPeligrosFiltroSedeMetodologiaProcesoValoracionDatos',
                        type: 'POST'
                    });
                    location.reload(true);
                    OcultarPopupposition();

                } else if (sedePeligro != "" && metodologia != "" && tipoPeligro != "") {
                    $.ajax({
                        data: {
                            sedePeligro: sedePeligro, metodologia: metodologia,
                            procesoPel: procesoPel,
                            tipoPeligro: tipoPeligro

                        },
                        url: urlBase + '/ReportesAplicacion/identificacionPeligrosFiltroSedeMetodologiaValoracionDatos',
                        type: 'POST'
                    });
                    location.reload(true);
                    OcultarPopupposition();
                }
                break;

        }
    }
}


function SeleccionarReporteInd() {

    var anio = $("#anio").val();

    var idSede = $("#FKSede").val();
    var sedeTexto = $("#FKSede option:selected").html();
    var TipoIndicador = $("#TipoReporteInd").val();
    var constanteK = $("#ConstanteK").val();
    var contigencia = $("#Contigencia").val();
    var contigenciaTexto = $("#Contigencia option:selected").html();
    var idProceso = $("#Procesos").val();
    var procesoTexto = $("#Procesos option:selected").html();
    var estado = $("#Estado").val();
    // var contigenciaTexto = $("#Contigencia").text();
    var tipoCom = $("#tipoCom").val();
    var tipoComTexto = $("#tipoCom  option:selected").html();
    var documento = $("#num_documento").val();
    var grupo = $("#Grupo").val();
    var cargo = $("#Cargo").val();
    var grupoTexto = $("#Grupo option:selected").html();
    var cargoTexto = $("#Cargo option:selected").html();
    var cargoAPP = $("#CargoAPP").val();
    var cargoTextoAPP = $("#CargoAPP option:selected").html();
    var tipoComAPP = $("#tipoComAPP").val();
    var tipoComTextoAPP = $("#tipoComAPP  option:selected").html();
    var sedePeligro = $("#FKSedePeligro").val();
    var sedePelTexto = $("#FKSedePeligro option:selected").html();
    var metodologia = $("#Fk_Metodologia").val();
    var metodologiaTexto = $("#Fk_Metodologia option:selected").html();
    var procesoPel = $("#Fk_Proceso").val();
    var procesoPelTexto = $("#Fk_Proceso option:selected").html();
    var zonaLugarTexto = $("#Fk_ZonaLugar option:selected").html();
    var zonaLugar = $("#Fk_ZonaLugar").val();
    var actividad = $("#Fk_Actividad").val();
    var actividadTexto = $("#Fk_Actividad option:selected").html();
    var tipoPeligro = $("#Fk_TipoDePeligro").val();
    var tipoPeligroTexto = $("#Fk_TipoDePeligro option:selected").html();
    var modulo = $("#modulo").val();
    var moduloTexto = $("#modulo option:selected").html();

  

    if (idProceso == "")
    {
        procesoTexto = "";
    }
    if (idSede == "")
    {
        sedeTexto = "";
    }


    if (TipoIndicador == "") {

        swal({
            type: 'warning',
            title: 'Estimado Usuario:',
            text: 'Por favor seleccione un indicador',
            confirmButtonColor: '#7E8A97'
        });

        return false;
    }
   
    switch (TipoIndicador) {

        case "PlanTrabajoAnual":

            if (anio == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El párametro año es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }


            if (idSede == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El párametro Sede es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }

            break;



        case "CapacitacionEntrenamiento":

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

        case "ReporteSST":

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

        case "CondicionActosInseguros":

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

        case "EstandaresMinimos":


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

        case "TasaAccidentalidad":

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

        case "AccidentesDeTrabajo":

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

        case "FrecuenciaAusentismo":
      
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

        case "SeveridadAusentismo":

            if (anio == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El párametro año es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }

            if (contigencia == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'La contigencia es obligatoria',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }

            
            break;


        case "SeveridadAccidenteTrabajo":


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


        case "LesionesIncapacitantes":

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


        case "ComiteCoppast":

            if (anio == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El párametro año es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }

            if (idSede == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El párametro sede es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }
            break;

        case "ComiteConvivencia":

            if (anio == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El párametro año es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }

            if (idSede == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El párametro sede es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }
            break;

        case "DxSalud":


            if (anio == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El parametro año es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }
            break;


        case "AnalisisVulnerabilidad":


            if (idSede == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El parametro Sede es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }
            break;

        case "CumplimientoRequisitosLegales":



            if (anio == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El parametro año es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }
            break;
            
        case "ComunicacionesInternas":
                
            if (tipoCom == "")
            {
                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'Por favor seleccione un tipo de comunicado',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }

            if (tipoCom == 1)

            {


                if (documento == "") {

                    swal({
                        type: 'warning',
                        title: 'Estimado Usuario:',
                        text: 'El parametro documento es obligatorio',
                        confirmButtonColor: '#7E8A97'
                    });

                    return false;
                }


                if (anio == "") {

                    swal({
                        type: 'warning',
                        title: 'Estimado Usuario:',
                        text: 'El parametro año es obligatorio',
                        confirmButtonColor: '#7E8A97'
                    });

                    return false;
                }

               
            } else if (tipoCom == 2)
            {
                if (cargo == "")
                {
                    swal({
                        type: 'warning',
                        title: 'Estimado Usuario:',
                        text: 'El parametro Destinatarios es obligatorio',
                        confirmButtonColor: '#7E8A97'
                    });
                    return false;
                }

                if (anio == "") {

                    swal({
                        type: 'warning',
                        title: 'Estimado Usuario:',
                        text: 'El parametro año es obligatorio',
                        confirmButtonColor: '#7E8A97'
                    });

                    return false;
                }


            } else {

                if(grupo == "")
                {
                    swal({
                        type: 'warning',
                        title: 'Estimado Usuario:',
                        text: 'El parametro grupo es obligatorio',
                        confirmButtonColor: '#7E8A97'
                    });

                    return false;

                }


                if (anio == "") {

                    swal({
                        type: 'warning',
                        title: 'Estimado Usuario:',
                        text: 'El parametro año es obligatorio',
                        confirmButtonColor: '#7E8A97'
                    });

                    return false;
                }


            }
            
            break;

        case "ComunicacionesAPP":

            if (tipoComAPP == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'Por favor seleccione un tipo de comunicado',
                    confirmButtonColor: '#7E8A97'
                });

                return false;

            }

            if (tipoComAPP == 1) {


                if (documento == "") {

                    swal({
                        type: 'warning',
                        title: 'Estimado Usuario:',
                        text: 'El parametro documento es obligatorio',
                        confirmButtonColor: '#7E8A97'
                    });

                    return false;
                }


                if (anio == "") {

                    swal({
                        type: 'warning',
                        title: 'Estimado Usuario:',
                        text: 'El parametro año es obligatorio',
                        confirmButtonColor: '#7E8A97'
                    });

                    return false;
                }


            } else if (tipoComAPP == 2) {
                if (cargoAPP == "") {
                    swal({
                        type: 'warning',
                        title: 'Estimado Usuario:',
                        text: 'El parametro Destinatarios es obligatorio',
                        confirmButtonColor: '#7E8A97'
                    });

                    return false;
                }

                if (anio == "") {

                    swal({
                        type: 'warning',
                        title: 'Estimado Usuario:',
                        text: 'El parametro año es obligatorio',
                        confirmButtonColor: '#7E8A97'
                    });

                    return false;
                }


            } 
            break;


        case "PeligroYRiesgos":



            if (sedePeligro == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El parametro Sede es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }


            if (metodologia == "" || metodologia==null) {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El parametro Metodología es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }

            if (tipoPeligro == "" || tipoPeligro == null) {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El parametro Tipo de peligro es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });

                return false;
            }
            break;

        case "PlanesDeAccion":

       
            

            if (modulo == "") {

                swal({
                    type: 'warning',
                    title: 'Estimado Usuario:',
                    text: 'El parametro módulo es obligatorio',
                    confirmButtonColor: '#7E8A97'
                });
                return false;
            }

                if (anio == "") {

                    swal({
                        type: 'warning',
                        title: 'Estimado Usuario:',
                        text: 'El parametro año es obligatorio',
                        confirmButtonColor: '#7E8A97'
                    });

                    return false;
                }
               
            
            break;

            
    }


 

    if ($("#formReportesIndicadores").valid()) {
        PopupPosition();
        switch (TipoIndicador) {
            case "ReporteSST":
                $.ajax({
                    data: { anio: anio },
                    url: urlBase + '/ReportesAplicacion/ReporteAccionCorrectivaPreventiva',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;

            case "CondicionActosInseguros":
                $.ajax({
                    data: { anio: anio },
                    url: urlBase + '/ReportesAplicacion/IndicadorCondicionesInseguras',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;

            case "PlanTrabajoAnual":
               

                $.ajax({
                    data: { anio: anio, idSede: idSede, sedeTexto: sedeTexto },
                    url: urlBase + '/ReportesAplicacion/IndicadorPlanTrabajoAnual',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;

            case "EstandaresMinimos":
                $.ajax({
                    data: { anio: anio },
                    url: urlBase + '/ReportesAplicacion/IndicadorEstandaresMinimos',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;

            case "AccidentesDeTrabajo":
                $.ajax({
                    data: { anio: anio },
                    url: urlBase + '/ReportesAplicacion/IndicadorAccidentesDeTrabajo',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;

            case "TasaAccidentalidad":
                $.ajax({
                    data: { anio: anio},
                    url: urlBase + '/ReportesAplicacion/IndicadorTasaAccidentalidad',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;

            case "CapacitacionEntrenamiento":
                $.ajax({
                    data: { anio: anio },
                    url: urlBase + '/ReportesAplicacion/IndicadorCapacitacionEntrenamiento',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;

            case "FrecuenciaAusentismo":
                $.ajax({
                    data: { anio: anio },
                    url: urlBase + '/ReportesAplicacion/IndicadorFrecuenciaAusentismo',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;

            case "SeveridadAusentismo":
                $.ajax({
                    data: { anio: anio, contigencia: contigencia, contigenciaTexto: contigenciaTexto },
                    url: urlBase + '/ReportesAplicacion/IndicadorSeveridadAusentismo',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;

            case "AccidenteDeTrabajo":
                $.ajax({
                    data: { anio: anio, contigencia: contigencia },
                    url: urlBase + '/ReportesAplicacion/IndicadorAccidenteDeTrabajo',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;

            case "SeveridadAccidenteTrabajo":
                $.ajax({
                    data: { anio: anio },
                    url: urlBase + '/ReportesAplicacion/IndicadorSeveridadAccidenteTrabajo',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;

            case "LesionesIncapacitantes":
                $.ajax({
                    data: { anio: anio },
                    url: urlBase + '/ReportesAplicacion/IndicadorLesionesIncapacitantes',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;

            case "CumplimientoRequisitosLegales":
                $.ajax({
                    data: { anio: anio},
                    url: urlBase + '/ReportesAplicacion/IndicadorCumplimientoRequisitosLegales',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;

            case "ComiteCoppast":
                $.ajax({
                    data: { anio: anio, idSede: idSede, sedeTexto: sedeTexto},
                    url: urlBase + '/ReportesAplicacion/IndicadorComiteCoppast',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;

            case "ComiteConvivencia":
                $.ajax({
                    data: { anio: anio, idSede: idSede, sedeTexto: sedeTexto },
                    url: urlBase + '/ReportesAplicacion/IndicadorComiteComiteConvivencia',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;

            case "PerfilSocioD":
                $.ajax({
                    data: {  idSede: idSede, sedeTexto: sedeTexto,idProceso:idProceso,procesoTexto:procesoTexto },
                    url: urlBase + '/ReportesAplicacion/IndicadorPerfilSocioDemografico',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;

            case "DxSalud":
                $.ajax({
                    data: { anio: anio,idSede:idSede, sedeTexto: sedeTexto, idProceso: idProceso, procesoTexto: procesoTexto },
                    url: urlBase + '/ReportesAplicacion/IndicadorDxCondicionesSalud',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;
    

            case "AnalisisVulnerabilidad":
                $.ajax({
                    data: { sedeTexto:sedeTexto},
                    url: urlBase + '/ReportesAplicacion/IndicadorAnalisisVulnerabilidad',
                    type: 'POST'
                });
                location.reload(true);
                OcultarPopupposition();
                break;

            case "ComunicacionesInternas":

                if (tipoCom == 1) {
                    $.ajax({
                        data: { anio:anio,documento: documento, tipoComTexto: tipoComTexto },
                        url: urlBase + '/ReportesAplicacion/IndicadorComunicacionesInternasPersonas',
                        type: 'POST'
                    });
                    location.reload(true);
                    OcultarPopupposition();
                }
                else if (tipoCom == 2)
                {
                    
                    $.ajax({
                        data: { anio: anio, cargoTexto: cargoTexto, tipoComTexto: tipoComTexto },
                        url: urlBase + '/ReportesAplicacion/IndicadorComunicacionesInternasCargo',
                        type: 'POST'
                    });
                    location.reload(true);
                    OcultarPopupposition();
                    
                }
                else
                {
                    $.ajax({
                        data: { anio: anio, grupoTexto: grupoTexto, tipoComTexto: tipoComTexto },
                        url: urlBase + '/ReportesAplicacion/IndicadorComunicacionesInternasGrupos',
                        type: 'POST'
                    });
                    location.reload(true);
                    OcultarPopupposition();
                }
                break;
            case "ComunicacionesAPP":

                if (tipoComAPP == 1) {
                    $.ajax({
                        data: { anio: anio, documento: documento, tipoComTextoAPP: tipoComTextoAPP },
                        url: urlBase + '/ReportesAplicacion/IndicadorComunicacionesInternasPersonasAPP',
                        type: 'POST'
                    });
                    location.reload(true);
                    OcultarPopupposition();
                }
                else {
                    $.ajax({
                        data: { anio: anio, cargoTextoAPP: cargoTextoAPP, tipoComTextoAPP: tipoComTextoAPP },
                        url: urlBase + '/ReportesAplicacion/IndicadorComunicacionesInternasCargoAPP',
                        type: 'POST'
                    });
                    location.reload(true);
                    OcultarPopupposition();
                }
                break;

            case "PeligroYRiesgos":
               
                if (procesoPel == null)
                {
                    procesoPel = "";
                }
                if (zonaLugar == null) {
                    zonaLugar = "";
                }
                if (actividad == null)
                {
                    actividad = "";
                }
                if (sedePeligro != "" && metodologia != "" && procesoPel != "" && zonaLugar != "" && actividad !="" && tipoPeligro != "") {
                
                    $.ajax({
                        data: {
                            sedePeligro: sedePeligro, sedePelTexto: sedePelTexto, metodologia: metodologia, metodologiaTexto: metodologiaTexto,
                            procesoPel: procesoPel, procesoPelTexto: procesoPelTexto, zonaLugarTexto: zonaLugarTexto, actividadTexto: actividadTexto,
                            tipoPeligro: tipoPeligro, tipoPeligroTexto: tipoPeligroTexto

                        },
                        url: urlBase + '/ReportesAplicacion/identificacionPeligrosFiltroSedeMetodologiaProcesoLugarActividadValoracion',
                        type: 'POST'
                    });
                    location.reload(true);
                    OcultarPopupposition();
                }
                else if (sedePeligro != "" && metodologia != "" && procesoPel != "" && zonaLugar != "" && tipoPeligro != "") {

                    $.ajax({
                        data: {
                            sedePeligro: sedePeligro, sedePelTexto: sedePelTexto, metodologia: metodologia, metodologiaTexto: metodologiaTexto,
                            procesoPel: procesoPel, procesoPelTexto: procesoPelTexto, zonaLugarTexto: zonaLugarTexto,
                            tipoPeligro: tipoPeligro, tipoPeligroTexto: tipoPeligroTexto
                        },
                        url: urlBase + '/ReportesAplicacion/identificacionPeligrosFiltroSedeMetodologiaProcesoLugarValoracion',
                        type: 'POST'
                    });
                    location.reload(true);
                    OcultarPopupposition();
                } else if (sedePeligro != "" && metodologia != "" && procesoPel !="" && tipoPeligro != "") {
                    $.ajax({
                        data: {
                            sedePeligro: sedePeligro, sedePelTexto: sedePelTexto, metodologia: metodologia, metodologiaTexto: metodologiaTexto,
                            procesoPel: procesoPel, procesoPelTexto: procesoPelTexto,
                            tipoPeligro: tipoPeligro, tipoPeligroTexto: tipoPeligroTexto

                        },
                        url: urlBase + '/ReportesAplicacion/identificacionPeligrosFiltroSedeMetodologiaProcesoValoracion',
                        type: 'POST'
                    });
                    location.reload(true);
                    OcultarPopupposition();

                } else if (sedePeligro != "" && metodologia != "" && tipoPeligro != "") {
                    $.ajax({
                        data: {
                            sedePeligro: sedePeligro, sedePelTexto: sedePelTexto, metodologia: metodologia, metodologiaTexto: metodologiaTexto,
                            tipoPeligro: tipoPeligro, tipoPeligroTexto: tipoPeligroTexto
                        },
                        url: urlBase + '/ReportesAplicacion/identificacionPeligrosFiltroSedeMetodologiaValoracion',
                        type: 'POST'
                    });
                    location.reload(true);
                    OcultarPopupposition();
                }
                break;
            case "PlanesDeAccion":
             
                switch (modulo) {

                    case "1":
                        $.ajax({
                            data: { anio: anio, modulo:modulo,moduloTexto:moduloTexto },
                            url: urlBase + '/ReportesAplicacion/IndicadorPlanesDeAccionEvaluacionSGSST',
                            type: 'POST'
                        });
                        location.reload(true);
                        OcultarPopupposition();

                        break;
                    case "2":
                        $.ajax({
                            data: { anio: anio, modulo: modulo, moduloTexto: moduloTexto },
                            url: urlBase + '/ReportesAplicacion/IndicadorPlanesDeAccionAccionesPrevCorrectivas',
                            type: 'POST'
                        });
                        location.reload(true);
                        OcultarPopupposition();
                        break;
                    case "3":
                        $.ajax({
                            data: { anio: anio, modulo: modulo, moduloTexto: moduloTexto },
                            url: urlBase + '/ReportesAplicacion/IndicadorPlanesDeAccionAuditorias',
                            type: 'POST'
                        });
                        location.reload(true);
                        OcultarPopupposition();
                        break;
                    case "4":
                        $.ajax({
                            data: { anio: anio, modulo: modulo, moduloTexto: moduloTexto },
                            url: urlBase + '/ReportesAplicacion/IndicadorPlanesDeAccionInspeccion',
                            type: 'POST'
                        });
                        location.reload();
                        OcultarPopupposition(true);
                        break;
                    case "5":
                        $.ajax({
                            data: { anio: anio, modulo: modulo, moduloTexto: moduloTexto },
                            url: urlBase + '/ReportesAplicacion/IndicadorPlanesDeAccionActosInseguros',
                            type: 'POST'
                        });
                        location.reload(true);
                        OcultarPopupposition();
                        break;
                    case "6":
                        $.ajax({
                            data: { anio: anio, modulo: modulo, moduloTexto: moduloTexto },
                            url: urlBase + '/ReportesAplicacion/IndicadorPlanesDeAccionCoppast',
                            type: 'POST'
                        });
                        location.reload();
                        OcultarPopupposition(true);
                        break;
                    case "7":
                        $.ajax({
                            data: { anio: anio, modulo: modulo, moduloTexto: moduloTexto },
                            url: urlBase + '/ReportesAplicacion/IndicadorPlanesDeAccionComiteConvivencia',
                            type: 'POST'
                        });
                        location.reload(true);
                        OcultarPopupposition();
                        break;
                    default:
                        $.ajax({
                            data: { anio: anio, modulo: modulo, moduloTexto: moduloTexto },
                            url: urlBase + '/ReportesAplicacion/IndicadorPlanesDeAccionRevisionSGSST',
                            type: 'POST'
                        });
                        location.reload(true);
                        OcultarPopupposition();
                 
                }
            
          
              
                break;

        }
    }
}


function seleccionarGraficasAunsentismo() {



    var anio = $("#anio").val();
    var idOrigen = $("#tipoOrigen").val();
    var IdEmpresaUsuaria = $("#IdEmpresaUsuaria").val();
    var idSede = $("#Sede").val();
    var IdDepartamento = $("#Departamento").val();
    var IdReporte = $("#IdReporte").val();

 
    if (anio == "")
    {
        
            swal({
                type: 'warning',
                title: 'Estimado Usuario:',
                text: 'Por favor seleccione el año',
                confirmButtonColor: '#7E8A97'
            });

            return false;
    }

  
    
    switch (IdReporte) {
       
        case "AC":
        
            $.ajax({
                data: { anio: anio, idorigen: idOrigen, idEmpresa: IdEmpresaUsuaria, idSede: idSede, idDepartamento: IdDepartamento },
                url: urlBase + '/ReportesAplicacion/ReporteDiasAunsentismoPorContigencia',
                type: 'POST',
            
            });
           
         location.reload(true);

            OcultarPopupposition();
            break;
        case "NC":
          
            $.ajax({
                data: { anio: anio, idorigen: idOrigen, idEmpresa: IdEmpresaUsuaria, idSede: idSede, idDepartamento: IdDepartamento },

                url: urlBase + '/ReportesAplicacion/ReporteNumeroDeEventosPorContigencia',
                type: 'POST'
            });
        location.reload(true);

            OcultarPopupposition();
            break;
        case "ADP":
        
            $.ajax({
                data: { anio: anio, idorigen: idOrigen, idEmpresa: IdEmpresaUsuaria, idSede: idSede, idDepartamento: IdDepartamento },

                url: urlBase + '/ReportesAplicacion/ReporteDiasAusentismoPorDepartamentos',
                type: 'POST'
            });
           location.reload(true);

            OcultarPopupposition();
            break;
        case "DCIE":
            
       
            $.ajax({
                data: { anio: anio, idorigen: idOrigen, idEmpresa: IdEmpresaUsuaria, idSede: idSede, idDepartamento: IdDepartamento },

                url: urlBase + '/ReportesAplicacion/ReporteDiasAusentismoPorEnfermedadesCIE10',
                type: 'POST'
            });
          location.reload(true);
   
      
            OcultarPopupposition();
            break;

        case "NCIE":
         
            $.ajax({
                data: { anio: anio, idorigen: idOrigen, idEmpresa: IdEmpresaUsuaria, idSede: idSede, idDepartamento: IdDepartamento },
                url: urlBase + '/ReportesAplicacion/ReporteEventosPorEnfermedadesCIE10',
                type: 'POST'
            });
            location.reload(true);
           
            OcultarPopupposition();

            break;

        case "DP":
            $("IDReportesAus").removeAttr("hidden");
            $.ajax({
                data: { anio: anio, idorigen: idOrigen, idEmpresa: IdEmpresaUsuaria, idSede: idSede, idDepartamento: IdDepartamento },

                url: urlBase + '/ReportesAplicacion/ReporteDiasAusentismoPorProceso',
                type: 'POST'
            });
            location.reload(true);
       
            OcultarPopupposition();
            break;

        case "DS":
     
            $.ajax({
                data: { anio: anio, idorigen: idOrigen, idEmpresa: IdEmpresaUsuaria, idSede: idSede, idDepartamento: IdDepartamento },

                url: urlBase + '/ReportesAplicacion/ReporteDiasAusentismoPorSede',
                type: 'POST'
            });
            location.reload(true);
        
            OcultarPopupposition();
            break;

        case "PC":
         
            $.ajax({
                data: { anio: anio, idorigen: idOrigen, idEmpresa: IdEmpresaUsuaria, idSede: idSede, idDepartamento: IdDepartamento },

                url: urlBase + '/ReportesAplicacion/ReporteCostoPorContigencia',
                type: 'POST'
            });
            location.reload(true);
   
            OcultarPopupposition();
            break;
        case "AEPS":
         
            $.ajax({
                data: { anio: anio, idorigen: idOrigen, idEmpresa: IdEmpresaUsuaria, idSede: idSede, idDepartamento: IdDepartamento },
                url: urlBase + '/ReportesAplicacion/ReporteAusentismoPorEPS',
                type: 'POST'
            });
           location.reload(true);
           
            OcultarPopupposition();
            break;
        case "ASX":
            
            $.ajax({
                data: { anio: anio, idorigen: idOrigen, idEmpresa: IdEmpresaUsuaria, idSede: idSede, idDepartamento: IdDepartamento },
                url: urlBase + '/ReportesAplicacion/ReporteAusentismoPorSexo',
                type: 'POST'
            });
           location.reload(true);
        
            OcultarPopupposition();
            break;
        case "AV":
            $("IDReportesAus").removeAttr("hidden");
            $.ajax({
                data: { anio: anio, idorigen: idOrigen, idEmpresa: IdEmpresaUsuaria, idSede: idSede, idDepartamento: IdDepartamento },

                url: urlBase + '/ReportesAplicacion/ReporteAusentismoPorTipoVinculacion',
                type: 'POST'
            });
            location.reload(true);
            
            OcultarPopupposition();
            break;
        case "AO":
       
            $.ajax({
                data: { anio: anio, idorigen: idOrigen, idEmpresa: IdEmpresaUsuaria, idSede: idSede, idDepartamento: IdDepartamento },

                url: urlBase + '/ReportesAplicacion/ReporteAusentismoPorOcupacionCIUO',
                type: 'POST'
            });
            location.reload(true);
          

            OcultarPopupposition();
            break;
        case "AET":
       
            $.ajax({
                data: { anio: anio, idorigen: idOrigen, idEmpresa: IdEmpresaUsuaria, idSede: idSede, idDepartamento: IdDepartamento },

                url: urlBase + '/ReportesAplicacion/ReporteAusentismoPorGrupoEtareo',
                type: 'POST'
            });
           location.reload(true);
            OcultarPopupposition();
 
            break;

    }
}

function SeleccionarTipoComunicacion() {

    var tipo = $("#tipoCom").val();
    if(tipo==1)
    {
        $("#divAnio").show();
        $("#divDocumento").show();
        $("#divCargo").hide();
        $("#divGrupo").hide();
    } else if (tipo == 2) {
        $("#divAnio").show();
        $("#divCargo").show();
        $("#divDocumento").hide();
        $("#divGrupo").hide();
    } else if(tipo == 3)
    {
        $("#divDocumento").hide();
        $("#divCargo").hide();
        $("#divAnio").show();
        $("#divGrupo").show();
    }
}

function SeleccionarTipoComunicacionAPP() {

    var tipo = $("#tipoComAPP").val();
    if (tipo == 1) {
        $("#divAnio").show();
        $("#divDocumento").show();
        $("#divCargoAPP").hide();
        $("#divGrupo").hide();
    } else if (tipo == 2) {
        $("#divAnio").show();
        $("#divCargoAPP").show();
        $("#divDocumento").hide();
        $("#divGrupo").hide();
    }
}

function darFormatoSoloNumeros(idCampo) {
    $('#' + idCampo).on('input', function () {
        this.value = this.value.replace(/[^0-9]/g, '');
    });
}

function obtenerMetodologias() {
   
    $.ajax({
        url: urlBase + '/ReportesAplicacion/ObtenerMetodologia',//primero el modulo/controlador/metodo que esta en el controlador
        data: {// se colocan los parametros a enviar... en este caso no porque los voy es a obtener.
            PK_Sede: $idSede.val()
        },
        type: 'POST',
        success: function (result) {
            if (result) {
                $("#divMetodologia").show();
                $idMetodologia.find("option").remove();//Removemos las opciones anteriores 
                $idProceso.find("option").remove();
                $idZonaLugar.find("option").remove();
                $idActividad.find("option").remove();
                $idTipoPeligro.find("option").remove();
                $idActividad.append(new Option("-- Seleccionar --", ""));
                $idZonaLugar.append(new Option("-- Seleccionar --", ""));
                $idProceso.append(new Option("-- Seleccionar --", ""));
                $idTipoPeligro.append(new Option("-- Seleccionar --", ""));
                $idMetodologia.append(new Option("-- Seleccionar --", ""));// agregamos la opcion de seleccionar              
                $.each(result, function (ind, element) {
                   // $idMetodologia.append(new Option(, ));//agregamos las opciones consultadas
                    $idMetodologia.append(new Option(element.Descripcion_Metodologia, element.PK_Metodologia));//agregamos las opciones consultadas
              
                })
            }
        }
    });
}

function obtenerProceso() {

    $.ajax({
        url: urlBase + '/ReportesAplicacion/ObtenerProceso',//primero el modulo/controlador/metodo que esta en el controlador
        data: {// se colocan los parametros a enviar... en este caso no porque los voy es a obtener.
            PK_Sede: $idSede.val(),
            Pk_Metodologia: $idMetodologia.val(),
        },
        type: 'POST',
        success: function (result) {
            if (result) {
                $("#divProceso").show();
                $("#divTipoDePeligro").show();
                $idProceso.find("option").remove();
                $idZonaLugar.find("option").remove();
                $idActividad.find("option").remove();
                $idTipoPeligro.find("option").remove();
                $idProceso.append(new Option("-- Seleccionar --", ""));
                $idZonaLugar.append(new Option("-- Seleccionar --", ""));
             
                $idActividad.append(new Option("-- Seleccionar --", ""));
                $idTipoPeligro.append(new Option("-- Seleccionar --", ""));
                $.each(result, function (ind, element) {
                    // $idMetodologia.append(new Option(, ));//agregamos las opciones consultadas
                //    $idProceso.append(new Option(element.PK_Proceso, element.Descripcion_Proceso));//agregamos las opciones consultadas
                    $idProceso.append(new Option(element.Descripcion_Proceso, element.PK_Proceso));//agregamos las opciones consultadas

                })
            }
        }
    });
}

function obtenerZonaLugar() {

    $.ajax({
        url: urlBase + '/ReportesAplicacion/ObtenerZonaLugar',//primero el modulo/controlador/metodo que esta en el controlador
        data: {// se colocan los parametros a enviar... en este caso no porque los voy es a obtener.
            PK_Sede: $idSede.val(),
            Pk_Metodologia: $idMetodologia.val(),
            Pk_Proceso: $idProceso.val(),
        },
        type: 'POST',
        success: function (result) {
            if (result) {
                $("#divZona").show();

                $idZonaLugar.find("option").remove();
                $idActividad.find("option").remove();
                $idTipoPeligro.find("option").remove();
             
                $idZonaLugar.append(new Option("-- Seleccionar --", ""));// agregamos la opcion de seleccionar              
                $idActividad.append(new Option("-- Seleccionar --", ""));
                $idTipoPeligro.append(new Option("-- Seleccionar --", ""));

                $.each(result, function (ind, element) {
                    // $idMetodologia.append(new Option(, ));//agregamos las opciones consultadas
                    //    $idProceso.append(new Option(element.PK_Proceso, element.Descripcion_Proceso));//agregamos las opciones consultadas
                    $idZonaLugar.append(new Option(element.Descripcion_ZonaLugar, element.PK_ZonaLugar));//agregamos las opciones consultadas

                })
            }
        }
    });
}

function obtenerActividadMetodologia() {
    var zonaLugarTexto = $("#Fk_ZonaLugar option:selected").html();

    $.ajax({
        url: urlBase + '/ReportesAplicacion/ObtenerActividadMetodologia',//primero el modulo/controlador/metodo que esta en el controlador
        data: {// se colocan los parametros a enviar... en este caso no porque los voy es a obtener.
            PK_Sede: $idSede.val(),
            Pk_Metodologia: $idMetodologia.val(),
            Pk_Proceso: $idProceso.val(),
            Pk_ZonaLugar: zonaLugarTexto,
        },
        type: 'POST',
        success: function (result) {
            if (result) {
                $("#divActividad").show();
                $idActividad.find("option").remove();
                $idTipoPeligro.find("option").remove();

                $idActividad.append(new Option("-- Seleccionar --", ""));// agregamos la opcion de seleccionar              
                $idTipoPeligro.append(new Option("-- Seleccionar --", ""));
                $.each(result, function (ind, element) {
                    // $idMetodologia.append(new Option(, ));//agregamos las opciones consultadas
                    //    $idProceso.append(new Option(element.PK_Proceso, element.Descripcion_Proceso));//agregamos las opciones consultadas
                    $idActividad.append(new Option(element.Descripcion_Actividad, element.PK_Actividad));//agregamos las opciones consultadas

                })
            }
        }
    });
}

function obtenerTipoPeligro() {
    var proceso = $("#Fk_Proceso").val();
    var zonaLugar = $("#Fk_ZonaLugar").val();
    var actividad = $("#Fk_Actividad").val();

    var zonaLugarTexto = $("#Fk_ZonaLugar option:selected").html();
    var actividadTexto = $("#Fk_Actividad option:selected").html();
    if (proceso == null || proceso=="")
    {
        proceso = 0;
    }
   
    if (zonaLugar == null || zonaLugar=="")
    {
        zonaLugarTexto = "";
    }
    if (actividad == null || actividad=="")
    {
        actividadTexto = "";
    }
    $.ajax({
        url: urlBase + '/ReportesAplicacion/ObtenerTipoDePeligro',//primero el modulo/controlador/metodo que esta en el controlador
        data: {// se colocan los parametros a enviar... en este caso no porque los voy es a obtener.
            PK_Sede: $idSede.val(),
            Pk_Metodologia: $idMetodologia.val(),
            Pk_Proceso: proceso,
            Pk_ZonaLugar: zonaLugarTexto,
            Pk_Actividad: actividadTexto,
        },
        type: 'POST',
        success: function (result) {
            if (result) {
                $idTipoPeligro.find("option").remove();//Removemos las opciones anteriores 
                $idTipoPeligro.append(new Option("-- Seleccionar --", ""));// agregamos la opcion de seleccionar              
                $.each(result, function (ind, element) {
                    // $idMetodologia.append(new Option(, ));//agregamos las opciones consultadas
                    //    $idProceso.append(new Option(element.PK_Proceso, element.Descripcion_Proceso));//agregamos las opciones consultadas
                    $idTipoPeligro.append(new Option(element.Descripcion_Peligro, element.PK_Peligro));//agregamos las opciones consultadas

                })
            }
        }
    });

}

function CargarSemaforos(tipoIndicador) {
    switch (tipoIndicador) {
        case "Proceso":
            CargarSemaforoEstandaresMinimos();
            CargarSemaforoPlanTrabajoAnual();
            CargarSemaforoReporteSST();
            CargarSemaforoCondicionActosInseguros();
            break;

        case "Estructura":
            CargarSemaforoConvivenciaLaboral();
            CargarSemaforoCoppast();
            CargarSemaforoPerfilSocioDemografico();
            break;

        case "Resultado":
            //CargarSemaforoSeveridadAccidenteTrabajo();
            //CargarSemaforoAccidentesDeTrabajo();
            CargarSemaforoFrecuenciaAusentismo();
            CargarSemaforoTasaAccidentalidad();
            CargarSemaforoSeveridadAusentismo();
            CargarSemaforoLesionesIncapacitantes();
            CargarSemaforoCumplimientoRequisitosLegales();
            CargarSemaforoCapacitacionEntrenamiento();
            CargarSemaforoAnalisisVulnerabilidad();
            CargarSemaforoPeligroYRiesgos();
            CargarSemaforoPlanesDeAccion();
            break;
    }
}

function CargarSemaforoEstandaresMinimos(){
    $("#metaEstandaresMinimos").val('Meta: ' + 100);

    $.ajax({
        url: urlBase + '/ReportesAplicacion/ObtenerSemaforoEstandaresMinimos',//primero el modulo/controlador/metodo que esta en el controlador
        type: 'POST',
        success: function (result) {
            if (result.Mensaje == "OK") {
                $("#relojEstandaresMinimos").attr('data-value', result.Data);
                $("#metaEstandaresMinimos").val('Meta: 100');
                if (result.Data < 60) {
                    $("#estadoEstandaresMinimos").css('background-color', 'red');
                    $("#semaforoEstandaresMinimos").attr('src', '/Content/Images/Semaforo/semaforoRojo.png');
                }
                else if (result.Data <= 85) {
                    $("#estadoEstandaresMinimos").css('background-color', 'yellow');
                    $("#semaforoEstandaresMinimos").attr('src', '/Content/Images/Semaforo/semaforoAmarillo.png');
                }
                else {
                    $("#estadoEstandaresMinimos").css('background-color', 'green');
                    $("#semaforoEstandaresMinimos").attr('src', '/Content/Images/Semaforo/semaforoVerde.png');
                }
            }
            else {
                $("#relojEstandaresMinimos").attr('data-value', '0');
                $("#estadoEstandaresMinimos").css('background-color', 'gray');
                $("#semaforoEstandaresMinimos").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
            }
        },
        error: function (result) {
            $("#relojEstandaresMinimos").attr('data-value', '0');
            $("#estadoEstandaresMinimos").css('background-color', 'gray');
            $("#semaforoEstandaresMinimos").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
        }
    });

}

function CargarSemaforoPlanTrabajoAnual() {
    $.ajax({
        url: urlBase + '/ReportesAplicacion/ObtenerSemaforoPlanTrabajoAnual',//primero el modulo/controlador/metodo que esta en el controlador
        type: 'POST',
        success: function (result) {
            if (result.Mensaje == "OK" || result.Mensaje == "METAOK") {
                $("#metaPlanTrabajoAnual").val('Meta: ' + result.Data.ValorMeta);
                $("#rojoPlanTrabajoAnual").val('Si el resultado es menor o igual a ' + result.Data.ValorRojo + '%');
                $("#amarilloPlanTrabajoAnual").val('Si el resultado es mayor a ' + result.Data.ValorRojo + ' y menor o igual a ' + result.Data.ValorAmarillo + '%');
                $("#verdePlanTrabajoAnual").val('Si el resultado es mayor a ' + result.Data.ValorAmarillo + '%');
                var rojo = result.Data.ValorRojo;
                var amarillo = result.Data.ValorAmarillo;
                var verde = result.Data.ValorVerde;
                var div = (verde / 5.0).toFixed(1);
                var div1 = (div * 2).toFixed(1);
                var div2 = (div * 3).toFixed(1);
                var div3 = (div * 4).toFixed(1);
                var div4 = (div * 5).toFixed(1);
                $("#relojPlanTrabajoAnual").attr('data-highlights', '[{"from": 0, "to": ' + rojo + ', "color": "rgba(255,40,14,0.9)"},{"from": ' + rojo + ', "to": ' + amarillo + ', "color": "rgba(255, 201, 0, 0.9)"},{"from": ' + amarillo + ', "to": ' + verde + ', "color": "rgba(73,255,0,0.9)"}]');
                $("#relojPlanTrabajoAnual").attr('data-max-value', verde);
                $("#relojPlanTrabajoAnual").attr('data-major-ticks', '0,' + div + ',' + div1 + ',' + div2 + ' ,' + div3 + ',' + div4 + '');
                $("#relojPlanTrabajoAnual").attr('data-value', result.Data.ValorResultado);



            }
            if (result.Mensaje == "OK") {
              
                if (result.Data.ValorResultado <= result.Data.ValorRojo) {
                    $("#estadoPlanTrabajoAnual").css('background-color', 'red');
                    $("#semaforoPlanTrabajoAnual").attr('src', '/Content/Images/Semaforo/semaforoRojo.png');
                }
                else if (result.Data.ValorResultado <= result.Data.ValorAmarillo) {
                    $("#estadoPlanTrabajoAnual").css('background-color', 'yellow');
                    $("#semaforoPlanTrabajoAnual").attr('src', '/Content/Images/Semaforo/semaforoAmarillo.png');
                }
                else {
                    $("#estadoPlanTrabajoAnual").css('background-color', 'green');
                    $("#semaforoPlanTrabajoAnual").attr('src', '/Content/Images/Semaforo/semaforoVerde.png');
                }
            }
            else {
                $("#relojPlanTrabajoAnual").attr('data-value', '0');
                $("#estadoPlanTrabajoAnual").css('background-color', 'gray');
                $("#semaforoPlanTrabajoAnual").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
            }
        },
        error: function (result) {
            $("#relojPlanTrabajoAnual").attr('data-value', '0');
            $("#estadoPlanTrabajoAnual").css('background-color', 'gray');
            $("#semaforoPlanTrabajoAnual").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
        }
    });
}

function CargarSemaforoReporteSST() {
    $.ajax({
        url: urlBase + '/ReportesAplicacion/ObtenerSemaforoReporteSST',//primero el modulo/controlador/metodo que esta en el controlador
        type: 'POST',
        success: function (result) {
            if (result.Mensaje == "OK" || result.Mensaje == "METAOK") {
                $("#metaReporteSST").val('Meta: ' + result.Data.ValorMeta);
                $("#rojoReporteSST").val('Si el resultado es menor o igual a ' + result.Data.ValorRojo + '%');
                $("#amarilloReporteSST").val('Si el resultado es mayor a ' + result.Data.ValorRojo + ' y menor o igual a ' + result.Data.ValorAmarillo + '%');
                $("#verdeReporteSST").val('Si el resultado es mayor a ' + result.Data.ValorAmarillo + '%');
                var rojo = result.Data.ValorRojo;
                var amarillo = result.Data.ValorAmarillo;
                var verde = result.Data.ValorVerde;
                var div = (verde / 5.0).toFixed(1);
                var div1 = (div * 2).toFixed(1);
                var div2 = (div * 3).toFixed(1);
                var div3 = (div * 4).toFixed(1);
                var div4 = (div * 5).toFixed(1);
                $("#relojReporteSST").attr('data-highlights', '[{"from": 0, "to": ' + rojo + ', "color": "rgba(255,40,14,0.9)"},{"from": ' + rojo + ', "to": ' + amarillo + ', "color": "rgba(255, 201, 0, 0.9)"},{"from": ' + amarillo + ', "to": ' + verde + ', "color": "rgba(73,255,0,0.9)"}]');
                $("#relojReporteSST").attr('data-max-value', verde);
                $("#relojReporteSST").attr('data-major-ticks', '0,' + div + ',' + div1 + ',' + div2 + ' ,' + div3 + ',' + div4 + '');
                $("#relojReporteSST").attr('data-value', result.Data.ValorResultado);

            }
            if (result.Mensaje == "OK") {
              
                if (result.Data.ValorResultado <= result.Data.ValorRojo) {
                    $("#estadoReporteSST").css('background-color', 'red');
                    $("#semaforoReporteSST").attr('src', '/Content/Images/Semaforo/semaforoRojo.png');
                }
                else if (result.Data.ValorResultado <= result.Data.ValorAmarillo) {
                    $("#estadoReporteSST").css('background-color', 'yellow');
                    $("#semaforoReporteSST").attr('src', '/Content/Images/Semaforo/semaforoAmarillo.png');
                }
                else {
                    $("#estadoReporteSST").css('background-color', 'green');
                    $("#semaforoReporteSST").attr('src', '/Content/Images/Semaforo/semaforoVerde.png');
                }
            }
            else {
                $("#relojReporteSST").attr('data-value', '0');
                $("#estadoReporteSST").css('background-color', 'gray');
                $("#semaforoReporteSST").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
            }
        },
        error: function (result) {
            $("#relojReporteSST").attr('data-value', '0');
            $("#estadoReporteSST").css('background-color', 'gray');
            $("#semaforoReporteSST").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
        }
    });
}

function CargarSemaforoCondicionActosInseguros() {
    $.ajax({
        url: urlBase + '/ReportesAplicacion/ObtenerSemaforoCondicionActosInseguros',//primero el modulo/controlador/metodo que esta en el controlador
        type: 'POST',
        success: function (result) {
            if (result.Mensaje == "OK" || result.Mensaje == "METAOK") {
                $("#metaCondicionActosInseguros").val('Meta: ' + result.Data.ValorMeta);
                $("#rojoCondicionActosInseguros").val('Si el resultado es menor o igual a ' + result.Data.ValorRojo + '%');
                $("#amarilloCondicionActosInseguros").val('Si el resultado es mayor a ' + result.Data.ValorRojo + ' y menor o igual a ' + result.Data.ValorAmarillo + '%');
                $("#verdeCondicionActosInseguros").val('Si el resultado es mayor a ' + result.Data.ValorAmarillo + '%');
                var rojo = result.Data.ValorRojo;
                var amarillo = result.Data.ValorAmarillo;
                var verde = result.Data.ValorVerde;
              
                var div = (verde / 5.0).toFixed(1);
                var div1 = (div * 2).toFixed(1);
                var div2 = (div * 3).toFixed(1);
                var div3 = (div * 4).toFixed(1);
                var div4 = (div * 5).toFixed(1);

                $("#relojCondicionActosInseguros").attr('data-highlights', '[{"from": 0, "to": ' + rojo + ', "color": "rgba(255,40,14,0.9)"},{"from": ' + rojo + ', "to": ' + amarillo + ', "color": "rgba(255, 201, 0, 0.9)"},{"from": ' + amarillo + ', "to": ' + verde + ', "color": "rgba(73,255,0,0.9)"}]');
                $("#relojCondicionActosInseguros").attr('data-max-value', verde);
                $("#relojCondicionActosInseguros").attr('data-major-ticks', '0,' + div + ',' + div1+ ',' + div2 + ' ,' + div3 + ',' + div4 + '');
                $("#relojCondicionActosInseguros").attr('data-value', result.Data.ValorResultado);

            }
            if (result.Mensaje == "OK") {
               
                if (result.Data.ValorResultado <= result.Data.ValorRojo) {
                    $("#estadoCondicionActosInseguros").css('background-color', 'red');
                    $("#semaforoCondicionActosInseguros").attr('src', '/Content/Images/Semaforo/semaforoRojo.png');
                }
                else if (result.Data.ValorResultado <= result.Data.ValorAmarillo) {
                    $("#estadoCondicionActosInseguros").css('background-color', 'yellow');
                    $("#semaforoCondicionActosInseguros").attr('src', '/Content/Images/Semaforo/semaforoAmarillo.png');
                }
                else {
                    $("#estadoCondicionActosInseguros").css('background-color', 'green');
                    $("#semaforoCondicionActosInseguros").attr('src', '/Content/Images/Semaforo/semaforoVerde.png');
                }
            }
            else {
                $("#relojCondicionActosInseguros").attr('data-value', '0');
                $("#estadoCondicionActosInseguros").css('background-color', 'gray');
                $("#semaforoCondicionActosInseguros").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
            }
        },
        error: function (result) {
            $("#relojCondicionActosInseguros").attr('data-value', '0');
            $("#estadoCondicionActosInseguros").css('background-color', 'gray');
            $("#semaforoCondicionActosInseguros").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
        }
    });
}

function CargarSemaforoSeveridadAccidenteTrabajo() {
    $.ajax({
        url: urlBase + '/ReportesAplicacion/ObtenerSemaforoSeveridadAccidenteTrabajo',//primero el modulo/controlador/metodo que esta en el controlador
        type: 'POST',
        success: function (result) {
            if (result.Mensaje == "OK" || result.Mensaje == "METAOK") {
                $("#metaSeveridadAccidenteTrabajo").val('Meta: ' + result.Data.ValorMeta);
                $("#rojoSeveridadAccidenteTrabajo").val('Si el resultado es mayor a ' + result.Data.ValorAmarillo + '');
                $("#amarilloSeveridadAccidenteTrabajo").val('Si el resultado es mayor a ' + result.Data.ValorVerde + ' y menor o igual a ' + result.Data.ValorAmarillo + '');
                $("#verdeSeveridadAccidenteTrabajo").val('Si el resultado es menor o igual a ' + result.Data.ValorVerde + '');
            }
            if (result.Mensaje == "OK") {
                $("#relojSeveridadAccidenteTrabajo").attr('data-value', result.Data.ValorResultado);
                if (result.Data.ValorResultado <= result.Data.ValorVerde) {
                    $("#estadoSeveridadAccidenteTrabajo").css('background-color', 'green');
                    $("#semaforoSeveridadAccidenteTrabajo").attr('src', '/Content/Images/Semaforo/semaforoVerde.png');
                }
                else if (result.Data.ValorResultado <= result.Data.ValorAmarillo) {
                    $("#estadoSeveridadAccidenteTrabajo").css('background-color', 'yellow');
                    $("#semaforoSeveridadAccidenteTrabajo").attr('src', '/Content/Images/Semaforo/semaforoAmarillo.png');
                }
                else {
                    $("#estadoSeveridadAccidenteTrabajo").css('background-color', 'red');
                    $("#semaforoSeveridadAccidenteTrabajo").attr('src', '/Content/Images/Semaforo/semaforoRojo.png');
                }
            }
            else {
                $("#relojSeveridadAccidenteTrabajo").attr('data-value', '0');
                $("#estadoSeveridadAccidenteTrabajo").css('background-color', 'gray');
                $("#semaforoSeveridadAccidenteTrabajo").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
            }
        },
        error: function (result) {
            $("#relojSeveridadAccidenteTrabajo").attr('data-value', '0');
            $("#estadoSeveridadAccidenteTrabajo").css('background-color', 'gray');
            $("#semaforoSeveridadAccidenteTrabajo").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
        }
    });
}

function CargarSemaforoAccidentesDeTrabajo() {
    $.ajax({
        url: urlBase + '/ReportesAplicacion/ObtenerSemaforoAccidentesDeTrabajo',//primero el modulo/controlador/metodo que esta en el controlador
        type: 'POST',
        success: function (result) {
            if (result.Mensaje == "OK" || result.Mensaje == "METAOK") {
                $("#metaAccidentesDeTrabajo").val('Meta: ' + result.Data.ValorMeta);
                $("#rojoAccidentesDeTrabajo").val('Si el resultado es mayor a ' + result.Data.ValorAmarillo + '');
                $("#amarilloAccidentesDeTrabajo").val('Si el resultado es mayor a ' + result.Data.ValorVerde + ' y menor o igual a ' + result.Data.ValorAmarillo + '');
                $("#verdeAccidentesDeTrabajo").val('Si el resultado es menor o igual a ' + result.Data.ValorVerde + '');
            }
            if (result.Mensaje == "OK") {
                $("#relojAccidentesDeTrabajo").attr('data-value', result.Data.ValorResultado);
                if (result.Data.ValorResultado <= result.Data.ValorVerde) {
                    $("#estadoAccidentesDeTrabajo").css('background-color', 'green');
                    $("#semaforoAccidentesDeTrabajo").attr('src', '/Content/Images/Semaforo/semaforoVerde.png');
                }
                else if (result.Data.ValorResultado <= result.Data.ValorAmarillo) {
                    $("#estadoAccidentesDeTrabajo").css('background-color', 'yellow');
                    $("#semaforoAccidentesDeTrabajo").attr('src', '/Content/Images/Semaforo/semaforoAmarillo.png');
                }
                else {
                    $("#estadoAccidentesDeTrabajo").css('background-color', 'red');
                    $("#semaforoAccidentesDeTrabajo").attr('src', '/Content/Images/Semaforo/semaforoRojo.png');
                }
            }
            else {
                $("#relojAccidentesDeTrabajo").attr('data-value', '0');
                $("#estadoAccidentesDeTrabajo").css('background-color', 'gray');
                $("#semaforoAccidentesDeTrabajo").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
            }
        },
        error: function (result) {
            $("#relojAccidentesDeTrabajo").attr('data-value', '0');
            $("#estadoAccidentesDeTrabajo").css('background-color', 'gray');
            $("#semaforoAccidentesDeTrabajo").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
        }
    });
}

function CargarSemaforoFrecuenciaAusentismo() {
    $.ajax({
        url: urlBase + '/ReportesAplicacion/ObtenerSemaforoFrecuenciaAusentismo',//primero el modulo/controlador/metodo que esta en el controlador
        type: 'POST',
        success: function (result) {
            if (result.Mensaje == "OK" || result.Mensaje == "METAOK") {
                $("#metaFrecuenciaAusentismo").val('Meta: ' + result.Data.ValorMeta);
              //  $("#rojoFrecuenciaAusentismo").val('Si el resultado es menor o igual a ' + result.Data.ValorRojo + ' y mayor  a ' + result.Data.ValorAmarillo + '');
                $("#rojoFrecuenciaAusentismo").val('Si el resultado es  mayor o igual a ' + result.Data.ValorAmarillo + ' y menor a ' + result.Data.ValorRojo + '');
                $("#amarilloFrecuenciaAusentismo").val('Si el resultado es mayor o igual a ' + result.Data.ValorVerde + ' y menor a ' + result.Data.ValorAmarillo + '');
                $("#verdeFrecuenciaAusentismo").val('Si el resultado es menor ' + result.Data.ValorVerde + '');

                var rojo = result.Data.ValorRojo;
                var amarillo = result.Data.ValorAmarillo;
                var verde = result.Data.ValorVerde;
               
                var div = (rojo / 5.0).toFixed(1);
                var div1 = (div * 2).toFixed(1);
                var div2 = (div * 3).toFixed(1);
                var div3 = (div * 4).toFixed(1);
                var div4 = (div * 5).toFixed(1);
                $("#relojFrecuenciaAusentismo").attr('data-highlights', '[{"from": 0, "to": ' + verde + ', "color": "rgba(73,255,0,0.9)"},{"from": ' + verde + ', "to": ' + amarillo + ', "color": "rgba(255, 201, 0, 0.9)"},{"from": ' + amarillo + ', "to": ' + rojo + ', "color": "rgba(255,40,14,0.9)"}]');

                $("#relojFrecuenciaAusentismo").attr('data-max-value', rojo);
                $("#relojFrecuenciaAusentismo").attr('data-major-ticks', '0,' + div + ',' + div1+ ',' + div2 + ' ,' + div3 + ',' + div4 + '');
                $("#relojFrecuenciaAusentismo").attr('data-value', result.Data.ValorResultado);
            }
            if (result.Mensaje == "OK") {

              
                if (result.Data.ValorResultado <= result.Data.ValorVerde) {

                    $("#estadoFrecuenciaAusentismo").css('background-color', 'green');
                    $("#semaforoFrecuenciaAusentismo").attr('src', '/Content/Images/Semaforo/semaforoVerde.png');
                }
                else if (result.Data.ValorResultado <= result.Data.ValorAmarillo) {
                    $("#estadoFrecuenciaAusentismo").css('background-color', 'yellow');
                    $("#semaforoFrecuenciaAusentismo").attr('src', '/Content/Images/Semaforo/semaforoAmarillo.png');
                }
                else {
                     $("#estadoFrecuenciaAusentismo").css('background-color', 'red');
                     $("#semaforoFrecuenciaAusentismo").attr('src', '/Content/Images/Semaforo/semaforoRojo.png');
                }

            }
            else {
                $("#relojFrecuenciaAusentismo").attr('data-value', '0');
                $("#estadoFrecuenciaAusentismo").css('background-color', 'gray');
                $("#semaforoFrecuenciaAusentismo").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
            }
        },
        error: function (result) {
            $("#relojFrecuenciaAusentismo").attr('data-value', '0');
            $("#estadoFrecuenciaAusentismo").css('background-color', 'gray');
            $("#semaforoFrecuenciaAusentismo").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
        }
    });
}

function CargarSemaforoTasaAccidentalidad() {
    $.ajax({
        url: urlBase + '/ReportesAplicacion/ObtenerSemaforoTasaAccidentalidad',//primero el modulo/controlador/metodo que esta en el controlador
        type: 'POST',
        success: function (result) {
            if (result.Mensaje == "OK" || result.Mensaje == "METAOK") {
                $("#metaTasaAccidentalidad").val('Meta: ' + result.Data.ValorMeta);
                $("#rojoTasaAccidentalidad").val('Si el resultado es mayor a ' + result.Data.ValorAmarillo + '');
                $("#amarilloTasaAccidentalidad").val('Si el resultado es mayor a ' + result.Data.ValorVerde + ' y menor o igual a ' + result.Data.ValorAmarillo + '');
                $("#verdeTasaAccidentalidad").val('Si el resultado es menor o igual a ' + result.Data.ValorVerde + '');

                var rojo = result.Data.ValorRojo;
                var amarillo = result.Data.ValorAmarillo;
                var verde = result.Data.ValorVerde;

                var div = (rojo / 5.0).toFixed(1);
                var div1 = (div * 2).toFixed(1);
                var div2 = (div * 3).toFixed(1);
                var div3 = (div * 4).toFixed(1);
                var div4 = (div * 5).toFixed(1);
                $("#relojTasaAccidentalidad").attr('data-highlights', '[{"from": 0, "to": ' + verde + ', "color": "rgba(73,255,0,0.9)"},{"from": ' + verde + ', "to": ' + amarillo + ', "color": "rgba(255, 201, 0, 0.9)"},{"from": ' + amarillo + ', "to": ' + rojo + ', "color": "rgba(255,40,14,0.9)"}]');

                $("#relojTasaAccidentalidad").attr('data-max-value', rojo);
                $("#relojTasaAccidentalidad").attr('data-major-ticks', '0,' + div + ',' + div1 + ',' + div2 + ' ,' + div3 + ',' + div4 + '');
                $("#relojTasaAccidentalidad").attr('data-value', result.Data.ValorResultado);

            }
            if (result.Mensaje == "OK") {
                if (result.Data.ValorResultado <= result.Data.ValorVerde) {

                    $("#estadoTasaAccidentalidad").css('background-color', 'green');
                    $("#semaforoTasaAccidentalidad").attr('src', '/Content/Images/Semaforo/semaforoVerde.png');
                }
                else if (result.Data.ValorResultado <= result.Data.ValorAmarillo) {
                    $("#estadoTasaAccidentalidad").css('background-color', 'yellow');
                    $("#semaforoTasaAccidentalidad").attr('src', '/Content/Images/Semaforo/semaforoAmarillo.png');
                }
                else {
                    $("#estadoTasaAccidentalidad").css('background-color', 'red');
                    $("#semaforoTasaAccidentalidad").attr('src', '/Content/Images/Semaforo/semaforoRojo.png');
                }
            }
            else {
                $("#relojTasaAccidentalidad").attr('data-value', '0');
                $("#estadoTasaAccidentalidad").css('background-color', 'gray');
                $("#semaforoTasaAccidentalidad").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
            }
        },
        error: function (result) {
            $("#relojTasaAccidentalidad").attr('data-value', '0');
            $("#estadoTasaAccidentalidad").css('background-color', 'gray');
            $("#semaforoTasaAccidentalidad").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
        }
    });
}

function CargarSemaforoSeveridadAusentismo() {
    $.ajax({
        url: urlBase + '/ReportesAplicacion/ObtenerSemaforoSeveridadAusentismo',//primero el modulo/controlador/metodo que esta en el controlador
        type: 'POST',
        success: function (result) {
            if (result.Mensaje == "OK" || result.Mensaje == "METAOK") {
                $("#metaSeveridadAusentismo").val('Meta: ' + result.Data.ValorMeta);
                $("#rojoSeveridadAusentismo").val('Si el resultado es mayor a ' + result.Data.ValorAmarillo + '');
                $("#amarilloSeveridadAusentismo").val('Si el resultado es mayor a ' + result.Data.ValorVerde + ' y menor o igual a ' + result.Data.ValorAmarillo + '');
                $("#verdeSeveridadAusentismo").val('Si el resultado es menor o igual a ' + result.Data.ValorVerde + '');
            }
            if (result.Mensaje == "OK") {
                $("#relojSeveridadAusentismo").attr('data-value', result.Data.ValorResultado);
                if (result.Data.ValorResultado <= result.Data.ValorVerde) {
                    $("#estadoSeveridadAusentismo").css('background-color', 'green');
                    $("#semaforoSeveridadAusentismo").attr('src', '/Content/Images/Semaforo/semaforoVerde.png');
                }
                else if (result.Data.ValorResultado <= result.Data.ValorAmarillo) {
                    $("#estadoSeveridadAusentismo").css('background-color', 'yellow');
                    $("#semaforoSeveridadAusentismo").attr('src', '/Content/Images/Semaforo/semaforoAmarillo.png');
                }
                else {
                    $("#estadoSeveridadAusentismo").css('background-color', 'red');
                    $("#semaforoSeveridadAusentismo").attr('src', '/Content/Images/Semaforo/semaforoRojo.png');
                }
            }
            else {
                $("#relojSeveridadAusentismo").attr('data-value', '0');
                $("#estadoSeveridadAusentismo").css('background-color', 'gray');
                $("#semaforoSeveridadAusentismo").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
            }
        },
        error: function (result) {
            $("#relojSeveridadAusentismo").attr('data-value', '0');
            $("#estadoSeveridadAusentismo").css('background-color', 'gray');
            $("#semaforoSeveridadAusentismo").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
        }
    });
}

function CargarSemaforoLesionesIncapacitantes() {
    $.ajax({
        url: urlBase + '/ReportesAplicacion/ObtenerSemaforoLesionesIncapacitantes',//primero el modulo/controlador/metodo que esta en el controlador
        type: 'POST',
        success: function (result) {
            if (result.Mensaje == "OK" || result.Mensaje == "METAOK") {
                $("#metaLesionesIncapacitantes").val('Meta: ' + result.Data.ValorMeta);
                $("#rojoLesionesIncapacitantes").val('Si el resultado es mayor a ' + result.Data.ValorAmarillo + '');
                $("#amarilloLesionesIncapacitantes").val('Si el resultado es mayor a ' + result.Data.ValorVerde + ' y menor o igual a ' + result.Data.ValorAmarillo + '');
                $("#verdeLesionesIncapacitantes").val('Si el resultado es menor o igual a ' + result.Data.ValorVerde + '');
            }
            if (result.Mensaje == "OK") {
                $("#relojLesionesIncapacitantes").attr('data-value', result.Data.ValorResultado);
                if (result.Data.ValorResultado <= result.Data.ValorVerde) {
                    $("#estadoLesionesIncapacitantes").css('background-color', 'green');
                    $("#semaforoLesionesIncapacitantes").attr('src', '/Content/Images/Semaforo/semaforoVerde.png');
                }
                else if (result.Data.ValorResultado <= result.Data.ValorAmarillo) {
                    $("#estadoLesionesIncapacitantes").css('background-color', 'yellow');
                    $("#semaforoLesionesIncapacitantes").attr('src', '/Content/Images/Semaforo/semaforoAmarillo.png');
                }
                else {
                    $("#estadoLesionesIncapacitantes").css('background-color', 'red');
                    $("#semaforoLesionesIncapacitantes").attr('src', '/Content/Images/Semaforo/semaforoRojo.png');
                }
            }
            else {
                $("#relojLesionesIncapacitantes").attr('data-value', '0');
                $("#estadoLesionesIncapacitantes").css('background-color', 'gray');
                $("#semaforoLesionesIncapacitantes").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
            }
        },
        error: function (result) {
            $("#relojLesionesIncapacitantes").attr('data-value', '0');
            $("#estadoLesionesIncapacitantes").css('background-color', 'gray');
            $("#semaforoLesionesIncapacitantes").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
        }
    });
}

function CargarSemaforoCumplimientoRequisitosLegales() {
    $.ajax({
        url: urlBase + '/ReportesAplicacion/ObtenerSemaforoCumplimientoRequisitosLegales',//primero el modulo/controlador/metodo que esta en el controlador
        type: 'POST',
        success: function (result) {
            if (result.Mensaje == "OK" || result.Mensaje == "METAOK") {
                $("#metaCumplimientoRequisitosLegales").val('Meta: ' + result.Data.ValorMeta);
                $("#rojoCumplimientoRequisitosLegales").val('Si el resultado es menor o igual a ' + result.Data.ValorRojo + '%');
                $("#amarilloCumplimientoRequisitosLegales").val('Si el resultado es mayor a ' + result.Data.ValorRojo + '% y menor o igual a ' + result.Data.ValorAmarillo + '%');
                $("#verdeCumplimientoRequisitosLegales").val('Si el resultado es mayor a ' + result.Data.ValorAmarillo + '%');
                var rojo = result.Data.ValorRojo;
                var amarillo = result.Data.ValorAmarillo;
                var verde = result.Data.ValorVerde;
               
                var div = (verde / 5.0).toFixed(1);
                var div1 = (div * 2).toFixed(1);
                var div2 = (div * 3).toFixed(1);
                var div3 = (div * 4).toFixed(1);
                var div4 = (div * 5).toFixed(1);
                $("#relojCumplimientoRequisitosLegales").attr('data-highlights', '[{"from": 0, "to": ' + rojo + ', "color": "rgba(255,40,14,0.9)"},{"from": ' + rojo + ', "to": ' + amarillo + ', "color": "rgba(255, 201, 0, 0.9)"},{"from": ' + amarillo + ', "to": ' + verde + ', "color": "rgba(73,255,0,0.9)"}]');
                $("#relojCumplimientoRequisitosLegales").attr('data-max-value', verde);
                $("#relojCumplimientoRequisitosLegales").attr('data-major-ticks', '0,' + div + ',' + div1 + ',' + div2 + ' ,' + div3 + ',' + div4 + '');
                $("#relojCumplimientoRequisitosLegales").attr('data-value', result.Data.ValorResultado);

            }
            if (result.Mensaje == "OK") {


                if (result.Data.ValorResultado <= result.Data.ValorRojo) {
                    $("#estadoCumplimientoRequisitosLegales").css('background-color', 'red');
                    $("#semaforoCumplimientoRequisitosLegales").attr('src', '/Content/Images/Semaforo/semaforoRojo.png');
                }
                else if (result.Data.ValorResultado <= result.Data.ValorAmarillo) {
                    $("#estadoCumplimientoRequisitosLegales").css('background-color', 'yellow');
                    $("#semaforoCumplimientoRequisitosLegales").attr('src', '/Content/Images/Semaforo/semaforoAmarillo.png');
                }
                else {
                    $("#estadoCumplimientoRequisitosLegales").css('background-color', 'green');
                    $("#semaforoCumplimientoRequisitosLegales").attr('src', '/Content/Images/Semaforo/semaforoVerde.png');
                }
            }
            else {
                $("#relojCumplimientoRequisitosLegales").attr('data-value', '0');
                $("#estadoCumplimientoRequisitosLegales").css('background-color', 'gray');
                $("#semaforoCumplimientoRequisitosLegales").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
            }
        },
        error: function (result) {
            $("#relojCumplimientoRequisitosLegales").attr('data-value', '0');
            $("#estadoCumplimientoRequisitosLegales").css('background-color', 'gray');
            $("#semaforoCumplimientoRequisitosLegales").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
        }
    });
}

function CargarSemaforoCapacitacionEntrenamiento() {
    $.ajax({
        url: urlBase + '/ReportesAplicacion/ObtenerSemaforoCapacitacionEntrenamiento',//primero el modulo/controlador/metodo que esta en el controlador
        type: 'POST',
        success: function (result) {
            if (result.Mensaje == "OK" || result.Mensaje == "METAOK") {
                $("#metaCapacitacionEntrenamiento").val('Meta: ' + result.Data.ValorMeta);
                $("#rojoCapacitacionEntrenamiento").val('Si el resultado es menor o igual a ' + result.Data.ValorRojo + '%');
                $("#amarilloCapacitacionEntrenamiento").val('Si el resultado es mayor a ' + result.Data.ValorRojo + '% y menor o igual a ' + result.Data.ValorAmarillo + '%');
                $("#verdeCapacitacionEntrenamiento").val('Si el resultado es mayor a ' + result.Data.ValorAmarillo + '%');
			    var rojo = result.Data.ValorRojo;
                var amarillo = result.Data.ValorAmarillo;
                var verde = result.Data.ValorVerde;
                

                var div = (verde / 5.0).toFixed(1);
                var div1 = (div * 2).toFixed(1);;
                var div2 = (div * 3).toFixed(1);;
                var div3 = (div * 4).toFixed(1);;
                var div4 = (div * 5).toFixed(1);;
                $("#relojCapacitacionEntrenamiento").attr('data-highlights', '[{"from": 0, "to": ' + rojo + ', "color": "rgba(255,40,14,0.9)"},{"from": ' + rojo + ', "to": ' + amarillo + ', "color": "rgba(255, 201, 0, 0.9)"},{"from": ' + amarillo + ', "to": ' + verde + ', "color": "rgba(73,255,0,0.9)"}]');
                $("#relojCapacitacionEntrenamiento").attr('data-max-value', verde);
                $("#relojCapacitacionEntrenamiento").attr('data-major-ticks', '0,'+div+','+div1 +','+div2+' ,'+div3+','+div4+'');
                $("#relojCapacitacionEntrenamiento").attr('data-value', result.Data.ValorResultado);
            }
            if (result.Mensaje == "OK") {

            
               
                if (result.Data.ValorResultado <= result.Data.ValorRojo) {
                    $("#estadoCapacitacionEntrenamiento").css('background-color', 'red');
                    $("#semaforoCapacitacionEntrenamiento").attr('src', '/Content/Images/Semaforo/semaforoRojo.png');
                }
                else if (result.Data.ValorResultado <= result.Data.ValorAmarillo) {
                    $("#estadoCapacitacionEntrenamiento").css('background-color', 'yellow');
                    $("#semaforoCapacitacionEntrenamiento").attr('src', '/Content/Images/Semaforo/semaforoAmarillo.png');
                }
                else {
                    $("#estadoCapacitacionEntrenamiento").css('background-color', 'green');
                    $("#semaforoCapacitacionEntrenamiento").attr('src', '/Content/Images/Semaforo/semaforoVerde.png');
                }
            }
            else {
                $("#relojCapacitacionEntrenamiento").attr('data-value', '0');
                $("#estadoCapacitacionEntrenamiento").css('background-color', 'gray');
                $("#semaforoCapacitacionEntrenamiento").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
            }
        },
        error: function (result) {
            $("#relojCapacitacionEntrenamiento").attr('data-value', '0');
            $("#estadoCapacitacionEntrenamiento").css('background-color', 'gray');
            $("#semaforoCapacitacionEntrenamiento").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
        }
    });
}

function CargarSemaforoAnalisisVulnerabilidad() {
    $.ajax({
        url: urlBase + '/ReportesAplicacion/ObtenerSemaforoAnalisisVulnerabilidad',//primero el modulo/controlador/metodo que esta en el controlador
        type: 'POST',
        success: function (result) {
            if (result.Mensaje == "OK" || result.Mensaje == "METAOK") {
                $("#metaAnalisisVulnerabilidad").val('Meta: ' + result.Data.ValorMeta);
                $("#rojoAnalisisVulnerabilidad").val('Si el resultado es menor o igual a ' + result.Data.ValorRojo + '%');
                $("#amarilloAnalisisVulnerabilidad").val('Si el resultado es mayor a ' + result.Data.ValorRojo + ' y menor o igual a ' + result.Data.ValorAmarillo + '%');
                $("#verdeAnalisisVulnerabilidad").val('Si el resultado es mayor a ' + result.Data.ValorAmarillo + '%');
            }
            if (result.Mensaje == "OK") {
                $("#relojAnalisisVulnerabilidad").attr('data-value', result.Data.ValorResultado);
                if (result.Data.ValorResultado <= result.Data.ValorRojo) {
                    $("#estadoAnalisisVulnerabilidad").css('background-color', 'red');
                    $("#semaforoAnalisisVulnerabilidad").attr('src', '/Content/Images/Semaforo/semaforoRojo.png');
                }
                else if (result.Data.ValorResultado <= result.Data.ValorAmarillo) {
                    $("#estadoAnalisisVulnerabilidad").css('background-color', 'yellow');
                    $("#semaforoAnalisisVulnerabilidad").attr('src', '/Content/Images/Semaforo/semaforoAmarillo.png');
                }
                else {
                    $("#estadoAnalisisVulnerabilidad").css('background-color', 'green');
                    $("#semaforoAnalisisVulnerabilidad").attr('src', '/Content/Images/Semaforo/semaforoVerde.png');
                }
            }
            else {
                $("#relojAnalisisVulnerabilidad").attr('data-value', '0');
                $("#estadoAnalisisVulnerabilidad").css('background-color', 'gray');
                $("#semaforoAnalisisVulnerabilidad").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
            }
        },
        error: function (result) {
            $("#relojAnalisisVulnerabilidad").attr('data-value', '0');
            $("#estadoAnalisisVulnerabilidad").css('background-color', 'gray');
            $("#semaforoAnalisisVulnerabilidad").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
        }
    });
}

function CargarSemaforoPeligroYRiesgos() {
    $.ajax({
        url: urlBase + '/ReportesAplicacion/ObtenerSemaforoPeligroYRiesgos',//primero el modulo/controlador/metodo que esta en el controlador
        type: 'POST',
        success: function (result) {
            if (result.Mensaje == "OK" || result.Mensaje == "METAOK") {
                $("#metaPeligroYRiesgos").val('Meta: ' + result.Data.ValorMeta);
                $("#rojoPeligroYRiesgos").val('Si el resultado es menor o igual a ' + result.Data.ValorRojo + '%');
                $("#amarilloPeligroYRiesgos").val('Si el resultado es mayor a ' + result.Data.ValorRojo + ' y menor o igual a ' + result.Data.ValorAmarillo + '%');
                $("#verdePeligroYRiesgos").val('Si el resultado es mayor a ' + result.Data.ValorAmarillo + '%');
            }
            if (result.Mensaje == "OK") {
                $("#relojPeligroYRiesgos").attr('data-value', result.Data.ValorResultado);
                if (result.Data.ValorResultado <= result.Data.ValorRojo) {
                    $("#estadoPeligroYRiesgos").css('background-color', 'red');
                    $("#semaforoPeligroYRiesgos").attr('src', '/Content/Images/Semaforo/semaforoRojo.png');
                }
                else if (result.Data.ValorResultado <= result.Data.ValorAmarillo) {
                    $("#estadoPeligroYRiesgos").css('background-color', 'yellow');
                    $("#semaforoPeligroYRiesgos").attr('src', '/Content/Images/Semaforo/semaforoAmarillo.png');
                }
                else {
                    $("#estadoPeligroYRiesgos").css('background-color', 'green');
                    $("#semaforoPeligroYRiesgos").attr('src', '/Content/Images/Semaforo/semaforoVerde.png');
                }
            }
            else {
                $("#relojPeligroYRiesgos").attr('data-value', '0');
                $("#estadoPeligroYRiesgos").css('background-color', 'gray');
                $("#semaforoPeligroYRiesgos").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
            }
        },
        error: function (result) {
            $("#relojPeligroYRiesgos").attr('data-value', '0');
            $("#estadoPeligroYRiesgos").css('background-color', 'gray');
            $("#semaforoPeligroYRiesgos").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
        }
    });
}

function CargarSemaforoPlanesDeAccion() {
    $.ajax({
        url: urlBase + '/ReportesAplicacion/ObtenerSemaforoPlanesDeAccion',//primero el modulo/controlador/metodo que esta en el controlador
        type: 'POST',
        success: function (result) {
            if (result.Mensaje == "OK" || result.Mensaje == "METAOK") {
                $("#metaPlanesDeAccion").val('Meta: ' + result.Data.ValorMeta);
                $("#rojoPlanesDeAccion").val('Si el resultado es menor o igual a ' + result.Data.ValorRojo + '%');
                $("#amarilloPlanesDeAccion").val('Si el resultado es mayor a ' + result.Data.ValorRojo + ' y menor o igual a ' + result.Data.ValorAmarillo + '%');
                $("#verdePlanesDeAccion").val('Si el resultado es mayor a ' + result.Data.ValorAmarillo + '%');
            }
            if (result.Mensaje == "OK") {
                $("#relojPlanesDeAccion").attr('data-value', result.Data.ValorResultado);
                if (result.Data.ValorResultado <= result.Data.ValorRojo) {
                    $("#estadoPlanesDeAccion").css('background-color', 'red');
                    $("#semaforoPlanesDeAccion").attr('src', '/Content/Images/Semaforo/semaforoRojo.png');
                }
                else if (result.Data.ValorResultado <= result.Data.ValorAmarillo) {
                    $("#estadoPlanesDeAccion").css('background-color', 'yellow');
                    $("#semaforoPlanesDeAccion").attr('src', '/Content/Images/Semaforo/semaforoAmarillo.png');
                }
                else {
                    $("#estadoPlanesDeAccion").css('background-color', 'green');
                    $("#semaforoPlanesDeAccion").attr('src', '/Content/Images/Semaforo/semaforoVerde.png');
                }
            }
            else {
                $("#relojPlanesDeAccion").attr('data-value', '0');
                $("#estadoPlanesDeAccion").css('background-color', 'gray');
                $("#semaforoPlanesDeAccion").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
            }
        },
        error: function (result) {
            $("#relojPlanesDeAccion").attr('data-value', '0');
            $("#estadoPlanesDeAccion").css('background-color', 'gray');
            $("#semaforoPlanesDeAccion").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
        }
    });
}

// Nuevos funcionalidades
function CargarSemaforoConvivenciaLaboral() {
    $.ajax({
        url: urlBase + '/ReportesAplicacion/ObtenerSemaforoConvivenciaLaboral',//primero el modulo/controlador/metodo que esta en el controlador
        type: 'POST',
        success: function (result) {
            if (result.Mensaje == "OK" || result.Mensaje == "METAOK") {
                $("#metaConvivenciaLabor").val('Meta: ' + result.Data.ValorMeta);
                $("#rojoConvivenciaLaboral").val('Si el resultado es menor o igual a ' + result.Data.ValorRojo );
                $("#amarilloConvivenciaLaboral").val('Si el resultado es mayor a ' + result.Data.ValorRojo + ' y menor o igual a ' + result.Data.ValorAmarillo + '');
                $("#verdeConvivenciaLaboral").val('Si el resultado es mayor a ' + result.Data.ValorAmarillo + '');
                var rojo = result.Data.ValorRojo;
                var amarillo = result.Data.ValorAmarillo;
                var verde = result.Data.ValorVerde;
                var div = (verde / 5.0).toFixed(1);
                var div1 = (div * 2).toFixed(1);;
                var div2 = (div * 3).toFixed(1);;
                var div3 = (div * 4).toFixed(1);;
                var div4 = (div * 5).toFixed(1);;
                $("#relojConvivenciaLabor").attr('data-highlights', '[{"from": 0, "to": ' + rojo + ', "color": "rgba(255,40,14,0.9)"},{"from": ' + rojo + ', "to": ' + amarillo + ', "color": "rgba(255, 201, 0, 0.9)"},{"from": ' + amarillo + ', "to": ' + verde + ', "color": "rgba(73,255,0,0.9)"}]');
                $("#relojConvivenciaLabor").attr('data-max-value', verde);
                $("#relojConvivenciaLabor").attr('data-major-ticks', '0,' + div + ',' + div1 + ',' + div2 + ' ,' + div3 + ',' + div4 + '');
                $("#relojConvivenciaLabor").attr('data-value', result.Data.ValorResultado);
            }
            if (result.Mensaje == "OK") {



                if (result.Data.ValorResultado <= result.Data.ValorRojo) {
                 
                    $("#semaforoComiteConvivencia").attr('src', '/Content/Images/Semaforo/semaforoRojo.png');
                }
                else if (result.Data.ValorResultado <= result.Data.ValorAmarillo) {
                  
                    $("#semaforoComiteConvivencia").attr('src', '/Content/Images/Semaforo/semaforoAmarillo.png');
                }
                else {
                  
                    $("#semaforoComiteConvivencia").attr('src', '/Content/Images/Semaforo/semaforoVerde.png');
                }
            }
            else {
                $("#relojConvivenciaLabor").attr('data-value', '0');
               
                $("#semaforoComiteConvivencia").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
            }
        },
        error: function (result) {
            $("#relojConvivenciaLabor").attr('data-value', '0');
            $("#relojConvivenciaLabor").css('background-color', 'gray');
            $("#relojConvivenciaLabor").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
        }
    });
}

function CargarSemaforoCoppast() {
    $.ajax({
        url: urlBase + '/ReportesAplicacion/ObtenerSemaforoCoppast',//primero el modulo/controlador/metodo que esta en el controlador
        type: 'POST',
        success: function (result) {
            if (result.Mensaje == "OK" || result.Mensaje == "METAOK") {
                $("#metaComiteCoppast").val('Meta: ' + result.Data.ValorMeta);
                $("#rojoComiteCoppast").val('Si el resultado es menor o igual a ' + result.Data.ValorRojo );
                $("#amarilloComiteCoppast").val('Si el resultado es mayor a ' + result.Data.ValorRojo + ' y menor o igual a ' + result.Data.ValorAmarillo );
                $("#verdeComiteCoppast").val('Si el resultado es mayor a ' + result.Data.ValorAmarillo );
                var rojo = result.Data.ValorRojo;
                var amarillo = result.Data.ValorAmarillo;
                var verde = result.Data.ValorVerde;
                var div = (verde / 5.0).toFixed(1);
                var div1 = (div * 2).toFixed(1);;
                var div2 = (div * 3).toFixed(1);;
                var div3 = (div * 4).toFixed(1);;
                var div4 = (div * 5).toFixed(1);;
                $("#relojComiteCoppast").attr('data-highlights', '[{"from": 0, "to": ' + rojo + ', "color": "rgba(255,40,14,0.9)"},{"from": ' + rojo + ', "to": ' + amarillo + ', "color": "rgba(255, 201, 0, 0.9)"},{"from": ' + amarillo + ', "to": ' + verde + ', "color": "rgba(73,255,0,0.9)"}]');
                $("#relojComiteCoppast").attr('data-max-value', verde);
                $("#relojComiteCoppast").attr('data-major-ticks', '0,' + div + ',' + div1  + ',' + div2 + ' ,' + div3  + ',' + div4 + '');
                $("#relojComiteCoppast").attr('data-value', result.Data.ValorResultado);
            }
            if (result.Mensaje == "OK") {



                if (result.Data.ValorResultado <= result.Data.ValorRojo) {
                    $("#semaforoComiteCoppast").attr('src', '/Content/Images/Semaforo/semaforoRojo.png');
                }
                else if (result.Data.ValorResultado <= result.Data.ValorAmarillo) {
                    $("#semaforoComiteCoppast").attr('src', '/Content/Images/Semaforo/semaforoAmarillo.png');
                }
                else {
                    $("#semaforoComiteCoppast").attr('src', '/Content/Images/Semaforo/semaforoVerde.png');
                }
            }
            else {
                $("#relojComiteCoppast").attr('data-value', '0');
                $("#semaforoComiteCoppast").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
            }
        },
        error: function (result) {
            $("#relojComiteCoppast").attr('data-value', '0');
           
            $("#semaforoComiteCoppast").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
        }
    });
}

function CargarSemaforoPerfilSocioDemografico() {
    $.ajax({
        url: urlBase + '/ReportesAplicacion/ObtenerSemaforoPerfilSocio',//primero el modulo/controlador/metodo que esta en el controlador
        type: 'POST',
        success: function (result) {
            if (result.Mensaje == "OK" || result.Mensaje == "METAOK") {
                $("#metaPerfilSocioD").val('Meta: ' + result.Data.ValorMeta);
                $("#rojoPerfilSocioD").val('Si el resultado es menor o igual a ' + result.Data.ValorRojo);
                $("#amarilloPerfilSocioD").val('Si el resultado es mayor a ' + result.Data.ValorRojo + ' y menor o igual a ' + result.Data.ValorAmarillo);
                $("#verdePerfilSocioD").val('Si el resultado es mayor a ' + result.Data.ValorAmarillo);
                var rojo = result.Data.ValorRojo;
                var amarillo = result.Data.ValorAmarillo;
                var verde = result.Data.ValorVerde;
                var div = (verde / 5.0).toFixed(1);
                var div1 = (div * 2).toFixed(1);;
                var div2 = (div * 3).toFixed(1);;
                var div3 = (div * 4).toFixed(1);;
                var div4 = (div * 5).toFixed(1);;
                $("#relojPerfilSocioD").attr('data-highlights', '[{"from": 0, "to": ' + rojo + ', "color": "rgba(255,40,14,0.9)"},{"from": ' + rojo + ', "to": ' + amarillo + ', "color": "rgba(255, 201, 0, 0.9)"},{"from": ' + amarillo + ', "to": ' + verde + ', "color": "rgba(73,255,0,0.9)"}]');
                $("#relojPerfilSocioD").attr('data-max-value', verde);
                $("#relojPerfilSocioD").attr('data-major-ticks', '0,' + div + ',' + div1 + ',' + div2 + ' ,' + div3 + ',' + div4 + '');
                $("#relojPerfilSocioD").attr('data-value', result.Data.ValorResultado);
            }
            if (result.Mensaje == "OK") {



                if (result.Data.ValorResultado <= result.Data.ValorRojo) {
                    $("#semaforoPerfilSocioD").attr('src', '/Content/Images/Semaforo/semaforoRojo.png');
                }
                else if (result.Data.ValorResultado <= result.Data.ValorAmarillo) {
                    $("#semaforoPerfilSocioD").attr('src', '/Content/Images/Semaforo/semaforoAmarillo.png');
                }
                else {
                    $("#semaforoPerfilSocioD").attr('src', '/Content/Images/Semaforo/semaforoVerde.png');
                }
            }
            else {
                $("#relojPerfilSocioD").attr('data-value', '0');
                $("#semaforoPerfilSocioD").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
            }
        },
        error: function (result) {
            $("#relojPerfilSocioD").attr('data-value', '0');

            $("#semaforoPerfilSocioD").attr('src', '/Content/Images/Semaforo/semaforoApagado.png');
        }
    });
}
