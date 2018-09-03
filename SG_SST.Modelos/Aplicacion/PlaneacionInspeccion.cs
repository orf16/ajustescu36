﻿namespace SG_SST.Models.Aplicacion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using SG_SST.Models.Empresas;

    [Table("Tbl_Planeacion_Inspeccion")]
    public class PlaneacionInspeccion
    {
        [Key]

        public int Pk_Id_PlaneacionInspeccion { get; set; }

        public string Responsable_Tipo_Inspeccion { get; set; }
       
        public DateTime Fecha { get; set; }        

        [ForeignKey("MaestrotipoInspeccion")]
        public int Fk_Id_Maestro_Tipo_Inspeccion { get; set; }
        [ForeignKey("Pk_Id_Maestro_Tipo_Inspeccion")]
        public virtual MaestroTipoInspeccion MaestrotipoInspeccion { get; set; }
        public int IdEmpresa { get; set; }
        public string EstadoPlaneacion { get; set; }

        public int ConsecutivoPlan { get; set; }

        public string ToString()
        {
            string cadena = " Pk_Id_PlaneacionInspeccion: " + Pk_Id_PlaneacionInspeccion +
                            " MaestrotipoInspeccion: " + ((MaestrotipoInspeccion == null) ? Fk_Id_Maestro_Tipo_Inspeccion.ToString() : MaestrotipoInspeccion.Descripcion_Tipo_Inspeccion) +
                            " Responsable_Tipo_Inspeccion: " + Responsable_Tipo_Inspeccion +
                            " IdEmpresa: " + IdEmpresa +
                            " EstadoPlaneacion: " + EstadoPlaneacion +
                            " ConsecutivoPlan: " + ConsecutivoPlan;           
            return cadena;
        }

    }
}