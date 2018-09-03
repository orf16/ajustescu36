using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Incidentes
{
    [Table("Tbl_IncidentesEL3")]
    public class IncidentesEL3
    {
        [Key]
        public int PK_Incidentes_EL3 { get; set; }
        public int FK_Incidentes_EL3 { get; set; }
        public string PlantaIII { get; set; }
        public string MisionIII { get; set; }
        public string CooperadorIII { get; set; }
        public string EstudianteIII { get; set; }
        public string IndependienteIII { get; set; }
        public string TipoIdentificacionIII { get; set; }
        public string NumIdentificacionIII { get; set; }
        public string PrimerApellidoIII { get; set; }
        public string SegundoApellidoIII { get; set; }
        public string PrimerNombreIII { get; set; }
        public string SegundoNombreIII { get; set; }
        public string FechaNacimientoIII { get; set; }
        public string SexoIII { get; set; }
        public string EPSAfiliadoIII { get; set; }
        public string AFPAfiliadoIII { get; set; }
        public string ARLAfiliadoIII { get; set; }
        public string TelefonoIII { get; set; }
        public string FaxIII { get; set; }
        public string EmailTrabajadorIII { get; set; }
        public string DireccionTrabajadorIII { get; set; }
        public string ZonaIII { get; set; }
        public string CodigoDeptoTrabajadorIII { get; set; }
        public string DeptoTrabajadorIII { get; set; }
        public string CodigoMncpioTrabajadorIII { get; set; }
        public string MncpioTrabajadorIII { get; set; }
        public string NitEmpresa { get; set; }
    }
}
