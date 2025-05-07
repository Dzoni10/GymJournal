using GymJournal.Model;
using GymJournal.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace GymJournal.Infrastructure.Database
{
    public class CrudDatabaseRepository<TEntity, TDbContext> : ICrudRepository<TEntity>
        where TEntity : Entity
        where TDbContext : DbContext
    {
        protected readonly TDbContext DbContext;
        private readonly DbSet<TEntity> dbSet;

        public CrudDatabaseRepository(TDbContext dbContext)
        {
            DbContext = dbContext;
            dbSet = DbContext.Set<TEntity>();
        }

        public PagedResult<TEntity> GetPaged(int page, int pageSize)
        {
            var task = dbSet.GetPagedById(page, pageSize);
            task.Wait();
            return task.Result;
        }

        public TEntity Get(long id)
        {
            var entity = dbSet.Find(id);
            if (entity == null) throw new KeyNotFoundException("Not found: " + id);
            return entity;
        }

        public TEntity Create(TEntity entity)
        {
            dbSet.Add(entity);
            DbContext.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            try
            {
                DbContext.Update(entity);
                DbContext.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new KeyNotFoundException(e.Message);
            }
            return entity;
        }

        public void Delete(long id)
        {
            var entity = Get(id);
            dbSet.Remove(entity);
            DbContext.SaveChanges();
        }

        public List<TEntity> GetMany(List<long> ids)
        {
            return dbSet.Where(e => ids.Contains(e.Id)).ToList();
        }

        public List<TEntity> GeyMany(List<long> ids)
        {
            throw new NotImplementedException();
        }
    }

}
