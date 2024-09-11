using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodCart_Hexaware.Migrations
{
    /// <inheritdoc />
    public partial class DeliveryAgent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DeliveryAgents",
                columns: new[] { "DeliveryAgentID", "Address", "Email", "IsAvailable", "Name", "PhoneNumber", "UsersUserID" },
                values: new object[,]
                {
                    { 1, "123 Elm Street, Springfield", "john.doe@example.com", true, "John Doe", "123-456-7890", null },
                    { 2, "456 Oak Avenue, Springfield", "jane.smith@example.com", true, "Jane Smith", "234-567-8901", null },
                    { 3, "789 Pine Road, Springfield", "emily.johnson@example.com", true, "Emily Johnson", "345-678-9012", null },
                    { 4, "101 Maple Drive, Springfield", "michael.brown@example.com", true, "Michael Brown", "456-789-0123", null },
                    { 5, "202 Birch Lane, Springfield", "sarah.davis@example.com", true, "Sarah Davis", "567-890-1234", null },
                    { 6, "303 Cedar Street, Springfield", "david.wilson@example.com", true, "David Wilson", "678-901-2345", null },
                    { 7, "404 Spruce Avenue, Springfield", "laura.miller@example.com", true, "Laura Miller", "789-012-3456", null },
                    { 8, "505 Fir Street, Springfield", "daniel.taylor@example.com", true, "Daniel Taylor", "890-123-4567", null },
                    { 9, "606 Redwood Road, Springfield", "olivia.anderson@example.com", true, "Olivia Anderson", "901-234-5678", null },
                    { 10, "707 Sequoia Boulevard, Springfield", "james.martinez@example.com", true, "James Martinez", "012-345-6789", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeliveryAgents",
                keyColumn: "DeliveryAgentID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DeliveryAgents",
                keyColumn: "DeliveryAgentID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DeliveryAgents",
                keyColumn: "DeliveryAgentID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DeliveryAgents",
                keyColumn: "DeliveryAgentID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DeliveryAgents",
                keyColumn: "DeliveryAgentID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DeliveryAgents",
                keyColumn: "DeliveryAgentID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DeliveryAgents",
                keyColumn: "DeliveryAgentID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DeliveryAgents",
                keyColumn: "DeliveryAgentID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "DeliveryAgents",
                keyColumn: "DeliveryAgentID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "DeliveryAgents",
                keyColumn: "DeliveryAgentID",
                keyValue: 10);
        }
    }
}
