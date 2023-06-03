using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class SetNameToUniversity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LevelHightEducationId",
                schema: "public",
                table: "Universities");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "public",
                table: "Universities",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                schema: "public",
                table: "Universities");

            migrationBuilder.AddColumn<int>(
                name: "LevelHightEducationId",
                schema: "public",
                table: "Universities",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
