using DemoUnitOrWork.Models;

namespace DemoUnitOrWork.Interfaces
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetListAsync();
        Task<Brand> GetByIdAsync(int id);
        Task AddAsync(Brand brand);
        Task UpdateAsync(Brand brand);
        Task DeleteAsync(int id);
    }
}
