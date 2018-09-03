using SG_SST.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SG_SST.Models.AdminUsuarios
{
    public class AdministrarUsuariosModel
    {
        public int IdUsuarioSistema { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string TipoDocumentoEmpresa { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Este campo debe contener solo números")]
        public string DocumentoEmpresa { get; set; }
        public string RazonSocialEmpresa { get; set; }
        public string MunicipioSedePpalEmpresa { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string TipoDocumento { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Este campo debe contener solo números")]
        public string Documento { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Apellidos { get; set; }
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [EmailAddress(ErrorMessage = "Debe Ingresar un correo válido")]
        public string EmailPersona { get; set; }

        //[Required(ErrorMessage = "Este campo es obligatorio")]
        [MinLength(6, ErrorMessage = "La clave debe ser mínimo de 6 caracteres")]
        [DataType(DataType.Password)]
        public string Clave { get; set; }

        [MinLength(6, ErrorMessage = "La clave debe ser mínimo de 6 caracteres")]
        [DataType(DataType.Password)]
        public string ConfirmarClave { get; set; }
        //public bool Activo { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int IdRolSeleccionado { get; set; }
        public int IdMunicipio { get; set; }
        public string NombreRolSeleccionado { get; set; }
        public List<SelectListItem> TiposDocumento { get; set; }
        public List<SelectListItem> RolesRegistrados { get; set; }
        public List<SelectListItem> Municipios { get; set; }
        public DateTime PeriodoInactividad { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
        public bool Aprobado { get; set; }
        public string IdCausalRechazoSeleccionada { get; set; }
        public string CausalRechazoSeleccionada { get; set; }
        public List<SelectListItem> CausalesRechazoUsuarioSistema { get; set; }
        public BuscardorModel BuscadorUsuariosSistema { get; set; }
        public ConfiguracionPreguntasSeguridad ConfiguracionPreguntasSeguridad { get; set; }
        public ConfigurarDatosAdicionalesModel ConfigurarDatosAdicionalesModel { get; set; }
    }
    public class AdministrarUsuarioAsesorSSTModel : AdministrarUsuariosModel
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public DateTime FechaInicioContrato { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public DateTime FechaFinContrato { get; set; }
        public string RutaPdfAutorizacion { get; set; }
        public Guid GuidTemporal { get; set; }

        [ValidaArchivos]
        public HttpPostedFileBase PdfAutorizacion { get; set; }
        public ConfigurarDatosAdicionalesModel ConfigurarDatosAdicionalesModel { get; set; }
    }
    public class CambiarClaveModel
    {
        public int IdUsuarioSession { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(255, ErrorMessage = "Este campo debe tener mínimo 6 caracteres de longitud", MinimumLength = 6)]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[(\,\*\+\-\;\(\)\[\]\@\#\$\.]).{6,15}$", ErrorMessage = "La contraseña ingresada no cumple con las condiciones establecidas")]
        [DataType(DataType.Password)]
        public string Clave { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(255, ErrorMessage = "Este campo debe tener mínimo 6 caracteres de longitud", MinimumLength = 6)]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[(\,\*\+\-\;\(\)\[\]\@\#\$\.]).{6,15}$", ErrorMessage = "La contraseña ingresada no cumple con las condiciones establecidas")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Clave")]
        public string ConfirmarClave { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public bool AceptaTerminosCondiciones { get; set; }
        public bool PrimerAcceso { get; set; }
    }

    public class BuscardorModel
    {
        public string NumeroDocumentoEmpresa { get; set; }
        public string TipoDocumentoUsuario { get; set; }
        public string NumeroDocumentoUsuario { get; set; }
        public string RolSeleccionadoUsuario { get; set; }
        public string IdMunicipio { get; set; }
        public List<SelectListItem> RolesSistema { get; set; }
        public List<SelectListItem> TiposDocumento { get; set; }
        public List<SelectListItem> Municipios { get; set; }
    }
    public class ConfiguracionPreguntasSeguridad
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int CodPreguntaUno { get; set; }
        public string NombrePreguntaUno { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string RespuestaUno { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int CodPreguntaDos { get; set; }
        public string NombrePreguntaDos { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string RespuestaDos { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int CodPreguntaTres { get; set; }
        public string NombrePreguntaTres { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string RespuestaTres { get; set; }
        public List<SelectListItem> PreguntasSeguridad { get; set; }
    }
    public class ConfigurarDatosAdicionalesModel
    {
        public string FechaInicioContrato { get; set; }
        public string FechaFinContrato { get; set; }
    }
}