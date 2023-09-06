using ContactsWebApplication.Models;
using System.Linq.Expressions;

namespace ContactsWebApplication.Repositories
{
    public interface IMarmosetRepository
    {
        bool Add(Marmoset entity);
        bool Delete(int entityId);
        Marmoset? Get(Expression<Func<Marmoset, bool>> predicate);
        List<Marmoset> GetAll();
        List<Marmoset> GetAll(Expression<Func<Marmoset, bool>> predicate);
        Marmoset? GetById(int entityId);
    }
}