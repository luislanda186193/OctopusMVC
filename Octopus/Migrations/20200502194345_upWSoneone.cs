using Microsoft.EntityFrameworkCore.Migrations;

namespace Octopus.Migrations
{
    public partial class upWSoneone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WebServDescId",
                table: "WebServices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WebServices_WebServDescId",
                table: "WebServices",
                column: "WebServDescId");

            migrationBuilder.AddForeignKey(
                name: "FK_WebServices_WebServDescs_WebServDescId",
                table: "WebServices",
                column: "WebServDescId",
                principalTable: "WebServDescs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WebServices_WebServDescs_WebServDescId",
                table: "WebServices");

            migrationBuilder.DropIndex(
                name: "IX_WebServices_WebServDescId",
                table: "WebServices");

            migrationBuilder.DropColumn(
                name: "WebServDescId",
                table: "WebServices");
        }
    }
}
