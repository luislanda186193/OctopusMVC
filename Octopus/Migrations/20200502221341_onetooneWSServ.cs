using Microsoft.EntityFrameworkCore.Migrations;

namespace Octopus.Migrations
{
    public partial class onetooneWSServ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WebServices_WebServRegions_WebServRegionId",
                table: "WebServices");

            migrationBuilder.DropIndex(
                name: "IX_WebServices_WebServRegionId",
                table: "WebServices");

            migrationBuilder.DropColumn(
                name: "WebServRegionId",
                table: "WebServices");

            migrationBuilder.CreateIndex(
                name: "IX_WebServRegions_WebServiceId",
                table: "WebServRegions",
                column: "WebServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_WebServRegions_WebServices_WebServiceId",
                table: "WebServRegions",
                column: "WebServiceId",
                principalTable: "WebServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WebServRegions_WebServices_WebServiceId",
                table: "WebServRegions");

            migrationBuilder.DropIndex(
                name: "IX_WebServRegions_WebServiceId",
                table: "WebServRegions");

            migrationBuilder.AddColumn<int>(
                name: "WebServRegionId",
                table: "WebServices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WebServices_WebServRegionId",
                table: "WebServices",
                column: "WebServRegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_WebServices_WebServRegions_WebServRegionId",
                table: "WebServices",
                column: "WebServRegionId",
                principalTable: "WebServRegions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
