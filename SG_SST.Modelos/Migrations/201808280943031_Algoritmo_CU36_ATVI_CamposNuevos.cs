namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Algoritmo_CU36_ATVI_CamposNuevos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_IncidentesAT6", "ExplosivosCantidadVI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT6", "GasesUnidadMedidaVI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT6", "VoltajeElectricoCantidadVI", c => c.String());
            DropColumn("dbo.Tbl_IncidentesAT6", "ExplosivosUnidadMedidaVI2");
            DropColumn("dbo.Tbl_IncidentesAT6", "ExplosivosUnidadMedidaV2");
            DropColumn("dbo.Tbl_IncidentesAT6", "VoltajeElectricoUnidadMedidaV2");
            DropColumn("dbo.Tbl_IncidentesAT6", "UnidadMedidaVI");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tbl_IncidentesAT6", "UnidadMedidaVI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT6", "VoltajeElectricoUnidadMedidaV2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT6", "ExplosivosUnidadMedidaV2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT6", "ExplosivosUnidadMedidaVI2", c => c.String());
            DropColumn("dbo.Tbl_IncidentesAT6", "VoltajeElectricoCantidadVI");
            DropColumn("dbo.Tbl_IncidentesAT6", "GasesUnidadMedidaVI");
            DropColumn("dbo.Tbl_IncidentesAT6", "ExplosivosCantidadVI");
        }
    }
}
