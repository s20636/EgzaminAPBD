using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kolokwium1.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    IdTeam = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.IdTeam);
                });

            migrationBuilder.CreateTable(
                name: "TaskTypes",
                columns: table => new
                {
                    IdTaskType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTypes", x => x.IdTaskType);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    IdTeamMember = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.IdTeamMember);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    IdTask = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdTeam = table.Column<int>(type: "int", nullable: false),
                    IdTaskType = table.Column<int>(type: "int", nullable: false),
                    IdAssignedTo = table.Column<int>(type: "int", nullable: false),
                    IdCreator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.IdTask);
                    table.ForeignKey(
                        name: "FK_Tasks_Projects_IdTeam",
                        column: x => x.IdTeam,
                        principalTable: "Projects",
                        principalColumn: "IdTeam",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_TaskTypes_IdTaskType",
                        column: x => x.IdTaskType,
                        principalTable: "TaskTypes",
                        principalColumn: "IdTaskType",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_TeamMembers_IdCreator",
                        column: x => x.IdCreator,
                        principalTable: "TeamMembers",
                        principalColumn: "IdTeamMember",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "IdTeam", "Deadline", "Name" },
                values: new object[] { 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "projekt1" });

            migrationBuilder.InsertData(
                table: "TaskTypes",
                columns: new[] { "IdTaskType", "Name" },
                values: new object[] { 1, "it" });

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "IdTeamMember", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "mail@wp.pl", "Jan", "Niezbedny" },
                    { 2, "mail2@wp.pl", "Anna", "Niezbedna" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "IdTask", "Deadline", "Description", "IdAssignedTo", "IdCreator", "IdTaskType", "IdTeam", "Name" },
                values: new object[] { 1, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "description", 2, 1, 1, 1, "wymiana pieca" });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_IdCreator",
                table: "Tasks",
                column: "IdCreator");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_IdTaskType",
                table: "Tasks",
                column: "IdTaskType");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_IdTeam",
                table: "Tasks",
                column: "IdTeam");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "TaskTypes");

            migrationBuilder.DropTable(
                name: "TeamMembers");
        }
    }
}
