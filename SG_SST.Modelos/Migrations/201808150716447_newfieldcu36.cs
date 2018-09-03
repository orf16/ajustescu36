namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newfieldcu36 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_IncidentesAT11", "myFile11", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT12", "myFile12", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT13", "myFile13", c => c.String());
            DropColumn("dbo.Tbl_IncidentesAT12", "myFile11");
            DropColumn("dbo.Tbl_IncidentesAT13", "myFile12");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tbl_IncidentesAT13", "myFile12", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT12", "myFile11", c => c.String());
            DropColumn("dbo.Tbl_IncidentesAT13", "myFile13");
            DropColumn("dbo.Tbl_IncidentesAT12", "myFile12");
            DropColumn("dbo.Tbl_IncidentesAT11", "myFile11");
        }
    }
}
