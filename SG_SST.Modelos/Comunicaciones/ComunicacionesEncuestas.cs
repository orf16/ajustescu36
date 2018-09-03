﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Comunicaciones
{
    [Table("Tbl_ComunicacionesEncuestas")]
    public class ComunicacionesEncuestas
    {
        [Key]
        public int pk_id_encuesta { get; set; }
        public int fk_pk_id_encuesta { get; set; }
        public int pk_id_encuesta_publicada { get; set; }
        public string pregunta { get; set; }
        public string respuesta { get; set; }
        public string control { get; set; }
        public string fechacreacion { get; set; }
        public string URL { get; set; }
        public string NitEmpresa { get; set; }

    }
}
