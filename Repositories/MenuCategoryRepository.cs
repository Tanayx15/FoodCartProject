using FoodCart_Hexaware.Data;
using FoodCart_Hexaware.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodCart_Hexaware.Repositories
{
    public class MenuCategoryRepository : IMenuCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public MenuCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MenuCategory>> GetAllCategoriesAsync()
        {
            return await _context.MenuCategories.ToListAsync();
        }

        public async Task<MenuCategory> GetCategoryByIdAsync(int id)
        {
            return await _context.MenuCategories.FindAsync(id);
        }

        public async Task AddCategoryAsync(MenuCategory category)
        {
            _context.MenuCategories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(MenuCategory category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await GetCategoryByIdAsync(id);
            if (category != null)
            {
                _context.MenuCategories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}
