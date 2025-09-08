using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeliosDataBaseContext.Migrations
{
    /// <inheritdoc />
    public partial class moduleplanning : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 2300);

            migrationBuilder.UpdateData(
                table: "Droits",
                keyColumn: "Id",
                keyValue: 10,
                column: "ModuleId",
                value: 7000);

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "Code", "Description", "Icon", "Label", "ParentId", "Path", "PrefixIcon", "SuffixIcon", "Title" },
                values: new object[] { 7000, 7000, null, "calendar-plus", "Planning", null, "/planning", null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 7000);

            migrationBuilder.UpdateData(
                table: "Droits",
                keyColumn: "Id",
                keyValue: 10,
                column: "ModuleId",
                value: 2300);

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "Code", "Description", "Icon", "Label", "ParentId", "Path", "PrefixIcon", "SuffixIcon", "Title" },
                values: new object[] { 2300, 2300, null, "calendar-plus", "Créer Conférence", 2000, "/creer/conference", null, null, null });
        }
    }
}
