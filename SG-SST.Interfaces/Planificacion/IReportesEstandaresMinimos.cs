using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Interfaces.Planificacion
{
    public interface IReportesEstandaresMinimos
    {
        int ObtenerCantidadPreguntasAlmomento(int idCclo, string Nit, int Ideval);
        decimal ObtenerPorcentajeObtenidoAlmomento(int idCclo, string Nit, int Ideval);
        decimal ObtenerPorcentajeObtenidoEstandar(int idCclo, int idEstandar, string Nit, int Ideval);
        decimal ObtenerPorcentajeObtenidoSubEstandar(int idCclo, int idEstandar, string Nit, int Idval);
    }
}
