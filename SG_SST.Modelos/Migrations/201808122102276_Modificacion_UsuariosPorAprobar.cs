namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modificacion_UsuariosPorAprobar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_UsuariosParaAprobar", "FK_Id_EstadoUsuario", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_UsuariosParaAprobar", "FK_Id_EstadoUsuario");
        }
    }
}
