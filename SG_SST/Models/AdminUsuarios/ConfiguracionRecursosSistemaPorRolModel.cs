using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SG_SST.Models.AdminUsuarios
{
    public class ConfiguracionRecursosSistemaPorRolModel
    {
        public string NumDocumentoAsesorSST { get; set; }
        public List<SelectListItem> EmpresasAsesorSST { get; set; }
        public List<SelectListItem> RolesSistema { get; set; }
        public string EmpresaSeleccionada { get; set; }
        public string NitEmpresa { get; set; }
        public List<MenuRecursoSistemaModel> MenuRecursoSistemaModel { get; set; }
    }
    public class MenuRecursoSistemaModel
    {
        public int IdRecursoSistema { get; set; }
        public int? CodRecursoSistemaPadre { get; set; }
        public string NombreRecursoSistema { get; set; }
        public string UrlRecursoSistema { get; set; }
        public bool Activo { get; set; }
        public IEnumerable<MenuRecursoSistemaModel> RecursosSistemaHijos { get; set; }
    }
    public class EmpresaAsesorSSTModel
    {
        public int IdEmpresa { get; set; }
        public string RazonSocial { get; set; }
        public bool Activo { get; set; }
        public string DocumentoAsesorSST { get; set; }
        public int CodRol { get; set; }
    }
}