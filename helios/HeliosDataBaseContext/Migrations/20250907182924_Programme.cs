using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeliosDataBaseContext.Migrations
{
    /// <inheritdoc />
    public partial class Programme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activitees_Centres_CentreId",
                table: "Activitees");

            migrationBuilder.AddColumn<int>(
                name: "ProgrammeActiviteeId",
                table: "TypeMembres",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CentreId",
                table: "Activitees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProgrammeId",
                table: "Activitees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Public",
                table: "Activitees",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ProgrammeActivitee",
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

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 100,
                column: "ProgrammeActiviteeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 200,
                column: "ProgrammeActiviteeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 300,
                column: "ProgrammeActiviteeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 400,
                column: "ProgrammeActiviteeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 500,
                column: "ProgrammeActiviteeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 600,
                column: "ProgrammeActiviteeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 700,
                column: "ProgrammeActiviteeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 800,
                column: "ProgrammeActiviteeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 900,
                column: "ProgrammeActiviteeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 950,
                column: "ProgrammeActiviteeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 1000,
                column: "ProgrammeActiviteeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 1050,
                column: "ProgrammeActiviteeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 1100,
                column: "ProgrammeActiviteeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 1200,
                column: "ProgrammeActiviteeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 1300,
                column: "ProgrammeActiviteeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 1400,
                column: "ProgrammeActiviteeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 1500,
                column: "ProgrammeActiviteeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 1600,
                column: "ProgrammeActiviteeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 1700,
                column: "ProgrammeActiviteeId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_TypeMembres_ProgrammeActiviteeId",
                table: "TypeMembres",
                column: "ProgrammeActiviteeId");

            migrationBuilder.CreateIndex(
                name: "IX_Activitees_ProgrammeId",
                table: "Activitees",
                column: "ProgrammeId");

            migrationBuilder.CreateIndex(
                name: "IX_CentreProgrammeActivitee_ProgrammesId",
                table: "CentreProgrammeActivitee",
                column: "ProgrammesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activitees_Centres_CentreId",
                table: "Activitees",
                column: "CentreId",
                principalTable: "Centres",
                principalColumn: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activitees_Centres_CentreId",
                table: "Activitees");

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

            migrationBuilder.DropIndex(
                name: "IX_TypeMembres_ProgrammeActiviteeId",
                table: "TypeMembres");

            migrationBuilder.DropIndex(
                name: "IX_Activitees_ProgrammeId",
                table: "Activitees");

            migrationBuilder.DropColumn(
                name: "ProgrammeActiviteeId",
                table: "TypeMembres");

            migrationBuilder.DropColumn(
                name: "ProgrammeId",
                table: "Activitees");

            migrationBuilder.DropColumn(
                name: "Public",
                table: "Activitees");

            migrationBuilder.AlterColumn<int>(
                name: "CentreId",
                table: "Activitees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Activitees_Centres_CentreId",
                table: "Activitees",
                column: "CentreId",
                principalTable: "Centres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
