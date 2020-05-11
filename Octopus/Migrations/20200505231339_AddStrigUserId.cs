using Microsoft.EntityFrameworkCore.Migrations;

namespace Octopus.Migrations
{
    public partial class AddStrigUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recargas_AspNetUsers_IdentityUserId1",
                table: "Recargas");

            migrationBuilder.DropIndex(
                name: "IX_Recargas_IdentityUserId1",
                table: "Recargas");

            migrationBuilder.DropColumn(
                name: "IdentityUserId1",
                table: "Recargas");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "Recargas",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Recargas_IdentityUserId",
                table: "Recargas",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recargas_AspNetUsers_IdentityUserId",
                table: "Recargas",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recargas_AspNetUsers_IdentityUserId",
                table: "Recargas");

            migrationBuilder.DropIndex(
                name: "IX_Recargas_IdentityUserId",
                table: "Recargas");

            migrationBuilder.AlterColumn<int>(
                name: "IdentityUserId",
                table: "Recargas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId1",
                table: "Recargas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recargas_IdentityUserId1",
                table: "Recargas",
                column: "IdentityUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Recargas_AspNetUsers_IdentityUserId1",
                table: "Recargas",
                column: "IdentityUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
