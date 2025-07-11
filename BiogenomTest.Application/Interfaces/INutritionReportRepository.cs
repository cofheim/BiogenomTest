using BiogenomTest.Domain.Models;

namespace BiogenomTest.Application.Interfaces;

public interface INutritionReportRepository
{
    Task<NutritionReport?> GetLatestReportAsync();
}