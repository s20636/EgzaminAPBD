using Kolokwium1.DTO;
using Kolokwium1.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium1.Services
{
    public class DbService : IDbService
    {
        private readonly MainDbContext _context;
        public DbService(MainDbContext context)
        {
            _context = context;
        }

        public System.Threading.Tasks.Task AddNewTask(TaskDTO task)
        {
            throw new NotImplementedException();
        }

        public async Task<ProjectDTO> GetProject(int IdProject)
        {
            return await _context.Projects
               .Where(t => t.IdTeam == IdProject)
               .Include(t => t.Tasks)
               .ThenInclude(t => t.TaskType)
               .Select(t => new ProjectDTO
               {
                   Name = t.Name,
                   IdTeam = t.IdTeam,
                   Tasks = t.Tasks
                   .Where(e => e.IdTeam == t.IdTeam)
                   .Select(e => new TaskDTO { Name = e.Name, Deadline = e.Deadline, Description = e.Description, TaskType = new TaskTypeDTO { Name = e.TaskType.Name}})
                   .OrderByDescending(e => e.Deadline)
                   .ToList()

               }).SingleOrDefaultAsync();

        }
    }
}
