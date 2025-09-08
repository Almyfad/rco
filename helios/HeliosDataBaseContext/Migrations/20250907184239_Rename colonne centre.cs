using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeliosDataBaseContext.Migrations
{
    /// <inheritdoc />
    public partial class Renamecolonnecentre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CentreProgramme_Centres_CentreId",
                table: "CentreProgramme");

            migrationBuilder.RenameColumn(
                name: "CentreId",
                table: "CentreProgramme",
                newName: "CentresId");

            migrationBuilder.AddForeignKey(
                name: "FK_CentreProgramme_Centres_CentresId",
                table: "CentreProgramme",
                column: "CentresId",
                principalTable: "Centres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CentreProgramme_Centres_CentresId",
                table: "CentreProgramme");

            migrationBuilder.RenameColumn(
                name: "CentresId",
                table: "CentreProgramme",
                newName: "CentreId");

            migrationBuilder.AddForeignKey(
                name: "FK_CentreProgramme_Centres_CentreId",
                table: "CentreProgramme",
                column: "CentreId",
                principalTable: "Centres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
