using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiCoreApp.DataAccessLayer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblCustomers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenEndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblProducts_tblCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "tblCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tblCategories",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("8483e2d1-d39b-4f5a-b54d-c324e5e4bd3f"), false, "Kalemler" },
                    { new Guid("90b46255-3b0d-48d6-a52e-2b5cff5ea49f"), false, "Defterler" }
                });

            migrationBuilder.InsertData(
                table: "tblCustomers",
                columns: new[] { "Id", "Address", "City", "Email", "IsDeleted", "Name", "Phone" },
                values: new object[,]
                {
                    { new Guid("8fce5dce-0308-4921-8be8-1e0346153bdf"), "istanbul", "ist", "cgr@hotmail.com", false, "Mehmet Aga", "555" },
                    { new Guid("cd8bd2ec-4307-4cf6-83b1-c9ecafae98e8"), "ankara", "ank", "feleket@hotmail.com", false, "Hasan Aga", "333" }
                });

            migrationBuilder.InsertData(
                table: "tblProducts",
                columns: new[] { "Id", "CategoryId", "IsDeleted", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("08237e5f-26b6-4a8d-8218-dadbacb43ec7"), new Guid("8483e2d1-d39b-4f5a-b54d-c324e5e4bd3f"), false, "Kursun Kalem", 62.13m, 100 },
                    { new Guid("4be9c56f-b471-4019-acaf-1ab7fc3593bc"), new Guid("8483e2d1-d39b-4f5a-b54d-c324e5e4bd3f"), false, "Dolma Kalem", 122.53m, 100 },
                    { new Guid("7266fa7d-9d1a-4918-8d8f-a361c69ea6cc"), new Guid("8483e2d1-d39b-4f5a-b54d-c324e5e4bd3f"), false, "Tukenmez Kalem", 18.06m, 100 },
                    { new Guid("9e334ce5-37aa-44e4-b067-feda84460c80"), new Guid("90b46255-3b0d-48d6-a52e-2b5cff5ea49f"), false, "Dumduz Defter", 62.13m, 0 },
                    { new Guid("b592e445-3f44-4b6c-aa18-b90876cd8660"), new Guid("90b46255-3b0d-48d6-a52e-2b5cff5ea49f"), false, "Kareli Defter", 18.06m, 100 },
                    { new Guid("df30adff-1ad1-4b26-9d0a-a52fa4aa8f1c"), new Guid("90b46255-3b0d-48d6-a52e-2b5cff5ea49f"), false, "Cizgili Defter", 122.53m, 100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblProducts_CategoryId",
                table: "tblProducts",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCustomers");

            migrationBuilder.DropTable(
                name: "tblProducts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "tblCategories");
        }
    }
}
