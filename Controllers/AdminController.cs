using FoodCart_Hexaware.Models;
using FoodCart_Hexaware.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodCart_Hexaware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMenuItemRepository _menuItemrepository;
        private readonly IMenuCategoryRepository _menuCategoryRepository;

        public AdminController(
            IUserRepository userRepository,
            IRestaurantRepository restaurantRepository,
            IMenuItemRepository menuItemRepository,
            IMenuCategoryRepository menuCategoryRepository)
        {
            _userRepository = userRepository;
            _restaurantRepository = restaurantRepository;
            _menuItemrepository = menuItemRepository;
            _menuCategoryRepository = menuCategoryRepository;
        }

        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            try
            {
                var users = await _userRepository.GetAllUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error occurred while fetching users: {ex.Message}");
            }
        }

        [HttpPost("users")]
        public async Task<ActionResult<Users>> CreateUser(Users user)
        {
            try
            {
                await _userRepository.AddUserAsync(user);
                return CreatedAtAction(nameof(GetUsers), new { id = user.UserID }, user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error occurred while creating user: {ex.Message}");
            }
        }

        [HttpPut("users/{id}")]
        public async Task<IActionResult> UpdateUser(int id, Users user)
        {
            if (id != user.UserID)
            {
                return BadRequest("User ID mismatch");
            }

            try
            {
                await _userRepository.UpdateUserAsync(user);
                return Content("Updated");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error occurred while updating user: {ex.Message}");
            }
        }

        [HttpDelete("users/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _userRepository.DeleteUserAsync(id);
                return Content("Deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error occurred while deleting user: {ex.Message}");
            }
        }


        [HttpGet("restaurants")]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants()
        {
            try
            {
                var restaurants = await _restaurantRepository.GetAllRestaurantsAsync();
                return Ok(restaurants);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error occurred while fetching restaurants: {ex.Message}");
            }
        }

        [HttpPost("restaurants")]
        public async Task<ActionResult<Restaurant>> CreateRestaurant(Restaurant restaurant)
        {
            try
            {
                await _restaurantRepository.AddRestaurantAsync(restaurant);
                return CreatedAtAction(nameof(GetRestaurants), new { id = restaurant.RestaurantID }, restaurant);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error occurred while creating restaurant: {ex.Message}");
            }
        }

        [HttpPut("restaurants/{id}")]
        public async Task<IActionResult> UpdateRestaurant(int id, Restaurant restaurant)
        {
            if (id != restaurant.RestaurantID)
            {
                return BadRequest("Restaurant ID mismatch");
            }

            try
            {
                await _restaurantRepository.UpdateRestaurantAsync(restaurant);
                return Content("Updated");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error occurred while updating restaurant: {ex.Message}");
            }
        }

        [HttpDelete("restaurants/{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            try
            {
                await _restaurantRepository.DeleteRestaurantAsync(id);
                return Content("Deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error occurred while deleting restaurant: {ex.Message}");
            }
        }

        [HttpGet("items")]
        public async Task<ActionResult<IEnumerable<MenuItems>>> GetMenuItems()
        {
            try
            {
                var menuItems = await _menuItemrepository.GetAllMenuItemsAsync();
                return Ok(menuItems);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error occurred while retrieving menu items: {ex.Message}");
            }
        }

        [HttpPost("menuitems")]
        public async Task<ActionResult<MenuItems>> CreateMenuItem(MenuItems menuItem)
        {
            try
            {
                await _menuItemrepository.AddMenuItemAsync(menuItem);
                return CreatedAtAction(nameof(GetMenuItems), new { id = menuItem.ItemID }, menuItem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error occurred while creating menu item: {ex.Message}");
            }
        }

        [HttpPut("menuitems/{id}")]
        public async Task<IActionResult> UpdateMenuItem(int id, MenuItems menuItem)
        {
            if (id != menuItem.ItemID)
            {
                return BadRequest("Menu Item ID mismatch");
            }

            try
            {
                await _menuItemrepository.UpdateMenuItemAsync(menuItem);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error occurred while updating menu item: {ex.Message}");
            }
        }

        [HttpDelete("menuitems/{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            try
            {
                await _menuItemrepository.DeleteMenuItemAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error occurred while deleting menu item: {ex.Message}");
            }
        }



        [HttpGet("AllCategories")]
        public async Task<ActionResult<IEnumerable<MenuCategory>>> GetCategories()
        {
            try
            {
                var categories = await _menuCategoryRepository.GetAllCategoriesAsync();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error occurred while retrieving categories: {ex.Message}");
            }
        }
        [HttpPost("categories")]
        public async Task<ActionResult<MenuCategory>> CreateCategory(MenuCategory category)
        {
            try
            {
                await _menuCategoryRepository.AddCategoryAsync(category);
                return CreatedAtAction(nameof(GetCategories), new { id = category.CategoryID }, category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error occurred while creating menu category: {ex.Message}");
            }
        }

        [HttpPut("categories/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, MenuCategory category)
        {
            if (id != category.CategoryID)
            {
                return BadRequest("Category ID mismatch");
            }

            try
            {
                await _menuCategoryRepository.UpdateCategoryAsync(category);
                return Content("Updated");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error occurred while updating menu category: {ex.Message}");
            }
        }

        [HttpDelete("categories/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                await _menuCategoryRepository.DeleteCategoryAsync(id);
                return Content("Deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error occurred while deleting menu category: {ex.Message}");
            }
        }
    }
}
