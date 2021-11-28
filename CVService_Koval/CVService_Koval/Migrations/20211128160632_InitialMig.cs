using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CVService_Koval.Migrations
{
    public partial class InitialMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CVs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expirience = table.Column<double>(type: "float", nullable: false),
                    BachelorDegree = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Technologies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserRole = table.Column<int>(type: "int", nullable: false),
                    CVId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_CVs_CVId",
                        column: x => x.CVId,
                        principalTable: "CVs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CVTechnologie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TechnologieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CVId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVTechnologie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CVTechnologie_CVs_CVId",
                        column: x => x.CVId,
                        principalTable: "CVs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CVTechnologie_Technologies_TechnologieId",
                        column: x => x.TechnologieId,
                        principalTable: "Technologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CVTechnologie_CVId",
                table: "CVTechnologie",
                column: "CVId");

            migrationBuilder.CreateIndex(
                name: "IX_CVTechnologie_TechnologieId",
                table: "CVTechnologie",
                column: "TechnologieId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CVId",
                table: "Users",
                column: "CVId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CVTechnologie");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Technologies");

            migrationBuilder.DropTable(
                name: "CVs");
        }
    }
}
