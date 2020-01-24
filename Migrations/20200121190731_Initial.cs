using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PostPrivate.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: false),
                    FName = table.Column<string>(nullable: false),
                    MName = table.Column<string>(nullable: true),
                    LName = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    DateJoined = table.Column<string>(nullable: true),
                    BDay = table.Column<DateTime>(nullable: false),
                    Bio = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    PhoneNum = table.Column<string>(nullable: true),
                    WorkPlace = table.Column<string>(nullable: true),
                    School = table.Column<string>(nullable: true),
                    HomeTown = table.Column<string>(nullable: true),
                    PhotoName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Friend",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<int>(nullable: true),
                    FriendProfileId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friend", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Friend_Profiles_FriendProfileId",
                        column: x => x.FriendProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Friend_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TextField = table.Column<string>(nullable: true),
                    TimpeStamp = table.Column<DateTime>(nullable: false),
                    Picture = table.Column<string>(nullable: true),
                    Audience = table.Column<int>(nullable: false),
                    ProfileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(nullable: false),
                    ProfileId = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Likes_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Age", "BDay", "Bio", "DateJoined", "EmailAddress", "FName", "HomeTown", "LName", "MName", "PhoneNum", "PhotoName", "School", "UserName", "WorkPlace" },
                values: new object[,]
                {
                    { 1, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Web Developer, Drummer, Citizen-Soldier, Drinker of Protein shakes", "January 2020", null, "Sean", null, "Robinson", null, null, "sean.jpg", null, "protein_m4chine", null },
                    { 2, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Effects Animationist, Bass Guitarist, Very much into Politics", "January 2020", null, "Evan", null, "Robinson", null, null, "evan.jpg", null, "deep_chaos", null },
                    { 3, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dronist, Guitarist, bored Alaskan", "January 2020", null, "AJ", null, "Robinson", null, null, "aj.jpg", null, "hav0c", null },
                    { 4, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Student, Violinist, Student Driver", "January 2020", null, "Erica", null, "Robinson", null, null, "erica.jpg", null, "bluegables", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friend_FriendProfileId",
                table: "Friend",
                column: "FriendProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Friend_ProfileId",
                table: "Friend",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PostId",
                table: "Likes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_ProfileId",
                table: "Likes",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ProfileId",
                table: "Posts",
                column: "ProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friend");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
