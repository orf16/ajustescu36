namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambiosOncloud : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_RecursosDenegadosPorRol", "DocumentoAsesorSST", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_RecursosDenegadosPorRol", "DocumentoAsesorSST");
        }
    }
}
