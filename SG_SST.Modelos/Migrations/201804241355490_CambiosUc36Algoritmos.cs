namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambiosUc36Algoritmos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_IncidentesAT", "AtencionOportunaOtrosIII", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_IncidentesAT", "AtencionOportunaOtrosIII");
        }
    }
}
