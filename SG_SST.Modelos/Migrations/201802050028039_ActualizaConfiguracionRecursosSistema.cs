namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActualizaConfiguracionRecursosSistema : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tbl_RecursosPorRol", "Fk_Id_Recurso", "dbo.Tbl_RecursosSistema");
            DropForeignKey("dbo.Tbl_RecursosPorRol", "Fk_Id_RolSistema", "dbo.Tbl_RolesSistema");
            DropIndex("dbo.Tbl_RecursosPorRol", new[] { "Fk_Id_RolSistema" });
            DropIndex("dbo.Tbl_RecursosPorRol", new[] { "Fk_Id_Recurso" });
            CreateTable(
                "dbo.Tbl_RecursosDenegadosPorRol",
                c => new
                    {
                        Pk_Id_RecursoDenegadoPorRol = c.Int(nullable: false, identity: true),
                        Fk_Id_RolSistema = c.Int(nullable: false),
                        Fk_Id_Recurso = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Pk_Id_RecursoDenegadoPorRol)
                .ForeignKey("dbo.Tbl_RecursosSistema", t => t.Fk_Id_Recurso, cascadeDelete: true)
                .ForeignKey("dbo.Tbl_RolesSistema", t => t.Fk_Id_RolSistema, cascadeDelete: true)
                .Index(t => t.Fk_Id_RolSistema)
                .Index(t => t.Fk_Id_Recurso);
            
            DropTable("dbo.Tbl_RecursosPorRol");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tbl_RecursosPorRol",
                c => new
                    {
                        Pk_Id_RecursoPorRol = c.Int(nullable: false, identity: true),
                        Fk_Id_RolSistema = c.Int(nullable: false),
                        Fk_Id_Recurso = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Pk_Id_RecursoPorRol);
            
            DropForeignKey("dbo.Tbl_RecursosDenegadosPorRol", "Fk_Id_RolSistema", "dbo.Tbl_RolesSistema");
            DropForeignKey("dbo.Tbl_RecursosDenegadosPorRol", "Fk_Id_Recurso", "dbo.Tbl_RecursosSistema");
            DropIndex("dbo.Tbl_RecursosDenegadosPorRol", new[] { "Fk_Id_Recurso" });
            DropIndex("dbo.Tbl_RecursosDenegadosPorRol", new[] { "Fk_Id_RolSistema" });
            DropTable("dbo.Tbl_RecursosDenegadosPorRol");
            CreateIndex("dbo.Tbl_RecursosPorRol", "Fk_Id_Recurso");
            CreateIndex("dbo.Tbl_RecursosPorRol", "Fk_Id_RolSistema");
            AddForeignKey("dbo.Tbl_RecursosPorRol", "Fk_Id_RolSistema", "dbo.Tbl_RolesSistema", "Pk_Id_RolSistema", cascadeDelete: true);
            AddForeignKey("dbo.Tbl_RecursosPorRol", "Fk_Id_Recurso", "dbo.Tbl_RecursosSistema", "Pk_Id_RecursoSistema", cascadeDelete: true);
        }
    }
}
