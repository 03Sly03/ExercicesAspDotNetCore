using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListWebApp.Models
{
    [Table("task")]
    public class MyTask
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Nom")]
        [Column("name")]
        [Required(ErrorMessage ="Té oblijé d'méte 1 nom min gua")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "té con ou koi? ché intre 3 é 30 lette !")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        [Column("description")]
        [Required(ErrorMessage ="Té oblijé d'méte 1 desscripssion min gua")]
        [StringLength(250, ErrorMessage = "té ve nou faire un roman ou koi ?!")]
        public string Description { get; set; }
        [Display(Name = "Statut")]
        [Column("status")]
        public bool Status { get; set; }
        //public TaskStatus Status { get; set;}

        //public enum TaskStatus
        //{
        //    Todo,
        //    InProgress,
        //    Done
        //}

        public MyTask() { }

        public MyTask(string name, string description, bool status = false)
        {
            Status = status;
            Name = name;
            Description = description;
        }
    }
}
