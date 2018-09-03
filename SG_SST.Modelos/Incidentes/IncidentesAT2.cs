using SG_SST.Models.Empresas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Incidentes
{
    [Table("Tbl_IncidentesAT2")]
    public class IncidentesAT2
    {
        /// <summary>
        /// II. Identificacion General del Empleador
        /// </summary>
        /// 

        [Key]
        public int PK_Incidentes_AT2 { get; set; }
        public int FK_incidentes_AT2 { get; set; }
        public string boTipoVinculacionII { get; set; }
        public string TipoIdentificacionII { get; set; }
        public string ActividadEconomicaII { get; set; }
        public string NumeroIdentificacionII { get; set; }
        public string NombreRazonSocialII { get; set; }
        public string DireccionPpalII { get; set; }
        public string TelefonoII { get; set; }
        public string FaxII { get; set; }
        public List<Departamento> DepartamentoII { get; set; }
        public List<Municipio> MunicipioII { get; set; }
        public string st_DepartamentoII { get; set; }///REQUERIDO
        public string st_MunicipioII { get; set; }///REQUERIDO
        public string EmailII { get; set; }
        public string ZonaUrbanaII { get; set; }
        public bool SedePrincipalII { get; set; }
        public string CodigoActEconoCentroTrabajoII { get; set; }
        public string ActEconoCentroTrabajoII { get; set; }
        public string CentroCostoTelefonoII { get; set; }
        public string CentroCostoFaxII { get; set; }
        public string DireccionCentroTrabajoII { get; set; }
        public string ZonaII { get; set; }
        public List<Departamento> DeptoCentroCostoII { get; set; }
        public List<Municipio> MncpioCentroCostoII { get; set; }
        public int pk_DeptoCentroCostoII { get; set; }///REQUERIDO
        public int pk_MncpioCentroCostoII { get; set; }///REQUERIDO
        public string NitEmpresa { get; set; }

    }
}
