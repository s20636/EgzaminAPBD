using System.ComponentModel.DataAnnotations;

namespace Kolokwium1.Models
{
    public class TeamMember
    {
        [Key]
        public int IdTeamMember { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
