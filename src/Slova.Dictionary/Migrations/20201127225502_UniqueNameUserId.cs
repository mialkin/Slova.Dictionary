using Microsoft.EntityFrameworkCore.Migrations;

namespace Slova.Dictionary.Migrations
{
    public partial class UniqueNameUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Words_Name_UserId",
                table: "Words",
                columns: new[] { "Name", "UserId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Words_Name_UserId",
                table: "Words");
        }
    }
}
