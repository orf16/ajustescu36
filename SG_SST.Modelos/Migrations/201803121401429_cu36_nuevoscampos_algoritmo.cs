namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cu36_nuevoscampos_algoritmo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_IncidentesEL", "TiempoOcupacionAniosIV", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TiempoOcupacionMesesIV", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "NoHabitualesIV", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_IncidentesEL", "NoHabitualesIV");
            DropColumn("dbo.Tbl_IncidentesEL", "TiempoOcupacionMesesIV");
            DropColumn("dbo.Tbl_IncidentesEL", "TiempoOcupacionAniosIV");
        }
    }
}
