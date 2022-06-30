
using Task1.Client.Models;


namespace Task1.Client.Services
{
     interface IServices
    {
        Task<LoginRequest> OnLogin(LoginRequest request);
    }
   
    
}
