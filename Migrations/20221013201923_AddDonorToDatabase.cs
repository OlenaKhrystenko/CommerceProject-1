using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommerceProject.Migrations
{
    public partial class AddDonorToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donors",
                columns: table => new
                {
                    DonorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    donatedAmount = table.Column<double>(type: "float", nullable: false),
                    Fundraiser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfDonation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donors", x => x.DonorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donors");
        }
    }
}
