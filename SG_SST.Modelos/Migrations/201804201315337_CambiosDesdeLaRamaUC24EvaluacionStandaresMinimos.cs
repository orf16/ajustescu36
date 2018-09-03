namespace SG_SST.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambiosDesdeLaRamaUC24EvaluacionStandaresMinimos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tbl_Evaluacion_Estandares_Minimos", "Fk_Id_Empresa_Evaluar", "dbo.Tbl_Empresas_Evaluar");
            DropIndex("dbo.Tbl_Evaluacion_Estandares_Minimos", new[] { "Fk_Id_Empresa_Evaluar" });
            CreateTable(
                "dbo.Tbl_EvaluacionEmpresa",
                c => new
                    {
                        Pk_Id_EvaluacionEmpresa = c.Int(nullable: false, identity: true),
                        Vigencia = c.Int(nullable: false),
                        Estado = c.Int(nullable: false),
                        Consecutivo = c.String(nullable: false),
                        Fecha_Elab = c.DateTime(nullable: false),
                        Fk_Id_Empresa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Pk_Id_EvaluacionEmpresa)
                .ForeignKey("dbo.Tbl_Empresa", t => t.Fk_Id_Empresa, cascadeDelete: true)
                .Index(t => t.Fk_Id_Empresa);
            
            AddColumn("dbo.Tbl_Actividades_Evaluacion", "EvaluacionCerrado", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_Evaluacion_Estandares_Minimos", "NombreArchivo1", c => c.String(maxLength: 2000));
            AddColumn("dbo.Tbl_Evaluacion_Estandares_Minimos", "NombreArchivo1_download", c => c.String(maxLength: 2000));
            AddColumn("dbo.Tbl_Evaluacion_Estandares_Minimos", "Ruta1", c => c.String(maxLength: 3000));
            AddColumn("dbo.Tbl_Evaluacion_Estandares_Minimos", "NombreArchivo2", c => c.String(maxLength: 2000));
            AddColumn("dbo.Tbl_Evaluacion_Estandares_Minimos", "NombreArchivo2_download", c => c.String());
            AddColumn("dbo.Tbl_Evaluacion_Estandares_Minimos", "Ruta2", c => c.String(maxLength: 3000));
            AddColumn("dbo.Tbl_Evaluacion_Estandares_Minimos", "NombreArchivo3", c => c.String(maxLength: 2000));
            AddColumn("dbo.Tbl_Evaluacion_Estandares_Minimos", "NombreArchivo3_download", c => c.String());
            AddColumn("dbo.Tbl_Evaluacion_Estandares_Minimos", "Ruta3", c => c.String(maxLength: 3000));
            AddColumn("dbo.Tbl_Evaluacion_Estandares_Minimos", "Fk_Id_EvaluacionEmpresa", c => c.Int(nullable: false));
            CreateIndex("dbo.Tbl_Evaluacion_Estandares_Minimos", "Fk_Id_EvaluacionEmpresa");
            AddForeignKey("dbo.Tbl_Evaluacion_Estandares_Minimos", "Fk_Id_EvaluacionEmpresa", "dbo.Tbl_EvaluacionEmpresa", "Pk_Id_EvaluacionEmpresa", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tbl_Evaluacion_Estandares_Minimos", "Fk_Id_EvaluacionEmpresa", "dbo.Tbl_EvaluacionEmpresa");
            DropForeignKey("dbo.Tbl_EvaluacionEmpresa", "Fk_Id_Empresa", "dbo.Tbl_Empresa");
            DropIndex("dbo.Tbl_EvaluacionEmpresa", new[] { "Fk_Id_Empresa" });
            DropIndex("dbo.Tbl_Evaluacion_Estandares_Minimos", new[] { "Fk_Id_EvaluacionEmpresa" });
            DropColumn("dbo.Tbl_Evaluacion_Estandares_Minimos", "Fk_Id_EvaluacionEmpresa");
            DropColumn("dbo.Tbl_Evaluacion_Estandares_Minimos", "Ruta3");
            DropColumn("dbo.Tbl_Evaluacion_Estandares_Minimos", "NombreArchivo3_download");
            DropColumn("dbo.Tbl_Evaluacion_Estandares_Minimos", "NombreArchivo3");
            DropColumn("dbo.Tbl_Evaluacion_Estandares_Minimos", "Ruta2");
            DropColumn("dbo.Tbl_Evaluacion_Estandares_Minimos", "NombreArchivo2_download");
            DropColumn("dbo.Tbl_Evaluacion_Estandares_Minimos", "NombreArchivo2");
            DropColumn("dbo.Tbl_Evaluacion_Estandares_Minimos", "Ruta1");
            DropColumn("dbo.Tbl_Evaluacion_Estandares_Minimos", "NombreArchivo1_download");
            DropColumn("dbo.Tbl_Evaluacion_Estandares_Minimos", "NombreArchivo1");
            DropColumn("dbo.Tbl_Actividades_Evaluacion", "EvaluacionCerrado");
            DropTable("dbo.Tbl_EvaluacionEmpresa");
            CreateIndex("dbo.Tbl_Evaluacion_Estandares_Minimos", "Fk_Id_Empresa_Evaluar");
            AddForeignKey("dbo.Tbl_Evaluacion_Estandares_Minimos", "Fk_Id_Empresa_Evaluar", "dbo.Tbl_Empresas_Evaluar", "Pk_Id_Empresa_Evaluar", cascadeDelete: true);
        }
    }
}
