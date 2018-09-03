
namespace SG_SST.Models.Aplicacion
{
    using SG_SST.Models.Empresas;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    [Table("Tbl_Producto_Por_Criterio")]
    public class ProductoPorCriterio
    {
        [Key]
        public int Id_Pk_ProductoPorCriterio { get; set; }

        [ForeignKey("ServicioOProducto")]
        public int Fk_Id_ServicioOProducto { get; set; }
        [ForeignKey("PK_ServicioOProducto")]
        public virtual ServicioOProducto ServicioOProducto { get; set; }

        [ForeignKey("CriterioSST")]
        public int Fk_Id__CriterioSST { get; set; }

        [ForeignKey("PK_CriterioSST")]
        public virtual CriterioSST CriterioSST { get; set; }

        public ICollection<ProveedorPorProductoPorCriterio> ProveedorPorProductoPorCriterio { get; set; }

        public string ToString()
        {
            string cadena = " Id_Pk_ProductoPorCriterio: " + Id_Pk_ProductoPorCriterio +
                            " ServicioOProducto: " + ((ServicioOProducto == null) ? Fk_Id_ServicioOProducto.ToString() : ServicioOProducto.ToString()) +
                            " CriterioSST: " + ((CriterioSST == null) ? Fk_Id__CriterioSST.ToString() : CriterioSST.ToString());
            return cadena;
        }
    }
}
