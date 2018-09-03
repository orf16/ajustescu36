namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cu_36masmascampos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tbl_IncidentesAT", "TipoIdentEncargadoPSOIX", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "TipoIdentCOPASOIX", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "TipoIdentEncargadosPSOIX", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "TipoIdentParticipanteIX", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "TipoIdentAnalisisIX", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tbl_IncidentesAT", "TipoIdentAnalisisIX", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "TipoIdentParticipanteIX", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "TipoIdentEncargadosPSOIX", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "TipoIdentCOPASOIX", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "TipoIdentEncargadoPSOIX", c => c.Boolean(nullable: false));
        }
    }
}
