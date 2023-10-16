using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Teatru.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bilet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    spectacol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rand = table.Column<int>(type: "int", nullable: false),
                    numar = table.Column<int>(type: "int", nullable: false),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilet", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Spectacol",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titlu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    regizor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    actori = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nrBilete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spectacol", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bilet");

            migrationBuilder.DropTable(
                name: "Spectacol");
        }
    }
}
