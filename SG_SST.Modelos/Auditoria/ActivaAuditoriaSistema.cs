using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Auditoria
{
     [Table("Tbl_ActivaAuditoriaSistema")]
    public class ActivaAuditoriaSistema
    {
        [Key]
        public int Pk_Id_ActivaAuditoriaSistema { get; set; }
        public bool EsActivaEmpresa { get; set; }
        public bool EsActivaLiderazgoGerencial { get; set; }
        public bool EsActivaPolitica { get; set; }
        public bool EsActivaOrganizacion { get; set; }
        public bool EsActivaPlanificacion { get; set; }
        public bool EsActivaAplicacion { get; set; }
        public bool EsActivaReporteEInvestigacion { get; set; }
        public bool EsActivaMedicionYEvaluaciónSGSST { get; set; }
        public bool EsActivaParticipacionTrabajadores { get; set; }
        public bool EsActivaRevisionPorLaDireccion { get; set; }
        public bool EsActivaConfiguracionMaestros { get; set; }
        public bool EsActivaUsuariosDelSistema { get; set; }

    }
}
