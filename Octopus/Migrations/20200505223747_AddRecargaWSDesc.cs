using Microsoft.EntityFrameworkCore.Migrations;

namespace Octopus.Migrations
{
    public partial class AddRecargaWSDesc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recargas_WebServices_WebServiceId",
                table: "Recargas");

            migrationBuilder.DropIndex(
                name: "IX_Recargas_WebServiceId",
                table: "Recargas");

            migrationBuilder.DropColumn(
                name: "WebServiceId",
                table: "Recargas");

            migrationBuilder.AddColumn<int>(
                name: "WebServDescId",
                table: "Recargas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recargas_WebServDescId",
                table: "Recargas",
                column: "WebServDescId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recargas_WebServDescs_WebServDescId",
                table: "Recargas",
                column: "WebServDescId",
                principalTable: "WebServDescs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recargas_WebServDescs_WebServDescId",
                table: "Recargas");

            migrationBuilder.DropIndex(
                name: "IX_Recargas_WebServDescId",
                table: "Recargas");

            migrationBuilder.DropColumn(
                name: "WebServDescId",
                table: "Recargas");

            migrationBuilder.AddColumn<int>(
                name: "WebServiceId",
                table: "Recargas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recargas_WebServiceId",
                table: "Recargas",
                column: "WebServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recargas_WebServices_WebServiceId",
                table: "Recargas",
                column: "WebServiceId",
                principalTable: "WebServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
