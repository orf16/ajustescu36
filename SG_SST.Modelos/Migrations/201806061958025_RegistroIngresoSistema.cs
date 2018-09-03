namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegistroIngresoSistema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_RegistroIngresoSistema",
                c => new
                    {
                        PK_Id_RegistroIngresoSistema = c.Int(nullable: false, identity: true),
                        FK_Empresa = c.Int(nullable: false),
                        FK_UsuarioSistema = c.Int(nullable: false),
                        FechaTransaccion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PK_Id_RegistroIngresoSistema)
                .ForeignKey("dbo.Tbl_Empresa", t => t.FK_Empresa, cascadeDelete: true)
                .ForeignKey("dbo.Tbl_UsuarioSistema", t => t.FK_UsuarioSistema, cascadeDelete: true)
                .Index(t => t.FK_Empresa)
                .Index(t => t.FK_UsuarioSistema);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tbl_RegistroIngresoSistema", "FK_UsuarioSistema", "dbo.Tbl_UsuarioSistema");
            DropForeignKey("dbo.Tbl_RegistroIngresoSistema", "FK_Empresa", "dbo.Tbl_Empresa");
            DropIndex("dbo.Tbl_RegistroIngresoSistema", new[] { "FK_UsuarioSistema" });
            DropIndex("dbo.Tbl_RegistroIngresoSistema", new[] { "FK_Empresa" });
            DropTable("dbo.Tbl_RegistroIngresoSistema");
        }
    }
}
