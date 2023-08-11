using Inclusive.Planets.Core;
using Inclusive.Planets.Infrastructure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
IConfiguration configuration = builder.Configuration;

// Add services to the container.

// Allowing CORS for all domains and methods
string[] origins = new string[] { "http://localhost:3000" };
services.AddCors(o => o.AddPolicy("default", builder =>
{
    builder.WithOrigins(origins).AllowAnyMethod().AllowAnyHeader().WithExposedHeaders("WWW-Authenticate");
}));

services.AddCoreDependecyInjection();
services.AddInfrastructureDependencyInfection(configuration); // Add Repository Dependency Injection

services.AddHttpContextAccessor();
services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Planets API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable Cors
app.UseCors("default");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
