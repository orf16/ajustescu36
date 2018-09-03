using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Incidentes
{
    [Table("Tbl_IncidentesAT6")]
    public class IncidentesAT6
    {
        [Key]
        public int PK_Incidentes_AT6 { get; set; }
        public int FK_incidentes_AT6 { get; set; }
        public string GasesUnidadVI { get; set; }
        public string MarcaVI { get; set; }
        public string AgenteVI { get; set; }
        public string MaterialVI { get; set; }
        public string ModeloVI { get; set; }
        public string ReferenciaVI { get; set; }
        public string PesoVI { get; set; }
        public string PesoUnidadMedidaVI { get; set; }
        public string AlturaVI { get; set; }
        public string AnchoVI { get; set; }
        public string VolumenVI { get; set; }
        public string ProfundidadVI { get; set; }
        public string VelocidadVI { get; set; }
        public string TiempoUsoVI { get; set; }
        public string TiempoUsoVIA { get; set; }
        public string FechaMantenimientoVI { get; set; }
        public string ReparadoVI { get; set; }

        public string ExplosivosVI { get; set; }
        public string ExplosivosUnidadMedidaVI { get; set; }
        public string ExplosivosCantidadVI { get; set; }

        public string GasesVI { get; set; }
        public string GasesUnidadMedidaVI { get; set; }
        public string GasesCantidadVI { get; set; }


        public string TemperaturaVI { get; set; }
        public string TemperaturaUnidadMedidaVI { get; set; }


        public string SustanciaVI { get; set; }
        public string SustanciaUnidadMedidaVI { get; set; }
        public string SustanciaCantidadVI { get; set; }


        public string VoltajeElectricoVI { get; set; }
        public string VoltajeElectricoUnidadMedidaVI { get; set; }
        public string VoltajeElectricoCantidadVI { get; set; }

        public string DetallesAdicionalesVI { get; set; }
        public string EPPVI { get; set; }
        public string TrabajadorEPPVI { get; set; }
        public string ObservacionesVI { get; set; }
        public string VelocidadUnidadMedidaVI { get; set; }
        public string NitEmpresa { get; set; }
    }
}
