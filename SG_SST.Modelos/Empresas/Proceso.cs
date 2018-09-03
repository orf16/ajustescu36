// <copyright file="Procesos.cs" company="Ada SA">
// Copyright (c) 2017 All Rights Reserved
// </copyright>
// <author>Robinson Andres Correa.</author>
// <date>13/02/2017</date>
// <summary>Modelo que contiene los campos de la tabla Procesos</summary>

namespace SG_SST.Models.Empresas
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    using SG_SST.Models.Planificacion;
    using SG_SST.Models.Aplicacion;

    [Table("Tbl_Proceso")]
    public class Proceso
    {
        [Key]
        public int Pk_Id_Proceso { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        [Display(Name = "SubProceso")]
        public String Descripcion_Proceso { get; set; }        

        [ForeignKey("Procesos")]
        public int? Fk_Id_Proceso { get; set; }
        [ForeignKey("Pk_Id_Proceso")]
        public virtual Proceso Procesos { get; set; }

        public  virtual ICollection<ProcesoEmpresa> ProcesoEmpresa { get; set; }

        public ICollection<Peligro> Peligros { get; set; }
        public ICollection<Inspecciones> Inspecciones { get; set; }
        public ICollection<EPPSuministro> EPPSuministros { get; set; }

        public string ToString()
        {
            string cadena = " Pk_Id_Proceso: " + Pk_Id_Proceso +
                            " Descripcion_Proceso: " + Descripcion_Proceso +
                            " Proceso: " + ((Procesos == null) ? Fk_Id_Proceso.ToString() : Procesos.Descripcion_Proceso);
            if (ProcesoEmpresa != null)
                foreach (ProcesoEmpresa proce in ProcesoEmpresa)
                    cadena = cadena + " ProcesoEmpresa:{ " + proce.ToString() + "}";
            return cadena;
        }
    }
}