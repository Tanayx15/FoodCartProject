using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodCart_Hexaware.Migrations
{
    /// <inheritdoc />
    public partial class InsertData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MenuCategories",
                columns: new[] { "CategoryID", "CategoryDescription", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Start your day with a hearty breakfast.", "Breakfast" },
                    { 2, "Enjoy a satisfying lunch.", "Lunch" },
                    { 3, "End your day with a delicious dinner.", "Dinner" },
                    { 4, "Juicy burgers with various toppings.", "Burgers" },
                    { 5, "Pizza with a variety of toppings.", "Pizza" },
                    { 6, "Traditional Italian dishes.", "Italian" },
                    { 7, "Authentic Arabian cuisine.", "Arabian" },
                    { 8, "Small dishes to start your meal.", "Appetizers" },
                    { 9, "Hearty and fulfilling main courses.", "Main Dishes" },
                    { 10, "Drinks to complement your meal.", "Beverages" },
                    { 11, "Sweet treats to end your meal.", "Desserts" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "RestaurantID", "ClosingHours", "OpeningHours", "RestaurantAddress", "RestaurantDescription", "RestaurantEmail", "RestaurantName", "RestaurantPhone" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 11, 0, 0, 0), new TimeSpan(0, 6, 0, 0, 0), "123 Breakfast Ave", "Serving the best breakfast in town.", "contact@breakfastclub.com", "The Breakfast Club", "1234567890" },
                    { 2, new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 11, 0, 0, 0), "456 Lunch Lane", "Delicious lunch options with a cozy ambiance.", "info@lunchhaven.com", "Lunch Haven", "2345678901" },
                    { 3, new TimeSpan(0, 22, 0, 0, 0), new TimeSpan(0, 17, 0, 0, 0), "789 Dinner Dr", "Fine dining with exquisite dinner choices.", "hello@dinnerdelight.com", "Dinner Delight", "3456789012" },
                    { 4, new TimeSpan(0, 23, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), "101 Burger Blvd", "The ultimate burger experience.", "contact@burgerbonanza.com", "Burger Bonanza", "4567890123" },
                    { 5, new TimeSpan(0, 23, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), "202 Pizza Place", "Amazing pizzas with fresh ingredients.", "info@pizzapalace.com", "Pizza Palace", "5678901234" },
                    { 6, new TimeSpan(0, 22, 0, 0, 0), new TimeSpan(0, 11, 0, 0, 0), "303 Italian St", "Authentic Italian cuisine.", "contact@italianbistro.com", "Italian Bistro", "6789012345" },
                    { 7, new TimeSpan(0, 23, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), "404 Arabian Ave", "Experience the taste of Arabian food.", "info@arabianights.com", "Arabian Nights", "7890123456" },
                    { 8, new TimeSpan(0, 22, 0, 0, 0), new TimeSpan(0, 11, 0, 0, 0), "505 Appetizer Rd", "A variety of appetizers to start your meal.", "contact@appetizeralley.com", "Appetizer Alley", "8901234567" },
                    { 9, new TimeSpan(0, 23, 0, 0, 0), new TimeSpan(0, 11, 0, 0, 0), "606 Main St", "Hearty main dishes for all tastes.", "info@maindishmasters.com", "Main Dish Masters", "9012345678" },
                    { 10, new TimeSpan(0, 22, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), "707 Dessert Blvd", "Sweet and decadent desserts.", "contact@dessertdelights.com", "Dessert Delights", "0123456789" }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "ItemID", "AvailabilityStatus", "CategoryID", "CuisineType", "DietaryInfo", "ImageURL", "Ingredients", "ItemDescription", "ItemName", "ItemPrice", "TasteInfo" },
                values: new object[,]
                {
                    { 1, "Available", 1, "American", "Vegetarian", "images/pancakes.jpg", "Flour, Eggs, Milk, Butter, Syrup", "Fluffy pancakes served with syrup and butter.", "Pancakes", 5.99m, "Sweet" },
                    { 2, "Available", 1, "American", "Vegetarian", "images/omelette.jpg", "Eggs, Cheese, Bell Peppers, Onions", "Classic omelette with cheese and vegetables.", "Omelette", 6.49m, "Savory" },
                    { 3, "Available", 2, "American", "Low Carb", "images/chicken_salad.jpg", "Chicken, Lettuce, Tomato, Cucumber, Vinaigrette", "Fresh salad with grilled chicken and vinaigrette.", "Grilled Chicken Salad", 8.99m, "Savory" },
                    { 4, "Available", 2, "American", "High Protein", "images/turkey_sandwich.jpg", "Turkey, Lettuce, Tomato, Mayo, Bread", "Turkey sandwich with lettuce, tomato, and mayo.", "Turkey Sandwich", 7.49m, "Savory" },
                    { 5, "Available", 3, "American", "High Protein", "images/steak_dinner.jpg", "Steak, Potatoes, Vegetables", "Grilled steak served with mashed potatoes and vegetables.", "Steak Dinner", 15.99m, "Savory" },
                    { 6, "Available", 3, "Italian", "Contains Dairy", "images/lasagna.jpg", "Pasta, Beef, Cheese, Tomato Sauce", "Layered pasta with meat sauce and cheese.", "Lasagna", 14.49m, "Savory" },
                    { 7, "Available", 4, "American", "Contains Dairy", "images/cheeseburger.jpg", "Beef, Cheese, Lettuce, Tomato, Bun", "Beef patty with cheese, lettuce, and tomato.", "Cheeseburger", 9.99m, "Savory" },
                    { 8, "Available", 4, "American", "Vegetarian", "images/veggie_burger.jpg", "Vegetables, Cheese, Bun", "Vegetarian burger with grilled vegetables and cheese.", "Veggie Burger", 8.49m, "Savory" },
                    { 9, "Available", 5, "Italian", "Contains Dairy", "images/margherita_pizza.jpg", "Tomato Sauce, Mozzarella, Basil", "Classic pizza with tomato sauce and mozzarella cheese.", "Margherita Pizza", 11.99m, "Savory" },
                    { 10, "Available", 5, "Italian", "Contains Dairy", "images/pepperoni_pizza.jpg", "Tomato Sauce, Mozzarella, Pepperoni", "Pizza with pepperoni and cheese.", "Pepperoni Pizza", 12.99m, "Savory" },
                    { 11, "Available", 6, "Italian", "Contains Dairy", "images/carbonara.jpg", "Spaghetti, Pancetta, Cream, Parmesan", "Spaghetti with creamy carbonara sauce and pancetta.", "Spaghetti Carbonara", 13.99m, "Savory" },
                    { 12, "Available", 6, "Italian", "Contains Dairy", "images/chicken_alfredo.jpg", "Fettuccine, Chicken, Alfredo Sauce", "Fettuccine pasta with creamy Alfredo sauce and chicken.", "Chicken Alfredo", 14.49m, "Savory" },
                    { 13, "Available", 7, "Arabian", "Contains Dairy", "images/chicken_shawarma.jpg", "Chicken, Pita, Vegetables, Shawarma Spices", "Spiced chicken wrapped in pita with vegetables.", "Chicken Shawarma", 10.99m, "Savory" },
                    { 14, "Available", 7, "Arabian", "Vegan", "images/falafel.jpg", "Chickpeas, Tahini, Spices", "Deep-fried chickpea balls with tahini sauce.", "Falafel", 8.49m, "Savory" },
                    { 15, "Available", 8, "Asian", "Vegetarian", "images/spring_rolls.jpg", "Vegetables, Spring Roll Wrappers", "Crispy spring rolls filled with vegetables.", "Spring Rolls", 6.99m, "Savory" },
                    { 16, "Available", 8, "Italian", "Vegetarian", "images/garlic_bread.jpg", "Bread, Garlic, Butter, Herbs", "Toasted bread with garlic and herbs.", "Garlic Bread", 5.49m, "Savory" },
                    { 17, "Available", 9, "Russian", "Contains Dairy", "images/beef_stroganoff.jpg", "Beef, Mushrooms, Cream, Onions", "Tender beef in a creamy mushroom sauce.", "Beef Stroganoff", 14.99m, "Savory" },
                    { 18, "Available", 9, "Indian", "Contains Dairy", "images/chicken_curry.jpg", "Chicken, Rice, Curry Spices", "Spicy chicken curry served with rice.", "Chicken Curry", 12.49m, "Spicy" },
                    { 19, "Available", 10, "American", "Vegan", "images/lemonade.jpg", "Lemon, Sugar, Water", "Freshly squeezed lemonade.", "Lemonade", 3.99m, "Sweet" },
                    { 20, "Available", 10, "American", "Contains Dairy", "images/iced_coffee.jpg", "Coffee, Cream, Sugar", "Chilled coffee with a touch of cream.", "Iced Coffee", 4.49m, "Bitter" },
                    { 21, "Available", 11, "American", "Contains Dairy", "images/chocolate_cake.jpg", "Chocolate, Flour, Sugar, Eggs", "Rich chocolate cake with a creamy frosting.", "Chocolate Cake", 6.49m, "Sweet" },
                    { 22, "Available", 11, "American", "Contains Dairy", "images/cheesecake.jpg", "Cream Cheese, Sugar, Graham Crackers", "Creamy cheesecake with a graham cracker crust.", "Cheesecake", 7.49m, "Sweet" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "ItemID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "ItemID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "ItemID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "ItemID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "ItemID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "ItemID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "ItemID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "ItemID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "ItemID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "ItemID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "ItemID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "ItemID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "ItemID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "ItemID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "ItemID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "ItemID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "ItemID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "ItemID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "ItemID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "ItemID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "ItemID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "ItemID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "CategoryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "CategoryID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "CategoryID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "CategoryID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "CategoryID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "CategoryID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "CategoryID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "CategoryID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "CategoryID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "CategoryID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MenuCategories",
                keyColumn: "CategoryID",
                keyValue: 11);
        }
    }
}
