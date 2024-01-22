using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaberApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Estimate_many_to_many_relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estimates",
                columns: table => new
                {
                    EstimateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ServieType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estimates", x => x.EstimateId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EstimateService",
                columns: table => new
                {
                    EstimateListEstimateId = table.Column<int>(type: "int", nullable: false),
                    ServiceListServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstimateService", x => new { x.EstimateListEstimateId, x.ServiceListServiceId });
                    table.ForeignKey(
                        name: "FK_EstimateService_Estimates_EstimateListEstimateId",
                        column: x => x.EstimateListEstimateId,
                        principalTable: "Estimates",
                        principalColumn: "EstimateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstimateService_Services_ServiceListServiceId",
                        column: x => x.ServiceListServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EstimateService_ServiceListServiceId",
                table: "EstimateService",
                column: "ServiceListServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstimateService");

            migrationBuilder.DropTable(
                name: "Estimates");
        }
    }
}
