global using Microsoft.EntityFrameworkCore;
global using Task1.Api.Models;
global using Task1.Api.data;
global using Task1.Api.Services;
global using Task1.Api.Interface;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);


//builder.Services.AddScoped<Serilog.ILogger>((s) =>
//{
//    return new LoggerConfiguration()
//#if DEBUG
//                  .MinimumLevel.Debug()
//#else
//                .MinimumLevel.Information()
//#endif
//                  .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
//       .Enrich.FromLogContext()
//       .WriteTo.Debug()
//       .CreateLogger();
//});



// Add services to the container.
builder.Services.AddDbContext<DataContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IProject, ProjectManager>();
builder.Services.AddTransient<IUserDetails, UserDetailsManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
