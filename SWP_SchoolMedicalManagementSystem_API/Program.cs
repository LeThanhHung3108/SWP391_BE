using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Context;
using SWP_SchoolMedicalManagementSystem_BussinessOject.MapperProfile;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Repository;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Service;
using SWP_SchoolMedicalManagementSystem_Repository.Repository;
using SWP_SchoolMedicalManagementSystem_Repository.Repository.Interface;
using SWP_SchoolMedicalManagementSystem_Service.Extension;
using SWP_SchoolMedicalManagementSystem_Service.IService;
using SWP_SchoolMedicalManagementSystem_Service.Repository;
using SWP_SchoolMedicalManagementSystem_Service.Repository.Implementation;
using SWP_SchoolMedicalManagementSystem_Service.Repository.Interface;
using SWP_SchoolMedicalManagementSystem_Service.Service;
using SWP_SchoolMedicalManagementSystem_Service.Service.Interface;
using System.Reflection; // Added for Assembly reference
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(typeof(MapperEntities));

#region AddScope
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITokenGeneratior, TokenGenerator>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IHealthRecordRepository, HealthRecordRepository>();
builder.Services.AddScoped<IHealthRecordService, HealthRecordService>();
builder.Services.AddScoped<IMedicalSupplierRepository, MedicalSuplierRepository>();
builder.Services.AddScoped<IMedicalSupplierService, MedicalSupplierService>();
builder.Services.AddScoped<IMedicalIncidentRepository, MedicalIncidentRepository>();
builder.Services.AddScoped<IMedicalIncidentService, MedicalIncidentService>();
builder.Services.AddScoped<IVaccCampaignRepository, VaccCampaignRepository>();
builder.Services.AddScoped<IVaccCampaignService, VaccCampaignService>();
builder.Services.AddScoped<IVaccScheduleRepository, VaccScheduleRepository>();
builder.Services.AddScoped<IVaccScheduleService, VaccScheduleService>();
builder.Services.AddScoped<IVaccFormRepository, VaccFormRepository>();
builder.Services.AddScoped<IVaccFormService, VaccFormService>();
builder.Services.AddScoped<IMedicationReqRepository, MedicationReqRepository>();
builder.Services.AddScoped<IMedicalRequestService, MedicalRequestService>();
builder.Services.AddScoped<IMedicalDiaryRepository, MedicalDiaryRepository>();
builder.Services.AddScoped<IMedicalDiaryService, MedicalDiaryService>();
#endregion

#region DBContext
IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("server")));
#endregion

#region JWT
var jwtSettings = configuration.GetSection("JWT");
var issuer = jwtSettings["Issuer"];
var audience = jwtSettings["Audience"];
var secretKey = jwtSettings["SecretKey"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = issuer,
            ValidateAudience = true,
            ValidAudience = audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });
#endregion

#region Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo() { Title = "SchoolMedical", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[] { }
    }
    });
    options.MapType<TimeOnly>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "time",
        Example = OpenApiAnyFactory.CreateFromJson("\"13:45:42\"")
    });
});
#endregion

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseCors("AllowAll");

app.Run();
