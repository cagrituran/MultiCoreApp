using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiCoreApp.DataAccessLayer.Migrations
{
    public partial class sa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tblProducts",
                keyColumn: "Id",
                keyValue: new Guid("4d4af9a8-56d0-4ffa-a5ab-6462c2c10f41"));

            migrationBuilder.DeleteData(
                table: "tblProducts",
                keyColumn: "Id",
                keyValue: new Guid("55946fda-d9c5-4c9b-91be-eb71b231e78b"));

            migrationBuilder.DeleteData(
                table: "tblProducts",
                keyColumn: "Id",
                keyValue: new Guid("6890250a-625c-4890-b42d-a8395839378a"));

            migrationBuilder.DeleteData(
                table: "tblProducts",
                keyColumn: "Id",
                keyValue: new Guid("b418bb57-8ee5-44e2-8299-344c36de9022"));

            migrationBuilder.DeleteData(
                table: "tblProducts",
                keyColumn: "Id",
                keyValue: new Guid("ce04c268-4430-4fa9-be01-98745fecb851"));

            migrationBuilder.DeleteData(
                table: "tblProducts",
                keyColumn: "Id",
                keyValue: new Guid("e4d3bfe8-8644-49b4-a723-44eb2d3428ac"));

            migrationBuilder.DeleteData(
                table: "tblCategories",
                keyColumn: "Id",
                keyValue: new Guid("95407c2f-47a3-42b1-9bec-069d0de89fd9"));

            migrationBuilder.DeleteData(
                table: "tblCategories",
                keyColumn: "Id",
                keyValue: new Guid("b80962c6-b5a9-4697-bb07-263126e481a9"));

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

            migrationBuilder.InsertData(
                table: "tblCategories",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("1c6a967a-ab1d-4421-bc07-9197f78a5b42"), false, "Defterler" },
                    { new Guid("8e943cf6-ee67-444c-9b52-a6c0047d0e2e"), false, "Kalemler" }
                });

            migrationBuilder.InsertData(
                table: "tblCustomers",
                columns: new[] { "Id", "Address", "City", "Email", "IsDeleted", "Name", "Phone" },
                values: new object[,]
                {
                    { new Guid("cfa58c5b-0445-44f6-a1a7-ea5b09cec4a5"), "ankara", "ank", "feleket@hotmail.com", false, "Hasan Aga", "333" },
                    { new Guid("f8f10a86-c942-4f34-90a1-b78c8455d309"), "istanbul", "ist", "cgr@hotmail.com", false, "Mehmet Aga", "555" }
                });

            migrationBuilder.InsertData(
                table: "tblProducts",
                columns: new[] { "Id", "CategoryId", "IsDeleted", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("863a6e43-ca77-4310-a674-209b5eb7d7bc"), new Guid("8e943cf6-ee67-444c-9b52-a6c0047d0e2e"), false, "Kursun Kalem", 62.13m, 100 },
                    { new Guid("8d75fcf3-81a0-41d0-ad9f-1582e4ae8107"), new Guid("1c6a967a-ab1d-4421-bc07-9197f78a5b42"), false, "Dumduz Defter", 62.13m, 0 },
                    { new Guid("c011a66d-9eba-4f36-9048-9b295b7f614f"), new Guid("8e943cf6-ee67-444c-9b52-a6c0047d0e2e"), false, "Dolma Kalem", 122.53m, 100 },
                    { new Guid("d2fa75f7-a722-4568-8b3f-0674d51e15a7"), new Guid("1c6a967a-ab1d-4421-bc07-9197f78a5b42"), false, "Kareli Defter", 18.06m, 100 },
                    { new Guid("d7a96b84-7d6c-4f3d-a849-47a48713fab5"), new Guid("8e943cf6-ee67-444c-9b52-a6c0047d0e2e"), false, "Tukenmez Kalem", 18.06m, 100 },
                    { new Guid("d8873e83-65d3-498e-8d9b-bb9fe1d6d39d"), new Guid("1c6a967a-ab1d-4421-bc07-9197f78a5b42"), false, "Cizgili Defter", 122.53m, 100 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCustomers");

            migrationBuilder.DeleteData(
                table: "tblProducts",
                keyColumn: "Id",
                keyValue: new Guid("863a6e43-ca77-4310-a674-209b5eb7d7bc"));

            migrationBuilder.DeleteData(
                table: "tblProducts",
                keyColumn: "Id",
                keyValue: new Guid("8d75fcf3-81a0-41d0-ad9f-1582e4ae8107"));

            migrationBuilder.DeleteData(
                table: "tblProducts",
                keyColumn: "Id",
                keyValue: new Guid("c011a66d-9eba-4f36-9048-9b295b7f614f"));

            migrationBuilder.DeleteData(
                table: "tblProducts",
                keyColumn: "Id",
                keyValue: new Guid("d2fa75f7-a722-4568-8b3f-0674d51e15a7"));

            migrationBuilder.DeleteData(
                table: "tblProducts",
                keyColumn: "Id",
                keyValue: new Guid("d7a96b84-7d6c-4f3d-a849-47a48713fab5"));

            migrationBuilder.DeleteData(
                table: "tblProducts",
                keyColumn: "Id",
                keyValue: new Guid("d8873e83-65d3-498e-8d9b-bb9fe1d6d39d"));

            migrationBuilder.DeleteData(
                table: "tblCategories",
                keyColumn: "Id",
                keyValue: new Guid("1c6a967a-ab1d-4421-bc07-9197f78a5b42"));

            migrationBuilder.DeleteData(
                table: "tblCategories",
                keyColumn: "Id",
                keyValue: new Guid("8e943cf6-ee67-444c-9b52-a6c0047d0e2e"));

            migrationBuilder.InsertData(
                table: "tblCategories",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[] { new Guid("95407c2f-47a3-42b1-9bec-069d0de89fd9"), false, "Defterler" });

            migrationBuilder.InsertData(
                table: "tblCategories",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[] { new Guid("b80962c6-b5a9-4697-bb07-263126e481a9"), false, "Kalemler" });

            migrationBuilder.InsertData(
                table: "tblProducts",
                columns: new[] { "Id", "CategoryId", "IsDeleted", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("4d4af9a8-56d0-4ffa-a5ab-6462c2c10f41"), new Guid("b80962c6-b5a9-4697-bb07-263126e481a9"), false, "Kursun Kalem", 62.13m, 100 },
                    { new Guid("55946fda-d9c5-4c9b-91be-eb71b231e78b"), new Guid("b80962c6-b5a9-4697-bb07-263126e481a9"), false, "Dolma Kalem", 122.53m, 100 },
                    { new Guid("6890250a-625c-4890-b42d-a8395839378a"), new Guid("95407c2f-47a3-42b1-9bec-069d0de89fd9"), false, "Kareli Defter", 18.06m, 100 },
                    { new Guid("b418bb57-8ee5-44e2-8299-344c36de9022"), new Guid("b80962c6-b5a9-4697-bb07-263126e481a9"), false, "Tukenmez Kalem", 18.06m, 100 },
                    { new Guid("ce04c268-4430-4fa9-be01-98745fecb851"), new Guid("95407c2f-47a3-42b1-9bec-069d0de89fd9"), false, "Cizgili Defter", 122.53m, 100 },
                    { new Guid("e4d3bfe8-8644-49b4-a723-44eb2d3428ac"), new Guid("95407c2f-47a3-42b1-9bec-069d0de89fd9"), false, "Dumduz Defter", 62.13m, 0 }
                });
        }
    }
}
