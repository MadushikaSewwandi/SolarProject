using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UmbracoSolarProject1.Migrations
{
    /// <inheritdoc />
    public partial class ratingsystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Rating");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Rating",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Rating",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Rating",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Review",
                table: "Rating",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "Review",
                table: "Rating");

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "Rating",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
