using Microsoft.EntityFrameworkCore.Migrations;

namespace Octopus.Migrations
{
    public partial class ladaReg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ladas_Regions_FK_RegionId",
                table: "Ladas");

            migrationBuilder.DropIndex(
                name: "IX_Ladas_FK_RegionId",
                table: "Ladas");

            migrationBuilder.DropColumn(
                name: "FK_RegionId",
                table: "Ladas");

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Ladas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ladas_RegionId",
                table: "Ladas",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ladas_Regions_RegionId",
                table: "Ladas",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ladas_Regions_RegionId",
                table: "Ladas");

            migrationBuilder.DropIndex(
                name: "IX_Ladas_RegionId",
                table: "Ladas");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Ladas");

            migrationBuilder.AddColumn<int>(
                name: "FK_RegionId",
                table: "Ladas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ladas_FK_RegionId",
                table: "Ladas",
                column: "FK_RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ladas_Regions_FK_RegionId",
                table: "Ladas",
                column: "FK_RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
