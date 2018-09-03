using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SG_SST.Models.Planificacion;
using SG_SST.Models.Empresas;

namespace SG_SST.Models.Aplicacion
{
    [Table("Tbl_AdministracionEMH")]
    public class AdmoEMH
    {
        [Key]
        public int Pk_Id_AdmoEMH { get; set; }

        [MaxLength(50)]
        [DisplayName("Tipo de Elemento")]
        [Required(ErrorMessage = "Debe ingresar el valor de {0}")]
        public string TipoElemento { get; set; }

        [MaxLength(250)]
        [DisplayName("Nombre del Elemento")]
        [Required(ErrorMessage = "Debe ingresar el valor de {0}")]
        public string NombreElemento { get; set; }

        [MaxLength(250)]
        [DisplayName("Código")]
        [Required(ErrorMessage = "Debe ingresar el valor de {0}")]
        public string CodigoElemento { get; set; }

        [MaxLength(250)]
        [DisplayName("Marca")]
        [Required(ErrorMessage = "Debe ingresar el valor de {0}")]
        public string Marca { get; set; }

        [MaxLength(250)]
        [DisplayName("Modelo")]
        [Required(ErrorMessage = "Debe ingresar el valor de {0}")]
        public string Modelo { get; set; }

        [MaxLength(250)]
        [DisplayName("Fabricante")]
        [Required(ErrorMessage = "Debe ingresar el valor de {0}")]
        public string Fabricante { get; set; }

        [DisplayName("Fecha de Fabricación")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Debe ingresar el valor de {0}")]
        public DateTime Fecha_Fab { get; set; }

        [DisplayName("Horas de Vida Útil")]
        [Required(ErrorMessage = "Debe ingresar el valor de {0}")]
        public int HorasVida { get; set; }


        [MaxLength(250)]
        [DisplayName("Ubicación")]
        [Required(ErrorMessage = "Debe ingresar el valor de {0}")]
        public string Ubicacion { get; set; }

        [MaxLength(2000)]
        [DisplayName("Características Generales")]
        [Required(ErrorMessage = "Debe ingresar el valor de {0}")]
        public string Caracteristicas { get; set; }

        [MaxLength(500)]
        [DisplayName("Nombre del Responsable")]
        [Required(ErrorMessage = "Debe ingresar el valor de {0}")]
        public string NombreResponsable { get; set; }

        [MaxLength(250)]
        [DisplayName("Cargo del Responsable")]
        [Required(ErrorMessage = "Debe ingresar el valor de {0}")]
        public string CargoResponsable { get; set; }

        [Required()]
        public short Estado { get; set; }

        //Imagenes & Archivos

        [StringLength(2000)]
        public string ArchivoImagen1 { get; set; }
        [StringLength(2000)]
        public string ArchivoImagen1_download { get; set; }
        [StringLength(3000)]
        public string RutaImage1 { get; set; }

        [StringLength(2000)]
        public string ArchivoImagen2 { get; set; }
        [StringLength(2000)]
        public string ArchivoImagen2_download { get; set; }
        [StringLength(3000)]
        public string RutaImage2 { get; set; }

        [StringLength(2000)]
        public string ArchivoImagen3 { get; set; }
        [StringLength(2000)]
        public string ArchivoImagen3_download { get; set; }
        [StringLength(3000)]
        public string RutaImage3 { get; set; }

        [StringLength(2000)]
        public string ArchivoImagen4 { get; set; }
        [StringLength(2000)]
        public string ArchivoImagen4_download { get; set; }
        [StringLength(3000)]
        public string RutaImage4 { get; set; }

        [StringLength(2000)]
        public string ArchivoImagen5 { get; set; }
        [StringLength(2000)]
        public string ArchivoImagen5_download { get; set; }
        [StringLength(3000)]
        public string RutaImage5 { get; set; }


        [StringLength(2000)]
        public string NombreArchivo1 { get; set; }
        [StringLength(2000)]
        public string NombreArchivo1_download { get; set; }
        [StringLength(3000)]
        public string Ruta1 { get; set; }
        [StringLength(2000)]
        public string NombreArchivo2 { get; set; }
        public string NombreArchivo2_download { get; set; }
        [StringLength(3000)]
        public string Ruta2 { get; set; }
        [StringLength(2000)]
        public string NombreArchivo3 { get; set; }
        public string NombreArchivo3_download { get; set; }
        [StringLength(3000)]
        public string Ruta3 { get; set; }

        [DisplayName("Fecha baja de equipo, máquina o herramienta")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Fecha_Baja { get; set; }

        [MaxLength(250)]
        [DisplayName("Motivo baja de equipo, máquina o herramienta")]
        public string Motivo_Baja { get; set; }

        public ICollection<PeligroEMH> PeligroEMHs { get; set; }
        public ICollection<EHMInspecciones> EHMInspeccioness { get; set; }

        [ForeignKey("Empresa")]
        public int Fk_Id_Empresa { get; set; }
        [ForeignKey("PK_Empresa")]
        public virtual Empresa Empresa { get; set; }


        public string ToString()
        {
            string cadena = " Pk_Id_AdmoEMH: " + Pk_Id_AdmoEMH +
                            " TipoElemento: " + TipoElemento +
                            " NombreElemento: " + NombreElemento +
                            " CodigoElemento: " + CodigoElemento +
                            " Marca: " + Marca +
                            " Modelo: " + Modelo +
                            " Fabricante: " + Fabricante +
                            " Fecha_Fab: " + Fecha_Fab +
                            " HorasVida: " + HorasVida +
                            " Ubicacion: " + Ubicacion +
                            " Caracteristicas: " + Caracteristicas +
                            " NombreResponsable: " + NombreResponsable +
                            " CargoResponsable: " + CargoResponsable +
                            " ArchivoImagen1: " + ArchivoImagen1 +
                            " ArchivoImagen1_download: " + ArchivoImagen1_download +
                            " RutaImage1: " + RutaImage1 +
                            " ArchivoImagen2: " + ArchivoImagen2 +
                            " ArchivoImagen2_download: " + ArchivoImagen2_download +
                            " RutaImage2: " + RutaImage2 +
                            " ArchivoImagen3: " + ArchivoImagen3 +
                            " ArchivoImagen3_download: " + ArchivoImagen3_download +
                            " RutaImage3: " + RutaImage3 +
                            " ArchivoImagen4: " + ArchivoImagen4 +
                            " ArchivoImagen4_download: " + ArchivoImagen4_download +
                            " RutaImage4: " + RutaImage4 +
                            " ArchivoImagen5: " + ArchivoImagen5 +
                            " ArchivoImagen5_download: " + ArchivoImagen5_download +
                            " NombreArchivo1: " + NombreArchivo1 +
                            " NombreArchivo1_download: " + NombreArchivo1_download +
                            " Ruta1: " + Ruta1 +
                            " NombreArchivo2: " + NombreArchivo2 +
                            " NombreArchivo2_download: " + NombreArchivo2_download +
                            " Ruta2: " + Ruta2 +
                            " NombreArchivo3: " + NombreArchivo3 +
                            " NombreArchivo3_download: " + NombreArchivo3_download +
                            " Ruta3: " + Ruta3 +
                            " Fecha_Baja: " + Fecha_Baja +
                            " Motivo_Baja: " + Motivo_Baja;
            return cadena;
        }
    }
}
