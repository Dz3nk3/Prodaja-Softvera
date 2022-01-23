using Microsoft.EntityFrameworkCore.Migrations;

namespace Prodaja_Softvera_ver3.Data.Migrations
{
    public partial class migracija3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_Racun_RacunID",
                table: "Narudzba");

            migrationBuilder.AlterColumn<int>(
                name: "RacunID",
                table: "Narudzba",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_Racun_RacunID",
                table: "Narudzba",
                column: "RacunID",
                principalTable: "Racun",
                principalColumn: "RacunID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_Racun_RacunID",
                table: "Narudzba");

            migrationBuilder.AlterColumn<int>(
                name: "RacunID",
                table: "Narudzba",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_Racun_RacunID",
                table: "Narudzba",
                column: "RacunID",
                principalTable: "Racun",
                principalColumn: "RacunID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
