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
    [Table("Tbl_IncidentesAT1")]
    public class IncidentesAT1
    {
        [Key]
        public int PK_Incidentes_AT { get; set; }

        /// <summary>
        /// I. Informe sobre la Investigacion
        /// </summary>
        /// 
        public string boIncidente { get; set; }///REQUERIDO

        public string boIncidente1 { get; set; }///REQUERIDO
        public string boAccidenteTrabajo { get; set; }///REQUERIDO
        public string boLeve { get; set; }///REQUERIDO
        public string boGrave { get; set; }///REQUERIDO
        public string boMortal { get; set; }///REQUERIDO
        public DateTime FechaInvestigacionI { get; set; }///REQUERIDO
        public List<Departamento> DepartamentoI { get; set; }///REQUERIDO
        public int pk_DepartamentoI { get; set; }///REQUERIDO
        public List<Municipio> MunicipioI { get; set; }///REQUERIDO
        public int pk_MunicipioI { get; set; }///REQUERIDO
        public string DireccionI { get; set; }///REQUERIDO
        public string HoraInicialI { get; set; }///REQUERIDO
        public string HoraFinalI { get; set; }///REQUERIDO
        public string ResponsablesI { get; set; }///REQUERIDO
        public bool FotografiasI { get; set; }///REQUERIDO
        public bool VideosI { get; set; }///REQUERIDO
        public bool CintasAudioI { get; set; }///REQUERIDO
        public bool IlustracionesI { get; set; }///REQUERIDO
        public bool DiagramasI { get; set; }///REQUERIDO
        public bool OtrosI { get; set; }///REQUERIDO
        public string CualesI { get; set; }///REQUERIDO
        public string myFile1 { get; set; }
        public string NitEmpresa { get; set; }
    }
}
