namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cu_36_algoritmo_radio_buttons : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_IncidentesAT", "boIncidente", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "boAccidenteTrabajo", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "boLeve", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "boGrave", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "boMortal", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "boDiurnoIII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "boNocturnoIII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "boMixtoIII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "boTurnosIII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "SegundoNombreIII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "CodigoOcupacionIII", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "boDiaSemanaIV", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "MarcaVI", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "textfield74", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "AnalisisNombresIX", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "CodActFactoresPersonalesVII2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesAT", "ActFactoresPersonalesVII2", c => c.String());
            DropColumn("dbo.Tbl_IncidentesAT", "Incidente");
            DropColumn("dbo.Tbl_IncidentesAT", "AccidenteTrabajo");
            DropColumn("dbo.Tbl_IncidentesAT", "Leve");
            DropColumn("dbo.Tbl_IncidentesAT", "Grave");
            DropColumn("dbo.Tbl_IncidentesAT", "Mortal");
            DropColumn("dbo.Tbl_IncidentesAT", "pk_ActEconoCentroTrabajoII");
            DropColumn("dbo.Tbl_IncidentesAT", "DiurnoIII");
            DropColumn("dbo.Tbl_IncidentesAT", "NocturnoIII");
            DropColumn("dbo.Tbl_IncidentesAT", "MixtoIII");
            DropColumn("dbo.Tbl_IncidentesAT", "TurnosIII");
            DropColumn("dbo.Tbl_IncidentesAT", "LunesIV");
            DropColumn("dbo.Tbl_IncidentesAT", "MartesIV");
            DropColumn("dbo.Tbl_IncidentesAT", "MiercolesIV");
            DropColumn("dbo.Tbl_IncidentesAT", "JuevesIV");
            DropColumn("dbo.Tbl_IncidentesAT", "ViernesIV");
            DropColumn("dbo.Tbl_IncidentesAT", "SabadoIV");
            DropColumn("dbo.Tbl_IncidentesAT", "DomingoIV");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tbl_IncidentesAT", "DomingoIV", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "SabadoIV", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "ViernesIV", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "JuevesIV", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "MiercolesIV", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "MartesIV", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "LunesIV", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "TurnosIII", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "MixtoIII", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "NocturnoIII", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "DiurnoIII", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "pk_ActEconoCentroTrabajoII", c => c.Int(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "Mortal", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "Grave", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "Leve", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "AccidenteTrabajo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IncidentesAT", "Incidente", c => c.Boolean(nullable: false));
            DropColumn("dbo.Tbl_IncidentesAT", "ActFactoresPersonalesVII2");
            DropColumn("dbo.Tbl_IncidentesAT", "CodActFactoresPersonalesVII2");
            DropColumn("dbo.Tbl_IncidentesAT", "AnalisisNombresIX");
            DropColumn("dbo.Tbl_IncidentesAT", "textfield74");
            DropColumn("dbo.Tbl_IncidentesAT", "MarcaVI");
            DropColumn("dbo.Tbl_IncidentesAT", "boDiaSemanaIV");
            DropColumn("dbo.Tbl_IncidentesAT", "CodigoOcupacionIII");
            DropColumn("dbo.Tbl_IncidentesAT", "SegundoNombreIII");
            DropColumn("dbo.Tbl_IncidentesAT", "boTurnosIII");
            DropColumn("dbo.Tbl_IncidentesAT", "boMixtoIII");
            DropColumn("dbo.Tbl_IncidentesAT", "boNocturnoIII");
            DropColumn("dbo.Tbl_IncidentesAT", "boDiurnoIII");
            DropColumn("dbo.Tbl_IncidentesAT", "boMortal");
            DropColumn("dbo.Tbl_IncidentesAT", "boGrave");
            DropColumn("dbo.Tbl_IncidentesAT", "boLeve");
            DropColumn("dbo.Tbl_IncidentesAT", "boAccidenteTrabajo");
            DropColumn("dbo.Tbl_IncidentesAT", "boIncidente");
        }
    }
}
