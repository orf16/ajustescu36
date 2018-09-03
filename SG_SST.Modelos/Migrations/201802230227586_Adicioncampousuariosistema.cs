namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adicioncampousuariosistema : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_UsuarioSistema", "FK_Id_EstadoUsuario", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_UsuarioSistema", "FK_Id_EstadoUsuario");
        }
    }
}
