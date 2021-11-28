using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsProgram.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArticleTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ArticleInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Author_Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");
        }
    }
}
