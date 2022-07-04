using Microsoft.AspNetCore.Components;
using Task1.Shared.Models;
using Task1.Api.Interface;

namespace Task1.Client.Pages
{
    public partial class UserDetailsPage
    {
        [Inject]
        public HttpClient Http { get; set; }
        [Inject]
        public IUserDetails userd { get; set; }
        public List<UserDetails> userList = new();
        public List<UserDetails> searchUserData = new();
        public UserDetails UserDetail = new();
        public string SearchString { get; set; } = string.Empty;
       
        protected override async Task OnInitializedAsync()
        {
            await GetUserDetails();
        }
        public async Task GetUserDetails()
        {
         
            
                //userList = await Http.GetFromJsonAsync<List<UserDetails>>("api/UserDetails");
                userList = userd.GetUserDetails();
                searchUserData = userList;
            
           
        }
        protected void FilterUsers()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                userList = searchUserData
                    .Where(x => x.Name.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) != -1)
                  .ToList();
            }
            else
            {
                userList = searchUserData;
            }
        }
        protected void DeleteConfirm(int Id)
        {
            UserDetail = userList.FirstOrDefault(x => x.Id == Id);
        }
        public void ResetSearch()
        {
            SearchString = string.Empty;
            userList = searchUserData;
        }
    }
}
