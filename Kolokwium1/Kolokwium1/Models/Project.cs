using System.ComponentModel.DataAnnotations;

namespace Kolokwium1.Models
{
    public class Project
    {
        [Key]
        public int IdTeam { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public DateTime Deadline { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
