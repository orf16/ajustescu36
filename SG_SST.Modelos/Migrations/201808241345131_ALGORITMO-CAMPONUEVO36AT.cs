namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ALGORITMOCAMPONUEVO36AT : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_IncidentesAT4", "EspecifiqueLaborHabitual", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_IncidentesAT4", "EspecifiqueLaborHabitual");
        }
    }
}
