using Newtonsoft.Json;
using SG_SST.Audotoria;
using SG_SST.EntidadesDominio.Auditoria;
using SG_SST.Interfaces.Auditoria;
using SG_SST.Models;
using SG_SST.Models.Auditoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Repositorio.AuditoriaSistema
{
    public class RegistroIngresoSistemaManager : IRegistroIngresoSistema
    {
        public EDRegistroIngresoSistema GuardarRegistroIngresoSistema(EDRegistroIngresoSistema registro)
        {
            using (SG_SSTContext context = new SG_SSTContext())
            {
                using (var Transaction = context.Database.BeginTransaction())
                {
                    RegistraLog registraLog = new RegistraLog();
                    try
                    {
                        RegistroIngresoSistema nuevo = new RegistroIngresoSistema();
                        nuevo.FK_Empresa = registro.FK_Empresa;
                        nuevo.FK_UsuarioSistema = registro.FK_UsuarioSistema;
                        nuevo.FechaTransaccion = registro.FechaTransaccion;
                        context.Tbl_RegistroIngresoSistema.Add(nuevo);
                        context.SaveChanges();
                        Transaction.Commit();
                        return registro;
                    }
                    catch (Exception ex)
                    {
                        registraLog.RegistrarError(typeof(RegistroIngresoSistemaManager), string.Format("Error al registrar el ingreso al sistema  {0}: {1}", DateTime.Now, ex.StackTrace), ex);
                        Transaction.Rollback();
                        return null;
                    }
                }
            }
        }


    }
}
