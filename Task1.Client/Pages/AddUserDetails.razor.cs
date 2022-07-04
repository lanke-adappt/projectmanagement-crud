using Microsoft.AspNetCore.Components;
using Task1.Shared.Models;

namespace Task1.Client.Pages
{
    public partial class AddUserDetails
    {
        [Parameter]
        public int Id { get; set; }
        protected string Title = "Add";
        protected UserDetails userDetails = new UserDetails();
        protected Gender gender;

        protected override async Task OnParametersSetAsync()
        {
            if (Id != 0)
            {
                Title = "Edit";
                // userDetails = await Http.GetFromJsonAsync<UserDetails>("api/UserDetails/" + Id);

                userDetails = await Http.GetFromJsonAsync<UserDetails>("api/UserDetails/" + Id);

            }
        }
        protected async Task SaveUser()
        {
            if (userDetails.Id != 0)

            {
                var userdetails1 = new UserDetails
                {
                    Name = userDetails.Name,
                    Designation = userDetails.Designation,
                    DOB = userDetails.DOB,
                    Address = userDetails.Address,
                    Gender = userDetails.Gender,



                };
                await Http.PutAsJsonAsync("api/userdetails", userdetails1);
            }
            else
            {
                var userdetails1 = new UserDetails
                {
                    Name = userDetails.Name,
                    Designation = userDetails.Designation,
                    DOB = userDetails.DOB,
                    Address = userDetails.Address,
                    Gender = userDetails.Gender,
                };
                await Http.PostAsJsonAsync("api/userdetails", userDetails);
            }
            Cancel();
        }
        public void Cancel()
        {
            NavigationManager.NavigateTo("/fetchuserdetails");
        }
    }
}
