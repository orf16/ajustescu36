namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adicion_IntentosRecuperarclave : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_UsuarioSistema", "IntentosRecuperarClave", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_UsuarioSistema", "IntentosRecuperarClave");
        }
    }
}
