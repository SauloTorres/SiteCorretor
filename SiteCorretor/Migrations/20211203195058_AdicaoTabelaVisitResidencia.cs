using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteCorretor.Migrations
{
    public partial class AdicaoTabelaVisitResidencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VisitResidencia",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResidenciaId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitResidencia", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VisitResidencia_Residencias_ResidenciaId",
                        column: x => x.ResidenciaId,
                        principalTable: "Residencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VisitResidencia_ResidenciaId",
                table: "VisitResidencia",
                column: "ResidenciaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisitResidencia");
        }
    }
}
