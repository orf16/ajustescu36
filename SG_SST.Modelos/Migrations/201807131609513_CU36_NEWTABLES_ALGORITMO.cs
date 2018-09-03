namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CU36_NEWTABLES_ALGORITMO : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tbl_Departamento", "IncidentesAT_PK_Incidentes_AT", "dbo.Tbl_IncidentesAT");
            DropForeignKey("dbo.Tbl_Departamento", "IncidentesAT_PK_Incidentes_AT1", "dbo.Tbl_IncidentesAT");
            DropForeignKey("dbo.Tbl_Departamento", "IncidentesAT_PK_Incidentes_AT2", "dbo.Tbl_IncidentesAT");
            DropForeignKey("dbo.Tbl_Departamento", "IncidentesAT_PK_Incidentes_AT3", "dbo.Tbl_IncidentesAT");
            DropForeignKey("dbo.Tbl_Municipio", "IncidentesAT_PK_Incidentes_AT", "dbo.Tbl_IncidentesAT");
            DropForeignKey("dbo.Tbl_Municipio", "IncidentesAT_PK_Incidentes_AT1", "dbo.Tbl_IncidentesAT");
            DropForeignKey("dbo.Tbl_Municipio", "IncidentesAT_PK_Incidentes_AT2", "dbo.Tbl_IncidentesAT");
            DropForeignKey("dbo.Tbl_Municipio", "IncidentesAT_PK_Incidentes_AT3", "dbo.Tbl_IncidentesAT");
            DropIndex("dbo.Tbl_Municipio", new[] { "IncidentesAT_PK_Incidentes_AT" });
            DropIndex("dbo.Tbl_Municipio", new[] { "IncidentesAT_PK_Incidentes_AT1" });
            DropIndex("dbo.Tbl_Municipio", new[] { "IncidentesAT_PK_Incidentes_AT2" });
            DropIndex("dbo.Tbl_Municipio", new[] { "IncidentesAT_PK_Incidentes_AT3" });
            DropIndex("dbo.Tbl_Departamento", new[] { "IncidentesAT_PK_Incidentes_AT" });
            DropIndex("dbo.Tbl_Departamento", new[] { "IncidentesAT_PK_Incidentes_AT1" });
            DropIndex("dbo.Tbl_Departamento", new[] { "IncidentesAT_PK_Incidentes_AT2" });
            DropIndex("dbo.Tbl_Departamento", new[] { "IncidentesAT_PK_Incidentes_AT3" });
            CreateTable(
                "dbo.Tbl_IncidentesAT1",
                c => new
                    {
                        PK_Incidentes_AT = c.Int(nullable: false, identity: true),
                        boIncidente = c.String(),
                        boIncidente1 = c.String(),
                        boAccidenteTrabajo = c.String(),
                        boLeve = c.String(),
                        boGrave = c.String(),
                        boMortal = c.String(),
                        FechaInvestigacionI = c.DateTime(nullable: false),
                        pk_DepartamentoI = c.Int(nullable: false),
                        pk_MunicipioI = c.Int(nullable: false),
                        DireccionI = c.String(),
                        HoraInicialI = c.String(),
                        HoraFinalI = c.String(),
                        ResponsablesI = c.String(),
                        FotografiasI = c.Boolean(nullable: false),
                        VideosI = c.Boolean(nullable: false),
                        CintasAudioI = c.Boolean(nullable: false),
                        IlustracionesI = c.Boolean(nullable: false),
                        DiagramasI = c.Boolean(nullable: false),
                        OtrosI = c.Boolean(nullable: false),
                        CualesI = c.String(),
                        myFile1 = c.String(),
                        NitEmpresa = c.String(),
                    })
                .PrimaryKey(t => t.PK_Incidentes_AT);
            
            CreateTable(
                "dbo.Tbl_IncidentesAT10",
                c => new
                    {
                        PK_Incidentes_AT10 = c.Int(nullable: false, identity: true),
                        FK_incidentes_AT10 = c.Int(nullable: false),
                        CausasInmediatasTipoC1X = c.String(),
                        MedidasIntervencion1X = c.String(),
                        TipoF1X = c.String(),
                        RespImplementacion1X = c.String(),
                        FechaImplementacion1X = c.String(),
                        CausasInmediatasTipoC2X = c.String(),
                        MedidasIntervencion2X = c.String(),
                        TipoF2X = c.String(),
                        RespImplementacion2X = c.String(),
                        FechaImplementacion2X = c.String(),
                        CausasInmediatasTipoC3X = c.String(),
                        MedidasIntervencion3X = c.String(),
                        TipoF3X = c.String(),
                        RespImplementacion3X = c.String(),
                        FechaImplementacion3X = c.String(),
                        CausasBasicasTipoC1X = c.String(),
                        BasicasInmediatas1X = c.String(),
                        BasicasF1X = c.String(),
                        BasicasRespImplementacion1X = c.String(),
                        BasicasFechaImplementacion1X = c.String(),
                        CausasBasicasTipoC2X = c.String(),
                        BasicasInmediatas2X = c.String(),
                        BasicasF2X = c.String(),
                        BasicasRespImplementacion2X = c.String(),
                        BasicasFechaImplementacion2X = c.String(),
                        CausasBasicasTipoC3X = c.String(),
                        BasicasInmediatas3X = c.String(),
                        BasicasF3X = c.String(),
                        BasicasRespImplementacion3X = c.String(),
                        BasicasFechaImplementacion3X = c.String(),
                        boTipoF1X = c.Boolean(nullable: false),
                        boTipoM1X = c.Boolean(nullable: false),
                        boTipoT1X = c.Boolean(nullable: false),
                        boTipoF2X = c.Boolean(nullable: false),
                        boTipoM2X = c.Boolean(nullable: false),
                        boTipoT2X = c.Boolean(nullable: false),
                        boTipoF3X = c.Boolean(nullable: false),
                        boTipoM3X = c.Boolean(nullable: false),
                        boTipoT3X = c.Boolean(nullable: false),
                        boBasicasF1X = c.Boolean(nullable: false),
                        boBasicasM1X = c.Boolean(nullable: false),
                        boBasicasT1X = c.Boolean(nullable: false),
                        boBasicasF2X = c.Boolean(nullable: false),
                        boBasicasM2X = c.Boolean(nullable: false),
                        boBasicasT2X = c.Boolean(nullable: false),
                        boBasicasF3X = c.Boolean(nullable: false),
                        boBasicasM3X = c.Boolean(nullable: false),
                        boBasicasT3X = c.Boolean(nullable: false),
                        BasicasT3X = c.String(),
                        myFile10 = c.String(),
                        NitEmpresa = c.String(),
                    })
                .PrimaryKey(t => t.PK_Incidentes_AT10);
            
            CreateTable(
                "dbo.Tbl_IncidentesAT11",
                c => new
                    {
                        PK_Incidentes_AT11 = c.Int(nullable: false, identity: true),
                        FK_incidentes_AT11 = c.Int(nullable: false),
                        FechaRemisionXI = c.String(),
                        NoFoliosXI = c.String(),
                        TipoIdentificacionXI = c.String(),
                        NumeroIdentificacionXI = c.String(),
                        NombresXI = c.String(),
                        CargoXI = c.String(),
                        RecomendacionesARLXI = c.String(),
                        RemisionInformeARLXI = c.String(),
                        RemisionMinisterioTrabajoXI = c.String(),
                        RecomendacionesCargoXI = c.String(),
                        NitEmpresa = c.String(),
                    })
                .PrimaryKey(t => t.PK_Incidentes_AT11);
            
            CreateTable(
                "dbo.Tbl_IncidentesAT12",
                c => new
                    {
                        PK_Incidentes_AT12 = c.Int(nullable: false, identity: true),
                        FK_incidentes_AT12 = c.Int(nullable: false),
                        TipoIdentificacionXII = c.String(),
                        NumeroIdentificacionXII = c.String(),
                        NombresXII = c.String(),
                        CargoXII = c.String(),
                        MedidasIntervencionXII = c.String(),
                        ObservacionesXII = c.String(),
                        FechaVerificacionXII = c.String(),
                        myFile11 = c.String(),
                        NitEmpresa = c.String(),
                    })
                .PrimaryKey(t => t.PK_Incidentes_AT12);
            
            CreateTable(
                "dbo.Tbl_IncidentesAT13",
                c => new
                    {
                        PK_Incidentes_AT13 = c.Int(nullable: false, identity: true),
                        FK_incidentes_AT13 = c.Int(nullable: false),
                        TipoIdentificacionXIII = c.String(),
                        NombresXIII = c.String(),
                        CargoXIII = c.String(),
                        NumeroIdentificacionXIII = c.String(),
                        MedidasIntervencionXIII = c.String(),
                        FechaVerificacionXIII = c.String(),
                        ObservacionesXIII = c.String(),
                        myFile12 = c.String(),
                        NitEmpresa = c.String(),
                    })
                .PrimaryKey(t => t.PK_Incidentes_AT13);
            
            CreateTable(
                "dbo.Tbl_IncidentesAT2",
                c => new
                    {
                        PK_Incidentes_AT2 = c.Int(nullable: false, identity: true),
                        FK_incidentes_AT2 = c.Int(nullable: false),
                        boTipoVinculacionII = c.String(),
                        TipoIdentificacionII = c.String(),
                        ActividadEconomicaII = c.String(),
                        NumeroIdentificacionII = c.String(),
                        NombreRazonSocialII = c.String(),
                        DireccionPpalII = c.String(),
                        TelefonoII = c.String(),
                        FaxII = c.String(),
                        st_DepartamentoII = c.String(),
                        st_MunicipioII = c.String(),
                        EmailII = c.String(),
                        ZonaUrbanaII = c.String(),
                        SedePrincipalII = c.Boolean(nullable: false),
                        CodigoActEconoCentroTrabajoII = c.String(),
                        ActEconoCentroTrabajoII = c.String(),
                        CentroCostoTelefonoII = c.String(),
                        CentroCostoFaxII = c.String(),
                        DireccionCentroTrabajoII = c.String(),
                        ZonaII = c.String(),
                        pk_DeptoCentroCostoII = c.Int(nullable: false),
                        pk_MncpioCentroCostoII = c.Int(nullable: false),
                        NitEmpresa = c.String(),
                    })
                .PrimaryKey(t => t.PK_Incidentes_AT2);
            
            CreateTable(
                "dbo.Tbl_IncidentesAT3",
                c => new
                    {
                        PK_Incidentes_AT3 = c.Int(nullable: false, identity: true),
                        FK_incidentes_AT3 = c.Int(nullable: false),
                        boTipoVinculacionIII = c.String(),
                        tempTipoIdentificacionIII = c.String(),
                        NumeroIdentificacionIII = c.String(),
                        PrimerApellidoIII = c.String(),
                        SegundoApellidoIII = c.String(),
                        PrimerNombreIII = c.String(),
                        FechaNacimientoIII = c.String(),
                        DepartamentoIII = c.String(),
                        MunicipioIII = c.String(),
                        SexoIII = c.String(),
                        EPSIII = c.String(),
                        AFPIII = c.String(),
                        ARLIII = c.String(),
                        TelefonoIII = c.String(),
                        FaxIII = c.String(),
                        EmailIII = c.String(),
                        DireccionCentroTrabajoIII = c.String(),
                        ZonaIII = c.String(),
                        CargoIII = c.String(),
                        OcupacionIII = c.String(),
                        FechaIngresoIII = c.String(),
                        TiempoOcupacionAIII = c.String(),
                        TiempoOcupacionMIII = c.String(),
                        AntiguedadAIII = c.String(),
                        AntiguedadMIII = c.String(),
                        boJornadaIII = c.String(),
                        SalarioHonorariosIII = c.String(),
                        FechaMuerteIII = c.String(),
                        AtencionOportunaIII = c.String(),
                        SegundoNombreIII = c.String(),
                        CodigoOcupacionIII = c.String(),
                        AtencionOportunaOtrosIII = c.String(),
                        NitEmpresa = c.String(),
                    })
                .PrimaryKey(t => t.PK_Incidentes_AT3);
            
            CreateTable(
                "dbo.Tbl_IncidentesAT4",
                c => new
                    {
                        PK_Incidentes_AT4 = c.Int(nullable: false, identity: true),
                        FK_incidentes_AT4 = c.Int(nullable: false),
                        FechaOcurrenciaIV = c.String(),
                        HoraOcurrenciaIV = c.String(),
                        boJornadaIV = c.String(),
                        boDiaSemanaIV = c.String(),
                        LaborHabitualIV = c.String(),
                        LaborHabitualIVN = c.Boolean(nullable: false),
                        TipoIncidenteIV = c.String(),
                        EspecTipoIncidenteIV = c.String(),
                        IPSAtendioIV = c.String(),
                        ZonaIV = c.String(),
                        TiempoLaboradoPrevioIV = c.String(),
                        LugarExactoIV = c.String(),
                        SitioExactoIV = c.String(),
                        OtroSitioIV = c.Boolean(nullable: false),
                        EspecifiqueIV = c.String(),
                        pk_DepartamentoIV = c.Int(nullable: false),
                        pk_MncpioIV = c.Int(nullable: false),
                        NitEmpresa = c.String(),
                    })
                .PrimaryKey(t => t.PK_Incidentes_AT4);
            
            CreateTable(
                "dbo.Tbl_IncidentesAT5",
                c => new
                    {
                        PK_Incidentes_AT5 = c.Int(nullable: false, identity: true),
                        FK_incidentes_AT5 = c.Int(nullable: false),
                        EventosSimilaresV = c.String(),
                        NumeroPersonasV = c.String(),
                        OtrosIncidentesV = c.String(),
                        EventoSimilarV = c.String(),
                        CondicionPrioritariaV = c.String(),
                        TrabajadorInvolucradoV = c.String(),
                        PanoramaRiesgoV = c.String(),
                        DescripcionAccidenteV = c.String(),
                        NitEmpresa = c.String(),
                    })
                .PrimaryKey(t => t.PK_Incidentes_AT5);
            
            CreateTable(
                "dbo.Tbl_IncidentesAT6",
                c => new
                    {
                        PK_Incidentes_AT6 = c.Int(nullable: false, identity: true),
                        FK_incidentes_AT6 = c.Int(nullable: false),
                        GasesUnidadVI = c.String(),
                        MarcaVI = c.String(),
                        AgenteVI = c.String(),
                        MaterialVI = c.String(),
                        ModeloVI = c.String(),
                        ReferenciaVI = c.String(),
                        PesoVI = c.String(),
                        PesoUnidadMedidaVI = c.String(),
                        AlturaVI = c.String(),
                        AnchoVI = c.String(),
                        VolumenVI = c.String(),
                        ProfundidadVI = c.String(),
                        VelocidadVI = c.String(),
                        TiempoUsoVI = c.String(),
                        TiempoUsoVIA = c.String(),
                        FechaMantenimientoVI = c.String(),
                        ReparadoVI = c.String(),
                        ExplosivosVI = c.String(),
                        ExplosivosUnidadMedidaVI = c.String(),
                        ExplosivosUnidadMedidaVI2 = c.String(),
                        ExplosivosUnidadMedidaV2 = c.String(),
                        GasesVI = c.String(),
                        GasesCantidadVI = c.String(),
                        SustanciaVI = c.String(),
                        TemperaturaVI = c.String(),
                        TemperaturaUnidadMedidaVI = c.String(),
                        SustanciaUnidadMedidaVI = c.String(),
                        SustanciaCantidadVI = c.String(),
                        VoltajeElectricoVI = c.String(),
                        VoltajeElectricoUnidadMedidaVI = c.String(),
                        VoltajeElectricoUnidadMedidaV2 = c.String(),
                        UnidadMedidaVI = c.String(),
                        DetallesAdicionalesVI = c.String(),
                        EPPVI = c.String(),
                        TrabajadorEPPVI = c.String(),
                        ObservacionesVI = c.String(),
                        VelocidadUnidadMedidaVI = c.String(),
                        NitEmpresa = c.String(),
                    })
                .PrimaryKey(t => t.PK_Incidentes_AT6);
            
            CreateTable(
                "dbo.Tbl_IncidentesAT7",
                c => new
                    {
                        PK_Incidentes_AT7 = c.Int(nullable: false, identity: true),
                        FK_incidentes_AT7 = c.Int(nullable: false),
                        CodTipoLesionVII = c.String(),
                        TipoLesionVII = c.String(),
                        CodigoParteCuerpoAfectadaVII = c.String(),
                        CodMecaAccideneteVII = c.String(),
                        MecanismoAccidenteVII = c.String(),
                        CodAgenteAccideneteVII = c.String(),
                        AgenteAccidenteVII = c.String(),
                        CodFactoresPersonalesVII1 = c.String(),
                        FactoresPersonalesVII1 = c.String(),
                        CodFactoresPersonalesVII2 = c.String(),
                        CodActFactoresPersonalesVII2 = c.String(),
                        ActFactoresPersonalesVII2 = c.String(),
                        CodActoSubestandarVII1 = c.String(),
                        ActosSubestandarVII1 = c.String(),
                        CodActoSubestandarVII2 = c.String(),
                        ActosSubestandarVII2 = c.String(),
                        CodFactoresTrabajoVII1 = c.String(),
                        FactoresTrabajoVII1 = c.String(),
                        CodFactoresTrabajoVII2 = c.String(),
                        FactoresTrabajoVII2 = c.String(),
                        CodCondAmbientalesVII1 = c.String(),
                        CondAmbientalesVII1 = c.String(),
                        CodCondAmbientalesVII2 = c.String(),
                        CondAmbientalesVII2 = c.String(),
                        textfield74 = c.String(),
                        FactoresPersonalesVII2 = c.String(),
                        NitEmpresa = c.String(),
                    })
                .PrimaryKey(t => t.PK_Incidentes_AT7);
            
            CreateTable(
                "dbo.Tbl_IncidentesAT8",
                c => new
                    {
                        PK_Incidentes_AT8 = c.Int(nullable: false, identity: true),
                        FK_incidentes_AT8 = c.Int(nullable: false),
                        NitEmpresa = c.String(),
                        myFile2 = c.String(),
                    })
                .PrimaryKey(t => t.PK_Incidentes_AT8);
            
            CreateTable(
                "dbo.Tbl_IncidentesAT9",
                c => new
                    {
                        PK_Incidentes_AT9 = c.Int(nullable: false, identity: true),
                        FK_incidentes_AT9 = c.Int(nullable: false),
                        TipoIdentJefeInmediantoIX = c.String(),
                        NumIdentJefeInmediatoIX = c.String(),
                        JefeInmediatoNombresIX = c.String(),
                        JefeInmediatoCargoIX = c.String(),
                        DescripcionAnalisisIX = c.String(),
                        TipoIdentEncargadoPSOIX = c.String(),
                        NumIdentPSOIX = c.String(),
                        EncargadoPSONombresIX = c.String(),
                        EncargadoPSOCargoIX = c.String(),
                        TipoIdentCOPASOIX = c.String(),
                        COPASONumIdentIX = c.String(),
                        COPASONombresCompletosIX = c.String(),
                        COPASOCargoIX = c.String(),
                        TipoIdentEncargadosPSOIX = c.String(),
                        TipoIdentBrigadistaIX = c.String(),
                        NumeroIdentBrigadistaIX = c.String(),
                        BrigadistaNombresIX = c.String(),
                        BrigadistaCargoIX = c.String(),
                        TipoIdentParticipanteIX = c.String(),
                        NumIdentParticipanteIX = c.String(),
                        ParticipanteNombreIX = c.String(),
                        ParticipanteCargoIX = c.String(),
                        TipoIdentAnalisisIX = c.String(),
                        EmpresaRepresentaIX = c.String(),
                        ObservacionEspecialistaIX = c.String(),
                        TipoIdentRepresentanteARLIX = c.String(),
                        RepresentanteARLNombresIX = c.String(),
                        NumLicenciaEspecialistaSGSSTIX1 = c.String(),
                        anioLicenciaEspecialistaSGSSTIX1 = c.String(),
                        NumIdentRepresentanteARLIXIX = c.String(),
                        TipoIdentEspecialistaSGSSTIX = c.String(),
                        EspecialistaSGSSTNombresIX = c.String(),
                        NumLicenciaEspecialistaSGSSTIX2 = c.String(),
                        anioLicenciaEspecialistaSGSSTIX2 = c.String(),
                        NumIdentEspecialistaSGSSTIX = c.String(),
                        FechaVerificacionXII = c.String(),
                        TipoIdentJefeInmediantoIXTI = c.String(),
                        TipoIdentEncargadoPSOIXTI = c.String(),
                        TipoIdentCOPASOIXTI = c.String(),
                        TipoIdentBrigadistaIXTI = c.String(),
                        TipoIdentParticipanteIXTI = c.String(),
                        TipoIdentRepresentanteARLIXTI = c.String(),
                        TipoIdentEspecialistaSGSSTIXTI = c.String(),
                        myFile3 = c.String(),
                        myFile4 = c.String(),
                        myFile5 = c.String(),
                        myFile6 = c.String(),
                        myFile7 = c.String(),
                        myFile8 = c.String(),
                        myFile9 = c.String(),
                        NitEmpresa = c.String(),
                    })
                .PrimaryKey(t => t.PK_Incidentes_AT9);
            
            CreateTable(
                "dbo.Tbl_IncidentesATAnexos",
                c => new
                    {
                        PK_Incidentes_ATAnexos = c.Int(nullable: false, identity: true),
                        FK_incidentes_ATAnexos = c.Int(nullable: false),
                        AnexoFechaIncidente = c.String(),
                        AnexoFechaTestimonio = c.String(),
                        AnexoTipoIdentificacion = c.String(),
                        AnexoNumIdentificacion = c.String(),
                        AnexoNombres = c.String(),
                        AnexoCargo = c.String(),
                        AnexoDondeSucedio = c.String(),
                        AnexoPrevenir = c.String(),
                        AnexoAdicionar = c.String(),
                        AnexoFirma = c.String(),
                        myFile13 = c.String(),
                        NitEmpresa = c.String(),
                    })
                .PrimaryKey(t => t.PK_Incidentes_ATAnexos);
            
            CreateTable(
                "dbo.Tbl_IncidentesEL1",
                c => new
                    {
                        PK_Incidentes_EL = c.Int(nullable: false, identity: true),
                        EnfLabCalificadaI = c.String(),
                        FechaInvestigacionI = c.DateTime(nullable: false),
                        HoraInicioI = c.String(),
                        HoraFinI = c.String(),
                        DepartamentoI = c.String(),
                        MunicipioI = c.String(),
                        DireccionI = c.String(),
                        NombresApellidosI = c.String(),
                        ProfesionalI = c.String(),
                        NoLicenciaI = c.String(),
                        FotografiasI = c.String(),
                        VideosI = c.String(),
                        CintasAudioI = c.String(),
                        IlustracionesI = c.String(),
                        DiagramasI = c.String(),
                        OtrosCualesI = c.String(),
                        myFile1 = c.String(),
                        NitEmpresa = c.String(),
                    })
                .PrimaryKey(t => t.PK_Incidentes_EL);
            
            CreateTable(
                "dbo.Tbl_IncidentesEL10",
                c => new
                    {
                        PK_Incidentes_EL10 = c.Int(nullable: false, identity: true),
                        FK_Incidentes_EL10 = c.Int(nullable: false),
                        tempTipoIdentificacionX = c.String(),
                        ResponsableVerficiacionX = c.String(),
                        CargoX = c.String(),
                        NumeroIdentificacionX = c.String(),
                        MedidasIntervencionX = c.String(),
                        ObsevacionesX = c.String(),
                        FechaVerficacionX = c.String(),
                        ObservacionesX = c.String(),
                        myFile11 = c.String(),
                        tempTipoIdentificacionXI = c.String(),
                        ResponsableVerficiacionXI = c.String(),
                        CargoXI = c.String(),
                        NumeroIdentificacionXI = c.String(),
                        MedidasIntervencionXI = c.String(),
                        ObsevacionesARLXI = c.String(),
                        FechaVerficacionXI = c.String(),
                        myFile12 = c.String(),
                        NitEmpresa = c.String(),
                    })
                .PrimaryKey(t => t.PK_Incidentes_EL10);
            
            CreateTable(
                "dbo.Tbl_IncidentesEL3",
                c => new
                    {
                        PK_Incidentes_EL3 = c.Int(nullable: false, identity: true),
                        FK_Incidentes_EL3 = c.Int(nullable: false),
                        PlantaIII = c.String(),
                        MisionIII = c.String(),
                        CooperadorIII = c.String(),
                        EstudianteIII = c.String(),
                        IndependienteIII = c.String(),
                        TipoIdentificacionIII = c.String(),
                        NumIdentificacionIII = c.String(),
                        PrimerApellidoIII = c.String(),
                        SegundoApellidoIII = c.String(),
                        PrimerNombreIII = c.String(),
                        SegundoNombreIII = c.String(),
                        FechaNacimientoIII = c.String(),
                        SexoIII = c.String(),
                        EPSAfiliadoIII = c.String(),
                        AFPAfiliadoIII = c.String(),
                        ARLAfiliadoIII = c.String(),
                        TelefonoIII = c.String(),
                        FaxIII = c.String(),
                        EmailTrabajadorIII = c.String(),
                        DireccionTrabajadorIII = c.String(),
                        ZonaIII = c.String(),
                        CodigoDeptoTrabajadorIII = c.String(),
                        DeptoTrabajadorIII = c.String(),
                        CodigoMncpioTrabajadorIII = c.String(),
                        MncpioTrabajadorIII = c.String(),
                        NitEmpresa = c.String(),
                    })
                .PrimaryKey(t => t.PK_Incidentes_EL3);
            
            CreateTable(
                "dbo.Tbl_IncidentesEL4",
                c => new
                    {
                        PK_Incidentes_EL4 = c.Int(nullable: false, identity: true),
                        FK_Incidentes_EL4 = c.Int(nullable: false),
                        CargoIV = c.String(),
                        AntiguedadCargoAIV = c.String(),
                        AntiguedadCargoMIV = c.String(),
                        TiempoOcupacionAniosIV = c.String(),
                        TiempoOcupacionMesesIV = c.String(),
                        CodOcupacionIV = c.String(),
                        OcupacionHabitualIV = c.String(),
                        MurioTrabajadorIV = c.String(),
                        FechaMuerteIV = c.String(),
                        AreaActualIV = c.String(),
                        NombreCargoIV = c.String(),
                        AntiguedadCargoAnioIV = c.String(),
                        AntiguedadCargoMesesIV = c.String(),
                        DiurnoIV = c.String(),
                        NocturnoIV = c.String(),
                        MixtoIV = c.String(),
                        TurnosIV = c.String(),
                        CondicionesPuestoTrabajoIV = c.String(),
                        FechaIngresoIV = c.String(),
                        TareasCargo1IV = c.String(),
                        DedicacionJL1IV = c.String(),
                        DedicacionJL11IV = c.String(),
                        DedicacionJL12IV = c.String(),
                        RelacionMuyProbable1IV = c.String(),
                        RelacionProbable1IV = c.String(),
                        RelacionPocoProbable1IV = c.String(),
                        DedicacionJL21IV = c.String(),
                        DedicacionJL22IV = c.String(),
                        DedicacionJL23IV = c.String(),
                        RelacionMuyProbable2IV = c.String(),
                        RelacionProbable2IV = c.String(),
                        RelacionPocoProbable2IV = c.String(),
                        TareasCargo3IV = c.String(),
                        DedicacionJL31IV = c.String(),
                        DedicacionJL32IV = c.String(),
                        DedicacionJL33IV = c.String(),
                        RelacionMuyProbable3IV = c.String(),
                        RelacionProbable3IV = c.String(),
                        RelacionPocoProbable3IV = c.String(),
                        CodigoCie5 = c.String(),
                        TareasCargo4IV = c.String(),
                        DedicacionJL41IV = c.String(),
                        DedicacionJL42IV = c.String(),
                        DedicacionJL43IV = c.String(),
                        RelacionMuyProbable4IV = c.String(),
                        RelacionProbable4IV = c.String(),
                        RelacionPocoProbable4IV = c.String(),
                        TareasCargo2IV = c.String(),
                        PreventivasIV = c.String(),
                        ImplementadasIV = c.String(),
                        DescripcionIV = c.String(),
                        NoHabitualesIV = c.String(),
                        CodigoCie1 = c.String(),
                        CodigoCie2 = c.String(),
                        CodigoCie3 = c.String(),
                        CodigoCie4 = c.String(),
                        DiagnosticoIV1 = c.String(),
                        DiagnosticoIV2 = c.String(),
                        DiagnosticoIV3 = c.String(),
                        DiagnosticoIV4 = c.String(),
                        FormacionInformacionIV = c.String(),
                        ProteccionColectivaIV = c.String(),
                        EPPIV = c.String(),
                        DisenoPuestoTrabajoIV = c.String(),
                        tempOrganizacionTrabajoIV = c.String(),
                        ObservacionesIV = c.String(),
                        DiurnoIV2 = c.String(),
                        NocturnoIV2 = c.String(),
                        MixtoIV2 = c.String(),
                        TurnosIV2 = c.String(),
                        FechaOrigenELIV = c.String(),
                        NitEmpresa = c.String(),
                    })
                .PrimaryKey(t => t.PK_Incidentes_EL4);
            
            CreateTable(
                "dbo.Tbl_IncidentesEL5",
                c => new
                    {
                        PK_Incidentes_EL5 = c.Int(nullable: false, identity: true),
                        FK_Incidentes_EL5 = c.Int(nullable: false),
                        FechaOrigenELV = c.String(),
                        OrigenLaboralV = c.String(),
                        NoTrabajadoresV = c.String(),
                        CargosSimilaresV = c.String(),
                        NombresApellidosV1 = c.String(),
                        NombresApellidosV2 = c.String(),
                        NombresApellidosV3 = c.String(),
                        NombresApellidosV4 = c.String(),
                        AnioDiagnosticoV1 = c.String(),
                        AnioDiagnosticoV2 = c.String(),
                        AnioDiagnosticoV3 = c.String(),
                        AnioDiagnosticoV4 = c.String(),
                        NombresApellidosV5 = c.String(),
                        NoTrabajadoresCargos = c.String(),
                        CodigoCieCIEV = c.String(),
                        DiagnosticosCIEV = c.String(),
                        NitEmpresa = c.String(),
                    })
                .PrimaryKey(t => t.PK_Incidentes_EL5);
            
            CreateTable(
                "dbo.Tbl_IncidentesEL6",
                c => new
                    {
                        PK_Incidentes_EL6 = c.Int(nullable: false, identity: true),
                        FK_Incidentes_EL6 = c.Int(nullable: false),
                        PuestoEmpresaVI1 = c.String(),
                        AgentesBiologicosVI1 = c.String(),
                        FrasesVI1 = c.String(),
                        RutinariaVI1 = c.String(),
                        NORutinariaVI1 = c.String(),
                        TiempoExposicionMesesVI1 = c.String(),
                        TiempoExposicionHorasVI1 = c.String(),
                        TLVCorregidoVI1 = c.String(),
                        ConcentracionHalladaVI1 = c.String(),
                        FechaMediacionDiaV1 = c.String(),
                        FechaMediaMesV1 = c.String(),
                        FechaMediaAnioV1 = c.String(),
                        NivelRiesgoV1 = c.String(),
                        ViaEntradaV1 = c.String(),
                        PuestoEmpresaVI2 = c.String(),
                        AgentesBiologicosVI2 = c.String(),
                        FrasesVI2 = c.String(),
                        RutinariaVI2 = c.String(),
                        NORutinariaVI2 = c.String(),
                        TiempoExposicionMesesVI2 = c.String(),
                        TiempoExposicionHorasVI2 = c.String(),
                        TLVCorregidoVI2 = c.String(),
                        ConcentracionHalladaVI2 = c.String(),
                        FechaMediacionDiaV2 = c.String(),
                        FechaMediaMesV2 = c.String(),
                        FechaMediaAnioV2 = c.String(),
                        NivelRiesgoV2 = c.String(),
                        ViaEntradaV2 = c.String(),
                        PuestoEmpresaVI3 = c.String(),
                        AgentesBiologicosVI3 = c.String(),
                        FrasesVI3 = c.String(),
                        RutinariaVI3 = c.String(),
                        NORutinariaVI3 = c.String(),
                        TiempoExposicionMesesVI3 = c.String(),
                        TiempoExposicionHorasVI3 = c.String(),
                        TLVCorregidoVI3 = c.String(),
                        ConcentracionHalladaVI3 = c.String(),
                        FechaMediacionDiaV3 = c.String(),
                        FechaMediaMesV3 = c.String(),
                        FechaMediaAnioV3 = c.String(),
                        NivelRiesgoV3 = c.String(),
                        ViaEntradaV3 = c.String(),
                        PuestoEmpresaVI4 = c.String(),
                        AgentesBiologicosVI4 = c.String(),
                        FrasesVI4 = c.String(),
                        RutinariaVI4 = c.String(),
                        NORutinariaVI4 = c.String(),
                        TiempoExposicionMesesVI4 = c.String(),
                        TiempoExposicionHorasVI4 = c.String(),
                        TLVCorregidoVI4 = c.String(),
                        ConcentracionHalladaVI4 = c.String(),
                        FechaMediacionDiaVI4 = c.String(),
                        FechaMediaMesVI4 = c.String(),
                        FechaMediaAnioVI4 = c.String(),
                        NivelRiesgoVI4 = c.String(),
                        ViaEntradaVI4 = c.String(),
                        OficioEmpresa2V1 = c.String(),
                        AgenteRelBiologico2VI = c.String(),
                        FuenteAgente2VI1 = c.String(),
                        MecanismoTransmicion2VI1 = c.String(),
                        TipoActividadRutinaria2VI1 = c.String(),
                        TipoActividadNoRutinaria2VI1 = c.String(),
                        TiempoExposicionMeses2VI1 = c.String(),
                        TiempoExposicionHoras2VI1 = c.String(),
                        ConcentracionHallada2VI1 = c.String(),
                        NivelRiesgo2VI1 = c.String(),
                        Dia2VI1 = c.String(),
                        Mes2VI1 = c.String(),
                        Anio2VI1 = c.String(),
                        FrecRiesgo2VI1 = c.String(),
                        OficioEmpresa2V2 = c.String(),
                        AgenteRelBiologico2VI2 = c.String(),
                        FuenteAgente2VI2 = c.String(),
                        MecanismoTransmicion2VI2 = c.String(),
                        TipoActividadRutinaria2VI2 = c.String(),
                        TipoActividadNoRutinaria2VI2 = c.String(),
                        TiempoExposicionMeses2VI2 = c.String(),
                        TiempoExposicionHoras2VI2 = c.String(),
                        ConcentracionHallada2VI2 = c.String(),
                        NivelRiesgo2VI2 = c.String(),
                        Dia2VI2 = c.String(),
                        Mes2VI2 = c.String(),
                        Anio2VI2 = c.String(),
                        FrecRiesgo2VI2 = c.String(),
                        OficioEmpresa2V3 = c.String(),
                        AgenteRelBiologico2VI3 = c.String(),
                        FuenteAgente2VI3 = c.String(),
                        MecanismoTransmicion2VI3 = c.String(),
                        TipoActividadRutinaria2VI3 = c.String(),
                        TipoActividadNoRutinaria2VI3 = c.String(),
                        TiempoExposicionMeses2VI3 = c.String(),
                        TiempoExposicionHoras2VI3 = c.String(),
                        ConcentracionHallada2VI3 = c.String(),
                        NivelRiesgo2VI3 = c.String(),
                        Dia2VI3 = c.String(),
                        Mes2VI3 = c.String(),
                        Anio2VI3 = c.String(),
                        FrecRiesgo2VI3 = c.String(),
                        OficioEmpresa2V4 = c.String(),
                        AgenteRelBiologico2VI4 = c.String(),
                        FuenteAgente2VI4 = c.String(),
                        MecanismoTransmicion2VI4 = c.String(),
                        TipoActividadRutinaria2VI4 = c.String(),
                        TipoActividadNoRutinaria2VI4 = c.String(),
                        TiempoExposicionMeses2VI4 = c.String(),
                        TiempoExposicionHoras2VI4 = c.String(),
                        ConcentracionHallada2VI4 = c.String(),
                        NivelRiesgo2VI4 = c.String(),
                        Dia2VI4 = c.String(),
                        Mes2VI4 = c.String(),
                        Anio2VI4 = c.String(),
                        FrecRiesgo2VI4 = c.String(),
                        ExpoAccidentales2VI = c.String(),
                        CargoOficioPuesto3VI = c.String(),
                        Fuentes3VI = c.String(),
                        Meses3VI = c.String(),
                        HorasDia3VI = c.String(),
                        NivelAmbiental3VI = c.String(),
                        FMDia3VI = c.String(),
                        FMMes3VI = c.String(),
                        FMAnio3VI = c.String(),
                        DosisRuido3VI = c.String(),
                        FecMedDia3VI = c.String(),
                        FecMedMes3VI = c.String(),
                        FecMEdAnio3VI = c.String(),
                        ExpSusQuimimcas3VI = c.String(),
                        ExpoAccPrevias3VI = c.String(),
                        CargoOficioPuesto3VI1 = c.String(),
                        Fuentes3VI1 = c.String(),
                        Meses3VI1 = c.String(),
                        HorasDia3VI1 = c.String(),
                        NivelAmbiental3VI1 = c.String(),
                        FMDia3VI1 = c.String(),
                        FMMes3VI1 = c.String(),
                        FMAnio3VI1 = c.String(),
                        DosisRuido3VI1 = c.String(),
                        FecMedDia3VI1 = c.String(),
                        FecMedMes3VI1 = c.String(),
                        FecMEdAnio3VI1 = c.String(),
                        ExpSusQuimimcas3VI1 = c.String(),
                        ExpoAccPrevias3VI1 = c.String(),
                        CargoOficioPuesto3VI2 = c.String(),
                        Fuentes3VI2 = c.String(),
                        Meses3VI2 = c.String(),
                        HorasDia3VI2 = c.String(),
                        NivelAmbiental3VI2 = c.String(),
                        FMDia3VI2 = c.String(),
                        FMMes3VI2 = c.String(),
                        FMAnio3VI2 = c.String(),
                        DosisRuido3VI2 = c.String(),
                        FecMedDia3VI2 = c.String(),
                        FecMedMes3VI2 = c.String(),
                        FecMEdAnio3VI2 = c.String(),
                        ExpSusQuimimcas3VI2 = c.String(),
                        ExpoAccPrevias3VI2 = c.String(),
                        CargoOficioPuesto3VI3 = c.String(),
                        Fuentes3VI3 = c.String(),
                        Meses3VI3 = c.String(),
                        HorasDia3VI3 = c.String(),
                        NivelAmbiental3VI3 = c.String(),
                        FMDia3VI3 = c.String(),
                        FMMes3VI3 = c.String(),
                        FMAnio3VI3 = c.String(),
                        DosisRuido3VI3 = c.String(),
                        FecMedDia3VI3 = c.String(),
                        FecMedMes3VI3 = c.String(),
                        FecMEdAnio3VI3 = c.String(),
                        ExpSusQuimimcas3VI3 = c.String(),
                        ExpoAccPrevias3VI3 = c.String(),
                        CargoOficio4VI1 = c.String(),
                        DescActividad4VI1 = c.String(),
                        Duracion4VI1 = c.String(),
                        FrecActividad4VI1 = c.String(),
                        TipoTrabajoActividad4VI1 = c.String(),
                        WBTG4VI1 = c.String(),
                        TipoExpMeses4VI1 = c.String(),
                        TipoExpHD4VI1 = c.String(),
                        TasaTrabajo4VI1 = c.String(),
                        FechaMedDia4VI1 = c.String(),
                        FechaMedMes4VI1 = c.String(),
                        FechaMedAnio4VI1 = c.String(),
                        CargoOficio4VI2 = c.String(),
                        DescActividad4VI2 = c.String(),
                        Duracion4VI2 = c.String(),
                        FrecActividad4VI2 = c.String(),
                        TipoTrabajoActividad4VI2 = c.String(),
                        WBTG4VI2 = c.String(),
                        TipoExpMeses4VI2 = c.String(),
                        TipoExpHD4VI2 = c.String(),
                        TasaTrabajo4VI2 = c.String(),
                        FechaMedDia4VI2 = c.String(),
                        FechaMedMes4VI2 = c.String(),
                        FechaMedAnio4VI2 = c.String(),
                        CargoOficio4VI3 = c.String(),
                        DescActividad4VI3 = c.String(),
                        Duracion4VI3 = c.String(),
                        FrecActividad4VI3 = c.String(),
                        TipoTrabajoActividad4VI3 = c.String(),
                        WBTG4VI3 = c.String(),
                        TipoExpMeses4VI3 = c.String(),
                        TipoExpHD4VI3 = c.String(),
                        TasaTrabajo4VI3 = c.String(),
                        FechaMedDia4VI3 = c.String(),
                        FechaMedMes4VI3 = c.String(),
                        FechaMedAnio4VI3 = c.String(),
                        CargoOficio4VI4 = c.String(),
                        DescActividad4VI4 = c.String(),
                        Duracion4VI4 = c.String(),
                        FrecActividad4VI4 = c.String(),
                        TipoTrabajoActividad4VI4 = c.String(),
                        WBTG4VI4 = c.String(),
                        TipoExpMeses4VI4 = c.String(),
                        TipoExpHD4VI4 = c.String(),
                        TasaTrabajo4VI4 = c.String(),
                        FechaMedDia4VI4 = c.String(),
                        FechaMedMes4VI4 = c.String(),
                        FechaMedAnio4VI4 = c.String(),
                        BooCauRelPrevVI13 = c.String(),
                        CauRelPrevVI13 = c.String(),
                        BooCauRelPrevVI14 = c.String(),
                        CauRelPrevVI14 = c.String(),
                        BooCauRelPrevVI15 = c.String(),
                        CauRelPrevVI15 = c.String(),
                        NivelRiesgoVI1 = c.String(),
                        ViaEntradaVI1 = c.String(),
                        NivelRiesgoV4 = c.String(),
                        ViaEntradaV4 = c.String(),
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
                        BooTipoVibCE6VI1 = c.String(),
                        BooTipoVibMB6VI1 = c.String(),
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
                        BooExpoRuido6VI1 = c.String(),
                        VibCargoEmpresa6VI2 = c.String(),
                        VibDescFuente6VI2 = c.String(),
                        BooTipoVibCE6VI2 = c.String(),
                        BooTipoVibMB6VI2 = c.String(),
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
                        BooExpoRuido6VI2 = c.String(),
                        VibCargoEmpresa6VI3 = c.String(),
                        VibDescFuente6VI3 = c.String(),
                        BooTipoVibCE6VI3 = c.String(),
                        BooTipoVibMB6VI3 = c.String(),
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
                        BooExpoRuido6VI3 = c.String(),
                        VibCargoEmpresa6VI4 = c.String(),
                        VibDescFuente6VI4 = c.String(),
                        BooTipoVibCE6VI4 = c.String(),
                        BooTipoVibMB6VI4 = c.String(),
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
                        BooExpoRuido6VI4 = c.String(),
                        VibCargoEmpresa6VI5 = c.String(),
                        VibDescFuente6VI5 = c.String(),
                        BooTipoVibCE6VI5 = c.String(),
                        BooTipoVibMB6VI5 = c.String(),
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
                        BooExpoRuido6VI5 = c.String(),
                        VibCargoEmpresa6VI6 = c.String(),
                        VibDescFuente6VI6 = c.String(),
                        BooTipoVibCE6VI6 = c.String(),
                        BooTipoVibMB6VI6 = c.String(),
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
                        BooExpoRuido6VI6 = c.String(),
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
                        BooEsfuerzoBrazosManos1 = c.String(),
                        BooPostPieProlongada = c.String(),
                        BooPostPieSedente = c.String(),
                        BooPosturaIncomodaBrazosManos = c.String(),
                        BooEsfuerzoBrazosManos = c.String(),
                        BooPosturaIncomodaEspalda = c.String(),
                        BooLabRepetitivaColumna = c.String(),
                        BooLabRepetitivaBrazoMuMano = c.String(),
                        BooPeriodoRecuperacionFisica = c.String(),
                        BooEsfuerzoManos = c.String(),
                        BooEsfuerzoCuerpo = c.String(),
                        BooManipulacionCargas = c.String(),
                        DMEResumen = c.String(),
                        BooCauRelPrevVI1 = c.String(),
                        CauRelPrevVI1 = c.String(),
                        BooCauRelPrevVI2 = c.String(),
                        CauRelPrevVI2 = c.String(),
                        BooCauRelPrevVI3 = c.String(),
                        CauRelPrevVI3 = c.String(),
                        BooCauRelPrevVI4 = c.String(),
                        CauRelPrevVI4 = c.String(),
                        BooCauRelPrevVI5 = c.String(),
                        CauRelPrevVI5 = c.String(),
                        BooCauRelPrevVI6 = c.String(),
                        CauRelPrevVI6 = c.String(),
                        BooCauRelPrevVI7 = c.String(),
                        CauRelPrevVI7 = c.String(),
                        BooCauRelPrevVI8 = c.String(),
                        CauRelPrevVI8 = c.String(),
                        BooCauRelPrevVI9 = c.String(),
                        CauRelPrevVI9 = c.String(),
                        BooCauRelPrevVI10 = c.String(),
                        CauRelPrevVI10 = c.String(),
                        BooCauRelPrevVI11 = c.String(),
                        CauRelPrevVI11 = c.String(),
                        BooCauRelPrevVI12 = c.String(),
                        CauRelPrevVI12 = c.String(),
                        OtrosDatosInteresVI = c.String(),
                        CausasEnfermedadLaboralVI = c.String(),
                        NitEmpresa = c.String(),
                    })
                .PrimaryKey(t => t.PK_Incidentes_EL6);
            
            CreateTable(
                "dbo.Tbl_IncidentesEL7",
                c => new
                    {
                        PK_Incidentes_EL7 = c.Int(nullable: false, identity: true),
                        FK_Incidentes_EL7 = c.Int(nullable: false),
                        MedidasPreventivasVII1 = c.String(),
                        ResponsableImplementacionVII1 = c.String(),
                        FechaEjeMesVII1 = c.String(),
                        FechaEjeDiaVII1 = c.String(),
                        MedidasPreventivasVII2 = c.String(),
                        ResponsableImplementacionVII2 = c.String(),
                        FechaEjeMesVII2 = c.String(),
                        FechaEjeDiaVII2 = c.String(),
                        MedidasPreventivasVII3 = c.String(),
                        ResponsableImplementacionVII3 = c.String(),
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
                        NitEmpresa = c.String(),
                    })
                .PrimaryKey(t => t.PK_Incidentes_EL7);
            
            CreateTable(
                "dbo.Tbl_IncidentesEL8",
                c => new
                    {
                        PK_Incidentes_EL8 = c.Int(nullable: false, identity: true),
                        FK_Incidentes_EL8 = c.Int(nullable: false),
                        tempTipoIdentificacionVIII1 = c.String(),
                        JefeInmediatoVIII1 = c.String(),
                        CargoVIII1 = c.String(),
                        NumeroIdentificacionVIII1 = c.String(),
                        tempTipoIdentificacionVIII2 = c.String(),
                        JefeInmediatoVIII2 = c.String(),
                        CargoVIII2 = c.String(),
                        NumeroIdentificacionVIII2 = c.String(),
                        tempTipoIdentificacionVIII3 = c.String(),
                        JefeInmediatoVIII3 = c.String(),
                        CargoVIII3 = c.String(),
                        NumeroIdentificacionVIII3 = c.String(),
                        tempTipoIdentificacionVIII4 = c.String(),
                        JefeInmediatoVIII4 = c.String(),
                        CargoVIII4 = c.String(),
                        NumeroIdentificacionVIII4 = c.String(),
                        tempTipoIdentificacionVIII5 = c.String(),
                        JefeInmediatoVIII5 = c.String(),
                        CargoVIII5 = c.String(),
                        NumeroIdentificacionVIII5 = c.String(),
                        tempTipoIdentificacionVIII6 = c.String(),
                        JefeInmediatoVIII6 = c.String(),
                        CargoVIII6 = c.String(),
                        NumeroIdentificacionVIII6 = c.String(),
                        tempTipoIdentificacionVIII7 = c.String(),
                        EspecialistaOcupacionalVIII = c.String(),
                        LicenciaNumVIII1 = c.String(),
                        LicenciaAnioVIII1 = c.String(),
                        NumeroIdentificacionVIII7 = c.String(),
                        tempTipoIdentificacionVIII8 = c.String(),
                        RepresentanteArlVIII8 = c.String(),
                        LicenciaNumeroVIII8 = c.String(),
                        LicenciaAnioVIII8 = c.String(),
                        NumeroIdentificacionVIII8 = c.String(),
                        EmpresaRepresentaVIII8 = c.String(),
                        NitVIII8 = c.String(),
                        myFile2 = c.String(),
                        myFile3 = c.String(),
                        myFile4 = c.String(),
                        myFile5 = c.String(),
                        myFile6 = c.String(),
                        myFile7 = c.String(),
                        myFile8 = c.String(),
                        myFile9 = c.String(),
                        NitEmpresa = c.String(),
                    })
                .PrimaryKey(t => t.PK_Incidentes_EL8);
            
            CreateTable(
                "dbo.Tbl_IncidentesEL9",
                c => new
                    {
                        PK_Incidentes_EL9 = c.Int(nullable: false, identity: true),
                        FK_Incidentes_EL9 = c.Int(nullable: false),
                        FechaRemisionIX = c.String(),
                        NoFoliosIX = c.String(),
                        tempTipoIdentificacionIX = c.String(),
                        NombreApellidoIX = c.String(),
                        CargoIX = c.String(),
                        NumeroIdentificacionIX = c.String(),
                        FechaRemisionARLIX = c.String(),
                        FecRemisionTerritorialIX = c.String(),
                        DisponibleRemisionARLIX = c.String(),
                        ResponsablesRemisionARLIX = c.String(),
                        CargoARLIX = c.String(),
                        myFile10 = c.String(),
                        NitEmpresa = c.String(),
                    })
                .PrimaryKey(t => t.PK_Incidentes_EL9);
            
            AddColumn("dbo.Tbl_Municipio", "IncidentesAT1_PK_Incidentes_AT", c => c.Int());
            AddColumn("dbo.Tbl_Municipio", "IncidentesAT2_PK_Incidentes_AT2", c => c.Int());
            AddColumn("dbo.Tbl_Municipio", "IncidentesAT2_PK_Incidentes_AT21", c => c.Int());
            AddColumn("dbo.Tbl_Municipio", "IncidentesAT4_PK_Incidentes_AT4", c => c.Int());
            AddColumn("dbo.Tbl_Departamento", "IncidentesAT1_PK_Incidentes_AT", c => c.Int());
            AddColumn("dbo.Tbl_Departamento", "IncidentesAT2_PK_Incidentes_AT2", c => c.Int());
            AddColumn("dbo.Tbl_Departamento", "IncidentesAT2_PK_Incidentes_AT21", c => c.Int());
            AddColumn("dbo.Tbl_Departamento", "IncidentesAT4_PK_Incidentes_AT4", c => c.Int());
            AddColumn("dbo.Tbl_IncidentesEL2", "EmpleadorII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CodActividadII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "ActividadPrincipalII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RazonSocialII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TipoIdentificacionII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "NumIdentificacionII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "DireccionPrincipalII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TelefonoPpalII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FaxII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "DeptoPpalII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "McpioPpalII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "EmailII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "ZonaPpalII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CentroTrabajoPpalII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CentroCostoTelefonoII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CentroCostoFaxII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CodActEconoPpalII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "ActEconoCentroTrabajoII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "DeptoEmpleadorII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "McpioEmpleadorII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "EmailEmpleadorII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "ZonaEmpleadorII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "DeptoCentroTrabajoII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "McpioCentroTrabajoII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "NitEmpresa", c => c.String());
            CreateIndex("dbo.Tbl_Municipio", "IncidentesAT1_PK_Incidentes_AT");
            CreateIndex("dbo.Tbl_Municipio", "IncidentesAT2_PK_Incidentes_AT2");
            CreateIndex("dbo.Tbl_Municipio", "IncidentesAT2_PK_Incidentes_AT21");
            CreateIndex("dbo.Tbl_Municipio", "IncidentesAT4_PK_Incidentes_AT4");
            CreateIndex("dbo.Tbl_Departamento", "IncidentesAT1_PK_Incidentes_AT");
            CreateIndex("dbo.Tbl_Departamento", "IncidentesAT2_PK_Incidentes_AT2");
            CreateIndex("dbo.Tbl_Departamento", "IncidentesAT2_PK_Incidentes_AT21");
            CreateIndex("dbo.Tbl_Departamento", "IncidentesAT4_PK_Incidentes_AT4");
            AddForeignKey("dbo.Tbl_Departamento", "IncidentesAT1_PK_Incidentes_AT", "dbo.Tbl_IncidentesAT1", "PK_Incidentes_AT");
            AddForeignKey("dbo.Tbl_Municipio", "IncidentesAT1_PK_Incidentes_AT", "dbo.Tbl_IncidentesAT1", "PK_Incidentes_AT");
            AddForeignKey("dbo.Tbl_Departamento", "IncidentesAT2_PK_Incidentes_AT2", "dbo.Tbl_IncidentesAT2", "PK_Incidentes_AT2");
            AddForeignKey("dbo.Tbl_Departamento", "IncidentesAT2_PK_Incidentes_AT21", "dbo.Tbl_IncidentesAT2", "PK_Incidentes_AT2");
            AddForeignKey("dbo.Tbl_Municipio", "IncidentesAT2_PK_Incidentes_AT2", "dbo.Tbl_IncidentesAT2", "PK_Incidentes_AT2");
            AddForeignKey("dbo.Tbl_Municipio", "IncidentesAT2_PK_Incidentes_AT21", "dbo.Tbl_IncidentesAT2", "PK_Incidentes_AT2");
            AddForeignKey("dbo.Tbl_Departamento", "IncidentesAT4_PK_Incidentes_AT4", "dbo.Tbl_IncidentesAT4", "PK_Incidentes_AT4");
            AddForeignKey("dbo.Tbl_Municipio", "IncidentesAT4_PK_Incidentes_AT4", "dbo.Tbl_IncidentesAT4", "PK_Incidentes_AT4");
            DropColumn("dbo.Tbl_Municipio", "IncidentesAT_PK_Incidentes_AT");
            DropColumn("dbo.Tbl_Municipio", "IncidentesAT_PK_Incidentes_AT1");
            DropColumn("dbo.Tbl_Municipio", "IncidentesAT_PK_Incidentes_AT2");
            DropColumn("dbo.Tbl_Municipio", "IncidentesAT_PK_Incidentes_AT3");
            DropColumn("dbo.Tbl_Departamento", "IncidentesAT_PK_Incidentes_AT");
            DropColumn("dbo.Tbl_Departamento", "IncidentesAT_PK_Incidentes_AT1");
            DropColumn("dbo.Tbl_Departamento", "IncidentesAT_PK_Incidentes_AT2");
            DropColumn("dbo.Tbl_Departamento", "IncidentesAT_PK_Incidentes_AT3");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadCargoEmpresa5VI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadDescripcionFuente5VI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadDescripcionAct5VI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadCondiciones5VI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadTEDia5VI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadTEMes5VI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadTEAnio5VI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadEvalAmbiental5VI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadFMDia5VI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadFMMes5VI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadFMAnio5VI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadCargoEmpresa5VI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadDescripcionFuente5VI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadDescripcionAct5VI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadCondiciones5VI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadTEDia5VI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadTEMes5VI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadTEAnio5VI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadEvalAmbiental5VI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadFMDia5VI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadFMMes5VI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadFMAnio5VI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadCargoEmpresa5VI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadDescripcionFuente5VI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadDescripcionAct5VI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadCondiciones5VI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadTEDia5VI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadTEMes5VI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadTEAnio5VI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadEvalAmbiental5VI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadFMDia5VI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadFMMes5VI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadFMAnio5VI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadCargoEmpresa5VI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadDescripcionFuente5VI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadDescripcionAct5VI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadCondiciones5VI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadTEDia5VI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadTEMes5VI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadTEAnio5V4");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadEvalAmbiental5VI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadFMDia5VI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadFMMes5VI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "RadFMAnio5VI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "VibCargoEmpresa6VI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "VibDescFuente6VI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooTipoVibCE6VI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooTipoVibMB6VI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "TiempoExpMeses6VI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "TiempoExpHD6VI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "VCE6VI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "VMB6VI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "AceTotal6VI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "EjeDominante6VI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "AceEjeDominante6VI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "Frecuencia6VI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "Aceleracion6VI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaMedDia6VI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaMedMes6VI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaMedAnio6VI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooExpoRuido6VI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "VibCargoEmpresa6VI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "VibDescFuente6VI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooTipoVibCE6VI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooTipoVibMB6VI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "TiempoExpMeses6VI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "TiempoExpHD6VI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "VCE6VI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "VMB6VI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "AceTotal6VI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "EjeDominante6VI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "AceEjeDominante6VI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "Frecuencia6VI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "Aceleracion6VI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaMedDia6VI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaMedMes6VI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaMedAnio6VI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooExpoRuido6VI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "VibCargoEmpresa6VI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "VibDescFuente6VI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooTipoVibCE6VI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooTipoVibMB6VI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "TiempoExpMeses6VI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "TiempoExpHD6VI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "VCE6VI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "VMB6VI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "AceTotal6VI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "EjeDominante6VI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "AceEjeDominante6VI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "Frecuencia6VI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "Aceleracion6VI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaMedDia6VI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaMedMes6VI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaMedAnio6VI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooExpoRuido6VI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "VibCargoEmpresa6VI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "VibDescFuente6VI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooTipoVibCE6VI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooTipoVibMB6VI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "TiempoExpMeses6VI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "TiempoExpHD6VI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "VCE6VI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "VMB6VI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "AceTotal6VI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "EjeDominante6VI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "AceEjeDominante6VI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "Frecuencia6VI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "Aceleracion6VI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaMedDia6VI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaMedMes6VI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaMedAnio6VI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooExpoRuido6VI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "VibCargoEmpresa6VI5");
            DropColumn("dbo.Tbl_IncidentesEL2", "VibDescFuente6VI5");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooTipoVibCE6VI5");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooTipoVibMB6VI5");
            DropColumn("dbo.Tbl_IncidentesEL2", "TiempoExpMeses6VI5");
            DropColumn("dbo.Tbl_IncidentesEL2", "TiempoExpHD6VI5");
            DropColumn("dbo.Tbl_IncidentesEL2", "VCE6VI5");
            DropColumn("dbo.Tbl_IncidentesEL2", "VMB6VI5");
            DropColumn("dbo.Tbl_IncidentesEL2", "AceTotal6VI5");
            DropColumn("dbo.Tbl_IncidentesEL2", "EjeDominante6VI5");
            DropColumn("dbo.Tbl_IncidentesEL2", "AceEjeDominante6VI5");
            DropColumn("dbo.Tbl_IncidentesEL2", "Frecuencia6VI5");
            DropColumn("dbo.Tbl_IncidentesEL2", "Aceleracion6VI5");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaMedDia6VI5");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaMedMes6VI5");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaMedAnio6VI5");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooExpoRuido6VI5");
            DropColumn("dbo.Tbl_IncidentesEL2", "VibCargoEmpresa6VI6");
            DropColumn("dbo.Tbl_IncidentesEL2", "VibDescFuente6VI6");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooTipoVibCE6VI6");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooTipoVibMB6VI6");
            DropColumn("dbo.Tbl_IncidentesEL2", "TiempoExpMeses6VI6");
            DropColumn("dbo.Tbl_IncidentesEL2", "TiempoExpHD6VI6");
            DropColumn("dbo.Tbl_IncidentesEL2", "VCE6VI6");
            DropColumn("dbo.Tbl_IncidentesEL2", "VMB6VI6");
            DropColumn("dbo.Tbl_IncidentesEL2", "AceTotal6VI6");
            DropColumn("dbo.Tbl_IncidentesEL2", "EjeDominante6VI6");
            DropColumn("dbo.Tbl_IncidentesEL2", "AceEjeDominante6VI6");
            DropColumn("dbo.Tbl_IncidentesEL2", "Frecuencia6VI6");
            DropColumn("dbo.Tbl_IncidentesEL2", "Aceleracion6VI6");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaMedDia6VI6");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaMedMes6VI6");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaMedAnio6VI6");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooExpoRuido6VI6");
            DropColumn("dbo.Tbl_IncidentesEL2", "DescEventoInv6VI");
            DropColumn("dbo.Tbl_IncidentesEL2", "FrecPresAltoVI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "FrecPresMedioVI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "FrecPresBajoVI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "TiempoExpAltoVI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "TiempoExpMedioVI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "TiempoExpBajoVI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "IntensidadAltoVI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "IntensidadMedioVI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "IntensidadBajoVI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "VarPsicoObservacionesVI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "FrecPresAltoVI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "FrecPresMedioVI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "FrecPresBajoVI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "TiempoExpAltoVI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "TiempoExpMedioVI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "TiempoExpBajoVI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "IntensidadAltoVI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "IntensidadMedioVI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "IntensidadBajoVI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "VarPsicoObservacionesVI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "FrecPresAltoVI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "FrecPresMedioVI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "FrecPresBajoVI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "TiempoExpAltoVI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "TiempoExpMedioVI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "TiempoExpBajoVI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "IntensidadAltoVI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "IntensidadMedioVI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "IntensidadBajoVI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "VarPsicoObservacionesVI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "FrecPresAltoVI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "FrecPresMedioVI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "FrecPresBajoVI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "TiempoExpAltoVI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "TiempoExpMedioVI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "TiempoExpBajoV4");
            DropColumn("dbo.Tbl_IncidentesEL2", "IntensidadAltoVI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "IntensidadMedioVI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "IntensidadBajoVI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "VarPsicoObservacionesVI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "IntensidadAltaVI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "IntensidadMediaVI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "IntensidadBajaVI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "IntensidadObservVI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "IntensidadAltaVI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "IntensidadMediaVI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "IntensidadBajaVI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "IntensidadObservVI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "NivelRiesgoLabVI");
            DropColumn("dbo.Tbl_IncidentesEL2", "NivelRiesgoExtralabVI");
            DropColumn("dbo.Tbl_IncidentesEL2", "NivelRiesgoIndiviVI");
            DropColumn("dbo.Tbl_IncidentesEL2", "NivelEstresVI");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooPostPieProlongada");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooPostPieSedente");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooPosturaIncomodaBrazosManos");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooEsfuerzoBrazosManos");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooPosturaIncomodaEspalda");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooLabRepetitivaColumna");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooLabRepetitivaBrazoMuMano");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooPeriodoRecuperacionFisica");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooEsfuerzoManos");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooEsfuerzoCuerpo");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooManipulacionCargas");
            DropColumn("dbo.Tbl_IncidentesEL2", "DMEResumen");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooCauRelPrevVI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "CauRelPrevVI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooCauRelPrevVI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "CauRelPrevVI2");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooCauRelPrevVI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "CauRelPrevVI3");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooCauRelPrevVI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "CauRelPrevVI4");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooCauRelPrevVI5");
            DropColumn("dbo.Tbl_IncidentesEL2", "CauRelPrevVI5");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooCauRelPrevVI6");
            DropColumn("dbo.Tbl_IncidentesEL2", "CauRelPrevVI6");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooCauRelPrevVI7");
            DropColumn("dbo.Tbl_IncidentesEL2", "CauRelPrevVI7");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooCauRelPrevVI8");
            DropColumn("dbo.Tbl_IncidentesEL2", "CauRelPrevVI8");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooCauRelPrevVI9");
            DropColumn("dbo.Tbl_IncidentesEL2", "CauRelPrevVI9");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooCauRelPrevVI10");
            DropColumn("dbo.Tbl_IncidentesEL2", "CauRelPrevVI10");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooCauRelPrevVI11");
            DropColumn("dbo.Tbl_IncidentesEL2", "CauRelPrevVI11");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooCauRelPrevVI12");
            DropColumn("dbo.Tbl_IncidentesEL2", "CauRelPrevVI12");
            DropColumn("dbo.Tbl_IncidentesEL2", "OtrosDatosInteresVI");
            DropColumn("dbo.Tbl_IncidentesEL2", "CausasEnfermedadLaboralVI");
            DropColumn("dbo.Tbl_IncidentesEL2", "MedidasPreventivasVII1");
            DropColumn("dbo.Tbl_IncidentesEL2", "ResponsableImplementacionVII1");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaEjeMesVII1");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaEjeDiaVII1");
            DropColumn("dbo.Tbl_IncidentesEL2", "MedidasPreventivasVII2");
            DropColumn("dbo.Tbl_IncidentesEL2", "ResponsableImplementacionVII2");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaEjeMesVII2");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaEjeDiaVII2");
            DropColumn("dbo.Tbl_IncidentesEL2", "MedidasPreventivasVII3");
            DropColumn("dbo.Tbl_IncidentesEL2", "ResponsableImplementacionVII3");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaEjeMesVII3");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaEjeDiaVII3");
            DropColumn("dbo.Tbl_IncidentesEL2", "MedidasPreventivasVII4");
            DropColumn("dbo.Tbl_IncidentesEL2", "ResponsableImplementacionVII4");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaEjeMesVII4");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaEjeDiaVII4");
            DropColumn("dbo.Tbl_IncidentesEL2", "MedidasPreventivasVII5");
            DropColumn("dbo.Tbl_IncidentesEL2", "ResponsableImplementacionVII5");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaEjeMesVII5");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaEjeDiaVII5");
            DropColumn("dbo.Tbl_IncidentesEL2", "MedidasPreventivasVII6");
            DropColumn("dbo.Tbl_IncidentesEL2", "ResponsableImplementacionVII6");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaEjeMesVII6");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaEjeDiaVII6");
            DropColumn("dbo.Tbl_IncidentesEL2", "MedidasPreventivasVII7");
            DropColumn("dbo.Tbl_IncidentesEL2", "ResponsableImplementacionVII7");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaEjeMesVII7");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaEjeDiaVII7");
            DropColumn("dbo.Tbl_IncidentesEL2", "MedidasPreventivasVII8");
            DropColumn("dbo.Tbl_IncidentesEL2", "ResponsableImplementacionVII8");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaEjeMesVII8");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaEjeDiaVII8");
            DropColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionVIII1");
            DropColumn("dbo.Tbl_IncidentesEL2", "JefeInmediatoVIII1");
            DropColumn("dbo.Tbl_IncidentesEL2", "CargoVIII1");
            DropColumn("dbo.Tbl_IncidentesEL2", "NumeroIdentificacionVIII1");
            DropColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionVIII2");
            DropColumn("dbo.Tbl_IncidentesEL2", "JefeInmediatoVIII2");
            DropColumn("dbo.Tbl_IncidentesEL2", "CargoVIII2");
            DropColumn("dbo.Tbl_IncidentesEL2", "NumeroIdentificacionVIII2");
            DropColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionVIII3");
            DropColumn("dbo.Tbl_IncidentesEL2", "JefeInmediatoVIII3");
            DropColumn("dbo.Tbl_IncidentesEL2", "CargoVIII3");
            DropColumn("dbo.Tbl_IncidentesEL2", "NumeroIdentificacionVIII3");
            DropColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionVIII4");
            DropColumn("dbo.Tbl_IncidentesEL2", "JefeInmediatoVIII4");
            DropColumn("dbo.Tbl_IncidentesEL2", "CargoVIII4");
            DropColumn("dbo.Tbl_IncidentesEL2", "NumeroIdentificacionVIII4");
            DropColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionVIII5");
            DropColumn("dbo.Tbl_IncidentesEL2", "JefeInmediatoVIII5");
            DropColumn("dbo.Tbl_IncidentesEL2", "CargoVIII5");
            DropColumn("dbo.Tbl_IncidentesEL2", "NumeroIdentificacionVIII5");
            DropColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionVIII6");
            DropColumn("dbo.Tbl_IncidentesEL2", "JefeInmediatoVIII6");
            DropColumn("dbo.Tbl_IncidentesEL2", "CargoVIII6");
            DropColumn("dbo.Tbl_IncidentesEL2", "NumeroIdentificacionVIII6");
            DropColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionVIII7");
            DropColumn("dbo.Tbl_IncidentesEL2", "EspecialistaOcupacionalVIII");
            DropColumn("dbo.Tbl_IncidentesEL2", "LicenciaNumVIII1");
            DropColumn("dbo.Tbl_IncidentesEL2", "LicenciaAnioVIII1");
            DropColumn("dbo.Tbl_IncidentesEL2", "NumeroIdentificacionVIII7");
            DropColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionVIII8");
            DropColumn("dbo.Tbl_IncidentesEL2", "RepresentanteArlVIII8");
            DropColumn("dbo.Tbl_IncidentesEL2", "LicenciaNumeroVIII8");
            DropColumn("dbo.Tbl_IncidentesEL2", "LicenciaAnioVIII8");
            DropColumn("dbo.Tbl_IncidentesEL2", "NumeroIdentificacionVIII8");
            DropColumn("dbo.Tbl_IncidentesEL2", "EmpresaRepresentaVIII8");
            DropColumn("dbo.Tbl_IncidentesEL2", "NitVIII8");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaRemisionIX");
            DropColumn("dbo.Tbl_IncidentesEL2", "NoFoliosIX");
            DropColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionIX");
            DropColumn("dbo.Tbl_IncidentesEL2", "NombreApellidoIX");
            DropColumn("dbo.Tbl_IncidentesEL2", "CargoIX");
            DropColumn("dbo.Tbl_IncidentesEL2", "NumeroIdentificacionIX");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaRemisionARLIX");
            DropColumn("dbo.Tbl_IncidentesEL2", "FecRemisionTerritorialIX");
            DropColumn("dbo.Tbl_IncidentesEL2", "DisponibleRemisionARLIX");
            DropColumn("dbo.Tbl_IncidentesEL2", "ResponsablesRemisionARLIX");
            DropColumn("dbo.Tbl_IncidentesEL2", "CargoARLIX");
            DropColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionX");
            DropColumn("dbo.Tbl_IncidentesEL2", "ResponsableVerficiacionX");
            DropColumn("dbo.Tbl_IncidentesEL2", "CargoX");
            DropColumn("dbo.Tbl_IncidentesEL2", "NumeroIdentificacionX");
            DropColumn("dbo.Tbl_IncidentesEL2", "MedidasIntervencionX");
            DropColumn("dbo.Tbl_IncidentesEL2", "ObsevacionesX");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaVerficacionX");
            DropColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionXI");
            DropColumn("dbo.Tbl_IncidentesEL2", "ResponsableVerficiacionXI");
            DropColumn("dbo.Tbl_IncidentesEL2", "CargoXI");
            DropColumn("dbo.Tbl_IncidentesEL2", "NumeroIdentificacionXI");
            DropColumn("dbo.Tbl_IncidentesEL2", "MedidasIntervencionXI");
            DropColumn("dbo.Tbl_IncidentesEL2", "ObsevacionesARLXI");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaVerficacionXI");
            DropColumn("dbo.Tbl_IncidentesEL2", "ObservacionesX");
            DropColumn("dbo.Tbl_IncidentesEL2", "CodigoDeptoTrabajadorIII");
            DropColumn("dbo.Tbl_IncidentesEL2", "DeptoTrabajadorIII");
            DropColumn("dbo.Tbl_IncidentesEL2", "CodigoMncpioTrabajadorIII");
            DropColumn("dbo.Tbl_IncidentesEL2", "MncpioTrabajadorIII");
            DropColumn("dbo.Tbl_IncidentesEL2", "ObservacionesIV");
            DropColumn("dbo.Tbl_IncidentesEL2", "DiurnoIV2");
            DropColumn("dbo.Tbl_IncidentesEL2", "NocturnoIV2");
            DropColumn("dbo.Tbl_IncidentesEL2", "MixtoIV2");
            DropColumn("dbo.Tbl_IncidentesEL2", "TurnosIV2");
            DropColumn("dbo.Tbl_IncidentesEL2", "NombresApellidosV5");
            DropColumn("dbo.Tbl_IncidentesEL2", "NoTrabajadoresCargos");
            DropColumn("dbo.Tbl_IncidentesEL2", "CodigoCieCIEV");
            DropColumn("dbo.Tbl_IncidentesEL2", "DiagnosticosCIEV");
            DropTable("dbo.Tbl_IncidentesAT");
            DropTable("dbo.Tbl_IncidentesEL");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tbl_IncidentesEL",
                c => new
                    {
                        PK_Incidentes_EL = c.Int(nullable: false, identity: true),
                        EnfLabCalificadaI = c.String(),
                        FechaInvestigacionI = c.DateTime(nullable: false),
                        HoraInicioI = c.String(),
                        HoraFinI = c.String(),
                        DepartamentoI = c.String(),
                        MunicipioI = c.String(),
                        DireccionI = c.String(),
                        NombresApellidosI = c.String(),
                        ProfesionalI = c.String(),
                        NoLicenciaI = c.String(),
                        FotografiasI = c.String(),
                        VideosI = c.String(),
                        CintasAudioI = c.String(),
                        IlustracionesI = c.String(),
                        DiagramasI = c.String(),
                        OtrosCualesI = c.String(),
                        EmpleadorII = c.String(),
                        CodActividadII = c.String(),
                        ActividadPrincipalII = c.String(),
                        RazonSocialII = c.String(),
                        TipoIdentificacionII = c.String(),
                        NumIdentificacionII = c.String(),
                        DireccionPrincipalII = c.String(),
                        TelefonoPpalII = c.String(),
                        FaxII = c.String(),
                        DeptoPpalII = c.String(),
                        McpioPpalII = c.String(),
                        EmailII = c.String(),
                        ZonaPpalII = c.String(),
                        CentroTrabajoPpalII = c.String(),
                        CentroCostoTelefonoII = c.String(),
                        CentroCostoFaxII = c.String(),
                        CodActEconoPpalII = c.String(),
                        ActEconoCentroTrabajoII = c.String(),
                        DeptoEmpleadorII = c.String(),
                        McpioEmpleadorII = c.String(),
                        EmailEmpleadorII = c.String(),
                        ZonaEmpleadorII = c.String(),
                        DeptoCentroTrabajoII = c.String(),
                        McpioCentroTrabajoII = c.String(),
                        PlantaIII = c.String(),
                        MisionIII = c.String(),
                        CooperadorIII = c.String(),
                        EstudianteIII = c.String(),
                        IndependienteIII = c.String(),
                        TipoIdentificacionIII = c.String(),
                        NumIdentificacionIII = c.String(),
                        PrimerApellidoIII = c.String(),
                        SegundoApellidoIII = c.String(),
                        PrimerNombreIII = c.String(),
                        SegundoNombreIII = c.String(),
                        FechaNacimientoIII = c.String(),
                        SexoIII = c.String(),
                        EPSAfiliadoIII = c.String(),
                        AFPAfiliadoIII = c.String(),
                        ARLAfiliadoIII = c.String(),
                        TelefonoIII = c.String(),
                        FaxIII = c.String(),
                        EmailTrabajadorIII = c.String(),
                        DireccionTrabajadorIII = c.String(),
                        ZonaIII = c.String(),
                        CargoIV = c.String(),
                        AntiguedadCargoAIV = c.String(),
                        AntiguedadCargoMIV = c.String(),
                        TiempoOcupacionAniosIV = c.String(),
                        TiempoOcupacionMesesIV = c.String(),
                        CodOcupacionIV = c.String(),
                        OcupacionHabitualIV = c.String(),
                        MurioTrabajadorIV = c.String(),
                        FechaMuerteIV = c.String(),
                        AreaActualIV = c.String(),
                        NombreCargoIV = c.String(),
                        AntiguedadCargoAnioIV = c.String(),
                        AntiguedadCargoMesesIV = c.String(),
                        DiurnoIV = c.String(),
                        NocturnoIV = c.String(),
                        MixtoIV = c.String(),
                        TurnosIV = c.String(),
                        CondicionesPuestoTrabajoIV = c.String(),
                        FechaIngresoIV = c.String(),
                        TareasCargo1IV = c.String(),
                        DedicacionJL1IV = c.String(),
                        DedicacionJL11IV = c.String(),
                        DedicacionJL12IV = c.String(),
                        RelacionMuyProbable1IV = c.String(),
                        RelacionProbable1IV = c.String(),
                        RelacionPocoProbable1IV = c.String(),
                        DedicacionJL21IV = c.String(),
                        DedicacionJL22IV = c.String(),
                        DedicacionJL23IV = c.String(),
                        RelacionMuyProbable2IV = c.String(),
                        RelacionProbable2IV = c.String(),
                        RelacionPocoProbable2IV = c.String(),
                        TareasCargo3IV = c.String(),
                        DedicacionJL31IV = c.String(),
                        DedicacionJL32IV = c.String(),
                        DedicacionJL33IV = c.String(),
                        RelacionMuyProbable3IV = c.String(),
                        RelacionProbable3IV = c.String(),
                        RelacionPocoProbable3IV = c.String(),
                        CodigoCie5 = c.String(),
                        TareasCargo4IV = c.String(),
                        DedicacionJL41IV = c.String(),
                        DedicacionJL42IV = c.String(),
                        DedicacionJL43IV = c.String(),
                        RelacionMuyProbable4IV = c.String(),
                        RelacionProbable4IV = c.String(),
                        RelacionPocoProbable4IV = c.String(),
                        TareasCargo2IV = c.String(),
                        PreventivasIV = c.String(),
                        ImplementadasIV = c.String(),
                        DescripcionIV = c.String(),
                        NoHabitualesIV = c.String(),
                        CodigoCie1 = c.String(),
                        CodigoCie2 = c.String(),
                        CodigoCie3 = c.String(),
                        CodigoCie4 = c.String(),
                        DiagnosticoIV1 = c.String(),
                        DiagnosticoIV2 = c.String(),
                        DiagnosticoIV3 = c.String(),
                        DiagnosticoIV4 = c.String(),
                        FechaOrigenELV = c.String(),
                        OrigenLaboralIV = c.String(),
                        NoTrabajadoresV = c.String(),
                        CargosSimilaresV = c.String(),
                        NombresApellidosV1 = c.String(),
                        NombresApellidosV2 = c.String(),
                        NombresApellidosV3 = c.String(),
                        NombresApellidosV4 = c.String(),
                        AnioDiagnosticoV1 = c.String(),
                        AnioDiagnosticoV2 = c.String(),
                        AnioDiagnosticoV3 = c.String(),
                        AnioDiagnosticoV4 = c.String(),
                        PuestoEmpresaVI1 = c.String(),
                        AgentesBiologicosVI1 = c.String(),
                        FrasesVI1 = c.String(),
                        RutinariaVI1 = c.String(),
                        NORutinariaVI1 = c.String(),
                        TiempoExposicionMesesVI1 = c.String(),
                        TiempoExposicionHorasVI1 = c.String(),
                        TLVCorregidoVI1 = c.String(),
                        ConcentracionHalladaVI1 = c.String(),
                        FechaMediacionDiaV1 = c.String(),
                        FechaMediaMesV1 = c.String(),
                        FechaMediaAnioV1 = c.String(),
                        NivelRiesgoV1 = c.String(),
                        ViaEntradaV1 = c.String(),
                        PuestoEmpresaVI2 = c.String(),
                        AgentesBiologicosVI2 = c.String(),
                        FrasesVI2 = c.String(),
                        RutinariaVI2 = c.String(),
                        NORutinariaVI2 = c.String(),
                        TiempoExposicionMesesVI2 = c.String(),
                        TiempoExposicionHorasVI2 = c.String(),
                        TLVCorregidoVI2 = c.String(),
                        ConcentracionHalladaVI2 = c.String(),
                        FechaMediacionDiaV2 = c.String(),
                        FechaMediaMesV2 = c.String(),
                        FechaMediaAnioV2 = c.String(),
                        NivelRiesgoV2 = c.String(),
                        ViaEntradaV2 = c.String(),
                        PuestoEmpresaVI3 = c.String(),
                        AgentesBiologicosVI3 = c.String(),
                        FrasesVI3 = c.String(),
                        RutinariaVI3 = c.String(),
                        NORutinariaVI3 = c.String(),
                        TiempoExposicionMesesVI3 = c.String(),
                        TiempoExposicionHorasVI3 = c.String(),
                        TLVCorregidoVI3 = c.String(),
                        ConcentracionHalladaVI3 = c.String(),
                        FechaMediacionDiaV3 = c.String(),
                        FechaMediaMesV3 = c.String(),
                        FechaMediaAnioV3 = c.String(),
                        NivelRiesgoV3 = c.String(),
                        ViaEntradaV3 = c.String(),
                        PuestoEmpresaVI4 = c.String(),
                        AgentesBiologicosVI4 = c.String(),
                        FrasesVI4 = c.String(),
                        RutinariaVI4 = c.String(),
                        NORutinariaVI4 = c.String(),
                        TiempoExposicionMesesVI4 = c.String(),
                        TiempoExposicionHorasVI4 = c.String(),
                        TLVCorregidoVI4 = c.String(),
                        ConcentracionHalladaVI4 = c.String(),
                        FechaMediacionDiaVI4 = c.String(),
                        FechaMediaMesVI4 = c.String(),
                        FechaMediaAnioVI4 = c.String(),
                        NivelRiesgoVI4 = c.String(),
                        ViaEntradaVI4 = c.String(),
                        OficioEmpresa2V1 = c.String(),
                        AgenteRelBiologico2VI = c.String(),
                        FuenteAgente2VI1 = c.String(),
                        MecanismoTransmicion2VI1 = c.String(),
                        TipoActividadRutinaria2VI1 = c.String(),
                        TipoActividadNoRutinaria2VI1 = c.String(),
                        TiempoExposicionMeses2VI1 = c.String(),
                        TiempoExposicionHoras2VI1 = c.String(),
                        ConcentracionHallada2VI1 = c.String(),
                        NivelRiesgo2VI1 = c.String(),
                        Dia2VI1 = c.String(),
                        Mes2VI1 = c.String(),
                        Anio2VI1 = c.String(),
                        FrecRiesgo2VI1 = c.String(),
                        OficioEmpresa2V2 = c.String(),
                        AgenteRelBiologico2VI2 = c.String(),
                        FuenteAgente2VI2 = c.String(),
                        MecanismoTransmicion2VI2 = c.String(),
                        TipoActividadRutinaria2VI2 = c.String(),
                        TipoActividadNoRutinaria2VI2 = c.String(),
                        TiempoExposicionMeses2VI2 = c.String(),
                        TiempoExposicionHoras2VI2 = c.String(),
                        ConcentracionHallada2VI2 = c.String(),
                        NivelRiesgo2VI2 = c.String(),
                        Dia2VI2 = c.String(),
                        Mes2VI2 = c.String(),
                        Anio2VI2 = c.String(),
                        FrecRiesgo2VI2 = c.String(),
                        OficioEmpresa2V3 = c.String(),
                        AgenteRelBiologico2VI3 = c.String(),
                        FuenteAgente2VI3 = c.String(),
                        MecanismoTransmicion2VI3 = c.String(),
                        TipoActividadRutinaria2VI3 = c.String(),
                        TipoActividadNoRutinaria2VI3 = c.String(),
                        TiempoExposicionMeses2VI3 = c.String(),
                        TiempoExposicionHoras2VI3 = c.String(),
                        ConcentracionHallada2VI3 = c.String(),
                        NivelRiesgo2VI3 = c.String(),
                        Dia2VI3 = c.String(),
                        Mes2VI3 = c.String(),
                        Anio2VI3 = c.String(),
                        FrecRiesgo2VI3 = c.String(),
                        OficioEmpresa2V4 = c.String(),
                        AgenteRelBiologico2VI4 = c.String(),
                        FuenteAgente2VI4 = c.String(),
                        MecanismoTransmicion2VI4 = c.String(),
                        TipoActividadRutinaria2VI4 = c.String(),
                        TipoActividadNoRutinaria2VI4 = c.String(),
                        TiempoExposicionMeses2VI4 = c.String(),
                        TiempoExposicionHoras2VI4 = c.String(),
                        ConcentracionHallada2VI4 = c.String(),
                        NivelRiesgo2VI4 = c.String(),
                        Dia2VI4 = c.String(),
                        Mes2VI4 = c.String(),
                        Anio2VI4 = c.String(),
                        FrecRiesgo2VI4 = c.String(),
                        ExpoAccidentales2VI = c.String(),
                        CargoOficioPuesto3VI = c.String(),
                        Fuentes3VI = c.String(),
                        Meses3VI = c.String(),
                        HorasDia3VI = c.String(),
                        NivelAmbiental3VI = c.String(),
                        FMDia3VI = c.String(),
                        FMMes3VI = c.String(),
                        FMAnio3VI = c.String(),
                        DosisRuido3VI = c.String(),
                        FecMedDia3VI = c.String(),
                        FecMedMes3VI = c.String(),
                        FecMEdAnio3VI = c.String(),
                        ExpSusQuimimcas3VI = c.String(),
                        ExpoAccPrevias3VI = c.String(),
                        CargoOficioPuesto3VI1 = c.String(),
                        Fuentes3VI1 = c.String(),
                        Meses3VI1 = c.String(),
                        HorasDia3VI1 = c.String(),
                        NivelAmbiental3VI1 = c.String(),
                        FMDia3VI1 = c.String(),
                        FMMes3VI1 = c.String(),
                        FMAnio3VI1 = c.String(),
                        DosisRuido3VI1 = c.String(),
                        FecMedDia3VI1 = c.String(),
                        FecMedMes3VI1 = c.String(),
                        FecMEdAnio3VI1 = c.String(),
                        ExpSusQuimimcas3VI1 = c.String(),
                        ExpoAccPrevias3VI1 = c.String(),
                        CargoOficioPuesto3VI2 = c.String(),
                        Fuentes3VI2 = c.String(),
                        Meses3VI2 = c.String(),
                        HorasDia3VI2 = c.String(),
                        NivelAmbiental3VI2 = c.String(),
                        FMDia3VI2 = c.String(),
                        FMMes3VI2 = c.String(),
                        FMAnio3VI2 = c.String(),
                        DosisRuido3VI2 = c.String(),
                        FecMedDia3VI2 = c.String(),
                        FecMedMes3VI2 = c.String(),
                        FecMEdAnio3VI2 = c.String(),
                        ExpSusQuimimcas3VI2 = c.String(),
                        ExpoAccPrevias3VI2 = c.String(),
                        CargoOficioPuesto3VI3 = c.String(),
                        Fuentes3VI3 = c.String(),
                        Meses3VI3 = c.String(),
                        HorasDia3VI3 = c.String(),
                        NivelAmbiental3VI3 = c.String(),
                        FMDia3VI3 = c.String(),
                        FMMes3VI3 = c.String(),
                        FMAnio3VI3 = c.String(),
                        DosisRuido3VI3 = c.String(),
                        FecMedDia3VI3 = c.String(),
                        FecMedMes3VI3 = c.String(),
                        FecMEdAnio3VI3 = c.String(),
                        ExpSusQuimimcas3VI3 = c.String(),
                        ExpoAccPrevias3VI3 = c.String(),
                        CargoOficio4VI1 = c.String(),
                        DescActividad4VI1 = c.String(),
                        Duracion4VI1 = c.String(),
                        FrecActividad4VI1 = c.String(),
                        TipoTrabajoActividad4VI1 = c.String(),
                        WBTG4VI1 = c.String(),
                        TipoExpMeses4VI1 = c.String(),
                        TipoExpHD4VI1 = c.String(),
                        TasaTrabajo4VI1 = c.String(),
                        FechaMedDia4VI1 = c.String(),
                        FechaMedMes4VI1 = c.String(),
                        FechaMedAnio4VI1 = c.String(),
                        CargoOficio4VI2 = c.String(),
                        DescActividad4VI2 = c.String(),
                        Duracion4VI2 = c.String(),
                        FrecActividad4VI2 = c.String(),
                        TipoTrabajoActividad4VI2 = c.String(),
                        WBTG4VI2 = c.String(),
                        TipoExpMeses4VI2 = c.String(),
                        TipoExpHD4VI2 = c.String(),
                        TasaTrabajo4VI2 = c.String(),
                        FechaMedDia4VI2 = c.String(),
                        FechaMedMes4VI2 = c.String(),
                        FechaMedAnio4VI2 = c.String(),
                        CargoOficio4VI3 = c.String(),
                        DescActividad4VI3 = c.String(),
                        Duracion4VI3 = c.String(),
                        FrecActividad4VI3 = c.String(),
                        TipoTrabajoActividad4VI3 = c.String(),
                        WBTG4VI3 = c.String(),
                        TipoExpMeses4VI3 = c.String(),
                        TipoExpHD4VI3 = c.String(),
                        TasaTrabajo4VI3 = c.String(),
                        FechaMedDia4VI3 = c.String(),
                        FechaMedMes4VI3 = c.String(),
                        FechaMedAnio4VI3 = c.String(),
                        CargoOficio4VI4 = c.String(),
                        DescActividad4VI4 = c.String(),
                        Duracion4VI4 = c.String(),
                        FrecActividad4VI4 = c.String(),
                        TipoTrabajoActividad4VI4 = c.String(),
                        WBTG4VI4 = c.String(),
                        TipoExpMeses4VI4 = c.String(),
                        TipoExpHD4VI4 = c.String(),
                        TasaTrabajo4VI4 = c.String(),
                        FechaMedDia4VI4 = c.String(),
                        FechaMedMes4VI4 = c.String(),
                        FechaMedAnio4VI4 = c.String(),
                        BooEsfuerzoBrazosManos1 = c.String(),
                        BooCauRelPrevVI13 = c.String(),
                        CauRelPrevVI13 = c.String(),
                        BooCauRelPrevVI14 = c.String(),
                        CauRelPrevVI14 = c.String(),
                        BooCauRelPrevVI15 = c.String(),
                        CauRelPrevVI15 = c.String(),
                        myFile1 = c.String(),
                        myFile2 = c.String(),
                        myFile3 = c.String(),
                        myFile4 = c.String(),
                        myFile5 = c.String(),
                        myFile6 = c.String(),
                        myFile7 = c.String(),
                        myFile8 = c.String(),
                        myFile9 = c.String(),
                        myFile10 = c.String(),
                        myFile11 = c.String(),
                        myFile12 = c.String(),
                        NivelRiesgoVI1 = c.String(),
                        ViaEntradaVI1 = c.String(),
                        NivelRiesgoV4 = c.String(),
                        ViaEntradaV4 = c.String(),
                        FormacionInformacionIV = c.String(),
                        ProteccionColectivaIV = c.String(),
                        EPPIV = c.String(),
                        DisenoPuestoTrabajoIV = c.String(),
                        tempOrganizacionTrabajoIV = c.String(),
                        NitEmpresa = c.String(),
                    })
                .PrimaryKey(t => t.PK_Incidentes_EL);
            
            CreateTable(
                "dbo.Tbl_IncidentesAT",
                c => new
                    {
                        PK_Incidentes_AT = c.Int(nullable: false, identity: true),
                        boIncidente = c.String(),
                        ExplosivosUnidadMedidaV2 = c.String(),
                        GasesUnidadVI = c.String(),
                        boIncidente1 = c.String(),
                        boAccidenteTrabajo = c.String(),
                        boLeve = c.String(),
                        boGrave = c.String(),
                        boMortal = c.String(),
                        FechaInvestigacionI = c.DateTime(nullable: false),
                        pk_DepartamentoI = c.Int(nullable: false),
                        pk_MunicipioI = c.Int(nullable: false),
                        DireccionI = c.String(),
                        HoraInicialI = c.String(),
                        HoraFinalI = c.String(),
                        ResponsablesI = c.String(),
                        FotografiasI = c.Boolean(nullable: false),
                        VideosI = c.Boolean(nullable: false),
                        CintasAudioI = c.Boolean(nullable: false),
                        IlustracionesI = c.Boolean(nullable: false),
                        DiagramasI = c.Boolean(nullable: false),
                        OtrosI = c.Boolean(nullable: false),
                        CualesI = c.String(),
                        boTipoVinculacionII = c.String(),
                        TipoIdentificacionII = c.String(),
                        ActividadEconomicaII = c.String(),
                        NumeroIdentificacionII = c.String(),
                        NombreRazonSocialII = c.String(),
                        DireccionPpalII = c.String(),
                        TelefonoII = c.String(),
                        FaxII = c.String(),
                        st_DepartamentoII = c.String(),
                        st_MunicipioII = c.String(),
                        EmailII = c.String(),
                        ZonaUrbanaII = c.String(),
                        SedePrincipalII = c.Boolean(nullable: false),
                        ActEconoCentroTrabajoII = c.String(),
                        CentroCostoTelefonoII = c.String(),
                        CentroCostoFaxII = c.String(),
                        DireccionCentroTrabajoII = c.String(),
                        ZonaII = c.String(),
                        pk_DeptoCentroCostoII = c.Int(nullable: false),
                        pk_MncpioCentroCostoII = c.Int(nullable: false),
                        pk_DepartamentoIV = c.Int(nullable: false),
                        pk_MncpioIV = c.Int(nullable: false),
                        boTipoVinculacionIII = c.String(),
                        tempTipoIdentificacionIII = c.String(),
                        NumeroIdentificacionIII = c.String(),
                        PrimerApellidoIII = c.String(),
                        SegundoApellidoIII = c.String(),
                        PrimerNombreIII = c.String(),
                        FechaNacimientoIII = c.String(),
                        DepartamentoIII = c.String(),
                        MunicipioIII = c.String(),
                        SexoIII = c.String(),
                        EPSIII = c.String(),
                        AFPIII = c.String(),
                        ARLIII = c.String(),
                        TelefonoIII = c.String(),
                        FaxIII = c.String(),
                        EmailIII = c.String(),
                        DireccionCentroTrabajoIII = c.String(),
                        ZonaIII = c.String(),
                        CargoIII = c.String(),
                        OcupacionIII = c.String(),
                        FechaIngresoIII = c.String(),
                        TiempoOcupacionAIII = c.String(),
                        TiempoOcupacionMIII = c.String(),
                        AntiguedadAIII = c.String(),
                        AntiguedadMIII = c.String(),
                        boJornadaIII = c.String(),
                        SalarioHonorariosIII = c.String(),
                        FechaMuerteIII = c.String(),
                        AtencionOportunaIII = c.String(),
                        SegundoNombreIII = c.String(),
                        CodigoOcupacionIII = c.String(),
                        AtencionOportunaOtrosIII = c.String(),
                        FechaOcurrenciaIV = c.String(),
                        HoraOcurrenciaIV = c.String(),
                        boJornadaIV = c.String(),
                        boDiaSemanaIV = c.String(),
                        LaborHabitualIV = c.String(),
                        LaborHabitualIVN = c.Boolean(nullable: false),
                        TipoIncidenteIV = c.String(),
                        EspecTipoIncidenteIV = c.String(),
                        IPSAtendioIV = c.String(),
                        ZonaIV = c.String(),
                        TiempoLaboradoPrevioIV = c.String(),
                        LugarExactoIV = c.String(),
                        SitioExactoIV = c.String(),
                        OtroSitioIV = c.Boolean(nullable: false),
                        EspecifiqueIV = c.String(),
                        MarcaVI = c.String(),
                        textfield74 = c.String(),
                        FactoresPersonalesVII2 = c.String(),
                        EventosSimilaresV = c.String(),
                        NumeroPersonasV = c.String(),
                        OtrosIncidentesV = c.String(),
                        EventoSimilarV = c.String(),
                        CondicionPrioritariaV = c.String(),
                        TrabajadorInvolucradoV = c.String(),
                        PanoramaRiesgoV = c.String(),
                        DescripcionAccidenteV = c.String(),
                        AgenteVI = c.String(),
                        MaterialVI = c.String(),
                        ModeloVI = c.String(),
                        ReferenciaVI = c.String(),
                        PesoVI = c.String(),
                        PesoUnidadMedidaVI = c.String(),
                        AlturaVI = c.String(),
                        AnchoVI = c.String(),
                        VolumenVI = c.String(),
                        ProfundidadVI = c.String(),
                        VelocidadVI = c.String(),
                        TiempoUsoVI = c.String(),
                        TiempoUsoVIA = c.String(),
                        FechaMantenimientoVI = c.String(),
                        ReparadoVI = c.String(),
                        ExplosivosVI = c.String(),
                        ExplosivosUnidadMedidaVI = c.String(),
                        ExplosivosUnidadMedidaVI2 = c.String(),
                        GasesVI = c.String(),
                        GasesCantidadVI = c.String(),
                        SustanciaVI = c.String(),
                        TemperaturaVI = c.String(),
                        TemperaturaUnidadMedidaVI = c.String(),
                        SustanciaUnidadMedidaVI = c.String(),
                        SustanciaCantidadVI = c.String(),
                        VoltajeElectricoVI = c.String(),
                        VoltajeElectricoUnidadMedidaVI = c.String(),
                        VoltajeElectricoUnidadMedidaV2 = c.String(),
                        UnidadMedidaVI = c.String(),
                        DetallesAdicionalesVI = c.String(),
                        EPPVI = c.String(),
                        TrabajadorEPPVI = c.String(),
                        ObservacionesVI = c.String(),
                        CodTipoLesionVII = c.String(),
                        TipoLesionVII = c.String(),
                        CodigoParteCuerpoAfectadaVII = c.String(),
                        CodMecaAccideneteVII = c.String(),
                        MecanismoAccidenteVII = c.String(),
                        CodAgenteAccideneteVII = c.String(),
                        AgenteAccidenteVII = c.String(),
                        CodFactoresPersonalesVII1 = c.String(),
                        FactoresPersonalesVII1 = c.String(),
                        CodFactoresPersonalesVII2 = c.String(),
                        CodActFactoresPersonalesVII2 = c.String(),
                        ActFactoresPersonalesVII2 = c.String(),
                        CodActoSubestandarVII1 = c.String(),
                        ActosSubestandarVII1 = c.String(),
                        CodActoSubestandarVII2 = c.String(),
                        ActosSubestandarVII2 = c.String(),
                        CodFactoresTrabajoVII1 = c.String(),
                        FactoresTrabajoVII1 = c.String(),
                        CodFactoresTrabajoVII2 = c.String(),
                        FactoresTrabajoVII2 = c.String(),
                        CodCondAmbientalesVII1 = c.String(),
                        CondAmbientalesVII1 = c.String(),
                        CodCondAmbientalesVII2 = c.String(),
                        CondAmbientalesVII2 = c.String(),
                        TipoIdentJefeInmediantoIX = c.String(),
                        NumIdentJefeInmediatoIX = c.String(),
                        JefeInmediatoNombresIX = c.String(),
                        JefeInmediatoCargoIX = c.String(),
                        DescripcionAnalisisIX = c.String(),
                        TipoIdentEncargadoPSOIX = c.String(),
                        NumIdentPSOIX = c.String(),
                        EncargadoPSONombresIX = c.String(),
                        EncargadoPSOCargoIX = c.String(),
                        TipoIdentCOPASOIX = c.String(),
                        COPASONumIdentIX = c.String(),
                        COPASONombresCompletosIX = c.String(),
                        COPASOCargoIX = c.String(),
                        TipoIdentEncargadosPSOIX = c.String(),
                        TipoIdentBrigadistaIX = c.String(),
                        NumeroIdentBrigadistaIX = c.String(),
                        BrigadistaNombresIX = c.String(),
                        BrigadistaCargoIX = c.String(),
                        TipoIdentParticipanteIX = c.String(),
                        NumIdentParticipanteIX = c.String(),
                        ParticipanteNombreIX = c.String(),
                        ParticipanteCargoIX = c.String(),
                        TipoIdentAnalisisIX = c.String(),
                        EmpresaRepresentaIX = c.String(),
                        ObservacionEspecialistaIX = c.String(),
                        TipoIdentRepresentanteARLIX = c.String(),
                        RepresentanteARLNombresIX = c.String(),
                        NumLicenciaEspecialistaSGSSTIX1 = c.String(),
                        anioLicenciaEspecialistaSGSSTIX1 = c.String(),
                        NumIdentRepresentanteARLIXIX = c.String(),
                        TipoIdentEspecialistaSGSSTIX = c.String(),
                        EspecialistaSGSSTNombresIX = c.String(),
                        NumLicenciaEspecialistaSGSSTIX2 = c.String(),
                        anioLicenciaEspecialistaSGSSTIX2 = c.String(),
                        NumIdentEspecialistaSGSSTIX = c.String(),
                        FechaVerificacionXII = c.String(),
                        CausasInmediatasTipoC1X = c.String(),
                        MedidasIntervencion1X = c.String(),
                        TipoF1X = c.String(),
                        RespImplementacion1X = c.String(),
                        FechaImplementacion1X = c.String(),
                        CausasInmediatasTipoC2X = c.String(),
                        MedidasIntervencion2X = c.String(),
                        TipoF2X = c.String(),
                        RespImplementacion2X = c.String(),
                        FechaImplementacion2X = c.String(),
                        CausasInmediatasTipoC3X = c.String(),
                        MedidasIntervencion3X = c.String(),
                        TipoF3X = c.String(),
                        RespImplementacion3X = c.String(),
                        FechaImplementacion3X = c.String(),
                        CausasBasicasTipoC1X = c.String(),
                        BasicasInmediatas1X = c.String(),
                        BasicasF1X = c.String(),
                        BasicasRespImplementacion1X = c.String(),
                        BasicasFechaImplementacion1X = c.String(),
                        CausasBasicasTipoC2X = c.String(),
                        BasicasInmediatas2X = c.String(),
                        BasicasF2X = c.String(),
                        BasicasRespImplementacion2X = c.String(),
                        BasicasFechaImplementacion2X = c.String(),
                        CausasBasicasTipoC3X = c.String(),
                        BasicasInmediatas3X = c.String(),
                        BasicasF3X = c.String(),
                        BasicasRespImplementacion3X = c.String(),
                        BasicasFechaImplementacion3X = c.String(),
                        FechaRemisionXI = c.String(),
                        NoFoliosXI = c.String(),
                        TipoIdentificacionXI = c.String(),
                        NumeroIdentificacionXI = c.String(),
                        NombresXI = c.String(),
                        CargoXI = c.String(),
                        RecomendacionesARLXI = c.String(),
                        RemisionInformeARLXI = c.String(),
                        RemisionMinisterioTrabajoXI = c.String(),
                        TipoIdentificacionXII = c.String(),
                        NumeroIdentificacionXII = c.String(),
                        NombresXII = c.String(),
                        CargoXII = c.String(),
                        MedidasIntervencionXII = c.String(),
                        ObservacionesXII = c.String(),
                        NitEmpresa = c.String(),
                        myFile1 = c.String(),
                        myFile2 = c.String(),
                        myFile3 = c.String(),
                        myFile4 = c.String(),
                        myFile5 = c.String(),
                        myFile6 = c.String(),
                        myFile7 = c.String(),
                        myFile8 = c.String(),
                        myFile9 = c.String(),
                        myFile10 = c.String(),
                        myFile11 = c.String(),
                        myFile12 = c.String(),
                        myFile13 = c.String(),
                        RecomendacionesCargoXI = c.String(),
                        BasicasT3X = c.String(),
                        VelocidadUnidadMedidaVI = c.String(),
                        TipoIdentificacionXIII = c.String(),
                        NombresXIII = c.String(),
                        CargoXIII = c.String(),
                        NumeroIdentificacionXIII = c.String(),
                        MedidasIntervencionXIII = c.String(),
                        FechaVerificacionXIII = c.String(),
                        ObservacionesXIII = c.String(),
                        TipoIdentJefeInmediantoIXTI = c.String(),
                        TipoIdentEncargadoPSOIXTI = c.String(),
                        TipoIdentCOPASOIXTI = c.String(),
                        TipoIdentBrigadistaIXTI = c.String(),
                        TipoIdentParticipanteIXTI = c.String(),
                        TipoIdentRepresentanteARLIXTI = c.String(),
                        TipoIdentEspecialistaSGSSTIXTI = c.String(),
                        boTipoF1X = c.Boolean(nullable: false),
                        boTipoM1X = c.Boolean(nullable: false),
                        boTipoT1X = c.Boolean(nullable: false),
                        boTipoF2X = c.Boolean(nullable: false),
                        boTipoM2X = c.Boolean(nullable: false),
                        boTipoT2X = c.Boolean(nullable: false),
                        boTipoF3X = c.Boolean(nullable: false),
                        boTipoM3X = c.Boolean(nullable: false),
                        boTipoT3X = c.Boolean(nullable: false),
                        boBasicasF1X = c.Boolean(nullable: false),
                        boBasicasM1X = c.Boolean(nullable: false),
                        boBasicasT1X = c.Boolean(nullable: false),
                        boBasicasF2X = c.Boolean(nullable: false),
                        boBasicasM2X = c.Boolean(nullable: false),
                        boBasicasT2X = c.Boolean(nullable: false),
                        boBasicasF3X = c.Boolean(nullable: false),
                        boBasicasM3X = c.Boolean(nullable: false),
                        boBasicasT3X = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PK_Incidentes_AT);
            
            AddColumn("dbo.Tbl_IncidentesEL2", "DiagnosticosCIEV", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CodigoCieCIEV", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "NoTrabajadoresCargos", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "NombresApellidosV5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TurnosIV2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "MixtoIV2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "NocturnoIV2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "DiurnoIV2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "ObservacionesIV", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "MncpioTrabajadorIII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CodigoMncpioTrabajadorIII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "DeptoTrabajadorIII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CodigoDeptoTrabajadorIII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "ObservacionesX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaVerficacionXI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "ObsevacionesARLXI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "MedidasIntervencionXI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "NumeroIdentificacionXI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CargoXI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "ResponsableVerficiacionXI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionXI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaVerficacionX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "ObsevacionesX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "MedidasIntervencionX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "NumeroIdentificacionX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CargoX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "ResponsableVerficiacionX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CargoARLIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "ResponsablesRemisionARLIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "DisponibleRemisionARLIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FecRemisionTerritorialIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaRemisionARLIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "NumeroIdentificacionIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CargoIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "NombreApellidoIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "NoFoliosIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaRemisionIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "NitVIII8", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "EmpresaRepresentaVIII8", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "NumeroIdentificacionVIII8", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "LicenciaAnioVIII8", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "LicenciaNumeroVIII8", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RepresentanteArlVIII8", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionVIII8", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "NumeroIdentificacionVIII7", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "LicenciaAnioVIII1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "LicenciaNumVIII1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "EspecialistaOcupacionalVIII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionVIII7", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "NumeroIdentificacionVIII6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CargoVIII6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "JefeInmediatoVIII6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionVIII6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "NumeroIdentificacionVIII5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CargoVIII5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "JefeInmediatoVIII5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionVIII5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "NumeroIdentificacionVIII4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CargoVIII4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "JefeInmediatoVIII4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionVIII4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "NumeroIdentificacionVIII3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CargoVIII3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "JefeInmediatoVIII3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionVIII3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "NumeroIdentificacionVIII2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CargoVIII2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "JefeInmediatoVIII2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionVIII2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "NumeroIdentificacionVIII1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CargoVIII1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "JefeInmediatoVIII1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionVIII1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaEjeDiaVII8", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaEjeMesVII8", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "ResponsableImplementacionVII8", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "MedidasPreventivasVII8", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaEjeDiaVII7", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaEjeMesVII7", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "ResponsableImplementacionVII7", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "MedidasPreventivasVII7", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaEjeDiaVII6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaEjeMesVII6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "ResponsableImplementacionVII6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "MedidasPreventivasVII6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaEjeDiaVII5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaEjeMesVII5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "ResponsableImplementacionVII5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "MedidasPreventivasVII5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaEjeDiaVII4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaEjeMesVII4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "ResponsableImplementacionVII4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "MedidasPreventivasVII4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaEjeDiaVII3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaEjeMesVII3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "ResponsableImplementacionVII3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "MedidasPreventivasVII3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaEjeDiaVII2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaEjeMesVII2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "ResponsableImplementacionVII2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "MedidasPreventivasVII2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaEjeDiaVII1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaEjeMesVII1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "ResponsableImplementacionVII1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "MedidasPreventivasVII1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CausasEnfermedadLaboralVI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "OtrosDatosInteresVI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CauRelPrevVI12", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooCauRelPrevVI12", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CauRelPrevVI11", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooCauRelPrevVI11", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CauRelPrevVI10", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooCauRelPrevVI10", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CauRelPrevVI9", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooCauRelPrevVI9", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CauRelPrevVI8", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooCauRelPrevVI8", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CauRelPrevVI7", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooCauRelPrevVI7", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CauRelPrevVI6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooCauRelPrevVI6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CauRelPrevVI5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooCauRelPrevVI5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CauRelPrevVI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooCauRelPrevVI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CauRelPrevVI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooCauRelPrevVI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CauRelPrevVI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooCauRelPrevVI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CauRelPrevVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooCauRelPrevVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "DMEResumen", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooManipulacionCargas", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooEsfuerzoCuerpo", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooEsfuerzoManos", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooPeriodoRecuperacionFisica", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooLabRepetitivaBrazoMuMano", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooLabRepetitivaColumna", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooPosturaIncomodaEspalda", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooEsfuerzoBrazosManos", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooPosturaIncomodaBrazosManos", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooPostPieSedente", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooPostPieProlongada", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "NivelEstresVI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "NivelRiesgoIndiviVI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "NivelRiesgoExtralabVI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "NivelRiesgoLabVI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "IntensidadObservVI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "IntensidadBajaVI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "IntensidadMediaVI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "IntensidadAltaVI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "IntensidadObservVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "IntensidadBajaVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "IntensidadMediaVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "IntensidadAltaVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "VarPsicoObservacionesVI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "IntensidadBajoVI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "IntensidadMedioVI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "IntensidadAltoVI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TiempoExpBajoV4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TiempoExpMedioVI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TiempoExpAltoVI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FrecPresBajoVI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FrecPresMedioVI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FrecPresAltoVI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "VarPsicoObservacionesVI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "IntensidadBajoVI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "IntensidadMedioVI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "IntensidadAltoVI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TiempoExpBajoVI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TiempoExpMedioVI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TiempoExpAltoVI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FrecPresBajoVI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FrecPresMedioVI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FrecPresAltoVI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "VarPsicoObservacionesVI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "IntensidadBajoVI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "IntensidadMedioVI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "IntensidadAltoVI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TiempoExpBajoVI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TiempoExpMedioVI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TiempoExpAltoVI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FrecPresBajoVI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FrecPresMedioVI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FrecPresAltoVI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "VarPsicoObservacionesVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "IntensidadBajoVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "IntensidadMedioVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "IntensidadAltoVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TiempoExpBajoVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TiempoExpMedioVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TiempoExpAltoVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FrecPresBajoVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FrecPresMedioVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FrecPresAltoVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "DescEventoInv6VI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooExpoRuido6VI6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaMedAnio6VI6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaMedMes6VI6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaMedDia6VI6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "Aceleracion6VI6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "Frecuencia6VI6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "AceEjeDominante6VI6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "EjeDominante6VI6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "AceTotal6VI6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "VMB6VI6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "VCE6VI6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TiempoExpHD6VI6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TiempoExpMeses6VI6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooTipoVibMB6VI6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooTipoVibCE6VI6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "VibDescFuente6VI6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "VibCargoEmpresa6VI6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooExpoRuido6VI5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaMedAnio6VI5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaMedMes6VI5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaMedDia6VI5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "Aceleracion6VI5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "Frecuencia6VI5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "AceEjeDominante6VI5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "EjeDominante6VI5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "AceTotal6VI5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "VMB6VI5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "VCE6VI5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TiempoExpHD6VI5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TiempoExpMeses6VI5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooTipoVibMB6VI5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooTipoVibCE6VI5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "VibDescFuente6VI5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "VibCargoEmpresa6VI5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooExpoRuido6VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaMedAnio6VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaMedMes6VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaMedDia6VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "Aceleracion6VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "Frecuencia6VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "AceEjeDominante6VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "EjeDominante6VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "AceTotal6VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "VMB6VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "VCE6VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TiempoExpHD6VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TiempoExpMeses6VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooTipoVibMB6VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooTipoVibCE6VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "VibDescFuente6VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "VibCargoEmpresa6VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooExpoRuido6VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaMedAnio6VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaMedMes6VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaMedDia6VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "Aceleracion6VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "Frecuencia6VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "AceEjeDominante6VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "EjeDominante6VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "AceTotal6VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "VMB6VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "VCE6VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TiempoExpHD6VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TiempoExpMeses6VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooTipoVibMB6VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooTipoVibCE6VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "VibDescFuente6VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "VibCargoEmpresa6VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooExpoRuido6VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaMedAnio6VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaMedMes6VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaMedDia6VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "Aceleracion6VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "Frecuencia6VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "AceEjeDominante6VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "EjeDominante6VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "AceTotal6VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "VMB6VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "VCE6VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TiempoExpHD6VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TiempoExpMeses6VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooTipoVibMB6VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooTipoVibCE6VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "VibDescFuente6VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "VibCargoEmpresa6VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooExpoRuido6VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaMedAnio6VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaMedMes6VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaMedDia6VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "Aceleracion6VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "Frecuencia6VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "AceEjeDominante6VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "EjeDominante6VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "AceTotal6VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "VMB6VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "VCE6VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TiempoExpHD6VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TiempoExpMeses6VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooTipoVibMB6VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooTipoVibCE6VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "VibDescFuente6VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "VibCargoEmpresa6VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadFMAnio5VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadFMMes5VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadFMDia5VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadEvalAmbiental5VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadTEAnio5V4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadTEMes5VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadTEDia5VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadCondiciones5VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadDescripcionAct5VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadDescripcionFuente5VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadCargoEmpresa5VI4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadFMAnio5VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadFMMes5VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadFMDia5VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadEvalAmbiental5VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadTEAnio5VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadTEMes5VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadTEDia5VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadCondiciones5VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadDescripcionAct5VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadDescripcionFuente5VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadCargoEmpresa5VI3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadFMAnio5VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadFMMes5VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadFMDia5VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadEvalAmbiental5VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadTEAnio5VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadTEMes5VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadTEDia5VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadCondiciones5VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadDescripcionAct5VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadDescripcionFuente5VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadCargoEmpresa5VI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadFMAnio5VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadFMMes5VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadFMDia5VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadEvalAmbiental5VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadTEAnio5VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadTEMes5VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadTEDia5VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadCondiciones5VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadDescripcionAct5VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadDescripcionFuente5VI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "RadCargoEmpresa5VI1", c => c.String());
            AddColumn("dbo.Tbl_Departamento", "IncidentesAT_PK_Incidentes_AT3", c => c.Int());
            AddColumn("dbo.Tbl_Departamento", "IncidentesAT_PK_Incidentes_AT2", c => c.Int());
            AddColumn("dbo.Tbl_Departamento", "IncidentesAT_PK_Incidentes_AT1", c => c.Int());
            AddColumn("dbo.Tbl_Departamento", "IncidentesAT_PK_Incidentes_AT", c => c.Int());
            AddColumn("dbo.Tbl_Municipio", "IncidentesAT_PK_Incidentes_AT3", c => c.Int());
            AddColumn("dbo.Tbl_Municipio", "IncidentesAT_PK_Incidentes_AT2", c => c.Int());
            AddColumn("dbo.Tbl_Municipio", "IncidentesAT_PK_Incidentes_AT1", c => c.Int());
            AddColumn("dbo.Tbl_Municipio", "IncidentesAT_PK_Incidentes_AT", c => c.Int());
            DropForeignKey("dbo.Tbl_Municipio", "IncidentesAT4_PK_Incidentes_AT4", "dbo.Tbl_IncidentesAT4");
            DropForeignKey("dbo.Tbl_Departamento", "IncidentesAT4_PK_Incidentes_AT4", "dbo.Tbl_IncidentesAT4");
            DropForeignKey("dbo.Tbl_Municipio", "IncidentesAT2_PK_Incidentes_AT21", "dbo.Tbl_IncidentesAT2");
            DropForeignKey("dbo.Tbl_Municipio", "IncidentesAT2_PK_Incidentes_AT2", "dbo.Tbl_IncidentesAT2");
            DropForeignKey("dbo.Tbl_Departamento", "IncidentesAT2_PK_Incidentes_AT21", "dbo.Tbl_IncidentesAT2");
            DropForeignKey("dbo.Tbl_Departamento", "IncidentesAT2_PK_Incidentes_AT2", "dbo.Tbl_IncidentesAT2");
            DropForeignKey("dbo.Tbl_Municipio", "IncidentesAT1_PK_Incidentes_AT", "dbo.Tbl_IncidentesAT1");
            DropForeignKey("dbo.Tbl_Departamento", "IncidentesAT1_PK_Incidentes_AT", "dbo.Tbl_IncidentesAT1");
            DropIndex("dbo.Tbl_Departamento", new[] { "IncidentesAT4_PK_Incidentes_AT4" });
            DropIndex("dbo.Tbl_Departamento", new[] { "IncidentesAT2_PK_Incidentes_AT21" });
            DropIndex("dbo.Tbl_Departamento", new[] { "IncidentesAT2_PK_Incidentes_AT2" });
            DropIndex("dbo.Tbl_Departamento", new[] { "IncidentesAT1_PK_Incidentes_AT" });
            DropIndex("dbo.Tbl_Municipio", new[] { "IncidentesAT4_PK_Incidentes_AT4" });
            DropIndex("dbo.Tbl_Municipio", new[] { "IncidentesAT2_PK_Incidentes_AT21" });
            DropIndex("dbo.Tbl_Municipio", new[] { "IncidentesAT2_PK_Incidentes_AT2" });
            DropIndex("dbo.Tbl_Municipio", new[] { "IncidentesAT1_PK_Incidentes_AT" });
            DropColumn("dbo.Tbl_IncidentesEL2", "NitEmpresa");
            DropColumn("dbo.Tbl_IncidentesEL2", "McpioCentroTrabajoII");
            DropColumn("dbo.Tbl_IncidentesEL2", "DeptoCentroTrabajoII");
            DropColumn("dbo.Tbl_IncidentesEL2", "ZonaEmpleadorII");
            DropColumn("dbo.Tbl_IncidentesEL2", "EmailEmpleadorII");
            DropColumn("dbo.Tbl_IncidentesEL2", "McpioEmpleadorII");
            DropColumn("dbo.Tbl_IncidentesEL2", "DeptoEmpleadorII");
            DropColumn("dbo.Tbl_IncidentesEL2", "ActEconoCentroTrabajoII");
            DropColumn("dbo.Tbl_IncidentesEL2", "CodActEconoPpalII");
            DropColumn("dbo.Tbl_IncidentesEL2", "CentroCostoFaxII");
            DropColumn("dbo.Tbl_IncidentesEL2", "CentroCostoTelefonoII");
            DropColumn("dbo.Tbl_IncidentesEL2", "CentroTrabajoPpalII");
            DropColumn("dbo.Tbl_IncidentesEL2", "ZonaPpalII");
            DropColumn("dbo.Tbl_IncidentesEL2", "EmailII");
            DropColumn("dbo.Tbl_IncidentesEL2", "McpioPpalII");
            DropColumn("dbo.Tbl_IncidentesEL2", "DeptoPpalII");
            DropColumn("dbo.Tbl_IncidentesEL2", "FaxII");
            DropColumn("dbo.Tbl_IncidentesEL2", "TelefonoPpalII");
            DropColumn("dbo.Tbl_IncidentesEL2", "DireccionPrincipalII");
            DropColumn("dbo.Tbl_IncidentesEL2", "NumIdentificacionII");
            DropColumn("dbo.Tbl_IncidentesEL2", "TipoIdentificacionII");
            DropColumn("dbo.Tbl_IncidentesEL2", "RazonSocialII");
            DropColumn("dbo.Tbl_IncidentesEL2", "ActividadPrincipalII");
            DropColumn("dbo.Tbl_IncidentesEL2", "CodActividadII");
            DropColumn("dbo.Tbl_IncidentesEL2", "EmpleadorII");
            DropColumn("dbo.Tbl_Departamento", "IncidentesAT4_PK_Incidentes_AT4");
            DropColumn("dbo.Tbl_Departamento", "IncidentesAT2_PK_Incidentes_AT21");
            DropColumn("dbo.Tbl_Departamento", "IncidentesAT2_PK_Incidentes_AT2");
            DropColumn("dbo.Tbl_Departamento", "IncidentesAT1_PK_Incidentes_AT");
            DropColumn("dbo.Tbl_Municipio", "IncidentesAT4_PK_Incidentes_AT4");
            DropColumn("dbo.Tbl_Municipio", "IncidentesAT2_PK_Incidentes_AT21");
            DropColumn("dbo.Tbl_Municipio", "IncidentesAT2_PK_Incidentes_AT2");
            DropColumn("dbo.Tbl_Municipio", "IncidentesAT1_PK_Incidentes_AT");
            DropTable("dbo.Tbl_IncidentesEL9");
            DropTable("dbo.Tbl_IncidentesEL8");
            DropTable("dbo.Tbl_IncidentesEL7");
            DropTable("dbo.Tbl_IncidentesEL6");
            DropTable("dbo.Tbl_IncidentesEL5");
            DropTable("dbo.Tbl_IncidentesEL4");
            DropTable("dbo.Tbl_IncidentesEL3");
            DropTable("dbo.Tbl_IncidentesEL10");
            DropTable("dbo.Tbl_IncidentesEL1");
            DropTable("dbo.Tbl_IncidentesATAnexos");
            DropTable("dbo.Tbl_IncidentesAT9");
            DropTable("dbo.Tbl_IncidentesAT8");
            DropTable("dbo.Tbl_IncidentesAT7");
            DropTable("dbo.Tbl_IncidentesAT6");
            DropTable("dbo.Tbl_IncidentesAT5");
            DropTable("dbo.Tbl_IncidentesAT4");
            DropTable("dbo.Tbl_IncidentesAT3");
            DropTable("dbo.Tbl_IncidentesAT2");
            DropTable("dbo.Tbl_IncidentesAT13");
            DropTable("dbo.Tbl_IncidentesAT12");
            DropTable("dbo.Tbl_IncidentesAT11");
            DropTable("dbo.Tbl_IncidentesAT10");
            DropTable("dbo.Tbl_IncidentesAT1");
            CreateIndex("dbo.Tbl_Departamento", "IncidentesAT_PK_Incidentes_AT3");
            CreateIndex("dbo.Tbl_Departamento", "IncidentesAT_PK_Incidentes_AT2");
            CreateIndex("dbo.Tbl_Departamento", "IncidentesAT_PK_Incidentes_AT1");
            CreateIndex("dbo.Tbl_Departamento", "IncidentesAT_PK_Incidentes_AT");
            CreateIndex("dbo.Tbl_Municipio", "IncidentesAT_PK_Incidentes_AT3");
            CreateIndex("dbo.Tbl_Municipio", "IncidentesAT_PK_Incidentes_AT2");
            CreateIndex("dbo.Tbl_Municipio", "IncidentesAT_PK_Incidentes_AT1");
            CreateIndex("dbo.Tbl_Municipio", "IncidentesAT_PK_Incidentes_AT");
            AddForeignKey("dbo.Tbl_Municipio", "IncidentesAT_PK_Incidentes_AT3", "dbo.Tbl_IncidentesAT", "PK_Incidentes_AT");
            AddForeignKey("dbo.Tbl_Municipio", "IncidentesAT_PK_Incidentes_AT2", "dbo.Tbl_IncidentesAT", "PK_Incidentes_AT");
            AddForeignKey("dbo.Tbl_Municipio", "IncidentesAT_PK_Incidentes_AT1", "dbo.Tbl_IncidentesAT", "PK_Incidentes_AT");
            AddForeignKey("dbo.Tbl_Municipio", "IncidentesAT_PK_Incidentes_AT", "dbo.Tbl_IncidentesAT", "PK_Incidentes_AT");
            AddForeignKey("dbo.Tbl_Departamento", "IncidentesAT_PK_Incidentes_AT3", "dbo.Tbl_IncidentesAT", "PK_Incidentes_AT");
            AddForeignKey("dbo.Tbl_Departamento", "IncidentesAT_PK_Incidentes_AT2", "dbo.Tbl_IncidentesAT", "PK_Incidentes_AT");
            AddForeignKey("dbo.Tbl_Departamento", "IncidentesAT_PK_Incidentes_AT1", "dbo.Tbl_IncidentesAT", "PK_Incidentes_AT");
            AddForeignKey("dbo.Tbl_Departamento", "IncidentesAT_PK_Incidentes_AT", "dbo.Tbl_IncidentesAT", "PK_Incidentes_AT");
        }
    }
}
