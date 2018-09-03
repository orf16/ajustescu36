namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_cu_36campos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_IncidentesAT", "TipoIdentBrigadistaIX4", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_IncidentesAT", "TipoIdentBrigadistaIX4");
        }
    }
}
