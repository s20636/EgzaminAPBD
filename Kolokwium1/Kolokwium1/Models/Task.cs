using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium1.Models
{
    public class Task
    {
        [Key]
        public int IdTask { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public DateTime Deadline { get; set; }
        public int IdTeam { get; set; }
        public int IdTaskType { get; set; }
        public int IdAssignedTo { get; set; }
        public int IdCreator { get; set; }
        [ForeignKey("IdTaskType")]
        public virtual TaskType TaskType { get; set; }
        [ForeignKey("IdAssignedTo")]
        [NotMapped]
        public virtual TeamMember AssignedTo { get; set; }
        [ForeignKey("IdCreator")]
        public virtual TeamMember Creator { get; set; }
        [ForeignKey("IdTeam")]
        public virtual Project Team { get; set; }



    }
}
