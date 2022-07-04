using Serilog;
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
            catch (Exception ex)
            {
                Log.Error("Error in Fetching object", ex.Message);
                return null;
            }
        }
        public void AddProjectMapping(ProjectMapping projectMapping)
        {
            try
            {
                _dbContext.ProjectMapping.Add(projectMapping);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.Error("Error in Creating object", ex.Message);
                
            }
        }
        public void UpdateProjectMappingDetails(ProjectMapping projectMapping)
        {
            try
            {
                _dbContext.Entry(projectMapping).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.Error("Error in Creating object", ex.Message);
                
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
            catch (Exception ex)
            {
                Log.Error("Error in Getting object", ex.Message);
                return null;

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
            catch (Exception ex)
            {
                Log.Error("Error in Deleting object", ex.Message);
                

            }

        }
    }
}
