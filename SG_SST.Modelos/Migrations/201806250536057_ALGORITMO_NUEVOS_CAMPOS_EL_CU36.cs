namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ALGORITMO_NUEVOS_CAMPOS_EL_CU36 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_IncidentesAT", "tempTipoIdentificacionIII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionVIII1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionVIII2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionVIII3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionVIII4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionVIII5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionVIII6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionVIII7", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionVIII8", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionXI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "ObservacionesX", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesEL2", "MedidasIntervencionX", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesEL2", "MedidasIntervencionXI", c => c.String());
            DropColumn("dbo.Tbl_IncidentesAT", "TipoIdentificacionIII");
            DropColumn("dbo.Tbl_IncidentesEL2", "TipoIdentificacionVIII1");
            DropColumn("dbo.Tbl_IncidentesEL2", "TipoIdentificacionVIII2");
            DropColumn("dbo.Tbl_IncidentesEL2", "TipoIdentificacionVIII3");
            DropColumn("dbo.Tbl_IncidentesEL2", "TipoIdentificacionVIII4");
            DropColumn("dbo.Tbl_IncidentesEL2", "TipoIdentificacionVIII5");
            DropColumn("dbo.Tbl_IncidentesEL2", "TipoIdentificacionVIII6");
            DropColumn("dbo.Tbl_IncidentesEL2", "TipoIdentificacionVIII7");
            DropColumn("dbo.Tbl_IncidentesEL2", "TipoIdentificacionVIII8");
            DropColumn("dbo.Tbl_IncidentesEL2", "TipoIdentificacionIX");
            DropColumn("dbo.Tbl_IncidentesEL2", "TipoIdentificacionX");
            DropColumn("dbo.Tbl_IncidentesEL2", "TipoIdentificacionXI");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tbl_IncidentesEL2", "TipoIdentificacionXI", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL2", "TipoIdentificacionX", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL2", "TipoIdentificacionIX", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesEL2", "TipoIdentificacionVIII8", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TipoIdentificacionVIII7", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TipoIdentificacionVIII6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TipoIdentificacionVIII5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TipoIdentificacionVIII4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TipoIdentificacionVIII3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TipoIdentificacionVIII2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TipoIdentificacionVIII1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "TipoIdentificacionIII", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesEL2", "MedidasIntervencionXI", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesEL2", "MedidasIntervencionX", c => c.Boolean(nullable: false));
            DropColumn("dbo.Tbl_IncidentesEL2", "ObservacionesX");
            DropColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionXI");
            DropColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionX");
            DropColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionIX");
            DropColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionVIII8");
            DropColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionVIII7");
            DropColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionVIII6");
            DropColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionVIII5");
            DropColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionVIII4");
            DropColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionVIII3");
            DropColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionVIII2");
            DropColumn("dbo.Tbl_IncidentesEL2", "tempTipoIdentificacionVIII1");
            DropColumn("dbo.Tbl_IncidentesAT", "tempTipoIdentificacionIII");
        }
    }
}
