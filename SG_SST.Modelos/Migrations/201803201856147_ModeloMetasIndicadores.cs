namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModeloMetasIndicadores : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_Indicador",
                c => new
                    {
                        PK_Id_Indicador = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Tipo = c.String(),
                        Unidad = c.String(),
                        Frecuencia = c.String(),
                    })
                .PrimaryKey(t => t.PK_Id_Indicador);
            
            CreateTable(
                "dbo.Tbl_MetaIndicador",
                c => new
                    {
                        PK_Id_MetaIndicador = c.Int(nullable: false, identity: true),
                        FK_Empresa = c.Int(nullable: false),
                        FK_Indicador = c.Int(nullable: false),
                        ValorMeta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValorRojo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValorAmarillo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValorVerde = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PK_Id_MetaIndicador)
                .ForeignKey("dbo.Tbl_Empresa", t => t.FK_Empresa, cascadeDelete: true)
                .ForeignKey("dbo.Tbl_Indicador", t => t.FK_Indicador, cascadeDelete: true)
                .Index(t => t.FK_Empresa)
                .Index(t => t.FK_Indicador);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tbl_MetaIndicador", "FK_Indicador", "dbo.Tbl_Indicador");
            DropForeignKey("dbo.Tbl_MetaIndicador", "FK_Empresa", "dbo.Tbl_Empresa");
            DropIndex("dbo.Tbl_MetaIndicador", new[] { "FK_Indicador" });
            DropIndex("dbo.Tbl_MetaIndicador", new[] { "FK_Empresa" });
            DropTable("dbo.Tbl_MetaIndicador");
            DropTable("dbo.Tbl_Indicador");
        }
    }
}
