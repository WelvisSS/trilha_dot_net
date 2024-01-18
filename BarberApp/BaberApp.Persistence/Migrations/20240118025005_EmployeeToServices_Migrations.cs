using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaberApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeToServices_Migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Employeess",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Services_EmployeeId",
                table: "Services",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Employeess_EmployeeId",
                table: "Services",
                column: "EmployeeId",
                principalTable: "Employeess",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Employeess_EmployeeId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_EmployeeId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Employeess");
        }
    }
}
