using System.Text.Json;
namespace Task1.Client.Pages
{
    public partial class Login
    {
        Task1.Client.Models.LoginRequest model = new Models.LoginRequest();


        async Task OnLogin()

        {
            // await AuthService.OnLogin(model);
            //var client = new HttpClient();
            HttpResponseMessage result = await Http.PostAsJsonAsync("api/User/login", model);
            if (result.IsSuccessStatusCode)
            {
                var response = result.Content.ReadAsStringAsync();
                string jsonString = JsonSerializer.Serialize(response.Result);
                NavManager.NavigateTo("/dashboard");
            }
            else
            {
                NavManager.NavigateTo("/login");
            }


        }
    }
}
