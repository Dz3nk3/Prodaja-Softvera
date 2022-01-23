using Microsoft.EntityFrameworkCore.Migrations;

namespace Prodaja_Softvera_ver3.Data.Migrations
{
    public partial class migracija4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoftverNarudzba_Ocjena_OcjenaID",
                table: "SoftverNarudzba");

            migrationBuilder.AlterColumn<int>(
                name: "OcjenaID",
                table: "SoftverNarudzba",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SoftverNarudzba_Ocjena_OcjenaID",
                table: "SoftverNarudzba",
                column: "OcjenaID",
                principalTable: "Ocjena",
                principalColumn: "OcjenaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoftverNarudzba_Ocjena_OcjenaID",
                table: "SoftverNarudzba");

            migrationBuilder.AlterColumn<int>(
                name: "OcjenaID",
                table: "SoftverNarudzba",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SoftverNarudzba_Ocjena_OcjenaID",
                table: "SoftverNarudzba",
                column: "OcjenaID",
                principalTable: "Ocjena",
                principalColumn: "OcjenaID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
