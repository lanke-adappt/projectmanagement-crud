using Task1.Shared.Models;

namespace Task1.Api.Interface
{
    public interface IProjectMapping
    {
        public List<ProjectMapping> GetProjectMappingDetails();
        public void AddProjectMapping(ProjectMapping projectMapping);
        public void UpdateProjectMappingDetails(ProjectMapping projectMapping);
        public ProjectMapping GetProjectMappingData(int id);
        public void DeleteProjectMapping(int id);
    }
}
