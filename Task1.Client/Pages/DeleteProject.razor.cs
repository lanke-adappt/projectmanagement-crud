using Microsoft.AspNetCore.Components;
using Task1.Shared.Models;

namespace Task1.Client.Pages
{
    public partial class DeleteProject
    {
        [Parameter]
        public int Id { get; set; }
        Project project = new Project();
        protected override async Task OnInitializedAsync()
        {
            project = await Http.GetFromJsonAsync<Project>("http://localhost:5238/api/Project/" + Convert.ToInt32(Id));
        }
        protected async Task RemoveProject(int Id)
        {
            await Http.DeleteAsync("http://localhost:5238/api/Project/" + Id);
            NavigationManager.NavigateTo("/fetchprojectdetails");
        }
        void Cancel()
        {
            NavigationManager.NavigateTo("/fetchprojectdetails");
        }
    }
}
