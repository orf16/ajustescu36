namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificacionEsquemaOrganizacional : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_Eme_EsquemaOrganizacional", "planAyudaArchivo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_Eme_EsquemaOrganizacional", "planAyudaArchivo");
        }
    }
}
