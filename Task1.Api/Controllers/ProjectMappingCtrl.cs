using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task1.Shared.Models;

namespace Task1.Api.Controllers
{
    [Route("api/ProjectMapping")]
    [ApiController]
    public class ProjectMappingCtrl : ControllerBase
    {
        private readonly IProjectMapping _IProjectMapping;
        public ProjectMappingCtrl(IProjectMapping iProjectMapping)
        {
            _IProjectMapping = iProjectMapping;
        }
        [HttpGet]
        public async Task<List<ProjectMapping>> Get()
        {
            return await Task.FromResult(_IProjectMapping.GetProjectMappingDetails());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ProjectMapping projectMapping = _IProjectMapping.GetProjectMappingData(id);
            if (projectMapping != null)
            {
                return Ok(projectMapping);
            }
            return NotFound();
        }
        [HttpPost]
        public void Post(ProjectMapping projectMapping)
        {
            _IProjectMapping.AddProjectMapping(projectMapping);

        }
        [HttpPut]
        public void Put(ProjectMapping projectMapping)
        {
            _IProjectMapping.UpdateProjectMappingDetails(projectMapping);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _IProjectMapping.DeleteProjectMapping(id);
            return Ok();
        }

    }
}
