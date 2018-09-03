﻿using System;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SG_SST.Models.Revision
{
    [Table("Tbl_AgendaRevision")]
    public class AgendaRevision
    {
        [Key]
        public int PK_Id_Agenda { get; set; }


        [ForeignKey("Tbl_ActaRevision")]
        public int FK_ActaRevision { get; set; }
        /// <summary>
        /// Obtiene y establece un objeto de tipo empresa
        /// </summary>
        [ForeignKey("PK_Id_ActaRevision")]
        public virtual ActaRevision Tbl_ActaRevision { get; set; }

        public string Titulo { get; set; }
        
        public string Desarrollo { get; set; }


        public string ToString()
        {
            string cadena = "PK_Id_Agenda: " + PK_Id_Agenda +
                            " Titulo: " + Titulo +
                            " Desarrollo: " + Desarrollo +
                            " Acta: " + ((Tbl_ActaRevision == null) ? FK_ActaRevision.ToString() : Tbl_ActaRevision.Num_Acta.ToString());
            return cadena;
        }

    }
}
