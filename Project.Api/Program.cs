using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OnTime.EntityFramework.DataBaseContext;
using OnTime.Repository;
using OnTime.User.Services;
using OnTime.Comman.Idenitity;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moujam.Casiher.Comman.Models;
//using OnTime.Module.Logic.Extensions;
using Refit;
//using Mujam.Intergration.Service.Mangment;
using Hangfire;
using StackExchange.Redis;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using OnTime.CrossCutting.Data.Repository;
using OnTime.Lookups.Services.Contracts;
using OnTime.Module.lookup.Mapper;
using OnTime.Lookups.Services.Implementation;
using OnTime.User.Services.Interfaces;
using OnTime.User.Services.Implementation;
using OnTime.CrossCutting.Comman.Time;
using OnTime.User.Services.DTO;
using OnTime.CrossCutting.Comman.Idenitity;

var builder = WebApplication.CreateBuilder(args);
var configuration= builder.Configuration;
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped(typeof(ICrossCuttingRepository<>), typeof(CrossCuttingRepository<>));

builder.Services.AddScoped(typeof(ILookupService<,>), typeof(LookupService<,>));
builder.Services.AddAutoMapper(typeof(LookupMappingProfile));

builder.Services.Configure<JwtOptions>(
builder.Configuration.GetSection("JWT"));

#region Connection String
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


#endregion

#region Identity
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequiredLength = 5;
}).AddDefaultTokenProviders()
.AddEntityFrameworkStores<ApplicationDbContext>();
#endregion
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
           .AddJwtBearer(options =>
           {
               options.SaveToken = true;
               options.RequireHttpsMetadata = false;

               var validIssuers = configuration.GetSection("JWT:ValidIssuers").Get<string[]>();
               var validAudiences = configuration.GetSection("JWT:ValidAudiences").Get<string[]>();

               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = false,
                   //ValidIssuer = configuration["JWT:ValidIssur"],
                //   ValidIssuers = validIssuers,
                   ValidateAudience = false,
                   //ValidAudiences = validAudiences,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
               };
           });
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Name = "Bearer",
                In = ParameterLocation.Header,
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });

});
var baseUrl = builder.Configuration.GetValue<string>("FileSettings:BASE_URL");
baseUrl = baseUrl.Remove(baseUrl.LastIndexOf("/"));
builder.Services.Configure<FileSettings>(builder.Configuration.GetSection("FileSettings"));
//builder.Services.AddRefitClient<IServieMangamentApI>().ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));
#region Dependency Injection
builder.Services.AddInfrastructureServices().

    AddReposetoriesServices();
//builder.Services. AddModuleLogicServices();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});


#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();
app.MapControllers();
app.UseCors("AllowAll");

try
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        try
        {
            var context = services.GetRequiredService<ApplicationDbContext>();

            if (context.Database.IsSqlServer())
            {
                context.Database.Migrate();
            }
            await ApplicationDbcontextSeed.SeedDefaultUserAsync(context,userManager, roleManager);
          

        }
        catch (Exception ex)
        {
        }
    }

  
}
catch (Exception e)
{
}

app.Run();
