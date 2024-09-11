using FoodCart_Hexaware.DTO;
using FoodCart_Hexaware.DTOs;
using FoodCart_Hexaware.Models;
using System.Collections.Generic;

namespace FoodCart_Hexaware.Services
{
    public interface IRestaurantService
    {
        // Fetch the dashboard data for a restaurant owned by the user
        DashBoardDTO GetDashboardData(int userId);

        // Add a new menu item to the restaurant
        void AddMenuItem(int userId, MenuItemDTO menuItemDTO);

        // Get all menu items for a specific restaurant
        IEnumerable<MenuItemDTO> GetMenuItems(int restaurantId);

        // Update an existing menu item
        void UpdateMenuItem(int userId, int itemId, MenuItemDTO menuItemDTO);

        // Delete a menu item by its ID
        void DeleteMenuItem(int userId, int itemId);

        // Fetch restaurant information for a user
        Restaurant GetRestaurantByUserId(int userId);

        // Fetch all categories for a restaurant
        List<CategoryDTO> GetCategories(int restaurantId);

        // Add a new category to the restaurant
        void AddCategory(int restaurantId, CategoryDTO categoryDTO);

        // Update an existing category
        void UpdateCategory(int restaurantId, int categoryId, CategoryDTO categoryDTO);

        // Delete a category by its ID
        void DeleteCategory(int restaurantId, int categoryId);

        // Fetch all orders for a restaurant
        List<OrderDTO> GetOrders(int restaurantId);

        // Update the status of an order
        void UpdateOrderStatus(int userId, int orderId, string status);

        // Get details of a specific order
        OrderDTO GetOrderDetails(int userId, int orderId);

        void MarkMenuItemAsOutOfStock(int userId, int itemId);
    }
}
