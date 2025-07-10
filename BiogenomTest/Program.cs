using BiogenomTest.Infrastructure.Repositories;
using BiogenomTest.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// регистрация DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BiogenomTestDbContext>(options =>
    options.UseNpgsql(connectionString));

// регистрация репозиториев
builder.Services.AddScoped<INutritionReportRepository, NutritionReportRepository>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
