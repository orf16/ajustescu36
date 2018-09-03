namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cu_PlanEmergencia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_Eme_EstructuraOrganizacion",
                c => new
                    {
                        id_EstucturaOrg = c.Int(nullable: false, identity: true),
                        fk_id_sede = c.Int(nullable: false),
                        Jefe_Estructura = c.String(),
                        cargo_Empleado = c.String(),
                        Fk_Id_EstructuraOrg = c.Int(),
                    })
                .PrimaryKey(t => t.id_EstucturaOrg)
                .ForeignKey("dbo.Tbl_Eme_EstructuraOrganizacion", t => t.Fk_Id_EstructuraOrg)
                .Index(t => t.Fk_Id_EstructuraOrg);
            
            AddColumn("dbo.Tbl_Eme_FrentesAccion", "plan_evaluacion", c => c.String());
            AddColumn("dbo.Tbl_Eme_Georeferenciacion", "bo_ZonaIndustrial", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_Eme_Georeferenciacion", "bo_ZonaResidencial", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_Eme_Georeferenciacion", "bo_ZonaComercial", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_Eme_Georeferenciacion", "bo_ZonaMixta", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tbl_Eme_EstructuraOrganizacion", "Fk_Id_EstructuraOrg", "dbo.Tbl_Eme_EstructuraOrganizacion");
            DropIndex("dbo.Tbl_Eme_EstructuraOrganizacion", new[] { "Fk_Id_EstructuraOrg" });
            DropColumn("dbo.Tbl_Eme_Georeferenciacion", "bo_ZonaMixta");
            DropColumn("dbo.Tbl_Eme_Georeferenciacion", "bo_ZonaComercial");
            DropColumn("dbo.Tbl_Eme_Georeferenciacion", "bo_ZonaResidencial");
            DropColumn("dbo.Tbl_Eme_Georeferenciacion", "bo_ZonaIndustrial");
            DropColumn("dbo.Tbl_Eme_FrentesAccion", "plan_evaluacion");
            DropTable("dbo.Tbl_Eme_EstructuraOrganizacion");
        }
    }
}
