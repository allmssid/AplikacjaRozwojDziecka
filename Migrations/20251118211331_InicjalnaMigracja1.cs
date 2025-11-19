using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aplikacja_wspierajaca_rozwoj_dziecka.Migrations
{
    /// <inheritdoc />
    public partial class InicjalnaMigracja1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aktywnosci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Kierunek = table.Column<int>(type: "int", nullable: false),
                    ZalecanyWiekOdRoku = table.Column<int>(type: "int", nullable: true),
                    ZalecanyWiekDoRoku = table.Column<int>(type: "int", nullable: true),
                    SzacowanyCzasMinuty = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aktywnosci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dzieci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DataUrodzenia = table.Column<DateTime>(type: "date", nullable: false),
                    Notatki = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dzieci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Umiejetnosci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Kierunek = table.Column<int>(type: "int", nullable: false),
                    ZalecanyWiekOdRoku = table.Column<int>(type: "int", nullable: true),
                    ZalecanyWiekDoRoku = table.Column<int>(type: "int", nullable: true),
                    CzyWlasna = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Umiejetnosci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DziennikiAktywnosci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DzieckoId = table.Column<int>(type: "int", nullable: false),
                    AktywnoscId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "date", nullable: false),
                    CzasTrwaniaMinuty = table.Column<int>(type: "int", nullable: true),
                    OcenaReakcjiDziecka = table.Column<int>(type: "int", nullable: true),
                    Notatki = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DziennikiAktywnosci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DziennikiAktywnosci_Aktywnosci_AktywnoscId",
                        column: x => x.AktywnoscId,
                        principalTable: "Aktywnosci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DziennikiAktywnosci_Dzieci_DzieckoId",
                        column: x => x.DzieckoId,
                        principalTable: "Dzieci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AktywnosciUmiejetnosci",
                columns: table => new
                {
                    AktywnosciId = table.Column<int>(type: "int", nullable: false),
                    UmiejetnosciId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AktywnosciUmiejetnosci", x => new { x.AktywnosciId, x.UmiejetnosciId });
                    table.ForeignKey(
                        name: "FK_AktywnosciUmiejetnosci_Aktywnosci_AktywnosciId",
                        column: x => x.AktywnosciId,
                        principalTable: "Aktywnosci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AktywnosciUmiejetnosci_Umiejetnosci_UmiejetnosciId",
                        column: x => x.UmiejetnosciId,
                        principalTable: "Umiejetnosci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DzieckoUmiejetnosci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DzieckoId = table.Column<int>(type: "int", nullable: false),
                    UmiejetnoscId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DataStatusu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Komentarz = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DzieckoUmiejetnosci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DzieckoUmiejetnosci_Dzieci_DzieckoId",
                        column: x => x.DzieckoId,
                        principalTable: "Dzieci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DzieckoUmiejetnosci_Umiejetnosci_UmiejetnoscId",
                        column: x => x.UmiejetnoscId,
                        principalTable: "Umiejetnosci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AktywnosciUmiejetnosci_UmiejetnosciId",
                table: "AktywnosciUmiejetnosci",
                column: "UmiejetnosciId");

            migrationBuilder.CreateIndex(
                name: "IX_DzieckoUmiejetnosci_DzieckoId_UmiejetnoscId",
                table: "DzieckoUmiejetnosci",
                columns: new[] { "DzieckoId", "UmiejetnoscId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DzieckoUmiejetnosci_UmiejetnoscId",
                table: "DzieckoUmiejetnosci",
                column: "UmiejetnoscId");

            migrationBuilder.CreateIndex(
                name: "IX_DziennikiAktywnosci_AktywnoscId",
                table: "DziennikiAktywnosci",
                column: "AktywnoscId");

            migrationBuilder.CreateIndex(
                name: "IX_DziennikiAktywnosci_DzieckoId",
                table: "DziennikiAktywnosci",
                column: "DzieckoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AktywnosciUmiejetnosci");

            migrationBuilder.DropTable(
                name: "DzieckoUmiejetnosci");

            migrationBuilder.DropTable(
                name: "DziennikiAktywnosci");

            migrationBuilder.DropTable(
                name: "Umiejetnosci");

            migrationBuilder.DropTable(
                name: "Aktywnosci");

            migrationBuilder.DropTable(
                name: "Dzieci");
        }
    }
}
