using Microsoft.EntityFrameworkCore.Migrations;

namespace Octopus.Migrations
{
    public partial class carrierregion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         
         
            migrationBuilder.AddColumn<int>(
                name: "CarrierId",
                table: "Regions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Regions_CarrierId",
                table: "Regions",
                column: "CarrierId");

     
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropIndex(
                name: "IX_Regions_CarrierId",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "CarrierId",
                table: "Regions");

            migrationBuilder.AddColumn<int>(
                name: "FK_CarrierId",
                table: "Regions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Regions_FK_CarrierId",
                table: "Regions",
                column: "FK_CarrierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Regions_Carriers_FK_CarrierId",
                table: "Regions",
                column: "FK_CarrierId",
                principalTable: "Carriers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
