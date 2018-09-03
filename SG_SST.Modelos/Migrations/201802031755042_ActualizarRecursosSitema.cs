namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActualizarRecursosSitema : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_RecursosSistema", "CodRecursoSistemaPadre", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_RecursosSistema", "CodRecursoSistemaPadre");
        }
    }
}
