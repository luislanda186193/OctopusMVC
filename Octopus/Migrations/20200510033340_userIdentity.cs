using Microsoft.EntityFrameworkCore.Migrations;

namespace Octopus.Migrations
{
    public partial class userIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recargas_AspNetUsers_IdentityUserId",
                table: "Recargas");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioGrupos_AspNetUsers_IdentityUserId",
                table: "UsuarioGrupos");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioGrupos_IdentityUserId",
                table: "UsuarioGrupos");

            migrationBuilder.DropIndex(
                name: "IX_Recargas_IdentityUserId",
                table: "Recargas");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "UsuarioGrupos");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Recargas");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UsuarioGrupos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Recargas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioGrupos_UserId",
                table: "UsuarioGrupos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Recargas_UserId",
                table: "Recargas",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recargas_AspNetUsers_UserId",
                table: "Recargas",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioGrupos_AspNetUsers_UserId",
                table: "UsuarioGrupos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recargas_AspNetUsers_UserId",
                table: "Recargas");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioGrupos_AspNetUsers_UserId",
                table: "UsuarioGrupos");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioGrupos_UserId",
                table: "UsuarioGrupos");

            migrationBuilder.DropIndex(
                name: "IX_Recargas_UserId",
                table: "Recargas");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UsuarioGrupos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Recargas");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "UsuarioGrupos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Recargas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioGrupos_IdentityUserId",
                table: "UsuarioGrupos",
                column: "IdentityUserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioGrupos_AspNetUsers_IdentityUserId",
                table: "UsuarioGrupos",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
