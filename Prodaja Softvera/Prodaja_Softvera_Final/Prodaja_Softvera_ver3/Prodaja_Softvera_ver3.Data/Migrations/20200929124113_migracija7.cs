using Microsoft.EntityFrameworkCore.Migrations;

namespace Prodaja_Softvera_ver3.Data.Migrations
{
    public partial class migracija7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Naziv",
                table: "Narudzba");

            migrationBuilder.AddColumn<string>(
                name: "NazivSoftvera",
                table: "SoftverNarudzba",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Kolicina",
                table: "Racun",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NazivSoftvera",
                table: "SoftverNarudzba");

            migrationBuilder.DropColumn(
                name: "Kolicina",
                table: "Racun");

            migrationBuilder.AddColumn<string>(
                name: "Naziv",
                table: "Narudzba",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
