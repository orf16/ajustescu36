
namespace SG_SST.Services.Empresas.Services
{
    using SG_SST.EntidadesDominio.Auditoria;
    using SG_SST.Models;
    using SG_SST.Models.Empresas;
    using SG_SST.Repositories.Empresas.IRepositories;
    using SG_SST.Repositories.Empresas.Repositories;
    using SG_SST.Services.Empresas.IServices;
    public class GobiernoServicios : IGobiernoServicios
    {
        IGobiernoRepositorio gb;
        public GobiernoServicios()//Metodo Constructor
        {
            gb = new GobiernoRepositorio();//instancia  de gobierno repositorio quien trae los valores de las consultas en la BD        
        }

        public GobiernoServicios(SG_SSTContext db)
        {
            gb = new GobiernoRepositorio(db);  
        }    
      
     

        public bool GrabarProceso(Proceso proceso)
        {
            return gb.GrabarProceso(proceso);
        }

        public void GrabarGobierno(Gobierno gobierno, int Pk_Id_Empresa,EDInformacionAuditoria edInfoauditoria)
        {
            ///toda la logica de grabar gobierno 
            gb.GrabarGobierno(gobierno,Pk_Id_Empresa,edInfoauditoria);
        }

        public void GrabarGobiernoV(Gobierno gobiernov, int Pk_Id_Empresa, int nit, EDInformacionAuditoria edInfoauditoria)
        {
            gb.GrabarGobiernoV(gobiernov, Pk_Id_Empresa, nit, edInfoauditoria);

        }
        //Metodo que graba la mision
        public bool GrabarMision(string mision, int Pk_Id_Empresa, EDInformacionAuditoria edInfoauditoria)
        {
            Gobierno gobierno = gb.ObtenerGobierno(Pk_Id_Empresa);//obtiene la consulta del RepositorioGobierno
            if (gobierno != null)
            {
                gobierno.Mision = mision;

                return gb.ModficarGobierno(gobierno, edInfoauditoria);
            }
            else
            {
                Gobierno gbo = new Gobierno();
                gbo.Mision = mision;

                gb.GrabarGobierno(gbo, Pk_Id_Empresa, edInfoauditoria);
                return true;
            }
        }

        public bool GrabarVision(string vision, int Pk_Id_Empresa, int nit, EDInformacionAuditoria edInfoauditori)
        {
            Gobierno gobiernov = gb.ObtenerGobierno(Pk_Id_Empresa);
            if (gobiernov != null)
            {
                gobiernov.Vision = vision;
                return gb.ModficarGobiernov(gobiernov, edInfoauditori);
            }
            else
            {
                Gobierno gbov = new Gobierno();
                gbov.Vision = vision;
                //gbov.Nit_Empresa = nit;
                gb.GrabarGobiernoV(gbov, Pk_Id_Empresa, nit, edInfoauditori);
                return true;
            }
        }

        public string ObtenerMision(int Pk_Id_Empresa)
        {
            return gb.ObtenerMisionEmpresa(Pk_Id_Empresa);
        }

        public string ObtenerVision(int Pk_Id_Empresa)
        {
            return gb.ObtenerVisionEmpresa(Pk_Id_Empresa);
        }

        public bool EliminarMision(int Pk_Id_Empresa, EDInformacionAuditoria edInfoauditoria)
        {
            return gb.EliminarMision(Pk_Id_Empresa, edInfoauditoria);
        }


        public bool EliminarVision(int Pk_Id_Empresa, EDInformacionAuditoria edInfoauditoria)
        {
            return gb.EliminarVision(Pk_Id_Empresa, edInfoauditoria);
        }


      
    }
}