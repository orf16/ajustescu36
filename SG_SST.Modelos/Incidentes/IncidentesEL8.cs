using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Incidentes
{
     [Table("Tbl_IncidentesEL8")]
    public class IncidentesEL8
    {
        [Key]
        public int PK_Incidentes_EL8 { get; set; }
        public int FK_Incidentes_EL8 { get; set; }
        public string tempTipoIdentificacionVIII1 { get; set; }
        public string JefeInmediatoVIII1 { get; set; }
        public string CargoVIII1 { get; set; }
        public string NumeroIdentificacionVIII1 { get; set; }

        public string tempTipoIdentificacionVIII2 { get; set; }
        public string JefeInmediatoVIII2 { get; set; }
        public string CargoVIII2 { get; set; }
        public string NumeroIdentificacionVIII2 { get; set; }

        public string tempTipoIdentificacionVIII3 { get; set; }
        public string JefeInmediatoVIII3 { get; set; }
        public string CargoVIII3 { get; set; }
        public string NumeroIdentificacionVIII3 { get; set; }

        public string tempTipoIdentificacionVIII4 { get; set; }
        public string JefeInmediatoVIII4 { get; set; }
        public string CargoVIII4 { get; set; }
        public string NumeroIdentificacionVIII4 { get; set; }

        public string tempTipoIdentificacionVIII5 { get; set; }
        public string JefeInmediatoVIII5 { get; set; }
        public string CargoVIII5 { get; set; }
        public string NumeroIdentificacionVIII5 { get; set; }

        public string tempTipoIdentificacionVIII6 { get; set; }
        public string JefeInmediatoVIII6 { get; set; }
        public string CargoVIII6 { get; set; }
        public string NumeroIdentificacionVIII6 { get; set; }


        public string tempTipoIdentificacionVIII7 { get; set; }
        public string EspecialistaOcupacionalVIII { get; set; }
        public string LicenciaNumVIII1 { get; set; }
        public string LicenciaAnioVIII1 { get; set; }
        public string NumeroIdentificacionVIII7 { get; set; }


        public string tempTipoIdentificacionVIII8 { get; set; }
        public string RepresentanteArlVIII8 { get; set; }
        public string LicenciaNumeroVIII8 { get; set; }
        public string LicenciaAnioVIII8 { get; set; }
        public string NumeroIdentificacionVIII8 { get; set; }
        public string EmpresaRepresentaVIII8 { get; set; }
        public string NitVIII8 { get; set; }
        public string myFile2 { get; set; }
        public string myFile3 { get; set; }
        public string myFile4 { get; set; }
        public string myFile5 { get; set; }
        public string myFile6 { get; set; }
        public string myFile7 { get; set; }
        public string myFile8 { get; set; }
        public string myFile9 { get; set; }
        public string NitEmpresa { get; set; }
    }
}
