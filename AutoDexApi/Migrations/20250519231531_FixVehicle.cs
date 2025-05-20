using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoDexApi.Migrations
{
    /// <inheritdoc />
    public partial class FixVehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehicleInfoId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleInfoId",
                table: "Vehicles");
        }
    }
}
