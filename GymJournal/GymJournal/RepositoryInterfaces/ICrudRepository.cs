using GymJournal.Infrastructure;
using GymJournal.Model;

namespace GymJournal.RepositoryInterfaces
{
    public interface ICrudRepository<TEntity> where TEntity : Entity
    {
        TEntity Get(long id);
        TEntity Create(TEntity entity);
        void Delete(long id);
        List<TEntity> GeyMany(List<long> ids);
        PagedResult<TEntity> GetPaged(int page, int pageSize);

        TEntity Update(TEntity entity);

    }
}
