namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccidentesAT_Y_Enfermedad_Laboral_CU36 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_IncidentesAT", "st_DepartamentoII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "st_MunicipioII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "TipoIdentificacionIII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "MurioTrabajadorIV", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FechaIngresoIV", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "CodigoCie5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "TareasCargo2IV", c => c.String());
            AlterColumn("dbo.Tbl_IncidentesAT", "LaborHabitualIV", c => c.String());
            DropColumn("dbo.Tbl_IncidentesAT", "pk_DepartamentoII");
            DropColumn("dbo.Tbl_IncidentesAT", "pk_MunicipioII");
            DropColumn("dbo.Tbl_IncidentesAT", "LaborHabitualIVS");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tbl_IncidentesAT", "LaborHabitualIVS", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "pk_MunicipioII", c => c.Int(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "pk_DepartamentoII", c => c.Int(nullable: false));
            AlterColumn("dbo.Tbl_IncidentesAT", "LaborHabitualIV", c => c.Boolean(nullable: false));
            DropColumn("dbo.Tbl_IncidentesEL", "TareasCargo2IV");
            DropColumn("dbo.Tbl_IncidentesEL", "CodigoCie5");
            DropColumn("dbo.Tbl_IncidentesEL", "FechaIngresoIV");
            DropColumn("dbo.Tbl_IncidentesEL", "MurioTrabajadorIV");
            DropColumn("dbo.Tbl_IncidentesAT", "TipoIdentificacionIII");
            DropColumn("dbo.Tbl_IncidentesAT", "st_MunicipioII");
            DropColumn("dbo.Tbl_IncidentesAT", "st_DepartamentoII");
        }
    }
}
