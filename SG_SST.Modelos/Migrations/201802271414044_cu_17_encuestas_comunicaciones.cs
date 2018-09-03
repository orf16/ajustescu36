namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cu_17_encuestas_comunicaciones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_ComunicacionesEncuestasPreguntas",
                c => new
                    {
                        pk_id_pregunta = c.Int(nullable: false, identity: true),
                        fk_pk_id_encuesta = c.Int(nullable: false),
                        pregunta = c.String(),
                        control = c.String(),
                    })
                .PrimaryKey(t => t.pk_id_pregunta);
            
            AddColumn("dbo.Tbl_ComunicacionesEncuestas", "pregunta", c => c.String());
            AddColumn("dbo.Tbl_ComunicacionesEncuestas", "respuesta", c => c.String());
            AddColumn("dbo.Tbl_ComunicacionesEncuestas", "control", c => c.String());
            DropColumn("dbo.Tbl_ComunicacionesEncuestas", "contenido");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tbl_ComunicacionesEncuestas", "contenido", c => c.String());
            DropColumn("dbo.Tbl_ComunicacionesEncuestas", "control");
            DropColumn("dbo.Tbl_ComunicacionesEncuestas", "respuesta");
            DropColumn("dbo.Tbl_ComunicacionesEncuestas", "pregunta");
            DropTable("dbo.Tbl_ComunicacionesEncuestasPreguntas");
        }
    }
}
