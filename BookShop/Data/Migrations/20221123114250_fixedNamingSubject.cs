using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShop.Data.Migrations
{
    public partial class fixedNamingSubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_SubjectType_BookTypeId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectType",
                table: "SubjectType");

            migrationBuilder.RenameTable(
                name: "SubjectType",
                newName: "SubjectTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectTypes",
                table: "SubjectTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_SubjectTypes_BookTypeId",
                table: "Books",
                column: "BookTypeId",
                principalTable: "SubjectTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_SubjectTypes_BookTypeId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectTypes",
                table: "SubjectTypes");

            migrationBuilder.RenameTable(
                name: "SubjectTypes",
                newName: "SubjectType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectType",
                table: "SubjectType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_SubjectType_BookTypeId",
                table: "Books",
                column: "BookTypeId",
                principalTable: "SubjectType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
