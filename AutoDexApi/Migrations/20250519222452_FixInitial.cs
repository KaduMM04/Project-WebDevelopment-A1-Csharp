using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoDexApi.Migrations
{
    /// <inheritdoc />
    public partial class FixInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Vehicles_CarId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Vehicles",
                newName: "MotorcycleId");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "Cars",
                newName: "MotorcycleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Vehicles_MotorcycleId",
                table: "Cars",
                column: "MotorcycleId",
                principalTable: "Vehicles",
                principalColumn: "MotorcycleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Vehicles_MotorcycleId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "MotorcycleId",
                table: "Vehicles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MotorcycleId",
                table: "Cars",
                newName: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Vehicles_CarId",
                table: "Cars",
                column: "CarId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
