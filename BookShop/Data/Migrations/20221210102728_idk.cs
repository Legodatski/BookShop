using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShop.Data.Migrations
{
    public partial class idk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Schools_SchoolId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DetailsUserModelId",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Schools",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.freeiconspng.com%2Fimages%2Fno-image-icon&psig=AOvVaw2SB0EpftM3utCWoOiGqnSI&ust=1669587243289000&source=images&cd=vfe&ved=0CBAQjRxqFwoTCJj6s6bvzPsCFQAAAAAdAAAAABAJ");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Schools_SchoolId",
                table: "AspNetUsers",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Schools_SchoolId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BookViewModel");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "DetailsUserModel");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Towns",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Schools",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.freeiconspng.com%2Fimages%2Fno-image-icon&psig=AOvVaw2SB0EpftM3utCWoOiGqnSI&ust=1669587243289000&source=images&cd=vfe&ved=0CBAQjRxqFwoTCJj6s6bvzPsCFQAAAAAdAAAAABAJ",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "DetailsUserModelId",
                table: "Books",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 1,
                column: "Location",
                value: "43.075672, 25.617151");

            migrationBuilder.UpdateData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 2,
                column: "Location",
                value: "42.698334, 23.319941");

            migrationBuilder.UpdateData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 3,
                column: "Location",
                value: "43.204666, 27.910543");

            migrationBuilder.CreateIndex(
                name: "IX_Books_DetailsUserModelId",
                table: "Books",
                column: "DetailsUserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Schools_SchoolId",
                table: "AspNetUsers",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_DetailsUserModel_DetailsUserModelId",
                table: "Books",
                column: "DetailsUserModelId",
                principalTable: "DetailsUserModel",
                principalColumn: "Id");
        }
    }
}
