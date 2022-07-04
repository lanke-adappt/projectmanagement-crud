using Task1.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Task1.Client.Pages
{
    public partial class ProjectDetails
    {
        [Inject]
        protected HttpClient Http { get; set; }
        protected List<Project> projectList = new();
        protected List<Project> searchProjectData = new();
        protected Project Project = new();
        protected string SearchString { get; set; } = string.Empty;
        protected override async Task OnInitializedAsync()
        {
            await GetProject();
        }
        protected async Task GetProject()
        {
            projectList = await Http.GetFromJsonAsync<List<Project>>("api/Project");
            searchProjectData = projectList;
        }
        protected void FilterProject()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                projectList = searchProjectData
                    .Where(x => x.ProjectName.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) != -1)
                  .ToList();
            }
            else
            {
                projectList = searchProjectData;
            }
        }
        protected void DeleteConfirm(int Id)
        {
            Project = projectList.FirstOrDefault(x => x.Id == Id);
        }
        public void ResetSearch()
        {
            SearchString = string.Empty;
            projectList = searchProjectData;
        }
    }
}
