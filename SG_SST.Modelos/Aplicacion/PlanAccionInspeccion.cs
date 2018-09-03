﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SG_SST.Models.Aplicacion
{
    [Table("Tbl_PlanAccionInspeccion")]
    public class PlanAccionInspeccion
    {
        [Key]
        public int Pk_Id_PlanAcccionInspeccion { get; set; }
        public string Actividad_Plan_Accion { get; set; }
        public string Responsable_Plan_Accion{ get; set; }
        //public string Fecha_Fin_Plan_Accion { get; set; }
        public DateTime Fecha_Fin_Plan_Accion { get; set; }
        public DateTime? Fecha_Cierre_Plan { get; set; }
        public int Estado { get; set; }     
        public ICollection<PlanaccionPorCondicion> PlanaccionPorCondicion { get; set; }
        public ICollection<PlanAccionCorrectiva> PlanAccionCorrectiva { get; set; }

        public string ToString()
        {
            string cadena = " Pk_Id_PlanAcccionInspeccion: " + Pk_Id_PlanAcccionInspeccion +
                            " Actividad_Plan_Accion: " + Actividad_Plan_Accion +
                            " Responsable_Plan_Accion: " + Responsable_Plan_Accion +
                            " Fecha_Fin_Plan_Accion: " + Fecha_Fin_Plan_Accion +
                            " Fecha_Cierre_Plan: " + Fecha_Cierre_Plan +
                            " Estado: " + Estado ;          
            return cadena;
        }
       
    }
}
