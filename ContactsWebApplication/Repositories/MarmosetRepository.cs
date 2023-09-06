using ContactsWebApplication.Data;
using ContactsWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Linq.Expressions;

namespace ContactsWebApplication.Repositories
{
    public class MarmosetRepository : IRepository<Marmoset>
    {
        private readonly ApplicationDbContext _dbContext;

        public MarmosetRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Add(Marmoset entity)
        {
            var addedEntity = _dbContext.Marmosets.Add(entity);
            _dbContext.SaveChanges();
            return addedEntity.Entity.Id > 0;
        }

        public Marmoset? GetById(int entityId)
        {
            return _dbContext.Marmosets.FirstOrDefault(marmoset => marmoset.Id == entityId);
        }

        public Marmoset? Get(Expression<Func<Marmoset, bool>> predicate)
        {
            return _dbContext.Marmosets
                .FirstOrDefault(predicate);
        }

        public List<Marmoset> GetAll()
        {
            return _dbContext.Marmosets.ToList();
        }

        public List<Marmoset> GetAll(Expression<Func<Marmoset, bool>> predicate)
        {
            return _dbContext.Marmosets
                             .Where(predicate)
                             .ToList();
        }

        // UPDATE
        public bool Update(Marmoset marmoset)
        {
        var marmosetFromDb = GetById(marmoset.Id);

            if (marmosetFromDb == null)
                return false;

            if (marmosetFromDb.Name != marmoset.Name)
                marmosetFromDb.Name = marmoset.Name;
            if (marmosetFromDb.Age != marmoset.Age)
                marmosetFromDb.Age = marmoset.Age;

            return _dbContext.SaveChanges() > 0;
        }

        //DELETE
        public bool Delete(int entityId)
        {
            var marmosetToDelete = GetById(entityId);
            if (marmosetToDelete == null)
                return false;

            _dbContext.Marmosets.Remove(marmosetToDelete);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
