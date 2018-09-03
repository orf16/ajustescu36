using SG_SST.Enumeraciones;
using SG_SST.EntidadesDominio.Planificacion;
using SG_SST.Interfaces.Planificacion;
using SG_SST.InterfazManager.Planificacion;
using System.Collections.Generic;
using OfficeOpenXml;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using OfficeOpenXml.Drawing.Chart;
using System;
using OfficeOpenXml.Style;
using System.Drawing;

namespace SG_SST.Logica.Planificacion
{
    public class LNEvaluacionStandMinimos
    {
        private static IEvaluacionEstandMinimos esm = IMEvaluaccion.EstandaresMinimos();
        private static IReportesEstandaresMinimos resm = IMEvaluaccion.Reportes();
        public List<EDCiclo> ObtenerCiclos(string Nit, int IdEval)
        {
            List<EDCiclo> Ciclos = new List<EDCiclo>();
            var ciclos = esm.ObtenerCiclos();
            foreach (var ciclo in ciclos)
            {
                ciclo.StandPorEvaluar = esm.ObtenerCantidaEstdPorEvaluas(ciclo.Id_Ciclo, Nit, IdEval);
                ciclo.CantidadCriterios = esm.ObtenerCantidadCriteriosPorEstandar(ciclo.Id_Ciclo);
                Ciclos.Add(ciclo);
            }

            return Ciclos;
        }
        
        public bool CrearEvaluacion(EDEvaluacionEmpresa EDEvaluacionEmpresa)
        {
            return esm.CrearEvaluacion(EDEvaluacionEmpresa);
        }
        public bool ValidarEvaluacion(EDEvaluacionEmpresa EDEvaluacionEmpresa)
        {
            return esm.ValidarEvaluacion(EDEvaluacionEmpresa);
        }
        public List<EDEvaluacionEmpresa> ListaEvaluaciones(int idEmpresa)
        {
            return esm.ListaEvaluaciones(idEmpresa);
        }
        public int VerificarCambiarEstado(int ideval)
        {
            return esm.VerificarCambiarEstado(ideval);
        }
        public List<EDEvaluacionEmpresa> Evaluacion(int Idempresa, int IdEval)
        {
            return esm.Evaluacion(Idempresa, IdEval);
        }
        public EDCiclo GuardarEvaluacionEstandar(EDEvaluacionEstandarMinimo EvaluacionEstandar)
        {
            bool result = false;
            EDCiclo ciclo = null;

            #region Verificar_Archivos
            try
            {
                if (System.IO.File.Exists(EvaluacionEstandar.RutaTempServer1))
                {
                    EvaluacionEstandar.Ruta1 = EvaluacionEstandar.RutaDB;
                }
                else
                {
                    EvaluacionEstandar.Ruta1 = null;
                    EvaluacionEstandar.NombreArchivo1 = null;
                    EvaluacionEstandar.Filedownload1 = null;
                }
            }
            catch (System.Exception)
            {
                EvaluacionEstandar.Ruta1 = null;
                EvaluacionEstandar.NombreArchivo1 = null;
                EvaluacionEstandar.Filedownload1 = null;
            }
            try
            {
                if (System.IO.File.Exists(EvaluacionEstandar.RutaTempServer2))
                {
                    EvaluacionEstandar.Ruta2 = EvaluacionEstandar.RutaDB;
                }
                else
                {
                    EvaluacionEstandar.Ruta2 = null;
                    EvaluacionEstandar.NombreArchivo2 = null;
                    EvaluacionEstandar.Filedownload2 = null;
                }
            }
            catch (System.Exception)
            {
                EvaluacionEstandar.Ruta2 = null;
                EvaluacionEstandar.NombreArchivo2 = null;
                EvaluacionEstandar.Filedownload2 = null;
            }
            try
            {
                if (System.IO.File.Exists(EvaluacionEstandar.RutaTempServer3))
                {
                    EvaluacionEstandar.Ruta3 = EvaluacionEstandar.RutaDB;
                }
                else
                {
                    EvaluacionEstandar.Ruta3 = null;
                    EvaluacionEstandar.NombreArchivo3 = null;
                    EvaluacionEstandar.Filedownload3 = null;
                }
            }
            catch (System.Exception)
            {
                EvaluacionEstandar.Ruta3 = null;
                EvaluacionEstandar.NombreArchivo3 = null;
                EvaluacionEstandar.Filedownload3 = null;
            }


            #endregion

            EDEvaluacionEstandarMinimo eval = esm.GuardarEvaluacionEstandar(EvaluacionEstandar);
            if (eval.IdEvalEstandarMinimo > 0)
            {
                if (eval.GuardadoArchivos)
                {
                    #region Mover_Archivos_Servidor
                    List<string> ArchivosTemporalesEliminar = new List<string>();
                    try
                    {
                        if (System.IO.File.Exists(EvaluacionEstandar.RutaTempServer1))
                        {

                            System.IO.File.Move(EvaluacionEstandar.RutaTempServer1, EvaluacionEstandar.RutaDBServer1);
                            ArchivosTemporalesEliminar.Add(EvaluacionEstandar.RutaTempServer1);
                        }
                    }
                    catch (System.Exception)
                    {
                    }
                    try
                    {
                        if (System.IO.File.Exists(EvaluacionEstandar.RutaTempServer2))
                        {
                            System.IO.File.Move(EvaluacionEstandar.RutaTempServer2, EvaluacionEstandar.RutaDBServer2);
                            ArchivosTemporalesEliminar.Add(EvaluacionEstandar.RutaTempServer2);
                        }
                    }
                    catch (System.Exception)
                    {
                    }
                    try
                    {
                        if (System.IO.File.Exists(EvaluacionEstandar.RutaTempServer3))
                        {
                            System.IO.File.Move(EvaluacionEstandar.RutaTempServer3, EvaluacionEstandar.RutaDBServer3);
                            ArchivosTemporalesEliminar.Add(EvaluacionEstandar.RutaTempServer3);
                        }
                    }
                    catch (System.Exception)
                    {
                    }

                    foreach (var item in ArchivosTemporalesEliminar)
                    {
                        EliminarArchivosTemporales(item);
                    }
                    #endregion
                }
                ciclo = esm.ObtenerEstandarPorCicloSiguiente(EvaluacionEstandar.IdEvaluacion, EvaluacionEstandar.Nit);
                if (ciclo != null)
                {
                    ciclo.CantidadCriterios = esm.ObtenerCantidadCriteriosPorEstandar(ciclo.Id_Ciclo);
                    ciclo.StandPorEvaluar = esm.ObtenerCantidaEstdPorEvaluas(ciclo.Id_Ciclo, eval.IdEmpresaEvaluar, EvaluacionEstandar.IdEvaluacion);
                }
            }

            return ciclo;
        }
        public EDCiclo EditarEvaluacionEstandar(EDEvaluacionEstandarMinimo EvaluacionEstandar)
        {
            bool result = false;
            EDCiclo ciclo = null;
            EDEvaluacionEstandarMinimo eval = esm.EditarEvaluacionEstandar(EvaluacionEstandar);
            if (eval.IdEvalEstandarMinimo > 0)
            {
                ciclo = esm.ObtenerEstandarPorCicloG(EvaluacionEstandar.IdCiclo, EvaluacionEstandar.IdCriterio, EvaluacionEstandar.IdEmpresaEvaluar);
                if (ciclo != null)
                {
                    ciclo.Operacion = eval.GuardadoArchivos;
                    ciclo.CantidadCriterios = esm.ObtenerCantidadCriteriosPorEstandar(ciclo.Id_Ciclo);
                    ciclo.StandPorEvaluar = esm.ObtenerCantidaEstdPorEvaluas(ciclo.Id_Ciclo, eval.IdEmpresaEvaluar, EvaluacionEstandar.IdEvaluacion);
                }
            }

            return ciclo;
        }
        public EDCiclo ObtenerEstandaresPorCicloConsulta(int idCiclo, string Nit, int IdEval, int idElemento)
        {
            List<int> Criterios = esm.ListaCriteriosAnteriores(IdEval, idCiclo);
            Criterios.Sort();
            int idcriterio = Criterios[idElemento - 1];
            EDCiclo ciclo = null;
            ciclo = esm.ObtenerEstandarPorCiclo(idCiclo, Nit, IdEval);
            if (ciclo != null)
            {
                ciclo.CantidadCriterios = 100;
                ciclo.Estandar = esm.ObtenerCantidaEstdPorEvaluasCons(idcriterio, IdEval);
                ciclo.ListaCriteriosAnteriores = Criterios;
            }
            return ciclo;
        }
        public EDCiclo ObtenerEstandaresPorCicloConsulta1(int idCiclo, string Nit, int IdEval, int idElemento)
        {
            List<int> Criterios = esm.ListaCriteriosAnteriores(IdEval, idCiclo);

            EDCiclo ciclo = null;
            ciclo = esm.ObtenerEstandarPorCiclo1(idCiclo, Nit, IdEval);
            if (ciclo != null)
            {
                ciclo.CantidadCriterios = 100;
                ciclo.Estandar = esm.ObtenerCantidaEstdPorEvaluasCons(idElemento, IdEval);
                ciclo.ListaCriteriosAnteriores = Criterios;
            }
            return ciclo;
        }
        public List<EDEstandar> ListaEstandarEditar(int idCiclo, string Nit, int IdEval)
        {
            return esm.ListaEstandarEditar(idCiclo, Nit, IdEval);
        }
        
        public EDCiclo ObtenerEstandaresPorCiclo(int idCiclo, string Nit, int IdEval)
        {
            EDCiclo ciclo = null;
            ciclo = esm.ObtenerEstandarPorCiclo(idCiclo, Nit, IdEval);
            if (ciclo != null)
            {
                ciclo.CantidadCriterios = esm.ObtenerCantidadCriteriosPorEstandar(ciclo.Id_Ciclo);
                ciclo.StandPorEvaluar = esm.ObtenerCantidaEstdPorEvaluas(ciclo.Id_Ciclo, Nit, IdEval);
            }
            return ciclo;
        }
        public EDValoracionFinal ObtenerCalificacionFinal(string Nit, int IdEval)
        {
            return esm.ObtenerCalificacion(Nit, IdEval);
        }
        public byte[] GenerarArchivoExcel(string Nit, int IdEval)
        {
            bool terminado = false;
            int preguntasfaltantes = 0;
            List<EDCiclo> CiclosG = esm.ObtenerCiclos();
            foreach (EDCiclo ciclo in CiclosG)
            {
                int preguntasRealizadas = resm.ObtenerCantidadPreguntasAlmomento(ciclo.Id_Ciclo, Nit, IdEval);
                decimal puntoObtenidos = esm.ObtenerPorcentajeObtenidoAlmomento(ciclo.Id_Ciclo, Nit, IdEval);
                int TotalPreguntas = esm.ObtenerCantidadCriteriosPorEstandar(ciclo.Id_Ciclo);
                preguntasfaltantes = preguntasfaltantes + (TotalPreguntas - preguntasRealizadas);
                if (puntoObtenidos > 0)
                {
                    ciclo.PorcenObtenido = (puntoObtenidos * 100) / ciclo.Porcentaje_Max;
                    ciclo.puntoObtenidos = puntoObtenidos;
                }
                else
                {
                    ciclo.PorcenObtenido = 0;
                    ciclo.puntoObtenidos = puntoObtenidos;
                }

            }
            if (preguntasfaltantes == 0)
            {
                terminado = true;
            }

            List<EDCiclo> Ciclos = ObternerDatosArchivoExcel(Nit, IdEval);
            if (Ciclos == null)
                return new byte[] { };
            // Creamos el archivo
            ExcelPackage em = new ExcelPackage();

            //Le añadimos los 'worksheets' que necesitemos.
            //En este caso añadiremos solo uno
            em.Workbook.Worksheets.Add("Estandares Minimos");
            em.Workbook.Worksheets.Add("Ciclos");


            //Creamos un objecto tipo ExcelWorksheet para
            //manejarlo facilmente.
            ExcelWorksheet hoja = em.Workbook.Worksheets[1];
            ExcelWorksheet hojaCiclo = em.Workbook.Worksheets[2];

            int nunInicialCL = 6;
            int nunInicialEst = 6;
            int nunInicialSub = 6;
            int nunInicialCr = 6;

            //Se arma el encabezado del Archivo
            CrearCabeceraArchivo(hoja);
            int idciclohoja = 3;
            //Se Arma el cuerpo del archivo con los datos recuperados de la base de datos
            foreach (var ciclo in Ciclos)
            {



                //Se Inserta las columnas de los ciclos
                hoja.Cells[string.Format("A{0}:A{1}", nunInicialCL, ciclo.CantidadCriterios + nunInicialCL - 1)].Merge = true;
                hoja.Cells[string.Format("A{0}", nunInicialCL)].Value = ciclo.Nombre;
                hoja.Cells[string.Format("A{0}", nunInicialCL)].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                hoja.Cells[string.Format("A{0}", nunInicialCL)].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                hoja.Cells[string.Format("A{0}", nunInicialCL)].Style.TextRotation = 90;
                hoja.Cells[string.Format("A{0}", nunInicialCL)].Style.Font.Bold = true;

                foreach (var estandar in ciclo.Estandares)
                {
                    var cantCell = ((Ciclos.Where(c => c.Id_Ciclo == ciclo.Id_Ciclo).Select(c => c).FirstOrDefault())
                                    .Estandares.Where(e => e.Id_Estandar == estandar.Id_Estandar).Select(e => e).FirstOrDefault())
                                    .SubEstandares.SelectMany(p => p.Criterios).ToList().Count();
                    //Se Inserta las columnas de los Estandares
                    hoja.Cells[string.Format("B{0}:B{1}", nunInicialEst, cantCell + nunInicialEst - 1)].Merge = true;
                    hoja.Cells[string.Format("B{0}:B{1}", nunInicialEst, cantCell + nunInicialEst - 1)].Style.WrapText = true;
                    hoja.Cells[string.Format("B{0}", nunInicialEst)].Value = estandar.Descripcion;
                    hoja.Cells[string.Format("B{0}", nunInicialEst)].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    hoja.Cells[string.Format("B{0}", nunInicialEst)].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    hoja.Cells[string.Format("B{0}", nunInicialEst)].Style.TextRotation = 90;
                    hoja.Cells[string.Format("B{0}", nunInicialEst)].Style.Font.Bold = true;

                    foreach (var sub in estandar.SubEstandares)
                    {
                        var cantCellSub = (((Ciclos.Where(c => c.Id_Ciclo == ciclo.Id_Ciclo).Select(c => c).FirstOrDefault())
                                        .Estandares.Where(e => e.Id_Estandar == estandar.Id_Estandar).Select(e => e).FirstOrDefault())
                                        .SubEstandares.Where(sb => sb.Id_SubEstandar == sub.Id_SubEstandar).Select(sb => sb).FirstOrDefault())
                                        .Criterios.Select(c => c).ToList().Count();
                        //Se Inserta las columnas de los subestandades
                        hoja.Cells[string.Format("C{0}:C{1}", nunInicialSub, cantCellSub + nunInicialSub - 1)].Merge = true;
                        hoja.Cells[string.Format("C{0}:C{1}", nunInicialEst, cantCell + nunInicialEst - 1)].Style.WrapText = true;
                        hoja.Cells[string.Format("C{0}", nunInicialSub)].Value = sub.Descripcion_Corta;
                        hoja.Cells[string.Format("C{0}", nunInicialSub)].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        hoja.Cells[string.Format("C{0}", nunInicialSub)].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        hoja.Cells[string.Format("C{0}", nunInicialSub)].Style.Font.Size = 10;

                        //Se Inserta las columnas de los porcentajes maximos por cada subestandar
                        hoja.Cells[string.Format("F{0}:F{1}", nunInicialSub, cantCellSub + nunInicialSub - 1)].Merge = true;
                        hoja.Cells[string.Format("F{0}:F{1}", nunInicialSub, cantCellSub + nunInicialSub - 1)].Style.WrapText = true;
                        hoja.Cells[string.Format("F{0}", nunInicialSub)].Value = sub.Procentaje_Max;
                        hoja.Cells[string.Format("F{0}", nunInicialSub)].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        hoja.Cells[string.Format("F{0}", nunInicialSub)].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        hoja.Cells[string.Format("F{0}", nunInicialSub)].Style.Font.Size = 12;

                        //Se Inserta las columnas de las calificaciones totales
                        hoja.Cells[string.Format("K{0}:K{1}", nunInicialSub, cantCellSub + nunInicialSub - 1)].Merge = true;
                        hoja.Cells[string.Format("K{0}:K{1}", nunInicialSub, cantCellSub + nunInicialSub - 1)].Style.WrapText = true;
                        hoja.Cells[string.Format("K{0}:K{1}", nunInicialSub, cantCellSub + nunInicialSub - 1)].OfType<int>();
                        hoja.Cells[string.Format("K{0}", nunInicialSub)].Value = sub.CalTotal;
                        hoja.Cells[string.Format("K{0}", nunInicialSub)].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        hoja.Cells[string.Format("K{0}", nunInicialSub)].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        hoja.Cells[string.Format("K{0}", nunInicialSub)].Style.Font.Size = 12;

                        foreach (var criterio in sub.Criterios)
                        {
                            //Se Inserta las columnas de cada creiterio
                            hoja.Cells[string.Format("D{0}", nunInicialCr)].Style.WrapText = true;
                            hoja.Cells[string.Format("D{0}", nunInicialCr)].Value = criterio.Descripcion_Corta;
                            hoja.Cells[string.Format("D{0}", nunInicialCr)].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                            hoja.Cells[string.Format("D{0}", nunInicialCr)].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            hoja.Cells[string.Format("D{0}", nunInicialCr)].Style.Font.Size = 8;

                            //Se Inserta las columnas de la calificacion que puede tomar cada pregunta
                            hoja.Cells[string.Format("E{0}", nunInicialCr)].Style.WrapText = true;
                            decimal valorporpregunta = criterio.ValPorPreguntadec;
                            string valorporpreguntastr = ObtenerValorConformato(criterio.ValPorPregunta);
                            string valorporpreguntastr1 = string.Format("{0:G29}", decimal.Parse(criterio.ValPorPreguntadec.ToString()));

                            int pos = 0;

                            try
                            {
                                string[] a = valorporpreguntastr1.Split(new char[] { '.' });
                                if (a[1] != null)
                                {
                                    pos = a[1].Length;
                                }
                            }
                            catch (Exception)
                            {

                            }
                            try
                            {
                                string[] b = valorporpreguntastr1.Split(new char[] { ',' });
                                if (b[1] != null)
                                {
                                    pos = b[1].Length;
                                }
                            }
                            catch (Exception)
                            {

                            }
                            
                            if (pos == 0) { hoja.Cells[string.Format("E{0}", nunInicialCr)].Style.Numberformat.Format = "#,##0"; }
                            if (pos == 1) { hoja.Cells[string.Format("E{0}", nunInicialCr)].Style.Numberformat.Format = "#,##0.0"; }
                            if (pos == 2) { hoja.Cells[string.Format("E{0}", nunInicialCr)].Style.Numberformat.Format = "#,##0.00"; }
                            if (pos == 3) { hoja.Cells[string.Format("E{0}", nunInicialCr)].Style.Numberformat.Format = "#,##0.000"; }


                            hoja.Cells[string.Format("E{0}", nunInicialCr)].Value = valorporpregunta;

                            hoja.Cells[string.Format("E{0}", nunInicialCr)].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                            hoja.Cells[string.Format("E{0}", nunInicialCr)].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            hoja.Cells[string.Format("E{0}", nunInicialCr)].Style.Font.Size = 9;
                            

                            if (criterio.Evaluacion != null)
                            {
                                if (criterio.Evaluacion.IdValoracionCriterio == (int)EnumPlanificacion.ValoracionStandares.CumpleTotalMente)
                                {
                                    //Se Inserta las columnas con valor 1 de los criterios calificados como cumple totalemte
                                    hoja.Cells[string.Format("G{0}", nunInicialCr)].Style.WrapText = true;
                                    hoja.Cells[string.Format("G{0}", nunInicialCr)].Value = "X";
                                    hoja.Cells[string.Format("G{0}", nunInicialCr)].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                                    hoja.Cells[string.Format("G{0}", nunInicialCr)].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                    hoja.Cells[string.Format("G{0}", nunInicialCr)].Style.Font.Size = 9;

                                    hoja.Cells[string.Format("H{0}", nunInicialCr)].Value = "";
                                    hoja.Cells[string.Format("I{0}", nunInicialCr)].Value = "";
                                    hoja.Cells[string.Format("J{0}", nunInicialCr)].Value = "";
                                }
                                else if (criterio.Evaluacion.IdValoracionCriterio == (int)EnumPlanificacion.ValoracionStandares.NoCumple)
                                {
                                    //Se Inserta las columnas con valor 1 de los criterios calificados como no cumple
                                    hoja.Cells[string.Format("H{0}", nunInicialCr)].Style.WrapText = true;
                                    hoja.Cells[string.Format("H{0}", nunInicialCr)].Value = "X";
                                    hoja.Cells[string.Format("H{0}", nunInicialCr)].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                                    hoja.Cells[string.Format("H{0}", nunInicialCr)].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                    hoja.Cells[string.Format("H{0}", nunInicialCr)].Style.Font.Size = 9;

                                    hoja.Cells[string.Format("G{0}", nunInicialCr)].Value = "";
                                    hoja.Cells[string.Format("I{0}", nunInicialCr)].Value = "";
                                    hoja.Cells[string.Format("J{0}", nunInicialCr)].Value = "";
                                }
                                else if (criterio.Evaluacion.IdValoracionCriterio == (int)EnumPlanificacion.ValoracionStandares.NoAplica)
                                {
                                    if (criterio.Evaluacion.Justificacion.Equals("1"))
                                    {
                                        //Se Inserta las columnas con valor 1 de los criterios calificados como no aplica y con justificacion
                                        hoja.Cells[string.Format("I{0}", nunInicialCr)].Style.WrapText = true;
                                        hoja.Cells[string.Format("I{0}", nunInicialCr)].Value = "X";
                                        hoja.Cells[string.Format("I{0}", nunInicialCr)].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                                        hoja.Cells[string.Format("I{0}", nunInicialCr)].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                        hoja.Cells[string.Format("I{0}", nunInicialCr)].Style.Font.Size = 9;

                                        hoja.Cells[string.Format("G{0}", nunInicialCr)].Value = "";
                                        hoja.Cells[string.Format("H{0}", nunInicialCr)].Value = "";
                                        hoja.Cells[string.Format("J{0}", nunInicialCr)].Value = "";
                                    }
                                    else
                                    {
                                        //Se Inserta las columnas con valor 1 de los criterios calificados como no aplica sin justificacion
                                        hoja.Cells[string.Format("J{0}", nunInicialCr)].Style.WrapText = true;
                                        hoja.Cells[string.Format("J{0}", nunInicialCr)].Value = "X";
                                        hoja.Cells[string.Format("J{0}", nunInicialCr)].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                                        hoja.Cells[string.Format("J{0}", nunInicialCr)].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                        hoja.Cells[string.Format("J{0}", nunInicialCr)].Style.Font.Size = 9;

                                        hoja.Cells[string.Format("G{0}", nunInicialCr)].Value = "";
                                        hoja.Cells[string.Format("H{0}", nunInicialCr)].Value = "";
                                        hoja.Cells[string.Format("I{0}", nunInicialCr)].Value = "";
                                    }
                                }
                            }
                            else
                            {
                                hoja.Cells[string.Format("G{0}", nunInicialCr)].Value = "";
                                hoja.Cells[string.Format("H{0}", nunInicialCr)].Value = "";
                                hoja.Cells[string.Format("I{0}", nunInicialCr)].Value = "";
                                hoja.Cells[string.Format("J{0}", nunInicialCr)].Value = "";
                            }

                            nunInicialCr++;
                        }
                        nunInicialSub = nunInicialSub + cantCellSub;
                    }
                    nunInicialEst = nunInicialEst + cantCell;
                }
                nunInicialCL = nunInicialCL + ciclo.CantidadCriterios;




            }


            //Se genera el pie del informe 
            CrearFinDeArchivo(hoja);

            foreach (var cel in hoja.Cells["A6:K66"])
            {
                cel.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
            }

            hoja.InsertRow(1, 3);
            string RazonSocial = esm.Identidadempresa(Nit).RazonSocial;
            EDEvaluacionEmpresa vigenciayFechaelab = esm.ObtenerVigenciayFechaElab(Nit, IdEval);

            if (RazonSocial != null)
            {
                hoja.Cells[1, 1].Value = "Razón social: " + RazonSocial + " - " + "Nit: " + Nit;
                hoja.Cells[1, 1].Style.Font.Size = 15;
                hoja.Cells[1, 1].Style.Font.Bold = true;
                if (vigenciayFechaelab!=null)
                {
                    if (vigenciayFechaelab.Vigencia != 0)
                    {
                        hoja.Cells[2, 1].Value = "Vigencia: " + vigenciayFechaelab.Vigencia;
                        hoja.Cells[2, 1].Style.Font.Size = 15;
                        hoja.Cells[2, 1].Style.Font.Bold = true;
                    }
                    if (vigenciayFechaelab.Fecha_Elab != DateTime.MinValue)
                    {
                        hoja.Cells[3, 1].Value = "Fecha de Elaboración: " + vigenciayFechaelab.Fecha_Elab.ToShortDateString();
                        hoja.Cells[3, 1].Style.Font.Size = 15;
                        hoja.Cells[3, 1].Style.Font.Bold = true;
                    }
                }
                
            }

            //Ajustar altura filas desde el primer criterio
            int i;
            for (i = 9; i < nunInicialCL + 4; i++)
            {
                hoja.Row(i).Height = 60;
            }
            hoja.Row(i).Height = 40;
            hoja.Row(i + 1).Height = 30;
            hoja.Row(i + 2).Height = 55.5;

            hoja.Column(1).Width = 8.43;
            hoja.Column(2).Width = 8.43;
            hoja.Column(3).Width = 24.29;
            hoja.Column(4).Width = 24.29;
            hoja.Column(5).Width = 10.71;
            hoja.Column(6).Width = 10.5;
            hoja.Column(7).Width = 10.86;
            hoja.Column(8).Width = 8.43;
            hoja.Column(9).Width = 8.43;
            hoja.Column(10).Width = 8.43;
            hoja.Column(11).Width = 13;

            hoja.Row(1).Height = 19.50;
            hoja.Row(2).Height = 19.50;
            hoja.Row(3).Height = 19.50;
            hoja.Row(4).Height = 39;
            hoja.Row(5).Height = 23.25;
            hoja.Row(6).Height = 18.75;
            hoja.Row(7).Height = 16.5;
            hoja.Row(8).Height = 24.75;

            //ep.Save();

            hojaCiclo.Cells["A1:C1"].Merge = true;
            hojaCiclo.Cells["A1"].Value = "PORCENTAJE DE CALIFICACION POR CICLO";
            hojaCiclo.Cells["A1"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
            hojaCiclo.Cells["A1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            hojaCiclo.Cells["A1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            hojaCiclo.Cells["A1"].Style.Font.Bold = true;
            hojaCiclo.Cells["A1"].Style.WrapText = true;
            hojaCiclo.Cells["A1"].Style.Font.Size = 14;
            hojaCiclo.Cells["A1:C1"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

            hojaCiclo.Cells["A2"].Value = "CICLO";
            hojaCiclo.Cells["A2"].Style.Font.Bold = true;
            hojaCiclo.Cells["B2"].Value = "RESULTADO";
            hojaCiclo.Cells["B2"].Style.Font.Bold = true;
            hojaCiclo.Cells["C2"].Value = "% DE CALIFICACIÓN";
            hojaCiclo.Cells["C2"].Style.Font.Bold = true;

            hojaCiclo.Cells["A2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            hojaCiclo.Cells["A2"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            hojaCiclo.Cells["B2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            hojaCiclo.Cells["B2"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            hojaCiclo.Cells["C2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            hojaCiclo.Cells["C2"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            hojaCiclo.Cells["D2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            hojaCiclo.Cells["D2"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            int nunInicial = 3;


            decimal total = 0;
            decimal totalp = 0;
            foreach (var ciclo in CiclosG)
            {
                hojaCiclo.Cells[string.Format("A{0}", nunInicial)].Value = ciclo.Nombre;
                hojaCiclo.Cells[string.Format("A{0}", nunInicial)].Style.WrapText = true;

                decimal resultado = Decimal.Round(ciclo.puntoObtenidos, 2);
                hojaCiclo.Cells[string.Format("B{0}", nunInicial)].Value = resultado;
                hojaCiclo.Cells[string.Format("B{0}", nunInicial)].Style.WrapText = true;
                hojaCiclo.Cells[string.Format("B{0}", nunInicial)].OfType<decimal>();
                totalp = totalp + ciclo.puntoObtenidos;
                decimal porcentaje = Decimal.Round(ciclo.PorcenObtenido, 2);
                hojaCiclo.Cells[string.Format("C{0}", nunInicial)].Value = porcentaje;
                hojaCiclo.Cells[string.Format("C{0}", nunInicial)].Style.WrapText = true;
                hojaCiclo.Cells[string.Format("C{0}", nunInicial)].OfType<decimal>();
                total = total + ciclo.PorcenObtenido;
                nunInicial++;
            }
            decimal totalr = Decimal.Round(total, 2);
            decimal totalpr = Decimal.Round(totalp, 2);
            hojaCiclo.Cells[nunInicial, 1].Value = "TOTAL";
            hojaCiclo.Cells[nunInicial, 1].Style.Font.Bold = true;
            hojaCiclo.Cells[nunInicial, 2].Value = totalpr;
            hojaCiclo.Cells[nunInicial, 2].Style.Font.Bold = true;
            hojaCiclo.Cells[nunInicial, 3].Value = totalr;
            hojaCiclo.Cells[nunInicial, 3].Style.Font.Bold = true;
            hojaCiclo.Cells[nunInicial, 3].OfType<decimal>();
            hojaCiclo.Cells[nunInicial, 3].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
            hojaCiclo.Cells[nunInicial, 3].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
            nunInicial++;

            hojaCiclo.Row(1).Height = 40;
            hojaCiclo.Column(1).Width = 50;
            hojaCiclo.Column(2).Width = 25;
            hojaCiclo.Column(3).Width = 25;

            foreach (var cel in hojaCiclo.Cells[string.Format("A1:C{0}", Ciclos.Count + 3)])
            {
                cel.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
            }

            //AGREGAMOS LA GRAFICA
            var chart = (hojaCiclo.Drawings.AddChart("PORCENTAJE DE CALIFICACION POR CICLO", OfficeOpenXml.Drawing.Chart.eChartType.Radar) as ExcelRadarChart);
            chart.Title.Text = "PORCENTAJE DE CALIFICACION POR CICLO";
            chart.SetPosition(1, 0, 5, 0);
            chart.SetSize(600, 400); // Tamaño de la gráfica
            chart.Legend.Remove(); // Si desea eliminar la leyenda
            //chart.YAxis.MaxValue = 100;
            chart.DataLabel.ShowPercent = true;
            // Define donde está la información de la gráfica.
            var serie = chart.Series.Add(hojaCiclo.Cells[string.Format("C3:C{0}", Ciclos.Count + 2)], hojaCiclo.Cells[string.Format("A3:A{0}", Ciclos.Count + 2)]);


            var ChartP = hojaCiclo.Drawings.AddChart("chart", eChartType.ColumnClustered);
            var seriesP = ChartP.Series.Add(hojaCiclo.Cells[string.Format("C3:C{0}", Ciclos.Count + 2)], hojaCiclo.Cells[string.Format("A3:A{0}", Ciclos.Count + 2)]);
            ChartP.Series[0].Header = "Porcentaje obtenido (%)";
            ChartP.Border.Fill.Color = System.Drawing.Color.Gray;
            ChartP.Title.Text = "PORCENTAJE DE CALIFICACION POR CICLO";
            ChartP.SetSize(768, 491);
            ChartP.ShowDataLabelsOverMaximum = true;
            ChartP.SetPosition(22, 0, 5, 0);


            if (terminado)
            {
                //Hojas Ciclos detalle
                List<EDCiclo> Cicloses = esm.ObtenerCiclos();
                foreach (EDCiclo ciclo in Cicloses)
                {
                    int preguntasRealizadas = resm.ObtenerCantidadPreguntasAlmomento(ciclo.Id_Ciclo, Nit, IdEval);
                    decimal puntoObtenidos = resm.ObtenerPorcentajeObtenidoAlmomento(ciclo.Id_Ciclo, Nit, IdEval);
                    int TotalPreguntas = esm.ObtenerCantidadCriteriosPorEstandar(ciclo.Id_Ciclo);
                    if (preguntasRealizadas > 0)
                    {
                        List<EDEstandar> Estandares = esm.ListaEstandarEditar(ciclo.Id_Ciclo, Nit, IdEval);
                        foreach (var item in Estandares)
                        {
                            var calificacion = resm.ObtenerPorcentajeObtenidoEstandar(ciclo.Id_Ciclo, item.Id_Estandar, Nit, IdEval);
                            if (calificacion > 0)
                            {
                                item.Calificacion = (calificacion * 100) / item.Porcentaje_Max;
                                item.Porcentaje = calificacion;
                            }
                            else
                            {
                                item.Calificacion = 0;
                            }
                            foreach (var item1 in item.SubEstandares)
                            {
                                var calificacionsub = resm.ObtenerPorcentajeObtenidoSubEstandar(ciclo.Id_Ciclo, item1.Id_SubEstandar, Nit, IdEval);
                                if (calificacionsub > 0)
                                {
                                    item1.Resultado = (calificacionsub * 100) / item1.Procentaje_Max;
                                    item1.Porcentaje = calificacionsub;
                                }
                                else
                                {
                                    item1.Resultado = 0;
                                }
                            }
                        }
                        ciclo.PorcenRespondido = (preguntasRealizadas * 100) / TotalPreguntas;
                        ciclo.PorcenObtenido = (puntoObtenidos * 100) / ciclo.Porcentaje_Max;
                        ciclo.puntoObtenidos = puntoObtenidos;
                        ciclo.Estandares = Estandares;
                    }
                    else
                    {
                        ciclo.PorcenRespondido = 0;
                    }
                }


                foreach (var item in Cicloses)
                {
                    int filault = 40;
                    em.Workbook.Worksheets.Add(item.Nombre);
                    Color graycolor = ColorTranslator.FromHtml("#d8dbd6");
                    ExcelWorksheet hojaC = em.Workbook.Worksheets[idciclohoja];
                    var Chart = hojaC.Drawings.AddChart("chart", eChartType.ColumnClustered);
                    var Chart1 = hojaC.Drawings.AddChart("chart1", eChartType.ColumnClustered);
                    idciclohoja++;
                    var rows = hojaC.Row(1);
                    rows.Height = 27;
                    hojaC.Cells[1, 1].Style.Font.Bold = true;
                    hojaC.Cells[1, 1].Style.Font.Size = 16;
                    hojaC.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    hojaC.Cells[1, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    hojaC.Cells[1, 1].Value = "CICLO " + item.Nombre;
                    hojaC.Cells[1, 1, 1, 6].Merge = true;

                    var rows1 = hojaC.Row(2);
                    rows1.Height = 32;
                    for (int i1 = 1; i1 < 7; i1++)
                    {
                        hojaC.Cells[2, i1].Style.Font.Bold = true;
                        hojaC.Cells[2, i1].Style.Font.Size = 12;
                        hojaC.Cells[2, i1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        hojaC.Cells[2, i1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        hojaC.Cells[2, i1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        hojaC.Cells[2, i1].Style.Fill.BackgroundColor.SetColor(graycolor);
                        hojaC.Cells[2, i1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        hojaC.Cells[2, i1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        hojaC.Cells[2, i1].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        hojaC.Cells[2, i1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        hojaC.Cells[2, i1].Style.WrapText = true;
                    }
                    hojaC.Cells[2, 1].Value = "ESTANDAR";
                    hojaC.Cells[2, 2].Value = "RESULTADO";
                    hojaC.Cells[2, 3].Value = "PORCENTAJE OBTENIDO (%)";
                    hojaC.Cells[2, 4].Value = "ÍTEM ESTANDAR";
                    hojaC.Cells[2, 5].Value = "RESULTADO";
                    hojaC.Cells[2, 6].Value = "PORCENTAJE OBTENIDO (%)";

                    hojaC.Column(1).Width = 50;
                    hojaC.Column(2).Width = 15;
                    hojaC.Column(3).Width = 15;
                    hojaC.Column(4).Width = 60;
                    hojaC.Column(5).Width = 15;
                    hojaC.Column(6).Width = 15;
                    int fila = 3;
                    int Primerafila = 3;
                    int ultimafila = 3;

                    int Primerafila1 = 3;
                    int ultimafila1 = 3;


                    foreach (var estandar in item.Estandares)
                    {
                        int numerosubesta = 0;
                        if (estandar.SubEstandares != null)
                        {
                            int fila1 = fila;
                            numerosubesta = estandar.SubEstandares.Count;
                            foreach (var subes in estandar.SubEstandares)
                            {
                                hojaC.Cells[fila1, 4].Value = subes.Descripcion_Corta;
                                hojaC.Cells[fila1, 4].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                hojaC.Cells[fila1, 4].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                hojaC.Cells[fila1, 4].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                hojaC.Cells[fila1, 4].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                hojaC.Cells[fila1, 4].Style.WrapText = true;
                                hojaC.Cells[fila1, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                hojaC.Cells[fila1, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                                hojaC.Cells[fila1, 5].Value = subes.Porcentaje;
                                hojaC.Cells[fila1, 5].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                hojaC.Cells[fila1, 5].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                hojaC.Cells[fila1, 5].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                hojaC.Cells[fila1, 5].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                                decimal porc1 = (subes.Porcentaje / subes.Procentaje_Max) * 100;
                                porc1 = Decimal.Round(porc1, 2);

                                hojaC.Cells[fila1, 6].Value = porc1;
                                hojaC.Cells[fila1, 6].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                hojaC.Cells[fila1, 6].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                hojaC.Cells[fila1, 6].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                hojaC.Cells[fila1, 6].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                ultimafila1 = fila1;
                                fila1++;
                            }
                        }


                        hojaC.Cells[fila, 1, fila + numerosubesta - 1, 1].Merge = true;
                        hojaC.Cells[fila, 1].Value = estandar.Descripcion;
                        hojaC.Cells[fila, 1, fila + numerosubesta - 1, 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        hojaC.Cells[fila, 1, fila + numerosubesta - 1, 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        hojaC.Cells[fila, 1, fila + numerosubesta - 1, 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        hojaC.Cells[fila, 1, fila + numerosubesta - 1, 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        hojaC.Cells[fila, 1, fila + numerosubesta - 1, 1].Style.WrapText = true;
                        hojaC.Cells[fila, 1, fila + numerosubesta - 1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        hojaC.Cells[fila, 1, fila + numerosubesta - 1, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                        hojaC.Cells[fila, 2, fila + numerosubesta - 1, 2].Merge = true;
                        hojaC.Cells[fila, 2].Value = estandar.Porcentaje;
                        hojaC.Cells[fila, 2, fila + numerosubesta - 1, 2].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        hojaC.Cells[fila, 2, fila + numerosubesta - 1, 2].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        hojaC.Cells[fila, 2, fila + numerosubesta - 1, 2].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        hojaC.Cells[fila, 2, fila + numerosubesta - 1, 2].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        hojaC.Cells[fila, 2, fila + numerosubesta - 1, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        hojaC.Cells[fila, 2, fila + numerosubesta - 1, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                        hojaC.Cells[fila, 3, fila + numerosubesta - 1, 3].Merge = true;
                        decimal porc = (estandar.Porcentaje / estandar.Porcentaje_Max) * 100;
                        porc = Decimal.Round(porc, 2);
                        hojaC.Cells[fila, 3].Value = porc;
                        hojaC.Cells[fila, 3, fila + numerosubesta - 1, 3].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        hojaC.Cells[fila, 3, fila + numerosubesta - 1, 3].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        hojaC.Cells[fila, 3, fila + numerosubesta - 1, 3].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        hojaC.Cells[fila, 3, fila + numerosubesta - 1, 3].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        hojaC.Cells[fila, 3, fila + numerosubesta - 1, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        hojaC.Cells[fila, 3, fila + numerosubesta - 1, 3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                        //hojaC.Cells[fila, 2].Value = estandar.Porcentaje_Max;
                        //hojaC.Cells[fila, 3].Value = estandar.Calificacion;




                        ultimafila = fila;
                        fila = fila + numerosubesta;
                        filault = filault + fila;
                    }

                    Primerafila = filault;
                    foreach (var estandar in item.Estandares)
                    {
                        hojaC.Cells[filault, 1].Value = estandar.Descripcion;
                        decimal porc = (estandar.Porcentaje / estandar.Porcentaje_Max) * 100;
                        porc = Decimal.Round(porc, 2);
                        hojaC.Cells[filault, 2].Value = porc;
                        ultimafila = filault;
                        hojaC.Column(ultimafila).Width = 0.5;
                        filault++;
                    }

                    var series = Chart.Series.Add(hojaC.Cells[Primerafila, 2, ultimafila, 2], hojaC.Cells[Primerafila, 1, ultimafila, 1]);
                    Chart.Series[0].Header = "Porcentaje obtenido (%)";
                    Chart.Border.Fill.Color = System.Drawing.Color.Gray;
                    Chart.Title.Text = "RESULTADOS DE ESTANDARES DEL CICLO " + item.Nombre;
                    Chart.SetSize(768, 491);
                    Chart.ShowDataLabelsOverMaximum = true;
                    Chart.SetPosition(1, 0, 7, 0);


                    var series1 = Chart1.Series.Add(hojaC.Cells[Primerafila1, 6, ultimafila1, 6], hojaC.Cells[Primerafila1, 4, ultimafila1, 4]);
                    Chart1.Series[0].Header = "Porcentaje obtenido (%)";
                    Chart1.Border.Fill.Color = System.Drawing.Color.Gray;
                    Chart1.Title.Text = "RESULTADOS DE ÍTEMS DE ESTANDARES DEL CICLO " + item.Nombre;
                    Chart1.SetSize(768, 491);
                    Chart1.ShowDataLabelsOverMaximum = true;
                    Chart1.SetPosition(28, 0, 7, 0);

                }
            }






            return em.GetAsByteArray();
        }
        public string ObtenerValorConformato(string valor)
        {
            try
            {
                return Regex.Match(valor, @"(([0-9]?(\.|\,)[1-9])*0*[1-9]*)*").Value;
            }
            catch
            {
                return valor;
            }
        }

        private static void CrearFinDeArchivo(ExcelWorksheet hoja)
        {
            hoja.Cells["A66:E66"].Merge = true;
            hoja.Cells["A66"].Value = "TOTALES";
            hoja.Cells["A66"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            hoja.Cells["A66"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            hoja.Cells["A66"].Style.Font.Size = 14;
            hoja.Cells["A66"].Style.Font.Bold = true;
            hoja.Cells["A66:E66"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

            hoja.Cells["F66"].Value = 100;
            hoja.Cells["F66"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            hoja.Cells["F66"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            hoja.Cells["F66"].Style.Font.Size = 14;
            hoja.Cells["F66"].Style.Font.Bold = true;
            hoja.Cells["F66"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

            hoja.Cells["G66"].Value = "";
            hoja.Cells["H66"].Value = "";
            hoja.Cells["I66"].Value = "";
            hoja.Cells["J66"].Value = "";

            hoja.Cells["K66"].Formula = "SUM(K6:K65)";
            hoja.Cells["K66"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            hoja.Cells["K66"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            hoja.Cells["K66"].Style.Font.Size = 14;
            hoja.Cells["K66"].Style.Font.Bold = true;
            hoja.Cells["K66"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

            hoja.Cells["A67:K67"].Merge = true;
            hoja.Cells["A67"].Value = "*Cuando se cumple con el ítem del estándar la calificación será la máxima del respectivo ítem, de lo contrario su calificación será igual a cero (0). Si el estándar No Aplica, se deberá justificar tal situación y se calificará con el porcentaje máximo del ítem indicado para cada estándar. En caso de no justificarse, la calificación del estándar será igual a cero (0)";
            hoja.Cells["A67"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            hoja.Cells["A67"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Justify;
            hoja.Cells["A67"].Style.Font.Size = 8;
            hoja.Cells["A67:K67"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);


            hoja.Cells["A68:K68"].Merge = true;
            hoja.Cells["A68"].Value = "SSTEl presente formulario es documento público, no se debe consignar hechos o manifestaciones falsas y está sujeta a las sanciones establecidas en los artículos 288 y 294 de la Ley 599 de 2000(Código Penal Colombiano).";
            hoja.Cells["A68"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            hoja.Cells["A68"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Justify;
            hoja.Cells["A68"].Style.Font.Size = 8;
            hoja.Cells["A68:K68"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

            hoja.Cells["A69:D69"].Merge = true;
            hoja.Cells["A69"].Value = "FIRMA DEL EMPLEADOR O CONTRATANTE";
            hoja.Cells["A69"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Bottom;
            hoja.Cells["A69"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
            hoja.Cells["A69"].Style.Font.Size = 10;
            //hoja.Cells["A69:D69"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
            hoja.Cells["A69:D69"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            hoja.Cells["A69:D69"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            hoja.Cells["A69:D69"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            //hoja.Cells["D69:F69"].Merge = true;
            //hoja.Cells["D69"].Value = "";
            //hoja.Cells["D69:F69"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

            hoja.Cells["E69:K69"].Merge = true;
            hoja.Cells["E69"].Value = "FIRMA DEL RESPONSABLE  DE LA EJECUCIÓN SG- SST";
            hoja.Cells["E69"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Bottom;
            hoja.Cells["E69"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
            hoja.Cells["E69"].Style.Font.Size = 10;
            //hoja.Cells["E69:K69"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
            hoja.Cells["E69:K69"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            hoja.Cells["E69:K69"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            hoja.Cells["E69:K69"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        }
        private static void CrearCabeceraArchivo(ExcelWorksheet hoja)
        {
            hoja.Cells["A1:K1"].Merge = true;
            hoja.Cells["A1"].Value = "ESTÁNDARES MÍNIMOS SG-SST";
            hoja.Cells["A1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            hoja.Cells["A1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            hoja.Cells["A1"].Style.Font.Size = 30;
            hoja.Cells["A1"].Style.Font.Bold = true;
            hoja.Cells["A1:K1"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

            hoja.Cells["A2:K2"].Merge = true;
            hoja.Cells["A2:K2"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
            hoja.Cells["A2"].Value = "TABLA DE VALORES Y CALIFICACIÓN";
            hoja.Cells["A2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            hoja.Cells["A2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            hoja.Cells["A2"].Style.Font.Size = 18;
            hoja.Cells["A2"].Style.Font.Bold = true;

            hoja.Cells["A3:A5"].Merge = true;
            hoja.Cells["A3:A5"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
            hoja.Cells["A3"].Value = "CICLO";
            hoja.Cells["A3"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            hoja.Cells["A3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            hoja.Cells["A3"].Style.WrapText = true;
            hoja.Cells["A3"].Style.Font.Size = 9;
            hoja.Cells["A3"].Style.Font.Bold = true;

            hoja.Cells["B3:C5"].Merge = true;
            hoja.Cells["B3:C5"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
            hoja.Cells["B3"].Value = "ESTÁNDAR";
            hoja.Cells["B3"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            hoja.Cells["B3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            hoja.Cells["B3"].Style.WrapText = true;
            hoja.Cells["B3"].Style.Font.Size = 9;
            hoja.Cells["B3"].Style.Font.Bold = true;

            hoja.Cells["D3:D5"].Merge = true;
            hoja.Cells["D3:D5"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
            hoja.Cells["D3"].Value = "ÍTEM DEL ESTÁNDAR";
            hoja.Cells["D3"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            hoja.Cells["D3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            hoja.Cells["D3"].Style.WrapText = true;
            hoja.Cells["D3"].Style.Font.Size = 9;
            hoja.Cells["D3"].Style.Font.Bold = true;

            hoja.Cells["E3:E5"].Merge = true;
            hoja.Cells["E3:E5"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
            hoja.Cells["E3"].Value = "VALOR DEL ÍTEM DEL ESTÁNDAR";
            hoja.Cells["E3"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            hoja.Cells["E3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            hoja.Cells["E3"].Style.WrapText = true;
            hoja.Cells["E3"].Style.Font.Size = 9;
            hoja.Cells["E3"].Style.Font.Bold = true;

            hoja.Cells["F3:F5"].Merge = true;
            hoja.Cells["F3:F5"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
            hoja.Cells["F3"].Value = "PESO PORCENTUAL";
            hoja.Cells["F3"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            hoja.Cells["F3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            hoja.Cells["F3"].Style.WrapText = true;
            hoja.Cells["F3"].Style.Font.Size = 9;
            hoja.Cells["F3"].Style.Font.Bold = true;

            hoja.Cells["G3:J3"].Merge = true;
            hoja.Cells["G3:J5"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
            hoja.Cells["G3"].Value = "PUNTAJE POSIBLE";
            hoja.Cells["G3"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            hoja.Cells["G3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            hoja.Cells["G3"].Style.WrapText = true;
            hoja.Cells["G3"].Style.Font.Size = 9;
            hoja.Cells["G3"].Style.Font.Bold = true;

            hoja.Cells["G4:G5"].Merge = true;
            hoja.Cells["G4:G5"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
            hoja.Cells["G4"].Value = "CUMPLE TOTALMENTE";
            hoja.Cells["G4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            hoja.Cells["G4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            hoja.Cells["G4"].Style.WrapText = true;
            hoja.Cells["G4"].Style.Font.Size = 8;
            hoja.Cells["G4"].Style.Font.Bold = true;

            hoja.Cells["H4:H5"].Merge = true;
            hoja.Cells["H4:H5"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
            hoja.Cells["H4"].Value = "NO CUMPLE";
            hoja.Cells["H4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            hoja.Cells["H4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            hoja.Cells["H4"].Style.WrapText = true;
            hoja.Cells["H4"].Style.Font.Size = 9;
            hoja.Cells["H4"].Style.Font.Bold = true;

            hoja.Cells["I4:J4"].Merge = true;
            hoja.Cells["I4:J4"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
            hoja.Cells["I4"].Value = "NO APLICA";
            hoja.Cells["I4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            hoja.Cells["I4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            hoja.Cells["I4"].Style.WrapText = true;
            hoja.Cells["I4"].Style.Font.Size = 9;
            hoja.Cells["I4"].Style.Font.Bold = true;

            hoja.Cells["I5"].Value = "JUSTIFICA";
            hoja.Cells["I5"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
            hoja.Cells["I5"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            hoja.Cells["I5"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            hoja.Cells["I5"].Style.WrapText = true;
            hoja.Cells["I5"].Style.Font.Size = 9;
            hoja.Cells["I5"].Style.Font.Bold = true;

            hoja.Cells["J5"].Value = "NO JUSTIFICA";
            hoja.Cells["J5"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
            hoja.Cells["J5"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            hoja.Cells["J5"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            hoja.Cells["J5"].Style.WrapText = true;
            hoja.Cells["J5"].Style.Font.Size = 9;
            hoja.Cells["J5"].Style.Font.Bold = true;

            hoja.Cells["K3:K5"].Merge = true;
            hoja.Cells["K3:K5"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
            hoja.Cells["K3"].Value = "CALIFICACIÓN DE LA EMPRESA O CONTRATANTE";
            hoja.Cells["K3"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            hoja.Cells["K3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            hoja.Cells["K3"].Style.WrapText = true;
            hoja.Cells["K3"].Style.Font.Size = 9;
            hoja.Cells["K3"].Style.Font.Bold = true;
        }
        private List<EDCiclo> ObternerDatosArchivoExcel(string Nit, int IdEval)
        {
            List<EDCiclo> Ciclos = null;
            List<EDCiclo> CiclosCalificados = esm.ObtenerDatosInformeExcel(Nit, IdEval);
            if (CiclosCalificados[0].Estandares[0].SubEstandares[0].Criterios.Count > 0)
            {
                Ciclos = esm.ObtenerDatosInicialesInformeExcel();
                foreach (var _ciclo in Ciclos)
                {
                    _ciclo.CantidadCriterios = esm.ObtenerCantidadCriteriosPorEstandar(_ciclo.Id_Ciclo);
                    foreach (var _estandar in _ciclo.Estandares)
                    {
                        foreach (var _sub in _estandar.SubEstandares)
                        {
                            _sub.CalTotal = ((CiclosCalificados.Where(c => c.Id_Ciclo == _ciclo.Id_Ciclo).Select(c => c).FirstOrDefault())
                                .Estandares.Where(e => e.Id_Estandar == _estandar.Id_Estandar).Select(e => e).FirstOrDefault())
                                .SubEstandares.Where(sb => sb.Id_SubEstandar == _sub.Id_SubEstandar).Select(sb => sb.CalTotal).FirstOrDefault();
                            foreach (var _criterio in _sub.Criterios)
                            {
                                _criterio.Evaluacion = (((CiclosCalificados.Where(c => c.Id_Ciclo == _ciclo.Id_Ciclo).Select(c => c).FirstOrDefault())
                                .Estandares.Where(e => e.Id_Estandar == _estandar.Id_Estandar).Select(e => e).FirstOrDefault())
                                .SubEstandares.Where(sb => sb.Id_SubEstandar == _sub.Id_SubEstandar).Select(sb => sb).FirstOrDefault())
                                .Criterios.Where(cr => cr.Id_Criterio == _criterio.Id_Criterio).Select(cr => cr.Evaluacion).FirstOrDefault();
                            }
                        }
                    }
                }
            }

            return Ciclos;
        }
        public List<EDActividad> ObtenerActividades(string Nit, int IdEval)
        {
            return esm.ObtenerActividades(Nit, IdEval);
        }
        public byte[] ObtenerActividadesExcel(string Nit, int IdEval)
        {
            List<EDActividad> Actividades = esm.ObtenerActividades(Nit, IdEval);
            Actividades = Actividades.OrderBy(s => s.Id_Actividad).ThenBy(n => n.FechaFin).ToList();

            if (Actividades.Count > 0)
            {
                string vigencia = Actividades[0].Vigencia;
                ExcelPackage Ac = new ExcelPackage();

                Ac.Workbook.Worksheets.Add("Plan de mejora");

                ExcelWorksheet ew1 = Ac.Workbook.Worksheets[1];

                ew1.Cells["A1:D1"].Merge = true;
                ew1.Cells["A1"].Value = "Plan de Mejora para los Estándares Mínimos SGSST - Vigencia "+ vigencia;
                ew1.Cells["A1"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                ew1.Cells["A1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                ew1.Cells["A1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ew1.Cells["A1"].Style.Font.Bold = true;
                ew1.Cells["A1"].Style.WrapText = true;
                ew1.Cells["A1"].Style.Font.Size = 14;
                ew1.Cells["A1:D1"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                ew1.Cells["A2"].Value = "ACTIVIDAD";
                ew1.Cells["A2"].Style.Font.Bold = true;
                ew1.Cells["B2"].Value = "RESPONSABLE";
                ew1.Cells["B2"].Style.Font.Bold = true;
                ew1.Cells["C2"].Value = "FECHA FIN";
                ew1.Cells["C2"].Style.Font.Bold = true;
                ew1.Cells["D2"].Value = "ESTANDAR";
                ew1.Cells["D2"].Style.Font.Bold = true;
                ew1.Cells["A2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                ew1.Cells["A2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ew1.Cells["B2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                ew1.Cells["B2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ew1.Cells["C2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                ew1.Cells["C2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ew1.Cells["D2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                ew1.Cells["D2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                int nunInicial = 3;

                foreach (var actividad in Actividades)
                {
                    ew1.Cells[string.Format("A{0}", nunInicial)].Value = actividad.Descripcion;
                    ew1.Cells[string.Format("A{0}", nunInicial)].Style.WrapText = true;
                    ew1.Cells[string.Format("B{0}", nunInicial)].Value = actividad.Responsable;
                    ew1.Cells[string.Format("B{0}", nunInicial)].Style.WrapText = true;
                    ew1.Cells[string.Format("C{0}", nunInicial)].Value = string.Format("{0}/{1}/{2}", actividad.FechaFin.Year, actividad.FechaFin.Month, actividad.FechaFin.Day);
                    ew1.Cells[string.Format("C{0}", nunInicial)].Style.WrapText = true;
                    ew1.Cells[string.Format("D{0}", nunInicial)].Value = actividad.Accion;
                    ew1.Cells[string.Format("D{0}", nunInicial)].Style.WrapText = true;
                    nunInicial++;
                }

                ew1.Row(1).Height = 40;
                ew1.Row(3).Height = 40;
                ew1.Column(1).Width = 50;
                ew1.Column(2).Width = 40;
                ew1.Column(3).Width = 20;
                ew1.Column(4).Width = 40;

                for (int i = 2; i < nunInicial; i++)
                {
                    for (int i1 = 1; i1 < 5; i1++)
                    {
                        ew1.Cells[i, i1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    }
                }

                ew1.InsertRow(1, 3);

                for (int i = 1; i < 4; i++)
                {
                    for (int i1 = 1; i1 < 6; i1++)
                    {
                        ew1.Cells[i, i1].Style.Font.Bold = true;
                        ew1.Cells[i, i1].Style.Font.Size = 11;
                    }
                }


                //foreach (var cel in ew1.Cells[string.Format("A3:D{0}", Actividades.Count)])
                //{
                //    cel.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                //}
                //FileInfo fileInfo = new FileInfo(@"D:\Archivos\Actividades.xlsx");
                //Ac.SaveAs(fileInfo);
                return Ac.GetAsByteArray();
            }
            else
                return new byte[] { };
        }
        public void EliminarArchivosTemporales(string ruta)
        {
            try
            {
                if (System.IO.File.Exists(ruta))
                {
                    System.IO.File.Delete(ruta);
                }
            }
            catch (System.Exception)
            {
            }

        }

        public List<EDEvaluacionEmpresa> EvaluacionCompleta(string Nit, int IdEval)
        {
            List<EDEvaluacionEmpresa> ListaEval = esm.EvaluacionCompleta(Nit, IdEval);
            //if (ListaEval != null)
            //{
            //    if (ListaEval[0] != null)
            //    {
            //        ListaEval[0].ValoracionFinal = esm.ObtenerCalificacion(Nit, IdEval);
            //        List<EDCiclo> Ciclos = esm.ObtenerCiclos();
            //        foreach (EDCiclo ciclo in Ciclos)
            //        {
            //            int preguntasRealizadas = resm.ObtenerCantidadPreguntasAlmomento(ciclo.Id_Ciclo, Nit, IdEval);
            //            decimal puntoObtenidos = resm.ObtenerPorcentajeObtenidoAlmomento(ciclo.Id_Ciclo, Nit, IdEval);
            //            int TotalPreguntas = esm.ObtenerCantidadCriteriosPorEstandar(ciclo.Id_Ciclo);
            //            if (preguntasRealizadas > 0)
            //            {
            //                List<EDEstandar> Estandares = esm.ListaEstandarEditar(ciclo.Id_Ciclo, Nit, IdEval);
            //                foreach (var item in Estandares)
            //                {
            //                    var calificacion = resm.ObtenerPorcentajeObtenidoEstandar(ciclo.Id_Ciclo, item.Id_Estandar, Nit, IdEval);
            //                    if (calificacion > 0)
            //                    {
            //                        item.Calificacion = (calificacion * 100) / item.Porcentaje_Max;
            //                        item.Porcentaje = calificacion;
            //                    }
            //                    else
            //                    {
            //                        item.Calificacion = 0;
            //                    }
            //                }
            //                ciclo.PorcenRespondido = (preguntasRealizadas * 100) / TotalPreguntas;
            //                ciclo.PorcenObtenido = (puntoObtenidos * 100) / ciclo.Porcentaje_Max;
            //                ciclo.puntoObtenidos = puntoObtenidos;
            //                ciclo.Estandares = Estandares;
            //            }
            //            else
            //            {
            //                ciclo.PorcenRespondido = 0;
            //            }
            //        }
            //        ListaEval[0].ListaCiclosReporte = Ciclos;
            //    }
            //}

            return ListaEval;

        }

        public bool EliminarEvaluacion(EDEvaluacionEmpresa EDEvaluacionEmpresa)
        {
            return esm.EliminarEvaluacion(EDEvaluacionEmpresa);
        }
        public string CerrarEvaluacion(int IdEval, int idempresa)
        {
            return esm.CerrarEvaluacion(IdEval, idempresa);
        }
        public bool verificarcriterio(int idCriterio, int idEvaluacionEmpresa)
        {
            return esm.verificarcriterio(idCriterio, idEvaluacionEmpresa);
        }

    }
}
