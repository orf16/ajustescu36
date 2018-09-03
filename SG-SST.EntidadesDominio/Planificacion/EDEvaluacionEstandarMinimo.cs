using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.EntidadesDominio.Planificacion
{
    public class EDEvaluacionEstandarMinimo
    {
        public int IdEvalEstandarMinimo { get; set; }
        public int IdEmpresaEvaluar { get; set; }
        public int IdCriterio { get; set; }
        public int IdCiclo { get; set; }
        public int IdValoracionCriterio { get; set; }
        public string Justificacion { get; set; }
        public string Valor { get; set; }
        public string Nit { get; set; }
        public List<EDActividad> Actividades { get; set; }
        public int IdEvaluacion { get; set; }
        //para validación
        public string Respuesta { get; set; }

        //Archivos

        public string Filedownload1 { get; set; }
        public string NombreArchivo1 { get; set; }
        public string Ruta1 { get; set; }
        public string Filedownload2 { get; set; }
        public string NombreArchivo2 { get; set; }
        public string Ruta2 { get; set; }
        public string Filedownload3 { get; set; }
        public string NombreArchivo3 { get; set; }
        public string Ruta3 { get; set; }

        public string RutaTemp { get; set; }
        public string RutaDB { get; set; }
        public string RutaTempServer1 { get; set; }
        public string RutaDBServer1 { get; set; }
        public string RutaTempServer2 { get; set; }
        public string RutaDBServer2 { get; set; }
        public string RutaTempServer3 { get; set; }
        public string RutaDBServer3 { get; set; }
        public bool GuardadoArchivos { get; set; }
    }
}
