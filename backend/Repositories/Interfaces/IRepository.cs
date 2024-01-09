namespace backend.Repositories.Interfaces
{
    public interface IRepository
    {
        Task<bool> SaveChanges();
    }
}
