using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Comunicaciones
{
    [Table("Tbl_ComunicacionesEncuestasPreguntas")]
    public class ComunicacionesEncuestasPreguntas
    {
        [Key]
        public int pk_id_pregunta { get; set; }
        public int fk_pk_id_encuesta { get; set; }
        public string pregunta { get; set; }
        public string control { get; set; }

    }
}
