namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class auditoriaSistema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_ActivaAuditoriaSistema",
                c => new
                    {
                        Pk_Id_ActivaAuditoriaSistema = c.Int(nullable: false, identity: true),
                        EsActivaEmpresa = c.Boolean(nullable: false),
                        EsActivaLiderazgoGerencial = c.Boolean(nullable: false),
                        EsActivaPolitica = c.Boolean(nullable: false),
                        EsActivaOrganizacion = c.Boolean(nullable: false),
                        EsActivaPlanificacion = c.Boolean(nullable: false),
                        EsActivaAplicacion = c.Boolean(nullable: false),
                        EsActivaReporteEInvestigacion = c.Boolean(nullable: false),
                        EsActivaMedicionYEvaluaciónSGSST = c.Boolean(nullable: false),
                        EsActivaParticipacionTrabajadores = c.Boolean(nullable: false),
                        EsActivaRevisionPorLaDireccion = c.Boolean(nullable: false),
                        EsActivaConfiguracionMaestros = c.Boolean(nullable: false),
                        EsActivaUsuariosDelSistema = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Pk_Id_ActivaAuditoriaSistema);
            
            CreateTable(
                "dbo.Tbl_AuditoriaAplicacionSistema",
                c => new
                    {
                        Pk_Id_AuditoriaAplicacionSistema = c.Int(nullable: false, identity: true),
                        NitEmpresa = c.String(),
                        Empresa = c.String(),
                        NombreUsuario = c.String(),
                        IdentificacionUsuario = c.String(),
                        FechaTransaccion = c.DateTime(nullable: false),
                        IpEquipoUsuario = c.String(),
                        TipoAccion = c.String(),
                        Informacion = c.String(),
                        Modulo = c.String(),
                        SubModulo = c.String(),
                        Opcion = c.String(),
                    })
                .PrimaryKey(t => t.Pk_Id_AuditoriaAplicacionSistema);
            
            CreateTable(
                "dbo.Tbl_AuditoriaConfiguracionMaestrosSistema",
                c => new
                    {
                        Pk_Id_AuditoriaConfiguracionMaestrosSistema = c.Int(nullable: false, identity: true),
                        NitEmpresa = c.String(),
                        Empresa = c.String(),
                        NombreUsuario = c.String(),
                        IdentificacionUsuario = c.String(),
                        FechaTransaccion = c.DateTime(nullable: false),
                        IpEquipoUsuario = c.String(),
                        TipoAccion = c.String(),
                        Informacion = c.String(),
                        Modulo = c.String(),
                        SubModulo = c.String(),
                        Opcion = c.String(),
                    })
                .PrimaryKey(t => t.Pk_Id_AuditoriaConfiguracionMaestrosSistema);
            
            CreateTable(
                "dbo.Tbl_AuditoriaEmpresaSistema",
                c => new
                    {
                        Pk_Id_AuditoriaEmpresaSistema = c.Int(nullable: false, identity: true),
                        NitEmpresa = c.String(),
                        Empresa = c.String(),
                        NombreUsuario = c.String(),
                        IdentificacionUsuario = c.String(),
                        FechaTransaccion = c.DateTime(nullable: false),
                        IpEquipoUsuario = c.String(),
                        TipoAccion = c.String(),
                        Informacion = c.String(),
                        Modulo = c.String(),
                        SubModulo = c.String(),
                        Opcion = c.String(),
                    })
                .PrimaryKey(t => t.Pk_Id_AuditoriaEmpresaSistema);
            
            CreateTable(
                "dbo.Tbl_AuditoriaLiderazgoGerencialSistema",
                c => new
                    {
                        Pk_Id_AuditoriaLiderazgoGerencial = c.Int(nullable: false, identity: true),
                        NitEmpresa = c.String(),
                        Empresa = c.String(),
                        NombreUsuario = c.String(),
                        IdentificacionUsuario = c.String(),
                        FechaTransaccion = c.DateTime(nullable: false),
                        IpEquipoUsuario = c.String(),
                        TipoAccion = c.String(),
                        Informacion = c.String(),
                        Modulo = c.String(),
                        SubModulo = c.String(),
                        Opcion = c.String(),
                    })
                .PrimaryKey(t => t.Pk_Id_AuditoriaLiderazgoGerencial);
            
            CreateTable(
                "dbo.Tbl_AuditoriaMedicionYEvaluaciónSGSSTSistema",
                c => new
                    {
                        Pk_Id_AuditoriaMedicionYEvaluaciónSGSSTSistema = c.Int(nullable: false, identity: true),
                        NitEmpresa = c.String(),
                        Empresa = c.String(),
                        NombreUsuario = c.String(),
                        IdentificacionUsuario = c.String(),
                        FechaTransaccion = c.DateTime(nullable: false),
                        IpEquipoUsuario = c.String(),
                        TipoAccion = c.String(),
                        Informacion = c.String(),
                        Modulo = c.String(),
                        SubModulo = c.String(),
                        Opcion = c.String(),
                    })
                .PrimaryKey(t => t.Pk_Id_AuditoriaMedicionYEvaluaciónSGSSTSistema);
            
            CreateTable(
                "dbo.Tbl_AuditoriaOrganizacionSistema",
                c => new
                    {
                        Pk_Id_AuditoriaOrganizacionSistema = c.Int(nullable: false, identity: true),
                        NitEmpresa = c.String(),
                        Empresa = c.String(),
                        NombreUsuario = c.String(),
                        IdentificacionUsuario = c.String(),
                        FechaTransaccion = c.DateTime(nullable: false),
                        IpEquipoUsuario = c.String(),
                        TipoAccion = c.String(),
                        Informacion = c.String(),
                        Modulo = c.String(),
                        SubModulo = c.String(),
                        Opcion = c.String(),
                    })
                .PrimaryKey(t => t.Pk_Id_AuditoriaOrganizacionSistema);
            
            CreateTable(
                "dbo.Tbl_AuditoriaParticipacionTrabajadoresSistema",
                c => new
                    {
                        Pk_Id_AuditoriaParticipacionTrabajadoresSistema = c.Int(nullable: false, identity: true),
                        NitEmpresa = c.String(),
                        Empresa = c.String(),
                        NombreUsuario = c.String(),
                        IdentificacionUsuario = c.String(),
                        FechaTransaccion = c.DateTime(nullable: false),
                        IpEquipoUsuario = c.String(),
                        TipoAccion = c.String(),
                        Informacion = c.String(),
                        Modulo = c.String(),
                        SubModulo = c.String(),
                        Opcion = c.String(),
                    })
                .PrimaryKey(t => t.Pk_Id_AuditoriaParticipacionTrabajadoresSistema);
            
            CreateTable(
                "dbo.Tbl_AuditoriaPlanificacionSistema",
                c => new
                    {
                        Pk_Id_AuditoriaPlanificacionSistema = c.Int(nullable: false, identity: true),
                        NitEmpresa = c.String(),
                        Empresa = c.String(),
                        NombreUsuario = c.String(),
                        IdentificacionUsuario = c.String(),
                        FechaTransaccion = c.DateTime(nullable: false),
                        IpEquipoUsuario = c.String(),
                        TipoAccion = c.String(),
                        Informacion = c.String(),
                        Modulo = c.String(),
                        SubModulo = c.String(),
                        Opcion = c.String(),
                    })
                .PrimaryKey(t => t.Pk_Id_AuditoriaPlanificacionSistema);
            
            CreateTable(
                "dbo.Tbl_AuditoriaPoliticaSistema",
                c => new
                    {
                        Pk_Id_AuditoriaPoliticaSistema = c.Int(nullable: false, identity: true),
                        NitEmpresa = c.String(),
                        Empresa = c.String(),
                        NombreUsuario = c.String(),
                        IdentificacionUsuario = c.String(),
                        FechaTransaccion = c.DateTime(nullable: false),
                        IpEquipoUsuario = c.String(),
                        TipoAccion = c.String(),
                        Informacion = c.String(),
                        Modulo = c.String(),
                        SubModulo = c.String(),
                        Opcion = c.String(),
                    })
                .PrimaryKey(t => t.Pk_Id_AuditoriaPoliticaSistema);
            
            CreateTable(
                "dbo.Tbl_AuditoriaReporteEInvestigacionSistema",
                c => new
                    {
                        Pk_Id_AuditoriaReporteEInvestigacionSistema = c.Int(nullable: false, identity: true),
                        NitEmpresa = c.String(),
                        Empresa = c.String(),
                        NombreUsuario = c.String(),
                        IdentificacionUsuario = c.String(),
                        FechaTransaccion = c.DateTime(nullable: false),
                        IpEquipoUsuario = c.String(),
                        TipoAccion = c.String(),
                        Informacion = c.String(),
                        Modulo = c.String(),
                        SubModulo = c.String(),
                        Opcion = c.String(),
                    })
                .PrimaryKey(t => t.Pk_Id_AuditoriaReporteEInvestigacionSistema);
            
            CreateTable(
                "dbo.Tbl_AuditoriaRevisionPorLaDireccionSistema",
                c => new
                    {
                        Pk_Id_AuditoriaRevisionPorLaDireccionSistema = c.Int(nullable: false, identity: true),
                        NitEmpresa = c.String(),
                        Empresa = c.String(),
                        NombreUsuario = c.String(),
                        IdentificacionUsuario = c.String(),
                        FechaTransaccion = c.DateTime(nullable: false),
                        IpEquipoUsuario = c.String(),
                        TipoAccion = c.String(),
                        Informacion = c.String(),
                        Modulo = c.String(),
                        SubModulo = c.String(),
                        Opcion = c.String(),
                    })
                .PrimaryKey(t => t.Pk_Id_AuditoriaRevisionPorLaDireccionSistema);
            
            CreateTable(
                "dbo.Tbl_AuditoriaUsuariosDelSistema",
                c => new
                    {
                        Pk_Id_AuditoriaUsuariosDelSistema = c.Int(nullable: false, identity: true),
                        NitEmpresa = c.String(),
                        Empresa = c.String(),
                        NombreUsuario = c.String(),
                        IdentificacionUsuario = c.String(),
                        FechaTransaccion = c.DateTime(nullable: false),
                        IpEquipoUsuario = c.String(),
                        TipoAccion = c.String(),
                        Informacion = c.String(),
                        Modulo = c.String(),
                        SubModulo = c.String(),
                        Opcion = c.String(),
                    })
                .PrimaryKey(t => t.Pk_Id_AuditoriaUsuariosDelSistema);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tbl_AuditoriaUsuariosDelSistema");
            DropTable("dbo.Tbl_AuditoriaRevisionPorLaDireccionSistema");
            DropTable("dbo.Tbl_AuditoriaReporteEInvestigacionSistema");
            DropTable("dbo.Tbl_AuditoriaPoliticaSistema");
            DropTable("dbo.Tbl_AuditoriaPlanificacionSistema");
            DropTable("dbo.Tbl_AuditoriaParticipacionTrabajadoresSistema");
            DropTable("dbo.Tbl_AuditoriaOrganizacionSistema");
            DropTable("dbo.Tbl_AuditoriaMedicionYEvaluaciónSGSSTSistema");
            DropTable("dbo.Tbl_AuditoriaLiderazgoGerencialSistema");
            DropTable("dbo.Tbl_AuditoriaEmpresaSistema");
            DropTable("dbo.Tbl_AuditoriaConfiguracionMaestrosSistema");
            DropTable("dbo.Tbl_AuditoriaAplicacionSistema");
            DropTable("dbo.Tbl_ActivaAuditoriaSistema");
        }
    }
}
