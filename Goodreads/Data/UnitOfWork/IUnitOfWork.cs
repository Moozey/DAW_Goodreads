namespace Goodreads.Data.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        Task<bool> SaveAsync();
    }
}
