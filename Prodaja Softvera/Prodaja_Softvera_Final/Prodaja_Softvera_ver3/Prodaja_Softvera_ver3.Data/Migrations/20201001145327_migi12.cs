using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prodaja_Softvera_ver3.Data.Migrations
{
    public partial class migi12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kod",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kod = table.Column<int>(nullable: false),
                    IsValid = table.Column<bool>(nullable: false),
                    VrijemeSlanja = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kod", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kod");
        }
    }
}
