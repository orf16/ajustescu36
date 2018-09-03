using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG_SST.EntidadesDominio.Planificacion;
using SG_SST.Audotoria;
using OfficeOpenXml;
using System.IO;
using System.Data;
using SG_SST.Interfaces.Planificacion;
using SG_SST.InterfazManager.Planificacion;
using SG_SST.Models.Emergencias;
using SG_SST.EntidadesDominio.Empresas;
using SG_SST.Logica.Ausentismo;
using RestSharp;
using System.Net;

namespace SG_SST.Logica.Planificacion
{
   public class LNCarguePlanEmergencia
    {

       LNAusencia lnausencia = new LNAusencia();
       private static IPlanEmergencia  eme = IMPlanEmergencia.PlanEmergencia();
       string sexo, eps,nombreCompleto;
       public string nitEmpresa;
       public EDCarguePlanEmergencia CargarPlantillaBDInterna(EDCarguePlanEmergencia cargueP)
       {
           nitEmpresa = cargueP.NitEmpresa;
           RegistraLog registraLog = new RegistraLog();
           EDCarguePlanEmergencia edCargue = new EDCarguePlanEmergencia();
           try
           {
               edCargue = CargarArchivoBDInterna(cargueP);
           }
           catch (Exception ex)
           {
               registraLog.RegistrarError(typeof(LNCargue), string.Format("Error en el método Cargar Plantilla BDInterna  {0}: {1}", DateTime.Now, ex.StackTrace), ex);
               edCargue.Message = "El cargue falló: la estructura del archivo no es valida";
               return edCargue;
           }

           return edCargue;
       }

       public EDCarguePlanEmergencia CargarArchivoBDInterna(EDCarguePlanEmergencia cargue)
       {
           RegistraLog registraLog = new RegistraLog();
           EDCarguePlanEmergencia edCargue = new EDCarguePlanEmergencia();
           try
           {
               using (ExcelPackage package = new ExcelPackage(new FileInfo(cargue.path)))
               {
                   var sheet = package.Workbook.Worksheets["Bd_Interna"];
                   // 

                   bool validaEstruc = ValidarNombreColumnasBDInterna(sheet);
                   if (validaEstruc)
                       edCargue = ProcesarCargueBDInterna(sheet, cargue);
                   else
                       edCargue.Message = "El cargue fallo: Los nombres de las columnas de la plantilla fueron modificados.";

                   return edCargue;
               }
           }
           catch (Exception ex)
           {
               registraLog.RegistrarError(typeof(LNCargue), string.Format("Error en el método CargarArchivoAusencias {0}: {1}", DateTime.Now, ex.StackTrace), ex);
               edCargue.Message = "El proceso  fallo: La estructura del archivo no es valida";
               return edCargue;
           }
       }


       private EDCarguePlanEmergencia ProcesarCargueBDInterna(ExcelWorksheet sheet, EDCarguePlanEmergencia cargue)
       {
           EDCarguePlanEmergencia edCargue = new EDCarguePlanEmergencia();

           List<EDDatosCarguePlanEmergencia> datosBI = new List<EDDatosCarguePlanEmergencia>();
           bool esValidoBDInt = true;
           bool noBlancos = true;
           string nFilaBla = "";
           string nFilaPV = "";
           string mensaje = "";
           string nFilaDoc = "";
           string nFilaEspecifica = "";
           bool resu = false;
           string mensajePlantillaVacia = "La plantilla ingresada no tiene datos";
           string mensajeEspBlancos = "Existen campos en blanco,revisar la(s) fila(s)";
           string mensajeEspecifica = "Se debes especificar cuando se requiere manejo, revisar la(s) fila(s)";
           string mensajeDocumento = "Revisar la columna A(Número de Documento) ya que el documento no tiene relación laboral,revisar la(s) fila(s)";
           string mensajeRepetidos = "";
           
           try
           {
               var dt = new DataTable();
               var rowCnt = 0;
               var cual = "";
               bool documentoValido = false;
               var sexoG = "";
               var epsG = "";
               rowCnt = sheet.Dimension.End.Row;
               var sede = cargue.idSede;
               List<string> documentos = new List<string>();
               List<string> documentosSinRep = new List<string>();
               for (var fila = 2; fila <= rowCnt; fila++)
               {

                   EDDatosCarguePlanEmergencia datoBI = new EDDatosCarguePlanEmergencia();
                
                   if (sheet.Cells[fila, 1].Value != null)
                   {
                       if (sheet.Cells[fila, 1].Value == null || sheet.Cells[fila, 2].Value == null || sheet.Cells[fila, 3].Value == null
                      || sheet.Cells[fila, 4].Value == null || sheet.Cells[fila, 5].Value == null || sheet.Cells[fila, 6].Value == null
                    
              
                      )
                       {
                           nFilaBla += " " + fila;
                           esValidoBDInt = false;
                           noBlancos = false;

                       }

                       if (noBlancos)
                       {
                           //var nombre = sheet.Cells[fila, 1].Value.ToString();
                           var documento = sheet.Cells[fila, 1].Value.ToString();
                           
                           var rh = sheet.Cells[fila, 2].Value.ToString();
                           var nombreContacto = sheet.Cells[fila, 3].Value.ToString();
                           var telefonoContacto = sheet.Cells[fila, 4].Value.ToString();
                           var parentesco = sheet.Cells[fila, 5].Value.ToString();
                           var requiereManejo = sheet.Cells[fila,6].Value.ToString();

                           documentoValido = ValidarDocumento(documento, cargue);

                           if (documentoValido == false)
                           {
                               nFilaDoc += " " + fila;

                               esValidoBDInt = false;
                           }

                           documentos.Add(documento);

                           if(requiereManejo.Equals("SI"))
                           {
                               if (sheet.Cells[fila, 7].Value == null)
                               {
                                   nFilaEspecifica += " " + fila;
                                   esValidoBDInt = false;
                               }
                           }
                           if (sheet.Cells[fila, 7].Value != null)
                           {
                             cual = sheet.Cells[fila, 7].Value.ToString();
                           }

                           if(sexo.Equals("M"))
                           {
                               sexoG = "Masculino";
                           }
                           else{
                               sexoG = "Femenino";
                           }

                           epsG = eps;
                           if (esValidoBDInt)
                           {
                               datoBI.idSede = sede;
                               datoBI.nombreCompleto = nombreCompleto;
                               datoBI.numeroDocumeto = documento;
                               datoBI.genero = sexoG;
                               datoBI.eps = epsG;
                               datoBI.rh = rh;
                               datoBI.nombreContacto = nombreContacto;
                               datoBI.telefonoContacto = telefonoContacto;
                               datoBI.paremtescoContacto = parentesco;
                               datoBI.requiereManejo = requiereManejo;
                               datoBI.cual = cual;
                               datosBI.Add(datoBI);

                           }
                       }

                   }
                   else
                   {
                       if (fila == 2)
                       {
                           nFilaPV += "" + fila;
                           esValidoBDInt = false;
                       }
                       break;
                   }
               }

               documentosSinRep= documentos.Distinct().ToList();

               if (documentos.Count() > documentosSinRep.Count())
                   {
                       esValidoBDInt = false;
                       mensajeRepetidos = "Existes registros con documentos repetidos, por favor revisar la Columna(A) Númmero de Documento";
                   }
               //Listo aca va mensajes y resto


               if (nFilaPV.Equals(""))
               {
                   mensajePlantillaVacia = "";
               }
               else
               {
                   mensajePlantillaVacia += "\n";
               }

               if(nFilaDoc.Equals(""))
               {
                   mensajeDocumento = "";
               }
               else
               {
                   mensajeDocumento += nFilaDoc + "\n";
               }


               if (nFilaBla.Equals(""))
               {
                   mensajeEspBlancos = "";
               }
               else
               {
                   mensajeEspBlancos += nFilaBla + "\n";
               }

               if (nFilaEspecifica.Equals(""))
               {
                   mensajeEspecifica = "";
               }
               else
               {
                   mensajeEspecifica += nFilaEspecifica + "\n";
               }
               mensaje = mensajePlantillaVacia + " " + mensajeEspBlancos + " " + mensajeEspecifica + " " + mensajeDocumento + " " + mensajeRepetidos + " ";


               if (esValidoBDInt == false)
               {
                   edCargue.Message = mensaje;
                   return edCargue;
               }


               if (esValidoBDInt == true)
               {
                   resu = eme.InsertarCargueMasivoBDInterna(datosBI, sede);
               }
               else
               {
                   edCargue.Message = "No se puede realizar la carga,revise e intente de nuevo";
                   return edCargue;
               }

               if (resu)
               {
                   if (esValidoBDInt)
                   {
                       edCargue.Message = "OK";
                   }
                   else
                   {
                       edCargue.Message = mensaje;
                   }
               }
               else
               {
                   edCargue.Message = "El proceso de cargue falló";
               }

           }

           catch (Exception ex)
           {
               RegistraLog registraLog = new RegistraLog();
               registraLog.RegistrarError(typeof(LNCarguePerfilSocioDemografico), string.Format("Error en el método WorksheetToDataTable {0}: {1}", DateTime.Now, ex.StackTrace), ex);
               edCargue.Message = "El proceso falló: revise la información y por favor intentelo de nuevo.";
               return edCargue;
           }

           return edCargue;
       }
       private bool ValidarNombreColumnasBDInterna(ExcelWorksheet sheet)
       {
           if (sheet.Cells[1, 1].Value.Equals("Número de Documento")
               && sheet.Cells[1, 2].Value.Equals("RH") && sheet.Cells[1, 3].Value.Equals("Nombre del Contacto")
               && sheet.Cells[1, 4].Value.Equals("Telefono del Contacto") && sheet.Cells[1, 5].Value.Equals("Parentesco")
               && sheet.Cells[1, 6].Value.Equals("Requiere Manejo Especial") && sheet.Cells[1, 7].Value.Equals("Cuál")

               )
               return true;
           else
               return false;
       }

       // Cargue plantilla BDExterna


       public EDCarguePlanEmergencia CargarPlantillaBDExterna(EDCarguePlanEmergencia cargueP)
       {

           RegistraLog registraLog = new RegistraLog();
           EDCarguePlanEmergencia edCargue = new EDCarguePlanEmergencia();
           try
           {
               edCargue = CargarArchivoBDExterna(cargueP);
           }
           catch (Exception ex)
           {
               registraLog.RegistrarError(typeof(LNCargue), string.Format("Error en el método Cargar Plantilla BDInterna  {0}: {1}", DateTime.Now, ex.StackTrace), ex);
               edCargue.Message = "El cargue falló: la estructura del archivo no es valida";
               return edCargue;
           }

           return edCargue;
       }

       public EDCarguePlanEmergencia CargarArchivoBDExterna(EDCarguePlanEmergencia cargue)
       {
           RegistraLog registraLog = new RegistraLog();
           EDCarguePlanEmergencia edCargue = new EDCarguePlanEmergencia();
           try
           {
               using (ExcelPackage package = new ExcelPackage(new FileInfo(cargue.path)))
               {
                   var sheet = package.Workbook.Worksheets["BDExterna"];
                   // 

                   bool validaEstruc = ValidarNombreColumnasBDExterna(sheet);
                   if (validaEstruc)
                       edCargue = ProcesarCargueBDExterna(sheet, cargue);
                   else
                       edCargue.Message = "El cargue fallo: Los nombres de las columnas de la plantilla fueron modificados.";

                   return edCargue;
               }
           }
           catch (Exception ex)
           {
               registraLog.RegistrarError(typeof(LNCargue), string.Format("Error en el método CargarArchivoAusencias {0}: {1}", DateTime.Now, ex.StackTrace), ex);
               edCargue.Message = "El proceso  fallo: La estructura del archivo no es valida";
               return edCargue;
           }
       }

       private bool ValidarNombreColumnasBDExterna(ExcelWorksheet sheet)
       {
           if (sheet.Cells[1, 1].Value.Equals("Entidad") && sheet.Cells[1, 2].Value.Equals("Dirección")
               && sheet.Cells[1, 3].Value.Equals("Teléfono") && sheet.Cells[1, 4].Value.Equals("Nombre del Contacto"))
               return true;
           else
               return false;
       }

       private EDCarguePlanEmergencia ProcesarCargueBDExterna(ExcelWorksheet sheet, EDCarguePlanEmergencia cargue)
       {
           EDCarguePlanEmergencia edCargue = new EDCarguePlanEmergencia();

           List<EDDatosCarguePlanEmergencia> datosBDExt = new List<EDDatosCarguePlanEmergencia>();
           bool esValidoBDExt = true;
           bool noBlancos = true;
           string nFilaBla = "";
           string nFilaPV = "";
           string mensaje = "";
           bool resu = false;
           string mensajePlantillaVacia = "La plantilla ingresada no tiene datos";
           string mensajeEspBlancos = "Existen campos en blanco,revisar la(s) fila(s)";
           
           try
           {
               var dt = new DataTable();
               var rowCnt = 0;
               rowCnt = sheet.Dimension.End.Row;
               var sede = cargue.idSede;
               var nitEmpresa = cargue.NitEmpresa;
               for (var fila = 2; fila <= rowCnt; fila++)
               {

                   EDDatosCarguePlanEmergencia datoBE = new EDDatosCarguePlanEmergencia();

                   if (sheet.Cells[fila, 1].Value != null)
                   {
                       if (sheet.Cells[fila, 1].Value == null || sheet.Cells[fila, 2].Value == null || sheet.Cells[fila, 3].Value == null
                      || sheet.Cells[fila, 4].Value == null 
                      )
                       {
                           nFilaBla += " " + fila;
                           esValidoBDExt = false;
                           noBlancos = false;

                       }

                       if (noBlancos)
                       {
                           var nombreEntidad = sheet.Cells[fila, 1].Value.ToString();
                           var direccion = sheet.Cells[fila, 2].Value.ToString();
                           var telefonoContacto = sheet.Cells[fila, 3].Value.ToString();
                           var nombreContacto = sheet.Cells[fila, 4].Value.ToString();
                          
                           if (esValidoBDExt)
                           {
                               datoBE.idSede = sede;
                               datoBE.entidad = nombreEntidad;
                               datoBE.direccion = direccion;
                               datoBE.nombreContacto = nombreContacto;
                               datoBE.telefonoContacto = telefonoContacto;
                               datoBE.nitEmpresa = nitEmpresa;
                               datosBDExt.Add(datoBE);

                           }
                       }

                   }
                   else
                   {
                       if (fila == 2)
                       {
                           nFilaPV += "" + fila;
                           esValidoBDExt = false;
                       }
                       break;
                   }
               }


               //Listo aca va mensajes y resto


               if (nFilaPV.Equals(""))
               {
                   mensajePlantillaVacia = "";
               }
               else
               {
                   mensajePlantillaVacia += "\n";
               }


               if (nFilaBla.Equals(""))
               {
                   mensajeEspBlancos = "";
               }
               else
               {
                   mensajeEspBlancos += nFilaBla + "\n";
               }

               mensaje = mensajePlantillaVacia + " " + mensajeEspBlancos + " " ;


               if (esValidoBDExt == false)
               {
                   edCargue.Message = mensaje;
                   return edCargue;
               }


               if (esValidoBDExt == true)
               {
                   resu = eme.InsertarCargueMasivoBDExterna(datosBDExt, sede);
               }
               else
               {
                   edCargue.Message = "No se puede realizar la carga,revise e intente de nuevo";
                   return edCargue;
               }

               if (resu)
               {
                   if (esValidoBDExt)
                   {
                       edCargue.Message = "OK";
                   }
                   else
                   {
                       edCargue.Message = mensaje;
                   }
               }
               else
               {
                   edCargue.Message = "El proceso de cargue falló";
               }

           }

           catch (Exception ex)
           {
               RegistraLog registraLog = new RegistraLog();
               registraLog.RegistrarError(typeof(LNCarguePerfilSocioDemografico), string.Format("Error en el método WorksheetToDataTable {0}: {1}", DateTime.Now, ex.StackTrace), ex);
               edCargue.Message = "El proceso falló: revise la información y por favor intentelo de nuevo.";
               return edCargue;
           }

           return edCargue;
       }

       //Plan de ayuda

       public EDCarguePlanEmergencia CargarPlantillaBDPlanAyuda(EDCarguePlanEmergencia cargueP)
       {

           RegistraLog registraLog = new RegistraLog();
           EDCarguePlanEmergencia edCargue = new EDCarguePlanEmergencia();
           try
           {
               edCargue = CargarArchivoBDPlanAyuda(cargueP);
           }
           catch (Exception ex)
           {
               registraLog.RegistrarError(typeof(LNCargue), string.Format("Error en el método Cargar Plantilla BDInterna  {0}: {1}", DateTime.Now, ex.StackTrace), ex);
               edCargue.Message = "El cargue falló: la estructura del archivo no es valida";
               return edCargue;
           }

           return edCargue;
       }

       public EDCarguePlanEmergencia CargarArchivoBDPlanAyuda(EDCarguePlanEmergencia cargue)
       {
           RegistraLog registraLog = new RegistraLog();
           EDCarguePlanEmergencia edCargue = new EDCarguePlanEmergencia();
           try
           {
               using (ExcelPackage package = new ExcelPackage(new FileInfo(cargue.path)))
               {
                   var sheet = package.Workbook.Worksheets["BD_PlanAyuda"];
                   // 

                   bool validaEstruc = ValidarNombreColumnasBDPlanAyuda(sheet);
                   if (validaEstruc)
                       edCargue = ProcesarCargueBDPlanAyuda(sheet, cargue);
                   else
                       edCargue.Message = "El cargue fallo: Los nombres de las columnas de la plantilla fueron modificados.";

                   return edCargue;
               }
           }
           catch (Exception ex)
           {
               registraLog.RegistrarError(typeof(LNCargue), string.Format("Error en el método CargarArchivoAusencias {0}: {1}", DateTime.Now, ex.StackTrace), ex);
               edCargue.Message = "El proceso  fallo: La estructura del archivo no es valida";
               return edCargue;
           }
       }

       private bool ValidarNombreColumnasBDPlanAyuda(ExcelWorksheet sheet)
       {
           if (sheet.Cells[1, 1].Value.Equals("Empresa Participante") && sheet.Cells[1, 2].Value.Equals("Recursos a Disposición")
               && sheet.Cells[1, 4].Value.Equals("Reintegro del Recurso")
               && sheet.Cells[1, 5].Value.Equals("Nombre del Contacto")
               )
               return true;
           else
               return false;
       }

       private EDCarguePlanEmergencia ProcesarCargueBDPlanAyuda(ExcelWorksheet sheet, EDCarguePlanEmergencia cargue)
       {
           EDCarguePlanEmergencia edCargue = new EDCarguePlanEmergencia();

           List<EDDatosCarguePlanEmergencia> datosBDPlanAyuda = new List<EDDatosCarguePlanEmergencia>();
           bool esValidoBDPlan = true;
           bool noBlancos = true;
           string nFilaBla = "";
           string nFilaPV = "";
           string mensaje = "";
           bool resu = false;
           string mensajePlantillaVacia = "La plantilla ingresada no tiene datos";
           string mensajeEspBlancos = "Existen campos en blanco,revisar la(s) fila(s)";

           try
           {
               var dt = new DataTable();
               var rowCnt = 0;
       
               rowCnt = sheet.Dimension.End.Row;
               var sede = cargue.idSede;
               var nitEmpresa = cargue.NitEmpresa;
               for (var fila = 2; fila <= rowCnt; fila++)
               {

                   EDDatosCarguePlanEmergencia datoPA = new EDDatosCarguePlanEmergencia();

                   if (sheet.Cells[fila, 1].Value != null)
                   {
                       if (sheet.Cells[fila, 1].Value == null || sheet.Cells[fila, 2].Value == null || sheet.Cells[fila, 3].Value == null
                      || sheet.Cells[fila, 4].Value == null
                      )
                       {
                           nFilaBla += " " + fila;
                           esValidoBDPlan = false;
                           noBlancos = false;

                       }

                       if (noBlancos)
                       {
                           var empresaParticipante = sheet.Cells[fila, 1].Value.ToString();
                           var recursoDisposicion = sheet.Cells[fila, 2].Value.ToString();
                           var compesacionEcomomica = sheet.Cells[fila, 3].Value.ToString();
                           var reintegroRecurso = sheet.Cells[fila, 4].Value.ToString();
                           var nombreContacto = sheet.Cells[fila, 5].Value.ToString();
                           var telefonoContacto = sheet.Cells[fila, 6].Value.ToString();

                           if (esValidoBDPlan)
                           {
                               datoPA.idSede = sede;
                               datoPA.empresaParticipante = empresaParticipante;
                               datoPA.recursoDisposicion = recursoDisposicion;
                               datoPA.compesacionEconomica = compesacionEcomomica;
                               datoPA.reintegroRecurso = compesacionEcomomica;
                               datoPA.nombreContacto = nombreContacto;
                               datoPA.telefonoContacto = telefonoContacto;
                               datoPA.nitEmpresa = nitEmpresa;
                               datosBDPlanAyuda.Add(datoPA);

                           }
                       }

                   }
                   else
                   {
                       if (fila == 2)
                       {
                           nFilaPV += "" + fila;
                           esValidoBDPlan = false;
                       }
                       break;
                   }
               }


               //Listo aca va mensajes y resto


               if (nFilaPV.Equals(""))
               {
                   mensajePlantillaVacia = "";
               }
               else
               {
                   mensajePlantillaVacia += "\n";
               }


               if (nFilaBla.Equals(""))
               {
                   mensajeEspBlancos = "";
               }
               else
               {
                   mensajeEspBlancos += nFilaBla + "\n";
               }

               mensaje = mensajePlantillaVacia + " " + mensajeEspBlancos + " ";


               if (esValidoBDPlan == false)
               {
                   edCargue.Message = mensaje;
                   return edCargue;
               }


               if (esValidoBDPlan == true)
               {
                   resu = eme.InsertarCargueMasivoBDPlanAyuda(datosBDPlanAyuda, sede);
               }
               else
               {
                   edCargue.Message = "No se puede realizar la carga,revise e intente de nuevo";
                   return edCargue;
               }

               if (resu)
               {
                   if (esValidoBDPlan)
                   {
                       edCargue.Message = "OK";
                   }
                   else
                   {
                       edCargue.Message = mensaje;
                   }
               }
               else
               {
                   edCargue.Message = "El proceso de cargue falló";
               }

           }

           catch (Exception ex)
           {
               RegistraLog registraLog = new RegistraLog();
               registraLog.RegistrarError(typeof(LNCarguePerfilSocioDemografico), string.Format("Error en el método WorksheetToDataTable {0}: {1}", DateTime.Now, ex.StackTrace), ex);
               edCargue.Message = "El proceso falló: revise la información y por favor intentelo de nuevo.";
               return edCargue;
           }

           return edCargue;
       }


       public bool ValidarDocumento(string documento, EDCarguePlanEmergencia cargue)
       {



           try
           {
               List<EDTipoDocumento> ListaDocumentos = lnausencia.ObtenerTipoDocumento();
               if (!string.IsNullOrEmpty(documento))
               {
                   var esValido = false;
                   foreach (var tdoc in ListaDocumentos)
                   {
                       var cliente = new RestSharp.RestClient(cargue.rutaServicio);
                       var request = new RestRequest("wssst/afiliadoEmpresaActivo?", RestSharp.Method.GET);


                       request.Parameters.Clear();
                       request.AddParameter("tpEm", cargue.SiglaTipoDocumentoEmpresa);
                       request.AddParameter("docEm", cargue.NitEmpresa);
                       request.AddParameter("tpAfiliado", tdoc.Sigla.ToLower());
                       request.AddParameter("docAfiliado", documento);
                       request.AddHeader("Content-Type", "application/json");
                       request.AddHeader("Accept", "application/json");

                       ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                       IRestResponse<List<EDPerfilSocioDemograficoWS>> response = cliente.Execute<List<EDPerfilSocioDemograficoWS>>(request);
                       var result = response.Content;
                  
                       var respuesta = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EDPerfilSocioDemograficoWS>>(result);
                       var nitEmpresaU = "";
                       if (respuesta.Count != 0)
                       {

                           nitEmpresaU = respuesta[0].documentoEmp;
                       }

                       if (nitEmpresaU.Equals(nitEmpresa))
                       {

                           sexo = respuesta[0].sexoPersona;
                           eps = respuesta[0].nombreEps;
                           nombreCompleto = respuesta[0].nombre1 + " " + respuesta[0].nombre2 + " " + respuesta[0].apellido1 + " " + respuesta[0].apellido2;

                           esValido = true;
                           break;
                       }
                       else
                       {
                           esValido = false;
                       }
                   }

                   if (esValido)
                   {
                       return true;
                   }
                   else
                   {
                       return false;
                   }
               }
               return false;
           }
           catch (Exception e)
           {
               return false;
           }
       }


    }
}
