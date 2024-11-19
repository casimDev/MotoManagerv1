using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoManager.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class ajustedriveridentifierrequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Identifier",
                table: "Drivers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identifier",
                table: "Drivers");
        }
    }
}
