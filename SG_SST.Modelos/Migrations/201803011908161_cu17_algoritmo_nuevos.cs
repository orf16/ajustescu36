namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cu17_algoritmo_nuevos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_ComunicacionesEncuestas", "pk_id_encuesta_publicada", c => c.Int(nullable: false));
            AddColumn("dbo.Tbl_ComunicacionesExternas", "esEncuesta", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_ComunicacionesInternas", "vigencia", c => c.String());
            AddColumn("dbo.Tbl_ComunicadosAPP", "esEncuesta", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_ComunicadosAPP", "esEncuesta");
            DropColumn("dbo.Tbl_ComunicacionesInternas", "vigencia");
            DropColumn("dbo.Tbl_ComunicacionesExternas", "esEncuesta");
            DropColumn("dbo.Tbl_ComunicacionesEncuestas", "pk_id_encuesta_publicada");
        }
    }
}
