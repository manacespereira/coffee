using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coffee.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "todo");

            migrationBuilder.CreateSequence(
                name: "todoseq",
                schema: "todo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "todos",
                schema: "todo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    is_completed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_todos", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "todos",
                schema: "todo");

            migrationBuilder.DropSequence(
                name: "todoseq",
                schema: "todo");
        }
    }
}
