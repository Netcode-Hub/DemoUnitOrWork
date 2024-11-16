using DemoUnitOrWork.Models;

namespace DemoUnitOrWork.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetListAsync();
        Task<Category> GetByIdAsync(int id);
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(int id);
    }
}
