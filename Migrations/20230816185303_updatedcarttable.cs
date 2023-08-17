using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UmbracoSolarProject1.Migrations
{
    /// <inheritdoc />
    public partial class updatedcarttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Register_UserId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_UserId",
                table: "CartItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CartItems_UserId",
                table: "CartItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Register_UserId",
                table: "CartItems",
                column: "UserId",
                principalTable: "Register",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
