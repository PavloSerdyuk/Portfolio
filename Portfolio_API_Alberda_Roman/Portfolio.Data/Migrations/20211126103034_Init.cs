using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Representation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpeakerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Representation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Representation_User_SpeakerId",
                        column: x => x.SpeakerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRepresentation",
                columns: table => new
                {
                    RepresentationId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRepresentation", x => new { x.RepresentationId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRepresentation_Representation_RepresentationId",
                        column: x => x.RepresentationId,
                        principalTable: "Representation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRepresentation_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Role", "Username" },
                values: new object[] { 1, "Petro", "Poroshenko", "admin", "Admin", "Getman" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Role", "Username" },
                values: new object[] { 2, "Roman", "Alberda", "user", "User", "user" });

            migrationBuilder.CreateIndex(
                name: "IX_Representation_SpeakerId",
                table: "Representation",
                column: "SpeakerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRepresentation_UserId",
                table: "UserRepresentation",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRepresentation");

            migrationBuilder.DropTable(
                name: "Representation");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
