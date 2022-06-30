using Task1.Shared.Models;
namespace Task1.Api.Interface
{
    public interface IProject
    
        {
        public List<Project> GetProjectDetails();
        public void AddProject(Project project);
        public void UpdateProjectDetails(Project project);
        public Project GetProjectData(int id);
        public void DeleteProject(int id);
    }

}
