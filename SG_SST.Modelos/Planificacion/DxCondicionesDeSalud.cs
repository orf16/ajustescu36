
namespace SG_SST.Models.Planificacion
{
    using Newtonsoft.Json;
    using SG_SST.Models.Ausentismo;
    using SG_SST.Models.Empresas;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Table("Tbl_Dx_Condiciones_De_Salud")]
    public class DxCondicionesDeSalud
    {
        /// <summary>
        /// Obtiene y establece la clave primaria del diagnostico general de condiciones de salud.
        /// </summary>
        [Key]
        public int Pk_DxCondicionesDeSalud { get; set; }

        /// <summary>
        /// Obtiene y establece la fecha del diagnostico general de condiciones de salud.
        /// </summary>
        public DateTime Fecha_Dx { get; set; }

        /// <summary>
        /// Obtiene y establece la fecha inicial del diagnostico general de condiciones de salud.
        /// </summary>
        public DateTime Fecha_Inicial_Dx { get; set; }

        /// <summary>
        /// Obtiene y establece la fecha final del diagnostico general de condiciones de salud.
        /// </summary>
        public DateTime Fecha_Final_Dx { get; set; }

        /// <summary>
        /// Obtiene y establece la vigencia diagnostico general de condiciones de salud.
        /// </summary>
        public int vigencia { get; set; }

        /// <summary>
        /// Obtiene y establece el lugar donde se presenta el peligro.
        /// </summary>
        public string Lugar { get; set; }

        /// <summary>
        /// Obtiene y establece el numero de trababajdores de la zona o lugar .
        /// </summary>
        public int Trabajadores_Lugar { get; set; }

        public string Responsable_informacion { get; set; }

        public string Profesion_Responsable { get; set; }

        public string Tarjeta_Profesional { get; set; }

        /// <summary>
        /// Obtiene y establece la clave foranea a la tabla  sede.
        /// </summary>
        [ForeignKey("Sede")]
        public int FK_Sede { get; set; }

        /// <summary>
        /// Obtiene y establece un objeto de sede.
        /// </summary>
        [ForeignKey("Pk_Id_Sede")]
        public virtual Sede Sede { get; set; }
        [ForeignKey("Procesos")]
        public int? FK_Proceso { get; set; }

        [ForeignKey("Pk_Id_Proceso")]
        public virtual Proceso Procesos { get; set; }

        public virtual ICollection<SintomatologiaDx> SintomatologiaDx { get; set; }
        public virtual ICollection<PruebasClinicasDx> PruebasClinicasDx { get; set; }
        public virtual ICollection<PruebasPClinicasDx> PruebasPClinicasDx { get; set; }
        public virtual ICollection<DiagnosticoCie10Dx> DiagnosticoCie10Dx { get; set; }

        public virtual ICollection<ClasificacionPeligroDx> ClasificacionPeligroDx { get; set; }


        public string ToString()
        {
            string cadena = "Pk_DxCondicionesDeSalud: " + Pk_DxCondicionesDeSalud +
                            " Fecha_Dx: " + Fecha_Dx +
                            " Fecha_Inicial_Dx: " + Fecha_Final_Dx +
                            " vigencia: " + vigencia +
                            " Lugar: " + Lugar +
                            " Trabajadores_Lugar: " + Trabajadores_Lugar +
                            " Responsable_informacion: " + Responsable_informacion +
                            " Profesion_Responsable: " + Profesion_Responsable +
                            " Tarjeta_Profesional: " + Tarjeta_Profesional +
                            " Sede: " + ((Sede == null) ? FK_Sede.ToString() : Sede.Nombre_Sede ) +
                            " Proceso: " + ((Procesos == null) ? FK_Proceso.ToString() : Procesos.Descripcion_Proceso);
            foreach (SintomatologiaDx sdx in SintomatologiaDx)            
                cadena = cadena + " SintomatologiasDx:{ " + sdx.ToString() + "}";
            foreach (PruebasClinicasDx pcdx in PruebasClinicasDx)
                cadena = cadena + " PruebasClinicasDx:{ " + pcdx.ToString() + "}";
            foreach (PruebasPClinicasDx ppcdx in PruebasPClinicasDx)
                cadena = cadena + " PruebasPClinicasDx:{ " + ppcdx.ToString() + "}";
            foreach (DiagnosticoCie10Dx cie10dx in DiagnosticoCie10Dx)
                cadena = cadena + " DiagnosticosCie10Dx:{ " + cie10dx.ToString() + "}";
            foreach (ClasificacionPeligroDx clas10dx in ClasificacionPeligroDx)
                cadena = cadena + " DiagnosticosCie10Dx:{ " + clas10dx.ToString() + "}";

            return cadena;
        }


    }


}
