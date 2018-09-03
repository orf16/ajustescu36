using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SG_SST.Models.Empresas
{

[Table("Tbl_UsuarioRol")]

    public class UsuarioRol
    {
        [Key]

        public int Pk_Id_UsuarioRol { get; set; }

        [ForeignKey("Rol")]
        public int Fk_Id_Rol { get; set; }

        [ForeignKey("Pk_Id_Rol")]
        public virtual Rol Rol { get; set; }

    /// <summary>
    /// 
    /// </summary>

        [ForeignKey("Usuario")]
        public int Fk_Id_Usuario { get; set; }
        [ForeignKey("Pk_Id_Usuario")]

        public virtual Usuario Usuario { get; set; }

        public string ToString()
        {
            string cadena = " Pk_Id_UsuarioRol: " + Pk_Id_UsuarioRol +
                            " Rol: " + ((Rol == null) ? Fk_Id_Rol.ToString() : Rol.ToString());                          
            
            return cadena;
        }
        
        }

}