using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SimpleProject.ApplicationModels;
using SimpleProject.Db;
using SimpleProject.Extensions;
using SimpleProject.Helpers;
using SimpleProject.Helpers.JwtHelper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.Conventions.Add(new LowercaseControllerConvention()));
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<SimpleProjectDbContext>(opt => opt.UseMySql(builder.Configuration.GetConnectionString("MySqlConnection"), new MySqlServerVersion(new Version(8,3,0)))); 

//builder services add codes below can be moved in extension methods
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "JWT Authorization header using the Bearer scheme",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    };
    c.AddSecurityDefinition("Bearer", securityScheme);

    var securityRequirement = new OpenApiSecurityRequirement
        {
            { securityScheme, new string[] { } }
        };
    c.AddSecurityRequirement(securityRequirement);
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddJwtAuthentication(x => builder.Configuration.GetSection("JwtSettings").Bind(x));

builder.Services.AddTransient<JwtConfiguration>();
builder.Services.AddScoped<RequestContextData>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
