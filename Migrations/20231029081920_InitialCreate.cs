using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IzySickAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Docteurss",
                columns: table => new
                {
                    DocteurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Specialisation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Sexe = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mdp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Poste = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docteurss", x => x.DocteurId);
                });

            migrationBuilder.CreateTable(
                name: "Medicamentss",
                columns: table => new
                {
                    MedicamentsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomMedicament = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NbEnStock = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prix = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamentss", x => x.MedicamentsId);
                });

            migrationBuilder.CreateTable(
                name: "Receptionnistess",
                columns: table => new
                {
                    ReceptionnisteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Sexe = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mdp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Poste = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receptionnistess", x => x.ReceptionnisteId);
                });

            migrationBuilder.CreateTable(
                name: "MedicamentVenduss",
                columns: table => new
                {
                    MedicamentVenduId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuantiteVendu = table.Column<int>(type: "int", nullable: true),
                    MedicamentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicamentVenduss", x => x.MedicamentVenduId);
                    table.ForeignKey(
                        name: "FK_MedicamentVenduss_Medicamentss_MedicamentsId",
                        column: x => x.MedicamentsId,
                        principalTable: "Medicamentss",
                        principalColumn: "MedicamentsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patientss",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Urgence = table.Column<int>(type: "int", nullable: true),
                    Hospitalise = table.Column<int>(type: "int", nullable: true),
                    Batiment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Chambre = table.Column<int>(type: "int", nullable: true),
                    Etage = table.Column<int>(type: "int", nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Maladie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Traitement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicamentsId = table.Column<int>(type: "int", nullable: true),
                    DateRdv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateHosp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateSortie = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Limite = table.Column<int>(type: "int", nullable: true),
                    Autorisation = table.Column<int>(type: "int", nullable: true),
                    Motif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocteurId = table.Column<int>(type: "int", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Sexe = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patientss", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_Patientss_Docteurss_DocteurId",
                        column: x => x.DocteurId,
                        principalTable: "Docteurss",
                        principalColumn: "DocteurId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patientss_Medicamentss_MedicamentsId",
                        column: x => x.MedicamentsId,
                        principalTable: "Medicamentss",
                        principalColumn: "MedicamentsId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicamentVenduss_MedicamentsId",
                table: "MedicamentVenduss",
                column: "MedicamentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Patientss_DocteurId",
                table: "Patientss",
                column: "DocteurId");

            migrationBuilder.CreateIndex(
                name: "IX_Patientss_MedicamentsId",
                table: "Patientss",
                column: "MedicamentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicamentVenduss");

            migrationBuilder.DropTable(
                name: "Patientss");

            migrationBuilder.DropTable(
                name: "Receptionnistess");

            migrationBuilder.DropTable(
                name: "Docteurss");

            migrationBuilder.DropTable(
                name: "Medicamentss");
        }
    }
}
