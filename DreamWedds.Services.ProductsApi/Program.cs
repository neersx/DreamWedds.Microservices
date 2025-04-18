using DreamWedds.Services.ProductsApi.Contexts;
using DreamWedds.Services.ProductsApi.Repository;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add CORS policy
var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>() ?? ["*"];
// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.WithOrigins(allowedOrigins)
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IFoodContext, FoodContext>();
builder.Services.AddScoped<IFoodItemsContext, FoodItemsContext>();
builder.Services.AddScoped<IIngredientsContext, IngredientsContext>();

builder.Services.AddScoped<IFoodMasterRepository, FoodMasterRepository>();
builder.Services.AddScoped<IFoodItemRepository, FoodItemsRepository>();
builder.Services.AddScoped<IIngredientsRepository, IngredientRepository>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Food Menu Services", Version = "v1" });
});


var app = builder.Build();

app.UseCors("AllowSpecificOrigins");


    app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product Service v1");
    c.RoutePrefix = "swagger"; // or "" if you want Swagger at "/"
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
