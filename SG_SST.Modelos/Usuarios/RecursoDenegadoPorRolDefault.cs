﻿
namespace SG_SST.Models.Usuarios
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Table("Tbl_RecursoDenegadoPorRolDefault")]
    public class RecursoDenegadoPorRolDefault
    {
        [Key]
        public int Pk_Id_RecursoDenegadoPorRolDefault { get; set; }

        [ForeignKey("RolSistema")]
        public int Fk_Id_RolSistema { get; set; }

        [ForeignKey("RecursoSistema")]
        public int Fk_Id_Recurso { get; set; }   

        [ForeignKey("Pk_Id_RolSistema")]
        public virtual RolSistema RolSistema { get; set; }

        [ForeignKey("Pk_Id_RecursoSistema")]
        public virtual RecursoSistema RecursoSistema { get; set; }

      
    }
}