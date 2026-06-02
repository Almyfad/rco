using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeliosDataBaseContext.Migrations
{
    /// <inheritdoc />
    public partial class DefaultDatetimecreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MailingListMembre_MailingLists_MailingListsId",
                table: "MailingListMembre");

            migrationBuilder.DropForeignKey(
                name: "FK_MailingLists_Centres_CentreId",
                table: "MailingLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MailingLists",
                table: "MailingLists");

            migrationBuilder.RenameTable(
                name: "MailingLists",
                newName: "MailingList");

            migrationBuilder.RenameIndex(
                name: "IX_MailingLists_CentreId",
                table: "MailingList",
                newName: "IX_MailingList_CentreId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "Utilisateurs",
                type: "datetime(6)",
                nullable: true,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation",
                table: "Utilisateurs",
                type: "datetime(6)",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "TypeMembres",
                type: "datetime(6)",
                nullable: true,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation",
                table: "TypeMembres",
                type: "datetime(6)",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "TypeCentres",
                type: "datetime(6)",
                nullable: true,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation",
                table: "TypeCentres",
                type: "datetime(6)",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "TypeActivitees",
                type: "datetime(6)",
                nullable: true,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation",
                table: "TypeActivitees",
                type: "datetime(6)",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "StatutMembres",
                type: "datetime(6)",
                nullable: true,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation",
                table: "StatutMembres",
                type: "datetime(6)",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "Roles",
                type: "datetime(6)",
                nullable: true,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation",
                table: "Roles",
                type: "datetime(6)",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "Modules",
                type: "datetime(6)",
                nullable: true,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation",
                table: "Modules",
                type: "datetime(6)",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "Membres",
                type: "datetime(6)",
                nullable: true,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation",
                table: "Membres",
                type: "datetime(6)",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "Inscriptions",
                type: "datetime(6)",
                nullable: true,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation",
                table: "Inscriptions",
                type: "datetime(6)",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "Droits",
                type: "datetime(6)",
                nullable: true,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation",
                table: "Droits",
                type: "datetime(6)",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "Civilites",
                type: "datetime(6)",
                nullable: true,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation",
                table: "Civilites",
                type: "datetime(6)",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "Centres",
                type: "datetime(6)",
                nullable: true,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation",
                table: "Centres",
                type: "datetime(6)",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "Activitees",
                type: "datetime(6)",
                nullable: true,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation",
                table: "Activitees",
                type: "datetime(6)",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "MailingList",
                type: "datetime(6)",
                nullable: true,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation",
                table: "MailingList",
                type: "datetime(6)",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MailingList",
                table: "MailingList",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Centres",
                keyColumn: "Id",
                keyValue: 1,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Centres",
                keyColumn: "Id",
                keyValue: 2,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Centres",
                keyColumn: "Id",
                keyValue: 3,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Centres",
                keyColumn: "Id",
                keyValue: 4,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Centres",
                keyColumn: "Id",
                keyValue: 5,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Centres",
                keyColumn: "Id",
                keyValue: 6,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Centres",
                keyColumn: "Id",
                keyValue: 7,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Centres",
                keyColumn: "Id",
                keyValue: 8,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Centres",
                keyColumn: "Id",
                keyValue: 9,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Centres",
                keyColumn: "Id",
                keyValue: 10,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Centres",
                keyColumn: "Id",
                keyValue: 11,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Centres",
                keyColumn: "Id",
                keyValue: 12,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Centres",
                keyColumn: "Id",
                keyValue: 13,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Centres",
                keyColumn: "Id",
                keyValue: 14,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Centres",
                keyColumn: "Id",
                keyValue: 15,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Centres",
                keyColumn: "Id",
                keyValue: 16,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Centres",
                keyColumn: "Id",
                keyValue: 17,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Civilites",
                keyColumn: "Id",
                keyValue: 100,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Civilites",
                keyColumn: "Id",
                keyValue: 200,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Droits",
                keyColumn: "Id",
                keyValue: 1,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Droits",
                keyColumn: "Id",
                keyValue: 2,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Droits",
                keyColumn: "Id",
                keyValue: 3,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Droits",
                keyColumn: "Id",
                keyValue: 4,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Droits",
                keyColumn: "Id",
                keyValue: 5,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Droits",
                keyColumn: "Id",
                keyValue: 6,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Droits",
                keyColumn: "Id",
                keyValue: 7,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Droits",
                keyColumn: "Id",
                keyValue: 8,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Droits",
                keyColumn: "Id",
                keyValue: 9,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Droits",
                keyColumn: "Id",
                keyValue: 10,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 1000,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 2000,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 2100,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 2200,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 2300,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3000,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3010,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3020,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3030,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3040,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3050,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3060,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3061,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3062,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3063,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3070,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3071,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 4000,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 4010,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 4020,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 4030,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 4040,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 5000,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 6000,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 6100,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 6200,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 10000,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 50000,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 100,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 200,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 300,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "StatutMembres",
                keyColumn: "Id",
                keyValue: 100,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "StatutMembres",
                keyColumn: "Id",
                keyValue: 200,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "StatutMembres",
                keyColumn: "Id",
                keyValue: 300,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "StatutMembres",
                keyColumn: "Id",
                keyValue: 400,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "StatutMembres",
                keyColumn: "Id",
                keyValue: 500,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TypeActivitees",
                keyColumn: "Id",
                keyValue: 100,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TypeActivitees",
                keyColumn: "Id",
                keyValue: 200,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TypeActivitees",
                keyColumn: "Id",
                keyValue: 300,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TypeActivitees",
                keyColumn: "Id",
                keyValue: 400,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TypeActivitees",
                keyColumn: "Id",
                keyValue: 500,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TypeActivitees",
                keyColumn: "Id",
                keyValue: 600,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TypeActivitees",
                keyColumn: "Id",
                keyValue: 700,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TypeActivitees",
                keyColumn: "Id",
                keyValue: 800,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TypeCentres",
                keyColumn: "Id",
                keyValue: 100,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TypeCentres",
                keyColumn: "Id",
                keyValue: 200,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 100,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 200,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 300,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 400,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 500,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 600,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 700,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 800,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 900,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 1000,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: 4,
                column: "Creation",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_MailingList_Centres_CentreId",
                table: "MailingList",
                column: "CentreId",
                principalTable: "Centres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MailingListMembre_MailingList_MailingListsId",
                table: "MailingListMembre",
                column: "MailingListsId",
                principalTable: "MailingList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MailingList_Centres_CentreId",
                table: "MailingList");

            migrationBuilder.DropForeignKey(
                name: "FK_MailingListMembre_MailingList_MailingListsId",
                table: "MailingListMembre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MailingList",
                table: "MailingList");

            migrationBuilder.RenameTable(
                name: "MailingList",
                newName: "MailingLists");

            migrationBuilder.RenameIndex(
                name: "IX_MailingList_CentreId",
                table: "MailingLists",
                newName: "IX_MailingLists_CentreId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "Utilisateurs",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true,
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation",
                table: "Utilisateurs",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "TypeMembres",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true,
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation",
                table: "TypeMembres",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "TypeCentres",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true,
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation",
                table: "TypeCentres",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "TypeActivitees",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true,
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation",
                table: "TypeActivitees",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "StatutMembres",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true,
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation",
                table: "StatutMembres",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "Roles",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true,
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation",
                table: "Roles",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "Modules",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true,
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation",
                table: "Modules",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "Membres",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true,
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation",
                table: "Membres",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "Inscriptions",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true,
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation",
                table: "Inscriptions",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "Droits",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true,
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation",
                table: "Droits",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "Civilites",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true,
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation",
                table: "Civilites",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "Centres",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true,
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation",
                table: "Centres",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "Activitees",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true,
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation",
                table: "Activitees",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modification",
                table: "MailingLists",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true,
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation",
                table: "MailingLists",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MailingLists",
                table: "MailingLists",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Centres",
                keyColumn: "Id",
                keyValue: 1,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 16, 37, 23, 909, DateTimeKind.Local).AddTicks(5216));

            migrationBuilder.UpdateData(
                table: "Centres",
                keyColumn: "Id",
                keyValue: 2,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 16, 37, 23, 909, DateTimeKind.Local).AddTicks(5907));

            migrationBuilder.UpdateData(
                table: "Centres",
                keyColumn: "Id",
                keyValue: 3,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 16, 37, 23, 909, DateTimeKind.Local).AddTicks(5910));

            migrationBuilder.UpdateData(
                table: "Centres",
                keyColumn: "Id",
                keyValue: 4,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 16, 37, 23, 909, DateTimeKind.Local).AddTicks(5912));

            migrationBuilder.UpdateData(
                table: "Centres",
                keyColumn: "Id",
                keyValue: 5,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 16, 37, 23, 909, DateTimeKind.Local).AddTicks(5913));

            migrationBuilder.UpdateData(
                table: "Centres",
                keyColumn: "Id",
                keyValue: 6,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 16, 37, 23, 909, DateTimeKind.Local).AddTicks(5914));

            migrationBuilder.UpdateData(
                table: "Centres",
                keyColumn: "Id",
                keyValue: 7,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 16, 37, 23, 909, DateTimeKind.Local).AddTicks(5915));

            migrationBuilder.UpdateData(
                table: "Centres",
                keyColumn: "Id",
                keyValue: 8,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 16, 37, 23, 909, DateTimeKind.Local).AddTicks(5916));

            migrationBuilder.UpdateData(
                table: "Centres",
                keyColumn: "Id",
                keyValue: 9,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 16, 37, 23, 909, DateTimeKind.Local).AddTicks(5917));

            migrationBuilder.UpdateData(
                table: "Centres",
                keyColumn: "Id",
                keyValue: 10,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 16, 37, 23, 909, DateTimeKind.Local).AddTicks(5918));

            migrationBuilder.UpdateData(
                table: "Centres",
                keyColumn: "Id",
                keyValue: 11,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 16, 37, 23, 909, DateTimeKind.Local).AddTicks(5919));

            migrationBuilder.UpdateData(
                table: "Centres",
                keyColumn: "Id",
                keyValue: 12,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 16, 37, 23, 909, DateTimeKind.Local).AddTicks(5921));

            migrationBuilder.UpdateData(
                table: "Centres",
                keyColumn: "Id",
                keyValue: 13,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 16, 37, 23, 909, DateTimeKind.Local).AddTicks(5922));

            migrationBuilder.UpdateData(
                table: "Centres",
                keyColumn: "Id",
                keyValue: 14,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 16, 37, 23, 909, DateTimeKind.Local).AddTicks(5923));

            migrationBuilder.UpdateData(
                table: "Centres",
                keyColumn: "Id",
                keyValue: 15,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 16, 37, 23, 909, DateTimeKind.Local).AddTicks(5924));

            migrationBuilder.UpdateData(
                table: "Centres",
                keyColumn: "Id",
                keyValue: 16,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 16, 37, 23, 909, DateTimeKind.Local).AddTicks(5930));

            migrationBuilder.UpdateData(
                table: "Centres",
                keyColumn: "Id",
                keyValue: 17,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 16, 37, 23, 909, DateTimeKind.Local).AddTicks(5940));

            migrationBuilder.UpdateData(
                table: "Civilites",
                keyColumn: "Id",
                keyValue: 100,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 858, DateTimeKind.Utc).AddTicks(2334));

            migrationBuilder.UpdateData(
                table: "Civilites",
                keyColumn: "Id",
                keyValue: 200,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 860, DateTimeKind.Utc).AddTicks(8628));

            migrationBuilder.UpdateData(
                table: "Droits",
                keyColumn: "Id",
                keyValue: 1,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 16, 37, 23, 827, DateTimeKind.Local).AddTicks(4216));

            migrationBuilder.UpdateData(
                table: "Droits",
                keyColumn: "Id",
                keyValue: 2,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 16, 37, 23, 827, DateTimeKind.Local).AddTicks(4709));

            migrationBuilder.UpdateData(
                table: "Droits",
                keyColumn: "Id",
                keyValue: 3,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 16, 37, 23, 827, DateTimeKind.Local).AddTicks(4713));

            migrationBuilder.UpdateData(
                table: "Droits",
                keyColumn: "Id",
                keyValue: 4,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 16, 37, 23, 827, DateTimeKind.Local).AddTicks(4714));

            migrationBuilder.UpdateData(
                table: "Droits",
                keyColumn: "Id",
                keyValue: 5,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 16, 37, 23, 827, DateTimeKind.Local).AddTicks(4715));

            migrationBuilder.UpdateData(
                table: "Droits",
                keyColumn: "Id",
                keyValue: 6,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 16, 37, 23, 827, DateTimeKind.Local).AddTicks(4716));

            migrationBuilder.UpdateData(
                table: "Droits",
                keyColumn: "Id",
                keyValue: 7,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 16, 37, 23, 827, DateTimeKind.Local).AddTicks(4993));

            migrationBuilder.UpdateData(
                table: "Droits",
                keyColumn: "Id",
                keyValue: 8,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 16, 37, 23, 827, DateTimeKind.Local).AddTicks(4994));

            migrationBuilder.UpdateData(
                table: "Droits",
                keyColumn: "Id",
                keyValue: 9,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 16, 37, 23, 827, DateTimeKind.Local).AddTicks(4995));

            migrationBuilder.UpdateData(
                table: "Droits",
                keyColumn: "Id",
                keyValue: 10,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 16, 37, 23, 827, DateTimeKind.Local).AddTicks(4996));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 1000,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 826, DateTimeKind.Utc).AddTicks(3685));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 2000,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 826, DateTimeKind.Utc).AddTicks(4879));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 2100,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 826, DateTimeKind.Utc).AddTicks(4889));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 2200,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 826, DateTimeKind.Utc).AddTicks(4890));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 2300,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 826, DateTimeKind.Utc).AddTicks(4887));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3000,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 826, DateTimeKind.Utc).AddTicks(4892));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3010,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 826, DateTimeKind.Utc).AddTicks(4894));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3020,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 826, DateTimeKind.Utc).AddTicks(4896));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3030,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 826, DateTimeKind.Utc).AddTicks(4897));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3040,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 826, DateTimeKind.Utc).AddTicks(4899));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3050,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 826, DateTimeKind.Utc).AddTicks(4900));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3060,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 826, DateTimeKind.Utc).AddTicks(4902));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3061,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 826, DateTimeKind.Utc).AddTicks(4903));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3062,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 826, DateTimeKind.Utc).AddTicks(4905));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3063,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 826, DateTimeKind.Utc).AddTicks(4907));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3070,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 826, DateTimeKind.Utc).AddTicks(4919));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3071,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 826, DateTimeKind.Utc).AddTicks(4920));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 4000,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 826, DateTimeKind.Utc).AddTicks(4922));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 4010,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 826, DateTimeKind.Utc).AddTicks(4923));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 4020,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 826, DateTimeKind.Utc).AddTicks(4924));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 4030,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 826, DateTimeKind.Utc).AddTicks(4928));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 4040,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 826, DateTimeKind.Utc).AddTicks(4930));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 5000,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 826, DateTimeKind.Utc).AddTicks(4933));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 6000,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 826, DateTimeKind.Utc).AddTicks(4749));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 6100,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 826, DateTimeKind.Utc).AddTicks(4752));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 6200,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 826, DateTimeKind.Utc).AddTicks(4877));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 10000,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 826, DateTimeKind.Utc).AddTicks(4931));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 50000,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 826, DateTimeKind.Utc).AddTicks(4934));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 100,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 899, DateTimeKind.Utc).AddTicks(1260));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 200,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 899, DateTimeKind.Utc).AddTicks(7483));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 300,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 899, DateTimeKind.Utc).AddTicks(7700));

            migrationBuilder.UpdateData(
                table: "StatutMembres",
                keyColumn: "Id",
                keyValue: 100,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 896, DateTimeKind.Utc).AddTicks(3493));

            migrationBuilder.UpdateData(
                table: "StatutMembres",
                keyColumn: "Id",
                keyValue: 200,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 896, DateTimeKind.Utc).AddTicks(9021));

            migrationBuilder.UpdateData(
                table: "StatutMembres",
                keyColumn: "Id",
                keyValue: 300,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 896, DateTimeKind.Utc).AddTicks(9225));

            migrationBuilder.UpdateData(
                table: "StatutMembres",
                keyColumn: "Id",
                keyValue: 400,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 896, DateTimeKind.Utc).AddTicks(9353));

            migrationBuilder.UpdateData(
                table: "StatutMembres",
                keyColumn: "Id",
                keyValue: 500,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 896, DateTimeKind.Utc).AddTicks(9462));

            migrationBuilder.UpdateData(
                table: "TypeActivitees",
                keyColumn: "Id",
                keyValue: 100,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 904, DateTimeKind.Utc).AddTicks(8346));

            migrationBuilder.UpdateData(
                table: "TypeActivitees",
                keyColumn: "Id",
                keyValue: 200,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 905, DateTimeKind.Utc).AddTicks(8718));

            migrationBuilder.UpdateData(
                table: "TypeActivitees",
                keyColumn: "Id",
                keyValue: 300,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 905, DateTimeKind.Utc).AddTicks(9121));

            migrationBuilder.UpdateData(
                table: "TypeActivitees",
                keyColumn: "Id",
                keyValue: 400,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 905, DateTimeKind.Utc).AddTicks(9439));

            migrationBuilder.UpdateData(
                table: "TypeActivitees",
                keyColumn: "Id",
                keyValue: 500,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 905, DateTimeKind.Utc).AddTicks(9563));

            migrationBuilder.UpdateData(
                table: "TypeActivitees",
                keyColumn: "Id",
                keyValue: 600,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 905, DateTimeKind.Utc).AddTicks(9683));

            migrationBuilder.UpdateData(
                table: "TypeActivitees",
                keyColumn: "Id",
                keyValue: 700,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 905, DateTimeKind.Utc).AddTicks(9775));

            migrationBuilder.UpdateData(
                table: "TypeActivitees",
                keyColumn: "Id",
                keyValue: 800,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 905, DateTimeKind.Utc).AddTicks(9886));

            migrationBuilder.UpdateData(
                table: "TypeCentres",
                keyColumn: "Id",
                keyValue: 100,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 908, DateTimeKind.Utc).AddTicks(816));

            migrationBuilder.UpdateData(
                table: "TypeCentres",
                keyColumn: "Id",
                keyValue: 200,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 908, DateTimeKind.Utc).AddTicks(6242));

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 100,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 893, DateTimeKind.Utc).AddTicks(3863));

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 200,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 893, DateTimeKind.Utc).AddTicks(9348));

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 300,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 894, DateTimeKind.Utc).AddTicks(331));

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 400,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 894, DateTimeKind.Utc).AddTicks(719));

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 500,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 894, DateTimeKind.Utc).AddTicks(821));

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 600,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 894, DateTimeKind.Utc).AddTicks(961));

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 700,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 894, DateTimeKind.Utc).AddTicks(1049));

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 800,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 894, DateTimeKind.Utc).AddTicks(1124));

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 900,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 894, DateTimeKind.Utc).AddTicks(1238));

            migrationBuilder.UpdateData(
                table: "TypeMembres",
                keyColumn: "Id",
                keyValue: 1000,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 20, 37, 23, 894, DateTimeKind.Utc).AddTicks(1341));

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 16, 37, 23, 902, DateTimeKind.Local).AddTicks(5145));

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 16, 37, 23, 902, DateTimeKind.Local).AddTicks(5819));

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 16, 37, 23, 902, DateTimeKind.Local).AddTicks(5828));

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "Id",
                keyValue: 4,
                column: "Creation",
                value: new DateTime(2025, 6, 15, 16, 37, 23, 902, DateTimeKind.Local).AddTicks(5833));

            migrationBuilder.AddForeignKey(
                name: "FK_MailingListMembre_MailingLists_MailingListsId",
                table: "MailingListMembre",
                column: "MailingListsId",
                principalTable: "MailingLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MailingLists_Centres_CentreId",
                table: "MailingLists",
                column: "CentreId",
                principalTable: "Centres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
