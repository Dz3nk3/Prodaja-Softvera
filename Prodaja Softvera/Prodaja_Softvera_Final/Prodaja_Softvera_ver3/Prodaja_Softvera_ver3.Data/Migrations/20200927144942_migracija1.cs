using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prodaja_Softvera_ver3.Data.Migrations
{
    public partial class migracija1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    DrzavaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Oznaka = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.DrzavaID);
                });

            migrationBuilder.CreateTable(
                name: "Fakultet",
                columns: table => new
                {
                    FakultetID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Univerzitet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fakultet", x => x.FakultetID);
                });

            migrationBuilder.CreateTable(
                name: "Kartica",
                columns: table => new
                {
                    KarticaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojKartice = table.Column<string>(nullable: true),
                    Iznos = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kartica", x => x.KarticaID);
                });

            migrationBuilder.CreateTable(
                name: "KorisnickiNalog",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnickoIme = table.Column<string>(nullable: true),
                    Lozinka = table.Column<string>(nullable: true),
                    TipKorisnickogNaloga = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnickiNalog", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ocjena",
                columns: table => new
                {
                    OcjenaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ocjena = table.Column<double>(nullable: false),
                    komentar = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocjena", x => x.OcjenaID);
                });

            migrationBuilder.CreateTable(
                name: "Racun",
                columns: table => new
                {
                    RacunID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<string>(nullable: true),
                    Cijena = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racun", x => x.RacunID);
                });

            migrationBuilder.CreateTable(
                name: "Specifikacije",
                columns: table => new
                {
                    SpecifikacijeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    HDD = table.Column<string>(nullable: true),
                    CPU = table.Column<string>(nullable: true),
                    GPU = table.Column<string>(nullable: true),
                    RAM = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifikacije", x => x.SpecifikacijeID);
                });

            migrationBuilder.CreateTable(
                name: "TipSoftvera",
                columns: table => new
                {
                    TipSoftveraID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipSoftvera", x => x.TipSoftveraID);
                });

            migrationBuilder.CreateTable(
                name: "TipZaposlenika",
                columns: table => new
                {
                    TipZaposlenikaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipZaposlenika", x => x.TipZaposlenikaID);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    GradID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    DrzavaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.GradID);
                    table.ForeignKey(
                        name: "FK_Grad_Drzava_DrzavaID",
                        column: x => x.DrzavaID,
                        principalTable: "Drzava",
                        principalColumn: "DrzavaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutorizacijskiToken",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrijednost = table.Column<string>(nullable: true),
                    KorisnickiNalogId = table.Column<int>(nullable: false),
                    VrijemeEvidentiranja = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorizacijskiToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutorizacijskiToken_KorisnickiNalog_KorisnickiNalogId",
                        column: x => x.KorisnickiNalogId,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Softver",
                columns: table => new
                {
                    SoftverID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Verzija = table.Column<string>(nullable: true),
                    Cijena = table.Column<double>(nullable: false),
                    TipSoftveraID = table.Column<int>(nullable: false),
                    SpecifikacijeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Softver", x => x.SoftverID);
                    table.ForeignKey(
                        name: "FK_Softver_Specifikacije_SpecifikacijeID",
                        column: x => x.SpecifikacijeID,
                        principalTable: "Specifikacije",
                        principalColumn: "SpecifikacijeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Softver_TipSoftvera_TipSoftveraID",
                        column: x => x.TipSoftveraID,
                        principalTable: "TipSoftvera",
                        principalColumn: "TipSoftveraID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Klijent",
                columns: table => new
                {
                    KlijentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Kontakt_broj = table.Column<string>(nullable: true),
                    Datum_rodjenja = table.Column<string>(nullable: true),
                    GradID = table.Column<int>(nullable: false),
                    KarticaID = table.Column<int>(nullable: false),
                    KorisnickiNalogID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klijent", x => x.KlijentID);
                    table.ForeignKey(
                        name: "FK_Klijent_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Klijent_Kartica_KarticaID",
                        column: x => x.KarticaID,
                        principalTable: "Kartica",
                        principalColumn: "KarticaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Klijent_KorisnickiNalog_KorisnickiNalogID",
                        column: x => x.KorisnickiNalogID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zaposlenik",
                columns: table => new
                {
                    ZaposlenikID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Kontakt_br = table.Column<string>(nullable: true),
                    Datum_rodjenja = table.Column<string>(nullable: true),
                    GradID = table.Column<int>(nullable: false),
                    FakultetID = table.Column<int>(nullable: false),
                    TipZaposlenikaID = table.Column<int>(nullable: false),
                    KorisnickiNalogID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaposlenik", x => x.ZaposlenikID);
                    table.ForeignKey(
                        name: "FK_Zaposlenik_Fakultet_FakultetID",
                        column: x => x.FakultetID,
                        principalTable: "Fakultet",
                        principalColumn: "FakultetID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zaposlenik_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zaposlenik_KorisnickiNalog_KorisnickiNalogID",
                        column: x => x.KorisnickiNalogID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zaposlenik_TipZaposlenika_TipZaposlenikaID",
                        column: x => x.TipZaposlenikaID,
                        principalTable: "TipZaposlenika",
                        principalColumn: "TipZaposlenikaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Narudzba",
                columns: table => new
                {
                    NarudzbaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Datum_narudzbe = table.Column<string>(nullable: true),
                    KlijentID = table.Column<int>(nullable: false),
                    RacunID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzba", x => x.NarudzbaID);
                    table.ForeignKey(
                        name: "FK_Narudzba_Klijent_KlijentID",
                        column: x => x.KlijentID,
                        principalTable: "Klijent",
                        principalColumn: "KlijentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Narudzba_Racun_RacunID",
                        column: x => x.RacunID,
                        principalTable: "Racun",
                        principalColumn: "RacunID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Analiza",
                columns: table => new
                {
                    AnalizaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Datum_analize = table.Column<DateTime>(nullable: false),
                    KlijentID = table.Column<int>(nullable: false),
                    ZaposlenikID = table.Column<int>(nullable: false),
                    SoftverID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analiza", x => x.AnalizaID);
                    table.ForeignKey(
                        name: "FK_Analiza_Klijent_KlijentID",
                        column: x => x.KlijentID,
                        principalTable: "Klijent",
                        principalColumn: "KlijentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Analiza_Softver_SoftverID",
                        column: x => x.SoftverID,
                        principalTable: "Softver",
                        principalColumn: "SoftverID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Analiza_Zaposlenik_ZaposlenikID",
                        column: x => x.ZaposlenikID,
                        principalTable: "Zaposlenik",
                        principalColumn: "ZaposlenikID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SoftverNarudzba",
                columns: table => new
                {
                    SoftverNarudzbaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<string>(nullable: true),
                    Kolicina = table.Column<int>(nullable: false),
                    SoftverID = table.Column<int>(nullable: false),
                    NarudzbaID = table.Column<int>(nullable: false),
                    OcjenaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftverNarudzba", x => x.SoftverNarudzbaID);
                    table.ForeignKey(
                        name: "FK_SoftverNarudzba_Narudzba_NarudzbaID",
                        column: x => x.NarudzbaID,
                        principalTable: "Narudzba",
                        principalColumn: "NarudzbaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoftverNarudzba_Ocjena_OcjenaID",
                        column: x => x.OcjenaID,
                        principalTable: "Ocjena",
                        principalColumn: "OcjenaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoftverNarudzba_Softver_SoftverID",
                        column: x => x.SoftverID,
                        principalTable: "Softver",
                        principalColumn: "SoftverID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Analiza_KlijentID",
                table: "Analiza",
                column: "KlijentID");

            migrationBuilder.CreateIndex(
                name: "IX_Analiza_SoftverID",
                table: "Analiza",
                column: "SoftverID");

            migrationBuilder.CreateIndex(
                name: "IX_Analiza_ZaposlenikID",
                table: "Analiza",
                column: "ZaposlenikID");

            migrationBuilder.CreateIndex(
                name: "IX_AutorizacijskiToken_KorisnickiNalogId",
                table: "AutorizacijskiToken",
                column: "KorisnickiNalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Grad_DrzavaID",
                table: "Grad",
                column: "DrzavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Klijent_GradID",
                table: "Klijent",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Klijent_KarticaID",
                table: "Klijent",
                column: "KarticaID");

            migrationBuilder.CreateIndex(
                name: "IX_Klijent_KorisnickiNalogID",
                table: "Klijent",
                column: "KorisnickiNalogID");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_KlijentID",
                table: "Narudzba",
                column: "KlijentID");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_RacunID",
                table: "Narudzba",
                column: "RacunID");

            migrationBuilder.CreateIndex(
                name: "IX_Softver_SpecifikacijeID",
                table: "Softver",
                column: "SpecifikacijeID");

            migrationBuilder.CreateIndex(
                name: "IX_Softver_TipSoftveraID",
                table: "Softver",
                column: "TipSoftveraID");

            migrationBuilder.CreateIndex(
                name: "IX_SoftverNarudzba_NarudzbaID",
                table: "SoftverNarudzba",
                column: "NarudzbaID");

            migrationBuilder.CreateIndex(
                name: "IX_SoftverNarudzba_OcjenaID",
                table: "SoftverNarudzba",
                column: "OcjenaID");

            migrationBuilder.CreateIndex(
                name: "IX_SoftverNarudzba_SoftverID",
                table: "SoftverNarudzba",
                column: "SoftverID");

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenik_FakultetID",
                table: "Zaposlenik",
                column: "FakultetID");

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenik_GradID",
                table: "Zaposlenik",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenik_KorisnickiNalogID",
                table: "Zaposlenik",
                column: "KorisnickiNalogID");

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenik_TipZaposlenikaID",
                table: "Zaposlenik",
                column: "TipZaposlenikaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Analiza");

            migrationBuilder.DropTable(
                name: "AutorizacijskiToken");

            migrationBuilder.DropTable(
                name: "SoftverNarudzba");

            migrationBuilder.DropTable(
                name: "Zaposlenik");

            migrationBuilder.DropTable(
                name: "Narudzba");

            migrationBuilder.DropTable(
                name: "Ocjena");

            migrationBuilder.DropTable(
                name: "Softver");

            migrationBuilder.DropTable(
                name: "Fakultet");

            migrationBuilder.DropTable(
                name: "TipZaposlenika");

            migrationBuilder.DropTable(
                name: "Klijent");

            migrationBuilder.DropTable(
                name: "Racun");

            migrationBuilder.DropTable(
                name: "Specifikacije");

            migrationBuilder.DropTable(
                name: "TipSoftvera");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "Kartica");

            migrationBuilder.DropTable(
                name: "KorisnickiNalog");

            migrationBuilder.DropTable(
                name: "Drzava");
        }
    }
}
