using Microsoft.EntityFrameworkCore.Migrations;

namespace Octopus.Migrations
{
    public partial class wsdescadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WebServDescs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebServiceName = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    WebServiceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebServDescs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebServDescs_WebServices_WebServiceId",
                        column: x => x.WebServiceId,
                        principalTable: "WebServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WebServDescs_WebServiceId",
                table: "WebServDescs",
                column: "WebServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WebServDescs");
        }
    }
}
