using Newtonsoft.Json;
using SG_SST.Audotoria;
using SG_SST.EntidadesDominio.Auditoria;
using SG_SST.Models;
using SG_SST.Models.Auditoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Repositorio.AuditoriaSistema
{
    public class AuditoriaSistemaManager
    {

        public AuditoriaPlanificacion ObtenerAuditoriaPlanificacion(EDInformacionAuditoria EDInfoAuditoria, string accion, string modulo, string SubModulo, string opcion, string info)
        {           
            
            AuditoriaPlanificacion audplan = new AuditoriaPlanificacion()
            {
                NitEmpresa = EDInfoAuditoria.NitEmpresa,
                Empresa = EDInfoAuditoria.NombreEmpresa,
                NombreUsuario = EDInfoAuditoria.NombreUsuario,
                IdentificacionUsuario = EDInfoAuditoria.IdentificacionUsuario,
                FechaTransaccion = DateTime.Now,
                IpEquipoUsuario = EDInfoAuditoria.IpUsuario,
                TipoAccion = accion,
                Modulo = modulo,
                SubModulo = SubModulo,
                Opcion = opcion,
                Informacion = info
            };
            return audplan;
        }

        public AuditoriaLiderazgoGerencial ObtenerAuditoriaLiderazgoGerencial(EDInformacionAuditoria EDInfoAuditoria, string accion, string modulo, string SubModulo, string opcion, string info)
        {

            AuditoriaLiderazgoGerencial audplan = new AuditoriaLiderazgoGerencial()
            {
                NitEmpresa = EDInfoAuditoria.NitEmpresa,
                Empresa = EDInfoAuditoria.NombreEmpresa,
                NombreUsuario = EDInfoAuditoria.NombreUsuario,
                IdentificacionUsuario = EDInfoAuditoria.IdentificacionUsuario,
                FechaTransaccion = DateTime.Now,
                IpEquipoUsuario = EDInfoAuditoria.IpUsuario,
                TipoAccion = accion,
                Modulo = modulo,
                SubModulo = SubModulo,
                Opcion = opcion,
                Informacion = info
            };
            return audplan;
        }

        public AuditoriaParticipacionTrabajadores ObtenerAuditoriaParticipacionTrabajadores(EDInformacionAuditoria EDInfoAuditoria, string accion, string modulo, string SubModulo, string opcion, string info)
        {

            AuditoriaParticipacionTrabajadores audplan = new AuditoriaParticipacionTrabajadores()
            {
                NitEmpresa = EDInfoAuditoria.NitEmpresa,
                Empresa = EDInfoAuditoria.NombreEmpresa,
                NombreUsuario = EDInfoAuditoria.NombreUsuario,
                IdentificacionUsuario = EDInfoAuditoria.IdentificacionUsuario,
                FechaTransaccion = DateTime.Now,
                IpEquipoUsuario = EDInfoAuditoria.IpUsuario,
                TipoAccion = accion,
                Modulo = modulo,
                SubModulo = SubModulo,
                Opcion = opcion,
                Informacion = info
            };
            return audplan;
        }

        public AuditoriaRevisionPorLaDireccion ObtenerAuditoriaRevisionPorLaDireccion(EDInformacionAuditoria EDInfoAuditoria, string accion, string modulo, string SubModulo, string opcion, string info)
        {

            AuditoriaRevisionPorLaDireccion audplan = new AuditoriaRevisionPorLaDireccion()
            {
                NitEmpresa = EDInfoAuditoria.NitEmpresa,
                Empresa = EDInfoAuditoria.NombreEmpresa,
                NombreUsuario = EDInfoAuditoria.NombreUsuario,
                IdentificacionUsuario = EDInfoAuditoria.IdentificacionUsuario,
                FechaTransaccion = DateTime.Now,
                IpEquipoUsuario = EDInfoAuditoria.IpUsuario,
                TipoAccion = accion,
                Modulo = modulo,
                SubModulo = SubModulo,
                Opcion = opcion,
                Informacion = info
            };
            return audplan;
        }

        public AuditoriaEmpresa ObtenerAuditoriaEmpresa(EDInformacionAuditoria EDInfoAuditoria, string accion, string modulo, string SubModulo, string opcion, string info)
        {

            AuditoriaEmpresa audplan = new AuditoriaEmpresa()
            {
                NitEmpresa = EDInfoAuditoria.NitEmpresa,
                Empresa = EDInfoAuditoria.NombreEmpresa,
                NombreUsuario = EDInfoAuditoria.NombreUsuario,
                IdentificacionUsuario = EDInfoAuditoria.IdentificacionUsuario,
                FechaTransaccion = DateTime.Now,
                IpEquipoUsuario = EDInfoAuditoria.IpUsuario,
                TipoAccion = accion,
                Modulo = modulo,
                SubModulo = SubModulo,
                Opcion = opcion,
                Informacion = info
            };
            return audplan;
        }

        public AuditoriaPolitica ObtenerAuditoriaPolitica(EDInformacionAuditoria EDInfoAuditoria, string accion, string modulo, string SubModulo, string opcion, string info)
        {

            AuditoriaPolitica audplan = new AuditoriaPolitica()
            {
                NitEmpresa = EDInfoAuditoria.NitEmpresa,
                Empresa = EDInfoAuditoria.NombreEmpresa,
                NombreUsuario = EDInfoAuditoria.NombreUsuario,
                IdentificacionUsuario = EDInfoAuditoria.IdentificacionUsuario,
                FechaTransaccion = DateTime.Now,
                IpEquipoUsuario = EDInfoAuditoria.IpUsuario,
                TipoAccion = accion,
                Modulo = modulo,
                SubModulo = SubModulo,
                Opcion = opcion,
                Informacion = info
            };
            return audplan;
        }

        public AuditoriaOrganizacion ObtenerAuditoriaOrganizacion(EDInformacionAuditoria EDInfoAuditoria, string accion, string modulo, string SubModulo, string opcion, string info)
        {

            AuditoriaOrganizacion audplan = new AuditoriaOrganizacion()
            {
                NitEmpresa = EDInfoAuditoria.NitEmpresa,
                Empresa = EDInfoAuditoria.NombreEmpresa,
                NombreUsuario = EDInfoAuditoria.NombreUsuario,
                IdentificacionUsuario = EDInfoAuditoria.IdentificacionUsuario,
                FechaTransaccion = DateTime.Now,
                IpEquipoUsuario = EDInfoAuditoria.IpUsuario,
                TipoAccion = accion,
                Modulo = modulo,
                SubModulo = SubModulo,
                Opcion = opcion,
                Informacion = info
            };
            return audplan;
        }

        public AuditoriaAplicacion ObtenerAuditoriaAplicacion(EDInformacionAuditoria EDInfoAuditoria, string accion, string modulo, string SubModulo, string opcion, string info)
        {

            AuditoriaAplicacion audplan = new AuditoriaAplicacion()
            {
                NitEmpresa = EDInfoAuditoria.NitEmpresa,
                Empresa = EDInfoAuditoria.NombreEmpresa,
                NombreUsuario = EDInfoAuditoria.NombreUsuario,
                IdentificacionUsuario = EDInfoAuditoria.IdentificacionUsuario,
                FechaTransaccion = DateTime.Now,
                IpEquipoUsuario = EDInfoAuditoria.IpUsuario,
                TipoAccion = accion,
                Modulo = modulo,
                SubModulo = SubModulo,
                Opcion = opcion,
                Informacion = info
            };
            return audplan;
        }

        public AuditoriaEmpresa ObtenerAuditoriaSistemaEmpresa(EDInformacionAuditoria EDInfoAuditoria, string accion, string modulo, string SubModulo, string opcion, string info)
        {

            AuditoriaEmpresa audplan = new AuditoriaEmpresa()
            {
                NitEmpresa = EDInfoAuditoria.NitEmpresa,
                Empresa = EDInfoAuditoria.NombreEmpresa,
                NombreUsuario = EDInfoAuditoria.NombreUsuario,
                IdentificacionUsuario = EDInfoAuditoria.IdentificacionUsuario,
                FechaTransaccion = DateTime.Now,
                IpEquipoUsuario = EDInfoAuditoria.IpUsuario,
                TipoAccion = accion,
                Modulo = modulo,
                SubModulo = SubModulo,
                Opcion = opcion,
                Informacion = info
            };
            return audplan;
        }
    }
}
