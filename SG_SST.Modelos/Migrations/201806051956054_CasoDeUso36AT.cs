namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CasoDeUso36AT : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_IncidentesAT", "TipoIdentificacionXIII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "NombresXIII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "CargoXIII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "NumeroIdentificacionXIII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "MedidasIntervencionXIII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "FechaVerificacionXIII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "ObservacionesXIII", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_IncidentesAT", "ObservacionesXIII");
            DropColumn("dbo.Tbl_IncidentesAT", "FechaVerificacionXIII");
            DropColumn("dbo.Tbl_IncidentesAT", "MedidasIntervencionXIII");
            DropColumn("dbo.Tbl_IncidentesAT", "NumeroIdentificacionXIII");
            DropColumn("dbo.Tbl_IncidentesAT", "CargoXIII");
            DropColumn("dbo.Tbl_IncidentesAT", "NombresXIII");
            DropColumn("dbo.Tbl_IncidentesAT", "TipoIdentificacionXIII");
        }
    }
}
