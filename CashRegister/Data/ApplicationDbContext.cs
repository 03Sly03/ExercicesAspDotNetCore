using CashRegister.Models;
using Microsoft.EntityFrameworkCore;

namespace CashRegister.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            int lastCategoryIndex = 0;

            List<Category> categories = new List<Category>() {
                new Category()
                {
                    Id = ++lastCategoryIndex,
                    Name = "Four"
                },
                new Category()
                {
                    Id= ++lastCategoryIndex,
                    Name = "Mug"
                }
            };

            modelBuilder.Entity<Category>().HasData(categories);

            int lastProductIndex = 0;
            List<Product> products = new List<Product>()
            {
                new Product() {
                    Id = ++lastProductIndex,
                    Name = "Four",
                    Price = 449.99M,
                    Description = "C'est un four à cuir",
                    PicturePath = "https://m.media-amazon.com/images/I/81mP4fmvvLL.__AC_SY300_SX300_QL70_ML2_.jpg",
                    CategoryId = 1
                },
                new Product()
                {
                    Id = ++lastProductIndex,
                    Name = "Micro Onde",
                    Price = 99.99M,
                    Description = "C'est un four à cuir avec des ondes microscopique",
                    PicturePath = "https://m.media-amazon.com/images/I/91EogiCRqfL.__AC_SY300_SX300_QL70_ML2_.jpg",
                    CategoryId = 1
                },
                new Product()
                {
                    Id= ++lastProductIndex,
                    Name = "El Mug",
                    Description = "Un mug mexicain d'exception !",
                    CategoryId = 2
                }
            };
            modelBuilder.Entity<Product>().HasData(products);
        }
    }
}
