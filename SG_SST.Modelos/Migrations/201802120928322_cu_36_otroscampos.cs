namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cu_36_otroscampos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_IncidentesAT", "boJornadaIV", c => c.String());
            DropColumn("dbo.Tbl_IncidentesAT", "JornadaIV");
            DropColumn("dbo.Tbl_IncidentesAT", "ExtraIV");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tbl_IncidentesAT", "ExtraIV", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "JornadaIV", c => c.Boolean(nullable: false));
            DropColumn("dbo.Tbl_IncidentesAT", "boJornadaIV");
        }
    }
}
