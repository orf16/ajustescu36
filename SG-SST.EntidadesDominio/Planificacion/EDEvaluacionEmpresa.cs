using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.EntidadesDominio.Planificacion
{
    public class EDEvaluacionEmpresa
    {
        public int Pk_Id_EvaluacionEmpresa { get; set; }
        public int Vigencia { get; set; }
        public int Estado { get; set; }
        public DateTime Fecha_Elab { get; set; }
        public int Fk_Id_Empresa { get; set; }
        public string Consecutivo { get; set; }
        public List<EDEvaluacionEstandarMinimo> ListaEstandarMinimo { get; set; }
        public List<EDCiclo> ListaCiclos { get; set; }
        public int Numeroevaluar { get; set; }
        public int NumeroTotal { get; set; }
        //Para reportes
        public EDValoracionFinal ValoracionFinal { get; set; }
        public List<EDCiclo> ListaCiclosReporte { get; set; }
    }
}
