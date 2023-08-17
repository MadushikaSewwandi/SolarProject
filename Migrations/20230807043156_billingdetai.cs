using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UmbracoSolarProject1.Migrations
{
    /// <inheritdoc />
    public partial class billingdetai : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillingDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    City = table.Column<int>(type: "int", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillingDetail_Register_RegisterId",
                        column: x => x.RegisterId,
                        principalTable: "Register",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillingDetail_RegisterId",
                table: "BillingDetail",
                column: "RegisterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillingDetail");
        }
    }
}
