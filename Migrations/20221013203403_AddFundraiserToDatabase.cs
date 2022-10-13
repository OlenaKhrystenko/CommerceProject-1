using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommerceProject.Migrations
{
    public partial class AddFundraiserToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FundraiserID",
                table: "Donors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Fundraisers",
                columns: table => new
                {
                    FundraiserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Goal = table.Column<double>(type: "float", nullable: false),
                    CurrentAmount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fundraisers", x => x.FundraiserID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donors_FundraiserID",
                table: "Donors",
                column: "FundraiserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_Fundraisers_FundraiserID",
                table: "Donors",
                column: "FundraiserID",
                principalTable: "Fundraisers",
                principalColumn: "FundraiserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donors_Fundraisers_FundraiserID",
                table: "Donors");

            migrationBuilder.DropTable(
                name: "Fundraisers");

            migrationBuilder.DropIndex(
                name: "IX_Donors_FundraiserID",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "FundraiserID",
                table: "Donors");
        }
    }
}
