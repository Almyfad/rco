using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HeliosDataBaseContext.Migrations
{
    /// <inheritdoc />
    public partial class Addcolonneportable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Portable",
                table: "Membres",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 900,
                column: "Description",
                value: "Sympathisant");

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 1000,
                column: "Description",
                value: "Enfant bébé");

            migrationBuilder.InsertData(
                table: "TypeMembres",
                columns: new[] { "Id", "Code", "Description" },
                values: new object[,]
                {
                    { 950, "Contact", "Contact" },
                    { 1050, "EnfantGroupePreA", "Enfant groupe pré-A" },
                    { 1100, "EnfantGroupeA", "Enfant groupe A" },
                    { 1200, "EnfantGroupeB", "Enfant groupe B" },
                    { 1300, "EnfantGroupeC", "Enfant groupe C" },
                    { 1400, "EnfantGroupeD", "Enfant groupe D" },
                    { 1500, "EnfantHorsGroupe", "Enfant hors groupe" },
                    { 1600, "GroupeD", "Groupe D" },
                    { 1700, "GroupeDPlus", "Groupe D+" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 950);

            migrationBuilder.DeleteData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 1050);

            migrationBuilder.DeleteData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 1100);

            migrationBuilder.DeleteData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 1200);

            migrationBuilder.DeleteData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 1300);

            migrationBuilder.DeleteData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 1400);

            migrationBuilder.DeleteData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 1500);

            migrationBuilder.DeleteData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 1600);

            migrationBuilder.DeleteData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 1700);

            migrationBuilder.DropColumn(
                name: "Portable",
                table: "Membres");

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 900,
                column: "Description",
                value: "Interessé");

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 1000,
                column: "Description",
                value: "Jeunesse");
        }
    }
}
