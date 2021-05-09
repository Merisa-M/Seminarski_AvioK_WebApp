using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeminarskiAvio_K.Migrations
{
    public partial class incijalna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    GradID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.GradID);
                });

            migrationBuilder.CreateTable(
                name: "Klasa",
                columns: table => new
                {
                    KlasaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klasa", x => x.KlasaID);
                });

            migrationBuilder.CreateTable(
                name: "KorisnickiNalog",
                columns: table => new
                {
                    KorisnickiNalogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lozinka = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnickiNalog", x => x.KorisnickiNalogID);
                });

            migrationBuilder.CreateTable(
                name: "Zaposlenik",
                columns: table => new
                {
                    ZaposlenikID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojUgovora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdresaSlike = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaposlenik", x => x.ZaposlenikID);
                });

            migrationBuilder.CreateTable(
                name: "Putovanja",
                columns: table => new
                {
                    PutovanjaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProsjecnaOcjena = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GradID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Putovanja", x => x.PutovanjaID);
                    table.ForeignKey(
                        name: "FK_Putovanja_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Avion",
                columns: table => new
                {
                    AvionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kapacitet = table.Column<int>(type: "int", nullable: false),
                    KlasaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avion", x => x.AvionID);
                    table.ForeignKey(
                        name: "FK_Avion_Klasa_KlasaID",
                        column: x => x.KlasaID,
                        principalTable: "Klasa",
                        principalColumn: "KlasaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Let",
                columns: table => new
                {
                    LetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Trajanje = table.Column<int>(type: "int", nullable: false),
                    Cijena = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VrijemePolaska = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GradID = table.Column<int>(type: "int", nullable: false),
                    KlasaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Let", x => x.LetID);
                    table.ForeignKey(
                        name: "FK_Let_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Let_Klasa_KlasaID",
                        column: x => x.KlasaID,
                        principalTable: "Klasa",
                        principalColumn: "KlasaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Sjediste",
                columns: table => new
                {
                    SjedisteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Red = table.Column<int>(type: "int", nullable: false),
                    Kolona = table.Column<int>(type: "int", nullable: false),
                    KlasaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sjediste", x => x.SjedisteID);
                    table.ForeignKey(
                        name: "FK_Sjediste_Klasa_KlasaID",
                        column: x => x.KlasaID,
                        principalTable: "Klasa",
                        principalColumn: "KlasaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnickiNalogID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminID);
                    table.ForeignKey(
                        name: "FK_Admin_KorisnickiNalog_KorisnickiNalogID",
                        column: x => x.KorisnickiNalogID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "KorisnickiNalogID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AutorizacijskiToken",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrijednost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnickiNalogID = table.Column<int>(type: "int", nullable: false),
                    VrijemeEvidentiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpAdresa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorizacijskiToken", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AutorizacijskiToken_KorisnickiNalog_KorisnickiNalogID",
                        column: x => x.KorisnickiNalogID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "KorisnickiNalogID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Kupac",
                columns: table => new
                {
                    KupacID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradID = table.Column<int>(type: "int", nullable: false),
                    BrojTokena = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnickiNalogID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupac", x => x.KupacID);
                    table.ForeignKey(
                        name: "FK_Kupac_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Kupac_KorisnickiNalog_KorisnickiNalogID",
                        column: x => x.KorisnickiNalogID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "KorisnickiNalogID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ZaposlenikPutovanje",
                columns: table => new
                {
                    ZaposlenikPutovanjeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZaposlenikID = table.Column<int>(type: "int", nullable: false),
                    PutovanjeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZaposlenikPutovanje", x => x.ZaposlenikPutovanjeID);
                    table.ForeignKey(
                        name: "FK_ZaposlenikPutovanje_Putovanja_PutovanjeID",
                        column: x => x.PutovanjeID,
                        principalTable: "Putovanja",
                        principalColumn: "PutovanjaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ZaposlenikPutovanje_Zaposlenik_ZaposlenikID",
                        column: x => x.ZaposlenikID,
                        principalTable: "Zaposlenik",
                        principalColumn: "ZaposlenikID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "NagradnaIgra",
                columns: table => new
                {
                    NagradnaIgraID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pocetak = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kraj = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdminID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NagradnaIgra", x => x.NagradnaIgraID);
                    table.ForeignKey(
                        name: "FK_NagradnaIgra_Admin_AdminID",
                        column: x => x.AdminID,
                        principalTable: "Admin",
                        principalColumn: "AdminID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Novosti",
                columns: table => new
                {
                    NovostiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KratkiSadrzaj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumVrijemeObjave = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdresaSlike = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Novosti", x => x.NovostiID);
                    table.ForeignKey(
                        name: "FK_Novosti_Admin_AdminID",
                        column: x => x.AdminID,
                        principalTable: "Admin",
                        principalColumn: "AdminID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PutovanjeKupac",
                columns: table => new
                {
                    PutovanjeKupacID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ocjena = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PutovanjeID = table.Column<int>(type: "int", nullable: false),
                    PutovanjaID = table.Column<int>(type: "int", nullable: true),
                    KupacID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PutovanjeKupac", x => x.PutovanjeKupacID);
                    table.ForeignKey(
                        name: "FK_PutovanjeKupac_Kupac_KupacID",
                        column: x => x.KupacID,
                        principalTable: "Kupac",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PutovanjeKupac_Putovanja_PutovanjaID",
                        column: x => x.PutovanjaID,
                        principalTable: "Putovanja",
                        principalColumn: "PutovanjaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recenzija",
                columns: table => new
                {
                    RecenzijaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sadrzaj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VrijemeKreiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Odobren = table.Column<bool>(type: "bit", nullable: false),
                    KupacID = table.Column<int>(type: "int", nullable: false),
                    PutovanjaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recenzija", x => x.RecenzijaID);
                    table.ForeignKey(
                        name: "FK_Recenzija_Kupac_KupacID",
                        column: x => x.KupacID,
                        principalTable: "Kupac",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Recenzija_Putovanja_PutovanjaID",
                        column: x => x.PutovanjaID,
                        principalTable: "Putovanja",
                        principalColumn: "PutovanjaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    RezervacijaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumRezervacije = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumIsteka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Odobrena = table.Column<bool>(type: "bit", nullable: false),
                    KupacID = table.Column<int>(type: "int", nullable: false),
                    LetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.RezervacijaID);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Kupac_KupacID",
                        column: x => x.KupacID,
                        principalTable: "Kupac",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Let_LetID",
                        column: x => x.LetID,
                        principalTable: "Let",
                        principalColumn: "LetID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "KupacNagradnaIgra",
                columns: table => new
                {
                    KupacNagradnaIgraID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KupacID = table.Column<int>(type: "int", nullable: false),
                    NagradnaIgraID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KupacNagradnaIgra", x => x.KupacNagradnaIgraID);
                    table.ForeignKey(
                        name: "FK_KupacNagradnaIgra_Kupac_KupacID",
                        column: x => x.KupacID,
                        principalTable: "Kupac",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_KupacNagradnaIgra_NagradnaIgra_NagradnaIgraID",
                        column: x => x.NagradnaIgraID,
                        principalTable: "NagradnaIgra",
                        principalColumn: "NagradnaIgraID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Karta",
                columns: table => new
                {
                    KartaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KupacID = table.Column<int>(type: "int", nullable: false),
                    SjedisteID = table.Column<int>(type: "int", nullable: false),
                    RezervacijaID = table.Column<int>(type: "int", nullable: false),
                    LetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Karta", x => x.KartaID);
                    table.ForeignKey(
                        name: "FK_Karta_Kupac_KupacID",
                        column: x => x.KupacID,
                        principalTable: "Kupac",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Karta_Let_LetID",
                        column: x => x.LetID,
                        principalTable: "Let",
                        principalColumn: "LetID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Karta_Rezervacija_RezervacijaID",
                        column: x => x.RezervacijaID,
                        principalTable: "Rezervacija",
                        principalColumn: "RezervacijaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Karta_Sjediste_SjedisteID",
                        column: x => x.SjedisteID,
                        principalTable: "Sjediste",
                        principalColumn: "SjedisteID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_KorisnickiNalogID",
                table: "Admin",
                column: "KorisnickiNalogID");

            migrationBuilder.CreateIndex(
                name: "IX_AutorizacijskiToken_KorisnickiNalogID",
                table: "AutorizacijskiToken",
                column: "KorisnickiNalogID");

            migrationBuilder.CreateIndex(
                name: "IX_Avion_KlasaID",
                table: "Avion",
                column: "KlasaID");

            migrationBuilder.CreateIndex(
                name: "IX_Karta_KupacID",
                table: "Karta",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_Karta_LetID",
                table: "Karta",
                column: "LetID");

            migrationBuilder.CreateIndex(
                name: "IX_Karta_RezervacijaID",
                table: "Karta",
                column: "RezervacijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Karta_SjedisteID",
                table: "Karta",
                column: "SjedisteID");

            migrationBuilder.CreateIndex(
                name: "IX_Kupac_GradID",
                table: "Kupac",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Kupac_KorisnickiNalogID",
                table: "Kupac",
                column: "KorisnickiNalogID");

            migrationBuilder.CreateIndex(
                name: "IX_KupacNagradnaIgra_KupacID",
                table: "KupacNagradnaIgra",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_KupacNagradnaIgra_NagradnaIgraID",
                table: "KupacNagradnaIgra",
                column: "NagradnaIgraID");

            migrationBuilder.CreateIndex(
                name: "IX_Let_GradID",
                table: "Let",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Let_KlasaID",
                table: "Let",
                column: "KlasaID");

            migrationBuilder.CreateIndex(
                name: "IX_NagradnaIgra_AdminID",
                table: "NagradnaIgra",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_Novosti_AdminID",
                table: "Novosti",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_Putovanja_GradID",
                table: "Putovanja",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_PutovanjeKupac_KupacID",
                table: "PutovanjeKupac",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_PutovanjeKupac_PutovanjaID",
                table: "PutovanjeKupac",
                column: "PutovanjaID");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzija_KupacID",
                table: "Recenzija",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzija_PutovanjaID",
                table: "Recenzija",
                column: "PutovanjaID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_KupacID",
                table: "Rezervacija",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_LetID",
                table: "Rezervacija",
                column: "LetID");

            migrationBuilder.CreateIndex(
                name: "IX_Sjediste_KlasaID",
                table: "Sjediste",
                column: "KlasaID");

            migrationBuilder.CreateIndex(
                name: "IX_ZaposlenikPutovanje_PutovanjeID",
                table: "ZaposlenikPutovanje",
                column: "PutovanjeID");

            migrationBuilder.CreateIndex(
                name: "IX_ZaposlenikPutovanje_ZaposlenikID",
                table: "ZaposlenikPutovanje",
                column: "ZaposlenikID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutorizacijskiToken");

            migrationBuilder.DropTable(
                name: "Avion");

            migrationBuilder.DropTable(
                name: "Karta");

            migrationBuilder.DropTable(
                name: "KupacNagradnaIgra");

            migrationBuilder.DropTable(
                name: "Novosti");

            migrationBuilder.DropTable(
                name: "PutovanjeKupac");

            migrationBuilder.DropTable(
                name: "Recenzija");

            migrationBuilder.DropTable(
                name: "ZaposlenikPutovanje");

            migrationBuilder.DropTable(
                name: "Rezervacija");

            migrationBuilder.DropTable(
                name: "Sjediste");

            migrationBuilder.DropTable(
                name: "NagradnaIgra");

            migrationBuilder.DropTable(
                name: "Putovanja");

            migrationBuilder.DropTable(
                name: "Zaposlenik");

            migrationBuilder.DropTable(
                name: "Kupac");

            migrationBuilder.DropTable(
                name: "Let");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "Klasa");

            migrationBuilder.DropTable(
                name: "KorisnickiNalog");
        }
    }
}
