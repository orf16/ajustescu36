using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Planificacion
{
    [Table("Tbl_Evaluacion_Estandares_Minimos")]
    public partial class Evaluacion_Estandar_Minimo
    {
        public Evaluacion_Estandar_Minimo()
        {
            this.ActividadesCriterio = new List<Actividad_Criterio>();

        }

        [Key]
        public int Pk_Id_Eval_Estandar_Minimo { get; set; }
        //[ForeignKey("Empresa_Evaluar")]
        public int Fk_Id_Empresa_Evaluar { get; set; }
        [ForeignKey("Criterio")]
        public int Fk_Id_Criterio { get; set; }
        [ForeignKey("Config_Valoracion_SubEstand")]
        public int Fk_Id_Config_Valoracion_SubEstand { get; set; }
        [StringLength(2000)]
        public string Justificacion { get; set; }

        public decimal Valor_Calificacion { get; set; }

        [StringLength(2000)]
        public string NombreArchivo1 { get; set; }
        [StringLength(2000)]
        public string NombreArchivo1_download { get; set; }
        [StringLength(3000)]
        public string Ruta1 { get; set; }
        [StringLength(2000)]
        public string NombreArchivo2 { get; set; }
        public string NombreArchivo2_download { get; set; }
        [StringLength(3000)]
        public string Ruta2 { get; set; }
        [StringLength(2000)]
        public string NombreArchivo3 { get; set; }
        public string NombreArchivo3_download { get; set; }
        [StringLength(3000)]
        public string Ruta3 { get; set; }

        //[ForeignKey("Pk_Id_Empresa_Evaluar")]
        //public virtual Empresa_Evaluar Empresa_Evaluar { get; set; }
        [ForeignKey("Pk_Id_Criterio")]
        public virtual Criterio Criterio { get; set; }
        [ForeignKey("Pk_Id_Config_Valoracion_SubEstand")]
        public virtual Config_Valoracion_SubEstand Config_Valoracion_SubEstand { get; set; }

        public virtual ICollection<Actividad_Criterio> ActividadesCriterio { get; set; }


        [Required(ErrorMessage = "Debe seleccionar la evaluacion")]
        [ForeignKey("EvaluacionEmpresa")]
        public int Fk_Id_EvaluacionEmpresa { get; set; }
        [ForeignKey("Pk_Id_EvaluacionEmpresa")]
        public virtual EvaluacionEmpresa EvaluacionEmpresa { get; set; }

    }
}
