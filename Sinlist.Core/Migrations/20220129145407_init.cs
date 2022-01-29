using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sinlist.Core.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoListItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: false),
                    TodoListId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoListItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TodoListItem_TodoList_TodoListId",
                        column: x => x.TodoListId,
                        principalTable: "TodoList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoListItem_TodoListId",
                table: "TodoListItem",
                column: "TodoListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoListItem");

            migrationBuilder.DropTable(
                name: "TodoList");
        }
    }
}
