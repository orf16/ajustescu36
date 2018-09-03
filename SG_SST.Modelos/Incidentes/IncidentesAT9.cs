using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Incidentes
{
    [Table("Tbl_IncidentesAT9")]
    public class IncidentesAT9
    {
        [Key]
        public int PK_Incidentes_AT9 { get; set; }
        public int FK_incidentes_AT9 { get; set; }
        public string TipoIdentJefeInmediantoIX { get; set; }
        public string NumIdentJefeInmediatoIX { get; set; }
        public string JefeInmediatoNombresIX { get; set; }
        public string JefeInmediatoCargoIX { get; set; }
        public string DescripcionAnalisisIX { get; set; }
        public string TipoIdentEncargadoPSOIX { get; set; }
        public string NumIdentPSOIX { get; set; }
        public string EncargadoPSONombresIX { get; set; }
        public string EncargadoPSOCargoIX { get; set; }
        public string TipoIdentCOPASOIX { get; set; }
        public string COPASONumIdentIX { get; set; }
        public string COPASONombresCompletosIX { get; set; }
        public string COPASOCargoIX { get; set; }
        public string TipoIdentEncargadosPSOIX { get; set; }
        public string TipoIdentBrigadistaIX { get; set; }
        public string NumeroIdentBrigadistaIX { get; set; }
        public string BrigadistaNombresIX { get; set; }
        public string BrigadistaCargoIX { get; set; }
        public string TipoIdentParticipanteIX { get; set; }
        public string NumIdentParticipanteIX { get; set; }
        public string ParticipanteNombreIX { get; set; }
        public string ParticipanteCargoIX { get; set; }
        public string TipoIdentAnalisisIX { get; set; }
        public string EmpresaRepresentaIX { get; set; }
        public string ObservacionEspecialistaIX { get; set; }
        public string TipoIdentRepresentanteARLIX { get; set; }
        public string RepresentanteARLNombresIX { get; set; }
        public string NumLicenciaEspecialistaSGSSTIX1 { get; set; }
        public string anioLicenciaEspecialistaSGSSTIX1 { get; set; }
        public string NumIdentRepresentanteARLIXIX { get; set; }
        public string TipoIdentEspecialistaSGSSTIX { get; set; }
        public string EspecialistaSGSSTNombresIX { get; set; }
        public string NumLicenciaEspecialistaSGSSTIX2 { get; set; }
        public string anioLicenciaEspecialistaSGSSTIX2 { get; set; }
        public string NumIdentEspecialistaSGSSTIX { get; set; }
        public string FechaVerificacionXII { get; set; }
        public string TipoIdentJefeInmediantoIXTI { get; set; }
        public string TipoIdentEncargadoPSOIXTI { get; set; }
        public string TipoIdentCOPASOIXTI { get; set; }
        public string TipoIdentBrigadistaIXTI { get; set; }
        public string TipoIdentParticipanteIXTI { get; set; }
        public string TipoIdentRepresentanteARLIXTI { get; set; }
        public string TipoIdentEspecialistaSGSSTIXTI { get; set; }
        public string myFile3 { get; set; }
        public string myFile4 { get; set; }
        public string myFile5 { get; set; }
        public string myFile6 { get; set; }
        public string myFile7 { get; set; }
        public string myFile9 { get; set; }
        public string myFile10 { get; set; }
        public string NitEmpresa { get; set; }
    }
}
