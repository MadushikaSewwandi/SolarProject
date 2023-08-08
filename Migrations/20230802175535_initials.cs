using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UmbracoSolarProject1.Migrations
{
    /// <inheritdoc />
<<<<<<<< HEAD:Migrations/20230807022547_rating.cs
    public partial class rating : Migration
========
    public partial class initials : Migration
>>>>>>>> 00b850c98c6009f4be022f430b2c7e4b286586e5:Migrations/20230802175535_initials.cs
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
<<<<<<<< HEAD:Migrations/20230807022547_rating.cs
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    RatingValue = table.Column<int>(type: "int", nullable: false)
========
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    ProductThumbnail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductLink = table.Column<string>(type: "nvarchar(max)", nullable: false)
>>>>>>>> 00b850c98c6009f4be022f430b2c7e4b286586e5:Migrations/20230802175535_initials.cs
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Register",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Register", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
<<<<<<<< HEAD:Migrations/20230807022547_rating.cs
                name: "Rating");
========
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Register");
>>>>>>>> 00b850c98c6009f4be022f430b2c7e4b286586e5:Migrations/20230802175535_initials.cs
        }
    }
}
