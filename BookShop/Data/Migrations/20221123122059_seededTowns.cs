using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShop.Data.Migrations
{
    public partial class seededTowns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "Id", "IsDeleted", "Location", "Name" },
                values: new object[] { 1, false, "43.075672, 25.617151", "Veliko Tarnovo" });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "Id", "IsDeleted", "Location", "Name" },
                values: new object[] { 2, false, "42.698334, 23.319941", "Sofia" });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "Id", "IsDeleted", "Location", "Name" },
                values: new object[] { 3, false, "43.204666, 27.910543", "Varna" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
