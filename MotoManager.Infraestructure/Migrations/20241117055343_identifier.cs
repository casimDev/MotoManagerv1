using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoManager.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class identifier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Identificador",
                table: "Motorcycles",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identificador",
                table: "Motorcycles");
        }
    }
}
