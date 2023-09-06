using ContactsWebApplication.Repositories;
using System.Linq.Expressions;
using ToDoListWebApp.Data;
using ToDoListWebApp.Models;

namespace ToDoListWebApp.Repositories
{
    public class MyTaskRepository : IRepository<MyTask>
    {
        private readonly ApplicationDbContext _dbContext;
        public MyTaskRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // CREATE

        public bool Add(MyTask entity)
        {
            var addedEntity = _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return addedEntity.Entity.Id > 0;
        }


        // READ

        public MyTask? GetById(int entityId)
        {
            return _dbContext.Tasks.FirstOrDefault(myTask => myTask.Id == entityId);
        }

        public MyTask? Get(Expression<Func<MyTask, bool>> predicate)
        {
            return _dbContext.Tasks.FirstOrDefault(predicate);
        }

        public List<MyTask> GetAll()
        {
            return _dbContext.Tasks.ToList();
        }
        public List<MyTask> GetAll(Expression<Func<MyTask, bool>> predicate)
        {
            return _dbContext.Tasks
                             .Where(predicate)
                             .ToList();
        }

        // UPDATE

        public bool Update(MyTask myTask)
        {
            var myTaskFromDb = GetById(myTask.Id);

            if (myTaskFromDb == null)
                return false;

            if (myTaskFromDb.Name != myTask.Name)
                myTaskFromDb.Name = myTask.Name;
            if (myTaskFromDb.Description != myTask.Description)
                myTaskFromDb.Description = myTask.Description;

            return _dbContext.SaveChanges() > 0;
        }

        //DELETE
        public bool Delete(int entityId)
        {
            var myTaskToDelete = GetById(entityId);
            if (myTaskToDelete == null)
                return false;

            _dbContext.Tasks.Remove(myTaskToDelete);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
