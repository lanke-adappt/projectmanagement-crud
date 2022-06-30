using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task1.Shared.Models;

namespace Task1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProject _IProject;
        public ProjectController(IProject iProject)
        {
            _IProject = iProject;
        }
        [HttpGet]
        public async Task<List<Project>> Get()
        {
            return await Task.FromResult(_IProject.GetProjectDetails());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Project project = _IProject.GetProjectData(id);
            if (project != null)
            {
                return Ok(project);
            }
            return NotFound();
        }
        [HttpPost]
        public void Post(Project project)
        {
            _IProject.AddProject(project);

        }
        [HttpPut]
        public void Put(Project project)
        {
            _IProject.UpdateProjectDetails(project);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _IProject.DeleteProject(id);
            return Ok();
        }

    }
}
