using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShop.Infrastructure.Migrations
{
    public partial class seedbooks2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                column: "OwnerId",
                value: "a754571d-5a65-433b-ae02-fc356f354448");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                column: "OwnerId",
                value: "a754571d-5a65-433b-ae02-fc356f354448");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                column: "OwnerId",
                value: "b68f5083-eb62-49f5-b487-b35c0d5a625c");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                column: "OwnerId",
                value: "b68f5083-eb62-49f5-b487-b35c0d5a625c");
        }
    }
}
