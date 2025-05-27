using Microsoft.EntityFrameworkCore;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
#region DBContext
IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("local")));
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
