using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoListWebApp.Data;
using ToDoListWebApp.Models;

namespace ToDoListWebApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public TodoController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View(_dbContext.Tasks.ToList());
        }

        public IActionResult AddTask()
        {
            return View();
        }

        public IActionResult UpdateTask(int id) 
        {
            var tasksLIst = _dbContext.Tasks.ToList();
            var taskFromDb = tasksLIst.FirstOrDefault(task => task.Id == id);
            if (taskFromDb == null)
            {
                throw new NotImplementedException();
            }
            if (taskFromDb.Status)
                taskFromDb.Status = false;
            else
                taskFromDb.Status = true;
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult SendTask(MyTask task) 
        {
            _dbContext.Tasks.Add(task);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var tasksLIst = _dbContext.Tasks.ToList();
            var taskFromDb = tasksLIst.FirstOrDefault(task => task.Id == id);
            if (taskFromDb == null)
                throw new NotImplementedException();
            _dbContext.Tasks.Remove(taskFromDb);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
            
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}