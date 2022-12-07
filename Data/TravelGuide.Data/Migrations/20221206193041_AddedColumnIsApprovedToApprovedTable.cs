using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelGuide.Data.Migrations
{
    public partial class AddedColumnIsApprovedToApprovedTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Approves",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Approves");
        }
    }
}
