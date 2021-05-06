using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSP.BetterCalm.DataAccess.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pathology_Psychologist_PsychologistId",
                table: "Pathology");

            migrationBuilder.DropIndex(
                name: "IX_Pathology_PsychologistId",
                table: "Pathology");

            migrationBuilder.DropColumn(
                name: "PsychologistId",
                table: "Pathology");

            migrationBuilder.CreateTable(
                name: "PathologyPsychologist",
                columns: table => new
                {
                    PathologiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PsychologistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PathologyPsychologist", x => new { x.PathologiesId, x.PsychologistId });
                    table.ForeignKey(
                        name: "FK_PathologyPsychologist_Pathology_PathologiesId",
                        column: x => x.PathologiesId,
                        principalTable: "Pathology",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PathologyPsychologist_Psychologist_PsychologistId",
                        column: x => x.PsychologistId,
                        principalTable: "Psychologist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PathologyPsychologist_PsychologistId",
                table: "PathologyPsychologist",
                column: "PsychologistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PathologyPsychologist");

            migrationBuilder.AddColumn<Guid>(
                name: "PsychologistId",
                table: "Pathology",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pathology_PsychologistId",
                table: "Pathology",
                column: "PsychologistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pathology_Psychologist_PsychologistId",
                table: "Pathology",
                column: "PsychologistId",
                principalTable: "Psychologist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
