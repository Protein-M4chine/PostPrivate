using Microsoft.EntityFrameworkCore.Migrations;

namespace PostPrivate.Data.Migrations
{
    public partial class FriendDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friend_Profiles_FriendProfileId",
                table: "Friend");

            migrationBuilder.DropForeignKey(
                name: "FK_Friend_Profiles_ProfileId",
                table: "Friend");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Friend",
                table: "Friend");

            migrationBuilder.RenameTable(
                name: "Friend",
                newName: "Friends");

            migrationBuilder.RenameIndex(
                name: "IX_Friend_ProfileId",
                table: "Friends",
                newName: "IX_Friends_ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Friend_FriendProfileId",
                table: "Friends",
                newName: "IX_Friends_FriendProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friends",
                table: "Friends",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Profiles_FriendProfileId",
                table: "Friends",
                column: "FriendProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Profiles_ProfileId",
                table: "Friends",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Profiles_FriendProfileId",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Profiles_ProfileId",
                table: "Friends");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Friends",
                table: "Friends");

            migrationBuilder.RenameTable(
                name: "Friends",
                newName: "Friend");

            migrationBuilder.RenameIndex(
                name: "IX_Friends_ProfileId",
                table: "Friend",
                newName: "IX_Friend_ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Friends_FriendProfileId",
                table: "Friend",
                newName: "IX_Friend_FriendProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friend",
                table: "Friend",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Friend_Profiles_FriendProfileId",
                table: "Friend",
                column: "FriendProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friend_Profiles_ProfileId",
                table: "Friend",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
