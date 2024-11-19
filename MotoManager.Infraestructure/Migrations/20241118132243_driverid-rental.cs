using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoManager.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class driveridrental : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DriverId",
                table: "MotorcycleRentals",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MotorcycleRentals_DriverId",
                table: "MotorcycleRentals",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_Identifier",
                table: "Drivers",
                column: "Identifier",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MotorcycleRentals_Drivers_DriverId",
                table: "MotorcycleRentals",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MotorcycleRentals_Drivers_DriverId",
                table: "MotorcycleRentals");

            migrationBuilder.DropIndex(
                name: "IX_MotorcycleRentals_DriverId",
                table: "MotorcycleRentals");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_Identifier",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "MotorcycleRentals");
        }
    }
}
