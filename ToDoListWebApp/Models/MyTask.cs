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
        public string Name { get; set; }
        [Display(Name = "Description")]
        [Column("description")]
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
