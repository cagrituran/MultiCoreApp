using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiCoreApp.DataAccessLayer.Migrations
{
    public partial class Selam : Migration
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
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    { new Guid("45b7c1d3-b293-432f-a44a-574fa877a30e"), false, "Defterler" },
                    { new Guid("e91b7f34-a36a-4d7f-ad01-e229b4df1c1c"), false, "Kalemler" }
                });

            migrationBuilder.InsertData(
                table: "tblCustomers",
                columns: new[] { "Id", "Address", "City", "Email", "IsDeleted", "Name", "Phone" },
                values: new object[,]
                {
                    { new Guid("03be10fd-8b6e-4c36-ba0b-6ccdb30c6267"), "istanbul", "ist", "cgr@hotmail.com", false, "Mehmet Aga", "555" },
                    { new Guid("0ee2a2f4-cda7-4908-bd31-107eb0b3924e"), "ankara", "ank", "feleket@hotmail.com", false, "Hasan Aga", "333" }
                });

            migrationBuilder.InsertData(
                table: "tblProducts",
                columns: new[] { "Id", "CategoryId", "IsDeleted", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("13ec1b2a-5774-4b4d-b9a9-50ca005bbfd7"), new Guid("e91b7f34-a36a-4d7f-ad01-e229b4df1c1c"), false, "Kursun Kalem", 62.13m, 100 },
                    { new Guid("5ae24e68-9e5e-4f5a-a769-d533ef6e0167"), new Guid("45b7c1d3-b293-432f-a44a-574fa877a30e"), false, "Kareli Defter", 18.06m, 100 },
                    { new Guid("5f11f3dd-8fa5-4d49-b583-de2dcfb5d4b8"), new Guid("45b7c1d3-b293-432f-a44a-574fa877a30e"), false, "Dumduz Defter", 62.13m, 0 },
                    { new Guid("acc30677-d16c-487d-a38a-d817e905f5ae"), new Guid("45b7c1d3-b293-432f-a44a-574fa877a30e"), false, "Cizgili Defter", 122.53m, 100 },
                    { new Guid("b3732f85-04e4-4634-9632-ed3263e2bfb2"), new Guid("e91b7f34-a36a-4d7f-ad01-e229b4df1c1c"), false, "Tukenmez Kalem", 18.06m, 100 },
                    { new Guid("e0611732-466b-4ce7-b765-43daa6115e44"), new Guid("e91b7f34-a36a-4d7f-ad01-e229b4df1c1c"), false, "Dolma Kalem", 122.53m, 100 }
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
