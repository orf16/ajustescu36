$(function () {
    ConstruirDatePickerPorElemento('fechaini');
	ConstruirDatePickerPorElemento('fechafin');
});

var class_css_header = 'style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center; vertical-align:middle; text-transform:uppercase"';
var class_css = 'style="border-right: 2px solid lightslategray; vertical-align:middle"';
var class_css_btxt = 'style="border-right: 2px solid lightslategray; vertical-align:middle; text-align:center"';

function Consultar() {
	var tipo = "";
	var urltemp = "";
	if($("#incidente").is(':checked')){
		tipo = "I";
		urltemp = '/IncidentesConsulta/ListarIncidentesAT';
	}
	
	if($("#accidente").is(':checked')){
		tipo = "A";
		urltemp = '/IncidentesConsulta/ListarIncidentesAT';
	}
	
	if($("#enfermedad").is(':checked')){
		tipo = "E";
		urltemp = '/IncidentesConsulta/ListarIncidentesEL';
	}
	
    $.ajax({
        type: 'GET',
        url: urltemp,
		data: { tipo : tipo, fechaini : $('#fechaini').val(), fechafin : $('#fechafin').val() },
        success: function (result) {
            var tHtml = "";
            $("#gridconsulta").empty();
            tHtml += '<thead style="border-left:2px solid lightslategray;"><tr class="titulos_tabla">';
            tHtml += '<th '+class_css_header+'>Tipo Investigacion</td>';
            tHtml += '<th '+class_css_header+'>Fecha de Registro</th>';
            tHtml += '<th '+class_css_header+'>Acciones</th>';
            tHtml += '</tr></thead>';
			tHtml += '<tbody style="border-left:2px solid lightslategray;">';
			if(tipo=='I')
			{
				$.each(result, function (key, val) {
					tHtml += '<tr><td '+class_css_btxt+'>Incidente Laboral</td>';
					tHtml += '<td '+class_css_btxt+'>' + val.fechainvestigacion + '</td>';
					tHtml += '<td '+class_css_btxt+'>&nbsp;<a href="#" class="btn btn-search btn-md" title="Editar" onClick="CargarInvestigacionAT(' + val.pk_id_incidente + ');"><span class="glyphicon glyphicon-pencil"></span></a>&nbsp|&nbsp';
					tHtml += '&nbsp;<a href="#" class="btn btn-search btn-md" title="Reporte" onClick="CargarReporteAT(' + val.pk_id_incidente + ');"><span class="glyphicon glyphicon-download-alt"></span></a>&nbsp|&nbsp';
					tHtml += '<a href="#" class="btn btn-search btn-md" title="Eliminar" onClick="EliminarIncidenteAT(' + val.pk_id_incidente + ');"><span class="glyphicon glyphicon-erase"></span></a></td>';
					
				});
			}
			
			
			if(tipo=='A')
			{
				$.each(result, function (key, val) {
				    tHtml += '<tr><td ' + class_css_btxt + '>Accidente de Trabajo</td>';
					tHtml += '<td '+class_css_btxt+'>' + val.fechainvestigacion + '</td>';
					tHtml += '<td '+class_css_btxt+'>&nbsp;<a href="#" class="btn btn-search btn-md" title="Editar" onClick="CargarInvestigacionAT(' + val.pk_id_incidente + ');"><span class="glyphicon glyphicon-pencil"></span></a>&nbsp|&nbsp';
					tHtml += '&nbsp;<a href="#" class="btn btn-search btn-md" title="Reporte" onClick="CargarReporteAT(' + val.pk_id_incidente + ');"><span class="glyphicon glyphicon-download-alt"></span></a>&nbsp|&nbsp';
					tHtml += '<a href="#" class="btn btn-search btn-md" title="Eliminar" onClick="EliminarIncidenteAT(' + val.pk_id_incidente + ');"><span class="glyphicon glyphicon-erase"></span></a></td>';
					
				});
			}
			
			if(tipo=='E')
			{
				$.each(result, function (key, val) {
					tHtml += '<tr><td '+class_css_btxt+'>Enfermedad Laboral</td>';
					tHtml += '<td '+class_css_btxt+'>' + val.fechainvestigacion + '</td>';
					tHtml += '<td '+class_css_btxt+'>&nbsp;<a href="#" class="btn btn-search btn-md" title="Editar" onClick="CargarInvestigacionE(' + val.pk_id_incidente + ');"><span class="glyphicon glyphicon-pencil"></span></a>&nbsp|&nbsp';
					tHtml += '&nbsp;<a href="#" class="btn btn-search btn-md" title="Reporte" onClick="CargarReporteEL(' + val.pk_id_incidente + ');"><span class="glyphicon glyphicon-download-alt"></span></a>&nbsp|&nbsp';
					tHtml += '<a href="#" class="btn btn-search btn-md" title="Eliminar" onClick="EliminarIncidenteEL(' + val.pk_id_incidente + ');"><span class="glyphicon glyphicon-erase"></span></a></td>';
				});
			}
			
			
            tHtml += '</tr></tbody>';
            $("#gridconsulta").append(tHtml);
        }
    });
}


function CargarInvestigacionAT(pk_id_incidente)
{
     window.location.href = "/IncidentesAT/CrearIncidenteAT?pk_id_incidente=" + pk_id_incidente;
}

function CargarReporteAT(pk_id_incidente)
{
    window.location.href = "/ReportesIncidentes/GenerarATPDF?pk_id_incidente=" + pk_id_incidente;
    //window.open('/ReportesIncidentes/GenerarATPDF?pk_id_incidente=' + pk_id_incidente, '_blank');
}

function CargarReporteEL(pk_id_incidente)
{
    window.location.href = "/ReportesIncidentes/ReporteIncidenteEL?pk_id_incidente=" + pk_id_incidente;
	// window.open('/ReportesIncidentes/ReporteIncidenteEL?pk_id_incidente=' + pk_id_incidente, '_blank');
}

function CargarInvestigacionE(PK_Incidentes_EL)
{
     window.location.href = "/IncidentesEL/CrearIncidenteEL?pk_id_incidente_el=" + PK_Incidentes_EL;
}

function EliminarIncidenteAT(pk_id_incidente)
{
	swal({
        title: "Estimado Usuario",
        text: "Desea Eliminar el Accidente de Trabajo Seleccionado?",
        type: "warning",
		showCancelButton: true,
		confirmButtonColor: "#DD6B55",
		confirmButtonText: "Si",
		cancelButtonText: "No",
		closeOnConfirm: false
    },
	function (isConfirm) {
	   if(isConfirm){
		   swal("Estimado Usuario", "El Accidente de Trabajo ha sido Eliminado con Éxito.", "success");
		   $.ajax({
				type: 'GET',
				url: '/IncidentesConsulta/EliminarIncidente',
				data: { pk_id_incidente: pk_id_incidente, tipo : "AT" },
				success: function (result) { Consultar(); }
			});
	   }
	
	});
}

function EliminarIncidenteEL(pk_id_incidente)
{
	swal({
        title: "Estimado Usuario",
        text: "Desea Eliminar el Incidente de Enfermedad Laboral Seleccionado?",
        type: "warning",
		showCancelButton: true,
		confirmButtonColor: "#DD6B55",
		confirmButtonText: "Si",
		cancelButtonText: "No",
		closeOnConfirm: false
    },
	function (isConfirm) {
	   if(isConfirm){
		   swal("Estimado Usuario", "El Incidente de Enfermedad Laboral ha sido Eliminado con Éxito.", "success");
		   $.ajax({
				type: 'GET',
				url: '/IncidentesConsulta/EliminarIncidente',
				data: { pk_id_incidente: pk_id_incidente, tipo : "EL" },
				success: function (result) { Consultar(); }
			});
	   }
	});
}