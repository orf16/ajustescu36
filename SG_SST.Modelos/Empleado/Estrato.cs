﻿using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.SqlServer;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

 namespace SG_SST.Models.Planificacion
{
       [Table("Tbl_Estrato")]
     public class Estrato
    {
        [Key]
           public int PK_Estrato { get; set; }
        public string Descripcion_Estrato { get; set; }



    }
}
