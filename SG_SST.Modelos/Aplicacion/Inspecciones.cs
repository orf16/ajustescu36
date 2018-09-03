namespace SG_SST.Models.Aplicacion
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SG_SST.Models.Empresas;

    [Table("Tbl_Inspecciones")]
    public class Inspecciones
    {
        [Key]
        public int Pk_Id_Inspecciones { get; set; }

        public int Id_Inspeccion { get; set; }

        [ForeignKey("Sede")]
        public int Fk_Id_Sede { get; set; }
        [ForeignKey("Pk_Id_Sede")]
        public virtual Sede Sede { get; set; }

        [ForeignKey("Proceso")]
        public int Fk_Id_Proceso { get; set; }
        [ForeignKey("Pk_Id_Proceso")]
        public virtual Proceso Proceso { get; set; }

        public DateTime Fecha_Realizacion { get; set; }

        [ForeignKey("PlaneacionInspeccion")]
        public int Fk_Id_PlaneacionInspeccion { get; set; }
        [ForeignKey(" Pk_Id_PlaneacionInspeccion")]
        public virtual PlaneacionInspeccion PlaneacionInspeccion { get; set; }

        public string Descripcion_Tipo_Inspeccion { get; set; }       

        public int Estado_Inspeccion { get; set; }
        public int Fk_IdEmpresa { get; set; }
        public string Area_Lugar { get; set; }
        public string Hora { get; set; }

        public string Responsable_Lugar { get; set; }

        public ICollection<ConfiguracionporInspeccion> ConfiguracionporInspeccion { get; set; }

        public ICollection<AsistentesporInspeccion> AsistentesporInspeccion { get; set; }

        public ICollection<PlanAccionporInspeccion> PlanAccionporInspeccion { get; set; }

        public ICollection<EHMInspecciones> EHMInspeccioness { get; set; }

        public string ToString()
        {
            string cadena = " Pk_Id_Inspecciones: " + Pk_Id_Inspecciones +
                            " Id_Inspeccion: " + Id_Inspeccion +
                            " Sede: " + ((Sede == null) ? Fk_Id_Sede.ToString() : Sede.ToString()) +
                            " Proceso: " + ((Proceso == null) ? Fk_Id_Proceso.ToString() : Proceso.ToString()) +
                            " Fecha_Realizacion: " + Fecha_Realizacion +
                            " PlaneacionInspeccion: " + ((PlaneacionInspeccion == null) ? Fk_Id_PlaneacionInspeccion.ToString() : PlaneacionInspeccion.ToString()) +
                            " Descripcion_Tipo_Inspeccion: " + Descripcion_Tipo_Inspeccion +
                            " Estado_Inspeccion: " + Estado_Inspeccion +
                            " Fk_IdEmpresa: " + Fk_IdEmpresa +
                            " Area_Lugar: " + Area_Lugar +
                            " Hora: " + Hora +
                            " Responsable_Lugar: " + Responsable_Lugar;
            if (ConfiguracionporInspeccion != null)
                foreach (ConfiguracionporInspeccion configInspe in ConfiguracionporInspeccion)
                    cadena = cadena + " ConfiguracionporInspeccion:{ " + configInspe.ToString() + "}";
            if (AsistentesporInspeccion != null)
                foreach (AsistentesporInspeccion asisInpe in AsistentesporInspeccion)
                    cadena = cadena + " AsistentesporInspeccion:{ " + asisInpe.ToString() + "}";
            if (PlanAccionporInspeccion != null)
                foreach (PlanAccionporInspeccion planInpe in PlanAccionporInspeccion)
                    cadena = cadena + " PlanAccionporInspeccion:{ " + planInpe.ToString() + "}";
            if (EHMInspeccioness != null)
                foreach (EHMInspecciones EHMInspe in EHMInspeccioness)
                    cadena = cadena + " EHMInspecciones:{ " + EHMInspe.ToString() + "}";
            return cadena;
        }

    }
}
