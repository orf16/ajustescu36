namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cu_36mas : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tbl_IncidentesAT", "ReparadoVI", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "EPPVI", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "TrabajadorEPPVI", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tbl_IncidentesAT", "TrabajadorEPPVI", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "EPPVI", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "ReparadoVI", c => c.Boolean(nullable: false));
        }
    }
}
