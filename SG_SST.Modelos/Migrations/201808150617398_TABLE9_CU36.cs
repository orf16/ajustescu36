namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TABLE9_CU36 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_IncidentesAT8", "myFile8", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT9", "myFile10", c => c.String());
            DropColumn("dbo.Tbl_IncidentesAT8", "myFile2");
            DropColumn("dbo.Tbl_IncidentesAT9", "myFile8");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tbl_IncidentesAT9", "myFile8", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT8", "myFile2", c => c.String());
            DropColumn("dbo.Tbl_IncidentesAT9", "myFile10");
            DropColumn("dbo.Tbl_IncidentesAT8", "myFile8");
        }
    }
}
