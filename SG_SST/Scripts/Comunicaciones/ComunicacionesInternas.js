$(function () {
    ConstruirDatePickerPorElemento("vigencia");
});
//onchange=\"CargarControl(" + intId + "\)\"

$(document).ready(function () {
    var ntop = 5;
    $("#add").click(function () {
        var intId = $("#buildyourform div").length + 1;
        var fieldWrapper = $("<div class=\"fieldwrapper\" id=\"field" + intId + "\"/>");
        var fName = $("<input type=\"text\" class=\"fieldname dinamic_input\" size=\"60\" />");
        var fType = $("<select name=\"myselect\" class=\"fieldtype dinamic_input\" data-field=\"name_selector\" onchange=\"CargarControl(" + intId + ",this.value)\"><option value=\"label_etiqueta\">Etiqueta Titulo</option><option value=\"label\">Etiqueta Seleccion Multiple</option><option value=\"radio\">Selección Múltiple</option><option value=\"checkbox\">Casilla de Verificación</option><option value=\"textbox\">Respuesta Corta</option><option value=\"textarea\">Párrafo</option><option value=\"escala_titulo\">Escala Lineal Titulo (1 a 5)</option><option value=\"escala_inicio\">Escala Lineal Etiqueta Inicial (1 a 5)</option><option value=\"escala_fin\">Escala Lineal Etiqueta Final (1 a 5)</option><option value=\"fecha\">Fecha (formato DD/MM/AAAA)</option><option value=\"hora\">Hora</option></select>");
        var removeButton = $("<a title=\"Eliminar Pregunta\" class=\"btn btn-md btn-search\" style=\"margin-bottom:2%\"><i class=\"glyphicon glyphicon-erase\"></i></a>");
        removeButton.click(function () {
            $(this).parent().remove();
        });
        //var fescala = $("<br /><div id=\"mydiv_" + intId + "\"></div>");
        fieldWrapper.append(fName);
        fieldWrapper.append(fType);
        fieldWrapper.append(removeButton);
        //fieldWrapper.append(fescala);//<option value=\"escala\">Escala Lineal</option>
        $("#buildyourform").append(fieldWrapper);
    });
    $("#preview").click(function () {
        $("#yourform").remove();
        var radiobutton = "";
        var fieldSet = $("<fieldset id=\"yourform\"><legend>" + $("#Titulo").val() + "</legend></fieldset>");
        var Html = "<table id=\"tblEncuesta\" border=\"0\"  style=\"width:auto;\">";
        var cont_fecha = 0;
        var cont_hora = 0;
		var escalaini = "";
		var escalafin = "";
        $("#buildyourform div").each(function () {
            Html += "<tr class=\"noborder\">";
            var id = "input" + $(this).attr("id").replace("field", "");
            if($(this).find("select.fieldtype").first().val()!="escala_inicio" && $(this).find("select.fieldtype").first().val()!="escala_fin")
				Html += "<td class=\"noborder\"><label for=\"" + id + "\">" + $(this).find("input.fieldname").first().val() + "</label></td>";
            
			var input;
			var Html1 = "";
			if($(this).find("select.fieldtype").first().val()=="escala_inicio" || $(this).find("select.fieldtype").first().val()=="escala_fin")
			{
				var escala_fin = $(this).find("select.fieldtype").first().val();

					if(	escala_fin == "escala_inicio")
						escalaini = $(this).find("input.fieldname").first().val();
						
				
					if(	escala_fin == "escala_fin")
						escalafin = $(this).find("input.fieldname").first().val();
						

					Html1 ="<table style=\"width:auto;\" border=\"0\">";
					Html1 +="<tr class=\"noborder\">";
					Html1 +="<td class=\"noborder\"><label for=\"" + id + "\">" + escalaini + "</label></td>";
					Html1 +="<td class=\"noborder\">1&nbsp;<input type=\"radio\" id=\"" + id + "\" name=\"" + id + "\" /></td>";
					Html1 +="<td class=\"noborder\">2&nbsp;<input type=\"radio\" id=\"" + id + "\" name=\"" + id + "\" /></td>";
					Html1 +="<td class=\"noborder\">3&nbsp;<input type=\"radio\" id=\"" + id + "\" name=\"" + id + "\" /></td>";
					Html1 +="<td class=\"noborder\">4&nbsp;<input type=\"radio\" id=\"" + id + "\" name=\"" + id + "\" /></td>";
					Html1 +="<td class=\"noborder\">5&nbsp;<input type=\"radio\" id=\"" + id + "\" name=\"" + id + "\" /></td>";
					Html1 +="<td class=\"noborder\"><label for=\"" + id + "\">" + escalafin + "</label></td>";
					Html1 +="</tr>";
					Html1 +="</table>";
			}
			

			if($(this).find("select.fieldtype").first().val()=="escala_fin")
				Html += "<td colspan=\"3\" class=\"noborder\">"+Html1+"</td>"

            switch ($(this).find("select.fieldtype").first().val()) {
                case "label":
                    radiobutton = id;
                    Html += "<td class=\"noborder\"><label id=\"" + id + "\" name=\"" + id + "\"></label></td>";
                    break;
				case "escala_titulo":
                    Html += "<td class=\"noborder\"><label id=\"" + id + "\" name=\"" + id + "\"></label></td>";
                    break;
                case "radio":
                    Html += "<td class=\"noborder\"><input type=\"radio\" id=\"radio_op_" + radiobutton + "\" name=\"radio_op_" + radiobutton + "\" /></td>";
                    break;
                case "checkbox":
                    Html += "<td class=\"noborder\"><input type=\"checkbox\" id=\"" + id + "\" name=\"" + id + "\" /></td>";
                    break;
                case "textbox":
                    Html += "<td class=\"noborder\"><input type=\"text\" id=\"" + id + "\" name=\"" + id + "\" class=\"form-control\" style=\"width:200%;\"/></td>";
                    break;
                case "textarea":
                    Html += "<td class=\"noborder\"><textarea id=\"" + id + "\" name=\"" + id + "\" class=\"form-control\" style=\"width:200%;\"></textarea></td>";
                    break;
                case "fecha":
                    cont_fecha = cont_fecha + 1;
                    Html += "<td class=\"noborder\"><input type=\"text\" id=\"campofecha_" + cont_fecha + "\" name=\"campofecha_" + cont_fecha + "\" class=\"form-control\" onclick=\"CargarFechas(this.id)\" onfocus=\"CargarFechas(this.id)\" readonly/></td>";
                    break;
                case "hora":
                    cont_hora = cont_hora + 1;
                    Html += "<td class=\"noborder\"><input  type=\"text\" id=\"campohora_" + cont_hora + "\" name=\"campohora_" + cont_hora + "\" class=\"form-control\" onclick=\"CargarHoras(this.id)\" onfocus=\"CargarHoras(this.id)\" /></td>";
                    break;
            }
            Html += "</tr>";
        });
        fieldSet.append(Html);
        Html += "</table>";
        $("#myform").append(fieldSet);
    });
});

function CargarControl(id, val) {
    if (val == "escala") {
        var html = '<table width="100%" class="noborder">';
        html += '<tr class="noborder">';
        html += '<td class="noborder" width="60">Etiqueta Inicio</td>';
        html += '<td class="noborder" width="186"><input class="fieldname dinamic_input" type="text" style="width:80%;"/></td>';
        html += '<td class="noborder" width="19">Etiqueta Fin</td>';
        html += '<td class="noborder" width="186"><input class="fieldname dinamic_input" type="text" style="width:80%;"/></td>';
        html += '</tr>';
        html += '</table>';
        $("#mydiv_" + id).html(html);
    }
}


function CargarFechas(val) {
    DatePickerPorElemento(val);
}

function CargarHoras(val) {
    $("#" + val + "").timepicker();
}

function VistaPrevia() {
    $('#myModal4').modal('show');
}

function DatePickerPorElemento(idElemento) {
    $.datepicker.setDefaults($.datepicker.regional["es"]);
    if ($('#' + idElemento).length > 0) {
        $('#' + idElemento).datepicker({
            firstDay: 1,
            format: "dd/mm/yyyy",
            language: 'es',
            autoclose: true,
            changeMonth: true,
            changeYear: true
        });
    }
}

var class_css_header = 'style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center; vertical-align:middle; text-transform:uppercase"';
var class_css = 'style="border-right: 2px solid lightslategray; vertical-align:middle"';
var class_css_btxt = 'style="border-right: 2px solid lightslategray; vertical-align:middle; text-align:center"';

function CrearEncuesta() {
    $('#myModal1').modal('show');
    $("#PK_Id_Encuesta").val(0);
    $("#Titulo").val("");
    $("#vigencia").val("");
    $("#URL").val("");
    $("#link_url").css("display", "none");
    $("#enviar").css("display", "none");
    $("#myform").empty();
    $("#buildyourform").empty();


}

function GenerarLink() {
    $.ajax({
        type: 'GET',
        url: '/ComunicacionesInternas/GenerarLink',
        data: { PK_Id_Encuesta: $("#PK_Id_Encuesta").val() },
        traditional: true,
        success: function (result) {
            $("#URL").val(result);
        }
    });
}

function CerrarModal() {
    $('#myModal1').modal('hide');
}

function ReCrear() {
    $("#myform").empty();
}

function GuardarEncuesta() {
    ValidaGuardarFormulario();
	
	$("#yourform").remove();
    var radiobutton = "";
        var fieldSet = $("<fieldset id=\"yourform\"><legend>" + $("#Titulo").val() + "</legend></fieldset>");
        var Html = "<table id=\"tblEncuesta\" border=\"0\"  style=\"width:auto;\">";
        var cont_fecha = 0;
        var cont_hora = 0;
		var escalaini = "";
		var escalafin = "";
        $("#buildyourform div").each(function () {
            Html += "<tr class=\"noborder\">";
            var id = "input" + $(this).attr("id").replace("field", "");
            if($(this).find("select.fieldtype").first().val()!="escala_inicio" && $(this).find("select.fieldtype").first().val()!="escala_fin")
				Html += "<td class=\"noborder\"><label for=\"" + id + "\">" + $(this).find("input.fieldname").first().val() + "</label></td>";
            
			var input;
			var Html1 = "";
			if($(this).find("select.fieldtype").first().val()=="escala_inicio" || $(this).find("select.fieldtype").first().val()=="escala_fin")
			{
				var escala_fin = $(this).find("select.fieldtype").first().val();

					if(	escala_fin == "escala_inicio")
						escalaini = $(this).find("input.fieldname").first().val();
						
				
					if(	escala_fin == "escala_fin")
						escalafin = $(this).find("input.fieldname").first().val();
						

					Html1 ="<table style=\"width:auto;\" border=\"0\">";
					Html1 +="<tr class=\"noborder\">";
					Html1 +="<td class=\"noborder\"><label for=\"" + id + "\">" + escalaini + "</label></td>";
					Html1 +="<td class=\"noborder\">1&nbsp;<input type=\"radio\" id=\"" + id + "\" name=\"" + id + "\" /></td>";
					Html1 +="<td class=\"noborder\">2&nbsp;<input type=\"radio\" id=\"" + id + "\" name=\"" + id + "\" /></td>";
					Html1 +="<td class=\"noborder\">3&nbsp;<input type=\"radio\" id=\"" + id + "\" name=\"" + id + "\" /></td>";
					Html1 +="<td class=\"noborder\">4&nbsp;<input type=\"radio\" id=\"" + id + "\" name=\"" + id + "\" /></td>";
					Html1 +="<td class=\"noborder\">5&nbsp;<input type=\"radio\" id=\"" + id + "\" name=\"" + id + "\" /></td>";
					Html1 +="<td class=\"noborder\"><label for=\"" + id + "\">" + escalafin + "</label></td>";
					Html1 +="</tr>";
					Html1 +="</table>";	
			}
			

			if($(this).find("select.fieldtype").first().val()=="escala_fin")
				Html += "<td colspan=\"3\" class=\"noborder\">"+Html1+"</td>"

            switch ($(this).find("select.fieldtype").first().val()) {
                case "label":
                    radiobutton = id;
                    Html += "<td class=\"noborder\"><label id=\"" + id + "\" name=\"" + id + "\"></label></td>";
                    break;
				case "escala_titulo":
                    Html += "<td class=\"noborder\"><label id=\"" + id + "\" name=\"" + id + "\"></label></td>";
                    break;
                case "radio":
                    Html += "<td class=\"noborder\"><input type=\"radio\" id=\"radio_op_" + radiobutton + "\" name=\"radio_op_" + radiobutton + "\" /></td>";
                    break;
                case "checkbox":
                    Html += "<td class=\"noborder\"><input type=\"checkbox\" id=\"" + id + "\" name=\"" + id + "\" /></td>";
                    break;
                case "textbox":
                    Html += "<td class=\"noborder\"><input type=\"text\" id=\"" + id + "\" name=\"" + id + "\" class=\"form-control\" style=\"width:200%;\"/></td>";
                    break;
                case "textarea":
                    Html += "<td class=\"noborder\"><textarea id=\"" + id + "\" name=\"" + id + "\" class=\"form-control\" style=\"width:200%;\"></textarea></td>";
                    break;
                case "fecha":
                    cont_fecha = cont_fecha + 1;
                    Html += "<td class=\"noborder\"><input type=\"text\" id=\"campofecha_" + cont_fecha + "\" name=\"campofecha_" + cont_fecha + "\" class=\"form-control\" onclick=\"CargarFechas(this.id)\" onfocus=\"CargarFechas(this.id)\" readonly/></td>";
                    break;
                case "hora":
                    cont_hora = cont_hora + 1;
                    Html += "<td class=\"noborder\"><input  type=\"text\" id=\"campohora_" + cont_hora + "\" name=\"campohora_" + cont_hora + "\" class=\"form-control\" onclick=\"CargarHoras(this.id)\" onfocus=\"CargarHoras(this.id)\" /></td>";
                    break;
            }
            Html += "</tr>";
        });
        fieldSet.append(Html);
        Html += "</table>";
    $("#myform").append(fieldSet);
    var cuerpoencuesta = $("#myform").html();
    var buildform = $("#buildyourform").html();
       var control = "";
    $("#buildyourform").find(':input').each(function () {
        var elemento = this;
        control += elemento.id + '|' + elemento.value;
    });

    //$("#URL").val("http://test-positiva.adacsc.co:18080/Publicacion/PublicarEncuesta/?formdata=MFjdrEADna6gwZJzgELZhibO");
    var nURL = $("#URL").val().split('?');
	if (ValidarVigencia()) {
        if ($("#frmEncuestas").valid()) {
			PopupPosition();
			$.ajax({
				type: 'POST',
				url: '/ComunicacionesInternas/GuardarEncuestaT',
				data: { PK_Id_Encuesta: $("#PK_Id_Encuesta").val(), Titulo: $("#Titulo").val(), CuerpoEncuesta: cuerpoencuesta, buildform: buildform, webControls: control, EstadoEncuesta: "En Espera", vigencia: $("#vigencia").val(), url: nURL },
				traditional: true,
				success: function (result) {
					$('#myModal4').modal('hide');
					$('#myModal1').modal('hide');
					OcultarPopupposition();
					ListarComunicacionesInternas();
				}
			});
		}
    }
    else
        swal("Estimado Usuario!", "La Vigencia debe ser una fecha mayor o igual a la Actual.", "warning");

}

function ValidaGuardarFormulario(){
	$("#frmEncuestas").validate({
        errorClass: "error",
        rules: {
			Titulo: {
                required: true
            },
			vigencia: {
                required: true
            },
			URL: {
                required: true
            }
        },
        messages: {
			Titulo: {
                required: "Este campo es requerido"
            },
			vigencia: {
                required: "Este campo es requerido"
            },
			URL: {
                required: "Este campo es requerido"
            }
        }
    });
}

function ValidarVigencia() {
    var vigencia = formatFecha($("#vigencia").val());
    var hoy = new Date();
    var fechaFormulario = new Date(vigencia);
    hoy.setHours(0, 0, 0, 0);

    if (fechaFormulario >= hoy)
        return true;
    else
        return false;

}

function ValidarVigenciaGrid(fecha) {
    if (fecha == null || fecha == "")
        return true;

    var vigencia = formatFecha(fecha);
    var hoy = new Date();
    var fechaFormulario = new Date(vigencia);
    hoy.setHours(0, 0, 0, 0);

    if (fechaFormulario >= hoy)
        return true;
    else
        return false;

}


function formatFecha(fecha) {
    if (fecha == null) {
        return "";
    }
    var fec = fecha.split("/");
    return fec[2] + "-" + fec[1] + "-" + fec[0];
}

String.prototype.contains = function (it) {
    return this.indexOf(it) != -1;
};

function GuardarEncuestas() {
    arValor = new Array();
    $("#tblEncuesta").find(':input').each(function () {
        var elemento = this;
        var label = $("label[for='" + elemento.id + "']");
        textbox = elemento.id + '|' + elemento.value;
        if (textbox.contains("radio")) {
            var label1 = $("label[for='" + elemento.id + "']");
            arValor.push(label1.text() + '|' + elemento.checked);
        }
        else
            arValor.push('0|' + elemento.value);

    });

    PopupPosition();
    $.ajax({
        type: 'POST',
        url: '/ComunicacionesInternas/GuardarEncuesta',
        data: { arRespuesta: arValor, fk_pk_id_encuesta: $("#fk_pk_id_encuesta").val() },
        traditional: true,
        success: function (result) {
            OcultarPopupposition();
            $("#gencuesta").css("display", "none");
            $("#gsalir").css("display", "block");

            swal("Estimado Usuario!", "La encuesta ha sido Guardada con éxito.", "success");
        }
    });
}

ListarComunicacionesInternas();
function ListarComunicacionesInternas() {
    $.ajax({
        type: 'POST',
        url: '/ComunicacionesInternas/ListarComunicacionesInternas',
        success: function (result) {
            var tHtml = "";
            $("#gridcomunicadosapp").empty();
            tHtml += '<thead style="border-left:2px solid lightslategray;"><tr class="titulos_tabla">';
            tHtml += '<th ' + class_css_header + '>Nombre de la Encuesta</td>';
            tHtml += '<th ' + class_css_header + '>Estado de la Encuesta</th>';
            tHtml += '<th ' + class_css_header + '>Fecha de CreaciÓn</th>';
            tHtml += '<th ' + class_css_header + '>Fecha de Publicacion</th>';
            tHtml += '<th ' + class_css_header + '>Fecha de Vigencia</th>';
            tHtml += '<th ' + class_css_header + '>Acciones</th>';
            tHtml += '</tr></thead>';
            $.each(result, function (key, val) {
                tHtml += '<tbody style="border-left:2px solid lightslategray;"><tr>';
                tHtml += '<td ' + class_css_btxt + '>' + val.Titulo + '</td>';
                if (ValidarVigenciaGrid(val.vigencia))
                    tHtml += '<td ' + class_css_btxt + '>' + val.EstadoEncuesta + '</td>';
                else
                    tHtml += '<td ' + class_css_btxt + '>Caducada</td>';


                tHtml += '<td ' + class_css_btxt + '>' + val.FechaCreacion.substring(0, 10) + '</td>';
                tHtml += '<td ' + class_css_btxt + '>' + val.FechaEnvio.substring(0, 10) + '</td>';
                var vig = "";
                if (val.vigencia != null)
                    vig = val.vigencia;


                tHtml += '<td ' + class_css_btxt + '>' + vig.substring(0, 10) + '</td>';
                tHtml += '<td ' + class_css_btxt + '>&nbsp;<a href="#" class="btn btn-search btn-md" title="Editar" onClick="EditarEncuesta(' + val.PK_Id_Encuesta + ');"><span class="glyphicon glyphicon-pencil"></span></a>&nbsp;|&nbsp;';
                tHtml += '<a href="#" class="btn btn-search btn-md" title="Copiar y Reutilizar" onClick="CopiarEncuesta(' + val.PK_Id_Encuesta + ');"><span class="glyphicon glyphicon-copy"></span></a>&nbsp;|&nbsp;';
                tHtml += '<a href="#" class="btn btn-search btn-md" title="Visualizar" onClick="PublicarEncuesta(' + val.PK_Id_Encuesta + ');"><span class="glyphicon glyphicon-search"></span></a>&nbsp;|&nbsp;';
                tHtml += '<a href="#" class="btn btn-search btn-md" title="Eliminar" onClick="EliminarEncuesta(' + val.PK_Id_Encuesta + ');"><span class="glyphicon glyphicon-erase"></span></a></td>';
                tHtml += '</tr></tbody>';
            });
            $("#gridcomunicadosapp").append(tHtml);
        }
    });
}

function CopiarEncuesta(PK_Id_Encuesta) {
    swal({
        title: "Estimado Usuario",
        text: "Desea Copiar para reutilizar la Encuesta?",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si",
        cancelButtonText: "No",
        closeOnConfirm: false
    },
	function () {
	    swal("Estimado Usuario", "La encuesta ha sido Copiada y Generada con éxito.", "success");
	    $.ajax({
	        type: 'GET',
	        url: '/ComunicacionesInternas/CopiarEncuesta',
	        data: { PK_Id_Encuesta: PK_Id_Encuesta },
	        success: function (result) {
	            ListarComunicacionesInternas();
	        }
	    });
	});

}

function PublicarEncuesta(PK_Id_Encuesta) {
    $.ajax({
        type: 'GET',
        url: '/Publicacion/GenerarEncuesta',
        data: { PK_Id_Encuesta: PK_Id_Encuesta },
        success: function (result) {
            //alert(JSON.stringify(result));
            window.open(result, "popup", 'width=auto,height=auto');
        }
    });
}

function CopiarLink(id_elemento) {
    document.getElementById(id_elemento).select();
    document.execCommand("copy");
    swal("Estimado Usuario!", "La URL ha sido copiada con Exito.", "success");
}

function EditarEncuesta(PK_Id_Encuesta) {
    $("#PK_Id_Encuesta").val(PK_Id_Encuesta);
    $.ajax({
        type: 'GET',
        url: '/ComunicacionesInternas/EditarEncuesta',
        data: { PK_Id_Encuesta: PK_Id_Encuesta },
        success: function (result) {
            $('#myModal1').modal('show');
            $("#link_url").css("display", "block");
            $("#enviar").css("display", "block");
            $("#CuerpoHtmlTemp").val(result.webControls);
            $("#BuildHtmlTemp").val(result.BuildFormHtml);
            $("#buildyourform").html(result.BuildFormHtml);
            $("#Titulo").val(result.Titulo);
            $("#vigencia").val(result.vigencia);
            $("#URL").val(result.URL);
            $("#PK_Id_Encuesta").val(PK_Id_Encuesta);
            var control = "";
            var cont = 0;
            var webcontrols = $("#CuerpoHtmlTemp").val().split('|');
            $("#buildyourform").find(':input[type=text]').each(function () {
                var elemento = this;
                var valor = webcontrols[cont].split(',');
                elemento.value = valor[0];
                cont++;
            });

            var cont = 0;
            $("#buildyourform").find(':input[data-field=name_selector]').each(function () {
                var elemento = this;
                var valor = webcontrols[cont].split(',');
                elemento.value = valor[1];
                cont++;
            });
        }
    });
}

function EliminarEncuesta(PK_Id_Encuesta) {
    swal({
        title: "Estimado Usuario",
        text: "Desea Eliminar la Encuesta?",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si",
        cancelButtonText: "No",
        closeOnConfirm: false
    },
	function () {
	    swal("Estimado Usuario", "La encuesta ha sido eliminada con éxito.", "success");
	    $.ajax({
	        type: 'GET',
	        url: '/ComunicacionesInternas/EliminarEncuesta',
	        data: { PK_Id_Encuesta: PK_Id_Encuesta },
	        success: function (result) {
	            ListarComunicacionesInternas();
	        }
	    });
	});
}

function EnviarEncuesta(PK_Id_Encuesta) {

    PopupPosition();
    var cuerpoencuesta = $("#myform").html();
    $.ajax({
        type: 'POST',
        url: '/ComunicacionesInternas/GuardarEncuestaT',
        data: { PK_Id_Encuesta: $("#PK_Id_Encuesta").val(), Titulo: $("#Titulo").val(), CuerpoEncuesta: cuerpoencuesta, EstadoEncuesta: "Enviado" },
        success: function (result) {
            $('#myModal1').modal('hide');
            OcultarPopupposition();
            ListarComunicacionesInternas();
        }
    });
}