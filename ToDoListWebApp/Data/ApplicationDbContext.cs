using Microsoft.EntityFrameworkCore;
using ToDoListWebApp.Models;

namespace ToDoListWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<MyTask> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            int lastIndex = 0;
            List<MyTask> tasks = new List<MyTask>()
            {
                new MyTask()
                {
                    Id = ++lastIndex,
                    Name = "Vaisselle",
                    Description = "Casser les verres"
                },
                new MyTask()
                {
                    Id = ++lastIndex,
                    Name = "Sport",
                    Description = "Casser des coquilles de cacahuète"
                },
                new MyTask()
                {
                    Id = ++lastIndex,
                    Name = "Jardinage",
                    Description = "Faire le barbecue",
                    Status = true
                }
            };
            modelBuilder.Entity<MyTask>().HasData(tasks);
        }
    }
}
