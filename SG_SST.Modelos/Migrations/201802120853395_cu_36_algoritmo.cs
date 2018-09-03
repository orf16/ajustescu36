namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cu_36_algoritmo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_IncidentesAT", "boJornadaIII", c => c.String());
            DropColumn("dbo.Tbl_IncidentesAT", "boDiurnoIII");
            DropColumn("dbo.Tbl_IncidentesAT", "boNocturnoIII");
            DropColumn("dbo.Tbl_IncidentesAT", "boMixtoIII");
            DropColumn("dbo.Tbl_IncidentesAT", "boTurnosIII");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tbl_IncidentesAT", "boTurnosIII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "boMixtoIII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "boNocturnoIII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "boDiurnoIII", c => c.String());
            DropColumn("dbo.Tbl_IncidentesAT", "boJornadaIII");
        }
    }
}
