using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShop.Infrastructure.Migrations
{
    public partial class seededSchools : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "IsDeleted", "Name", "SchoolType", "TownId" },
                values: new object[,]
                {
                    { 1, false, "PMG Vasil Drumev", 2, 1 },
                    { 2, false, "SMG Paisius of Hilendar", 2, 2 },
                    { 3, false, "Anton Strashimirov", 0, 3 },
                    { 4, false, "SU Emiliyan Stanev", 0, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
