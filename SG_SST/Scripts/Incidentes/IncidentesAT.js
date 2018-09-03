$(function () {

	ConstruirDatePickerPorElemento('FechaInvestigacionI');
	//ConstruirDatePickerPorElemento('FechaNacimientoIII');
	ConstruirDatePickerPorElemento('FechaIngresoIII');
	ConstruirDatePickerPorElemento('FechaMuerteIII');
	ConstruirDatePickerPorElemento('FechaOcurrenciaIV');
	ConstruirDatePickerPorElemento('FechaRemisionXI');
	ConstruirDatePickerPorElemento('AnexoFechaIncidente');
	ConstruirDatePickerPorElemento('FechaMantenimientoVI');
	ConstruirDatePickerPorElemento('FechaImplementacion1X');
	ConstruirDatePickerPorElemento('FechaImplementacion2X');
	ConstruirDatePickerPorElemento('FechaImplementacion3X');
	ConstruirDatePickerPorElemento('BasicasFechaImplementacion1X');
	ConstruirDatePickerPorElemento('BasicasFechaImplementacion2X');
	ConstruirDatePickerPorElemento('BasicasFechaImplementacion3X');
	ConstruirDatePickerPorElemento('RecomendacionesARLXI');
	ConstruirDatePickerPorElemento('RemisionInformeARLXI');
	ConstruirDatePickerPorElemento('FechaVerificacionXII');
	ConstruirDatePickerPorElemento('FechaVerificacionXIII');
	ConstruirDatePickerPorElemento('AnexoFechaTestimonio');
	$("#HoraInicialI").timepicker();
	$("#TiempoLaboradoPrevioIV").timepicker({'timeFormat': 'h:i'});
	$("#HoraFinalI").timepicker	();
    $("#HoraOcurrenciaIV").timepicker();
	$("#accordion").accordion({
        heightStyle: "content"
    });
});

var boOtroSitioIV = false;

var jqXHRData;
$(document).ready(function () {
	initSimpleFileUpload();
	//Handler for "Start upload" button 
	 $("#hl-start-upload").on('click', function () {
		if (jqXHRData) {
			jqXHRData.submit();
		}
		return false;
	});  
});

function initSimpleFileUpload() {
	$('#upload').fileupload({
        
    });
}

function GetProp(val)
{
	$('#TipoIdentificacionIII').prop("disabled", val);
}

function boolIncidentes(val)
{
	if(val==1)
		return true;
	else
		return false;
}

CargarIncidenteAT();
function CargarIncidenteAT()
{
	if($('#PK_Incidentes_AT_Id1').val()!=null)
	{
		$("#PK_Incidentes_AT_Id1").val($('#PK_Incidentes_AT_Id1').val());
		$("#PK_Incidentes_AT_Id2").val($('#PK_Incidentes_AT_Id1').val());
		$("#PK_Incidentes_AT_Id3").val($('#PK_Incidentes_AT_Id1').val());
		$("#PK_Incidentes_AT_Id4").val($('#PK_Incidentes_AT_Id1').val());
		$("#PK_Incidentes_AT_Id5").val($('#PK_Incidentes_AT_Id1').val());
		$("#PK_Incidentes_AT_Id6").val($('#PK_Incidentes_AT_Id1').val());
		$("#PK_Incidentes_AT_Id7").val($('#PK_Incidentes_AT_Id1').val());
		$("#PK_Incidentes_AT_Id8").val($('#PK_Incidentes_AT_Id1').val());
		$("#PK_Incidentes_AT_Id9").val($('#PK_Incidentes_AT_Id1').val());
		$("#PK_Incidentes_AT_Id10").val($('#PK_Incidentes_AT_Id1').val());
		$("#PK_Incidentes_AT_Id11").val($('#PK_Incidentes_AT_Id1').val());
		$("#PK_Incidentes_AT_Id12").val($('#PK_Incidentes_AT_Id1').val());
		$("#PK_Incidentes_AT_Id13").val($('#PK_Incidentes_AT_Id1').val());
		$("#PK_Incidentes_ATAnexos").val($('#PK_Incidentes_AT_Id1').val());
		$.ajax({
			type: 'GET',
			url: '/IncidentesAT/CargarIncidenteAT',
			data: { pk_id_incidente : $('#PK_Incidentes_AT_Id1').val() },
			success: function (result) {
				if(result.boIncidente=='I')
					$('#boIncidente').prop( "checked", true );
				else
					$('#boAccidenteTrabajo').prop( "checked", true );
			
				Habilitar(result.boIncidente);
				
				if(result.boIncidente1=='L')
					$('#boLeve').prop( "checked", true );
				else
					$('#boLeve').prop( "checked", false );
			
				
				if(result.boIncidente1=='G')
					$('#boGrave').prop( "checked", true );
				else
					$('#boGrave').prop( "checked", false );
				
				
				if(result.boIncidente1=='M')
					$('#boMortal').prop( "checked", true );
				else
					$('#boMortal').prop( "checked", false );


				$('#dmyFile1').text(result.hmyFile1);

				$('#AtencionOportunaOtrosIII').val(result.AtencionOportunaOtrosIII);
				$('#FechaInvestigacionI').val(result.FechaInvestigacionI);
				$('#pk_DepartamentoI').val(result.pk_DepartamentoI);
				CargarMunicipios(result.pk_DepartamentoI);
				//$('#pk_MunicipioI').val(result.pk_MunicipioI);
				$('#DireccionI').val(result.DireccionI);
				$('#HoraInicialI').val(result.HoraInicialI);
				$('#HoraFinalI').val(result.HoraFinalI);
				$('#ResponsablesI').val(result.ResponsablesI);

				$('#FotografiasI').prop( "checked", boolIncidentes(result.FotografiasI) );
				$('#VideosI').prop( "checked", boolIncidentes(result.VideosI) );
				$('#CintasAudioI').prop( "checked", boolIncidentes(result.CintasAudioI) );
				$('#IlustracionesI').prop( "checked", boolIncidentes(result.IlustracionesI) );
				$('#DiagramasI').prop( "checked", boolIncidentes(result.DiagramasI) );
				$('#OtrosI').prop( "checked", boolIncidentes(result.OtrosI) );
				$('#CualesI').val(result.CualesI);
				
				$('#boTipoF1X').prop( "checked", boolIncidentes(result.boTipoF1X) );
				$('#boTipoM1X').prop( "checked", boolIncidentes(result.boTipoM1X) );
				$('#boTipoT1X').prop( "checked", boolIncidentes(result.boTipoT1X) );
				$('#boTipoF2X').prop( "checked", boolIncidentes(result.boTipoF2X) );
				$('#boTipoM2X').prop( "checked", boolIncidentes(result.boTipoM2X) );
				$('#boTipoT2X').prop( "checked", boolIncidentes(result.boTipoT2X) );
				$('#boTipoF3X').prop( "checked", boolIncidentes(result.boTipoF3X) );
				$('#boTipoM3X').prop( "checked", boolIncidentes(result.boTipoM3X) );
				$('#boTipoT3X').prop( "checked", boolIncidentes(result.boTipoT3X) );
				$('#boBasicasF1X').prop( "checked", boolIncidentes(result.boBasicasF1X) );
				$('#boBasicasM1X').prop( "checked", boolIncidentes(result.boBasicasM1X) );
				$('#boBasicasT1X').prop( "checked", boolIncidentes(result.boBasicasT1X) );
				$('#boBasicasF2X').prop( "checked", boolIncidentes(result.boBasicasF2X) );
				$('#boBasicasM2X').prop( "checked", boolIncidentes(result.boBasicasM2X) );
				$('#boBasicasT2X').prop( "checked", boolIncidentes(result.boBasicasT2X) );
				$('#boBasicasF3X').prop( "checked", boolIncidentes(result.boBasicasF3X) );
				$('#boBasicasM3X').prop( "checked", boolIncidentes(result.boBasicasM3X) );
				$('#boBasicasT3X').prop( "checked", boolIncidentes(result.boBasicasT3X) );
				
				if(result.boTipoVinculacionII=="EM")
					$('#TipoVinculacionII2').prop( "checked",true);
				
				if(result.boTipoVinculacionII=="CO")
					$('#TipoVinculacionII3').prop( "checked",true);
				
				if(result.boTipoVinculacionII=="COO")
					$('#TipoVinculacionII').prop( "checked",true);
				
				
				/*if(result.TipoIdentificacionII=="NI")
					$('#TipoIdentificacionII2').prop("checked",true);
				
				if(result.TipoIdentificacionII=="CC")
					$('#TipoIdentificacionII3').prop("checked",true);
				
				if(result.TipoIdentificacionII=="CE")
					$('#TipoIdentificacionII4').prop("checked",true);
				
				if(result.TipoIdentificacionII=="NU")
					$('#TipoIdentificacionII2').prop("checked",true);
				
				if(result.TipoIdentificacionII=="PA")
					$('#TipoIdentificacionII').prop("checked",true);
				
			
				$('#ActividadEconomicaII').val(result.ActividadEconomicaII);
				$('#NumeroIdentificacionII').val(result.NumeroIdentificacionII);
				
				
				
				$('#NombreRazonSocialII').val(result.NombreRazonSocialII);
				$('#DireccionPpalII').val(result.DireccionPpalII);
				$('#TelefonoII').val(result.TelefonoII);
				$('#FaxII').val(result.FaxII);
				$('#DepartamentoIII').val(result.DepartamentoIII);
				$('#MunicipioIII').val(result.MunicipioIII);
				$('#EmailII').val(result.EmailII);
				
				if(result.ZonaUrbanaII=="U")
					$('#ZonaUrbanaII').prop("checked", true);
				
				if(result.ZonaUrbanaII=="R")
					$('#ZonaUrbanaII').prop("checked", false);
				
	
				if(result.SedePrincipalII==0)
					$('#SedePrincipalIIR').prop("checked", true);
				else
					$('#SedePrincipalIIU').prop("checked", true);
				

				$('#ActEconoCentroTrabajoII').val(result.ActEconoCentroTrabajoII);
				$('#pk_ActEconoCentroTrabajoII').val(result.pk_ActEconoCentroTrabajoII);
				$('#CentroCostoTelefonoII').val(result.CentroCostoTelefonoII);
				$('#CentroCostoFaxII').val(result.CentroCostoFaxII);
				$('#DireccionCentroTrabajoII').val(result.DireccionCentroTrabajoII);
				
				
				if(result.ZonaII=='U')
					$('#ZonaII2').prop("checked", true);
				else
					$('#ZonaII').prop("checked", true);*/
				
				
				$('#pk_DeptoCentroCostoII').val(result.pk_DeptoCentroCostoII);
				CargarMncpioCentroCostoII(result.pk_DeptoCentroCostoII);
				
			    //$('#pk_MncpioCentroCostoII').val(result.pk_MncpioCentroCostoII);

				

				$('#pk_DepartamentoIV').val(result.pk_DepartamentoIV);
				//$('#pk_MncpioIV').val(result.pk_MncpioIV);
				CargarMunicipioIV(result.pk_DepartamentoIV);

				if(result.boTipoVinculacionIII=="P")
					$('#TipoVinculacionIII2').prop("checked", true);
					
				if(result.boTipoVinculacionIII=="M")
					$('#TipoVinculacionIII3').prop("checked", true);
					
				if(result.boTipoVinculacionIII=="C")
					$('#TipoVinculacionIII4').prop("checked", true);
					
				if(result.boTipoVinculacionIII=="E")
					$('#TipoVinculacionIII').prop("checked", true);
						

			
				if(result.tempTipoIdentificacionIII == "CC")
					$("#TipoIdentificacionIII3").prop('checked',true);
				
				if(result.tempTipoIdentificacionIII == "CE")
					$("#TipoIdentificacionIII4").prop('checked',true);
				
				if(result.tempTipoIdentificacionIII == "NU")
					$("#TipoIdentificacionIII5").prop('checked',true);
				
				if(result.tempTipoIdentificacionIII == "PA")
					$("#TipoIdentificacionIII").prop('checked',true);
				
				
				
				if(result.TipoIdentRepresentanteARLIX == "CC")
					$("#TipoIdentRepresentanteARLIX1").prop('checked',true);
				
				if(result.TipoIdentRepresentanteARLIX == "CE")
					$("#TipoIdentRepresentanteARLIX2").prop('checked',true);
				
				if(result.TipoIdentRepresentanteARLIX == "NU")
					$("#TipoIdentRepresentanteARLIX3").prop('checked',true);
				
				if(result.TipoIdentRepresentanteARLIX == "PA")
					$("#TipoIdentRepresentanteARLIX4").prop('checked',true);
				
		
				$("#RepresentanteARLNombresIX").val(result.RepresentanteARLNombresIX);
				$("#CargoRepresentanteARLIX").val(result.CargoRepresentanteARLIX);
				$("#NumIdentRepresentanteARLIXIX").val(result.NumIdentRepresentanteARLIXIX);
				

				if(result.TipoIdentEspecialistaSGSSTIX == "CC")
					$("#TipoIdentEspecialistaSGSSTIX1").prop('checked',true);
				
				if(result.TipoIdentEspecialistaSGSSTIX == "CE")
					$("#TipoIdentEspecialistaSGSSTIX2").prop('checked',true);
				
				if(result.TipoIdentEspecialistaSGSSTIX == "NU")
					$("#TipoIdentEspecialistaSGSSTIX3").prop('checked',true);
				
				if(result.TipoIdentEspecialistaSGSSTIX == "PA")
					$("#TipoIdentEspecialistaSGSSTIX4").prop('checked',true);
				
				
				$("#EspecialistaSGSSTNombresIX").val(result.EspecialistaSGSSTNombresIX);
				$("#CargoEspecialistaSGSSTIX").val(result.CargoEspecialistaSGSSTIX);
				$("#NumIdentEspecialistaSGSSTIX").val(result.NumIdentEspecialistaSGSSTIX);
				
				$("#FechaVerificacionXII").val(result.FechaVerificacionXII);
				
				$("#TemperaturaVI").val(result.TemperaturaVI);
				$("#VoltajeElectricoUnidadMedidaV2").val(result.VoltajeElectricoUnidadMedidaV2);
				
		
				
				
				$('#NumeroIdentificacionIII').val(result.NumeroIdentificacionIII);
				CargarEmpleado(result.NumeroIdentificacionIII);
				
				$('#PrimerApellidoIII').val(result.PrimerApellidoIII);
				$('#SegundoApellidoIII').val(result.SegundoApellidoIII);
				$('#PrimerNombreIII').val(result.PrimerNombreIII);
				$('#FechaNacimientoIII').val(result.FechaNacimientoIII);
				$('#SegundoNombreIII').val(result.SegundoNombreIII);
				$('#CodigoOcupacionIII').val(result.CodigoOcupacionIII);
				
				$('#MarcaVI').val(result.MarcaVI);
				$('#textfield74').val(result.textfield74);
				$('#AnalisisNombresIX').val(result.AnalisisNombresIX);

	
				$('#SexoIII').val(result.SexoIII);
				$('#EPSIII').val(result.EPSIII);
				$('#AFPIII').val(result.AFPIII);
				$('#ARLIII').val(result.ARLIII);
				$('#TelefonoIII').val(result.TelefonoIII);
				$('#FaxIII').val(result.FaxIII);
				$('#EmailIII').val(result.EmailIII);
				$('#DireccionCentroTrabajoIII').val(result.DireccionCentroTrabajoIII);

				if(result.ZonaIII=="U")
					$('#ZonaIIIU').prop("checked", true);
				
				if(result.ZonaIII=="R")
					$('#ZonaIIIR').prop("checked", true);
				
				$('#CargoIII').val(result.CargoIII);
				$('#OcupacionIII').val(result.OcupacionIII);
				$('#FechaIngresoIII').val(result.FechaIngresoIII);
				$('#TiempoOcupacionAIII').val(result.TiempoOcupacionAIII);
				$('#TiempoOcupacionMIII').val(result.TiempoOcupacionMIII);
				$('#AntiguedadAIII').val(result.AntiguedadAIII);
				$('#AntiguedadMIII').val(result.AntiguedadMIII);
				
				
				if(result.boJornadaIII=="D")
					$('#DiurnoIII').prop("checked", true);
				
				if(result.boJornadaIII=="N")
					$('#NocturnoIII').prop("checked", true);
				
				if(result.boJornadaIII=="M")
					$('#MixtoIII').prop("checked", true);
				
				if(result.boJornadaIII=="T")
					$('#TurnosIII').prop("checked", true);
				

				$('#SalarioHonorariosIII').val(result.SalarioHonorariosIII);
				$('#FechaMuerteIII').val(result.FechaMuerteIII);
				
				if(result.AtencionOportunaIII=="S")
					$('#AtencionOportunaIIIS').prop("checked", true);
				else
					$('#AtencionOportunaIIIN').prop("checked", true);
				
			
				
				$('#FechaOcurrenciaIV').val(result.FechaOcurrenciaIV);
				diaSemana(result.FechaOcurrenciaIV);
				
				
				$('#HoraOcurrenciaIV').val(result.HoraOcurrenciaIV);
				
				if(result.boJornadaIII=="M")
					$('#MixtoIII').prop("checked", true);
				
				if(result.boJornadaIII=="T")
					$('#TurnosIII').prop("checked", true);

				if(result.boJornadaIV=="N")
					$('#boJornadaIVN').prop("checked", true);
				
				if(result.boJornadaIV=="E")
					$('#boJornadaIVE').prop("checked", true);
				
				
				if(result.boDiaSemanaIV=="LU")
					$('#boDiaSemanaIVLU').prop("checked", true);
	
				if(result.boDiaSemanaIV=="MA")
					$('#boDiaSemanaIVMA').prop("checked", true);
				
				if(result.boDiaSemanaIV=="MI")
					$('#boDiaSemanaIVMI').prop("checked", true);
				
				if(result.boDiaSemanaIV=="JU")
					$('#boDiaSemanaIVJU').prop("checked", true);
				
				if(result.boDiaSemanaIV=="VI")
					$('#boDiaSemanaIVVI').prop("checked", true);
				
				if(result.boDiaSemanaIV=="SA")
					$('#boDiaSemanaIVSA').prop("checked", true);
				
				if(result.boDiaSemanaIV=="DO")
					$('#boDiaSemanaIVDO').prop("checked", true);
				
				
				if(result.LaborHabitualIV=="S")
					$('#LaborHabitualIVS').prop("checked", true);
				else
					$('#LaborHabitualIVN').prop("checked", true);
				
			
				$('#TipoIncidenteIV').val(result.TipoIncidenteIV);
				$('#EspecTipoIncidenteIV').val(result.EspecTipoIncidenteIV);
				$('#IPSAtendioIV').val(result.IPSAtendioIV);
				
				
				if(result.ZonaIV=="U")
					$('#ZonaIVU').prop("checked", true);
				
				if(result.ZonaIV=="R")
					$('#ZonaIVR').prop("checked", true);
				
				
				$('#TiempoLaboradoPrevioIV').val(result.TiempoLaboradoPrevioIV);
				$('#LugarExactoIV').val(result.LugarExactoIV);
				$('#SitioExactoIV').val(result.SitioExactoIV);
				$('#OtroSitioIV').val(result.OtroSitioIV);
				$('#EspecifiqueIV').val(result.EspecifiqueIV);
				$('#EspecifiqueLaborHabitual').val(result.EspecifiqueLaborHabitual);
				

				if(result.EventosSimilaresV != null){
					if(result.EventosSimilaresV=="S")
						$('#EventosSimilaresV2').prop("checked", true);
					else
						$('#EventosSimilaresV').prop("checked", true);
					
				}
				else
				{
					$('#EventosSimilaresV2').prop("checked", false);
					$('#EventosSimilaresV').prop("checked", false);
				}
					
				
				
				
				if(result.NumeroPersonasV != null){
					if(result.NumeroPersonasV=="S")
						$('#OtrosIncidentesV2').prop("checked", true);
					else
						$('#OtrosIncidentesV').prop("checked", true);
					
				}
				else
				{
					$('#OtrosIncidentesV2').prop("checked", false);
					$('#OtrosIncidentesV').prop("checked", false);
				}
				
				
				if(result.EventoSimilarV != null){
					if(result.EventoSimilarV=="S")
						$('#EventoSimilarV2').prop("checked", true);
					else
						$('#EventoSimilarV').prop("checked", true);
					
				}
				else
				{
					$('#EventoSimilarV2').prop("checked", false);
					$('#EventoSimilarV').prop("checked", false);
				}
				
				
				if(result.CondicionPrioritariaV != null){
					if(result.CondicionPrioritariaV=="S")
						$('#CondicionPrioritariaV2').prop("checked", true);
					else
						$('#CondicionPrioritariaV').prop("checked", true);
					
				}
				else
				{
					$('#CondicionPrioritariaV2').prop("checked", false);
					$('#CondicionPrioritariaV').prop("checked", false);
				}
				
				
				if(result.TrabajadorInvolucradoV != null){
					if(result.TrabajadorInvolucradoV=="S")
						$('#TrabajadorInvolucradoV2').prop("checked", true);
					else
						$('#TrabajadorInvolucradoV').prop("checked", true);
					
				}
				else
				{
					$('#TrabajadorInvolucradoV2').prop("checked", false);
					$('#TrabajadorInvolucradoV').prop("checked", false);
				}
		
		
				if(result.PanoramaRiesgoV != null){
					if(result.PanoramaRiesgoV=="S")
						$('#PanoramaRiesgoV2').prop("checked", true);
					else
						$('#PanoramaRiesgoV').prop("checked", true);
					
				}
				else
				{
					$('#PanoramaRiesgoV2').prop("checked", false);
					$('#PanoramaRiesgoV').prop("checked", false);
				}
		
		
				if(result.OtrosIncidentesV != null){
					if(result.OtrosIncidentesV=="S")
						$('#OtrosIncidentesV2').prop("checked", true);
					else
						$('#OtrosIncidentesV').prop("checked", true);
					
				}
				else
				{
					$('#OtrosIncidentesV2').prop("checked", false);
					$('#OtrosIncidentesV').prop("checked", false);
				}
				

				
				$('#NumeroPersonasV').val(result.NumeroPersonasV);
				$('#DescripcionAccidenteV').val(result.DescripcionAccidenteV);
				$('#AgenteVI').val(result.AgenteVI);
				$('#MaterialVI').val(result.MaterialVI);
				$('#ModeloVI').val(result.ModeloVI);
				$('#ReferenciaVI').val(result.ReferenciaVI);
				$('#PesoVI').val(result.PesoVI);
				$('#PesoUnidadMedidaVI').val(result.PesoUnidadMedidaVI);
				$('#AlturaVI').val(result.AlturaVI);
				$('#AnchoVI').val(result.AnchoVI);
				$('#VolumenVI').val(result.VolumenVI);
				$('#ProfundidadVI').val(result.ProfundidadVI);
				$('#VelocidadVI').val(result.VelocidadVI);
				$('#TiempoUsoVI').val(result.TiempoUsoVI);
				$('#TiempoUsoVIA').val(result.TiempoUsoVIA);
				$('#FechaMantenimientoVI').val(result.FechaMantenimientoVI);
				
				if(result.ReparadoVI=="S")
					$('#ReparadoVI2').prop("checked", true);
				else
					$('#ReparadoVI').prop("checked", true);
				
				
				
				$('#VelocidadUnidadMedidaVI').val(result.VelocidadUnidadMedidaVI);
				
				$('#ExplosivosVI').val(result.ExplosivosVI);
				$('#ExplosivosUnidadMedidaVI').val(result.ExplosivosUnidadMedidaVI);
				$('#ExplosivosCantidadVI').val(result.ExplosivosCantidadVI);
				
				$('#GasesVI').val(result.GasesVI);
				$('#GasesUnidadMedidaVI').val(result.GasesUnidadMedidaVI);
				$('#GasesCantidadVI').val(result.GasesCantidadVI);
				
				$('#TemperaturaVI').val(result.TemperaturaVI);
				$('#TemperaturaUnidadMedidaVI').val(result.TemperaturaUnidadMedidaVI);
				
				
				$('#SustanciaVI').val(result.SustanciaVI);
				$('#SustanciaUnidadMedidaVI').val(result.SustanciaUnidadMedidaVI);
				$('#SustanciaCantidadVI').val(result.SustanciaCantidadVI);
				
				
				
				$('#VoltajeElectricoVI').val(result.VoltajeElectricoVI);
				$('#VoltajeElectricoUnidadMedidaVI').val(result.VoltajeElectricoUnidadMedidaVI);
				$('#VoltajeElectricoCantidadVI').val(result.VoltajeElectricoCantidadVI);
				
				$('#DetallesAdicionalesVI').val(result.DetallesAdicionalesVI);
				
	
				if(result.EPPVI != null){
					if(result.EPPVI=="S")
						$('#EPPVI2').prop("checked", true);
					else
						$('#EPPVI').prop("checked", true);
					
				}
				else
				{
					$('#EPPVI2').prop("checked", false);
					$('#EPPVI').prop("checked", false);
				}

				if(result.TrabajadorEPPVI != null){
					if(result.TrabajadorEPPVI=="S")
						$('#TrabajadorEPPVI2').prop("checked", true);
					else
						$('#TrabajadorEPPVI').prop("checked", true);
					
				}
				else
				{
					$('#TrabajadorEPPVI2').prop("checked", false);
					$('#TrabajadorEPPVI').prop("checked", false);
				}
				
			
			
			
				$('#ObservacionesVI').val(result.ObservacionesVI);
				$('#CodTipoLesionVII').val(result.CodTipoLesionVII);
				$('#TipoLesionVII').val(result.TipoLesionVII);
				$('#CodigoParteCuerpoAfectadaVII').val(result.CodigoParteCuerpoAfectadaVII);
				$('#CodMecaAccideneteVII').val(result.CodMecaAccideneteVII);
				$('#MecanismoAccidenteVII').val(result.MecanismoAccidenteVII);
				$('#CodAgenteAccideneteVII').val(result.CodAgenteAccideneteVII);
				$('#AgenteAccidenteVII').val(result.AgenteAccidenteVII);
				$('#CodFactoresPersonalesVII1').val(result.CodFactoresPersonalesVII1);
				$('#FactoresPersonalesVII1').val(result.FactoresPersonalesVII1);
				$('#CodFactoresPersonalesVII2').val(result.CodFactoresPersonalesVII2);
				$('#FactoresPersonalesVII2').val(result.FactoresPersonalesVII2);
				$('#CodActoSubestandarVII1').val(result.CodActoSubestandarVII1);
				$('#CodActFactoresPersonalesVII2').val(result.CodActFactoresPersonalesVII2);
				$('#ActFactoresPersonalesVII2').val(result.ActFactoresPersonalesVII2);
				$('#ActosSubestandarVII1').val(result.ActosSubestandarVII1);
				$('#CodActoSubestandarVII2').val(result.CodActoSubestandarVII2);
				$('#ActosSubestandarVII2').val(result.ActosSubestandarVII2);
				$('#CodFactoresTrabajoVII1').val(result.CodFactoresTrabajoVII1);
				$('#FactoresTrabajoVII1').val(result.FactoresTrabajoVII1);
				$('#CodFactoresTrabajoVII2').val(result.CodFactoresTrabajoVII2);
				$('#FactoresTrabajoVII2').val(result.FactoresTrabajoVII2);
				$('#CodCondAmbientalesVII1').val(result.CodCondAmbientalesVII1);
				$('#CondAmbientalesVII1').val(result.CondAmbientalesVII1);
				$('#CodCondAmbientalesVII2').val(result.CodCondAmbientalesVII2);
				$('#CondAmbientalesVII2').val(result.CondAmbientalesVII2);
				
				$('#dmyFile8').text(result.hmyFile8);

				if(result.TipoIdentJefeInmediantoIX=="CC")
					$('#TipoIdentJefeInmediantoIX3').prop("checked",true);
				
				if(result.TipoIdentJefeInmediantoIX=="CE")
					$('#TipoIdentJefeInmediantoIX4').prop("checked",true);
				
				if(result.TipoIdentJefeInmediantoIX=="NU")
					$('#TipoIdentJefeInmediantoIX5').prop("checked",true);
				
				if(result.TipoIdentJefeInmediantoIX=="PA")
					$('#TipoIdentJefeInmediantoIX').prop("checked",true);
				
				if(result.TipoIdentJefeInmediantoIX=="TI")
					$('#TipoIdentJefeInmediantoIXTI').prop("checked",true);
				
				
				
				$('#NumIdentJefeInmediatoIX').val(result.NumIdentJefeInmediatoIX);
				$('#JefeInmediatoNombresIX').val(result.JefeInmediatoNombresIX);
				$('#JefeInmediatoCargoIX').val(result.JefeInmediatoCargoIX);
				$('#DescripcionAnalisisIX').val(result.DescripcionAnalisisIX);
				
		
				if(result.TipoIdentEncargadoPSOIX=="CC")
					$('#TipoIdentEncargadoPSOIX3').prop("checked",true);
				
				if(result.TipoIdentEncargadoPSOIX=="CE")
					$('#TipoIdentEncargadoPSOIX4').prop("checked",true);
				
				if(result.TipoIdentEncargadoPSOIX=="NU")
					$('#TipoIdentEncargadoPSOIX5').prop("checked",true);
				
				if(result.TipoIdentEncargadoPSOIX=="PA")
					$('#TipoIdentEncargadoPSOIX').prop("checked",true);
				
				if(result.TipoIdentEncargadoPSOIX=="TI")
					$('#TipoIdentEncargadoPSOIXTI').prop("checked",true);
				
				
				
				$('#NumIdentPSOIX').val(result.NumIdentPSOIX);
				$('#EncargadoPSONombresIX').val(result.EncargadoPSONombresIX);
				$('#EncargadoPSOCargoIX').val(result.EncargadoPSOCargoIX);
				

				if(result.TipoIdentCOPASOIX=="CC")
					$('#TipoIdentCOPASOIX3').prop("checked",true);
				
				if(result.TipoIdentCOPASOIX=="CE")
					$('#TipoIdentCOPASOIX4').prop("checked",true);
				
				if(result.TipoIdentCOPASOIX=="NU")
					$('#TipoIdentCOPASOIX5').prop("checked",true);
				
				if(result.TipoIdentCOPASOIX=="PA")
					$('#TipoIdentCOPASOIX').prop("checked",true);
				
				if(result.TipoIdentCOPASOIX=="TI")
					$('#TipoIdentCOPASOIXTI').prop("checked",true);
				
				
				$('#COPASONumIdentIX').val(result.COPASONumIdentIX);
				$('#COPASONombresCompletosIX').val(result.COPASONombresCompletosIX);
				$('#COPASOCargoIX').val(result.COPASOCargoIX);
				
				
			
				if(result.TipoIdentEncargadosPSOIX=="CC")
					$('#TipoIdentEncargadosPSOIX3').prop("checked",true);
				
				if(result.TipoIdentEncargadosPSOIX=="CE")
					$('#TipoIdentEncargadosPSOIX4').prop("checked",true);
				
				if(result.TipoIdentEncargadosPSOIX=="NU")
					$('#TipoIdentEncargadosPSOIX5').prop("checked",true);
				
				if(result.TipoIdentEncargadosPSOIX=="PA")
					$('#TipoIdentEncargadosPSOIX').prop("checked",true);
				
				if(result.TipoIdentEncargadosPSOIX=="TI")
					$('#TipoIdentEncargadosPSOIXTI').prop("checked",true);
				
				
				$('#NumeroIdentBrigadistaIX').val(result.NumeroIdentBrigadistaIX);
				$('#BrigadistaNombresIX').val(result.BrigadistaNombresIX);
				$('#BrigadistaCargoIX').val(result.BrigadistaCargoIX);
			
				if(result.TipoIdentParticipanteIX=="CC")
					$('#TipoIdentParticipanteIX3').prop("checked",true);
				
				if(result.TipoIdentParticipanteIX=="CE")
					$('#TipoIdentParticipanteIX4').prop("checked",true);
				
				if(result.TipoIdentParticipanteIX=="NU")
					$('#TipoIdentParticipanteIX5').prop("checked",true);
				
				if(result.TipoIdentParticipanteIX=="PA")
					$('#TipoIdentParticipanteIX').prop("checked",true);
				
				if(result.TipoIdentParticipanteIX=="TI")
					$('#TipoIdentParticipanteIXTI').prop("checked",true);
				
				
				$('#NumIdentParticipanteIX').val(result.NumIdentParticipanteIX);
				$('#ParticipanteNombreIX').val(result.ParticipanteNombreIX);
				$('#ParticipanteCargoIX').val(result.ParticipanteCargoIX);

				if(result.TipoIdentBrigadistaIX=="CC")
					$('#TipoIdentBrigadistaIX3').prop("checked",true);
				
				if(result.TipoIdentBrigadistaIX=="CE")
					$('#TipoIdentBrigadistaIX4').prop("checked",true);
				
				if(result.TipoIdentBrigadistaIX=="NU")
					$('#TipoIdentBrigadistaIX5').prop("checked",true);
				
				if(result.TipoIdentBrigadistaIX=="PA")
					$('#TipoIdentBrigadistaIX').prop("checked",true);
				
				if(result.TipoIdentBrigadistaIX=="TI")
					$('#TipoIdentBrigadistaIXTI').prop("checked",true);
				
				
				$('#EmpresaRepresentaIX').val(result.EmpresaRepresentaIX);
				$('#ObservacionEspecialistaIX').val(result.ObservacionEspecialistaIX);
				
				
	
				
				if(result.CausasInmediatasTipoC1X=="C")
					$('#boCausasInmediatasTipoC1X').prop("checked",true);
				else if(result.CausasInmediatasTipoC1X=="P")
					$('#boCausasInmediatasTipoP1X').prop("checked",true);
				else{
					$('#boCausasInmediatasTipoC1X').prop("checked",false);
					$('#boCausasInmediatasTipoP1X').prop("checked",false);
				}
				
				
				
				$('#MedidasIntervencion1X').val(result.MedidasIntervencion1X);
				if(result.TipoF1X=="F")
					$('#boTipoF1X').prop("checked",true);
				
				if(result.TipoF1X=="M")
					$('#boTipoM1X').prop("checked",true);
				
				if(result.TipoF1X=="T")
					$('#boTipoT1X').prop("checked",true);
				
				
				$('#RespImplementacion1X').val(result.RespImplementacion1X);
				$('#FechaImplementacion1X').val(result.FechaImplementacion1X);
	
				if(result.CausasInmediatasTipoC2X=="C")
					$('#boCausasInmediatasTipoC2X').prop("checked",true);
				else if(result.CausasInmediatasTipoC2X=="P")
					$('#boCausasInmediatasTipoP2X').prop("checked",true);
				else{
					$('#boCausasInmediatasTipoC2X').prop("checked",false);
					$('#boCausasInmediatasTipoP2X').prop("checked",false);
				}
				
				
				$('#MedidasIntervencion2X').val(result.MedidasIntervencion2X);
				
				if(result.TipoF2X=="F")
					$('#boTipoF2X').prop("checked",true);
				
				if(result.TipoF2X=="M")
					$('#boTipoM2X').prop("checked",true);
				
				if(result.TipoF2X=="T")
					$('#boTipoT2X').prop("checked",true);
				
				
					
					
					
					
				$('#NumLicenciaEspecialistaSGSSTIX1').val(result.NumLicenciaEspecialistaSGSSTIX1);
				$('#anioLicenciaEspecialistaSGSSTIX1').val(result.anioLicenciaEspecialistaSGSSTIX1);
				$('#NumLicenciaEspecialistaSGSSTIX2').val(result.NumLicenciaEspecialistaSGSSTIX2);
				$('#anioLicenciaEspecialistaSGSSTIX2').val(result.anioLicenciaEspecialistaSGSSTIX2);
				
				$('#RespImplementacion2X').val(result.RespImplementacion2X);
				$('#FechaImplementacion2X').val(result.FechaImplementacion2X);

				if(result.CausasInmediatasTipoC3X=="C")
					$('#boCausasInmediatasTipoC3X').prop("checked",true);
				else if(result.CausasInmediatasTipoC3X=="P")
					$('#boCausasInmediatasTipoP3X').prop("checked",true);
				else{
					$('#boCausasInmediatasTipoC3X').prop("checked",false);
					$('#boCausasInmediatasTipoP3X').prop("checked",false);
				}
				
				
				
				$('#MedidasIntervencion3X').val(result.MedidasIntervencion3X);
				
				if(result.TipoF3X=="F")
					$('#boTipoF3X').prop("checked",true);
				
				if(result.TipoF3X=="M")
					$('#boTipoM3X').prop("checked",true);
				
				if(result.TipoF3X=="T")
					$('#boTipoT3X').prop("checked",true);

				$('#RespImplementacion3X').val(result.RespImplementacion3X);
				$('#FechaImplementacion3X').val(result.FechaImplementacion3X);
				
				if(result.CausasBasicasTipoC1X=="C")
					$('#boCausasBasicasTipoC1X').prop("checked",true);
				else if(result.CausasBasicasTipoC1X=="P")
					$('#boCausasBasicasTipoP1X').prop("checked",true);
				else{
					$('#boCausasBasicasTipoC1X').prop("checked",false);
					$('#boCausasBasicasTipoP1X').prop("checked",false);
				}
	
				$('#BasicasInmediatas1X').val(result.BasicasInmediatas1X);
				
				if(result.BasicasF1X=="F")
					$('#boBasicasF1X').prop("checked",true);
				
				if(result.BasicasF1X=="M")
					$('#boBasicasF1X').prop("checked",true);
				
				if(result.BasicasF1X=="T")
					$('#boBasicasF1X').prop("checked",true);
				
			
				
				$('#BasicasRespImplementacion1X').val(result.BasicasRespImplementacion1X);
				$('#BasicasFechaImplementacion1X').val(result.BasicasFechaImplementacion1X);

				if(result.CausasBasicasTipoC2X=="C")
					$('#boCausasBasicasTipoC2X').prop("checked",true);
				else if(result.CausasBasicasTipoC2X=="P")
					$('#boCausasBasicasTipoP2X').prop("checked",true);
				else{
					$('#boCausasBasicasTipoC2X').prop("checked",false);
					$('#boCausasBasicasTipoP2X').prop("checked",false);
				}

				$('#BasicasInmediatas2X').val(result.BasicasInmediatas2X);
				
				if(result.BasicasF2X=="F")
					$('#boBasicasF2X').prop("checked",true);
				
				if(result.BasicasF2X=="M")
					$('#boBasicasM2X').prop("checked",true);
				
				if(result.BasicasF2X=="T")
					$('#boBasicasT2X').prop("checked",true);
					

				$('#BasicasRespImplementacion2X').val(result.BasicasRespImplementacion2X);
				$('#BasicasFechaImplementacion2X').val(result.BasicasFechaImplementacion2X);
				
				if(result.CausasBasicasTipoC3X=="C")
					$('#boCausasBasicasTipoC3X').prop("checked",true);
				else if(result.CausasBasicasTipoC3X=="P")
					$('#boCausasBasicasTipoP3X').prop("checked",true);
				else{
					$('#boCausasBasicasTipoC3X').prop("checked",false);
					$('#boCausasBasicasTipoP3X').prop("checked",false);
				}

				$('#BasicasInmediatas3X').val(result.BasicasInmediatas3X);
				
				if(result.BasicasF3X=="F")
					$('#boBasicasF3X').prop("checked",true);
				
				if(result.BasicasF3X=="M")
					$('#boBasicasM3X').prop("checked",true);
			
				if(result.BasicasT3X=="T")
					$('#boBasicasT3X').prop("checked",true);
				
				$('#BasicasRespImplementacion3X').val(result.BasicasRespImplementacion3X);
				$('#BasicasFechaImplementacion3X').val(result.BasicasFechaImplementacion3X);
				$('#FechaRemisionXI').val(result.FechaRemisionXI);
				$('#NoFoliosXI').val(result.NoFoliosXI);
				if(result.TipoIdentificacionXI=="NIT")
					$('#TipoIdentificacionXI2').prop("checked",true);
				
				if(result.TipoIdentificacionXI=="CC")
					$('#TipoIdentificacionXI3').prop("checked",true);
				
				if(result.TipoIdentificacionXI=="CE")
					$('#TipoIdentificacionXI4').prop("checked",true);
				
				if(result.TipoIdentificacionXI=="NU")
					$('#TipoIdentificacionXI5').prop("checked",true);
				
				if(result.TipoIdentificacionXI=="PA")
					$('#TipoIdentificacionXI').prop("checked",true);
				
				$('#NumeroIdentificacionXI').val(result.NumeroIdentificacionXI);
				$('#NombresXI').val(result.NombresXI);
				

	
				$('#CargoXI').val(result.CargoXI);
				$('#RecomendacionesARLXI').val(result.RecomendacionesARLXI);
				$('#RemisionInformeARLXI').val(result.RemisionInformeARLXI);
				$('#RemisionMinisterioTrabajoXI').val(result.RemisionMinisterioTrabajoXI);
				if(result.TipoIdentificacionXII=="NIT")
					$('#TipoIdentificacionXII2').prop("checked",true);
				
				if(result.TipoIdentificacionXII=="CC")
					$('#TipoIdentificacionXII3').prop("checked",true);
				
				if(result.TipoIdentificacionXII=="CE")
					$('#TipoIdentificacionXII4').prop("checked",true);
				
				if(result.TipoIdentificacionXII=="NU")
					$('#TipoIdentificacionXII5').prop("checked",true);
				
				if(result.TipoIdentificacionXII=="PA")
					$('#TipoIdentificacionXII').prop("checked",true);
				
				if(result.TipoIdentificacionXII=="TI")
					$('#TipoIdentificacionXIITI').prop("checked",true);
				
				$('#NumeroIdentificacionXII').val(result.NumeroIdentificacionXII);
				$('#NombresXII').val(result.NombresXII);
				$('#CargoXII').val(result.CargoXII);
				
				if(result.MedidasIntervencionXII=="S")
					$('#MedidasIntervencionXII2').prop("checked",true);
				
				if(result.MedidasIntervencionXII=="N")
					$('#MedidasIntervencionXII1').prop("checked",true);

				$('#ObservacionesXII').val(result.ObservacionesXII);
				
				$('#RecomendacionesCargoXI').val(result.RecomendacionesCargoXI);
				$('#GasesUnidadVI').val(result.GasesUnidadVI);
				$('#ExplosivosUnidadMedidaVI').val(result.ExplosivosUnidadMedidaVI);
				$('#SustanciaVI').val(result.SustanciaVI);
				
				
				
				if(result.TipoIdentificacionXIII=="CC")
					$('#TipoIdentificacionXIII1').prop("checked",true);
				
				if(result.TipoIdentificacionXIII=="CE")
					$('#TipoIdentificacionXIII2').prop("checked",true);
				
				if(result.TipoIdentificacionXIII=="NU")
					$('#TipoIdentificacionXIII3').prop("checked",true);
				
				if(result.TipoIdentificacionXIII=="PA")
					$('#TipoIdentificacionXIII4').prop("checked",true);
				
				if(result.TipoIdentificacionXIII=="TI")
					$('#TipoIdentificacionXIIITI').prop("checked",true);
				
				$('#NombresXIII').val(result.NombresXIII);

				$('#CargoXIII').val(result.CargoXIII);
				$('#NumeroIdentificacionXIII').val(result.NumeroIdentificacionXIII);
				
				$('#FechaVerificacionXIII').val(result.FechaVerificacionXIII);
				$('#ObservacionesXIII').val(result.ObservacionesXIII);
				
				if(result.MedidasIntervencionXIII=="S")
					$('#MedidasIntervencionXIII2').prop("checked",true);
				
				if(result.MedidasIntervencionXIII=="N")
					$('#MedidasIntervencionXIII1').prop("checked",true);

				$('#dmyFile2').text(result.hmyFile2);
				$('#dmyFile3').text(result.hmyFile3);
				$('#dmyFile4').text(result.hmyFile4);
				$('#dmyFile5').text(result.hmyFile5);
				$('#dmyFile6').text(result.hmyFile6);
				$('#dmyFile7').text(result.hmyFile7);
				$('#dmyFile9').text(result.hmyFile9);
				$('#dmyFile10').text(result.hmyFile10);
				$('#dmyFile11').text(result.hmyFile11);
				$('#dmyFile12').text(result.hmyFile12);
				$('#dmyFile13').text(result.hmyFile13);
				$('#dmyFile14').text(result.hmyFile14);
				
				$('#hmyFile2').text(result.hmyFile2);
				$('#hmyFile3').text(result.hmyFile3);
				$('#hmyFile4').text(result.hmyFile4);
				$('#hmyFile5').text(result.hmyFile5);
				$('#hmyFile6').text(result.hmyFile6);
				$('#hmyFile7').text(result.hmyFile7);
				$('#hmyFile9').text(result.hmyFile9);
				$('#hmyFile10').text(result.hmyFile10);
				$('#hmyFile11').text(result.hmyFile11);
				$('#hmyFile12').text(result.hmyFile12);
				$('#hmyFile13').text(result.hmyFile13);
				$('#hmyFile14').text(result.hmyFile14);

			}
			
		});
		
	}
}


function Habilitar(value)
{
	
	if(value=="I")
	{
		$('#boLeve').prop("disabled", true);
		$('#boGrave').prop("disabled", true);
		$('#boMortal').prop("disabled", true);
		$('#boLeve').prop("checked", false);
		$('#boGrave').prop("checked", false);
		$('#boMortal').prop("checked", false);
		$('#FechaMuerteIII').prop("disabled", true);
		$('#FechaMuerteIII').val("");
	}
	else{
		$('#FechaMuerteIII').prop("disabled", false);
		$('#boLeve').prop("disabled", false);
		$('#boGrave').prop("disabled", false);
		$('#boMortal').prop("disabled", false);
	}
}

function CheckedCentro(val)
{
	if(val=="N")
	{
		$('#ActEconoCentroTrabajoII').val("");
		$('#CentroCostoTelefonoII').val("");
		$('#CentroCostoFaxII').val("");
		$('#DireccionCentroTrabajoII').val("");
	}
	else
	{
		$('#ActEconoCentroTrabajoII').val($('#ActividadEconomicaII').val());
		$('#CentroCostoTelefonoII').val($('#TelefonoII').val());
		$('#CentroCostoFaxII').val($('#FaxII').val());
		$('#DireccionCentroTrabajoII').val($('#DireccionPpalII').val());
	}
}


function diaSemana(fecha){ 
    if (fecha == null || fecha == "")
        return;

    fecha = fecha.split('/');
    if(fecha.length!=3){
            return null;
    }
    //Vector para calcular día de la semana de un año regular.
    var regular =[0,3,3,6,1,4,6,2,5,0,3,5]; 
    //Vector para calcular día de la semana de un año bisiesto.
    var bisiesto=[0,3,4,0,2,5,0,3,6,1,4,6]; 
    //Vector para hacer la traducción de resultado en día de la semana.
    var semana=['DO', 'LU', 'MA', 'MI', 'JU', 'VI', 'SA'];
    //Día especificado en la fecha recibida por parametro.
    var dia=fecha[0];
    //Módulo acumulado del mes especificado en la fecha recibida por parametro.
    var mes=fecha[1]-1;
    //Año especificado por la fecha recibida por parametros.
    var anno=fecha[2];
    //Comparación para saber si el año recibido es bisiesto.
    if((anno % 4 == 0) && !(anno % 100 == 0 && anno % 400 != 0))
        mes=bisiesto[mes];
    else
        mes=regular[mes];
    //Se retorna el resultado del calculo del día de la semana.
    var dia = semana[Math.ceil(Math.ceil(Math.ceil((anno-1)%7)+Math.ceil((Math.floor((anno-1)/4)-Math.floor((3*(Math.floor((anno-1)/100)+1))/4))%7)+mes+dia%7)%7)];
	
	if(dia=="LU"){
		$('#boDiaSemanaIVLU').prop("checked", true);
		$('#boDiaSemanaIVMA').prop("disabled", true);
		$('#boDiaSemanaIVMI').prop("disabled", true);
		$('#boDiaSemanaIVJU').prop("disabled", true);
		$('#boDiaSemanaIVVI').prop("disabled", true);
		$('#boDiaSemanaIVSA').prop("disabled", true);
		$('#boDiaSemanaIVDO').prop("disabled", true);
	}
	
	if(dia=="MA"){
		$('#boDiaSemanaIVMA').prop("checked", true);
		$('#boDiaSemanaIVLU').prop("disabled", true);
		$('#boDiaSemanaIVMI').prop("disabled", true);
		$('#boDiaSemanaIVJU').prop("disabled", true);
		$('#boDiaSemanaIVVI').prop("disabled", true);
		$('#boDiaSemanaIVSA').prop("disabled", true);
		$('#boDiaSemanaIVDO').prop("disabled", true);
	}
	
	if(dia=="MI"){
		$('#boDiaSemanaIVMI').prop("checked", true);
		$('#boDiaSemanaIVMA').prop("disabled", true);
		$('#boDiaSemanaIVLU').prop("disabled", true);
		$('#boDiaSemanaIVJU').prop("disabled", true);
		$('#boDiaSemanaIVVI').prop("disabled", true);
		$('#boDiaSemanaIVSA').prop("disabled", true);
		$('#boDiaSemanaIVDO').prop("disabled", true);
	}
	
	if(dia=="JU"){
		$('#boDiaSemanaIVJU').prop("checked", true);
		$('#boDiaSemanaIVMI').prop("disabled", true);
		$('#boDiaSemanaIVMA').prop("disabled", true);
		$('#boDiaSemanaIVLU').prop("disabled", true);
		$('#boDiaSemanaIVVI').prop("disabled", true);
		$('#boDiaSemanaIVSA').prop("disabled", true);
		$('#boDiaSemanaIVDO').prop("disabled", true);
	}
	
	if(dia=="VI"){
		$('#boDiaSemanaIVVI').prop("checked", true);
		$('#boDiaSemanaIVJU').prop("disabled", true);
		$('#boDiaSemanaIVMI').prop("disabled", true);
		$('#boDiaSemanaIVMA').prop("disabled", true);
		$('#boDiaSemanaIVLU').prop("disabled", true);
		$('#boDiaSemanaIVSA').prop("disabled", true);
		$('#boDiaSemanaIVDO').prop("disabled", true);
	}
	
	if(dia=="SA"){
		$('#boDiaSemanaIVSA').prop("checked", true);
		$('#boDiaSemanaIVVI').prop("disabled", true);
		$('#boDiaSemanaIVJU').prop("disabled", true);
		$('#boDiaSemanaIVMI').prop("disabled", true);
		$('#boDiaSemanaIVMA').prop("disabled", true);
		$('#boDiaSemanaIVLU').prop("disabled", true);
		$('#boDiaSemanaIVDO').prop("disabled", true);
	}
	
	if(dia=="DO"){
		$('#boDiaSemanaIVDO').prop("checked", true);
		$('#boDiaSemanaIVSA').prop("disabled", true);
		$('#boDiaSemanaIVVI').prop("disabled", true);
		$('#boDiaSemanaIVJU').prop("disabled", true);
		$('#boDiaSemanaIVMI').prop("disabled", true);
		$('#boDiaSemanaIVMA').prop("disabled", true);
		$('#boDiaSemanaIVLU').prop("disabled", true);
	}
}

function CargarMunicipios(codDepto){
	$.ajax({
		type: 'GET',
		url: '/IncidentesAT/ObtenerMunicipiosxDepto',
		data: { pk_id_depto : codDepto },
		success: function (result) {
		 $("#pk_MunicipioI").empty();
		 $.each(result, function(k,v){
			$("#pk_MunicipioI").append("<option value=\""+v.Pk_Id_Municipio+"\">"+v.Nombre_Municipio+"</option>");
		 });
		}
	});
}

function CargarMunicipiosII(codDepto){
	$.ajax({
		type: 'GET',
		url: '/IncidentesAT/ObtenerMunicipiosxDepto',
		data: { pk_id_depto : codDepto },
		success: function (result) {
		 $("#pk_MunicipioII").empty();
		 $.each(result, function(k,v){
			$("#pk_MunicipioII").append("<option value=\""+v.Pk_Id_Municipio+"\">"+v.Nombre_Municipio+"</option>");
		 });
		}
	});
}

function CargarMncpioCentroCostoII(codDepto){
	$.ajax({
		type: 'GET',
		url: '/IncidentesAT/ObtenerMunicipiosxDepto',
		data: { pk_id_depto : codDepto },
		success: function (result) {
		 $("#pk_MncpioCentroCostoII").empty();
		 $.each(result, function(k,v){
			$("#pk_MncpioCentroCostoII").append("<option value=\""+v.Pk_Id_Municipio+"\">"+v.Nombre_Municipio+"</option>");
		 });
		}
	});
}

function CargarMunicipioIV(codDepto){
	$.ajax({
		type: 'GET',
		url: '/IncidentesAT/ObtenerMunicipiosxDepto',
		data: { pk_id_depto : codDepto },
		success: function (result) {
		 $("#pk_MncpioIV").empty();
		 $.each(result, function(k,v){
			$("#pk_MncpioIV").append("<option value=\""+v.Pk_Id_Municipio+"\">"+v.Nombre_Municipio+"</option>");
		 });
		}
	});
}

function CargarEmpleado(numeroDocumento)
{
	$.ajax({
		type: 'POST',
		url: '/IncidentesAT/ConsultarDatosTrabajador',
		data: { numeroDocumento : numeroDocumento },
		success: function (result) {
			if(result.Mensaje!="OK")
				swal("Estimado Usuario",result.Data, "warning");
			else{
				if(result.Data.tipoDoc == "CC")
					$("#TipoIdentificacionIII3").prop('checked',true);
				
				if(result.Data.tipoDoc == "CE")
					$("#TipoIdentificacionIII4").prop('checked',true);
				
				if(result.Data.tipoDoc == "NU")
					$("#TipoIdentificacionIII5").prop('checked',true);
				
				if(result.Data.tipoDoc == "PA")
					$("#TipoIdentificacionIII").prop('checked',true);
					
					
				$("#PrimerApellidoIII").val(result.Data.apellido1);
				$("#SegundoApellidoIII").val(result.Data.apellido2);
				$("#PrimerNombreIII").val(result.Data.nombre1);
				$("#SegundoNombreIII").val(result.Data.nombre2);
				$("#FechaNacimientoIII").val(result.Data.fechaNacimiento);
				$("#DepartamentoIII").val(result.Data.nomDepAfiliado);
				$("#MunicipioIII").val(result.Data.nomMunAfiliado);
				if(result.Data.sexoPersona=="F")
					$("#SexoIII").val("F");
				else
					$("#SexoIII").val("M");

				
				$("#EPSIII").val(result.Data.nombreEps);
				$("#AFPIII").val(result.Data.nombreAfp);
				$("#ARLIII").val(result.Data.nombreArl);
				$("#TelefonoIII").val(result.Data.telPersona);
				$("#FaxIII").val(result.Data.faxEmpresa);
				$("#EmailIII").val(result.Data.emailPersona);
				$("#DireccionCentroTrabajoIII").val(result.Data.dirEmpresa);
				
				if(result.Data.idZona=="U")
					$("#ZonaIIIU").prop('checked',true);
				else
					$("#ZonaIIIR").prop('checked',true);
				
				
				
				$("#CargoIII").val(result.Data.cargo);
				$("#CodigoOcupacionIII").val(result.Data.idOcupacion);
				$("#OcupacionIII").val(result.Data.ocupacion);
				$("#SalarioHonorariosIII").val(FormatoMoneda(result.Data.salario),2);	
			}	
		}
	});
}

function FormatoMoneda(amount, decimals) {

    amount += ''; // por si pasan un numero en vez de un string
    amount = parseFloat(amount.replace(/[^0-9\.]/g, '')); // elimino cualquier cosa que no sea numero o punto

    decimals = decimals || 0; // por si la variable no fue fue pasada

    // si no es un numero o es igual a cero retorno el mismo cero
    if (isNaN(amount) || amount === 0) 
        return parseFloat(0).toFixed(decimals);

    // si es mayor o menor que cero retorno el valor formateado como numero
    amount = '' + amount.toFixed(decimals);

    var amount_parts = amount.split('.'),
        regexp = /(\d+)(\d{3})/;

    while (regexp.test(amount_parts[0]))
        amount_parts[0] = amount_parts[0].replace(regexp, '$1' + ',' + '$2');

    return amount_parts.join('.');
}

function HabilitarM(val)
{
	if(val=="M"){
		$("#FechaMuerteIII").prop( "disabled", false );
		$("#fechamuerte").css( "display", "block");
	}else{
		$("#FechaMuerteIII").prop( "disabled", true );
		$("#fechamuerte").css( "display", "none");
		
	}
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

function GuardarParcial1(){
	ValidaGuardarFormulario1();
	if ($("#IncidentesAT1").valid()) {
		PopupPosition();
		if($("#myFile1").val()!="")
			$("#hmyFile1").val($("#myFile1").val());
		else
			$("#hmyFile1").val($('#dmyFile1').text());

		GetProp(true);
		$("#SexoIII").prop("disabled",false);
		
		$.ajax({
			type: 'POST',
			url: '/IncidentesAT/GuardarIncidenteAT1',
			data: $("#IncidentesAT1").serialize(),
			traditional: true,
			success: function (result) {
				OcultarPopupposition();
				$("#PK_Incidentes_AT_Id1").val(result);
				$("#PK_Incidentes_AT_Id2").val(result);
				$("#PK_Incidentes_AT_Id3").val(result);
				$("#PK_Incidentes_AT_Id4").val(result);
				$("#PK_Incidentes_AT_Id5").val(result);
				$("#PK_Incidentes_AT_Id6").val(result);
				$("#PK_Incidentes_AT_Id7").val(result);
				$("#PK_Incidentes_AT_Id8").val(result);
				$("#PK_Incidentes_AT_Id9").val(result);
				$("#PK_Incidentes_AT_Id10").val(result);
				$("#PK_Incidentes_AT_Id11").val(result);
				$("#PK_Incidentes_AT_Id12").val(result);
				$("#PK_Incidentes_AT_Id13").val(result);
				$("#PK_Incidentes_ATAnexos").val(result);
				
				$("#SexoIII").prop("disabled",true);
				swal("Estimado Usuario", "El Incidente AT ha sido Guardado con Éxito.", "success");
				GetProp(false);
				$( "#accordion" ).accordion({ active: 1 });
			}
		});
	}
}

function ValidaGuardarFormulario1(){

	$("#IncidentesAT1").validate({
        errorClass: "error",
        rules: {
			boIncidente : 
			{
				required : true
			},
			boIncidente1 : {
				required: false
			},
			FechaInvestigacionI: {
                required: true
            },
			pk_DepartamentoI: {
                required: true
            },
			pk_MunicipioI: {
                required: true
            },
			DireccionI: {
                required: true
            },
			HoraInicialI: {
                required: true
            },
			HoraFinalI: {
                required: true
            },
			ResponsablesI: {
                required: true
            }
        },
        messages: {
			boIncidente : {
				required: "Este campo es requerido"
			},
			boIncidente1 : {
				required: "Este campo es requerido"
			},
			FechaInvestigacionI: {
                required: "Este campo es requerido"
            },
			pk_DepartamentoI: {
                required: "Este campo es requerido"
            },
			pk_MunicipioI: {
                required: "Este campo es requerido"
            },
			DireccionI: {
                required: "Este campo es requerido"
            },
			HoraInicialI: {
                required: "Este campo es requerido"
            },
			HoraFinalI: {
                required: "Este campo es requerido"
            },
			ResponsablesI: {
                required: "Este campo es requerido"
            }
        }
    });
}


function GuardarParcial2(){
	ValidaGuardarFormulario2();
	if ($("#IncidentesAT2").valid()) {
		PopupPosition();
		GetProp(true);
		$.ajax({
			type: 'POST',
			url: '/IncidentesAT/GuardarIncidenteAT2',
			data: $("#IncidentesAT2").serialize(),
			traditional: true,
			success: function (result) {
				OcultarPopupposition();
				swal("Estimado Usuario", "El Incidente AT ha sido Guardado con Éxito.", "success");
				GetProp(false);
				$( "#accordion" ).accordion({ active: 2 });
			}
		});
	}
}


function ValidaGuardarFormulario2(){
	
	$("#IncidentesAT2").validate({
        errorClass: "error",
        rules: {
			TipoVinculacionII: {
                required: true
            },
			TipoIdentificacionII: {
                required: true
            },
			ActividadEconomicaII: {
                required: true
            },
			NumeroIdentificacionII: {
                required: true
            },
			NombreRazonSocialII: {
                required: true
            },
			DireccionPpalII: {
                required: true
            },
			TelefonoII: {
                required: true
            },
			FaxII: {
                required: true
            },
			pk_DepartamentoII: {
                required: true
            },
			pk_MunicipioII: {
                required: true
            },
			EmailII: {
                required: true
            },
			CentroCostoTelefonoII: {
                required: true
            },
			CentroCostoFaxII: {
                required: true
            },
			DireccionCentroTrabajoII: {
                required: true
            },
			pk_DeptoCentroCostoII: {
                required: true
            },
			pk_MncpioCentroCostoII: {
                required: true
            }
        },
        messages: {
			TipoVinculacionII: {
                required: "Este campo es requerido"
            },
			TipoIdentificacionII: {
                required: "Este campo es requerido"
            },
			ActividadEconomicaII: {
                required: "Este campo es requerido"
            },
			NumeroIdentificacionII: {
                required: "Este campo es requerido"
            },
			NombreRazonSocialII: {
                required: "Este campo es requerido"
            },
			DireccionPpalII: {
                required: "Este campo es requerido"
            },
			TelefonoII: {
                required: "Este campo es requerido"
            },
			FaxII: {
                required: "Este campo es requerido"
            },
			pk_DepartamentoII: {
                required: "Este campo es requerido"
            },
			pk_MunicipioII: {
                required: "Este campo es requerido"
            },
			EmailII: {
                required: "Este campo es requerido"
            },
			CentroCostoTelefonoII: {
                required: "Este campo es requerido"
            },
			CentroCostoFaxII: {
                required: "Este campo es requerido"
            },
			DireccionCentroTrabajoII: {
                required: "Este campo es requerido"
            },
			pk_DeptoCentroCostoII: {
                required: "Este campo es requerido"
            },
			pk_MncpioCentroCostoII: {
                required: "Este campo es requerido"
            }
        }
    });
}


function GuardarParcial3(accordId){
	var booVal = false;
	var booVal1= true;
	if(accordId== 3)
	{
		if($("#boAccidenteTrabajo").is(':checked'))
			if($("#boMortal").is(':checked')){
				$("#fechamuerte").css( "display", "block");
				booVal = true;
			}
		
	}

	if(booVal)
		if($("#FechaMuerteIII").val()==""){
			booVal1=false;
		}
		else
			$("#fechamuerte").css( "display", "none");		
		
		
	ValidaGuardarFormulario3();
	if ($("#IncidentesAT3").valid()) {
		PopupPosition();
		GetProp(true);
		if(booVal1){
			$.ajax({
				type: 'POST',
				url: '/IncidentesAT/GuardarIncidenteAT3',
				data: $("#IncidentesAT3").serialize(),
				traditional: true,
				success: function (result) {
					OcultarPopupposition();
					swal("Estimado Usuario", "El Incidente AT ha sido Guardado con Éxito.", "success");
					GetProp(false);
					$( "#accordion" ).accordion({ active: 3 });
				}
			});
		}
	}
}


function ValidaGuardarFormulario3(){
	
	$("#IncidentesAT3").validate({
        errorClass: "error",
        rules: {
			TipoVinculacionIII: {
                required: true
            },
			NumeroIdentificacionIII: {
                required: true
            },
			PrimerApellidoIII: {
                required: true
            },
			SegundoApellidoIII: {
                required: true
            },
			PrimerNombreIII: {
                required: true
            },
			FechaNacimientoIII: {
                required: true
            },
			SexoIII: {
                required: true
            },
			EPSIII: {
                required: true
            },
			AFPIII: {
                required: true
            },
			ARLIII: {
                required: true
            },
			TelefonoIII: {
                required: true
            },
			FaxIII: {
                required: false
            },
			EmailIII: {
                required: false
            },
			DireccionCentroTrabajoIII: {
                required: true
            },
			ZonaIII: {
                required: true
            },
			CargoIII: {
                required: true
            },
			CodigoOcupacionIII: {
                required: true
            },
			OcupacionIII: {
                required: true
            },
			FechaIngresoIII: {
                required: false
            },
			TiempoOcupacionAIII: {
                required: false
            },
			TiempoOcupacionMIII: {
                required: false
            },
			AntiguedadAIII: {
                required: false
            },
			AntiguedadMIII: {
                required: false
            },
			SalarioHonorariosIII: {
                required: true
            },
			FechaMuerteIII: {
                required: false
            },
			AtencionOportunaIII: {
                required: false
            },
			FechaOcurrenciaIII: {
                required: true
            },
			HoraOcurrenciaIII: {
                required: true
            }
        },
        messages: {
			TipoVinculacionIII: {
                required: "Este campo es requerido"
            },
			NumeroIdentificacionIII: {
                required: "Este campo es requerido"
            },
			PrimerApellidoIII: {
                required: "Este campo es requerido"
            },
			SegundoApellidoIII: {
                required: "Este campo es requerido"
            },
			PrimerNombreIII: {
                required: "Este campo es requerido"
            },
			FechaNacimientoIII: {
                required: "Este campo es requerido"
            },
			SexoIII: {
                required: "Este campo es requerido"
            },
			EPSIII: {
                required: "Este campo es requerido"
            },
			AFPIII: {
                required: "Este campo es requerido"
            },
			ARLIII: {
                required: "Este campo es requerido"
            },
			TelefonoIII: {
                required: "Este campo es requerido"
            },
			FaxIII: {
                required: "Este campo es requerido"
            },
			EmailIII: {
                required: "Este campo es requerido"
            },
			DireccionCentroTrabajoIII: {
                required: "Este campo es requerido"
            },
			ZonaIII: {
                required: "Este campo es requerido"
            },
			CargoIII: {
                required: "Este campo es requerido"
            },
			CodigoOcupacionIII: {
               required: "Este campo es requerido"
            },
			OcupacionIII: {
                required: "Este campo es requerido"
            },
			FechaIngresoIII: {
                required: "Este campo es requerido"
            },
			TiempoOcupacionAIII: {
                required: "Este campo es requerido"
            },
			TiempoOcupacionMIII: {
                required: "Este campo es requerido"
            },
			AntiguedadAIII: {
                required: "Este campo es requerido"
            },
			AntiguedadMIII: {
                required: "Este campo es requerido"
            },
			SalarioHonorariosIII: {
                required: "Este campo es requerido"
            },
			FechaMuerteIII: {
                required: "Este campo es requerido"
            },
			AtencionOportunaIII: {
                required: "Este campo es requerido"
            },
			FechaOcurrenciaIII: {
                required: "Este campo es requerido"
            },
			HoraOcurrenciaIII: {
                required: "Este campo es requerido"
            }
        }
    });
}


function GuardarParcial4(){
	EnableDiaSemana(false);
	
	if($('#boDiaSemanaIVLU').is(':checked'))
		$('#stDiaSemanaIV').val("LU");
	
	if($('#boDiaSemanaIVMA').is(':checked'))
		$('#stDiaSemanaIV').val("MA");
	
	if($('#boDiaSemanaIVMI').is(':checked'))
		$('#stDiaSemanaIV').val("MI");
	
	if($('#boDiaSemanaIVJU').is(':checked'))
		$('#stDiaSemanaIV').val("JU");
	
	if($('#boDiaSemanaIVVI').is(':checked'))
		$('#stDiaSemanaIV').val("VI");
	
	if($('#boDiaSemanaIVSA').is(':checked'))
		$('#stDiaSemanaIV').val("SA");
	
	if($('#boDiaSemanaIVDO').is(':checked'))
		$('#stDiaSemanaIV').val("DO");
	
    
	ValidaGuardarFormulario4();
	if ($("#IncidentesAT4").valid()) {
		PopupPosition();
		GetProp(true);
		EnableDiaSemana(true);
		$.ajax({
			type: 'POST',
			url: '/IncidentesAT/GuardarIncidenteAT4',
			data: $("#IncidentesAT4").serialize(),
			traditional: true,
			success: function (result) {
				OcultarPopupposition();
				swal("Estimado Usuario", "El Incidente AT ha sido Guardado con Éxito.", "success");
				GetProp(false);
				EnableDiaSemana(true);
				$( "#accordion" ).accordion({ active: 4 });
			}
		});
	}
}

function EnableDiaSemana(boValor)
{
	$('#boDiaSemanaIVLU').prop("disabled", boValor);
	$('#boDiaSemanaIVMA').prop("disabled", boValor);
	$('#boDiaSemanaIVMI').prop("disabled", boValor);
	$('#boDiaSemanaIVJU').prop("disabled", boValor);
	$('#boDiaSemanaIVVI').prop("disabled", boValor);
	$('#boDiaSemanaIVSA').prop("disabled", boValor);
	$('#boDiaSemanaIVDO').prop("disabled", boValor);
}

function ValidaGuardarFormulario4(){
	
	$("#IncidentesAT4").validate({
        errorClass: "error",
        rules: {
			
			LaborHabitualIV: {
                required: true
            },
			TipoIncidenteIV: {
                required: true
            },
			EspecTipoIncidenteIV: {
                required: true
            },
			IPSAtendioIV: {
                required: true
            },
			DepartamentoIV: {
                required: true
            },
			MncpioIV: {
                required: true
            },
			ZonaIV: {
                required: true
            },
			TiempoLaboradoPrevioIV: {
                required: true
            },
			LugarExactoIV: {
                required: true
            },
			SitioExactoIV: {
                required: true
            },
			EspecifiqueIV:{
				required : boOtroSitioIV
			}
        },
        messages: {
			LaborHabitualIV: {
                required: "Este campo es requerido"
            },
			TipoIncidenteIV: {
                required: "Este campo es requerido"
            },
			EspecTipoIncidenteIV: {
                required: "Este campo es requerido"
            },
			IPSAtendioIV: {
                required: "Este campo es requerido"
            },
			DepartamentoIV: {
                required: "Este campo es requerido"
            },
			MncpioIV: {
                required: "Este campo es requerido"
            },
			ZonaIV: {
                required: "Este campo es requerido"
            },
			TiempoLaboradoPrevioIV: {
                required: "Este campo es requerido"
            },
			LugarExactoIV: {
                required: "Este campo es requerido"
            },
			SitioExactoIV: {
                required: "Este campo es requerido"
            },
			EspecifiqueIV : {
				required: "Este campo es requerido"
			}
        }
    });
}


function GuardarParcial5(){
	ValidaGuardarFormulario5();
	if ($("#IncidentesAT5").valid()) {
		PopupPosition();
		GetProp(true);
		$.ajax({
			type: 'POST',
			url: '/IncidentesAT/GuardarIncidenteAT5',
			data: $("#IncidentesAT5").serialize(),
			traditional: true,
			success: function (result) {
				OcultarPopupposition();
				swal("Estimado Usuario", "El Incidente AT ha sido Guardado con Éxito.", "success");
				GetProp(false);
				$( "#accordion" ).accordion({ active: 5 });
			}
		});
	}
}


function ValidaGuardarFormulario5(){
	$("#IncidentesAT5").validate({
        errorClass: "error",
        rules: {
			EventosSimilaresV: {
                required: true
            },
			NumeroPersonasV: {
                required: true
            },
			OtrosIncidentesV: {
                required: true
            },
			EventoSimilarV: {
                required: true
            },
			CondicionPrioritariaV: {
                required: true
            },
			TrabajadorInvolucradoV: {
                required: true
            },
			PanoramaRiesgoV: {
                required: true
            },
			DescripcionAccidenteV: {
                required: true
            }
        },
        messages: {
			
			EventosSimilaresV: {
                required: "Este campo es requerido"
            },
			NumeroPersonasV: {
                required: "Este campo es requerido"
            },
			OtrosIncidentesV: {
                required: "Este campo es requerido"
            },
			EventoSimilarV: {
                required: "Este campo es requerido"
            },
			CondicionPrioritariaV: {
                required: "Este campo es requerido"
            },
			TrabajadorInvolucradoV: {
                required: "Este campo es requerido"
            },
			PanoramaRiesgoV: {
                required: "Este campo es requerido"
            },
			DescripcionAccidenteV: {
                required: "Este campo es requerido"
            }
        }
    });
}

function GuardarParcial6(){
	ValidaGuardarFormulario6();
	if ($("#IncidentesAT6").valid()) {
		PopupPosition();
		GetProp(true);
		$.ajax({
			type: 'POST',
			url: '/IncidentesAT/GuardarIncidenteAT6',
			data: $("#IncidentesAT6").serialize(),
			traditional: true,
			success: function (result) {
				OcultarPopupposition();
				swal("Estimado Usuario", "El Incidente AT ha sido Guardado con Éxito.", "success");
				GetProp(false);
				$( "#accordion" ).accordion({ active: 6 });
			}
		});
	}
}

function ValidaGuardarFormulario6(){
	
	$("#IncidentesAT6").validate({
        errorClass: "error",
        rules: {
			AgenteVI: {
                required: true
            },
			MaterialVI: {
                required: false
            },
			ModeloVI: {
                required: false
            },
			ReferenciaVI: {
                required: false
            },
			PesoVI: {
                required: false
            },
			PesoUnidadMedidaVI: {
                required: false
            },
			AlturaVI: {
                required: false
            },
			AnchoVI: {
                required: false
            },
			VolumenVI: {
                required: false
            },
			ProfundidadVI: {
                required: false
            },
			VelocidadVI: {
                required: false
            },
			TiempoUsoVI: {
                required: false
            },
			FechaMantenimientoVI: {
                required: false
            },
			ReparadoVI: {
                required: false
            },
			ExplosivosVI: {
                required: false
            },
			ExplosivosUnidadMedidaVI: {
                required: false
            },
			GasesVI: {
                required: false
            },
			GasesCantidadVI: {
                required: false
            },
			TemperaturaUnidadMedidaVI: {
                required: false
            },
			SustanciaUnidadMedidaVI: {
                required: false
            },
			SustanciaCantidadVI: {
                required: false
            },
			VoltajeElectricoVI: {
                required: false
            },
			VoltajeElectricoUnidadMedidaVI: {
                required: false
            },
			UnidadMedidaVI: {
                required: false
            },
			DetallesAdicionalesVI: {
                required: true
            },
			EPPVI: {
                required: true
            },
			TrabajadorEPPVI: {
                required: true
            },
			ObservacionesVI: {
                required: true
            }
        },
        messages: {
			AgenteVI: {
                required: "Este campo es requerido"
            },
			MaterialVI: {
                required: "Este campo es requerido"
            },
			ModeloVI: {
                required: "Este campo es requerido"
            },
			ReferenciaVI: {
                required: "Este campo es requerido"
            },
			PesoVI: {
                required: "Este campo es requerido"
            },
			PesoUnidadMedidaVI: {
                required: "Este campo es requerido"
            },
			AlturaVI: {
                required: "Este campo es requerido"
            },
			AnchoVI: {
                required: "Este campo es requerido"
            },
			VolumenVI: {
                required: "Este campo es requerido"
            },
			ProfundidadVI: {
                required: "Este campo es requerido"
            },
			VelocidadVI: {
                required: "Este campo es requerido"
            },
			TiempoUsoVI: {
                required: "Este campo es requerido"
            },
			FechaMantenimientoVI: {
                required: "Este campo es requerido"
            },
			ReparadoVI: {
                required: "Este campo es requerido"
            },
			ExplosivosVI: {
                required: "Este campo es requerido"
            },
			ExplosivosUnidadMedidaVI: {
                required: "Este campo es requerido"
            },
			GasesVI: {
                required: "Este campo es requerido"
            },
			GasesCantidadVI: {
                required: "Este campo es requerido"
            },
			TemperaturaUnidadMedidaVI: {
                required: "Este campo es requerido"
            },
			SustanciaUnidadMedidaVI: {
                required: "Este campo es requerido"
            },
			SustanciaCantidadVI: {
                required: "Este campo es requerido"
            },
			VoltajeElectricoVI: {
                required: "Este campo es requerido"
            },
			VoltajeElectricoUnidadMedidaVI: {
                required: "Este campo es requerido"
            },
			UnidadMedidaVI: {
                required: "Este campo es requerido"
            },
			DetallesAdicionalesVI: {
                required: "Este campo es requerido"
            },
			EPPVI: {
                required: "Este campo es requerido"
            },
			TrabajadorEPPVI: {
                required: "Este campo es requerido"
            },
			ObservacionesVI: {
                required: "Este campo es requerido"
            }
        }
    });
}


function GuardarParcial7(){
	ValidaGuardarFormulario7();
	if ($("#IncidentesAT7").valid()) {
		PopupPosition();
		GetProp(true);
		$.ajax({
			type: 'POST',
			url: '/IncidentesAT/GuardarIncidenteAT7',
			data: $("#IncidentesAT7").serialize(),
			traditional: true,
			success: function (result) {
				OcultarPopupposition();
				swal("Estimado Usuario", "El Incidente AT ha sido Guardado con Éxito.", "success");
				GetProp(false);
				$( "#accordion" ).accordion({ active: 7 });
			}
		});
	}
}

function ValidaGuardarFormulario7(){
	$("#IncidentesAT7").validate({
        errorClass: "error",
        rules: {
			CodTipoLesionVII: {
                required: true
            },
			TipoLesionVII: {
                required: true
            },
			CodigoParteCuerpoAfectadaVII: {
                required: true
            },
			CodMecaAccideneteVII: {
                required: true
            },
			MecanismoAccidenteVII: {
                required: true
            },
			CodAgenteAccideneteVII: {
                required: true
            },
			AgenteAccidenteVII: {
                required: true
            },
			CodFactoresPersonalesVII1: {
                required: true
            },
			FactoresPersonalesVII1: {
                required: true
            },
			CodFactoresPersonalesVII2: {
                required: true
            },
			FactoresPersonalesVII2: {
                required: true
            },
			CodActoSubestandarVII1: {
                required: true
            },
			ActosSubestandarVII1: {
                required: true
            },
			CodActoSubestandarVII2: {
                required: true
            },
			ActosSubestandarVII2: {
                required: true
            },
			CodFactoresTrabajoVII1: {
                required: true
            },
			FactoresTrabajoVII1: {
                required: true
            },
			CodFactoresTrabajoVII2: {
                required: true
            },
			FactoresTrabajoVII2: {
                required: true
            },
			CodCondAmbientalesVII1: {
                required: true
            },
			CondAmbientalesVII1: {
                required: true
            },
			CodCondAmbientalesVII2: {
                required: true
            },
			CondAmbientalesVII2: {
                required: true
            }
        },
        messages: {
			CodTipoLesionVII: {
                required: "Este campo es requerido"
            },
			TipoLesionVII: {
                required: "Este campo es requerido"
            },
			CodigoParteCuerpoAfectadaVII: {
                required: "Este campo es requerido"
            },
			CodMecaAccideneteVII: {
                required: "Este campo es requerido"
            },
			MecanismoAccidenteVII: {
                required: "Este campo es requerido"
            },
			CodAgenteAccideneteVII: {
                required: "Este campo es requerido"
            },
			AgenteAccidenteVII: {
                required: "Este campo es requerido"
            },
			CodFactoresPersonalesVII1: {
                required: "Este campo es requerido"
            },
			FactoresPersonalesVII1: {
                required: "Este campo es requerido"
            },
			CodFactoresPersonalesVII2: {
                required: "Este campo es requerido"
            },
			FactoresPersonalesVII2: {
                required: "Este campo es requerido"
            },
			CodActoSubestandarVII1: {
                required: "Este campo es requerido"
            },
			ActosSubestandarVII1: {
                required: "Este campo es requerido"
            },
			CodActoSubestandarVII2: {
                required: "Este campo es requerido"
            },
			ActosSubestandarVII2: {
                required: "Este campo es requerido"
            },
			CodFactoresTrabajoVII1: {
                required: "Este campo es requerido"
            },
			FactoresTrabajoVII1: {
                required: "Este campo es requerido"
            },
			CodFactoresTrabajoVII2: {
                required: "Este campo es requerido"
            },
			FactoresTrabajoVII2: {
                required: "Este campo es requerido"
            },
			CodCondAmbientalesVII1: {
                required: "Este campo es requerido"
            },
			CondAmbientalesVII1: {
                required: "Este campo es requerido"
            },
			CodCondAmbientalesVII2: {
                required: "Este campo es requerido"
            },
			CondAmbientalesVII2: {
                required: "Este campo es requerido"
            }
        }
    });
}


function DiligenciarAnexo(){
	GetProp(false);
	$( "#accordion" ).accordion({ active: 13 });
}

function GuardarParcial8(){
    if($("#myFile8").val()!="")
		$("#hmyFile8").val($("#myFile8").val());
	else
		$("#hmyFile8").val($('#dmyFile8').text());
	
	PopupPosition();
	GetProp(true);
	$.ajax({
		type: 'POST',
		url: '/IncidentesAT/GuardarIncidenteAT8',
		data: $("#IncidentesAT8").serialize(),
		traditional: true,
		success: function (result) {
			OcultarPopupposition();
			swal("Estimado Usuario", "El Incidente AT ha sido Guardado con Éxito.", "success");
			GetProp(false);
			$( "#accordion" ).accordion({ active: 8 });
		}
	});
}


function GuardarParcial9(){
	
	if($("#myFile3").val()!="")
		$("#hmyFile3").val($("#myFile3").val());
	else
		$("#hmyFile3").val($('#dmyFile3').text());
	
	
	if($("#myFile4").val()!="")
		$("#hmyFile4").val($("#myFile4").val());
	else
		$("#hmyFile4").val($('#dmyFile4').text());
	
	
	if($("#myFile5").val()!="")
		$("#hmyFile5").val($("#myFile5").val());
	else
		$("#hmyFile5").val($('#dmyFile5').text());
	
	
	if($("#myFile6").val()!="")
		$("#hmyFile6").val($("#myFile6").val());
	else
		$("#hmyFile6").val($('#dmyFile6').text());
	

	if($("#myFile7").val()!="")
		$("#hmyFile7").val($("#myFile7").val());
	else
		$("#hmyFile7").val($('#dmyFile7').text());
	
	
	if($("#myFile9").val()!="")
		$("#hmyFile9").val($("#myFile9").val());
	else
		$("#hmyFile9").val($('#dmyFile9').text());
	
	
	
	if($("#myFile10").val()!="")
		$("#hmyFile10").val($("#myFile10").val());
	else
		$("#hmyFile10").val($('#dmyFile10').text());


	ValidaGuardarFormulario9();
	if ($("#IncidentesAT9").valid()) {
		PopupPosition();
		GetProp(true);
		$.ajax({
			type: 'POST',
			url: '/IncidentesAT/GuardarIncidenteAT9',
			data: $("#IncidentesAT9").serialize(),
			traditional: true,
			success: function (result) {
				OcultarPopupposition();
				swal("Estimado Usuario", "El Incidente AT ha sido Guardado con Éxito.", "success");
				GetProp(false);
				$( "#accordion" ).accordion({ active: 9 });
			}
		});
	}
}

function ValidaGuardarFormulario9(){
	$("#IncidentesAT9").validate({
        errorClass: "error",
        rules: {
			TipoIdentJefeInmediantoIX: {
                required: false
            },
			NumIdentJefeInmediatoIX: {
                required: false
            },
			JefeInmediatoNombresIX: {
                required: false
            },
			JefeInmediatoCargoIX: {
                required: false
            },
			TipoIdentEncargadoPSOIX: {
                required: false
            },
			NumIdentPSOIX: {
                required: false
            },
			EncargadoPSONombresIX: {
                required: false
            },
			EncargadoPSOCargoIX: {
                required: false
            },
			TipoIdentCOPASOIX: {
                required: false
            },
			COPASONumIdentIX: {
                required: false
            },
			COPASONombresCompletosIX: {
                required: false
            },
			COPASOCargoIX: {
                required: false
            },
			TipoIdentEncargadoPSOIX: {
                required: false
            },
			NumeroIdentBrigadistaIX: {
                required: false
            },
			BrigadistaNombresIX: {
                required: false
            },
			BrigadistaCargoIX: {
                required: false
            },
			TipoIdentParticipanteIX: {
                required: false
            },
			NumIdentParticipanteIX: {
                required: false
            },
			ParticipanteNombreIX: {
                required: false
            },
			ParticipanteCargoIX: {
                required: false
            },
			TipoIdentAnalisisIX: {
                required: false
            },
			NumIdentAnalisisIX: {
                required: false
            },
			CargoAnalisisIX: {
                required: false
            },
			EmpresaRepresentaIX: {
                required: false
            },
			ObservacionEspecialistaIX: {
                required: false
            }
        },
        messages: {
			TipoIdentJefeInmediantoIX: {
                required: "Este campo es requerido"
            },
			NumIdentJefeInmediatoIX: {
                required: "Este campo es requerido"
            },
			JefeInmediatoNombresIX: {
                required: "Este campo es requerido"
            },
			JefeInmediatoCargoIX: {
                required: "Este campo es requerido"
            },
			TipoIdentEncargadoPSOIX: {
                required: "Este campo es requerido"
            },
			NumIdentPSOIX: {
                required: "Este campo es requerido"
            },
			EncargadoPSONombresIX: {
                required: "Este campo es requerido"
            },
			EncargadoPSOCargoIX: {
                required: "Este campo es requerido"
            },
			TipoIdentCOPASOIX: {
                required: "Este campo es requerido"
            },
			COPASONumIdentIX: {
                required: "Este campo es requerido"
            },
			COPASONombresCompletosIX: {
                required: "Este campo es requerido"
            },
			COPASOCargoIX: {
                required: "Este campo es requerido"
            },
			TipoIdentEncargadoPSOIX: {
                required: "Este campo es requerido"
            },
			NumeroIdentBrigadistaIX: {
                required: "Este campo es requerido"
            },
			BrigadistaNombresIX: {
                required: "Este campo es requerido"
            },
			BrigadistaCargoIX: {
                required: "Este campo es requerido"
            },
			TipoIdentParticipanteIX: {
                required: "Este campo es requerido"
            },
			NumIdentParticipanteIX: {
                required: "Este campo es requerido"
            },
			ParticipanteNombreIX: {
                required: "Este campo es requerido"
            },
			ParticipanteCargoIX: {
                required: "Este campo es requerido"
            },
			TipoIdentAnalisisIX: {
                required: "Este campo es requerido"
            },
			NumIdentAnalisisIX: {
                required: "Este campo es requerido"
            },
			CargoAnalisisIX: {
                required: "Este campo es requerido"
            },
			EmpresaRepresentaIX: {
                required: "Este campo es requerido"
            },
			ObservacionEspecialistaIX: {
                required: "Este campo es requerido"
            }
        }
    });
}


function GuardarParcial10(){
	
	PopupPosition();
	GetProp(true);
	$.ajax({
		type: 'POST',
		url: '/IncidentesAT/GuardarIncidenteAT10',
		data: $("#IncidentesAT10").serialize(),
		traditional: true,
		success: function (result) {
			OcultarPopupposition();
			swal("Estimado Usuario", "El Incidente AT ha sido Guardado con Éxito.", "success");
			GetProp(false);
			$( "#accordion" ).accordion({ active: 10 });
		}
	});
}

function GuardarParcial11(){
	if($("#myFile11").val()!="")
		$("#hmyFile11").val($("#myFile11").val());
	else
		$("#hmyFile11").val($('#dmyFile11').text());
	
	
	PopupPosition();
	GetProp(true);
	$.ajax({
		type: 'POST',
		url: '/IncidentesAT/GuardarIncidenteAT11',
		data: $("#IncidentesAT11").serialize(),
		traditional: true,
		success: function (result) {
			OcultarPopupposition();
			swal("Estimado Usuario", "El Incidente AT ha sido Guardado con Éxito.", "success");
			GetProp(false);
			$( "#accordion" ).accordion({ active: 11 });
		}
	});
}

function GuardarParcial12(){
	if($("#myFile12").val()!="")
		$("#hmyFile12").val($("#myFile12").val());
	else
		$("#hmyFile12").val($('#dmyFile12').text());
	
	PopupPosition();
	GetProp(true);
	$.ajax({
		type: 'POST',
		url: '/IncidentesAT/GuardarIncidenteAT12',
		data: $("#IncidentesAT12").serialize(),
		traditional: true,
		success: function (result) {
			OcultarPopupposition();
			swal("Estimado Usuario", "El Incidente AT ha sido Guardado con Éxito.", "success");
			GetProp(false);
			$( "#accordion" ).accordion({ active: 12 });
		}
	});
}


function GuardarParcial13(){
	if($("#myFile13").val()!="")
		$("#hmyFile13").val($("#myFile13").val());
	else
		$("#hmyFile13").val($('#dmyFile13').text());
	
	PopupPosition();
	GetProp(true);
	$.ajax({
		type: 'POST',
		url: '/IncidentesAT/GuardarIncidenteAT13',
		data: $("#IncidentesAT13").serialize(),
		traditional: true,
		success: function (result) {
			OcultarPopupposition();
			swal("Estimado Usuario", "El Incidente AT ha sido Guardado con Éxito.", "success");
			GetProp(false);
			$( "#accordion" ).accordion({ active: 13 });
		}
	});
}


function GuardarIncidenteATAnexos(){
	if($("#myFile14").val()!="")
		$("#hmyFile14").val($("#myFile14").val());
	else
		$("#hmyFile14").val($('#dmyFile14').text());
	
	
	ValidaGuardarFormularioAdjuntos();
	if ($("#IncidentesATAnexos").valid()) {
		PopupPosition();
		GetProp(true);
		$.ajax({
			type: 'POST',
			url: '/IncidentesAT/GuardarIncidenteATAnexos',
			data: $("#IncidentesATAnexos").serialize(),
			traditional: true,
			success: function (result) {
				OcultarPopupposition();
				swal("Estimado Usuario", "El Incidente AT ha sido Guardado con Éxito.", "success");
				GetProp(false);
				$( "#accordion" ).accordion({ active: 0 });
			}
		});
	}
}

function ValidaGuardarFormularioAdjuntos(){
	$("#IncidentesATAnexos").validate({
        errorClass: "error",
        rules: {
			AnexoFechaIncidente: {
				required: true
			},
			AnexoFechaTestimonio: {
				required: true
			},
			AnexoNumIdentificacion: {
				required: true
			},
			AnexoNombres: {
				required: true
			},
			AnexoCargo: {
				required: true
			},
			AnexoDondeSucedio: {
				required: true
			},
			AnexoPorqueSucedio: {
				required: true
			},
			AnexoPrevenir: {
				required: true
			},
			AnexoAdicionar: {
				required: true
			},
			myFile14: {
				required: true
			}
        },
        messages: {
			AnexoFechaIncidente: {
			required: "Este campo es requerido"
			},
			AnexoFechaTestimonio: {
			required: "Este campo es requerido"
			},
			AnexoNumIdentificacion: {
			required: "Este campo es requerido"
			},
			AnexoNombres: {
			required: "Este campo es requerido"
			},
			AnexoCargo: {
			required: "Este campo es requerido"
			},
			AnexoDondeSucedio: {
			required: "Este campo es requerido"
			},
			AnexoPorqueSucedio: {
			required: "Este campo es requerido"
			},
			AnexoPrevenir: {
			required: "Este campo es requerido"
			},
			AnexoAdicionar: {
			required: "Este campo es requerido"
			},
			myFile14: {
				required: "Este campo es requerido"
			}
        }
    });
	
}

function soloNumeros(e){
	var key = window.Event ? e.which : e.keyCode
	return (key >= 48 && key <= 57)
}
	
function ValOtro(val)
{
	if(val==9){
		$("#divreq").css("display", "block");
		$("#EspecifiqueIV").focus();
	}else
		$("#divreq").css("display", "none");
	
}


function GetTipoLesion(val){
	$.ajax({
			type: 'POST',
			url: '/IncidentesAT/GetTipoLesion',
			data: { PK_Tipo_De_Lesion : val },
			success: function (result) {
				if(result=='0')
				{
					$("#CodTipoLesionVII").val("");
					$("#CodTipoLesionVII").focus();
				}
				else
					$("#TipoLesionVII").val(result);
					
			}
		});
}

function GetParteCuerpo(val){
	$.ajax({
			type: 'POST',
			url: '/IncidentesAT/GetParteCuerpo',
			data: { PK_PDCA_Corto : val },
			success: function (result) {
				if(result=='0')
				{
					$("#CodigoParteCuerpoAfectadaVII").val("");
					$("#CodigoParteCuerpoAfectadaVII").focus();
				}
				else
					$("#textfield74").val(result);
				
			}
		});
}

function GetMecanismo(val){
	$.ajax({
			type: 'POST',
			url: '/IncidentesAT/GetMecanismo',
			data: { PK_Mecanismo : val },
			success: function (result) {
				if(result=='0')
				{
					$("#CodMecaAccideneteVII").val("");
					$("#CodMecaAccideneteVII").focus();
				}
				else
					$("#MecanismoAccidenteVII").val(result);
			
			
			}
		});
}

function GetAgente(val){
	$.ajax({
			type: 'POST',
			url: '/IncidentesAT/GetAgente',
			data: { PK_Agente : val },
			success: function (result) {
				if(result=='0')
				{
					$("#CodAgenteAccideneteVII").val("");
					$("#CodAgenteAccideneteVII").focus();
				}
				else
					$("#AgenteAccidenteVII").val(result);
				
				
			}
		});
}

function GetFactoresPersonales(val){
	$.ajax({
			type: 'POST',
			url: '/IncidentesAT/GetFactoresPersonales',
			data: { PK_FactoresPersonales : val },
			success: function (result) {				
				if(result=='0')
				{
					$("#CodFactoresPersonalesVII1").val("");
					$("#CodFactoresPersonalesVII1").focus();
				}
				else
					$("#FactoresPersonalesVII1").val(result);
				
			
			}
		});
}

function GetFactoresPersonales1(val){
	$.ajax({
			type: 'POST',
			url: '/IncidentesAT/GetFactoresPersonales',
			data: { PK_FactoresPersonales : val },
			success: function (result) {
				if(result=='0')
				{
					$("#CodFactoresPersonalesVII2").val("");
					$("#CodFactoresPersonalesVII2").focus();
				}
				else
					$("#FactoresPersonalesVII2").val(result);
			
			
			}
		});
}

function GetFactoresTrabajo(val){
	$.ajax({
			type: 'POST',
			url: '/IncidentesAT/GetFactoresTrabajo',
			data: { PK_Factores_De_Trabajo : val },
			success: function (result) {				
			if(result=='0')
			{
				$("#CodFactoresTrabajoVII1").val("");
				$("#CodFactoresTrabajoVII1").focus();
			}
			else
				$("#FactoresTrabajoVII1").val(result);
		
			
			}
		});
}

function GetFactoresTrabajo1(val){
	$.ajax({
			type: 'POST',
			url: '/IncidentesAT/GetFactoresTrabajo',
			data: { PK_Factores_De_Trabajo : val },
			success: function (result) {
			if(result=='0')
			{
				$("#CodFactoresTrabajoVII2").val("");
				$("#CodFactoresTrabajoVII2").focus();
			}
			else
				$("#FactoresTrabajoVII2").val(result);
		
			}
		});
}

function GetActosSubestandar(val){
	$.ajax({
			type: 'POST',
			url: '/IncidentesAT/GetActosSubestandar',
			data: { PK_Actos_Subestandar : val },
			success: function (result) {
			if(result=='0')
			{
				$("#CodActoSubestandarVII1").val("");
				$("#CodActoSubestandarVII1").focus();
			}
			else
				$("#ActosSubestandarVII1").val(result);	
				
			}
		});
}

function GetActosSubestandar1(val){
	$.ajax({
			type: 'POST',
			url: '/IncidentesAT/GetActosSubestandar',
			data: { PK_Actos_Subestandar : val },
			success: function (result) {			
			if(result=='0')
			{
				$("#CodActoSubestandarVII2").val("");
				$("#CodActoSubestandarVII2").focus();
			}
			else
				$("#ActosSubestandarVII2").val(result);	
			
			
			}
		});
}

function GetCondicionesAmbientales(val){
	$.ajax({
			type: 'POST',
			url: '/IncidentesAT/GetCondicionesAmbientales',
			data: { PK_Condiciones_Ambientales_Subestandar : val },
			success: function (result) {
			if(result=='0')
			{
				$("#CodCondAmbientalesVII1").val("");
				$("#CodCondAmbientalesVII1").focus();
			}
			else
				$("#CondAmbientalesVII1").val(result);	
			
			
			}
		});
}

function GetCondicionesAmbientales1(val){
	$.ajax({
			type: 'POST',
			url: '/IncidentesAT/GetCondicionesAmbientales',
			data: { PK_Condiciones_Ambientales_Subestandar : val },
			success: function (result) {
			if(result=='0')
			{
				$("#CodCondAmbientalesVII2").val("");
				$("#CodCondAmbientalesVII2").focus();
			}
			else
				$("#CondAmbientalesVII2").val(result);	
			
			
			}
		});
}

function Refrescar(){
	$("#AnexoFechaIncidente").val("");
	$("#AnexoFechaTestimonio").val("");
	$("#AnexoNombres").val("");
	$("#AnexoCargo").val("");
	$("#AnexoNumIdentificacion").val("");
	$("#AnexoDondeSucedio").val("");
	$("#AnexoPorqueSucedio").val("");
	$("#AnexoPrevenir").val("");
	$("#AnexoAdicionar").val("");
	$("#AnexoFirma").val("");
}
