using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UmbracoSolarProject1.Migrations
{
    /// <inheritdoc />
    public partial class updatebillingdetailsversion3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingDetail_Register_EmailId",
                table: "BillingDetail");

            migrationBuilder.RenameColumn(
                name: "EmailId",
                table: "BillingDetail",
                newName: "RegisterId");

            migrationBuilder.RenameIndex(
                name: "IX_BillingDetail_EmailId",
                table: "BillingDetail",
                newName: "IX_BillingDetail_RegisterId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "BillingDetail",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.DropColumn(
                name: "Email",
                table: "BillingDetail");

            migrationBuilder.RenameColumn(
                name: "RegisterId",
                table: "BillingDetail",
                newName: "EmailId");

            migrationBuilder.RenameIndex(
                name: "IX_BillingDetail_RegisterId",
                table: "BillingDetail",
                newName: "IX_BillingDetail_EmailId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingDetail_Register_EmailId",
                table: "BillingDetail",
                column: "EmailId",
                principalTable: "Register",
                principalColumn: "Id");
        }
    }
}
