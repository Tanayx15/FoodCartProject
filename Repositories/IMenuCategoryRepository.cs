using FoodCart_Hexaware.Models;

namespace FoodCart_Hexaware.Repositories
{
    public interface IMenuCategoryRepository
    {

        Task<IEnumerable<MenuCategory>> GetAllCategoriesAsync();
        Task<MenuCategory> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(MenuCategory category);
        Task UpdateCategoryAsync(MenuCategory category);
        Task DeleteCategoryAsync(int id);


    }
}
