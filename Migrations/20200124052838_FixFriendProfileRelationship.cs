using Microsoft.EntityFrameworkCore.Migrations;

namespace PostPrivate.Data.Migrations
{
    public partial class FixFriendProfileRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Friends_FriendProfileId",
                table: "Friends");

            migrationBuilder.DropIndex(
                name: "IX_Friends_ProfileId",
                table: "Friends");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Friends");

            migrationBuilder.DropColumn(
                name: "FriendProfileId",
                table: "Friends");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Friends");

            migrationBuilder.AddColumn<int>(
                name: "WithId",
                table: "Friends",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FromId",
                table: "Friends",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friends",
                table: "Friends",
                columns: new[] { "WithId", "FromId" });

            migrationBuilder.CreateIndex(
                name: "IX_Friends_FromId",
                table: "Friends",
                column: "FromId");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Profiles_FromId",
                table: "Friends",
                column: "FromId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Profiles_WithId",
                table: "Friends",
                column: "WithId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Profiles_FromId",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Profiles_WithId",
                table: "Friends");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Friends",
                table: "Friends");

            migrationBuilder.DropIndex(
                name: "IX_Friends_FromId",
                table: "Friends");

            migrationBuilder.DropColumn(
                name: "WithId",
                table: "Friends");

            migrationBuilder.DropColumn(
                name: "FromId",
                table: "Friends");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Friends",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "FriendProfileId",
                table: "Friends",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Friends",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friends",
                table: "Friends",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_FriendProfileId",
                table: "Friends",
                column: "FriendProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_ProfileId",
                table: "Friends",
                column: "ProfileId");

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
    }
}
