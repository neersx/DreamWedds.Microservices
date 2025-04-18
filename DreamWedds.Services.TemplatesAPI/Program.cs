using DreamWedds.Services.TemplatesAPI.Contexts;
using DreamWedds.Services.TemplatesAPI.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ITemplateContext, TemplateContext>();
builder.Services.AddScoped<ITemplateRepository, TemplateRepository>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TemplatesService", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
        // Display Swagger UI at root (/)
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TemplatesService v1");
        c.RoutePrefix = string.Empty; // This makes Swagger UI available at "/"
    });
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
