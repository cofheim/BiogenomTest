using BiogenomTest.Domain.Models;

namespace BiogenomTest.Infrastructure.Repositories
{
    public interface INutritionReportRepository
    {
        Task<NutritionReport?> GetLatestReportAsync();
    }
}