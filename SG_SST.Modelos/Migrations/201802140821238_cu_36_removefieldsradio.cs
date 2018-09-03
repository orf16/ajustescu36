namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cu_36_removefieldsradio : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tbl_IncidentesAT", "CausasInmediatasTipoP1X");
            DropColumn("dbo.Tbl_IncidentesAT", "TipoM1X");
            DropColumn("dbo.Tbl_IncidentesAT", "TipoT1X");
            DropColumn("dbo.Tbl_IncidentesAT", "CausasInmediatasTipoP2X");
            DropColumn("dbo.Tbl_IncidentesAT", "TipoM2X");
            DropColumn("dbo.Tbl_IncidentesAT", "TipoT2X");
            DropColumn("dbo.Tbl_IncidentesAT", "CausasInmediatasTipoP3X");
            DropColumn("dbo.Tbl_IncidentesAT", "TipoM3X");
            DropColumn("dbo.Tbl_IncidentesAT", "TipoT3X");
            DropColumn("dbo.Tbl_IncidentesAT", "CausasBasicasTipoP1X");
            DropColumn("dbo.Tbl_IncidentesAT", "BasicasM1X");
            DropColumn("dbo.Tbl_IncidentesAT", "BasicasT1X");
            DropColumn("dbo.Tbl_IncidentesAT", "CausasBasicasTipoP2X");
            DropColumn("dbo.Tbl_IncidentesAT", "BasicasM2X");
            DropColumn("dbo.Tbl_IncidentesAT", "BasicasT2X");
            DropColumn("dbo.Tbl_IncidentesAT", "CausasBasicasTipoP3X");
            DropColumn("dbo.Tbl_IncidentesAT", "BasicasM3X");
            DropColumn("dbo.Tbl_IncidentesAT", "BasicasT3X");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tbl_IncidentesAT", "BasicasT3X", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "BasicasM3X", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "CausasBasicasTipoP3X", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "BasicasT2X", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "BasicasM2X", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "CausasBasicasTipoP2X", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "BasicasT1X", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "BasicasM1X", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "CausasBasicasTipoP1X", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "TipoT3X", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "TipoM3X", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "CausasInmediatasTipoP3X", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "TipoT2X", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "TipoM2X", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "CausasInmediatasTipoP2X", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "TipoT1X", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "TipoM1X", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "CausasInmediatasTipoP1X", c => c.String());
        }
    }
}
