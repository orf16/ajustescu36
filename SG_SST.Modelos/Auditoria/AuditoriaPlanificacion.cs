﻿
namespace SG_SST.Models.Auditoria
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Table("Tbl_AuditoriaPlanificacionSistema")]
    public class AuditoriaPlanificacion
    {
        [Key]
        public int Pk_Id_AuditoriaPlanificacionSistema { get; set; }

        public string NitEmpresa { get; set; }

        public string Empresa { get; set; }

        public string NombreUsuario { get; set; }

        public string IdentificacionUsuario { get; set; }

        public DateTime FechaTransaccion { get; set; }

        public string IpEquipoUsuario { get; set; }

        public string TipoAccion { get; set; }

        public string Informacion { get; set; }

        public string Modulo { get; set; }

        public string SubModulo { get; set; }

        public string Opcion { get; set; }

    }
}