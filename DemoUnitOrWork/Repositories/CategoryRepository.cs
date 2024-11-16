using DemoUnitOrWork.Data;
using DemoUnitOrWork.Interfaces;
using DemoUnitOrWork.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoUnitOrWork.Repositories
{
    // CategoryRepository.cs
    public class CategoryRepository(AppDbContext _context) : ICategoryRepository
    {
        public async Task<IEnumerable<Category>> GetListAsync()
        {
            return await _context.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
 
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category is null)
                throw new DbUpdateException("Category not found");
                _context.Categories.Remove(category);

        }
    }

}
