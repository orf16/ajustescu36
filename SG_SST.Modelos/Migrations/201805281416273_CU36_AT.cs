namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CU36_AT : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_IncidentesAT", "ExplosivosUnidadMedidaV2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "GasesUnidadVI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "ExplosivosUnidadMedidaVI2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "SustanciaVI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "TemperaturaVI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "VoltajeElectricoUnidadMedidaV2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "TipoIdentRepresentanteARLIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "RepresentanteARLNombresIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "CargoRepresentanteARLIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "NumIdentRepresentanteARLIXIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "TipoIdentEspecialistaSGSSTIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "EspecialistaSGSSTNombresIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "CargoEspecialistaSGSSTIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "NumIdentEspecialistaSGSSTIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "FechaVerificacionXII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "myFile1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "myFile2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "myFile3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "myFile4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "myFile5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "myFile6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "myFile7", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "myFile8", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "myFile9", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "myFile10", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "myFile11", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "myFile12", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "myFile13", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "RecomendacionesCargoXI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "BasicasT3X", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "VelocidadUnidadMedidaVI", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_IncidentesAT", "VelocidadUnidadMedidaVI");
            DropColumn("dbo.Tbl_IncidentesAT", "BasicasT3X");
            DropColumn("dbo.Tbl_IncidentesAT", "RecomendacionesCargoXI");
            DropColumn("dbo.Tbl_IncidentesAT", "myFile13");
            DropColumn("dbo.Tbl_IncidentesAT", "myFile12");
            DropColumn("dbo.Tbl_IncidentesAT", "myFile11");
            DropColumn("dbo.Tbl_IncidentesAT", "myFile10");
            DropColumn("dbo.Tbl_IncidentesAT", "myFile9");
            DropColumn("dbo.Tbl_IncidentesAT", "myFile8");
            DropColumn("dbo.Tbl_IncidentesAT", "myFile7");
            DropColumn("dbo.Tbl_IncidentesAT", "myFile6");
            DropColumn("dbo.Tbl_IncidentesAT", "myFile5");
            DropColumn("dbo.Tbl_IncidentesAT", "myFile4");
            DropColumn("dbo.Tbl_IncidentesAT", "myFile3");
            DropColumn("dbo.Tbl_IncidentesAT", "myFile2");
            DropColumn("dbo.Tbl_IncidentesAT", "myFile1");
            DropColumn("dbo.Tbl_IncidentesAT", "FechaVerificacionXII");
            DropColumn("dbo.Tbl_IncidentesAT", "NumIdentEspecialistaSGSSTIX");
            DropColumn("dbo.Tbl_IncidentesAT", "CargoEspecialistaSGSSTIX");
            DropColumn("dbo.Tbl_IncidentesAT", "EspecialistaSGSSTNombresIX");
            DropColumn("dbo.Tbl_IncidentesAT", "TipoIdentEspecialistaSGSSTIX");
            DropColumn("dbo.Tbl_IncidentesAT", "NumIdentRepresentanteARLIXIX");
            DropColumn("dbo.Tbl_IncidentesAT", "CargoRepresentanteARLIX");
            DropColumn("dbo.Tbl_IncidentesAT", "RepresentanteARLNombresIX");
            DropColumn("dbo.Tbl_IncidentesAT", "TipoIdentRepresentanteARLIX");
            DropColumn("dbo.Tbl_IncidentesAT", "VoltajeElectricoUnidadMedidaV2");
            DropColumn("dbo.Tbl_IncidentesAT", "TemperaturaVI");
            DropColumn("dbo.Tbl_IncidentesAT", "SustanciaVI");
            DropColumn("dbo.Tbl_IncidentesAT", "ExplosivosUnidadMedidaVI2");
            DropColumn("dbo.Tbl_IncidentesAT", "GasesUnidadVI");
            DropColumn("dbo.Tbl_IncidentesAT", "ExplosivosUnidadMedidaV2");
        }
    }
}
