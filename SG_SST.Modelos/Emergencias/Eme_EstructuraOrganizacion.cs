using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SG_SST.Models.Emergencias
{


   [Table("Tbl_Eme_EstructuraOrganizacion")]
    public class Eme_EstructuraOrganizacion
    {

       [Key]
       public int id_EstucturaOrg { get; set; }


       public int fk_id_sede { get; set; }

       public string Jefe_Estructura{ get; set; }


        public string cargo_Empleado { get; set; }



        [ForeignKey("OrgEstructuraEme")]
        public int? Fk_Id_EstructuraOrg { get; set; }

        [ForeignKey("id_EstucturaOrg")]
        public virtual Eme_EstructuraOrganizacion OrgEstructuraEme { get; set; }



    }
}
