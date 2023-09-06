using ContactsWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsWebApplication.Data
{

    public class ApplicationDbContext : DbContext
    {
        //public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions options) : base(options) 
        { 
        }

        public DbSet<Marmoset> Marmosets { get; set; }


        // DAns le cas ou on utilise le OnConfiguring
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\marmoset;Integrated Security=True");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            int lastIndex = 0;
            List<Marmoset> marmosets = new List<Marmoset>()
            {
                new Marmoset() 
                {
                    Id = ++lastIndex,
                    Name = "Poupi",
                    Age = 5
                },
                new Marmoset()
                {
                    Id = ++lastIndex,
                    Name = "Mig",
                    Age = 3
                }
            };
            modelBuilder.Entity<Marmoset>().HasData(marmosets);
        }
    }
}
