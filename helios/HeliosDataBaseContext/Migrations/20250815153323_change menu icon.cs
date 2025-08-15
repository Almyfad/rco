using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeliosDataBaseContext.Migrations
{
    /// <inheritdoc />
    public partial class changemenuicon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 6200);

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 2000,
                column: "Icon",
                value: "building-church");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 2100,
                column: "Icon",
                value: "calendar-up");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 2200,
                column: "Icon",
                value: "checklist");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 2300,
                column: "Icon",
                value: "calendar-plus");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3010,
                column: "Icon",
                value: "id");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3020,
                column: "Icon",
                value: "parking-circle");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3030,
                column: "Icon",
                value: "users-group");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3040,
                column: "Icon",
                value: "baby-carriage");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3050,
                column: "Icon",
                value: "horse-toy");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3060,
                column: "Icon",
                value: "checklist");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3061,
                column: "Icon",
                value: "clipboard-smile");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3062,
                column: "Icon",
                value: "clipboard-heart");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3063,
                column: "Icon",
                value: "clipboard-check");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3070,
                column: "Icon",
                value: "chart-infographic");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3071,
                column: "Icon",
                value: "checklist");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 4000,
                column: "Icon",
                value: "calculator");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 4010,
                column: "Icon",
                value: "credit-card-pay");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 4020,
                column: "Icon",
                value: "adjustments-alt");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 4030,
                column: "Icon",
                value: "replace");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 4040,
                column: "Icon",
                value: "coins");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 5000,
                column: "Icon",
                value: "settings");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 6000,
                column: "Icon",
                value: "brand-gmail");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 6100,
                column: "Icon",
                value: "message-share");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 50000,
                column: "Icon",
                value: "logout");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 2000,
                column: "Icon",
                value: "temple_buddhist");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 2100,
                column: "Icon",
                value: "person_add");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 2200,
                column: "Icon",
                value: "edit");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 2300,
                column: "Icon",
                value: "post_add");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3010,
                column: "Icon",
                value: "people");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3020,
                column: "Icon",
                value: "wb_iridescent");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3030,
                column: "Icon",
                value: "contact_page");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3040,
                column: "Icon",
                value: "child_care");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3050,
                column: "Icon",
                value: "settings_accessibility");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3060,
                column: "Icon",
                value: "featured_play_list");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3061,
                column: "Icon",
                value: "list_alt");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3062,
                column: "Icon",
                value: "fact_check");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3063,
                column: "Icon",
                value: "receipt_long");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3070,
                column: "Icon",
                value: "insert_chart_outlined");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3071,
                column: "Icon",
                value: "list_alt");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 4000,
                column: "Icon",
                value: "account_balance");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 4010,
                column: "Icon",
                value: "account_balance_wallet");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 4020,
                column: "Icon",
                value: "settings");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 4030,
                column: "Icon",
                value: "monetization_on");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 4040,
                column: "Icon",
                value: "description");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 5000,
                column: "Icon",
                value: "admin_panel_settings");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 6000,
                column: "Icon",
                value: "email");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 6100,
                column: "Icon",
                value: "list");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 50000,
                column: "Icon",
                value: "exit_to_app");

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "Code", "Description", "Icon", "Label", "ParentId", "Path", "PrefixIcon", "SuffixIcon", "Title" },
                values: new object[] { 6200, 6200, null, "campaign", "Campagnes", 6000, "/mailing/campagnes", null, null, null });
        }
    }
}
