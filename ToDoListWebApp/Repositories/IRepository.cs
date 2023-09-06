using System.Linq.Expressions;

namespace ContactsWebApplication.Repositories
{
    public interface IRepository<TEntity>
    {
        // CREATE

        bool Add(TEntity entity);

        // READ

        TEntity? GetById(int entityId);
        TEntity? Get(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> GetAll();
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        //UPDATE

        bool Update(TEntity entity);


        //DELETE

        bool Delete(int entityId);
    }
}
