using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VegeFoods_MVC.Migrations
{
    /// <inheritdoc />
    public partial class INITdsh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Read",
                table: "ContacUs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Read",
                table: "ContacUs");
        }
    }
}
