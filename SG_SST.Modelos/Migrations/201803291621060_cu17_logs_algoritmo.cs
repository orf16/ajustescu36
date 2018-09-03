namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cu17_logs_algoritmo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_ComunicacionesLog", "fecha_envio", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_ComunicacionesLog", "fecha_envio");
        }
    }
}
