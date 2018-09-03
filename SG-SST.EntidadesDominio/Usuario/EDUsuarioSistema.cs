using System;
using System.Collections.Generic;

namespace SG_SST.EntidadesDominio.Usuario
{
    public class EDUsuarioSistema
    {
        public int IdUsuarioSistema { get; set; }
        public int CodEmpresa { get; set; }
        public int TipoDocumentoEmpresa { get; set; }
        public string TipoDocumentoSiglaEmpresa { get; set; }
        public string DocumentoEmpresa { get; set; }
        public string RazonSocial { get; set; }
        public int TipoDocumento { get; set; }
        public string TipoDocumentoSigla { get; set; }
        public string Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int IdRol { get; set; }
        public string NombreRol { get; set; }
        public string RolUsuario { get; set; }
        public string ClaveSalt { get; set; }
        public string ClaveHash { get; set; }
        public int IdEstado { get; set; }
        public string NombreEstado { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public bool Activo { get; set; }
        public bool Bloqueado { get; set; }
        public bool PrimerAcceso { get; set; }
        public DateTime PeriodoInactividad { get; set; }
        public int DiasLaborables { get; set; }
        public string DepartamentoSedePpalEmpresa { get; set; }
        public string MunicipioSedePpalEmpresa { get; set; }
        public string Telefono { get; set; }
        public int EstadoUsuario { get; set; }
        public List<PreguntasSeguridadSeleccionada> PreguntasSeguridad { get; set; }
        public int CantidadRegistros { get; set; }
        public List<DatosAdicionalesUsuarios> DatosAdicionalesUsuarios { get; set; }
    }
    public class PreguntasSeguridadSeleccionada
    {
        public int CodPreguntaSeguridad { get; set; }
        public string NombrePregunta { get; set; }
        public string RespuestaSeguridad { get; set; }
    }
    public class DatosAdicionalesUsuarios
    {
        public string NombreDato { get; set; }
        public string ValorDato { get; set; }
    }
}
