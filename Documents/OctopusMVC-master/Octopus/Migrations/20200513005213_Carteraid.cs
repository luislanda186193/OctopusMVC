using Microsoft.EntityFrameworkCore.Migrations;

namespace Octopus.Migrations
{
    public partial class Carteraid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carteras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaldoTAE = table.Column<double>(nullable: false),
                    SaldoNormal = table.Column<double>(nullable: false),
                    ComisionTAE = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carteras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioRegions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Comision = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRegions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioRegions_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioRegions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRegions_RegionId",
                table: "UsuarioRegions",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRegions_UserId",
                table: "UsuarioRegions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carteras");

            migrationBuilder.DropTable(
                name: "UsuarioRegions");
        }
    }
}
