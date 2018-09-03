﻿using SG_SST.EntidadesDominio.Ausentismo;
using SG_SST.EntidadesDominio.Empresas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Interfaces.Ausentismo
{
    public interface IAusencia
    {
        List<EDAusencia> ValidarCruceAusentismo(EDAusencia ausencia);
        bool GuardarDiasLaborables(string NitEmpresa, int IdDiasSeleccionado);
        int ObtenerDiasLaborablesEmpresa(string NitEmpresa);
        bool GuardarAusencia(EDAusencia ausencia);
        IEnumerable<Resultados> ConsultarAusencia(EDAusencia edAusencia);
        bool ProrrogarAusencia(EDAusencia prorrogar);
        List<string> ObtenerSedes();
        List<EDAlertaAusentismo> ConsultarAlertaAusencia(EDAlertaAusentismoParametros parametros);
        EDCargueMasivo InsertarAusenciasCargueMasivo(List<EDAusencia> AusenciasMasivo);

        List<string> BuscarDocumentos(string prefijo);
        List<EDDiasLaborables> ConsultarDiasLaborables(string idEmpresa);


        //Creado por Javier García (Kerocorp) 7/03/2017
        List<EDTipoDocumento> ObtenerTipoDocumento();
        //Creado por Javier García (Kerocorp) 30/03/2017
        EDAusencia ConsultarAusenciaEliminar(string idEmpresa, int idAusencia);
        //Creado por Javier García (Kerocorp) 30/03/2017
        bool EliminarAusencia(string NitEmpresa, int idAusencia);
        //Creado por Javier García (Kerocorp) 30/03/2017
        List<EDAusencia> ConsultarAusenciaProrrogas(string NitEmpresa, int idAusencia);
        //Creado por Javier García (Kerocorp) 30/03/2017
        string ConsultarDiagnostico(int idDiagnostico);
        string ConsultarTipo(int idausencia);
    }
}
