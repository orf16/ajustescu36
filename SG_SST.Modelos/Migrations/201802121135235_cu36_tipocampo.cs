namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cu36_tipocampo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_IncidentesAT", "TipoIdentBrigadistaIX", c => c.String());
            DropColumn("dbo.Tbl_IncidentesAT", "TipoIdentBrigadistaIX4");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tbl_IncidentesAT", "TipoIdentBrigadistaIX4", c => c.String());
            DropColumn("dbo.Tbl_IncidentesAT", "TipoIdentBrigadistaIX");
        }
    }
}
