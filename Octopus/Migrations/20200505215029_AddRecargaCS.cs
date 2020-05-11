using Microsoft.EntityFrameworkCore.Migrations;

namespace Octopus.Migrations
{
    public partial class AddRecargaCS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recargas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MontoId = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<double>(nullable: false),
                    CarrierId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<double>(nullable: false),
                    DateResolved = table.Column<double>(nullable: true),
                    StatusCode = table.Column<int>(nullable: false),
                    WebServiceId = table.Column<int>(nullable: true),
                    IdentityUserId = table.Column<int>(nullable: false),
                    IdentityUserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recargas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recargas_Carriers_CarrierId",
                        column: x => x.CarrierId,
                        principalTable: "Carriers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recargas_AspNetUsers_IdentityUserId1",
                        column: x => x.IdentityUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recargas_Montos_MontoId",
                        column: x => x.MontoId,
                        principalTable: "Montos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Recargas_WebServices_WebServiceId",
                        column: x => x.WebServiceId,
                        principalTable: "WebServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recargas_CarrierId",
                table: "Recargas",
                column: "CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_Recargas_IdentityUserId1",
                table: "Recargas",
                column: "IdentityUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Recargas_MontoId",
                table: "Recargas",
                column: "MontoId");

            migrationBuilder.CreateIndex(
                name: "IX_Recargas_WebServiceId",
                table: "Recargas",
                column: "WebServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recargas");
        }
    }
}
