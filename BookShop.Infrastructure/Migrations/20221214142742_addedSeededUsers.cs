using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShop.Infrastructure.Migrations
{
    public partial class addedSeededUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SchoolId", "SecurityStamp", "TownId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b68f5083-eb62-49f5-b487-b35c0d5a625c", 0, "f95d8e56-91ef-4e5b-b23a-c115406d7fbe", "guest@gmail.com", false, "Pesho", false, "Peshov", false, null, null, null, "AQAAAAEAACcQAAAAELcKq7MFBNmEPi3A27MZ2nYdwI/tYvcZ35mU3iwKS7WMhgbFi0qVrFkGnB5lreMGig==", "0881234567", false, 1, "21210b5e-6bf2-4547-8453-16c776521223", 1, false, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SchoolId", "SecurityStamp", "TownId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e97bab0a-4e68-404a-b1d9-57bc8865ab83", 0, "2b0d9030-8b73-45fd-a1fd-6cbc660661d0", "admin1@gmail.com", false, "Admin", false, "Adminov", false, null, null, null, "AQAAAAEAACcQAAAAEI3iXNBY/Bs8MZAJE7VyJK/AeqdJ/++8zwp/xo/PRlZp/prZxkilCKBJglDhSnJqrg==", "0881234567", false, 1, "9fccdfe0-61d9-4c79-985c-9daac1e31cdf", 1, false, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b68f5083-eb62-49f5-b487-b35c0d5a625c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e97bab0a-4e68-404a-b1d9-57bc8865ab83");

            migrationBuilder.CreateTable(
                name: "DetailsUserModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    School = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Town = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsUserModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetailsUserModelId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookViewModel_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookViewModel_DetailsUserModel_DetailsUserModelId",
                        column: x => x.DetailsUserModelId,
                        principalTable: "DetailsUserModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookViewModel_DetailsUserModelId",
                table: "BookViewModel",
                column: "DetailsUserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_BookViewModel_OwnerId",
                table: "BookViewModel",
                column: "OwnerId");
        }
    }
}
