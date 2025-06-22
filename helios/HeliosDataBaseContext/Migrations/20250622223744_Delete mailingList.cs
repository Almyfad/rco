using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeliosDataBaseContext.Migrations
{
    /// <inheritdoc />
    public partial class DeletemailingList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MailingListMembre");

            migrationBuilder.DropTable(
                name: "MailingList");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MailingList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CentreId = table.Column<int>(type: "int", nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Libelle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Modification = table.Column<DateTime>(type: "datetime(6)", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    brevoListId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailingList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MailingList_Centres_CentreId",
                        column: x => x.CentreId,
                        principalTable: "Centres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MailingListMembre",
                columns: table => new
                {
                    MailingListsId = table.Column<int>(type: "int", nullable: false),
                    MembresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailingListMembre", x => new { x.MailingListsId, x.MembresId });
                    table.ForeignKey(
                        name: "FK_MailingListMembre_MailingList_MailingListsId",
                        column: x => x.MailingListsId,
                        principalTable: "MailingList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MailingListMembre_Membres_MembresId",
                        column: x => x.MembresId,
                        principalTable: "Membres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_MailingList_CentreId",
                table: "MailingList",
                column: "CentreId");

            migrationBuilder.CreateIndex(
                name: "IX_MailingListMembre_MembresId",
                table: "MailingListMembre",
                column: "MembresId");
        }
    }
}
