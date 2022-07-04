using Microsoft.AspNetCore.Components;
using Task1.Shared.Models;

namespace Task1.Client.Pages
{
    public partial class DeleteUserDetails
    {
        [Parameter]
        public int Id { get; set; }
        UserDetails userdetails = new UserDetails();
        protected override async Task OnInitializedAsync()
        {
            userdetails = await Http.GetFromJsonAsync<UserDetails>("http://localhost:5238/api/Userdetails/" + Convert.ToInt32(Id));
        }
        protected async Task RemoveProject(int Id)
        {
            await Http.DeleteAsync("http://localhost:5238/api/UserDetails/" + Id);
            NavigationManager.NavigateTo("/fetchuserdetails");
        }
        void Cancel()
        {
            NavigationManager.NavigateTo("/fetchuserdetails");
        }
    }
}
