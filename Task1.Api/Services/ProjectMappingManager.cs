using Task1.Shared.Models;

namespace Task1.Api.Services
{
    public class ProjectMappingManager:IProjectMapping
    {
        readonly DataContext _dbContext;
        public ProjectMappingManager(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<ProjectMapping> GetProjectMappingDetails()
        {
            try
            {
                return _dbContext.ProjectMapping.ToList();
            }
            catch
            {
                throw;
            }
        }
        public void AddProjectMapping(ProjectMapping projectMapping)
        {
            try
            {
                _dbContext.ProjectMapping.Add(projectMapping);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;

            }
        }
        public void UpdateProjectMappingDetails(ProjectMapping projectMapping)
        {
            try
            {
                _dbContext.Entry(projectMapping).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public ProjectMapping GetProjectMappingData(int id)
        {
            try
            {
                ProjectMapping? projectMapping = _dbContext.ProjectMapping.Find(id);
                if (projectMapping != null)
                {
                    return projectMapping;
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
        public void DeleteProjectMapping(int id)
        {
            try
            {
                ProjectMapping? projectMapping = _dbContext.ProjectMapping.Find(id);
                if (projectMapping != null)
                {
                    _dbContext.ProjectMapping.Remove(projectMapping);
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
