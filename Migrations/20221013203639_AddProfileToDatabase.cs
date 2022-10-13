using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommerceProject.Migrations
{
    public partial class AddProfileToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserProfileUserId",
                table: "Fundraisers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fundraisers_UserProfileUserId",
                table: "Fundraisers",
                column: "UserProfileUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fundraisers_Profiles_UserProfileUserId",
                table: "Fundraisers",
                column: "UserProfileUserId",
                principalTable: "Profiles",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fundraisers_Profiles_UserProfileUserId",
                table: "Fundraisers");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Fundraisers_UserProfileUserId",
                table: "Fundraisers");

            migrationBuilder.DropColumn(
                name: "UserProfileUserId",
                table: "Fundraisers");
        }
    }
}
