using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SG_SST.Models.Usuarios
{
    public class UsuarioModel
    {
        public int IdUsuarioSistema { get; set; }
        public string Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public List<SelectListItem> Empresas { get; set; }
        public int Id_Empresa { get; set; }


        public int CodEmpresa { get; set; }
        public int TipoDocumentoEmpresa { get; set; }
        public string TipoDocumentoSiglaEmpresa { get; set; }
        public string DocumentoEmpresa { get; set; }
        public string RazonSocial { get; set; }
        public int TipoDocumento { get; set; }
        public string TipoDocumentoSigla { get; set; }               
        public int IdRol { get; set; }
        public string RolUsuario { get; set; }
        public string ClaveSalt { get; set; }
        public string ClaveHash { get; set; }
        public int IdEstado { get; set; }
        public string NombreEstado { get; set; } 
        public bool Activo { get; set; }
        public bool Bloqueado { get; set; }
        public bool PrimerAcceso { get; set; }
        public DateTime PeriodoInactividad { get; set; }
        public int DiasLaborables { get; set; }
        public string DepartamentoSedePpalEmpresa { get; set; }
        public string MunicipioSedePpalEmpresa { get; set; }
        public string Telefono { get; set; }

        public List<SelectListItem> EstadosUsuario { get; set; }
        public ConfigurarDatosAdicionalesUsuariosModel ConfigurarDatosAdicionalesUsuariosModel { get; set; }
    }
    public class ConfigurarDatosAdicionalesUsuariosModel
    {
        public string FechaInicioContrato { get; set; }
        public string FechaFinContrato { get; set; }
    }
}