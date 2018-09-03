namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cu_17_app_nuevocampo_enlaces : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_ComunicadosAPP", "Enlaces", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_ComunicadosAPP", "Enlaces");
        }
    }
}
