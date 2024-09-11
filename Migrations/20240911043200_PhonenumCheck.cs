using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodCart_Hexaware.Migrations
{
    /// <inheritdoc />
    public partial class PhonenumCheck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlternativePhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlternativePhoneNumber",
                table: "Users");
        }
    }
}
