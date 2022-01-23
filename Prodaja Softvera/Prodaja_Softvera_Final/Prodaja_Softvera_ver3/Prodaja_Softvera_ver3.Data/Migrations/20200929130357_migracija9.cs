using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prodaja_Softvera_ver3.Data.Migrations
{
    public partial class migracija9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kolicina",
                table: "Narudzba");

            migrationBuilder.AddColumn<double>(
                name: "CijenaSoftvera",
                table: "SoftverNarudzba",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Datum",
                table: "Racun",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CijenaSoftvera",
                table: "SoftverNarudzba");

            migrationBuilder.AlterColumn<string>(
                name: "Datum",
                table: "Racun",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<int>(
                name: "Kolicina",
                table: "Narudzba",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
