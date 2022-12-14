using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShop.Infrastructure.Migrations
{
    public partial class booksExperiment2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "BookTypeId", "Description", "Grade", "ImageUrl", "IsDeleted", "OwnerId", "Price", "PublisherId", "Title", "Year", "datePublished" },
                values: new object[] { 10, 5, "Learn programming while having fun!", 1, "https://m.media-amazon.com/images/I/51WE1rxr-0L._AC_SY780_.jpg", false, "a754571d-5a65-433b-ae02-fc356f354448", 12.50m, 1, "Coding adventures", 2020, new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "BookTypeId", "Description", "Grade", "ImageUrl", "IsDeleted", "OwnerId", "Price", "PublisherId", "Title", "Year", "datePublished" },
                values: new object[] { 11, 3, "Learn the geogrpahy of the whole world.", 7, "https://m.media-amazon.com/images/I/51HiKFBSbFL._AC_SY780_.jpg", false, "a754571d-5a65-433b-ae02-fc356f354448", 10.80m, 2, "Geography", 2022, new DateTime(2022, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);
        }
    }
}
