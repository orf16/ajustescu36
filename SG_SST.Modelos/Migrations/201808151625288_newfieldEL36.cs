namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newfieldEL36 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_IncidentesEL5", "CodigoCie1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL5", "CodigoCie2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL5", "CodigoCie3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL5", "CodigoCie4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL5", "DiagnosticoIV1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL5", "DiagnosticoIV2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL5", "DiagnosticoIV3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL5", "DiagnosticoIV4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL5", "FechaOrigenELIV", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL5", "OrigenLaboralIV", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_IncidentesEL5", "OrigenLaboralIV");
            DropColumn("dbo.Tbl_IncidentesEL5", "FechaOrigenELIV");
            DropColumn("dbo.Tbl_IncidentesEL5", "DiagnosticoIV4");
            DropColumn("dbo.Tbl_IncidentesEL5", "DiagnosticoIV3");
            DropColumn("dbo.Tbl_IncidentesEL5", "DiagnosticoIV2");
            DropColumn("dbo.Tbl_IncidentesEL5", "DiagnosticoIV1");
            DropColumn("dbo.Tbl_IncidentesEL5", "CodigoCie4");
            DropColumn("dbo.Tbl_IncidentesEL5", "CodigoCie3");
            DropColumn("dbo.Tbl_IncidentesEL5", "CodigoCie2");
            DropColumn("dbo.Tbl_IncidentesEL5", "CodigoCie1");
        }
    }
}
