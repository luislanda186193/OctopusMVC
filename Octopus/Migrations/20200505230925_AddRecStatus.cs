using Microsoft.EntityFrameworkCore.Migrations;

namespace Octopus.Migrations
{
    public partial class AddRecStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Recargas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Statues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statues", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recargas_StatusId",
                table: "Recargas",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recargas_Statues_StatusId",
                table: "Recargas",
                column: "StatusId",
                principalTable: "Statues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recargas_Statues_StatusId",
                table: "Recargas");

            migrationBuilder.DropTable(
                name: "Statues");

            migrationBuilder.DropIndex(
                name: "IX_Recargas_StatusId",
                table: "Recargas");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Recargas");
        }
    }
}
