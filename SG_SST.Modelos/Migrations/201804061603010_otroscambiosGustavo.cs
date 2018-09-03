namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class otroscambiosGustavo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_IncidentesEL", "VideosI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "CintasAudioI", c => c.String());
            DropColumn("dbo.Tbl_IncidentesEL", "ContratanteII");
            DropColumn("dbo.Tbl_IncidentesEL", "IndependienteII");
            DropColumn("dbo.Tbl_IncidentesEL", "CooperativaII");
            DropColumn("dbo.Tbl_IncidentesEL", "AgremiacionII");
            DropColumn("dbo.Tbl_IncidentesEL", "AsociacionII");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tbl_IncidentesEL", "AsociacionII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "AgremiacionII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "CooperativaII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "IndependienteII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "ContratanteII", c => c.String());
            DropColumn("dbo.Tbl_IncidentesEL", "CintasAudioI");
            DropColumn("dbo.Tbl_IncidentesEL", "VideosI");
        }
    }
}
