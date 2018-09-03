namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnfermedadLaboralUC36Algoritmos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_IncidentesAT", "TiempoUsoVIA", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaEjeMesVII2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FechaEjeDiaVII2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "MedidasPreventivasVII3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "ResponsableImplementacionVII3", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_IncidentesEL2", "ResponsableImplementacionVII3");
            DropColumn("dbo.Tbl_IncidentesEL2", "MedidasPreventivasVII3");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaEjeDiaVII2");
            DropColumn("dbo.Tbl_IncidentesEL2", "FechaEjeMesVII2");
            DropColumn("dbo.Tbl_IncidentesAT", "TiempoUsoVIA");
        }
    }
}
