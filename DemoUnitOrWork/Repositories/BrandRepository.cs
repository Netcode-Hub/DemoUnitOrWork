using DemoUnitOrWork.Data;
using DemoUnitOrWork.Interfaces;
using DemoUnitOrWork.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoUnitOrWork.Repositories
{
    // BrandRepository.cs
    public class BrandRepository(AppDbContext _context) : IBrandRepository
    {
        public async Task<IEnumerable<Brand>> GetListAsync()
        {
            return await _context.Brands.ToListAsync();
        }

        public async Task<Brand> GetByIdAsync(int id)
        {
            return await _context.Brands.FindAsync(id);
        }

        public async Task AddAsync(Brand brand)
        {
            await _context.Brands.AddAsync(brand);

        }

        public async Task UpdateAsync(Brand brand)
        {
            _context.Brands.Update(brand);

        }

        public async Task DeleteAsync(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand is null)
                throw new DbUpdateException("Category not found");
            _context.Brands.Remove(brand);

            
        }
    }

}
