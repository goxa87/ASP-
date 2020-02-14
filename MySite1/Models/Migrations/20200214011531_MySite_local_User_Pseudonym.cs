using Microsoft.EntityFrameworkCore.Migrations;

namespace MySite1.Migrations
{
    public partial class MySite_local_User_Pseudonym : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Pseudonym",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pseudonym",
                table: "AspNetUsers");
        }
    }
}
