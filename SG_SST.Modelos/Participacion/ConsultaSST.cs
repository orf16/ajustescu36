using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SG_SST.Models.Participacion
{
    [Table("Tbl_ConsultaSST")]
    public class ConsultaSST
    {
        [Key]
        public int Pk_Id_Consulta { get; set; }
        public int Fk_Empresa { get; set; }
       [StringLength(200)]
        public string Tipo_Consulta { get; set; }

       [StringLength(5000)]
        public string Descripcion_Consulta { get; set; }
        public int Id_Usuario { get; set; }

        public DateTime Fecha_Consulta { get; set; }


        //Gestion de Consultas
        public DateTime Fecha_Revision { get; set; }
        public string Observaciones { get; set; }

        public string NombreArchivo1 { get; set; }

        public string NombreArchivo1_download { get; set; }

        public string Ruta1 { get; set; }

        public string NombreArchivo2 { get; set; }
        public string NombreArchivo2_download { get; set; }

        public string Ruta2 { get; set; }

        public string NombreArchivo3 { get; set; }
        public string NombreArchivo3_download { get; set; }

        public string Ruta3 { get; set; }

        public string ToString()
        {
            string cadena = " Pk_Id_Consulta: " + Pk_Id_Consulta +
                            " Fk_Empresa: " + Fk_Empresa +
                            " Tipo_Consulta: " + Tipo_Consulta +
                            " Descripcion_Consulta: " + Descripcion_Consulta +
                            " Id_Usuario: " + Id_Usuario +
                            " Fecha_Consulta: " + Fecha_Consulta +
                            " Fecha_Revision: " + Fecha_Revision +
                            " Observaciones: " + Observaciones +
                            " NombreArchivo1: " + NombreArchivo1 +
                            " NombreArchivo1_download: " + NombreArchivo1_download +
                            " Ruta1: " + Ruta1 +
                            " NombreArchivo2: " + NombreArchivo2 +
                            " NombreArchivo2_download: " + NombreArchivo2_download +
                            " Ruta2: " + Ruta2 +
                            " NombreArchivo3: " + NombreArchivo3 +
                            " NombreArchivo3_download: " + NombreArchivo3_download +
                            " Ruta3: " + Ruta3;
                            
            return cadena;
        }

    }
}
