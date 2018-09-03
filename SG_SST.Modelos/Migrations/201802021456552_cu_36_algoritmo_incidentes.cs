namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cu_36_algoritmo_incidentes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_IncidentesEL2",
                c => new
                    {
                        PK_Incidentes_EL2 = c.Int(nullable: false, identity: true),
                        FK_incidentes_EL2 = c.Int(nullable: false),
                        RadCargoEmpresa5VI1 = c.String(),
                        RadDescripcionFuente5VI1 = c.String(),
                        RadDescripcionAct5VI1 = c.String(),
                        RadCondiciones5VI1 = c.String(),
                        RadTEDia5VI1 = c.String(),
                        RadTEMes5VI1 = c.String(),
                        RadTEAnio5VI1 = c.String(),
                        RadEvalAmbiental5VI1 = c.String(),
                        RadFMDia5VI1 = c.String(),
                        RadFMMes5VI1 = c.String(),
                        RadFMAnio5VI1 = c.String(),
                        RadCargoEmpresa5VI2 = c.String(),
                        RadDescripcionFuente5VI2 = c.String(),
                        RadDescripcionAct5VI2 = c.String(),
                        RadCondiciones5VI2 = c.String(),
                        RadTEDia5VI2 = c.String(),
                        RadTEMes5VI2 = c.String(),
                        RadTEAnio5VI2 = c.String(),
                        RadEvalAmbiental5VI2 = c.String(),
                        RadFMDia5VI2 = c.String(),
                        RadFMMes5VI2 = c.String(),
                        RadFMAnio5VI2 = c.String(),
                        RadCargoEmpresa5VI3 = c.String(),
                        RadDescripcionFuente5VI3 = c.String(),
                        RadDescripcionAct5VI3 = c.String(),
                        RadCondiciones5VI3 = c.String(),
                        RadTEDia5VI3 = c.String(),
                        RadTEMes5VI3 = c.String(),
                        RadTEAnio5VI3 = c.String(),
                        RadEvalAmbiental5VI3 = c.String(),
                        RadFMDia5VI3 = c.String(),
                        RadFMMes5VI3 = c.String(),
                        RadFMAnio5VI3 = c.String(),
                        RadCargoEmpresa5VI4 = c.String(),
                        RadDescripcionFuente5VI4 = c.String(),
                        RadDescripcionAct5VI4 = c.String(),
                        RadCondiciones5VI4 = c.String(),
                        RadTEDia5VI4 = c.String(),
                        RadTEMes5VI4 = c.String(),
                        RadTEAnio5V4 = c.String(),
                        RadEvalAmbiental5VI4 = c.String(),
                        RadFMDia5VI4 = c.String(),
                        RadFMMes5VI4 = c.String(),
                        RadFMAnio5VI4 = c.String(),
                        VibCargoEmpresa6VI1 = c.String(),
                        VibDescFuente6VI1 = c.String(),
                        BooTipoVibCE6VI1 = c.Boolean(nullable: false),
                        BooTipoVibMB6VI1 = c.Boolean(nullable: false),
                        TiempoExpMeses6VI1 = c.String(),
                        TiempoExpHD6VI1 = c.String(),
                        VCE6VI1 = c.String(),
                        VMB6VI1 = c.String(),
                        AceTotal6VI1 = c.String(),
                        EjeDominante6VI1 = c.String(),
                        AceEjeDominante6VI1 = c.String(),
                        Frecuencia6VI1 = c.String(),
                        Aceleracion6VI1 = c.String(),
                        FechaMedDia6VI1 = c.String(),
                        FechaMedMes6VI1 = c.String(),
                        FechaMedAnio6VI1 = c.String(),
                        BooExpoRuido6VI1 = c.Boolean(nullable: false),
                        VibCargoEmpresa6VI2 = c.String(),
                        VibDescFuente6VI2 = c.String(),
                        BooTipoVibCE6VI2 = c.Boolean(nullable: false),
                        BooTipoVibMB6VI2 = c.Boolean(nullable: false),
                        TiempoExpMeses6VI2 = c.String(),
                        TiempoExpHD6VI2 = c.String(),
                        VCE6VI2 = c.String(),
                        VMB6VI2 = c.String(),
                        AceTotal6VI2 = c.String(),
                        EjeDominante6VI2 = c.String(),
                        AceEjeDominante6VI2 = c.String(),
                        Frecuencia6VI2 = c.String(),
                        Aceleracion6VI2 = c.String(),
                        FechaMedDia6VI2 = c.String(),
                        FechaMedMes6VI2 = c.String(),
                        FechaMedAnio6VI2 = c.String(),
                        BooExpoRuido6VI2 = c.Boolean(nullable: false),
                        VibCargoEmpresa6VI3 = c.String(),
                        VibDescFuente6VI3 = c.String(),
                        BooTipoVibCE6VI3 = c.Boolean(nullable: false),
                        BooTipoVibMB6VI3 = c.Boolean(nullable: false),
                        TiempoExpMeses6VI3 = c.String(),
                        TiempoExpHD6VI3 = c.String(),
                        VCE6VI3 = c.String(),
                        VMB6VI3 = c.String(),
                        AceTotal6VI3 = c.String(),
                        EjeDominante6VI3 = c.String(),
                        AceEjeDominante6VI3 = c.String(),
                        Frecuencia6VI3 = c.String(),
                        Aceleracion6VI3 = c.String(),
                        FechaMedDia6VI3 = c.String(),
                        FechaMedMes6VI3 = c.String(),
                        FechaMedAnio6VI3 = c.String(),
                        BooExpoRuido6VI3 = c.Boolean(nullable: false),
                        VibCargoEmpresa6VI4 = c.String(),
                        VibDescFuente6VI4 = c.String(),
                        BooTipoVibCE6VI4 = c.Boolean(nullable: false),
                        BooTipoVibMB6VI4 = c.Boolean(nullable: false),
                        TiempoExpMeses6VI4 = c.String(),
                        TiempoExpHD6VI4 = c.String(),
                        VCE6VI4 = c.String(),
                        VMB6VI4 = c.String(),
                        AceTotal6VI4 = c.String(),
                        EjeDominante6VI4 = c.String(),
                        AceEjeDominante6VI4 = c.String(),
                        Frecuencia6VI4 = c.String(),
                        Aceleracion6VI4 = c.String(),
                        FechaMedDia6VI4 = c.String(),
                        FechaMedMes6VI4 = c.String(),
                        FechaMedAnio6VI4 = c.String(),
                        BooExpoRuido6VI4 = c.Boolean(nullable: false),
                        VibCargoEmpresa6VI5 = c.String(),
                        VibDescFuente6VI5 = c.String(),
                        BooTipoVibCE6VI5 = c.Boolean(nullable: false),
                        BooTipoVibMB6VI5 = c.Boolean(nullable: false),
                        TiempoExpMeses6VI5 = c.String(),
                        TiempoExpHD6VI5 = c.String(),
                        VCE6VI5 = c.String(),
                        VMB6VI5 = c.String(),
                        AceTotal6VI5 = c.String(),
                        EjeDominante6VI5 = c.String(),
                        AceEjeDominante6VI5 = c.String(),
                        Frecuencia6VI5 = c.String(),
                        Aceleracion6VI5 = c.String(),
                        FechaMedDia6VI5 = c.String(),
                        FechaMedMes6VI5 = c.String(),
                        FechaMedAnio6VI5 = c.String(),
                        BooExpoRuido6VI5 = c.Boolean(nullable: false),
                        VibCargoEmpresa6VI6 = c.String(),
                        VibDescFuente6VI6 = c.String(),
                        BooTipoVibCE6VI6 = c.Boolean(nullable: false),
                        BooTipoVibMB6VI6 = c.Boolean(nullable: false),
                        TiempoExpMeses6VI6 = c.String(),
                        TiempoExpHD6VI6 = c.String(),
                        VCE6VI6 = c.String(),
                        VMB6VI6 = c.String(),
                        AceTotal6VI6 = c.String(),
                        EjeDominante6VI6 = c.String(),
                        AceEjeDominante6VI6 = c.String(),
                        Frecuencia6VI6 = c.String(),
                        Aceleracion6VI6 = c.String(),
                        FechaMedDia6VI6 = c.String(),
                        FechaMedMes6VI6 = c.String(),
                        FechaMedAnio6VI6 = c.String(),
                        BooExpoRuido6VI6 = c.Boolean(nullable: false),
                        DescEventoInv6VI = c.String(),
                        FrecPresAltoVI1 = c.String(),
                        FrecPresMedioVI1 = c.String(),
                        FrecPresBajoVI1 = c.String(),
                        TiempoExpAltoVI1 = c.String(),
                        TiempoExpMedioVI1 = c.String(),
                        TiempoExpBajoVI1 = c.String(),
                        IntensidadAltoVI1 = c.String(),
                        IntensidadMedioVI1 = c.String(),
                        IntensidadBajoVI1 = c.String(),
                        VarPsicoObservacionesVI1 = c.String(),
                        FrecPresAltoVI2 = c.String(),
                        FrecPresMedioVI2 = c.String(),
                        FrecPresBajoVI2 = c.String(),
                        TiempoExpAltoVI2 = c.String(),
                        TiempoExpMedioVI2 = c.String(),
                        TiempoExpBajoVI2 = c.String(),
                        IntensidadAltoVI2 = c.String(),
                        IntensidadMedioVI2 = c.String(),
                        IntensidadBajoVI2 = c.String(),
                        VarPsicoObservacionesVI2 = c.String(),
                        FrecPresAltoVI3 = c.String(),
                        FrecPresMedioVI3 = c.String(),
                        FrecPresBajoVI3 = c.String(),
                        TiempoExpAltoVI3 = c.String(),
                        TiempoExpMedioVI3 = c.String(),
                        TiempoExpBajoVI3 = c.String(),
                        IntensidadAltoVI3 = c.String(),
                        IntensidadMedioVI3 = c.String(),
                        IntensidadBajoVI3 = c.String(),
                        VarPsicoObservacionesVI3 = c.String(),
                        FrecPresAltoVI4 = c.String(),
                        FrecPresMedioVI4 = c.String(),
                        FrecPresBajoVI4 = c.String(),
                        TiempoExpAltoVI4 = c.String(),
                        TiempoExpMedioVI4 = c.String(),
                        TiempoExpBajoV4 = c.String(),
                        IntensidadAltoVI4 = c.String(),
                        IntensidadMedioVI4 = c.String(),
                        IntensidadBajoVI4 = c.String(),
                        VarPsicoObservacionesVI4 = c.String(),
                        IntensidadAltaVI1 = c.String(),
                        IntensidadMediaVI1 = c.String(),
                        IntensidadBajaVI1 = c.String(),
                        IntensidadObservVI1 = c.String(),
                        IntensidadAltaVI2 = c.String(),
                        IntensidadMediaVI2 = c.String(),
                        IntensidadBajaVI2 = c.String(),
                        IntensidadObservVI2 = c.String(),
                        NivelRiesgoLabVI = c.String(),
                        NivelRiesgoExtralabVI = c.String(),
                        NivelRiesgoIndiviVI = c.String(),
                        NivelEstresVI = c.String(),
                        BooPostPieProlongada = c.Boolean(nullable: false),
                        BooPostPieSedente = c.Boolean(nullable: false),
                        BooPosturaIncomodaBrazosManos = c.Boolean(nullable: false),
                        BooEsfuerzoBrazosManos = c.Boolean(nullable: false),
                        BooPosturaIncomodaEspalda = c.Boolean(nullable: false),
                        BooLabRepetitivaColumna = c.Boolean(nullable: false),
                        BooLabRepetitivaBrazoMuMano = c.Boolean(nullable: false),
                        BooPeriodoRecuperacionFisica = c.Boolean(nullable: false),
                        BooEsfuerzoManos = c.Boolean(nullable: false),
                        BooEsfuerzoCuerpo = c.Boolean(nullable: false),
                        BooManipulacionCargas = c.Boolean(nullable: false),
                        DMEResumen = c.String(),
                        BooCauRelPrevVI1 = c.Boolean(nullable: false),
                        CauRelPrevVI1 = c.String(),
                        BooCauRelPrevVI2 = c.Boolean(nullable: false),
                        CauRelPrevVI2 = c.String(),
                        BooCauRelPrevVI3 = c.Boolean(nullable: false),
                        CauRelPrevVI3 = c.String(),
                        BooCauRelPrevVI4 = c.Boolean(nullable: false),
                        CauRelPrevVI4 = c.String(),
                        BooCauRelPrevVI5 = c.Boolean(nullable: false),
                        CauRelPrevVI5 = c.String(),
                        BooCauRelPrevVI6 = c.Boolean(nullable: false),
                        CauRelPrevVI6 = c.String(),
                        BooCauRelPrevVI7 = c.Boolean(nullable: false),
                        CauRelPrevVI7 = c.String(),
                        BooCauRelPrevVI8 = c.Boolean(nullable: false),
                        CauRelPrevVI8 = c.String(),
                        BooCauRelPrevVI9 = c.Boolean(nullable: false),
                        CauRelPrevVI9 = c.String(),
                        BooCauRelPrevVI10 = c.Boolean(nullable: false),
                        CauRelPrevVI10 = c.String(),
                        BooCauRelPrevVI11 = c.Boolean(nullable: false),
                        CauRelPrevVI11 = c.String(),
                        BooCauRelPrevVI12 = c.Boolean(nullable: false),
                        CauRelPrevVI12 = c.String(),
                        OtrosDatosInteresVI = c.String(),
                        CausasEnfermedadLaboralVI = c.String(),
                        MedidasPreventivasVII1 = c.String(),
                        ResponsableImplementacionVII1 = c.String(),
                        FechaEjeMesVII1 = c.String(),
                        FechaEjeDiaVII1 = c.String(),
                        MedidasPreventivasVII2 = c.String(),
                        ResponsableImplementacionVII2 = c.String(),
                        FechaEjeMesVII3 = c.String(),
                        FechaEjeDiaVII3 = c.String(),
                        MedidasPreventivasVII4 = c.String(),
                        ResponsableImplementacionVII4 = c.String(),
                        FechaEjeMesVII4 = c.String(),
                        FechaEjeDiaVII4 = c.String(),
                        MedidasPreventivasVII5 = c.String(),
                        ResponsableImplementacionVII5 = c.String(),
                        FechaEjeMesVII5 = c.String(),
                        FechaEjeDiaVII5 = c.String(),
                        MedidasPreventivasVII6 = c.String(),
                        ResponsableImplementacionVII6 = c.String(),
                        FechaEjeMesVII6 = c.String(),
                        FechaEjeDiaVII6 = c.String(),
                        MedidasPreventivasVII7 = c.String(),
                        ResponsableImplementacionVII7 = c.String(),
                        FechaEjeMesVII7 = c.String(),
                        FechaEjeDiaVII7 = c.String(),
                        MedidasPreventivasVII8 = c.String(),
                        ResponsableImplementacionVII8 = c.String(),
                        FechaEjeMesVII8 = c.String(),
                        FechaEjeDiaVII8 = c.String(),
                        TipoIdentificacionVIII1 = c.String(),
                        JefeInmediatoVIII1 = c.String(),
                        CargoVIII1 = c.String(),
                        NumeroIdentificacionVIII1 = c.String(),
                        TipoIdentificacionVIII2 = c.String(),
                        JefeInmediatoVIII2 = c.String(),
                        CargoVIII2 = c.String(),
                        NumeroIdentificacionVIII2 = c.String(),
                        TipoIdentificacionVIII3 = c.String(),
                        JefeInmediatoVIII3 = c.String(),
                        CargoVIII3 = c.String(),
                        NumeroIdentificacionVIII3 = c.String(),
                        TipoIdentificacionVIII4 = c.String(),
                        JefeInmediatoVIII4 = c.String(),
                        CargoVIII4 = c.String(),
                        NumeroIdentificacionVIII4 = c.String(),
                        TipoIdentificacionVIII5 = c.String(),
                        JefeInmediatoVIII5 = c.String(),
                        CargoVIII5 = c.String(),
                        NumeroIdentificacionVIII5 = c.String(),
                        TipoIdentificacionVIII6 = c.String(),
                        JefeInmediatoVIII6 = c.String(),
                        CargoVIII6 = c.String(),
                        NumeroIdentificacionVIII6 = c.String(),
                        TipoIdentificacionVIII7 = c.String(),
                        EspecialistaOcupacionalVIII = c.String(),
                        LicenciaNumVIII1 = c.String(),
                        LicenciaAnioVIII1 = c.String(),
                        NumeroIdentificacionVIII7 = c.String(),
                        TipoIdentificacionVIII8 = c.String(),
                        RepresentanteArlVIII8 = c.String(),
                        LicenciaNumeroVIII8 = c.String(),
                        LicenciaAnioVIII8 = c.String(),
                        NumeroIdentificacionVIII8 = c.String(),
                        EmpresaRepresentaVIII8 = c.String(),
                        NitVIII8 = c.String(),
                        FechaRemisionIX = c.String(),
                        NoFoliosIX = c.String(),
                        TipoIdentificacionIX = c.Boolean(nullable: false),
                        NombreApellidoIX = c.String(),
                        CargoIX = c.String(),
                        NumeroIdentificacionIX = c.String(),
                        FechaRemisionARLIX = c.String(),
                        FecRemisionTerritorialIX = c.String(),
                        DisponibleRemisionARLIX = c.String(),
                        ResponsablesRemisionARLIX = c.String(),
                        CargoARLIX = c.String(),
                        TipoIdentificacionX = c.Boolean(nullable: false),
                        ResponsableVerficiacionX = c.String(),
                        CargoX = c.String(),
                        NumeroIdentificacionX = c.String(),
                        MedidasIntervencionX = c.Boolean(nullable: false),
                        ObsevacionesX = c.String(),
                        FechaVerficacionX = c.String(),
                        TipoIdentificacionXI = c.Boolean(nullable: false),
                        ResponsableVerficiacionXI = c.String(),
                        CargoXI = c.String(),
                        NumeroIdentificacionXI = c.String(),
                        MedidasIntervencionXI = c.Boolean(nullable: false),
                        ObsevacionesARLXI = c.String(),
                        FechaVerficacionXI = c.String(),
                    })
                .PrimaryKey(t => t.PK_Incidentes_EL2);
            
            AddColumn("dbo.Tbl_IncidentesAT", "NitEmpresa", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "HoraInicioI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "HoraFinI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "NitEmpresa", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "FechaInvestigacionI", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesEL", "FechaInvestigacionI", c => c.DateTime(nullable: false));
            DropColumn("dbo.Tbl_IncidentesEL", "RadCargoEmpresa5VI1");
            DropColumn("dbo.Tbl_IncidentesEL", "RadDescripcionFuente5VI1");
            DropColumn("dbo.Tbl_IncidentesEL", "RadDescripcionAct5VI1");
            DropColumn("dbo.Tbl_IncidentesEL", "RadCondiciones5VI1");
            DropColumn("dbo.Tbl_IncidentesEL", "RadTEDia5VI1");
            DropColumn("dbo.Tbl_IncidentesEL", "RadTEMes5VI1");
            DropColumn("dbo.Tbl_IncidentesEL", "RadTEAnio5VI1");
            DropColumn("dbo.Tbl_IncidentesEL", "RadEvalAmbiental5VI1");
            DropColumn("dbo.Tbl_IncidentesEL", "RadFMDia5VI1");
            DropColumn("dbo.Tbl_IncidentesEL", "RadFMMes5VI1");
            DropColumn("dbo.Tbl_IncidentesEL", "RadFMAnio5VI1");
            DropColumn("dbo.Tbl_IncidentesEL", "RadCargoEmpresa5VI2");
            DropColumn("dbo.Tbl_IncidentesEL", "RadDescripcionFuente5VI2");
            DropColumn("dbo.Tbl_IncidentesEL", "RadDescripcionAct5VI2");
            DropColumn("dbo.Tbl_IncidentesEL", "RadCondiciones5VI2");
            DropColumn("dbo.Tbl_IncidentesEL", "RadTEDia5VI2");
            DropColumn("dbo.Tbl_IncidentesEL", "RadTEMes5VI2");
            DropColumn("dbo.Tbl_IncidentesEL", "RadTEAnio5VI2");
            DropColumn("dbo.Tbl_IncidentesEL", "RadEvalAmbiental5VI2");
            DropColumn("dbo.Tbl_IncidentesEL", "RadFMDia5VI2");
            DropColumn("dbo.Tbl_IncidentesEL", "RadFMMes5VI2");
            DropColumn("dbo.Tbl_IncidentesEL", "RadFMAnio5VI2");
            DropColumn("dbo.Tbl_IncidentesEL", "RadCargoEmpresa5VI3");
            DropColumn("dbo.Tbl_IncidentesEL", "RadDescripcionFuente5VI3");
            DropColumn("dbo.Tbl_IncidentesEL", "RadDescripcionAct5VI3");
            DropColumn("dbo.Tbl_IncidentesEL", "RadCondiciones5VI3");
            DropColumn("dbo.Tbl_IncidentesEL", "RadTEDia5VI3");
            DropColumn("dbo.Tbl_IncidentesEL", "RadTEMes5VI3");
            DropColumn("dbo.Tbl_IncidentesEL", "RadTEAnio5VI3");
            DropColumn("dbo.Tbl_IncidentesEL", "RadEvalAmbiental5VI3");
            DropColumn("dbo.Tbl_IncidentesEL", "RadFMDia5VI3");
            DropColumn("dbo.Tbl_IncidentesEL", "RadFMMes5VI3");
            DropColumn("dbo.Tbl_IncidentesEL", "RadFMAnio5VI3");
            DropColumn("dbo.Tbl_IncidentesEL", "RadCargoEmpresa5VI4");
            DropColumn("dbo.Tbl_IncidentesEL", "RadDescripcionFuente5VI4");
            DropColumn("dbo.Tbl_IncidentesEL", "RadDescripcionAct5VI4");
            DropColumn("dbo.Tbl_IncidentesEL", "RadCondiciones5VI4");
            DropColumn("dbo.Tbl_IncidentesEL", "RadTEDia5VI4");
            DropColumn("dbo.Tbl_IncidentesEL", "RadTEMes5VI4");
            DropColumn("dbo.Tbl_IncidentesEL", "RadTEAnio5V4");
            DropColumn("dbo.Tbl_IncidentesEL", "RadEvalAmbiental5VI4");
            DropColumn("dbo.Tbl_IncidentesEL", "RadFMDia5VI4");
            DropColumn("dbo.Tbl_IncidentesEL", "RadFMMes5VI4");
            DropColumn("dbo.Tbl_IncidentesEL", "RadFMAnio5VI4");
            DropColumn("dbo.Tbl_IncidentesEL", "VibCargoEmpresa6VI1");
            DropColumn("dbo.Tbl_IncidentesEL", "VibDescFuente6VI1");
            DropColumn("dbo.Tbl_IncidentesEL", "BooTipoVibCE6VI1");
            DropColumn("dbo.Tbl_IncidentesEL", "BooTipoVibMB6VI1");
            DropColumn("dbo.Tbl_IncidentesEL", "TiempoExpMeses6VI1");
            DropColumn("dbo.Tbl_IncidentesEL", "TiempoExpHD6VI1");
            DropColumn("dbo.Tbl_IncidentesEL", "VCE6VI1");
            DropColumn("dbo.Tbl_IncidentesEL", "VMB6VI1");
            DropColumn("dbo.Tbl_IncidentesEL", "AceTotal6VI1");
            DropColumn("dbo.Tbl_IncidentesEL", "EjeDominante6VI1");
            DropColumn("dbo.Tbl_IncidentesEL", "AceEjeDominante6VI1");
            DropColumn("dbo.Tbl_IncidentesEL", "Frecuencia6VI1");
            DropColumn("dbo.Tbl_IncidentesEL", "Aceleracion6VI1");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaMedDia6VI1");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaMedMes6VI1");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaMedAnio6VI1");
            DropColumn("dbo.Tbl_IncidentesEL", "BooExpoRuido6VI1");
            DropColumn("dbo.Tbl_IncidentesEL", "VibCargoEmpresa6VI2");
            DropColumn("dbo.Tbl_IncidentesEL", "VibDescFuente6VI2");
            DropColumn("dbo.Tbl_IncidentesEL", "BooTipoVibCE6VI2");
            DropColumn("dbo.Tbl_IncidentesEL", "BooTipoVibMB6VI2");
            DropColumn("dbo.Tbl_IncidentesEL", "TiempoExpMeses6VI2");
            DropColumn("dbo.Tbl_IncidentesEL", "TiempoExpHD6VI2");
            DropColumn("dbo.Tbl_IncidentesEL", "VCE6VI2");
            DropColumn("dbo.Tbl_IncidentesEL", "VMB6VI2");
            DropColumn("dbo.Tbl_IncidentesEL", "AceTotal6VI2");
            DropColumn("dbo.Tbl_IncidentesEL", "EjeDominante6VI2");
            DropColumn("dbo.Tbl_IncidentesEL", "AceEjeDominante6VI2");
            DropColumn("dbo.Tbl_IncidentesEL", "Frecuencia6VI2");
            DropColumn("dbo.Tbl_IncidentesEL", "Aceleracion6VI2");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaMedDia6VI2");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaMedMes6VI2");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaMedAnio6VI2");
            DropColumn("dbo.Tbl_IncidentesEL", "BooExpoRuido6VI2");
            DropColumn("dbo.Tbl_IncidentesEL", "VibCargoEmpresa6VI3");
            DropColumn("dbo.Tbl_IncidentesEL", "VibDescFuente6VI3");
            DropColumn("dbo.Tbl_IncidentesEL", "BooTipoVibCE6VI3");
            DropColumn("dbo.Tbl_IncidentesEL", "BooTipoVibMB6VI3");
            DropColumn("dbo.Tbl_IncidentesEL", "TiempoExpMeses6VI3");
            DropColumn("dbo.Tbl_IncidentesEL", "TiempoExpHD6VI3");
            DropColumn("dbo.Tbl_IncidentesEL", "VCE6VI3");
            DropColumn("dbo.Tbl_IncidentesEL", "VMB6VI3");
            DropColumn("dbo.Tbl_IncidentesEL", "AceTotal6VI3");
            DropColumn("dbo.Tbl_IncidentesEL", "EjeDominante6VI3");
            DropColumn("dbo.Tbl_IncidentesEL", "AceEjeDominante6VI3");
            DropColumn("dbo.Tbl_IncidentesEL", "Frecuencia6VI3");
            DropColumn("dbo.Tbl_IncidentesEL", "Aceleracion6VI3");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaMedDia6VI3");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaMedMes6VI3");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaMedAnio6VI3");
            DropColumn("dbo.Tbl_IncidentesEL", "BooExpoRuido6VI3");
            DropColumn("dbo.Tbl_IncidentesEL", "VibCargoEmpresa6VI4");
            DropColumn("dbo.Tbl_IncidentesEL", "VibDescFuente6VI4");
            DropColumn("dbo.Tbl_IncidentesEL", "BooTipoVibCE6VI4");
            DropColumn("dbo.Tbl_IncidentesEL", "BooTipoVibMB6VI4");
            DropColumn("dbo.Tbl_IncidentesEL", "TiempoExpMeses6VI4");
            DropColumn("dbo.Tbl_IncidentesEL", "TiempoExpHD6VI4");
            DropColumn("dbo.Tbl_IncidentesEL", "VCE6VI4");
            DropColumn("dbo.Tbl_IncidentesEL", "VMB6VI4");
            DropColumn("dbo.Tbl_IncidentesEL", "AceTotal6VI4");
            DropColumn("dbo.Tbl_IncidentesEL", "EjeDominante6VI4");
            DropColumn("dbo.Tbl_IncidentesEL", "AceEjeDominante6VI4");
            DropColumn("dbo.Tbl_IncidentesEL", "Frecuencia6VI4");
            DropColumn("dbo.Tbl_IncidentesEL", "Aceleracion6VI4");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaMedDia6VI4");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaMedMes6VI4");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaMedAnio6VI4");
            DropColumn("dbo.Tbl_IncidentesEL", "BooExpoRuido6VI4");
            DropColumn("dbo.Tbl_IncidentesEL", "VibCargoEmpresa6VI5");
            DropColumn("dbo.Tbl_IncidentesEL", "VibDescFuente6VI5");
            DropColumn("dbo.Tbl_IncidentesEL", "BooTipoVibCE6VI5");
            DropColumn("dbo.Tbl_IncidentesEL", "BooTipoVibMB6VI5");
            DropColumn("dbo.Tbl_IncidentesEL", "TiempoExpMeses6VI5");
            DropColumn("dbo.Tbl_IncidentesEL", "TiempoExpHD6VI5");
            DropColumn("dbo.Tbl_IncidentesEL", "VCE6VI5");
            DropColumn("dbo.Tbl_IncidentesEL", "VMB6VI5");
            DropColumn("dbo.Tbl_IncidentesEL", "AceTotal6VI5");
            DropColumn("dbo.Tbl_IncidentesEL", "EjeDominante6VI5");
            DropColumn("dbo.Tbl_IncidentesEL", "AceEjeDominante6VI5");
            DropColumn("dbo.Tbl_IncidentesEL", "Frecuencia6VI5");
            DropColumn("dbo.Tbl_IncidentesEL", "Aceleracion6VI5");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaMedDia6VI5");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaMedMes6VI5");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaMedAnio6VI5");
            DropColumn("dbo.Tbl_IncidentesEL", "BooExpoRuido6VI5");
            DropColumn("dbo.Tbl_IncidentesEL", "VibCargoEmpresa6VI6");
            DropColumn("dbo.Tbl_IncidentesEL", "VibDescFuente6VI6");
            DropColumn("dbo.Tbl_IncidentesEL", "BooTipoVibCE6VI6");
            DropColumn("dbo.Tbl_IncidentesEL", "BooTipoVibMB6VI6");
            DropColumn("dbo.Tbl_IncidentesEL", "TiempoExpMeses6VI6");
            DropColumn("dbo.Tbl_IncidentesEL", "TiempoExpHD6VI6");
            DropColumn("dbo.Tbl_IncidentesEL", "VCE6VI6");
            DropColumn("dbo.Tbl_IncidentesEL", "VMB6VI6");
            DropColumn("dbo.Tbl_IncidentesEL", "AceTotal6VI6");
            DropColumn("dbo.Tbl_IncidentesEL", "EjeDominante6VI6");
            DropColumn("dbo.Tbl_IncidentesEL", "AceEjeDominante6VI6");
            DropColumn("dbo.Tbl_IncidentesEL", "Frecuencia6VI6");
            DropColumn("dbo.Tbl_IncidentesEL", "Aceleracion6VI6");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaMedDia6VI6");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaMedMes6VI6");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaMedAnio6VI6");
            DropColumn("dbo.Tbl_IncidentesEL", "BooExpoRuido6VI6");
            DropColumn("dbo.Tbl_IncidentesEL", "DescEventoInv6VI");
            DropColumn("dbo.Tbl_IncidentesEL", "FrecPresAltoVI1");
            DropColumn("dbo.Tbl_IncidentesEL", "FrecPresMedioVI1");
            DropColumn("dbo.Tbl_IncidentesEL", "FrecPresBajoVI1");
            DropColumn("dbo.Tbl_IncidentesEL", "TiempoExpAltoVI1");
            DropColumn("dbo.Tbl_IncidentesEL", "TiempoExpMedioVI1");
            DropColumn("dbo.Tbl_IncidentesEL", "TiempoExpBajoVI1");
            DropColumn("dbo.Tbl_IncidentesEL", "IntensidadAltoVI1");
            DropColumn("dbo.Tbl_IncidentesEL", "IntensidadMedioVI1");
            DropColumn("dbo.Tbl_IncidentesEL", "IntensidadBajoVI1");
            DropColumn("dbo.Tbl_IncidentesEL", "VarPsicoObservacionesVI1");
            DropColumn("dbo.Tbl_IncidentesEL", "FrecPresAltoVI2");
            DropColumn("dbo.Tbl_IncidentesEL", "FrecPresMedioVI2");
            DropColumn("dbo.Tbl_IncidentesEL", "FrecPresBajoVI2");
            DropColumn("dbo.Tbl_IncidentesEL", "TiempoExpAltoVI2");
            DropColumn("dbo.Tbl_IncidentesEL", "TiempoExpMedioVI2");
            DropColumn("dbo.Tbl_IncidentesEL", "TiempoExpBajoVI2");
            DropColumn("dbo.Tbl_IncidentesEL", "IntensidadAltoVI2");
            DropColumn("dbo.Tbl_IncidentesEL", "IntensidadMedioVI2");
            DropColumn("dbo.Tbl_IncidentesEL", "IntensidadBajoVI2");
            DropColumn("dbo.Tbl_IncidentesEL", "VarPsicoObservacionesVI2");
            DropColumn("dbo.Tbl_IncidentesEL", "FrecPresAltoVI3");
            DropColumn("dbo.Tbl_IncidentesEL", "FrecPresMedioVI3");
            DropColumn("dbo.Tbl_IncidentesEL", "FrecPresBajoVI3");
            DropColumn("dbo.Tbl_IncidentesEL", "TiempoExpAltoVI3");
            DropColumn("dbo.Tbl_IncidentesEL", "TiempoExpMedioVI3");
            DropColumn("dbo.Tbl_IncidentesEL", "TiempoExpBajoVI3");
            DropColumn("dbo.Tbl_IncidentesEL", "IntensidadAltoVI3");
            DropColumn("dbo.Tbl_IncidentesEL", "IntensidadMedioVI3");
            DropColumn("dbo.Tbl_IncidentesEL", "IntensidadBajoVI3");
            DropColumn("dbo.Tbl_IncidentesEL", "VarPsicoObservacionesVI3");
            DropColumn("dbo.Tbl_IncidentesEL", "FrecPresAltoVI4");
            DropColumn("dbo.Tbl_IncidentesEL", "FrecPresMedioVI4");
            DropColumn("dbo.Tbl_IncidentesEL", "FrecPresBajoVI4");
            DropColumn("dbo.Tbl_IncidentesEL", "TiempoExpAltoVI4");
            DropColumn("dbo.Tbl_IncidentesEL", "TiempoExpMedioVI4");
            DropColumn("dbo.Tbl_IncidentesEL", "TiempoExpBajoV4");
            DropColumn("dbo.Tbl_IncidentesEL", "IntensidadAltoVI4");
            DropColumn("dbo.Tbl_IncidentesEL", "IntensidadMedioVI4");
            DropColumn("dbo.Tbl_IncidentesEL", "IntensidadBajoVI4");
            DropColumn("dbo.Tbl_IncidentesEL", "VarPsicoObservacionesVI4");
            DropColumn("dbo.Tbl_IncidentesEL", "IntensidadAltaVI1");
            DropColumn("dbo.Tbl_IncidentesEL", "IntensidadMediaVI1");
            DropColumn("dbo.Tbl_IncidentesEL", "IntensidadBajaVI1");
            DropColumn("dbo.Tbl_IncidentesEL", "IntensidadObservVI1");
            DropColumn("dbo.Tbl_IncidentesEL", "IntensidadAltaVI2");
            DropColumn("dbo.Tbl_IncidentesEL", "IntensidadMediaVI2");
            DropColumn("dbo.Tbl_IncidentesEL", "IntensidadBajaVI2");
            DropColumn("dbo.Tbl_IncidentesEL", "IntensidadObservVI2");
            DropColumn("dbo.Tbl_IncidentesEL", "NivelRiesgoLabVI");
            DropColumn("dbo.Tbl_IncidentesEL", "NivelRiesgoExtralabVI");
            DropColumn("dbo.Tbl_IncidentesEL", "NivelRiesgoIndiviVI");
            DropColumn("dbo.Tbl_IncidentesEL", "NivelEstresVI");
            DropColumn("dbo.Tbl_IncidentesEL", "BooPostPieProlongada");
            DropColumn("dbo.Tbl_IncidentesEL", "BooPostPieSedente");
            DropColumn("dbo.Tbl_IncidentesEL", "BooPosturaIncomodaBrazosManos");
            DropColumn("dbo.Tbl_IncidentesEL", "BooEsfuerzoBrazosManos");
            DropColumn("dbo.Tbl_IncidentesEL", "BooPosturaIncomodaEspalda");
            DropColumn("dbo.Tbl_IncidentesEL", "BooLabRepetitivaColumna");
            DropColumn("dbo.Tbl_IncidentesEL", "BooLabRepetitivaBrazoMuMano");
            DropColumn("dbo.Tbl_IncidentesEL", "BooPeriodoRecuperacionFisica");
            DropColumn("dbo.Tbl_IncidentesEL", "BooEsfuerzoManos");
            DropColumn("dbo.Tbl_IncidentesEL", "BooEsfuerzoCuerpo");
            DropColumn("dbo.Tbl_IncidentesEL", "BooManipulacionCargas");
            DropColumn("dbo.Tbl_IncidentesEL", "DMEResumen");
            DropColumn("dbo.Tbl_IncidentesEL", "BooCauRelPrevVI1");
            DropColumn("dbo.Tbl_IncidentesEL", "CauRelPrevVI1");
            DropColumn("dbo.Tbl_IncidentesEL", "BooCauRelPrevVI2");
            DropColumn("dbo.Tbl_IncidentesEL", "CauRelPrevVI2");
            DropColumn("dbo.Tbl_IncidentesEL", "BooCauRelPrevVI3");
            DropColumn("dbo.Tbl_IncidentesEL", "CauRelPrevVI3");
            DropColumn("dbo.Tbl_IncidentesEL", "BooCauRelPrevVI4");
            DropColumn("dbo.Tbl_IncidentesEL", "CauRelPrevVI4");
            DropColumn("dbo.Tbl_IncidentesEL", "BooCauRelPrevVI5");
            DropColumn("dbo.Tbl_IncidentesEL", "CauRelPrevVI5");
            DropColumn("dbo.Tbl_IncidentesEL", "BooCauRelPrevVI6");
            DropColumn("dbo.Tbl_IncidentesEL", "CauRelPrevVI6");
            DropColumn("dbo.Tbl_IncidentesEL", "BooCauRelPrevVI7");
            DropColumn("dbo.Tbl_IncidentesEL", "CauRelPrevVI7");
            DropColumn("dbo.Tbl_IncidentesEL", "BooCauRelPrevVI8");
            DropColumn("dbo.Tbl_IncidentesEL", "CauRelPrevVI8");
            DropColumn("dbo.Tbl_IncidentesEL", "BooCauRelPrevVI9");
            DropColumn("dbo.Tbl_IncidentesEL", "CauRelPrevVI9");
            DropColumn("dbo.Tbl_IncidentesEL", "BooCauRelPrevVI10");
            DropColumn("dbo.Tbl_IncidentesEL", "CauRelPrevVI10");
            DropColumn("dbo.Tbl_IncidentesEL", "BooCauRelPrevVI11");
            DropColumn("dbo.Tbl_IncidentesEL", "CauRelPrevVI11");
            DropColumn("dbo.Tbl_IncidentesEL", "BooCauRelPrevVI12");
            DropColumn("dbo.Tbl_IncidentesEL", "CauRelPrevVI12");
            DropColumn("dbo.Tbl_IncidentesEL", "OtrosDatosInteresVI");
            DropColumn("dbo.Tbl_IncidentesEL", "CausasEnfermedadLaboralVI");
            DropColumn("dbo.Tbl_IncidentesEL", "MedidasPreventivasVII1");
            DropColumn("dbo.Tbl_IncidentesEL", "ResponsableImplementacionVII1");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaEjeMesVII1");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaEjeDiaVII1");
            DropColumn("dbo.Tbl_IncidentesEL", "MedidasPreventivasVII2");
            DropColumn("dbo.Tbl_IncidentesEL", "ResponsableImplementacionVII2");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaEjeMesVII3");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaEjeDiaVII3");
            DropColumn("dbo.Tbl_IncidentesEL", "MedidasPreventivasVII4");
            DropColumn("dbo.Tbl_IncidentesEL", "ResponsableImplementacionVII4");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaEjeMesVII4");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaEjeDiaVII4");
            DropColumn("dbo.Tbl_IncidentesEL", "MedidasPreventivasVII5");
            DropColumn("dbo.Tbl_IncidentesEL", "ResponsableImplementacionVII5");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaEjeMesVII5");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaEjeDiaVII5");
            DropColumn("dbo.Tbl_IncidentesEL", "MedidasPreventivasVII6");
            DropColumn("dbo.Tbl_IncidentesEL", "ResponsableImplementacionVII6");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaEjeMesVII6");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaEjeDiaVII6");
            DropColumn("dbo.Tbl_IncidentesEL", "MedidasPreventivasVII7");
            DropColumn("dbo.Tbl_IncidentesEL", "ResponsableImplementacionVII7");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaEjeMesVII7");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaEjeDiaVII7");
            DropColumn("dbo.Tbl_IncidentesEL", "MedidasPreventivasVII8");
            DropColumn("dbo.Tbl_IncidentesEL", "ResponsableImplementacionVII8");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaEjeMesVII8");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaEjeDiaVII8");
            DropColumn("dbo.Tbl_IncidentesEL", "TipoIdentificacionVIII1");
            DropColumn("dbo.Tbl_IncidentesEL", "JefeInmediatoVIII1");
            DropColumn("dbo.Tbl_IncidentesEL", "CargoVIII1");
            DropColumn("dbo.Tbl_IncidentesEL", "NumeroIdentificacionVIII1");
            DropColumn("dbo.Tbl_IncidentesEL", "TipoIdentificacionVIII2");
            DropColumn("dbo.Tbl_IncidentesEL", "JefeInmediatoVIII2");
            DropColumn("dbo.Tbl_IncidentesEL", "CargoVIII2");
            DropColumn("dbo.Tbl_IncidentesEL", "NumeroIdentificacionVIII2");
            DropColumn("dbo.Tbl_IncidentesEL", "TipoIdentificacionVIII3");
            DropColumn("dbo.Tbl_IncidentesEL", "JefeInmediatoVIII3");
            DropColumn("dbo.Tbl_IncidentesEL", "CargoVIII3");
            DropColumn("dbo.Tbl_IncidentesEL", "NumeroIdentificacionVIII3");
            DropColumn("dbo.Tbl_IncidentesEL", "TipoIdentificacionVIII4");
            DropColumn("dbo.Tbl_IncidentesEL", "JefeInmediatoVIII4");
            DropColumn("dbo.Tbl_IncidentesEL", "CargoVIII4");
            DropColumn("dbo.Tbl_IncidentesEL", "NumeroIdentificacionVIII4");
            DropColumn("dbo.Tbl_IncidentesEL", "TipoIdentificacionVIII5");
            DropColumn("dbo.Tbl_IncidentesEL", "JefeInmediatoVIII5");
            DropColumn("dbo.Tbl_IncidentesEL", "CargoVIII5");
            DropColumn("dbo.Tbl_IncidentesEL", "NumeroIdentificacionVIII5");
            DropColumn("dbo.Tbl_IncidentesEL", "TipoIdentificacionVIII6");
            DropColumn("dbo.Tbl_IncidentesEL", "JefeInmediatoVIII6");
            DropColumn("dbo.Tbl_IncidentesEL", "CargoVIII6");
            DropColumn("dbo.Tbl_IncidentesEL", "NumeroIdentificacionVIII6");
            DropColumn("dbo.Tbl_IncidentesEL", "TipoIdentificacionVIII7");
            DropColumn("dbo.Tbl_IncidentesEL", "EspecialistaOcupacionalVIII");
            DropColumn("dbo.Tbl_IncidentesEL", "LicenciaNumVIII1");
            DropColumn("dbo.Tbl_IncidentesEL", "LicenciaAnioVIII1");
            DropColumn("dbo.Tbl_IncidentesEL", "NumeroIdentificacionVIII7");
            DropColumn("dbo.Tbl_IncidentesEL", "TipoIdentificacionVIII8");
            DropColumn("dbo.Tbl_IncidentesEL", "RepresentanteArlVIII8");
            DropColumn("dbo.Tbl_IncidentesEL", "LicenciaNumeroVIII8");
            DropColumn("dbo.Tbl_IncidentesEL", "LicenciaAnioVIII8");
            DropColumn("dbo.Tbl_IncidentesEL", "NumeroIdentificacionVIII8");
            DropColumn("dbo.Tbl_IncidentesEL", "EmpresaRepresentaVIII8");
            DropColumn("dbo.Tbl_IncidentesEL", "NitVIII8");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaRemisionIX");
            DropColumn("dbo.Tbl_IncidentesEL", "NoFoliosIX");
            DropColumn("dbo.Tbl_IncidentesEL", "TipoIdentificacionIX");
            DropColumn("dbo.Tbl_IncidentesEL", "NombreApellidoIX");
            DropColumn("dbo.Tbl_IncidentesEL", "CargoIX");
            DropColumn("dbo.Tbl_IncidentesEL", "NumeroIdentificacionIX");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaRemisionARLIX");
            DropColumn("dbo.Tbl_IncidentesEL", "FecRemisionTerritorialIX");
            DropColumn("dbo.Tbl_IncidentesEL", "DisponibleRemisionARLIX");
            DropColumn("dbo.Tbl_IncidentesEL", "ResponsablesRemisionARLIX");
            DropColumn("dbo.Tbl_IncidentesEL", "CargoARLIX");
            DropColumn("dbo.Tbl_IncidentesEL", "TipoIdentificacionX");
            DropColumn("dbo.Tbl_IncidentesEL", "ResponsableVerficiacionX");
            DropColumn("dbo.Tbl_IncidentesEL", "CargoX");
            DropColumn("dbo.Tbl_IncidentesEL", "NumeroIdentificacionX");
            DropColumn("dbo.Tbl_IncidentesEL", "MedidasIntervencionX");
            DropColumn("dbo.Tbl_IncidentesEL", "ObsevacionesX");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaVerficacionX");
            DropColumn("dbo.Tbl_IncidentesEL", "TipoIdentificacionXI");
            DropColumn("dbo.Tbl_IncidentesEL", "ResponsableVerficiacionXI");
            DropColumn("dbo.Tbl_IncidentesEL", "CargoXI");
            DropColumn("dbo.Tbl_IncidentesEL", "NumeroIdentificacionXI");
            DropColumn("dbo.Tbl_IncidentesEL", "MedidasIntervencionXI");
            DropColumn("dbo.Tbl_IncidentesEL", "ObsevacionesARLXI");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaVerficacionXI");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tbl_IncidentesEL", "FechaVerficacionXI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "ObsevacionesARLXI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "MedidasIntervencionXI", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "NumeroIdentificacionXI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "CargoXI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "ResponsableVerficiacionXI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TipoIdentificacionXI", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "FechaVerficacionX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "ObsevacionesX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "MedidasIntervencionX", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "NumeroIdentificacionX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "CargoX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "ResponsableVerficiacionX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TipoIdentificacionX", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "CargoARLIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "ResponsablesRemisionARLIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "DisponibleRemisionARLIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FecRemisionTerritorialIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FechaRemisionARLIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "NumeroIdentificacionIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "CargoIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "NombreApellidoIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TipoIdentificacionIX", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "NoFoliosIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FechaRemisionIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "NitVIII8", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "EmpresaRepresentaVIII8", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "NumeroIdentificacionVIII8", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "LicenciaAnioVIII8", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "LicenciaNumeroVIII8", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RepresentanteArlVIII8", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TipoIdentificacionVIII8", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "NumeroIdentificacionVIII7", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "LicenciaAnioVIII1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "LicenciaNumVIII1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "EspecialistaOcupacionalVIII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TipoIdentificacionVIII7", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "NumeroIdentificacionVIII6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "CargoVIII6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "JefeInmediatoVIII6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TipoIdentificacionVIII6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "NumeroIdentificacionVIII5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "CargoVIII5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "JefeInmediatoVIII5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TipoIdentificacionVIII5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "NumeroIdentificacionVIII4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "CargoVIII4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "JefeInmediatoVIII4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TipoIdentificacionVIII4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "NumeroIdentificacionVIII3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "CargoVIII3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "JefeInmediatoVIII3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TipoIdentificacionVIII3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "NumeroIdentificacionVIII2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "CargoVIII2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "JefeInmediatoVIII2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TipoIdentificacionVIII2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "NumeroIdentificacionVIII1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "CargoVIII1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "JefeInmediatoVIII1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TipoIdentificacionVIII1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FechaEjeDiaVII8", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FechaEjeMesVII8", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "ResponsableImplementacionVII8", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "MedidasPreventivasVII8", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FechaEjeDiaVII7", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FechaEjeMesVII7", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "ResponsableImplementacionVII7", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "MedidasPreventivasVII7", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FechaEjeDiaVII6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FechaEjeMesVII6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "ResponsableImplementacionVII6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "MedidasPreventivasVII6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FechaEjeDiaVII5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FechaEjeMesVII5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "ResponsableImplementacionVII5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "MedidasPreventivasVII5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FechaEjeDiaVII4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FechaEjeMesVII4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "ResponsableImplementacionVII4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "MedidasPreventivasVII4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FechaEjeDiaVII3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FechaEjeMesVII3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "ResponsableImplementacionVII2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "MedidasPreventivasVII2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FechaEjeDiaVII1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FechaEjeMesVII1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "ResponsableImplementacionVII1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "MedidasPreventivasVII1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "CausasEnfermedadLaboralVI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "OtrosDatosInteresVI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "CauRelPrevVI12", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "BooCauRelPrevVI12", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "CauRelPrevVI11", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "BooCauRelPrevVI11", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "CauRelPrevVI10", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "BooCauRelPrevVI10", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "CauRelPrevVI9", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "BooCauRelPrevVI9", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "CauRelPrevVI8", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "BooCauRelPrevVI8", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "CauRelPrevVI7", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "BooCauRelPrevVI7", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "CauRelPrevVI6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "BooCauRelPrevVI6", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "CauRelPrevVI5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "BooCauRelPrevVI5", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "CauRelPrevVI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "BooCauRelPrevVI4", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "CauRelPrevVI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "BooCauRelPrevVI3", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "CauRelPrevVI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "BooCauRelPrevVI2", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "CauRelPrevVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "BooCauRelPrevVI1", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "DMEResumen", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "BooManipulacionCargas", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "BooEsfuerzoCuerpo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "BooEsfuerzoManos", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "BooPeriodoRecuperacionFisica", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "BooLabRepetitivaBrazoMuMano", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "BooLabRepetitivaColumna", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "BooPosturaIncomodaEspalda", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "BooEsfuerzoBrazosManos", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "BooPosturaIncomodaBrazosManos", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "BooPostPieSedente", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "BooPostPieProlongada", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "NivelEstresVI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "NivelRiesgoIndiviVI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "NivelRiesgoExtralabVI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "NivelRiesgoLabVI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "IntensidadObservVI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "IntensidadBajaVI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "IntensidadMediaVI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "IntensidadAltaVI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "IntensidadObservVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "IntensidadBajaVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "IntensidadMediaVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "IntensidadAltaVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "VarPsicoObservacionesVI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "IntensidadBajoVI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "IntensidadMedioVI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "IntensidadAltoVI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TiempoExpBajoV4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TiempoExpMedioVI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TiempoExpAltoVI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FrecPresBajoVI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FrecPresMedioVI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FrecPresAltoVI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "VarPsicoObservacionesVI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "IntensidadBajoVI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "IntensidadMedioVI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "IntensidadAltoVI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TiempoExpBajoVI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TiempoExpMedioVI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TiempoExpAltoVI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FrecPresBajoVI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FrecPresMedioVI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FrecPresAltoVI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "VarPsicoObservacionesVI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "IntensidadBajoVI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "IntensidadMedioVI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "IntensidadAltoVI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TiempoExpBajoVI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TiempoExpMedioVI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TiempoExpAltoVI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FrecPresBajoVI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FrecPresMedioVI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FrecPresAltoVI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "VarPsicoObservacionesVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "IntensidadBajoVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "IntensidadMedioVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "IntensidadAltoVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TiempoExpBajoVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TiempoExpMedioVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TiempoExpAltoVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FrecPresBajoVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FrecPresMedioVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FrecPresAltoVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "DescEventoInv6VI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "BooExpoRuido6VI6", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "FechaMedAnio6VI6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FechaMedMes6VI6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FechaMedDia6VI6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "Aceleracion6VI6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "Frecuencia6VI6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "AceEjeDominante6VI6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "EjeDominante6VI6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "AceTotal6VI6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "VMB6VI6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "VCE6VI6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TiempoExpHD6VI6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TiempoExpMeses6VI6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "BooTipoVibMB6VI6", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "BooTipoVibCE6VI6", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "VibDescFuente6VI6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "VibCargoEmpresa6VI6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "BooExpoRuido6VI5", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "FechaMedAnio6VI5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FechaMedMes6VI5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FechaMedDia6VI5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "Aceleracion6VI5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "Frecuencia6VI5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "AceEjeDominante6VI5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "EjeDominante6VI5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "AceTotal6VI5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "VMB6VI5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "VCE6VI5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TiempoExpHD6VI5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TiempoExpMeses6VI5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "BooTipoVibMB6VI5", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "BooTipoVibCE6VI5", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "VibDescFuente6VI5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "VibCargoEmpresa6VI5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "BooExpoRuido6VI4", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "FechaMedAnio6VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FechaMedMes6VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FechaMedDia6VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "Aceleracion6VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "Frecuencia6VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "AceEjeDominante6VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "EjeDominante6VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "AceTotal6VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "VMB6VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "VCE6VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TiempoExpHD6VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TiempoExpMeses6VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "BooTipoVibMB6VI4", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "BooTipoVibCE6VI4", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "VibDescFuente6VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "VibCargoEmpresa6VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "BooExpoRuido6VI3", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "FechaMedAnio6VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FechaMedMes6VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FechaMedDia6VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "Aceleracion6VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "Frecuencia6VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "AceEjeDominante6VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "EjeDominante6VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "AceTotal6VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "VMB6VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "VCE6VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TiempoExpHD6VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TiempoExpMeses6VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "BooTipoVibMB6VI3", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "BooTipoVibCE6VI3", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "VibDescFuente6VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "VibCargoEmpresa6VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "BooExpoRuido6VI2", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "FechaMedAnio6VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FechaMedMes6VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FechaMedDia6VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "Aceleracion6VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "Frecuencia6VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "AceEjeDominante6VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "EjeDominante6VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "AceTotal6VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "VMB6VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "VCE6VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TiempoExpHD6VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TiempoExpMeses6VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "BooTipoVibMB6VI2", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "BooTipoVibCE6VI2", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "VibDescFuente6VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "VibCargoEmpresa6VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "BooExpoRuido6VI1", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "FechaMedAnio6VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FechaMedMes6VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FechaMedDia6VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "Aceleracion6VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "Frecuencia6VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "AceEjeDominante6VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "EjeDominante6VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "AceTotal6VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "VMB6VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "VCE6VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TiempoExpHD6VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TiempoExpMeses6VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "BooTipoVibMB6VI1", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "BooTipoVibCE6VI1", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL", "VibDescFuente6VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "VibCargoEmpresa6VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadFMAnio5VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadFMMes5VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadFMDia5VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadEvalAmbiental5VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadTEAnio5V4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadTEMes5VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadTEDia5VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadCondiciones5VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadDescripcionAct5VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadDescripcionFuente5VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadCargoEmpresa5VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadFMAnio5VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadFMMes5VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadFMDia5VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadEvalAmbiental5VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadTEAnio5VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadTEMes5VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadTEDia5VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadCondiciones5VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadDescripcionAct5VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadDescripcionFuente5VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadCargoEmpresa5VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadFMAnio5VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadFMMes5VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadFMDia5VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadEvalAmbiental5VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadTEAnio5VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadTEMes5VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadTEDia5VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadCondiciones5VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadDescripcionAct5VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadDescripcionFuente5VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadCargoEmpresa5VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadFMAnio5VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadFMMes5VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadFMDia5VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadEvalAmbiental5VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadTEAnio5VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadTEMes5VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadTEDia5VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadCondiciones5VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadDescripcionAct5VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadDescripcionFuente5VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "RadCargoEmpresa5VI1", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesEL", "FechaInvestigacionI", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "FechaInvestigacionI", c => c.String());
            DropColumn("dbo.Tbl_IncidentesEL", "NitEmpresa");
            DropColumn("dbo.Tbl_IncidentesEL", "HoraFinI");
            DropColumn("dbo.Tbl_IncidentesEL", "HoraInicioI");
            DropColumn("dbo.Tbl_IncidentesAT", "NitEmpresa");
            DropTable("dbo.Tbl_IncidentesEL2");
        }
    }
}
