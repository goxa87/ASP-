using Microsoft.EntityFrameworkCore.Migrations;

namespace MySite1.Migrations
{
    public partial class ContactMessage_addFromEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FromEmail",
                table: "ContactMessages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromEmail",
                table: "ContactMessages");
        }
    }
}
