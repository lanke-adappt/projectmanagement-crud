using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Task1.Client.Data;
using Task1.Client.Services;
using System.Text.Json;
//using Blazorise;
//using Blazorise.Bootstrap;
//using Blazorise.Icons.FontAwesome;
var builder = WebApplication.CreateBuilder(args);


//builder.Services
//    .AddBlazorise(options =>
//    {
//        options.Immediate = true;
//    })
//    .AddBootstrapProviders()
//    .AddFontAwesomeIcons();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5238/") });
HttpClientHandler clientHandler = new HttpClientHandler();
clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

builder.Services.AddHttpClient("Task1.Api", client => client.BaseAddress = new Uri("http://localhost:5238/"));

   



// Supply HttpClient instances that include access tokens when making requests to the server project

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Task1.Api"));
// Pass the handler to httpclient(from you are calling api)
HttpClient client = new HttpClient(clientHandler);
// Add services to the container.
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});
//builder.Services.AddAuthentication(
//    CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie();
// BLAZOR COOKIE Auth Code (end)
// ******
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
//builder.Services.AddScoped<IServices, AuthService>();
//builder.Services.AddSingleton<AuthService>();
builder.Services.AddHttpContextAccessor();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
