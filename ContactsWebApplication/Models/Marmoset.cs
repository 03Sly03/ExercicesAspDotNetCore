using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsWebApplication.Models
{
    [Table("marmoset")]
    public class Marmoset
    {
        [Column("id")]
        [Required]
        public int Id { get; set; }
        [Display(Name = "Nom")]
        [Column("name")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Age")]
        [Column("age")]
        [Required]
        [Range(0, 100, ErrorMessage = "L'age doit être compris entre 0 et 100")]
        public int Age { get; set; }

        public Marmoset() { }

        public Marmoset(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
