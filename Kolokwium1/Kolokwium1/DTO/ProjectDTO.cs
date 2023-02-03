namespace Kolokwium1.DTO
{
    public class ProjectDTO
    {
        public int IdTeam { get; set; }
        public string Name { get; set; }
        public IEnumerable<TaskDTO> Tasks { get; set; }
    }
}
