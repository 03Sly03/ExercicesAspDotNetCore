using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashRegister.Models
{
    [Table("category")]
    public class Category
    {
        [Display(Name = "Id")]
        [Column("id")]
        public int Id { get; set; }
        [Display(Name = "Nom")]
        [Column("name")]
        [Required]
        public string? Name { get; set; }
        [Display(Name = "Liste des produits")]
        [Column("products")]

        // relation avec un ou plusieurs produits OneToMany
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
