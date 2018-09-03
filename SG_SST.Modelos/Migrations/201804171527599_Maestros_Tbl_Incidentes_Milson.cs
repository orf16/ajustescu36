namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Maestros_Tbl_Incidentes_Milson : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_Actos_Subestandar",
                c => new
                    {
                        PK_Actos_Subestandar = c.Int(nullable: false, identity: true),
                        Descripcion_AS = c.String(),
                    })
                .PrimaryKey(t => t.PK_Actos_Subestandar);
            
            CreateTable(
                "dbo.Tbl_Agente",
                c => new
                    {
                        PK_Agente = c.Int(nullable: false, identity: true),
                        Descripcion_Agente = c.String(),
                    })
                .PrimaryKey(t => t.PK_Agente);
            
            CreateTable(
                "dbo.Tbl_Condiciones_Ambientales_Subestandar",
                c => new
                    {
                        PK_Condiciones_Ambientales_Subestandar = c.Int(nullable: false, identity: true),
                        Descripcion_CAS = c.String(),
                    })
                .PrimaryKey(t => t.PK_Condiciones_Ambientales_Subestandar);
            
            CreateTable(
                "dbo.Tbl_Factores_De_Trabajo",
                c => new
                    {
                        PK_Factores_De_Trabajo = c.Int(nullable: false, identity: true),
                        Descripcion_FDT = c.String(),
                    })
                .PrimaryKey(t => t.PK_Factores_De_Trabajo);
            
            CreateTable(
                "dbo.Tbl_FactoresPersonales",
                c => new
                    {
                        PK_FactoresPersonales = c.Int(nullable: false, identity: true),
                        Descripcion_FP = c.String(),
                    })
                .PrimaryKey(t => t.PK_FactoresPersonales);
            
            CreateTable(
                "dbo.Tbl_Mecanismo",
                c => new
                    {
                        PK_Mecanismo = c.Int(nullable: false, identity: true),
                        Descripcion_Mecanismo = c.String(),
                    })
                .PrimaryKey(t => t.PK_Mecanismo);
            
            CreateTable(
                "dbo.Tbl_PDCA_Corto",
                c => new
                    {
                        PK_PDCA_Corto = c.Int(nullable: false, identity: true),
                        Descripcion_PDCA_Corto = c.String(),
                    })
                .PrimaryKey(t => t.PK_PDCA_Corto);
            
            CreateTable(
                "dbo.Tbl_Sitio_AT",
                c => new
                    {
                        PK_Sitio_AT = c.Int(nullable: false, identity: true),
                        Descripcion_Sitio_AT = c.String(),
                    })
                .PrimaryKey(t => t.PK_Sitio_AT);
            
            CreateTable(
                "dbo.Tbl_Tipo_AT",
                c => new
                    {
                        PK_Tipo_AT = c.Int(nullable: false, identity: true),
                        Descripcion_Tipo_AT = c.String(),
                    })
                .PrimaryKey(t => t.PK_Tipo_AT);
            
            CreateTable(
                "dbo.Tbl_Tipo_De_Lesion",
                c => new
                    {
                        PK_Tipo_De_Lesion = c.Int(nullable: false, identity: true),
                        Descripcion_Tipo_De_Lesion = c.String(),
                    })
                .PrimaryKey(t => t.PK_Tipo_De_Lesion);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tbl_Tipo_De_Lesion");
            DropTable("dbo.Tbl_Tipo_AT");
            DropTable("dbo.Tbl_Sitio_AT");
            DropTable("dbo.Tbl_PDCA_Corto");
            DropTable("dbo.Tbl_Mecanismo");
            DropTable("dbo.Tbl_FactoresPersonales");
            DropTable("dbo.Tbl_Factores_De_Trabajo");
            DropTable("dbo.Tbl_Condiciones_Ambientales_Subestandar");
            DropTable("dbo.Tbl_Agente");
            DropTable("dbo.Tbl_Actos_Subestandar");
        }
    }
}
