namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cu36_changecampos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tbl_IncidentesAT", "CausasInmediatasTipoC1X", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "CausasInmediatasTipoP1X", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "TipoF1X", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "TipoM1X", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "TipoT1X", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "CausasInmediatasTipoC2X", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "CausasInmediatasTipoP2X", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "TipoF2X", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "TipoM2X", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "TipoT2X", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "CausasInmediatasTipoC3X", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "CausasInmediatasTipoP3X", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "TipoF3X", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "TipoM3X", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "TipoT3X", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "CausasBasicasTipoC1X", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "CausasBasicasTipoP1X", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "BasicasF1X", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "BasicasM1X", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "BasicasT1X", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "CausasBasicasTipoC2X", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "CausasBasicasTipoP2X", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "BasicasF2X", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "BasicasM2X", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "BasicasT2X", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "CausasBasicasTipoC3X", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "CausasBasicasTipoP3X", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "BasicasF3X", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "BasicasM3X", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "BasicasT3X", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "MedidasIntervencionXII", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tbl_IncidentesAT", "MedidasIntervencionXII", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "BasicasT3X", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "BasicasM3X", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "BasicasF3X", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "CausasBasicasTipoP3X", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "CausasBasicasTipoC3X", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "BasicasT2X", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "BasicasM2X", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "BasicasF2X", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "CausasBasicasTipoP2X", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "CausasBasicasTipoC2X", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "BasicasT1X", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "BasicasM1X", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "BasicasF1X", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "CausasBasicasTipoP1X", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "CausasBasicasTipoC1X", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "TipoT3X", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "TipoM3X", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "TipoF3X", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "CausasInmediatasTipoP3X", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "CausasInmediatasTipoC3X", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "TipoT2X", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "TipoM2X", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "TipoF2X", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "CausasInmediatasTipoP2X", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "CausasInmediatasTipoC2X", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "TipoT1X", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "TipoM1X", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "TipoF1X", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "CausasInmediatasTipoP1X", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "CausasInmediatasTipoC1X", c => c.Boolean(nullable: false));
        }
    }
}
