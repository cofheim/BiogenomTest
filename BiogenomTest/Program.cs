using BiogenomTest.Application.Interfaces;
using BiogenomTest.Application.Services;
using BiogenomTest.Infrastructure;
using BiogenomTest.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// регистрация DbContext
builder.Services.AddDbContext<BiogenomTestDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(BiogenomTestDbContext)));
});

// регистрация репозиториев
builder.Services.AddScoped<INutritionReportRepository, NutritionReportRepository>();

// регистрация сервисов
builder.Services.AddScoped<INutritionReportService, NutritionReportService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// временная строка для теста (проверит существует ли бд если нет создаст)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<BiogenomTestDbContext>();
    dbContext.Database.EnsureCreated();
}

app.Run();
