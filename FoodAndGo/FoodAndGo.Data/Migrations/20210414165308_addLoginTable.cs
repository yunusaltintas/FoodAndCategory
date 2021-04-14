using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodAndGo.Data.Migrations
{
    public partial class addLoginTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    UserName = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Password = table.Column<string>(type: "varchar(350)", maxLength: 350, nullable: false),
                    Role = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logins");
        }
    }
}
