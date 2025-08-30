using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HeliosDataBaseContext.Migrations
{
    /// <inheritdoc />
    public partial class Timeline2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimelineMembre_Membres_MembreId",
                table: "TimelineMembre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimelineMembre",
                table: "TimelineMembre");

            migrationBuilder.RenameTable(
                name: "TimelineMembre",
                newName: "TimelineMembres");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "TimelineMembres",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_TimelineMembre_MembreId",
                table: "TimelineMembres",
                newName: "IX_TimelineMembres_MembreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimelineMembres",
                table: "TimelineMembres",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TimelineMembreTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Creation = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Modification = table.Column<DateTime>(type: "datetime(6)", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimelineMembreTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "TimelineMembreTypes",
                columns: new[] { "Id", "Code", "Description" },
                values: new object[,]
                {
                    { 100, "PremierContact", "Premier Contact" },
                    { 200, "Bapteme", "Baptème" },
                    { 300, "MariageBenediction", "Mariage Bénédiction" },
                    { 400, "MariageSacrement", "Mariage Sacrement" },
                    { 500, "Societaire", "Sociétaire" },
                    { 600, "PremierAspect", "1er Aspect" },
                    { 700, "DeuxiemeAspect", "2e Aspect" },
                    { 800, "ECS", "ECS" },
                    { 900, "Ecclesia", "Ecclesia" },
                    { 1000, "Graal", "Graal" },
                    { 1100, "TeteDor", "Tête d'or" },
                    { 1200, "SixiemeAspect", "6e Aspect" },
                    { 1300, "Codicile", "Codicile" },
                    { 1400, "Demission", "Démission" },
                    { 1500, "Deces", "Décès" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimelineMembres_TypeId",
                table: "TimelineMembres",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TimelineMembreTypes_Code",
                table: "TimelineMembreTypes",
                column: "Code",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TimelineMembres_Membres_MembreId",
                table: "TimelineMembres",
                column: "MembreId",
                principalTable: "Membres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimelineMembres_TimelineMembreTypes_TypeId",
                table: "TimelineMembres",
                column: "TypeId",
                principalTable: "TimelineMembreTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimelineMembres_Membres_MembreId",
                table: "TimelineMembres");

            migrationBuilder.DropForeignKey(
                name: "FK_TimelineMembres_TimelineMembreTypes_TypeId",
                table: "TimelineMembres");

            migrationBuilder.DropTable(
                name: "TimelineMembreTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimelineMembres",
                table: "TimelineMembres");

            migrationBuilder.DropIndex(
                name: "IX_TimelineMembres_TypeId",
                table: "TimelineMembres");

            migrationBuilder.RenameTable(
                name: "TimelineMembres",
                newName: "TimelineMembre");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "TimelineMembre",
                newName: "Type");

            migrationBuilder.RenameIndex(
                name: "IX_TimelineMembres_MembreId",
                table: "TimelineMembre",
                newName: "IX_TimelineMembre_MembreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimelineMembre",
                table: "TimelineMembre",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TimelineMembre_Membres_MembreId",
                table: "TimelineMembre",
                column: "MembreId",
                principalTable: "Membres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
