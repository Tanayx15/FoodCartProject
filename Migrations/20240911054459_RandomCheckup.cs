using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodCart_Hexaware.Migrations
{
    /// <inheritdoc />
    public partial class RandomCheckup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryAgents_Users_UsersUserID",
                table: "DeliveryAgents");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryAgents_UsersUserID",
                table: "DeliveryAgents");

            migrationBuilder.DropColumn(
                name: "UsersUserID",
                table: "DeliveryAgents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsersUserID",
                table: "DeliveryAgents",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DeliveryAgents",
                keyColumn: "DeliveryAgentID",
                keyValue: 1,
                column: "UsersUserID",
                value: null);

            migrationBuilder.UpdateData(
                table: "DeliveryAgents",
                keyColumn: "DeliveryAgentID",
                keyValue: 2,
                column: "UsersUserID",
                value: null);

            migrationBuilder.UpdateData(
                table: "DeliveryAgents",
                keyColumn: "DeliveryAgentID",
                keyValue: 3,
                column: "UsersUserID",
                value: null);

            migrationBuilder.UpdateData(
                table: "DeliveryAgents",
                keyColumn: "DeliveryAgentID",
                keyValue: 4,
                column: "UsersUserID",
                value: null);

            migrationBuilder.UpdateData(
                table: "DeliveryAgents",
                keyColumn: "DeliveryAgentID",
                keyValue: 5,
                column: "UsersUserID",
                value: null);

            migrationBuilder.UpdateData(
                table: "DeliveryAgents",
                keyColumn: "DeliveryAgentID",
                keyValue: 6,
                column: "UsersUserID",
                value: null);

            migrationBuilder.UpdateData(
                table: "DeliveryAgents",
                keyColumn: "DeliveryAgentID",
                keyValue: 7,
                column: "UsersUserID",
                value: null);

            migrationBuilder.UpdateData(
                table: "DeliveryAgents",
                keyColumn: "DeliveryAgentID",
                keyValue: 8,
                column: "UsersUserID",
                value: null);

            migrationBuilder.UpdateData(
                table: "DeliveryAgents",
                keyColumn: "DeliveryAgentID",
                keyValue: 9,
                column: "UsersUserID",
                value: null);

            migrationBuilder.UpdateData(
                table: "DeliveryAgents",
                keyColumn: "DeliveryAgentID",
                keyValue: 10,
                column: "UsersUserID",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryAgents_UsersUserID",
                table: "DeliveryAgents",
                column: "UsersUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryAgents_Users_UsersUserID",
                table: "DeliveryAgents",
                column: "UsersUserID",
                principalTable: "Users",
                principalColumn: "UserID");
        }
    }
}
