using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.EntidadesDominio.Usuario
{
    public class EDMenuRecursoSistema
    {
        public int IdRecursoSistema { get; set; }
        public int? CodRecursoSistemaPadre { get; set; }
        public string NombreRecursoSistema { get; set; }
        public string UrlRecursoSistema { get; set; }
        public string Controlador { get; set; }
        public string Accion { get; set; }
        public bool Acceso { get; set; }
        public IEnumerable<EDMenuRecursoSistema> RecursosSistemaHijos { get; set; }
    }
}
