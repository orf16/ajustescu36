namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nuevaMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_vul_Personas", "Fk_Sede", c => c.String());
            AddColumn("dbo.Tbl_vul_Recursos", "Fk_Sede", c => c.String());
            AddColumn("dbo.Tbl_vul_SistemasProcesos", "Fk_Sede", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_vul_SistemasProcesos", "Fk_Sede");
            DropColumn("dbo.Tbl_vul_Recursos", "Fk_Sede");
            DropColumn("dbo.Tbl_vul_Personas", "Fk_Sede");
        }
    }
}
