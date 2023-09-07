using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace CashRegister.Models
{
    [Table("product")]
    public class Product
    {
        [Display(Name = "Id")]
        [Column("id")]
        public int Id { get; set; }
        [Display(Name = "Nom")]
        [Column("name")]
        [Required]
        public string? Name { get; set; }
        [Display(Name = "Description")]
        [Column("description")]
        [Required]
        public string? Description { get; set; }
        [Display(Name = "prix")]
        [Column("price")]
        [Precision(10, 2)]
        [Required]
        public decimal Price { get; set; }
        [Display(Name = "Quantité")]
        [Column("stock")]
        [Required]
        public int Stock {  get; set; }
        [Display(Name = "Photo du produit")]
        [Column("picture_path")]
        public string? PicturePath {  get; set; }
        // TODO
        // product picture

        // relation avec une seule Category ManyToOne

        [Display(Name = "catégorie")]
        [Column("category_id")]
        [Required]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
