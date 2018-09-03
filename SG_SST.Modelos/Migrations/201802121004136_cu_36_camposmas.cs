namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cu_36_camposmas : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tbl_IncidentesAT", "EventosSimilaresV", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "OtrosIncidentesV", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "EventoSimilarV", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "CondicionPrioritariaV", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "TrabajadorInvolucradoV", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "PanoramaRiesgoV", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tbl_IncidentesAT", "PanoramaRiesgoV", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "TrabajadorInvolucradoV", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "CondicionPrioritariaV", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "EventoSimilarV", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "OtrosIncidentesV", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "EventosSimilaresV", c => c.Boolean(nullable: false));
        }
    }
}
