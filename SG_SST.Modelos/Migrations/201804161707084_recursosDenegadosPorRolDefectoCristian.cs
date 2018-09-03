namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recursosDenegadosPorRolDefectoCristian : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_RecursoDenegadoPorRolDefault",
                c => new
                    {
                        Pk_Id_RecursoDenegadoPorRolDefault = c.Int(nullable: false, identity: true),
                        Fk_Id_RolSistema = c.Int(nullable: false),
                        Fk_Id_Recurso = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Pk_Id_RecursoDenegadoPorRolDefault)
                .ForeignKey("dbo.Tbl_RecursosSistema", t => t.Fk_Id_Recurso, cascadeDelete: true)
                .ForeignKey("dbo.Tbl_RolesSistema", t => t.Fk_Id_RolSistema, cascadeDelete: true)
                .Index(t => t.Fk_Id_RolSistema)
                .Index(t => t.Fk_Id_Recurso);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tbl_RecursoDenegadoPorRolDefault", "Fk_Id_RolSistema", "dbo.Tbl_RolesSistema");
            DropForeignKey("dbo.Tbl_RecursoDenegadoPorRolDefault", "Fk_Id_Recurso", "dbo.Tbl_RecursosSistema");
            DropIndex("dbo.Tbl_RecursoDenegadoPorRolDefault", new[] { "Fk_Id_Recurso" });
            DropIndex("dbo.Tbl_RecursoDenegadoPorRolDefault", new[] { "Fk_Id_RolSistema" });
            DropTable("dbo.Tbl_RecursoDenegadoPorRolDefault");
        }
    }
}
