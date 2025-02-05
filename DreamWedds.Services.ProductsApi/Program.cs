using DreamWedds.Services.ProductsApi.Contexts;
using DreamWedds.Services.ProductsApi.Repository;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy =>
        {
            policy.WithOrigins("https://localhost:7167")
                  .AllowAnyMethod()
                  .AllowAnyHeader();
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

app.UseCors("AllowSpecificOrigin");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
