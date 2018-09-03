namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newfieldcu36ad14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_IncidentesATAnexos", "myFile14", c => c.String());
            DropColumn("dbo.Tbl_IncidentesATAnexos", "myFile13");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tbl_IncidentesATAnexos", "myFile13", c => c.String());
            DropColumn("dbo.Tbl_IncidentesATAnexos", "myFile14");
        }
    }
}
