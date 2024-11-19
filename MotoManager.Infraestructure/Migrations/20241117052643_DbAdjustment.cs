using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoManager.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class DbAdjustment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Make",
                table: "Motorcycles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Make",
                table: "Motorcycles",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
