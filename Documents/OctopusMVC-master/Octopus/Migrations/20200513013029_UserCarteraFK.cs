using Microsoft.EntityFrameworkCore.Migrations;

namespace Octopus.Migrations
{
    public partial class UserCarteraFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarteraId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CarteraId",
                table: "AspNetUsers",
                column: "CarteraId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Carteras_CarteraId",
                table: "AspNetUsers",
                column: "CarteraId",
                principalTable: "Carteras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Carteras_CarteraId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CarteraId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CarteraId",
                table: "AspNetUsers");
        }
    }
}
