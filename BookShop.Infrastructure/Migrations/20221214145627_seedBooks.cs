using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShop.Infrastructure.Migrations
{
    public partial class seedBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b68f5083-eb62-49f5-b487-b35c0d5a625c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5497c7c2-981c-4ffb-bd77-4cf42e81270f", "AQAAAAEAACcQAAAAEF3dTZXOgxXWS6wD7eTAU6h3xRJ/jGcD/GiF04grzxql5w8kY+79858XjvMQTfPDsg==", "8c90a3d5-e833-4156-b42a-741b3e545fba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e97bab0a-4e68-404a-b1d9-57bc8865ab83",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe1d0f4c-d8b2-4513-9271-c4c98af8e27d", "AQAAAAEAACcQAAAAEMNawPTJ8cIKjfj+UbNIixEDP/LV7uH0F08xq8L2LfbC59T/ufku3xdVLSPuVW2jjA==", "07e2139c-8b63-4f9b-9b6d-78a9cbacaae4" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "BookTypeId", "Description", "Grade", "ImageUrl", "IsDeleted", "OwnerId", "Price", "PublisherId", "Title", "Year", "datePublished" },
                values: new object[,]
                {
                    { 10, 5, "Learn programming while having fun!", 1, "https://m.media-amazon.com/images/I/51WE1rxr-0L._AC_SY780_.jpg", false, "b68f5083-eb62-49f5-b487-b35c0d5a625c", 12.50m, 1, "Coding adventures", 2020, new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 3, "Learn the geogrpahy of the whole world.", 7, "https://m.media-amazon.com/images/I/51HiKFBSbFL._AC_SY780_.jpg", false, "b68f5083-eb62-49f5-b487-b35c0d5a625c", 10.80m, 2, "Geography", 2022, new DateTime(2022, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b68f5083-eb62-49f5-b487-b35c0d5a625c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ab596ccf-2c31-4388-a5de-a27b9871f004", "AQAAAAEAACcQAAAAEAfvpSWul7KNcj3wZVunp14YoErKxLvaMJsjNF5Qvf+9H5FxDEQfVJC7+jBhRg6+Rw==", "1b1845f6-9e64-4ed4-a890-ebab6b20c53e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e97bab0a-4e68-404a-b1d9-57bc8865ab83",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7713b7c-6903-41da-8b97-63cd9de6ec27", "AQAAAAEAACcQAAAAEPGey2ycQOU+3Qmg5Mqfxi21h8FUHEolcqa3qoqzm8WecPhjicvZ28GJPSLkUQfV0A==", "335b2ca5-f2a8-402d-8c72-ab84871dec7b" });
        }
    }
}
