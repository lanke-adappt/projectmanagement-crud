
using Task1.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Task1.Client.Services
{
    public class AuthService : IServices
    {
        private readonly HttpClient _http;

        public AuthService(HttpClient http)
        {
            _http = http;
        }
        public async Task<LoginRequest> OnLogin(LoginRequest request)
        {
            var result = await _http.PostAsJsonAsync("api/user/login", request);
            return await result.Content.ReadFromJsonAsync<LoginRequest>();
        }
    }


}
