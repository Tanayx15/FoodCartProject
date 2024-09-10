using FoodCart_Hexaware.Data;
using FoodCart_Hexaware.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodCart_Hexaware.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly ApplicationDbContext _context;

        public MenuItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MenuItems>> GetAllMenuItemsAsync()
        {
            return await _context.Menus.Include(m => m.MenuCategory).ToListAsync();
        }

        public async Task<MenuItems> GetMenuItemByIdAsync(int id)
        {
            return await _context.Menus.Include(m => m.MenuCategory).FirstOrDefaultAsync(m => m.ItemID == id);
        }

        public async Task AddMenuItemAsync(MenuItems menuItem)
        {
            _context.Menus.Add(menuItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMenuItemAsync(MenuItems menuItem)
        {
            _context.Entry(menuItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMenuItemAsync(int id)
        {
            var menuItem = await GetMenuItemByIdAsync(id);
            if (menuItem != null)
            {
                _context.Menus.Remove(menuItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAvailabilityStatusAsync(int id, string status)
        {
            var menuItem = await GetMenuItemByIdAsync(id);
            if (menuItem != null)
            {
                menuItem.AvailabilityStatus = status;
                _context.Entry(menuItem).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
