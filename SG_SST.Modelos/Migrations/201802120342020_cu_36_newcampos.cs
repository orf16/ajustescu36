namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cu_36_newcampos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_IncidentesAT", "boTipoVinculacionII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "boTipoVinculacionIII", c => c.String());
            DropColumn("dbo.Tbl_IncidentesAT", "TipoVinculacionII");
            DropColumn("dbo.Tbl_IncidentesAT", "TipoVinculacionIII");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tbl_IncidentesAT", "TipoVinculacionIII", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "TipoVinculacionII", c => c.Boolean(nullable: false));
            DropColumn("dbo.Tbl_IncidentesAT", "boTipoVinculacionIII");
            DropColumn("dbo.Tbl_IncidentesAT", "boTipoVinculacionII");
        }
    }
}
