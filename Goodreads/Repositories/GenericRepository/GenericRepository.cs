using Goodreads.Base;
using Goodreads.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Goodreads.Repositories.GenericRepository
{
    public class GenericRepository<TEntity>: IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly GoodreadsContext _context;
        protected readonly DbSet<TEntity> _entities;

        public GenericRepository(GoodreadsContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }
        //get all
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _entities.AsNoTracking().ToListAsync();

        }

        public IQueryable<TEntity> GetAllAsQueryable()
        {
            return _entities.AsNoTracking();
        }

        //create
        public void Create(TEntity entity)
        {
            _entities.Add(entity);
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
        }

        public void CreateRange(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
        }

        public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            await _entities.AddRangeAsync(entities);
        }

        //update
        public void Update(TEntity entity)
        {
            _entities.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _entities.UpdateRange(entities);
        }

        //delete
        public void Delete(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }

        //find
        public TEntity FindById(Guid id)
        {
            return _entities.Find(id);
        }

        public async Task<TEntity> FindByIdAsync(Guid id)
        {
            return await _entities.FindAsync(id);
        }

        //save
        public bool Save()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (SqlException exp)
            {
                Console.WriteLine(exp.ErrorCode);
            }
            return false;
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (SqlException exp)
            {
                Console.WriteLine(exp.ErrorCode);
            }
            return false;
        }
    }
}

