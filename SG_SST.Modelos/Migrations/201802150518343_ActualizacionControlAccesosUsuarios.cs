namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActualizacionControlAccesosUsuarios : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tbl_PermisosDenegadosPorRol", "Fk_Id_PermisoSistema", "dbo.Tbl_PermisosSistema");
            DropForeignKey("dbo.Tbl_PermisosDenegadosPorRol", "Fk_Id_RolSistema", "dbo.Tbl_RolesSistema");
            DropIndex("dbo.Tbl_PermisosDenegadosPorRol", new[] { "Fk_Id_PermisoSistema" });
            DropIndex("dbo.Tbl_PermisosDenegadosPorRol", new[] { "Fk_Id_RolSistema" });
            AddColumn("dbo.Tbl_RecursosDenegadosPorRol", "Fk_Id_Empresa", c => c.Int(nullable: false));
            CreateIndex("dbo.Tbl_RecursosDenegadosPorRol", "Fk_Id_Empresa");
            AddForeignKey("dbo.Tbl_RecursosDenegadosPorRol", "Fk_Id_Empresa", "dbo.Tbl_Empresa", "Pk_Id_Empresa", cascadeDelete: true);
            DropTable("dbo.Tbl_PermisosDenegadosPorRol");
            DropTable("dbo.Tbl_PermisosSistema");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tbl_PermisosSistema",
                c => new
                    {
                        Pk_Id_PermisoSistema = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Controlador = c.String(),
                        Accion = c.String(),
                        Vista = c.String(),
                    })
                .PrimaryKey(t => t.Pk_Id_PermisoSistema);
            
            CreateTable(
                "dbo.Tbl_PermisosDenegadosPorRol",
                c => new
                    {
                        Pk_Id_PermisoDenegadoPorRol = c.Int(nullable: false, identity: true),
                        Fk_Id_PermisoSistema = c.Int(nullable: false),
                        Fk_Id_RolSistema = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Pk_Id_PermisoDenegadoPorRol);
            
            DropForeignKey("dbo.Tbl_RecursosDenegadosPorRol", "Fk_Id_Empresa", "dbo.Tbl_Empresa");
            DropIndex("dbo.Tbl_RecursosDenegadosPorRol", new[] { "Fk_Id_Empresa" });
            DropColumn("dbo.Tbl_RecursosDenegadosPorRol", "Fk_Id_Empresa");
            CreateIndex("dbo.Tbl_PermisosDenegadosPorRol", "Fk_Id_RolSistema");
            CreateIndex("dbo.Tbl_PermisosDenegadosPorRol", "Fk_Id_PermisoSistema");
            AddForeignKey("dbo.Tbl_PermisosDenegadosPorRol", "Fk_Id_RolSistema", "dbo.Tbl_RolesSistema", "Pk_Id_RolSistema", cascadeDelete: true);
            AddForeignKey("dbo.Tbl_PermisosDenegadosPorRol", "Fk_Id_PermisoSistema", "dbo.Tbl_PermisosSistema", "Pk_Id_PermisoSistema", cascadeDelete: true);
        }
    }
}
