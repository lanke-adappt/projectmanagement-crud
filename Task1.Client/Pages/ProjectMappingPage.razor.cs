using Microsoft.AspNetCore.Components;
using Task1.Shared.Models;

namespace Task1.Client.Pages
{
    public partial class ProjectMappingPage
    {
        [Inject]
        protected HttpClient Http { get; set; }
        protected List<ProjectMapping> projectMappList = new();
        protected List<ProjectMapping> searchProjMapData = new();
        protected ProjectMapping projectMapping = new();
        protected string SearchString { get; set; } = string.Empty;
        protected Gender gender;
        protected List<Project> projectList = new List<Project>();
        protected List<UserDetails> userDetailList = new List<UserDetails>();
        protected override async Task OnInitializedAsync()
        {
            await GetProjectMappingDetails();
            await GetUserDetails();

        }
        protected async Task GetUserDetails()
        {

            userDetailList = (await Http.GetFromJsonAsync<List<UserDetails>>("api/userdetails")).ToList();

            projectList = (await Http.GetFromJsonAsync<List<Project>>("api/Project")).ToList();




        }
        protected async Task GetProjectMappingDetails()
        {
            projectMappList = await Http.GetFromJsonAsync<List<ProjectMapping>>("api/projectmapping");



            searchProjMapData = projectMappList;

        }

        protected void Filter()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                projectMappList = searchProjMapData
                    .Where(x => x.Note.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) != -1)
                  .ToList();
            }
            else
            {
                projectMappList = searchProjMapData;
            }
        }
        protected void DeleteConfirm(int Id)
        {
            projectMapping = projectMappList.FirstOrDefault(x => x.Id == Id);
        }
        public void ResetSearch()
        {
            SearchString = string.Empty;
            projectMappList = searchProjMapData;
        }

    }
}
