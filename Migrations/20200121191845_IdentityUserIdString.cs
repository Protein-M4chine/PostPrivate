using Microsoft.EntityFrameworkCore.Migrations;

namespace PostPrivate.Data.Migrations
{
    public partial class IdentityUserIdString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Profiles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Profiles");
        }
    }
}
