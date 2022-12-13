using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShop.Infrastructure.Migrations
{
    public partial class updatedPublsihers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorPublisher");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Towns",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Authors",
                table: "Publishers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Authors", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, "Hermes Trismegistus", false, "Hermes" },
                    { 2, "John Atanasov", false, "Arhimed" },
                    { 3, "Нели Дамянова, Радина Попова", false, "Prosveta" }
                });

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 4,
                column: "SchoolType",
                value: 1);

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "IsDeleted", "Name", "SchoolType", "TownId" },
                values: new object[] { 5, false, "Other", 0, 1 });

            migrationBuilder.InsertData(
                table: "SubjectTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Other" });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "Id", "IsDeleted", "Location", "Name" },
                values: new object[] { 4, false, null, "Other" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SubjectTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Authors",
                table: "Publishers");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Towns",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorPublisher",
                columns: table => new
                {
                    AuthorsId = table.Column<int>(type: "int", nullable: false),
                    PublishersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorPublisher", x => new { x.AuthorsId, x.PublishersId });
                    table.ForeignKey(
                        name: "FK_AuthorPublisher_Authors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorPublisher_Publishers_PublishersId",
                        column: x => x.PublishersId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 4,
                column: "SchoolType",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AuthorPublisher_PublishersId",
                table: "AuthorPublisher",
                column: "PublishersId");
        }
    }
}
