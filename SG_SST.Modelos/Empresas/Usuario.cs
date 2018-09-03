using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SG_SST.Models.Empleado;
using SG_SST.Models.Empresas;



namespace SG_SST.Models.Empresas
{


    [Table("Tbl_Usuario")]
    public class Usuario
    {
        [Key]
        public int Pk_Id_Usuario { get; set; }

        [Display(Name = "Tipo Documento")]
        [ForeignKey("TipoDocumentos")]
        public int Fk_Tipo_Documento { get; set; }

        [ForeignKey("PK_IDTipo_Documento")]
        public virtual TipoDocumento TipoDocumentos { get; set; }


        [Display(Name = "Numero Documento")]
        public int Numero_Documento { get; set; }

        [Display(Name = "Nombre Usuario")]
        public string Nombre_Usuario { get; set; }

     
        [Display(Name = "Firma Digital")]
        public string Imagen_Firma { get; set; }


        public ICollection<UsuarioRol> UsuarioRoles { get; set; }
        public string nit_Empresa { get; set; }


        [ForeignKey("Empresa")]
        public int Fk_Id_Empresa { get; set; }
        [ForeignKey("Pk_Id_Empresa")]
        public virtual Empresa Empresa { get; set; }

        [NotMapped]
        public int[] SelectedRolCode { get; set; }

        public string ToString()
        {
            string cadena = " Pk_Id_Usuario: " + Pk_Id_Usuario +
                            " TipoDocumentos: " + ((TipoDocumentos == null) ? Fk_Tipo_Documento.ToString() : TipoDocumentos.ToString()) +
                            " Numero_Documento: " + Numero_Documento +
                            " Nombre_Usuario: " + Nombre_Usuario +
                            " Imagen_Firma: " + Imagen_Firma +
                            " nit_Empresa: " + nit_Empresa +
                            " Empresa: " + ((Empresa == null) ? Fk_Id_Empresa.ToString() : Empresa.ToString());
            if (UsuarioRoles != null)
                foreach (UsuarioRol usuariorol in UsuarioRoles)
                    cadena = cadena + " UsuarioRoles:{ " + usuariorol.ToString() + "}";
            return cadena;
        }
    }
}