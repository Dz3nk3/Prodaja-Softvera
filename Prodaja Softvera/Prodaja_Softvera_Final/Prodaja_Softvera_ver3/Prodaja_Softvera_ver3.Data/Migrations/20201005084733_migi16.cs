using Microsoft.EntityFrameworkCore.Migrations;

namespace Prodaja_Softvera_ver3.Data.Migrations
{
    public partial class migi16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoftverNarudzba_Ocjena_OcjenaID",
                table: "SoftverNarudzba");

            migrationBuilder.DropIndex(
                name: "IX_SoftverNarudzba_OcjenaID",
                table: "SoftverNarudzba");

            migrationBuilder.DropColumn(
                name: "OcjenaID",
                table: "SoftverNarudzba");

            migrationBuilder.AddColumn<string>(
                name: "Komentar",
                table: "SoftverNarudzba",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ocjena",
                table: "SoftverNarudzba",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Komentar",
                table: "SoftverNarudzba");

            migrationBuilder.DropColumn(
                name: "Ocjena",
                table: "SoftverNarudzba");

            migrationBuilder.AddColumn<int>(
                name: "OcjenaID",
                table: "SoftverNarudzba",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SoftverNarudzba_OcjenaID",
                table: "SoftverNarudzba",
                column: "OcjenaID");

            migrationBuilder.AddForeignKey(
                name: "FK_SoftverNarudzba_Ocjena_OcjenaID",
                table: "SoftverNarudzba",
                column: "OcjenaID",
                principalTable: "Ocjena",
                principalColumn: "OcjenaID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
