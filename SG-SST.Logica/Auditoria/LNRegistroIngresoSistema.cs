using SG_SST.EntidadesDominio.Auditoria;
using SG_SST.Interfaces.Auditoria;
using SG_SST.InterfazManager.Auditoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Logica.Auditoria
{
    public class LNRegistroIngresoSistema
    {
        private static IRegistroIngresoSistema em = IMRegistroIngresoSistema.RegistroIngresoSistema();

        public EDRegistroIngresoSistema GuardarRegistroIngresoSistema(EDRegistroIngresoSistema registro)
        {
            return em.GuardarRegistroIngresoSistema(registro);
        }

    }
}
