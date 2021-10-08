using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Ăn hoài không chán, giàu protein", new byte[0], "Trứng chiên", 15000.0 },
                    { 2, "Cũng được nhưng cần nước mắm ngon", new byte[0], "Cá chiên", 20000.0 },
                    { 3, "Thêm bún thì hết nước chấm", new byte[0], "Thịt nướng", 17000.0 },
                    { 4, "Ngon vcl, nhất là nước rau", new byte[0], "Rau muống xào", 10000.0 },
                    { 5, "Cứ phải gọi là ổn áp", new byte[0], "Canh cà chua", 5000.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DisplayName", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, null, "c4ca4238a0b923820dcc509a6f75849b", "Admin", "admin" },
                    { 2, null, "c4ca4238a0b923820dcc509a6f75849b", "Guest", "guest" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
