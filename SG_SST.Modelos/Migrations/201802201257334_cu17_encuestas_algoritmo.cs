namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cu17_encuestas_algoritmo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_ComunicacionesInternas", "BuildFormHtml", c => c.String());
            AddColumn("dbo.Tbl_ComunicacionesInternas", "webControls", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_ComunicacionesInternas", "webControls");
            DropColumn("dbo.Tbl_ComunicacionesInternas", "BuildFormHtml");
        }
    }
}
