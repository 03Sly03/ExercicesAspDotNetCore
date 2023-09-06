using System.ComponentModel.DataAnnotations;

namespace ContactsWebApplication.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Display(Name = "Nom")]
        public string? Lastname { get; set; }
        [Display(Name = "Prénom")]
        public string? Firstname { get; set; }
        [Display(Name = "Adresse Mail")]
        [RegularExpression(@"[A-Z][a-zA-Z \-]*", ErrorMessage = "Le mail n'est pas valide")]
        public string? Email { get; set; }
        [Display(Name = "Numéro de téléphone")]
        public string? Phone { get; set; }
        [Display(Name = "Adresse")]
        public string? Address { get; set; }
        [Display(Name = "Ville")]
        public string? City { get; set; }
    }
}
