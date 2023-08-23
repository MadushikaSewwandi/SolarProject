using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UmbracoSolarProject1.Migrations
{
    /// <inheritdoc />
    public partial class loginissue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_BillingDetail_Register_RegisterId",
                table: "BillingDetail",
                column: "RegisterId",
                principalTable: "Register",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingDetail_Register_RegisterId",
                table: "BillingDetail");
        }
    }
}
