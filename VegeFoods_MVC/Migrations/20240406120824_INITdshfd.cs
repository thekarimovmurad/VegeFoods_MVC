using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VegeFoods_MVC.Migrations
{
    /// <inheritdoc />
    public partial class INITdshfd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Paertner",
                table: "PartnerCounts",
                newName: "Partner");

            migrationBuilder.AddColumn<string>(
                name: "BackgroundImage",
                table: "PartnerCounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackgroundImage",
                table: "PartnerCounts");

            migrationBuilder.RenameColumn(
                name: "Partner",
                table: "PartnerCounts",
                newName: "Paertner");
        }
    }
}
