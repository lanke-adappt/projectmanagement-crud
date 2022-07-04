using Microsoft.AspNetCore.Components;
using Task1.Shared.Models;

namespace Task1.Client.Pages
{
    public partial class AddProjectMapping
    {
        IEnumerable<int> multipleValues = new int[] { };

        string[] colorsSelected = new[] { "white", "1" };

        [Parameter]
        public int Id { get; set; }
        protected string Title = "Add";
        protected ProjectMapping projmap = new ProjectMapping();
        protected Gender gender;
        protected List<Project> projectList = new List<Project>();
        protected List<UserDetails> userDetailList = new List<UserDetails>();

        private void SelectedCarsChanged(ChangeEventArgs e)
        {
            colorsSelected = (string[])e.Value;
            Console.WriteLine(colorsSelected);
        }

        protected override async Task OnParametersSetAsync()
        {
            if (Id != 0)
            {
                Title = "Edit";
                projmap = await Http.GetFromJsonAsync<ProjectMapping>("api/projectmapping/" + Id);
            }
        }
        protected override async Task OnInitializedAsync()
        {

            await GetUserDetails();

        }

        protected async Task GetUserDetails()
        {

            userDetailList = (await Http.GetFromJsonAsync<List<UserDetails>>("api/userdetails")).ToList();

            projectList = (await Http.GetFromJsonAsync<List<Project>>("api/Project")).ToList();
        }

        protected async Task SaveProjMap()
        {
            if (projmap.Id != 0)

            {
                await Http.PutAsJsonAsync("api/projectmapping", projmap);
            }
            else
            {

                await Http.PostAsJsonAsync("api/projectmapping", projmap);
            }
            Cancel();


        }
        public void Cancel()
        {
            NavigationManager.NavigateTo("/fetchprojectmapping");
        }
    }
}
