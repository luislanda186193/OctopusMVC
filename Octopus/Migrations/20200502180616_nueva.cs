using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Octopus.Migrations
{
    public partial class nueva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         

            migrationBuilder.CreateTable(
                name: "Carriers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarrierName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carriers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebServRegions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebServiceId = table.Column<int>(nullable: false),
                    RegionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebServRegions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebServRegions_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WebServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebServiceName = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    WebServRegionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebServices_WebServRegions_WebServRegionId",
                        column: x => x.WebServRegionId,
                        principalTable: "WebServRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

         

            migrationBuilder.CreateIndex(
                name: "IX_WebServices_WebServRegionId",
                table: "WebServices",
                column: "WebServRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_WebServRegions_RegionId",
                table: "WebServRegions",
                column: "RegionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
       

            migrationBuilder.DropTable(
                name: "Ladas");

        
      
      

            migrationBuilder.DropTable(
                name: "Regions");

        }
    }
}
