using Microsoft.EntityFrameworkCore.Migrations;

namespace Octopus.Migrations
{
    public partial class downWSmulti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WebServDescs_WebServices_WebServiceId",
                table: "WebServDescs");

            migrationBuilder.DropIndex(
                name: "IX_WebServDescs_WebServiceId",
                table: "WebServDescs");

            migrationBuilder.DropColumn(
                name: "WebServiceId",
                table: "WebServDescs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WebServiceId",
                table: "WebServDescs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WebServDescs_WebServiceId",
                table: "WebServDescs",
                column: "WebServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_WebServDescs_WebServices_WebServiceId",
                table: "WebServDescs",
                column: "WebServiceId",
                principalTable: "WebServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
