using Kolokwium1.DTO;

namespace Kolokwium1.Services
{
    public interface IDbService
    {
        Task<ProjectDTO> GetProject(int IdProject);
        Task AddNewTask(TaskDTO task);
    }
}
