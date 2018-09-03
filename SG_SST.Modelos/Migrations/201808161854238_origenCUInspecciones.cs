namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class origenCUInspecciones : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_Incidentes", "origenIncidente", c => c.String(maxLength: 12));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_Incidentes", "origenIncidente");
        }
    }
}