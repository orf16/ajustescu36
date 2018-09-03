namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EvaluacionStanderesMinimosCampoElaboraPor : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tbl_Empresas_Evaluar", "Elaborado_Por", c => c.String(maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tbl_Empresas_Evaluar", "Elaborado_Por", c => c.String(maxLength: 20));
        }
    }
}
