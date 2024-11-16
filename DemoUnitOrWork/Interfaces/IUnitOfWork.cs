namespace DemoUnitOrWork.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
