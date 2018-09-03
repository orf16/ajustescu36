namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CAMBIOCAMPOSEL2_ALGORITMOS : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_IncidentesEL", "BooEsfuerzoBrazosManos1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "BooCauRelPrevVI13", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "CauRelPrevVI13", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "BooCauRelPrevVI14", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "CauRelPrevVI14", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "BooCauRelPrevVI15", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "CauRelPrevVI15", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "myFile1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "myFile2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "myFile3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "myFile4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "myFile5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "myFile6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "myFile7", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "myFile8", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "myFile9", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "myFile10", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "myFile11", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "myFile12", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "NivelRiesgoVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "ViaEntradaVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "NivelRiesgoV4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "ViaEntradaV4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "FormacionInformacionIV", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "ProteccionColectivaIV", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "EPPIV", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "DisenoPuestoTrabajoIV", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL", "tempOrganizacionTrabajoIV", c => c.String());
            DropColumn("dbo.Tbl_IncidentesEL2", "BooEsfuerzoBrazosManos1");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooCauRelPrevVI13");
            DropColumn("dbo.Tbl_IncidentesEL2", "CauRelPrevVI13");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooCauRelPrevVI14");
            DropColumn("dbo.Tbl_IncidentesEL2", "CauRelPrevVI14");
            DropColumn("dbo.Tbl_IncidentesEL2", "BooCauRelPrevVI15");
            DropColumn("dbo.Tbl_IncidentesEL2", "CauRelPrevVI15");
            DropColumn("dbo.Tbl_IncidentesEL2", "myFile1");
            DropColumn("dbo.Tbl_IncidentesEL2", "myFile2");
            DropColumn("dbo.Tbl_IncidentesEL2", "myFile3");
            DropColumn("dbo.Tbl_IncidentesEL2", "myFile4");
            DropColumn("dbo.Tbl_IncidentesEL2", "myFile5");
            DropColumn("dbo.Tbl_IncidentesEL2", "myFile6");
            DropColumn("dbo.Tbl_IncidentesEL2", "myFile7");
            DropColumn("dbo.Tbl_IncidentesEL2", "myFile8");
            DropColumn("dbo.Tbl_IncidentesEL2", "myFile9");
            DropColumn("dbo.Tbl_IncidentesEL2", "myFile10");
            DropColumn("dbo.Tbl_IncidentesEL2", "myFile11");
            DropColumn("dbo.Tbl_IncidentesEL2", "myFile12");
            DropColumn("dbo.Tbl_IncidentesEL2", "NivelRiesgoVI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "ViaEntradaVI1");
            DropColumn("dbo.Tbl_IncidentesEL2", "NivelRiesgoV4");
            DropColumn("dbo.Tbl_IncidentesEL2", "ViaEntradaV4");
            DropColumn("dbo.Tbl_IncidentesEL2", "FormacionInformacionIV");
            DropColumn("dbo.Tbl_IncidentesEL2", "ProteccionColectivaIV");
            DropColumn("dbo.Tbl_IncidentesEL2", "EPPIV");
            DropColumn("dbo.Tbl_IncidentesEL2", "DisenoPuestoTrabajoIV");
            DropColumn("dbo.Tbl_IncidentesEL2", "tempOrganizacionTrabajoIV");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tbl_IncidentesEL2", "tempOrganizacionTrabajoIV", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "DisenoPuestoTrabajoIV", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "EPPIV", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "ProteccionColectivaIV", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "FormacionInformacionIV", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "ViaEntradaV4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "NivelRiesgoV4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "ViaEntradaVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "NivelRiesgoVI1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "myFile12", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "myFile11", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "myFile10", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "myFile9", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "myFile8", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "myFile7", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "myFile6", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "myFile5", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "myFile4", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "myFile3", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "myFile2", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "myFile1", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CauRelPrevVI15", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooCauRelPrevVI15", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CauRelPrevVI14", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooCauRelPrevVI14", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "CauRelPrevVI13", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooCauRelPrevVI13", c => c.String());
            AddColumn("dbo.Tbl_IncidentesEL2", "BooEsfuerzoBrazosManos1", c => c.String());
            DropColumn("dbo.Tbl_IncidentesEL", "tempOrganizacionTrabajoIV");
            DropColumn("dbo.Tbl_IncidentesEL", "DisenoPuestoTrabajoIV");
            DropColumn("dbo.Tbl_IncidentesEL", "EPPIV");
            DropColumn("dbo.Tbl_IncidentesEL", "ProteccionColectivaIV");
            DropColumn("dbo.Tbl_IncidentesEL", "FormacionInformacionIV");
            DropColumn("dbo.Tbl_IncidentesEL", "ViaEntradaV4");
            DropColumn("dbo.Tbl_IncidentesEL", "NivelRiesgoV4");
            DropColumn("dbo.Tbl_IncidentesEL", "ViaEntradaVI1");
            DropColumn("dbo.Tbl_IncidentesEL", "NivelRiesgoVI1");
            DropColumn("dbo.Tbl_IncidentesEL", "myFile12");
            DropColumn("dbo.Tbl_IncidentesEL", "myFile11");
            DropColumn("dbo.Tbl_IncidentesEL", "myFile10");
            DropColumn("dbo.Tbl_IncidentesEL", "myFile9");
            DropColumn("dbo.Tbl_IncidentesEL", "myFile8");
            DropColumn("dbo.Tbl_IncidentesEL", "myFile7");
            DropColumn("dbo.Tbl_IncidentesEL", "myFile6");
            DropColumn("dbo.Tbl_IncidentesEL", "myFile5");
            DropColumn("dbo.Tbl_IncidentesEL", "myFile4");
            DropColumn("dbo.Tbl_IncidentesEL", "myFile3");
            DropColumn("dbo.Tbl_IncidentesEL", "myFile2");
            DropColumn("dbo.Tbl_IncidentesEL", "myFile1");
            DropColumn("dbo.Tbl_IncidentesEL", "CauRelPrevVI15");
            DropColumn("dbo.Tbl_IncidentesEL", "BooCauRelPrevVI15");
            DropColumn("dbo.Tbl_IncidentesEL", "CauRelPrevVI14");
            DropColumn("dbo.Tbl_IncidentesEL", "BooCauRelPrevVI14");
            DropColumn("dbo.Tbl_IncidentesEL", "CauRelPrevVI13");
            DropColumn("dbo.Tbl_IncidentesEL", "BooCauRelPrevVI13");
            DropColumn("dbo.Tbl_IncidentesEL", "BooEsfuerzoBrazosManos1");
        }
    }
}
