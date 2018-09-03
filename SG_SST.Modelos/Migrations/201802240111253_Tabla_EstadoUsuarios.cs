namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tabla_EstadoUsuarios : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_UsuarioEstados",
                c => new
                    {
                        Pk_Id_UsuarioEstados = c.Int(nullable: false, identity: true),
                        EstadoUsuario = c.String(),
                    })
                .PrimaryKey(t => t.Pk_Id_UsuarioEstados);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tbl_UsuarioEstados");
        }
    }
}
