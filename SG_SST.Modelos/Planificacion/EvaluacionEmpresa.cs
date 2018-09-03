using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SG_SST.Models.Empresas;
using System.ComponentModel;

namespace SG_SST.Models.Planificacion
{
    [Table("Tbl_EvaluacionEmpresa")]
    public class EvaluacionEmpresa
    {
        public EvaluacionEmpresa()
        {
            this.Evaluacion_Estandar_Minimos = new List<Evaluacion_Estandar_Minimo>();
        }

        [Key]
        public int Pk_Id_EvaluacionEmpresa { get; set; }

        [DisplayName("Vigencia")]
        [Required(ErrorMessage = "Debe ingresar el valor de {0}")]
        public int Vigencia { get; set; }

        [DisplayName("Estado")]
        [Required(ErrorMessage = "Debe ingresar el valor de {0}")]
        public int Estado { get; set; }

        [DisplayName("Consecutivo")]
        [Required(ErrorMessage = "Debe ingresar el valor de {0}")]
        public string Consecutivo { get; set; }

        [DisplayName("Fecha de Elaboración")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Debe ingresar el valor de {0}")]
        public DateTime Fecha_Elab { get; set; }

        [ForeignKey("Empresa")]
        public int Fk_Id_Empresa { get; set; }
        [ForeignKey("Pk_Id_Empresa")]
        public virtual Empresa Empresa { get; set; }


        public ICollection<Evaluacion_Estandar_Minimo> Evaluacion_Estandar_Minimos { get; set; }
    }
}
