using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HeliosDataBaseContext.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Civilites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Creation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modification = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Civilites", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Path = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Icon = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PrefixIcon = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SuffixIcon = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modification = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modules_Modules_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Modules",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Creation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modification = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StatutMembres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Creation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modification = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatutMembres", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TypeActivitees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Creation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modification = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeActivitees", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TypeCentres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Creation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modification = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeCentres", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TypeMembres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Creation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modification = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeMembres", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Centres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypeCentreId = table.Column<int>(type: "int", nullable: false),
                    Libelle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Adresse = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodePostal = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ville = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Pays = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Capacite = table.Column<int>(type: "int", nullable: true),
                    brevoFolderId = table.Column<long>(type: "bigint", nullable: true),
                    Creation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modification = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Centres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Centres_TypeCentres_TypeCentreId",
                        column: x => x.TypeCentreId,
                        principalTable: "TypeCentres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Activitees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Libelle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateDebut = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypeActiviteeId = table.Column<int>(type: "int", nullable: false),
                    CentreId = table.Column<int>(type: "int", nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modification = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activitees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activitees_Centres_CentreId",
                        column: x => x.CentreId,
                        principalTable: "Centres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activitees_TypeActivitees_TypeActiviteeId",
                        column: x => x.TypeActiviteeId,
                        principalTable: "TypeActivitees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MailingLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Libelle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CentreId = table.Column<int>(type: "int", nullable: false),
                    brevoListId = table.Column<long>(type: "bigint", nullable: true),
                    Creation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modification = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailingLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MailingLists_Centres_CentreId",
                        column: x => x.CentreId,
                        principalTable: "Centres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Membres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CiviliteId = table.Column<int>(type: "int", nullable: false),
                    Nom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Prenom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypeMembreId = table.Column<int>(type: "int", nullable: false),
                    StatutMembreId = table.Column<int>(type: "int", nullable: false),
                    CentreId = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Profession = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telephone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Adresse = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodePostal = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ville = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Pays = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailValide = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Connaissances = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Commentaires = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateNaissance = table.Column<DateOnly>(type: "date", nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modification = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Membres_Centres_CentreId",
                        column: x => x.CentreId,
                        principalTable: "Centres",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Membres_Civilites_CiviliteId",
                        column: x => x.CiviliteId,
                        principalTable: "Civilites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Membres_StatutMembres_StatutMembreId",
                        column: x => x.StatutMembreId,
                        principalTable: "StatutMembres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Membres_TypeMembres_TypeMembreId",
                        column: x => x.TypeMembreId,
                        principalTable: "TypeMembres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ActiviteeTypeMembre",
                columns: table => new
                {
                    ActiviteesId = table.Column<int>(type: "int", nullable: false),
                    AspectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiviteeTypeMembre", x => new { x.ActiviteesId, x.AspectsId });
                    table.ForeignKey(
                        name: "FK_ActiviteeTypeMembre_Activitees_ActiviteesId",
                        column: x => x.ActiviteesId,
                        principalTable: "Activitees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActiviteeTypeMembre_TypeMembres_AspectsId",
                        column: x => x.AspectsId,
                        principalTable: "TypeMembres",
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
                        name: "FK_MailingListMembre_MailingLists_MailingListsId",
                        column: x => x.MailingListsId,
                        principalTable: "MailingLists",
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

            migrationBuilder.CreateTable(
                name: "ParentsEnfants",
                columns: table => new
                {
                    EnfantsId = table.Column<int>(type: "int", nullable: false),
                    ParentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentsEnfants", x => new { x.EnfantsId, x.ParentsId });
                    table.ForeignKey(
                        name: "FK_ParentsEnfants_Membres_EnfantsId",
                        column: x => x.EnfantsId,
                        principalTable: "Membres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParentsEnfants_Membres_ParentsId",
                        column: x => x.ParentsId,
                        principalTable: "Membres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MotDePasse = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MembreId = table.Column<int>(type: "int", nullable: true),
                    Creation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modification = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Utilisateurs_Membres_MembreId",
                        column: x => x.MembreId,
                        principalTable: "Membres",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Droits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    utilisateurId = table.Column<int>(type: "int", nullable: true),
                    CentreId = table.Column<int>(type: "int", nullable: true),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modification = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Droits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Droits_Centres_CentreId",
                        column: x => x.CentreId,
                        principalTable: "Centres",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Droits_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Droits_Utilisateurs_utilisateurId",
                        column: x => x.utilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Inscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UtilisateurId = table.Column<int>(type: "int", nullable: true),
                    ActiviteeId = table.Column<int>(type: "int", nullable: true),
                    Infos = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Creation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modification = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inscriptions_Activitees_ActiviteeId",
                        column: x => x.ActiviteeId,
                        principalTable: "Activitees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inscriptions_Utilisateurs_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RoleUtilisateur",
                columns: table => new
                {
                    RolesId = table.Column<int>(type: "int", nullable: false),
                    UtilisateursId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUtilisateur", x => new { x.RolesId, x.UtilisateursId });
                    table.ForeignKey(
                        name: "FK_RoleUtilisateur_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUtilisateur_Utilisateurs_UtilisateursId",
                        column: x => x.UtilisateursId,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Civilites",
                columns: new[] { "Id", "Code", "Creation", "Description", "Modification" },
                values: new object[,]
                {
                    { 100, "Monsieur", new DateTime(2025, 6, 1, 23, 12, 41, 955, DateTimeKind.Utc).AddTicks(737), "Monsieur", null },
                    { 200, "Madame", new DateTime(2025, 6, 1, 23, 12, 41, 960, DateTimeKind.Utc).AddTicks(548), "Madame", null }
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "Code", "Creation", "Description", "Icon", "Label", "Modification", "ParentId", "Path", "PrefixIcon", "SuffixIcon", "Title" },
                values: new object[,]
                {
                    { 1000, 1000, new DateTime(2025, 6, 1, 23, 12, 41, 895, DateTimeKind.Utc).AddTicks(9949), null, "home", "Accueil", null, null, "/", "grass", "grass", "Bienvenue dans votre Espace Intranet" },
                    { 2000, 2000, new DateTime(2025, 6, 1, 23, 12, 41, 896, DateTimeKind.Utc).AddTicks(826), null, "temple_buddhist", "Conférence", null, null, "/conferences", null, null, null },
                    { 3000, 3000, new DateTime(2025, 6, 1, 23, 12, 41, 896, DateTimeKind.Utc).AddTicks(839), null, "book", "Registre", null, null, "/registre", null, null, null },
                    { 4000, 4000, new DateTime(2025, 6, 1, 23, 12, 41, 896, DateTimeKind.Utc).AddTicks(860), null, "account_balance", "Comptabilité", null, null, "/compta", null, null, null },
                    { 5000, 5000, new DateTime(2025, 6, 1, 23, 12, 41, 896, DateTimeKind.Utc).AddTicks(873), null, "admin_panel_settings", "Administation", null, null, "/administation", null, null, null },
                    { 6000, 6000, new DateTime(2025, 6, 1, 23, 12, 41, 896, DateTimeKind.Utc).AddTicks(716), null, "email", "Mailing", null, null, "/mailing", null, null, null },
                    { 10000, 10000, new DateTime(2025, 6, 1, 23, 12, 41, 896, DateTimeKind.Utc).AddTicks(872), null, "code", "Développement", null, null, "/developpment", "code", "code", null },
                    { 50000, 50000, new DateTime(2025, 6, 1, 23, 12, 41, 896, DateTimeKind.Utc).AddTicks(874), null, "exit_to_app", "Deconnexion", null, null, "/logout", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Code", "Creation", "Description", "Modification" },
                values: new object[,]
                {
                    { 100, "SYSADMIN", new DateTime(2025, 6, 1, 23, 12, 42, 5, DateTimeKind.Utc).AddTicks(9566), "Administrateur Systeme Full access", null },
                    { 200, "ADMIN_FULL_ACCESS", new DateTime(2025, 6, 1, 23, 12, 42, 6, DateTimeKind.Utc).AddTicks(4325), "Administrateur Full access", null },
                    { 300, "USER_MANAGER", new DateTime(2025, 6, 1, 23, 12, 42, 6, DateTimeKind.Utc).AddTicks(4544), "Manager des droits utilisateurs", null }
                });

            migrationBuilder.InsertData(
                table: "StatutMembres",
                columns: new[] { "Id", "Code", "Creation", "Description", "Modification" },
                values: new object[,]
                {
                    { 100, "Present", new DateTime(2025, 6, 1, 23, 12, 42, 3, DateTimeKind.Utc).AddTicks(1609), "Présent", null },
                    { 200, "Suivi", new DateTime(2025, 6, 1, 23, 12, 42, 3, DateTimeKind.Utc).AddTicks(7336), "Suivi", null },
                    { 300, "Absent", new DateTime(2025, 6, 1, 23, 12, 42, 3, DateTimeKind.Utc).AddTicks(7589), "Absent", null },
                    { 400, "Demissionnaire", new DateTime(2025, 6, 1, 23, 12, 42, 3, DateTimeKind.Utc).AddTicks(7716), "Démissionnaire", null },
                    { 500, "Decede", new DateTime(2025, 6, 1, 23, 12, 42, 3, DateTimeKind.Utc).AddTicks(7825), "Décédé", null }
                });

            migrationBuilder.InsertData(
                table: "TypeActivitees",
                columns: new[] { "Id", "Code", "Creation", "Description", "Modification" },
                values: new object[,]
                {
                    { 100, "ServiceTempleInteresse", new DateTime(2025, 6, 1, 23, 12, 42, 12, DateTimeKind.Utc).AddTicks(3583), "Service du Temple pour membres interessés", null },
                    { 200, "ServiceApprofondissement", new DateTime(2025, 6, 1, 23, 12, 42, 13, DateTimeKind.Utc).AddTicks(7428), "Service du Temple d'approfondissement", null },
                    { 300, "WeekEndVille", new DateTime(2025, 6, 1, 23, 12, 42, 13, DateTimeKind.Utc).AddTicks(7899), "Week-end Ville", null },
                    { 400, "ConferenceRenouvellement", new DateTime(2025, 6, 1, 23, 12, 42, 13, DateTimeKind.Utc).AddTicks(8080), "Conférence Renouvellement", null },
                    { 500, "ConferenceECS", new DateTime(2025, 6, 1, 23, 12, 42, 13, DateTimeKind.Utc).AddTicks(8196), "Conférence ECS", null },
                    { 600, "ConferenceECC", new DateTime(2025, 6, 1, 23, 12, 42, 13, DateTimeKind.Utc).AddTicks(8315), "Conférence ECC", null },
                    { 700, "ConferenceECS_ECC", new DateTime(2025, 6, 1, 23, 12, 42, 13, DateTimeKind.Utc).AddTicks(8439), "Conférence ECS/ECC", null },
                    { 800, "ConventGraalCTO", new DateTime(2025, 6, 1, 23, 12, 42, 13, DateTimeKind.Utc).AddTicks(8554), "Conférence Convent Graal CTO", null }
                });

            migrationBuilder.InsertData(
                table: "TypeCentres",
                columns: new[] { "Id", "Code", "Creation", "Description", "Modification" },
                values: new object[,]
                {
                    { 100, "Renouvellement", new DateTime(2025, 6, 1, 23, 12, 42, 16, DateTimeKind.Utc).AddTicks(1263), "Centre de Renouvellement", null },
                    { 200, "Ville", new DateTime(2025, 6, 1, 23, 12, 42, 16, DateTimeKind.Utc).AddTicks(6371), "Centre de ville", null }
                });

            migrationBuilder.InsertData(
                table: "TypeMembres",
                columns: new[] { "Id", "Code", "Creation", "Description", "Modification" },
                values: new object[,]
                {
                    { 100, "PremierAspect", new DateTime(2025, 6, 1, 23, 12, 41, 998, DateTimeKind.Utc).AddTicks(8229), "Premier Aspect", null },
                    { 200, "DeuxiemeAspect", new DateTime(2025, 6, 1, 23, 12, 41, 999, DateTimeKind.Utc).AddTicks(4081), "Deuxieme Aspect", null },
                    { 300, "ECS", new DateTime(2025, 6, 1, 23, 12, 41, 999, DateTimeKind.Utc).AddTicks(8151), "Ecole de Conscience Supérieure", null },
                    { 400, "ECCLESIA", new DateTime(2025, 6, 1, 23, 12, 42, 0, DateTimeKind.Utc).AddTicks(7301), "Ecclesia", null },
                    { 500, "GRAAL", new DateTime(2025, 6, 1, 23, 12, 42, 0, DateTimeKind.Utc).AddTicks(7476), "Graal", null },
                    { 600, "CinquiemeAspect", new DateTime(2025, 6, 1, 23, 12, 42, 0, DateTimeKind.Utc).AddTicks(7581), "Cinquieme Aspect", null },
                    { 700, "SixiemeAspect", new DateTime(2025, 6, 1, 23, 12, 42, 0, DateTimeKind.Utc).AddTicks(7700), "Sixieme Aspect", null },
                    { 800, "SeptiemeAspect", new DateTime(2025, 6, 1, 23, 12, 42, 0, DateTimeKind.Utc).AddTicks(7783), "Septieme Aspect", null },
                    { 900, "Interesse", new DateTime(2025, 6, 1, 23, 12, 42, 0, DateTimeKind.Utc).AddTicks(7915), "Interessé", null },
                    { 1000, "Jeunesse", new DateTime(2025, 6, 1, 23, 12, 42, 0, DateTimeKind.Utc).AddTicks(8020), "Jeunesse", null }
                });

            migrationBuilder.InsertData(
                table: "Centres",
                columns: new[] { "Id", "Adresse", "Capacite", "Code", "CodePostal", "Creation", "Description", "Libelle", "Modification", "Pays", "TypeCentreId", "Ville", "brevoFolderId" },
                values: new object[,]
                {
                    { 1, "", null, "MG", "93120", new DateTime(2025, 6, 1, 19, 12, 42, 17, DateTimeKind.Local).AddTicks(5391), null, "MontGivroux", null, "France", 100, null, null },
                    { 2, "", null, "PO", "93120", new DateTime(2025, 6, 1, 19, 12, 42, 17, DateTimeKind.Local).AddTicks(6074), null, "Poitier", null, "France", 100, null, null },
                    { 3, "", null, "LC", "93120", new DateTime(2025, 6, 1, 19, 12, 42, 17, DateTimeKind.Local).AddTicks(6076), null, "La Licorne", null, "France", 100, null, null },
                    { 4, "", null, "PR", "93120", new DateTime(2025, 6, 1, 19, 12, 42, 17, DateTimeKind.Local).AddTicks(6077), null, "Paris", null, "France", 200, null, null },
                    { 5, "", null, "LY", "69000", new DateTime(2025, 6, 1, 19, 12, 42, 17, DateTimeKind.Local).AddTicks(6078), null, "Lyon", null, "France", 200, null, null },
                    { 6, "", null, "MA", "13000", new DateTime(2025, 6, 1, 19, 12, 42, 17, DateTimeKind.Local).AddTicks(6079), null, "Marseille", null, "France", 200, null, null },
                    { 7, "", null, "TO", "31000", new DateTime(2025, 6, 1, 19, 12, 42, 17, DateTimeKind.Local).AddTicks(6080), null, "Toulouse", null, "France", 200, null, null },
                    { 8, "", null, "GP", "97100", new DateTime(2025, 6, 1, 19, 12, 42, 17, DateTimeKind.Local).AddTicks(6080), null, "Guadeloupe", null, "France", 200, null, null },
                    { 9, "", null, "AX", "97100", new DateTime(2025, 6, 1, 19, 12, 42, 17, DateTimeKind.Local).AddTicks(6081), null, "Aix-en-Provence", null, "France", 200, null, null },
                    { 10, "", null, "LL", "97100", new DateTime(2025, 6, 1, 19, 12, 42, 17, DateTimeKind.Local).AddTicks(6082), null, "Lille", null, "France", 200, null, null },
                    { 11, "", null, "MT", "97100", new DateTime(2025, 6, 1, 19, 12, 42, 17, DateTimeKind.Local).AddTicks(6083), null, "Metz", null, "France", 200, null, null },
                    { 12, "", null, "MP", "97100", new DateTime(2025, 6, 1, 19, 12, 42, 17, DateTimeKind.Local).AddTicks(6083), null, "Montptelier", null, "France", 200, null, null },
                    { 13, "", null, "PP", "97100", new DateTime(2025, 6, 1, 19, 12, 42, 17, DateTimeKind.Local).AddTicks(6084), null, "Perpignan", null, "France", 200, null, null },
                    { 14, "", null, "CA", "97100", new DateTime(2025, 6, 1, 19, 12, 42, 17, DateTimeKind.Local).AddTicks(6085), null, "Côte d'Azure", null, "France", 200, null, null },
                    { 15, "", null, "RE", "97100", new DateTime(2025, 6, 1, 19, 12, 42, 17, DateTimeKind.Local).AddTicks(6085), null, "Rennes", null, "France", 200, null, null },
                    { 16, "", null, "RU", "97100", new DateTime(2025, 6, 1, 19, 12, 42, 17, DateTimeKind.Local).AddTicks(6086), null, "Rouen", null, "France", 200, null, null },
                    { 17, "", null, "SB", "97100", new DateTime(2025, 6, 1, 19, 12, 42, 17, DateTimeKind.Local).AddTicks(6087), null, "Strasbourg", null, "France", 200, null, null }
                });

            migrationBuilder.InsertData(
                table: "Droits",
                columns: new[] { "Id", "CentreId", "Code", "Creation", "Description", "Modification", "ModuleId", "utilisateurId" },
                values: new object[,]
                {
                    { 1, null, 1, new DateTime(2025, 6, 1, 19, 12, 41, 897, DateTimeKind.Local).AddTicks(352), null, null, 1000, null },
                    { 2, null, 1, new DateTime(2025, 6, 1, 19, 12, 41, 897, DateTimeKind.Local).AddTicks(855), null, null, 2000, null },
                    { 5, null, 1, new DateTime(2025, 6, 1, 19, 12, 41, 897, DateTimeKind.Local).AddTicks(859), null, null, 50000, null }
                });

            migrationBuilder.InsertData(
                table: "Membres",
                columns: new[] { "Id", "Adresse", "CentreId", "CiviliteId", "CodePostal", "Commentaires", "Connaissances", "Creation", "DateNaissance", "Email", "EmailValide", "Modification", "Nom", "Pays", "Prenom", "Profession", "StatutMembreId", "Telephone", "TypeMembreId", "Ville" },
                values: new object[,]
                {
                    { 1, null, null, 100, null, null, null, new DateTime(2025, 6, 1, 19, 12, 42, 9, DateTimeKind.Local).AddTicks(1460), new DateOnly(1, 1, 1), null, true, null, "Admin", null, "SysAdmin", null, 100, null, 900, null },
                    { 2, null, null, 100, null, null, null, new DateTime(2025, 6, 1, 19, 12, 42, 9, DateTimeKind.Local).AddTicks(2106), new DateOnly(1, 1, 1), null, true, null, "Admin", null, "Admin", null, 100, null, 900, null },
                    { 3, null, null, 100, null, null, null, new DateTime(2025, 6, 1, 19, 12, 42, 9, DateTimeKind.Local).AddTicks(2108), new DateOnly(1, 1, 1), null, true, null, "usermanager", null, "usermanager", null, 100, null, 900, null },
                    { 4, null, null, 100, null, null, null, new DateTime(2025, 6, 1, 19, 12, 42, 9, DateTimeKind.Local).AddTicks(2109), new DateOnly(1, 1, 1), null, true, null, "usercentre", null, "usercentre", null, 100, null, 900, null }
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "Code", "Creation", "Description", "Icon", "Label", "Modification", "ParentId", "Path", "PrefixIcon", "SuffixIcon", "Title" },
                values: new object[,]
                {
                    { 2100, 2100, new DateTime(2025, 6, 1, 23, 12, 41, 896, DateTimeKind.Utc).AddTicks(836), null, "person_add", "Inscription", null, 2000, "/conferences/inscription", null, null, null },
                    { 2200, 2200, new DateTime(2025, 6, 1, 23, 12, 41, 896, DateTimeKind.Utc).AddTicks(837), null, "edit", "Mes Inscriptions", null, 2000, "/mesinscriptions", null, null, null },
                    { 2300, 2300, new DateTime(2025, 6, 1, 23, 12, 41, 896, DateTimeKind.Utc).AddTicks(835), null, "post_add", "Créer Conférence", null, 2000, "/creer/conference", null, null, null },
                    { 3010, 3010, new DateTime(2025, 6, 1, 23, 12, 41, 896, DateTimeKind.Utc).AddTicks(841), null, "people", "Fiches Elèves", null, 3000, "/registre/fiches/eleves", null, null, null },
                    { 3020, 3020, new DateTime(2025, 6, 1, 23, 12, 41, 896, DateTimeKind.Utc).AddTicks(842), null, "wb_iridescent", "Fiches Parvis", null, 3000, "/registre/fiches-parvis", null, null, null },
                    { 3030, 3030, new DateTime(2025, 6, 1, 23, 12, 41, 896, DateTimeKind.Utc).AddTicks(843), null, "contact_page", "Fiches Contacts", null, 3000, "/registre/fiches-contacts", null, null, null },
                    { 3040, 3040, new DateTime(2025, 6, 1, 23, 12, 41, 896, DateTimeKind.Utc).AddTicks(845), null, "child_care", "Fiches Jeunesses", null, 3000, "/registre/fiches-jeunesses", null, null, null },
                    { 3050, 3050, new DateTime(2025, 6, 1, 23, 12, 41, 896, DateTimeKind.Utc).AddTicks(846), null, "settings_accessibility", "Fiches Jeunes Rosicruciens", null, 3000, "/registre/fiches-jeunes-rosicruciens", null, null, null },
                    { 3060, 3060, new DateTime(2025, 6, 1, 23, 12, 41, 896, DateTimeKind.Utc).AddTicks(847), null, "featured_play_list", "Saisie Présences", null, 3000, "/registre/traitements", null, null, null },
                    { 3070, 3070, new DateTime(2025, 6, 1, 23, 12, 41, 896, DateTimeKind.Utc).AddTicks(858), null, "insert_chart_outlined", "Statistiques", null, 3000, "/registre/statistiques", null, null, null },
                    { 4010, 4010, new DateTime(2025, 6, 1, 23, 12, 41, 896, DateTimeKind.Utc).AddTicks(861), null, "account_balance_wallet", "Compta en ligne", null, 4000, "/compta/comptes", null, null, null },
                    { 4020, 4020, new DateTime(2025, 6, 1, 23, 12, 41, 896, DateTimeKind.Utc).AddTicks(868), null, "settings", "Paramètre generaux", null, 4000, "/compta/parametres", null, null, null },
                    { 4030, 4030, new DateTime(2025, 6, 1, 23, 12, 41, 896, DateTimeKind.Utc).AddTicks(869), null, "monetization_on", "Sasie écritures répetitives", null, 4000, "/compta/ecritures", null, null, null },
                    { 4040, 4040, new DateTime(2025, 6, 1, 23, 12, 41, 896, DateTimeKind.Utc).AddTicks(871), null, "description", "Comptes/caisse", null, 4000, "/compta/comptescaisse", null, null, null },
                    { 6100, 6100, new DateTime(2025, 6, 1, 23, 12, 41, 896, DateTimeKind.Utc).AddTicks(718), null, "list", "Listes", null, 6000, "/mailing/listes", null, null, null },
                    { 6200, 6200, new DateTime(2025, 6, 1, 23, 12, 41, 896, DateTimeKind.Utc).AddTicks(824), null, "campaign", "Campagnes", null, 6000, "/mailing/campagnes", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Droits",
                columns: new[] { "Id", "CentreId", "Code", "Creation", "Description", "Modification", "ModuleId", "utilisateurId" },
                values: new object[,]
                {
                    { 3, null, 1, new DateTime(2025, 6, 1, 19, 12, 41, 897, DateTimeKind.Local).AddTicks(857), null, null, 2100, null },
                    { 4, null, 1, new DateTime(2025, 6, 1, 19, 12, 41, 897, DateTimeKind.Local).AddTicks(858), null, null, 2200, null }
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "Code", "Creation", "Description", "Icon", "Label", "Modification", "ParentId", "Path", "PrefixIcon", "SuffixIcon", "Title" },
                values: new object[,]
                {
                    { 3061, 3061, new DateTime(2025, 6, 1, 23, 12, 41, 896, DateTimeKind.Utc).AddTicks(848), null, "list_alt", "Présence Villes", null, 3060, "/registre/traitements/encours", null, null, null },
                    { 3062, 3062, new DateTime(2025, 6, 1, 23, 12, 41, 896, DateTimeKind.Utc).AddTicks(850), null, "fact_check", "Présence CR", null, 3060, "/registre/traitements/termines", null, null, null },
                    { 3063, 3063, new DateTime(2025, 6, 1, 23, 12, 41, 896, DateTimeKind.Utc).AddTicks(856), null, "receipt_long", "Présence EI", null, 3060, "/registre/traitements/termines", null, null, null },
                    { 3071, 3071, new DateTime(2025, 6, 1, 23, 12, 41, 896, DateTimeKind.Utc).AddTicks(859), null, "list_alt", "Présences", null, 3070, "/registre/statistiques/villes", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Utilisateurs",
                columns: new[] { "Id", "Creation", "Email", "MembreId", "Modification", "MotDePasse" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 1, 19, 12, 42, 9, DateTimeKind.Local).AddTicks(8926), "admin@rco.com", 1, null, "AQAAAAIAAYagAAAAEEiNVE7GnBd6NNlBeIh1KHdEWcrYV3GpgaIw5NPr3hQ8LCK30Df1/LgmaUfSBliSLg==" },
                    { 2, new DateTime(2025, 6, 1, 19, 12, 42, 9, DateTimeKind.Local).AddTicks(9722), "admin2@rco.com", 2, null, "AQAAAAIAAYagAAAAEEiNVE7GnBd6NNlBeIh1KHdEWcrYV3GpgaIw5NPr3hQ8LCK30Df1/LgmaUfSBliSLg==" },
                    { 3, new DateTime(2025, 6, 1, 19, 12, 42, 9, DateTimeKind.Local).AddTicks(9744), "usermanager@rco.com", 3, null, "AQAAAAIAAYagAAAAEEiNVE7GnBd6NNlBeIh1KHdEWcrYV3GpgaIw5NPr3hQ8LCK30Df1/LgmaUfSBliSLg==" },
                    { 4, new DateTime(2025, 6, 1, 19, 12, 42, 9, DateTimeKind.Local).AddTicks(9749), "usercentre@rco.com", 4, null, "AQAAAAIAAYagAAAAEEiNVE7GnBd6NNlBeIh1KHdEWcrYV3GpgaIw5NPr3hQ8LCK30Df1/LgmaUfSBliSLg==" }
                });

            migrationBuilder.InsertData(
                table: "Droits",
                columns: new[] { "Id", "CentreId", "Code", "Creation", "Description", "Modification", "ModuleId", "utilisateurId" },
                values: new object[,]
                {
                    { 6, 1, 200, new DateTime(2025, 6, 1, 19, 12, 41, 897, DateTimeKind.Local).AddTicks(859), null, null, 3000, 4 },
                    { 7, 1, 200, new DateTime(2025, 6, 1, 19, 12, 41, 897, DateTimeKind.Local).AddTicks(1142), null, null, 3010, 4 },
                    { 8, 1, 200, new DateTime(2025, 6, 1, 19, 12, 41, 897, DateTimeKind.Local).AddTicks(1143), null, null, 4000, 4 },
                    { 9, 2, 100, new DateTime(2025, 6, 1, 19, 12, 41, 897, DateTimeKind.Local).AddTicks(1143), null, null, 3000, 4 },
                    { 10, 2, 200, new DateTime(2025, 6, 1, 19, 12, 41, 897, DateTimeKind.Local).AddTicks(1145), null, null, 2300, 4 }
                });

            migrationBuilder.InsertData(
                table: "RoleUtilisateur",
                columns: new[] { "RolesId", "UtilisateursId" },
                values: new object[,]
                {
                    { 100, 1 },
                    { 200, 2 },
                    { 300, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activitees_CentreId",
                table: "Activitees",
                column: "CentreId");

            migrationBuilder.CreateIndex(
                name: "IX_Activitees_TypeActiviteeId",
                table: "Activitees",
                column: "TypeActiviteeId");

            migrationBuilder.CreateIndex(
                name: "IX_ActiviteeTypeMembre_AspectsId",
                table: "ActiviteeTypeMembre",
                column: "AspectsId");

            migrationBuilder.CreateIndex(
                name: "IX_Centres_Code",
                table: "Centres",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Centres_TypeCentreId",
                table: "Centres",
                column: "TypeCentreId");

            migrationBuilder.CreateIndex(
                name: "IX_Civilites_Code",
                table: "Civilites",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Droits_CentreId",
                table: "Droits",
                column: "CentreId");

            migrationBuilder.CreateIndex(
                name: "IX_Droits_ModuleId",
                table: "Droits",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Droits_utilisateurId",
                table: "Droits",
                column: "utilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_ActiviteeId",
                table: "Inscriptions",
                column: "ActiviteeId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_UtilisateurId",
                table: "Inscriptions",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_MailingListMembre_MembresId",
                table: "MailingListMembre",
                column: "MembresId");

            migrationBuilder.CreateIndex(
                name: "IX_MailingLists_CentreId",
                table: "MailingLists",
                column: "CentreId");

            migrationBuilder.CreateIndex(
                name: "IX_Membres_CentreId",
                table: "Membres",
                column: "CentreId");

            migrationBuilder.CreateIndex(
                name: "IX_Membres_CiviliteId",
                table: "Membres",
                column: "CiviliteId");

            migrationBuilder.CreateIndex(
                name: "IX_Membres_StatutMembreId",
                table: "Membres",
                column: "StatutMembreId");

            migrationBuilder.CreateIndex(
                name: "IX_Membres_TypeMembreId",
                table: "Membres",
                column: "TypeMembreId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_ParentId",
                table: "Modules",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentsEnfants_ParentsId",
                table: "ParentsEnfants",
                column: "ParentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Code",
                table: "Roles",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleUtilisateur_UtilisateursId",
                table: "RoleUtilisateur",
                column: "UtilisateursId");

            migrationBuilder.CreateIndex(
                name: "IX_StatutMembres_Code",
                table: "StatutMembres",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TypeActivitees_Code",
                table: "TypeActivitees",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TypeCentres_Code",
                table: "TypeCentres",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TypeMembres_Code",
                table: "TypeMembres",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_MembreId",
                table: "Utilisateurs",
                column: "MembreId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActiviteeTypeMembre");

            migrationBuilder.DropTable(
                name: "Droits");

            migrationBuilder.DropTable(
                name: "Inscriptions");

            migrationBuilder.DropTable(
                name: "MailingListMembre");

            migrationBuilder.DropTable(
                name: "ParentsEnfants");

            migrationBuilder.DropTable(
                name: "RoleUtilisateur");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Activitees");

            migrationBuilder.DropTable(
                name: "MailingLists");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Utilisateurs");

            migrationBuilder.DropTable(
                name: "TypeActivitees");

            migrationBuilder.DropTable(
                name: "Membres");

            migrationBuilder.DropTable(
                name: "Centres");

            migrationBuilder.DropTable(
                name: "Civilites");

            migrationBuilder.DropTable(
                name: "StatutMembres");

            migrationBuilder.DropTable(
                name: "TypeMembres");

            migrationBuilder.DropTable(
                name: "TypeCentres");
        }
    }
}
