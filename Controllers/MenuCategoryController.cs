using FoodCart_Hexaware.Models;
using FoodCart_Hexaware.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodCart_Hexaware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Hotel Owner")]
    public class MenuCategoryController : ControllerBase
    {
        private readonly IMenuCategoryRepository _repository;

        public MenuCategoryController(IMenuCategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuCategory>>> GetCategories()
        {
            try
            {
                var categories = await _repository.GetAllCategoriesAsync();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error occurred while retrieving categories: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuCategory>> GetCategory(int id)
        {
            try
            {
                var category = await _repository.GetCategoryByIdAsync(id);
                if (category == null)
                {
                    return NotFound($"Category with ID {id} not found.");
                }
                return Ok($"Here your category:{category}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error occurred while retrieving category with ID {id}: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<MenuCategory>> CreateCategory(MenuCategory category)
        {
            try
            {
                await _repository.AddCategoryAsync(category);
                return CreatedAtAction(nameof(GetCategory), new { id = category.CategoryID }, category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error occurred while creating category: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, MenuCategory category)
        {
            try
            {
                if (id != category.CategoryID)
                    return BadRequest("Category ID mismatch.");

                await _repository.UpdateCategoryAsync(category);
                return Content("Updated");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error occurred while updating category with ID {id}: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                await _repository.DeleteCategoryAsync(id);
                return Content("Deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error occurred while deleting category with ID {id}: {ex.Message}");
            }
        }
    }
}
