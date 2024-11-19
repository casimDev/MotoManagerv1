using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoManager.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class ajustedriver : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DriversLicense",
                table: "Drivers",
                newName: "DriverLicense");

            migrationBuilder.RenameIndex(
                name: "IX_Drivers_DriversLicense",
                table: "Drivers",
                newName: "IX_Drivers_DriverLicense");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DriverLicense",
                table: "Drivers",
                newName: "DriversLicense");

            migrationBuilder.RenameIndex(
                name: "IX_Drivers_DriverLicense",
                table: "Drivers",
                newName: "IX_Drivers_DriversLicense");
        }
    }
}
