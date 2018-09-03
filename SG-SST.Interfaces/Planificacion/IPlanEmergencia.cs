using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SG_SST.EntidadesDominio.Planificacion;
namespace SG_SST.Interfaces.Planificacion
{

   public interface IPlanEmergencia
    {

       bool InsertarCargueMasivoBDInterna(List<EDDatosCarguePlanEmergencia> bdInterna, int idsede);

       bool InsertarCargueMasivoBDExterna(List<EDDatosCarguePlanEmergencia> bdExterna, int idsede);

       bool InsertarCargueMasivoBDPlanAyuda(List<EDDatosCarguePlanEmergencia> bdPlanAyuda, int idsede);

    }
}
