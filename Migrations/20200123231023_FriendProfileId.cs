using Microsoft.EntityFrameworkCore.Migrations;

namespace PostPrivate.Data.Migrations
{
    public partial class FriendProfileId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProfileId",
                table: "Friends",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FriendProfileId",
                table: "Friends",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProfileId",
                table: "Friends",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FriendProfileId",
                table: "Friends",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
