
namespace SG_SST.Repositories.Empresas.IRepositories
{
    using SG_SST.EntidadesDominio.Auditoria;
    using SG_SST.Models.Empresas;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    interface IGobiernoRepositorio
    {
        void GrabarGobierno(Gobierno gobierno, int Pk_Id_Empresa, EDInformacionAuditoria edInfoauditoria);
        void GrabarGobiernoV(Gobierno gobiernov,int Pk_Id_Empresa,int Nit_Empresa, EDInformacionAuditoria edInfoauditoria);
        Gobierno ObtenerGobierno(int Pk_Id_Empresa);
        //Gobierno ObtenerGobiernov();
     
        bool ModficarGobierno(Gobierno gobierno, EDInformacionAuditoria edInfoauditoria);
        bool ModficarGobiernov(Gobierno gobiernov, EDInformacionAuditoria edInfoauditori);

        string ObtenerMisionEmpresa(int Pk_Id_Empresa);
        string ObtenerVisionEmpresa(int Pk_Id_Empresa);

        bool EliminarMision(int Pk_Id_Empresa, EDInformacionAuditoria edInfoauditoria);
        bool EliminarVision(int Pk_Id_Empresa, EDInformacionAuditoria edInfoauditoria);

        bool GrabarProceso(Proceso proceso);

        //Proceso ObtenerProceso(int Pk_Id_Empresa);

       

    

    }
}
