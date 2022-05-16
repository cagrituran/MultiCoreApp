using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiCoreApp.DataAccessLayer.Migrations
{
    public partial class Init : Migration
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

            migrationBuilder.CreateIndex(
                name: "IX_tblProducts_CategoryId",
                table: "tblProducts",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblProducts");

            migrationBuilder.DropTable(
                name: "tblCategories");
        }
    }
}
