using Microsoft.AspNetCore.Components;
using Task1.Shared.Models;

namespace Task1.Client.Pages
{
    public partial class DeleteProjectMapping
    {
        [Parameter]
        public int Id { get; set; }
        ProjectMapping project = new ProjectMapping();
        protected override async Task OnInitializedAsync()
        {
            project = await Http.GetFromJsonAsync<ProjectMapping>("api/ProjectMapping/" + Convert.ToInt32(Id));
        }
        protected async Task RemoveProjectMapping(int Id)
        {
            await Http.DeleteAsync("http://localhost:5238/api/ProjectMapping/" + Id);
            NavigationManager.NavigateTo("/fetchprojectmapping");
        }
        void Cancel()
        {
            NavigationManager.NavigateTo("/fetchprojectmapping");
        }
    }
}
