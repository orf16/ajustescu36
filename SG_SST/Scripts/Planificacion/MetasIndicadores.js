var $idIndicador = $("#FK_Id_Indicador");
//Función para consultar los indicadores de un tipo
function ConsultarIndicadores(tipo) {
    var $tipo = $("#tiposIndicadores").val();
    $.ajax({
        url: urlBase + '/MetasIndicadores/ObtenerIndicadores',//primero el modulo/controlador/metodo que esta en el controlador
        data: {
            tipo: $tipo
        },
        type: 'POST',
        success: function (result) {
            if (result.Mensaje == "OK") {
                $idIndicador.find("option").remove();//Removemos las opciones anteriores 
                $idIndicador.append(new Option("---Seleccionar Indicador---", ""));// agregamos la opcion de seleccionar              
                $.each(result.Data, function (ind, element) {
                    $idIndicador.append(new Option(element.Nombre, element.PK_Id_Indicador));//agregamos las opciones consultadas
                });
                $("#unidadIndicador").val("");
                $("#unidadIndicador1").val("");
                $("#unidadIndicador2").val("");
                $("#unidadIndicador3").val("");
                $("#unidadIndicador4").val("");
                $("#frecuencia").val("");
            }
        }
    });

}

//Función para consultar la información del indicador seleccionado
function ConsultarIndicador() {
    var indi = $idIndicador.val();
    $.ajax({
        url: urlBase + '/MetasIndicadores/ObtenerIndicador',//primero el modulo/controlador/metodo que esta en el controlador
        data: {
            id: indi
        },
        type: 'POST',
        success: function (result) {
            if (result.Mensaje == "OK") {
                $("#unidadIndicador").val(result.Data.Unidad);
                $("#unidadIndicador1").val(result.Data.Unidad);
                $("#unidadIndicador2").val(result.Data.Unidad);
                $("#unidadIndicador3").val(result.Data.Unidad);
                $("#unidadIndicador4").val(result.Data.Unidad);
                $("#frecuencia").val(result.Data.Frecuencia);
            }
            else {
                $("#unidadIndicador").val("");
                $("#unidadIndicador1").val("");
                $("#unidadIndicador2").val("");
                $("#unidadIndicador3").val("");
                $("#unidadIndicador4").val("");
                $("#frecuencia").val("");
            }
        },
        error: function (result) {
            swal({
                type: 'warning',
                title: 'Estimado Usuario',
                text: 'Se presentó un error, intente más tarde.',
                confirmButtonColor: '#7E8A97'
            });
            OcultarPopupposition();
        }
    });
}

//Función para agregar la meta de un indicador
function AdicionarMeta() {
    if ($("#formMetas").valid()) {
        PopupPosition();
        var item = $idIndicador.val();
        if (item == "") {
            swal({
                type: 'warning',
                title: 'Estimado Usuario',
                text: 'Debe seleccionar el indicador.',
                confirmButtonColor: '#7E8A97'
            });
            OcultarPopupposition();
        }
        else {
            var empresa = $("#IdEmpresa").val();
            var rojoS = $("#rojo").val();
            var amarilloS = $("#amarillo").val();
            var verdeS = $("#verde").val();
            var metaS = $("#meta").val();
            try {
                var rojo = parseFloat(rojoS);
                var amarillo = parseFloat(amarilloS);
                var verde = parseFloat(verdeS);
                var meta = parseFloat(metaS);
            }
            catch (err) {
                var rojo = "";
                var amarillo = "";
                var verde = "";
                var meta = "";
            }
            if (rojo == "" || isNaN(rojo) || amarillo == "" || isNaN(amarillo) || verde == "" || isNaN(verde) || meta == "" || isNaN(meta)) {
                swal({
                    type: 'warning',
                    title: 'Estimado Usuario',
                    text: 'Debe diligenciar todos los campos solo con números positivos y el signo (,) para los decimales.',
                    confirmButtonColor: '#7E8A97'
                });
                OcultarPopupposition();
            }
            else {
                var metaNueva = {
                    FK_Indicador: item,
                    FK_Empresa: empresa,
                    ValorRojoString: rojoS,
                    ValorAmarilloString: amarilloS,
                    ValorVerdeString: verdeS,
                    ValorMetaString: metaS
                }
                $.ajax({
                    url: urlBase + '/MetasIndicadores/GuardarMetaIndicador',
                    data: metaNueva,
                    type: 'POST',
                    success: function (result) {
                        if (result.Mensaje == "ERRORYAAGREGADO") {
                            swal({
                                type: 'warning',
                                title: 'Estimado Usuario',
                                text: 'El indicador seleccionado ya se encuentra registrado.',
                                confirmButtonColor: '#7E8A97'
                            });
                            OcultarPopupposition();
                        }
                        else {
                            if (result.Mensaje == "ERRORNUMEROS") {
                                swal({
                                    type: 'warning',
                                    title: 'Estimado Usuario',
                                    text: 'Debe diligenciar todos los campos solo con números positivos y el signo (,) para los decimales.',
                                    confirmButtonColor: '#7E8A97'
                                });
                                OcultarPopupposition();
                            }
                            else {
                                $.ajax({
                                    url: urlBase + '/MetasIndicadores/ObtenerMetasIndicadoresEmpresa',
                                    data: {
                                        id: empresa
                                    },
                                    type: 'POST',
                                    success: function (result) {
                                        OcultarPopupposition();
                                        $("#tiposIndicadores").val("");
                                        $idIndicador.find("option").remove();//Removemos las opciones anteriores 
                                        $idIndicador.val("");
                                        $("#rojo").val("");
                                        $("#amarillo").val("");
                                        $("#verde").val("");
                                        $("#meta").val("");
                                        $("#unidadIndicador").val("");
                                        $("#unidadIndicador1").val("");
                                        $("#unidadIndicador2").val("");
                                        $("#unidadIndicador3").val("");
                                        $("#unidadIndicador4").val("");
                                        $("#frecuencia").val("");

                                        $("#tMetas1 td").parent().remove();
                                        $("#divTmeta").show("toogle");
                                        $("#divTmeta").trigger("reset");
                                        $('#tMetas').empty();
                                        var contador = 0;
                                        $.each(result.Data, function (ind, element) {
                                            var elemento = '<tr name="trMetas">' +
                                                            '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><input type="hidden" name="IdMetaIndicador" id="IdMetaIndicador' + contador + '"value="' + element.PK_Id_MetaIndicador + '"><input type="hidden" name="Nombre" id="Nombre' + contador + '" value="' + element.Indicador.Nombre + '">' + element.Indicador.Nombre + '</td>' +
                                                            '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><input type="hidden" name="Tipo" id="Tipo' + contador + '" value="' + element.Indicador.Tipo + '">' + element.Indicador.Tipo + '</td>' +
                                                            '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><input type="hidden" name="Frecuencia" id="Frecuencia' + contador + '" value="' + element.Indicador.Frecuencia + '">' + element.Indicador.Frecuencia + '</td>' +
                                                            '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><input type="hidden" name="Unidad" id="Unidad' + contador + '" value="' + element.Indicador.Unidad + '">' + element.Indicador.Unidad + '</td>' +
                                                            '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><input type="hidden" name="Rojo" id="Rojo' + contador + '"value="' + element.ValorRojo + '">' + element.ValorRojo + '</td>' +
                                                            '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><input type="hidden" name="Amarillo" id ="Amarillo' + contador + '"value="' + element.ValorAmarillo + '">' + element.ValorAmarillo + '</td>' +
                                                            '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><input type="hidden" name="Verde" id ="Verde' + contador + '"value="' + element.ValorVerde + '">' + element.ValorVerde + '</td>' +
                                                            '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><input type="hidden" name="Meta" id ="Meta' + contador + '"value="' + element.ValorMeta + '">' + element.ValorMeta + '</td>' +
                                                            '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><a id="botonEditar" data-toggle="modal" data-target="#modalFormModificacion" onclick="EditarMetaIndicador(' + element.PK_Id_MetaIndicador + ')" class="btn btn-search btn-md"><span class="glyphicon  glyphicon-pencil"></span></a></td>' +
                                                            '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><a id="botonBorrar" onclick="BorrarMetaIndicador(' + element.PK_Id_MetaIndicador + ',' + element.FK_Empresa + ')" class="btn btn-search btn-md"><span class="glyphicon  glyphicon-erase"></span></a></td>' +
                                                            '</tr></table>'
                                            $('#tMetas').append(elemento)
                                            contador = contador + 1;
                                        })

                                        paginador("#tMetas", "tr[name = trMetas]", "#paginadorMetas")
                                    },
                                    error: function (result) {
                                        swal({
                                            type: 'error',
                                            title: 'Estimado Usuario',
                                            text: 'Se presentó un error, intente más tarde.',
                                            confirmButtonColor: '#7E8A97'
                                        });
                                        OcultarPopupposition();
                                    }
                                });
                            }
                        }
                    },
                    error: function (result) {
                        swal({
                            type: 'error',
                            title: 'Estimado Usuario',
                            text: 'Se presentó un error, intente más tarde.',
                            confirmButtonColor: '#7E8A97'
                        });
                        OcultarPopupposition();
                    }
                });
            }
        }
    }
}

//Función para cargar las metas registradas para una empresa
function ObtenerMetas() {
    if ($("#formMetas").valid()) {
        PopupPosition();
        var empresa = $("#IdEmpresa").val();
        $.ajax({
            url: urlBase + '/MetasIndicadores/ObtenerMetasIndicadoresEmpresa',
            data: {
                id: empresa
            },
            type: 'POST',
            success: function (result) {
                OcultarPopupposition();
                $("#tiposIndicadores").val("");
                $idIndicador.find("option").remove();//Removemos las opciones anteriores 
                $idIndicador.val("");
                $("#rojo").val("");
                $("#amarillo").val("");
                $("#verde").val("");
                $("#meta").val("");
                $("#unidadIndicador").val("");
                $("#unidadIndicador1").val("");
                $("#unidadIndicador2").val("");
                $("#unidadIndicador3").val("");
                $("#unidadIndicador4").val("");
                $("#frecuencia").val("");

                $("#tMetas1 td").parent().remove();
                $("#divTmeta").show("toogle");
                $("#divTmeta").trigger("reset");
                $('#tMetas').empty();
                var contador = 0;
                $.each(result.Data, function (ind, element) {
                    var elemento = '<tr name="trMetas">' +
                                    '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><input type="hidden" name="IdMetaIndicador" id="IdMetaIndicador' + contador + '"value="' + element.PK_Id_MetaIndicador + '"><input type="hidden" name="Nombre" id="Nombre' + contador + '" value="' + element.Indicador.Nombre + '">' + element.Indicador.Nombre + '</td>' +
                                    '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><input type="hidden" name="Tipo" id="Tipo' + contador + '" value="' + element.Indicador.Tipo + '">' + element.Indicador.Tipo + '</td>' +
                                    '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><input type="hidden" name="Frecuencia" id="Frecuencia' + contador + '" value="' + element.Indicador.Frecuencia + '">' + element.Indicador.Frecuencia + '</td>' +
                                    '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><input type="hidden" name="Unidad" id="Unidad' + contador + '" value="' + element.Indicador.Unidad + '">' + element.Indicador.Unidad + '</td>' +
                                    '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><input type="hidden" name="Rojo" id="Rojo' + contador + '"value="' + element.ValorRojo + '">' + element.ValorRojo + '</td>' +
                                    '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><input type="hidden" name="Amarillo" id ="Amarillo' + contador + '"value="' + element.ValorAmarillo + '">' + element.ValorAmarillo + '</td>' +
                                    '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><input type="hidden" name="Verde" id ="Verde' + contador + '"value="' + element.ValorVerde + '">' + element.ValorVerde + '</td>' +
                                    '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><input type="hidden" name="Meta" id ="Meta' + contador + '"value="' + element.ValorMeta + '">' + element.ValorMeta + '</td>' +
                                    '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><a id="botonEditar" data-toggle="modal" data-target="#modalFormModificacion"  onclick="EditarMetaIndicador(' + element.PK_Id_MetaIndicador + ')" class="btn btn-search btn-md"><span class="glyphicon  glyphicon-pencil"></span></a></td>' +
                                    '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><a id="botonBorrar" onclick="BorrarMetaIndicador(' + element.PK_Id_MetaIndicador + ',' + element.FK_Empresa + ')" class="btn btn-search btn-md"><span class="glyphicon  glyphicon-erase"></span></a></td>' +
                                    '</tr></table>'
                    $('#tMetas').append(elemento)
                    contador = contador + 1;
                })

                paginador("#tMetas", "tr[name = trMetas]", "#paginadorMetas")
            },
            error: function (result) {
                swal({
                    type: 'error',
                    title: 'Estimado Usuario',
                    text: 'Se presentó un error, intente más tarde.',
                    confirmButtonColor: '#7E8A97'
                });
                OcultarPopupposition();
            }
        });
    }
}

//Función para mostrar el formualrio de edición de la meta de un indicador ya registrado
function EditarMetaIndicador(idMetaIndicador) {
    $.ajax({
        url: urlBase + '/MetasIndicadores/ObtenerMetaIndicador',//primero el modulo/controlador/metodo que esta en el controlador
        data: {
            id: idMetaIndicador
        },
        type: 'POST',
        success: function (result) {
            if (result.Mensaje == "OK") {
                $("#IdMeta").val(idMetaIndicador);
                $("#tipoIndicadorM").val("Indicador de " + result.Data.Indicador.Tipo);
                $("#nombreIndicadorM").val(result.Data.Indicador.Nombre);
                $("#rojoM").val(result.Data.ValorRojo);
                $("#amarilloM").val(result.Data.ValorAmarillo);
                $("#verdeM").val(result.Data.ValorVerde);
                $("#metaM").val(result.Data.ValorMeta);
                $("#unidadIndicadorM").val(result.Data.Indicador.Unidad);
                $("#unidadIndicador1M").val(result.Data.Indicador.Unidad);
                $("#unidadIndicador2M").val(result.Data.Indicador.Unidad);
                $("#unidadIndicador3M").val(result.Data.Indicador.Unidad);
                $("#unidadIndicador4M").val(result.Data.Indicador.Unidad);
                $("#frecuenciaM").val(result.Data.Indicador.Frecuencia);
            }
            else {
                swal({
                    type: 'warning',
                    title: 'Estimado Usuario',
                    text: 'Se presentó un error, intente más tarde.',
                    confirmButtonColor: '#7E8A97'
                });
                OcultarPopupposition();
            }
        },
        error: function (result) {
            swal({
                type: 'warning',
                title: 'Estimado Usuario',
                text: 'Se presentó un error, intente más tarde.',
                confirmButtonColor: '#7E8A97'
            });
            OcultarPopupposition();
        }
    });
}

function GuardarEdicionMeta() {
    var empresa = $("#IdEmpresa").val();
    var idMeta = $("#IdMeta").val();
    var rojoS = $("#rojoM").val();
    var amarilloS = $("#amarilloM").val();
    var verdeS = $("#verdeM").val();
    var metaS = $("#metaM").val();
    try {
        var rojo = parseFloat(rojoS);
        var amarillo = parseFloat(amarilloS);
        var verde = parseFloat(verdeS);
        var meta = parseFloat(metaS);
    }
    catch (err) {
        var rojo = "";
        var amarillo = "";
        var verde = "";
        var meta = "";
    }
    if (rojo == "" || isNaN(rojo) || amarillo == "" || isNaN(amarillo) || verde == "" || isNaN(verde) || meta == "" || isNaN(meta)) {
        swal({
            type: 'warning',
            title: 'Estimado Usuario',
            text: 'Debe diligenciar todos los campos solo con números positivos y el signo (,) para los decimales.',
            confirmButtonColor: '#7E8A97'
        });
        OcultarPopupposition();
    }
    else {
        var metaNueva = {
            PK_Id_MetaIndicador: idMeta,
            FK_Empresa: empresa,
            ValorRojoString: rojoS,
            ValorAmarilloString: amarilloS,
            ValorVerdeString: verdeS,
            ValorMetaString: metaS
        }
        $.ajax({
            url: urlBase + '/MetasIndicadores/ModificarMetaIndicador',
            data: metaNueva,
            type: 'POST',
            success: function (result) {
                if (result.Mensaje == "ERRORYAAGREGADO") {
                    swal({
                        type: 'warning',
                        title: 'Estimado Usuario',
                        text: 'El indicador seleccionado ya se encuentra registrado.',
                        confirmButtonColor: '#7E8A97'
                    });
                    OcultarPopupposition();
                }
                else {
                    if (result.Mensaje == "ERRORNUMEROS") {
                        swal({
                            type: 'warning',
                            title: 'Estimado Usuario',
                            text: 'Debe diligenciar todos los campos solo con números positivos y el signo (,) para los decimales.',
                            confirmButtonColor: '#7E8A97'
                        });
                        OcultarPopupposition();
                    }
                    else {
                        OcultarPopupposition();
                        swal({
                            type: 'success',
                            title: 'Estimado Usuario',
                            text: 'La meta del indicador se ha modificado correctamente.',
                            showConfirmButton: true,
                            confirmButtonText: 'Aceptar',
                            confirmButtonColor: '#7E8A97'
                        });
                        $('.confirm').on('click', function () {
                            $("#rojoM").val("");
                            $("#amarilloM").val("");
                            $("#verdeM").val("");
                            $("#metaM").val("");
                            $("#unidadIndicadorM").val("");
                            $("#unidadIndicador1M").val("");
                            $("#unidadIndicador2M").val("");
                            $("#unidadIndicador3M").val("");
                            $("#unidadIndicador4M").val("");
                            $("#frecuenciaM").val("");
                            $("#modalFormModificacion").modal("hide");
                            OcultarPopupposition();
                        });
                        $.ajax({
                            url: urlBase + '/MetasIndicadores/ObtenerMetasIndicadoresEmpresa',
                            data: {
                                id: empresa
                            },
                            type: 'POST',
                            success: function (result) {
                                OcultarPopupposition();
                                $("#tiposIndicadores").val("");
                                $idIndicador.find("option").remove();//Removemos las opciones anteriores 
                                $idIndicador.val("");
                                $("#rojo").val("");
                                $("#amarillo").val("");
                                $("#verde").val("");
                                $("#meta").val("");
                                $("#unidadIndicador").val("");
                                $("#unidadIndicador1").val("");
                                $("#unidadIndicador2").val("");
                                $("#unidadIndicador3").val("");
                                $("#unidadIndicador4").val("");
                                $("#frecuencia").val("");

                                $("#tMetas1 td").parent().remove();
                                $("#divTmeta").show("toogle");
                                $("#divTmeta").trigger("reset");
                                $('#tMetas').empty();
                                var contador = 0;
                                $.each(result.Data, function (ind, element) {
                                    var elemento = '<tr name="trMetas">' +
                                                    '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><input type="hidden" name="IdMetaIndicador" id="IdMetaIndicador' + contador + '"value="' + element.PK_Id_MetaIndicador + '"><input type="hidden" name="Nombre" id="Nombre' + contador + '" value="' + element.Indicador.Nombre + '">' + element.Indicador.Nombre + '</td>' +
                                                    '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><input type="hidden" name="Tipo" id="Tipo' + contador + '" value="' + element.Indicador.Tipo + '">' + element.Indicador.Tipo + '</td>' +
                                                    '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><input type="hidden" name="Frecuencia" id="Frecuencia' + contador + '" value="' + element.Indicador.Frecuencia + '">' + element.Indicador.Frecuencia + '</td>' +
                                                    '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><input type="hidden" name="Unidad" id="Unidad' + contador + '" value="' + element.Indicador.Unidad + '">' + element.Indicador.Unidad + '</td>' +
                                                    '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><input type="hidden" name="Rojo" id="Rojo' + contador + '"value="' + element.ValorRojo + '">' + element.ValorRojo + '</td>' +
                                                    '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><input type="hidden" name="Amarillo" id ="Amarillo' + contador + '"value="' + element.ValorAmarillo + '">' + element.ValorAmarillo + '</td>' +
                                                    '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><input type="hidden" name="Verde" id ="Verde' + contador + '"value="' + element.ValorVerde + '">' + element.ValorVerde + '</td>' +
                                                    '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><input type="hidden" name="Meta" id ="Meta' + contador + '"value="' + element.ValorMeta + '">' + element.ValorMeta + '</td>' +
                                                    '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><a id="botonEditar" data-toggle="modal" data-target="#modalFormModificacion" onclick="EditarMetaIndicador(' + element.PK_Id_MetaIndicador + ')" class="btn btn-search btn-md"><span class="glyphicon  glyphicon-pencil"></span></a></td>' +
                                                    '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><a id="botonBorrar" onclick="BorrarMetaIndicador(' + element.PK_Id_MetaIndicador + ',' + element.FK_Empresa + ')" class="btn btn-search btn-md"><span class="glyphicon  glyphicon-erase"></span></a></td>' +
                                                    '</tr></table>'
                                    $('#tMetas').append(elemento)
                                    contador = contador + 1;
                                })

                                paginador("#tMetas", "tr[name = trMetas]", "#paginadorMetas")
                            },
                            error: function (result) {
                                swal({
                                    type: 'error',
                                    title: 'Estimado Usuario',
                                    text: 'Se presentó un error, intente más tarde.',
                                    confirmButtonColor: '#7E8A97'
                                });
                                OcultarPopupposition();
                            }
                        });
                    }
                }
            },
            error: function (result) {
                swal({
                    type: 'error',
                    title: 'Estimado Usuario',
                    text: 'Se presentó un error, intente más tarde.',
                    confirmButtonColor: '#7E8A97'
                });
                OcultarPopupposition();
            }
        });
    }
}
//Función para borrar la meta de un indicador
function BorrarMetaIndicador(idMetaIndicador, idEmpresa) {
    swal({
        title: 'Estimado Usuario',
        text: "¿Seguro desea eliminar la meta del indicador?",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#7E8A97',
        cancelButtonColor: '#d33',
        cancelButtonText: 'Cancelar',
        confirmButtonText: 'Eliminar'
    }, (function (isConfirm) {
        if (isConfirm) {
            PopupPosition();
            $.ajax({
                url: urlBase + '/MetasIndicadores/EliminarMetaIndicador',
                data: {
                    idMetaIndicador: idMetaIndicador,
                    idEmpresa: idEmpresa
                },
                type: 'POST',
                success: function (result) {
                    OcultarPopupposition();
                    if (result.Mensaje == "OK") {
                        swal({
                            type: 'success',
                            title: 'Estimado Usuario',
                            text: 'Su registro ha sido eliminado.',
                            confirmButtonColor: '#7E8A97'
                        });
                        OcultarPopupposition();
                        $("#tiposIndicadores").val("");
                        $idIndicador.find("option").remove();//Removemos las opciones anteriores 
                        $idIndicador.val("");
                        $("#rojo").val("");
                        $("#amarillo").val("");
                        $("#verde").val("");
                        $("#meta").val("");
                        $("#unidadIndicador").val("");
                        $("#unidadIndicador1").val("");
                        $("#unidadIndicador2").val("");
                        $("#unidadIndicador3").val("");
                        $("#unidadIndicador4").val("");
                        $("#frecuencia").val("");

                        $("#tMetas1 td").parent().remove();
                        $("#divTmeta").show("toogle");
                        $("#divTmeta").trigger("reset");
                        $('#tMetas').empty();
                        var contador = 0;
                        $.each(result.Data, function (ind, element) {
                            var elemento = '<tr name="trMetas">' +
                                            '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><input type="hidden" name="IdMetaIndicador" id="IdMetaIndicador' + contador + '"value="' + element.PK_Id_MetaIndicador + '"><input type="hidden" name="Nombre" id="Nombre' + contador + '" value="' + element.Indicador.Nombre + '">' + element.Indicador.Nombre + '</td>' +
                                            '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><input type="hidden" name="Tipo" id="Tipo' + contador + '" value="' + element.Indicador.Tipo + '">' + element.Indicador.Tipo + '</td>' +
                                            '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><input type="hidden" name="Frecuencia" id="Frecuencia' + contador + '" value="' + element.Indicador.Frecuencia + '">' + element.Indicador.Frecuencia + '</td>' +
                                            '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><input type="hidden" name="Unidad" id="Unidad' + contador + '" value="' + element.Indicador.Unidad + '">' + element.Indicador.Unidad + '</td>' +
                                            '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><input type="hidden" name="Rojo" id="Rojo' + contador + '"value="' + element.ValorRojo + '">' + element.ValorRojo + '</td>' +
                                            '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><input type="hidden" name="Amarillo" id ="Amarillo' + contador + '"value="' + element.ValorAmarillo + '">' + element.ValorAmarillo + '</td>' +
                                            '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><input type="hidden" name="Verde" id ="Verde' + contador + '"value="' + element.ValorVerde + '">' + element.ValorVerde + '</td>' +
                                            '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><input type="hidden" name="Meta" id ="Meta' + contador + '"value="' + element.ValorMeta + '">' + element.ValorMeta + '</td>' +
                                            '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><a id="botonEditar" data-toggle="modal" data-target="#modalFormModificacion" onclick="EditarMetaIndicador(' + element.PK_Id_MetaIndicador + ')" class="btn btn-search btn-md"><span class="glyphicon  glyphicon-pencil"></span></a></td>' +
                                            '<td style="border-right: 2px solid lightslategray; border-bottom: 2px solid lightslategray; text-align:center"><a id="botonBorrar" onclick="BorrarMetaIndicador(' + element.PK_Id_MetaIndicador + ',' + element.FK_Empresa + ')" class="btn btn-search btn-md"><span class="glyphicon  glyphicon-erase"></span></a></td>' +
                                            '</tr></table>'
                            $('#tMetas').append(elemento)
                            contador = contador + 1;
                        })

                        paginador("#tMetas", "tr[name = trMetas]", "#paginadorMetas")
                    }
                    else {
                        swal({
                            type: 'error',
                            title: 'Estimado Usuario',
                            text: 'Se presentó un error, intente más tarde.',
                            confirmButtonColor: '#7E8A97'
                        });
                        OcultarPopupposition();
                    }
                },
                error: function (result) {
                    swal({
                        type: 'error',
                        title: 'Estimado Usuario',
                        text: 'Se presentó un error, intente más tarde.',
                        confirmButtonColor: '#7E8A97'
                    });
                    OcultarPopupposition();
                }
            });
        }
    }))

}
