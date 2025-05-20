using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoDexApi.Migrations
{
    /// <inheritdoc />
    public partial class FixCarIO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_VehicleInfos_infoId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_infoId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "infoId",
                table: "Cars");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "infoId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_infoId",
                table: "Cars",
                column: "infoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_VehicleInfos_infoId",
                table: "Cars",
                column: "infoId",
                principalTable: "VehicleInfos",
                principalColumn: "Id");
        }
    }
}
