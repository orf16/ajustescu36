using SG_SST.Interfaces.Auditoria;
using SG_SST.Repositorio.AuditoriaSistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.InterfazManager.Auditoria
{
    public class IMRegistroIngresoSistema
    {
        public static IRegistroIngresoSistema RegistroIngresoSistema()
        {
            return new RegistroIngresoSistemaManager();
        }

    }
}
