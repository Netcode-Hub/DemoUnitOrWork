using DemoUnitOrWork.Data;
using DemoUnitOrWork.Interfaces;

namespace DemoUnitOrWork.Repositories
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork, IDisposable
    {
        public void Dispose()
        {
            context.Dispose();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
