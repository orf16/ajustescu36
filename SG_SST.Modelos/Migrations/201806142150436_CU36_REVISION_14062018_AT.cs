namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CU36_REVISION_14062018_AT : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_IncidentesAT", "DepartamentoIII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "MunicipioIII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "NumLicenciaEspecialistaSGSSTIX1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "anioLicenciaEspecialistaSGSSTIX1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "NumLicenciaEspecialistaSGSSTIX2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "anioLicenciaEspecialistaSGSSTIX2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "TipoIdentJefeInmediantoIXTI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "TipoIdentEncargadoPSOIXTI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "TipoIdentCOPASOIXTI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "TipoIdentBrigadistaIXTI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "TipoIdentParticipanteIXTI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "TipoIdentRepresentanteARLIXTI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "TipoIdentEspecialistaSGSSTIXTI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "boTipoF1X", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "boTipoM1X", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "boTipoT1X", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "boTipoF2X", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "boTipoM2X", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "boTipoT2X", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "boTipoF3X", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "boTipoM3X", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "boTipoT3X", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "boBasicasF1X", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "boBasicasM1X", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "boBasicasT1X", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "boBasicasF2X", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "boBasicasM2X", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "boBasicasT2X", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "boBasicasF3X", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "boBasicasM3X", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "boBasicasT3X", c => c.Boolean(nullable: false));
            DropColumn("dbo.Tbl_IncidentesAT", "AnalisisNombresIX");
            DropColumn("dbo.Tbl_IncidentesAT", "NumIdentAnalisisIX");
            DropColumn("dbo.Tbl_IncidentesAT", "CargoAnalisisIX");
            DropColumn("dbo.Tbl_IncidentesAT", "CargoRepresentanteARLIX");
            DropColumn("dbo.Tbl_IncidentesAT", "CargoEspecialistaSGSSTIX");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tbl_IncidentesAT", "CargoEspecialistaSGSSTIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "CargoRepresentanteARLIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "CargoAnalisisIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "NumIdentAnalisisIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "AnalisisNombresIX", c => c.String());
            DropColumn("dbo.Tbl_IncidentesAT", "boBasicasT3X");
            DropColumn("dbo.Tbl_IncidentesAT", "boBasicasM3X");
            DropColumn("dbo.Tbl_IncidentesAT", "boBasicasF3X");
            DropColumn("dbo.Tbl_IncidentesAT", "boBasicasT2X");
            DropColumn("dbo.Tbl_IncidentesAT", "boBasicasM2X");
            DropColumn("dbo.Tbl_IncidentesAT", "boBasicasF2X");
            DropColumn("dbo.Tbl_IncidentesAT", "boBasicasT1X");
            DropColumn("dbo.Tbl_IncidentesAT", "boBasicasM1X");
            DropColumn("dbo.Tbl_IncidentesAT", "boBasicasF1X");
            DropColumn("dbo.Tbl_IncidentesAT", "boTipoT3X");
            DropColumn("dbo.Tbl_IncidentesAT", "boTipoM3X");
            DropColumn("dbo.Tbl_IncidentesAT", "boTipoF3X");
            DropColumn("dbo.Tbl_IncidentesAT", "boTipoT2X");
            DropColumn("dbo.Tbl_IncidentesAT", "boTipoM2X");
            DropColumn("dbo.Tbl_IncidentesAT", "boTipoF2X");
            DropColumn("dbo.Tbl_IncidentesAT", "boTipoT1X");
            DropColumn("dbo.Tbl_IncidentesAT", "boTipoM1X");
            DropColumn("dbo.Tbl_IncidentesAT", "boTipoF1X");
            DropColumn("dbo.Tbl_IncidentesAT", "TipoIdentEspecialistaSGSSTIXTI");
            DropColumn("dbo.Tbl_IncidentesAT", "TipoIdentRepresentanteARLIXTI");
            DropColumn("dbo.Tbl_IncidentesAT", "TipoIdentParticipanteIXTI");
            DropColumn("dbo.Tbl_IncidentesAT", "TipoIdentBrigadistaIXTI");
            DropColumn("dbo.Tbl_IncidentesAT", "TipoIdentCOPASOIXTI");
            DropColumn("dbo.Tbl_IncidentesAT", "TipoIdentEncargadoPSOIXTI");
            DropColumn("dbo.Tbl_IncidentesAT", "TipoIdentJefeInmediantoIXTI");
            DropColumn("dbo.Tbl_IncidentesAT", "anioLicenciaEspecialistaSGSSTIX2");
            DropColumn("dbo.Tbl_IncidentesAT", "NumLicenciaEspecialistaSGSSTIX2");
            DropColumn("dbo.Tbl_IncidentesAT", "anioLicenciaEspecialistaSGSSTIX1");
            DropColumn("dbo.Tbl_IncidentesAT", "NumLicenciaEspecialistaSGSSTIX1");
            DropColumn("dbo.Tbl_IncidentesAT", "MunicipioIII");
            DropColumn("dbo.Tbl_IncidentesAT", "DepartamentoIII");
        }
    }
}
