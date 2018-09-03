using SG_SST.EntidadesDominio.Planificacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SG_SST.Models.Planificacion
{
    public class MetasIndicadoresModel
    {
        public int PKIdMetaIndicador { get; set; }

        public int FKEmpresa { get; set; }

        public int FKIndicador { get; set; }

        public decimal Meta { get; set; }

        public decimal Rojo { get; set; }

        public decimal Amarillo { get; set; }

        public decimal Verde { get; set; }

        public string TipoIndicador { get; set; }

        public string NombreIndicador { get; set; }

        public string UnidadIndicador { get; set; }

        public string FrecuenciaIndicador { get; set; }

        public IndicadorModel IndicadorCompleto { get; set; }

        public List<SelectListItem> TiposIndicadores { get; set; }

        public List<SelectListItem> Indicadores { get; set; }

        public List<MetasModel> Metas { get; set; }

    }

        public class MetasModel
    {
        public int PKIdMetaIndicador { get; set; }

        public int FKEmpresa { get; set; }

        public int FKIndicador { get; set; }

        public decimal Meta { get; set; }

        public decimal Rojo { get; set; }

        public decimal Amarillo { get; set; }

        public decimal Verde { get; set; }

        public IndicadorModel IndicadorCompleto { get; set; }
    }

    public class IndicadorModel
    {
        public int PKIdIndicador { get; set; }

        public string NombreIndicador { get; set; }

        public string TipoIndicador { get; set; }

        public string UnidadIndicador { get; set; }

        public string FrecuenciaIndicador { get; set; }
    }

}