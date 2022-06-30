using Task1.Api.Interface;
using Task1.Shared.Models;

namespace Task1.Api.Services
{
    public class ProjectManager:IProject
    {
        readonly DataContext _dbContext;
        public ProjectManager(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Project> GetProjectDetails()
        {
            try
            {
                return _dbContext.Projects.ToList();
            }
            catch
            {
                throw;
            }
        }
        public void AddProject(Project project)
        {
            try
            {
                _dbContext.Projects.Add(project);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;

            }
        }
        public void UpdateProjectDetails(Project project)
        {
            try
            {
                _dbContext.Entry(project).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public Project GetProjectData(int id )
        {
            try
            {
                Project ? project = _dbContext.Projects.Find(id);
                if(project != null)
                {
                    return project;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
        public void DeleteProject(int id)
        {
            try
            {
                Project? project = _dbContext.Projects.Find(id);
                if(project != null)
                {
                    _dbContext.Projects.Remove(project);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();


                }
            }
            catch
            {
                throw;
            }

        }
    }
}
