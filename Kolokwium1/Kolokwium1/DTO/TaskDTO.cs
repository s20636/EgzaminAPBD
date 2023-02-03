namespace Kolokwium1.DTO
{
    public class TaskDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public TaskTypeDTO TaskType { get; set; }
    }
}
