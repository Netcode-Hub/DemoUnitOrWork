using DemoUnitOrWork.Data;
using DemoUnitOrWork.Interfaces;
using DemoUnitOrWork.Models;
using Microsoft.EntityFrameworkCore;
namespace DemoUnitOrWork.Repositories
{
    // ProductRepository.cs
    public class ProductRepository(AppDbContext _context) : IProductRepository
    {

        public async Task<IEnumerable<Product>> GetListAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);

        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);

        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

                _context.Products.Remove(product);

        }
    }

}
