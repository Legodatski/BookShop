using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShop.Infrastructure.Migrations
{
    public partial class updatedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b68f5083-eb62-49f5-b487-b35c0d5a625c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "ab596ccf-2c31-4388-a5de-a27b9871f004", "AQAAAAEAACcQAAAAEAfvpSWul7KNcj3wZVunp14YoErKxLvaMJsjNF5Qvf+9H5FxDEQfVJC7+jBhRg6+Rw==", "1b1845f6-9e64-4ed4-a890-ebab6b20c53e", "PeshoPeshov" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e97bab0a-4e68-404a-b1d9-57bc8865ab83",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "a7713b7c-6903-41da-8b97-63cd9de6ec27", "AQAAAAEAACcQAAAAEPGey2ycQOU+3Qmg5Mqfxi21h8FUHEolcqa3qoqzm8WecPhjicvZ28GJPSLkUQfV0A==", "335b2ca5-f2a8-402d-8c72-ab84871dec7b", "AdminAdminov" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b68f5083-eb62-49f5-b487-b35c0d5a625c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "f95d8e56-91ef-4e5b-b23a-c115406d7fbe", "AQAAAAEAACcQAAAAELcKq7MFBNmEPi3A27MZ2nYdwI/tYvcZ35mU3iwKS7WMhgbFi0qVrFkGnB5lreMGig==", "21210b5e-6bf2-4547-8453-16c776521223", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e97bab0a-4e68-404a-b1d9-57bc8865ab83",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "2b0d9030-8b73-45fd-a1fd-6cbc660661d0", "AQAAAAEAACcQAAAAEI3iXNBY/Bs8MZAJE7VyJK/AeqdJ/++8zwp/xo/PRlZp/prZxkilCKBJglDhSnJqrg==", "9fccdfe0-61d9-4c79-985c-9daac1e31cdf", null });
        }
    }
}
