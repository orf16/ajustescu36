namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CAMBIOS_EL36ALGORITMO : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_IncidentesEL2", "CodigoDeptoTrabajadorIII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "DeptoTrabajadorIII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CodigoMncpioTrabajadorIII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "MncpioTrabajadorIII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "ObservacionesIV", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "DireccionCentroTrabajoII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "DiurnoIV2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "NocturnoIV2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "MixtoIV2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "TurnosIV2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "NombresApellidosV5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "NoTrabajadoresCargos", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CodigoCieCIEV", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "DiagnosticosCIEV", c => c.String());
            DropColumn("dbo.Tbl_IncidentesEL", "CodigoDeptoTrabajadorIII");
            DropColumn("dbo.Tbl_IncidentesEL", "DeptoTrabajadorIII");
            DropColumn("dbo.Tbl_IncidentesEL", "CodigoMncpioTrabajadorIII");
            DropColumn("dbo.Tbl_IncidentesEL", "MncpioTrabajadorIII");
            DropColumn("dbo.Tbl_IncidentesEL", "ObservacionesIV");
            DropColumn("dbo.Tbl_IncidentesEL", "DireccionCentroTrabajoII");
            DropColumn("dbo.Tbl_IncidentesEL", "DiurnoIV2");
            DropColumn("dbo.Tbl_IncidentesEL", "NocturnoIV2");
            DropColumn("dbo.Tbl_IncidentesEL", "MixtoIV2");
            DropColumn("dbo.Tbl_IncidentesEL", "TurnosIV2");
            DropColumn("dbo.Tbl_IncidentesEL", "NombresApellidosV5");
            DropColumn("dbo.Tbl_IncidentesEL", "NoTrabajadoresCargos");
            DropColumn("dbo.Tbl_IncidentesEL", "CodigoCieCIEV");
            DropColumn("dbo.Tbl_IncidentesEL", "DiagnosticosCIEV");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tbl_IncidentesEL", "DiagnosticosCIEV", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "CodigoCieCIEV", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "NoTrabajadoresCargos", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "NombresApellidosV5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TurnosIV2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "MixtoIV2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "NocturnoIV2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "DiurnoIV2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "DireccionCentroTrabajoII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "ObservacionesIV", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "MncpioTrabajadorIII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "CodigoMncpioTrabajadorIII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "DeptoTrabajadorIII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "CodigoDeptoTrabajadorIII", c => c.String());
            DropColumn("dbo.Tbl_IncidentesEL2", "DiagnosticosCIEV");
            DropColumn("dbo.Tbl_IncidentesEL2", "CodigoCieCIEV");
            DropColumn("dbo.Tbl_IncidentesEL2", "NoTrabajadoresCargos");
            DropColumn("dbo.Tbl_IncidentesEL2", "NombresApellidosV5");
            DropColumn("dbo.Tbl_IncidentesEL2", "TurnosIV2");
            DropColumn("dbo.Tbl_IncidentesEL2", "MixtoIV2");
            DropColumn("dbo.Tbl_IncidentesEL2", "NocturnoIV2");
            DropColumn("dbo.Tbl_IncidentesEL2", "DiurnoIV2");
            DropColumn("dbo.Tbl_IncidentesEL2", "DireccionCentroTrabajoII");
            DropColumn("dbo.Tbl_IncidentesEL2", "ObservacionesIV");
            DropColumn("dbo.Tbl_IncidentesEL2", "MncpioTrabajadorIII");
            DropColumn("dbo.Tbl_IncidentesEL2", "CodigoMncpioTrabajadorIII");
            DropColumn("dbo.Tbl_IncidentesEL2", "DeptoTrabajadorIII");
            DropColumn("dbo.Tbl_IncidentesEL2", "CodigoDeptoTrabajadorIII");
        }
    }
}
