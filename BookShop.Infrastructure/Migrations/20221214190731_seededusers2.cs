using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShop.Infrastructure.Migrations
{
    public partial class seededusers2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b68f5083-eb62-49f5-b487-b35c0d5a625c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e97bab0a-4e68-404a-b1d9-57bc8865ab83");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SchoolId", "SecurityStamp", "TownId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b68f5083-eb62-49f5-b487-b35c0d5a625c", 0, "5497c7c2-981c-4ffb-bd77-4cf42e81270f", "guest@gmail.com", false, "Pesho", false, "Peshov", false, null, null, null, "AQAAAAEAACcQAAAAEF3dTZXOgxXWS6wD7eTAU6h3xRJ/jGcD/GiF04grzxql5w8kY+79858XjvMQTfPDsg==", "0881234567", false, 1, "8c90a3d5-e833-4156-b42a-741b3e545fba", 1, false, "PeshoPeshov" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SchoolId", "SecurityStamp", "TownId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e97bab0a-4e68-404a-b1d9-57bc8865ab83", 0, "fe1d0f4c-d8b2-4513-9271-c4c98af8e27d", "admin1@gmail.com", false, "Admin", false, "Adminov", false, null, null, null, "AQAAAAEAACcQAAAAEMNawPTJ8cIKjfj+UbNIixEDP/LV7uH0F08xq8L2LfbC59T/ufku3xdVLSPuVW2jjA==", "0881234567", false, 1, "07e2139c-8b63-4f9b-9b6d-78a9cbacaae4", 1, false, "AdminAdminov" });
        }
    }
}
