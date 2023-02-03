using System.ComponentModel.DataAnnotations;

namespace Kolokwium1.Models
{
    public class TaskType
    {
        [Key]
        public int IdTaskType { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
