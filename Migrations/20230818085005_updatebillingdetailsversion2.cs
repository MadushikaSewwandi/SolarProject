using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UmbracoSolarProject1.Migrations
{
    /// <inheritdoc />
    public partial class updatebillingdetailsversion2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingDetail_Register_RegisterId",
                table: "BillingDetail");

            migrationBuilder.DropIndex(
                name: "IX_BillingDetail_RegisterId",
                table: "BillingDetail");

            migrationBuilder.RenameColumn(
                name: "RegisterId",
                table: "BillingDetail",
                newName: "Telephone");

            migrationBuilder.AddColumn<int>(
                name: "EmailId",
                table: "BillingDetail",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "BillingDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "BillingDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BillingDetail_EmailId",
                table: "BillingDetail",
                column: "EmailId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingDetail_Register_EmailId",
                table: "BillingDetail",
                column: "EmailId",
                principalTable: "Register",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingDetail_Register_EmailId",
                table: "BillingDetail");

            migrationBuilder.DropIndex(
                name: "IX_BillingDetail_EmailId",
                table: "BillingDetail");

            migrationBuilder.DropColumn(
                name: "EmailId",
                table: "BillingDetail");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "BillingDetail");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "BillingDetail");

            migrationBuilder.RenameColumn(
                name: "Telephone",
                table: "BillingDetail",
                newName: "RegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingDetail_RegisterId",
                table: "BillingDetail",
                column: "RegisterId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingDetail_Register_RegisterId",
                table: "BillingDetail",
                column: "RegisterId",
                principalTable: "Register",
                principalColumn: "Id");
        }
    }
}
