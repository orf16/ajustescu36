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
    [Table("Tbl_IncidentesAT4")]
    public class IncidentesAT4
    {
        /// <summary>
        /// MODULO IV
        /// </summary>
        /// 
        [Key]
        public int PK_Incidentes_AT4 { get; set; }
        public int FK_incidentes_AT4 { get; set; }
        public string FechaOcurrenciaIV { get; set; }
        public string HoraOcurrenciaIV { get; set; }
        public string boJornadaIV { get; set; }
        public string boDiaSemanaIV { get; set; }
        public string LaborHabitualIV { get; set; }
        public string TipoIncidenteIV { get; set; }
        public string EspecTipoIncidenteIV { get; set; }
        public string IPSAtendioIV { get; set; }
        public string ZonaIV { get; set; }
        public string TiempoLaboradoPrevioIV { get; set; }
        public string LugarExactoIV { get; set; }
        public string SitioExactoIV { get; set; }
        public bool OtroSitioIV { get; set; }
        public string EspecifiqueIV { get; set; }

        public List<Departamento> DepartamentoIV { get; set; }
        public List<Municipio> MncpioIV { get; set; }
        public int pk_DepartamentoIV { get; set; }///REQUERIDO
        public int pk_MncpioIV { get; set; }///REQUERIDO
                                            ///
        public string EspecifiqueLaborHabitual { get; set; }
        public string NitEmpresa { get; set; }
    }
}
