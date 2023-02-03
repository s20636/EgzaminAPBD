using Kolokwium1.DTO;
using Kolokwium1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IDbService _service;
        public ProjectController(IDbService service)
        {
            _service = service;
        }

        [HttpGet("{idProject}")]
        public async Task<IActionResult> GetProject(int IdProject)
        {
            var project = await _service.GetProject(IdProject);
            if (project != null)
            {
                return Ok(project);
            }
            return BadRequest("Project not Found");
        }
    }
}
