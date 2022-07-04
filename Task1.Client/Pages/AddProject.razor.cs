using Microsoft.AspNetCore.Components;
using Task1.Shared.Models;

namespace Task1.Client.Pages
{
    public partial class AddProject
    {
        [Inject]
        protected HttpClient Http { get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; }
        [Parameter]
        public int Id { get; set; }
        protected string Title = "Add";
        protected Project project = new();
        protected Technologies technologies;
        //public enum Technologies
        //{
        //    JAVA ,
        //    ANGULAR,
        //    DOTNET,
        //    PYTHON

        //}
        protected override async Task OnParametersSetAsync()
        {
            if (Id != 0)
            {
                Title = "Edit";
                project = await Http.GetFromJsonAsync<Project>("api/project/" + Id);
            }
        }
        protected async Task SaveUser()
        {
            if (project.Id != 0)

            {
                var project1 = new Project
                {
                    ProjectName = project.ProjectName,
                    Description = project.Description,
                    ModifiedDate = DateTime.Now,
                    CreatedBy = "satish",
                    ModifiedBy = "satish",
                    Technologies = project.Technologies



                };
                await Http.PutAsJsonAsync("api/project", project1);
            }
            else
            {
                var project1 = new Project
                {
                    ProjectName = project.ProjectName,
                    Description = project.Description,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "satish",
                    ModifiedBy = "satish",
                    Technologies = project.Technologies
                };
                await Http.PostAsJsonAsync("api/project", project1);
            }
            Cancel();
        }
        public void Cancel()
        {
            NavigationManager.NavigateTo("/fetchprojectdetails");
        }
    }
}
