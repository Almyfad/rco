using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeliosDataBaseContext.Migrations
{
    /// <inheritdoc />
    public partial class RenameProgramme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activitees_ProgrammeActivitee_ProgrammeId",
                table: "Activitees");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeMembres_ProgrammeActivitee_ProgrammeActiviteeId",
                table: "TypeMembres");

            migrationBuilder.DropTable(
                name: "CentreProgrammeActivitee");

            migrationBuilder.DropTable(
                name: "ProgrammeActivitee");

            migrationBuilder.RenameColumn(
                name: "ProgrammeActiviteeId",
                table: "TypeMembres",
                newName: "ProgrammeId");

            migrationBuilder.RenameIndex(
                name: "IX_TypeMembres_ProgrammeActiviteeId",
                table: "TypeMembres",
                newName: "IX_TypeMembres_ProgrammeId");

            migrationBuilder.CreateTable(
                name: "Programmes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Libelle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Annee = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Creation = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Modification = table.Column<DateTime>(type: "datetime(6)", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programmes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CentreProgramme",
                columns: table => new
                {
                    CentreId = table.Column<int>(type: "int", nullable: false),
                    ProgrammesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentreProgramme", x => new { x.CentreId, x.ProgrammesId });
                    table.ForeignKey(
                        name: "FK_CentreProgramme_Centres_CentreId",
                        column: x => x.CentreId,
                        principalTable: "Centres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CentreProgramme_Programmes_ProgrammesId",
                        column: x => x.ProgrammesId,
                        principalTable: "Programmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CentreProgramme_ProgrammesId",
                table: "CentreProgramme",
                column: "ProgrammesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activitees_Programmes_ProgrammeId",
                table: "Activitees",
                column: "ProgrammeId",
                principalTable: "Programmes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TypeMembres_Programmes_ProgrammeId",
                table: "TypeMembres",
                column: "ProgrammeId",
                principalTable: "Programmes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activitees_Programmes_ProgrammeId",
                table: "Activitees");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeMembres_Programmes_ProgrammeId",
                table: "TypeMembres");

            migrationBuilder.DropTable(
                name: "CentreProgramme");

            migrationBuilder.DropTable(
                name: "Programmes");

            migrationBuilder.RenameColumn(
                name: "ProgrammeId",
                table: "TypeMembres",
                newName: "ProgrammeActiviteeId");

            migrationBuilder.RenameIndex(
                name: "IX_TypeMembres_ProgrammeId",
                table: "TypeMembres",
                newName: "IX_TypeMembres_ProgrammeActiviteeId");

            migrationBuilder.CreateTable(
                name: "ProgrammeActivitee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Annee = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Creation = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Libelle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Modification = table.Column<DateTime>(type: "datetime(6)", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammeActivitee", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CentreProgrammeActivitee",
                columns: table => new
                {
                    CentreId = table.Column<int>(type: "int", nullable: false),
                    ProgrammesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentreProgrammeActivitee", x => new { x.CentreId, x.ProgrammesId });
                    table.ForeignKey(
                        name: "FK_CentreProgrammeActivitee_Centres_CentreId",
                        column: x => x.CentreId,
                        principalTable: "Centres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CentreProgrammeActivitee_ProgrammeActivitee_ProgrammesId",
                        column: x => x.ProgrammesId,
                        principalTable: "ProgrammeActivitee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CentreProgrammeActivitee_ProgrammesId",
                table: "CentreProgrammeActivitee",
                column: "ProgrammesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activitees_ProgrammeActivitee_ProgrammeId",
                table: "Activitees",
                column: "ProgrammeId",
                principalTable: "ProgrammeActivitee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TypeMembres_ProgrammeActivitee_ProgrammeActiviteeId",
                table: "TypeMembres",
                column: "ProgrammeActiviteeId",
                principalTable: "ProgrammeActivitee",
                principalColumn: "Id");
        }
    }
}
