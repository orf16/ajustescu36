using SG_SST.EntidadesDominio.Auditoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Interfaces.Auditoria
{
    public interface IRegistroIngresoSistema
    {
        EDRegistroIngresoSistema GuardarRegistroIngresoSistema(EDRegistroIngresoSistema registro);
    }
}
