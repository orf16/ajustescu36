namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActualizarEstructuraRoles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_UsuarioSistema", "Bloqueado", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_RolesSistema", "TipoRolSistema", c => c.Int(nullable: false));
            DropColumn("dbo.Tbl_RolesSistema", "Bloqueado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tbl_RolesSistema", "Bloqueado", c => c.Boolean(nullable: false));
            DropColumn("dbo.Tbl_RolesSistema", "TipoRolSistema");
            DropColumn("dbo.Tbl_UsuarioSistema", "Bloqueado");
        }
    }
}
