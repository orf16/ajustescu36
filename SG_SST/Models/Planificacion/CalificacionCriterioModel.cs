using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SG_SST.Models.Planificacion
{
    public class CalificacionCriterioModel
    {
        public int IdEvalEstandarMinimo { get; set; }
        [Required()]
        public int IdEmpresaEvaluar { get; set; }
        [Required()]
        public int IdCriterio { get; set; }
        [Required()]
        public int IdCiclo { get; set; }
        [Required()]
        public int IdValoracionCriterio { get; set; }
        [Required()]
        public int IdEvaluacion { get; set; }
        public string Justificacion { get; set; }
        public IEnumerable<ActividadModel> Actividades { get; set; }

        //Archivos Justifica
        public string Filedownload1 { get; set; }
        public string Filedownload2 { get; set; }
        public string Filedownload3 { get; set; }
        public string NombreArchivo1 { get; set; }
        public string NombreArchivo2 { get; set; }
        public string NombreArchivo3 { get; set; }
        public string Ruta1 { get; set; }
        public string Ruta2 { get; set; }
        public string Ruta3 { get; set; }

    }

    public class ActividadModel
    {
        public int Id_Actividad { get; set; }
        [Required()]
        public string Descripcion { get; set; }
        [Required()]
        public string Responsable { get; set; }
        [Required()]
        public DateTime FechaFin { get; set; }
        public string strFechaFin { get; set; }
        public string Accion { get; set; }
        public string Id_Actividad_String { get; set; }
        public string Vigencia { get; set; }

    }
}