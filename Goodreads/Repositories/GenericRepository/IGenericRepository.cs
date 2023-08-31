

using Goodreads.Base;

namespace Goodreads.Repositories.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        //Get all data
        Task<List<TEntity>> GetAllAsync();
        IQueryable<TEntity> GetAllAsQueryable();
        //create
        void Create(TEntity entity);
        Task CreateAsync(TEntity entity);
        void CreateRange(IEnumerable<TEntity> entities);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);
        //update
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        //delete
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        //find
        TEntity FindById(Guid id);
        Task<TEntity> FindByIdAsync(Guid id);
        //save
        bool Save();
        Task<bool> SaveAsync();
    }
}
