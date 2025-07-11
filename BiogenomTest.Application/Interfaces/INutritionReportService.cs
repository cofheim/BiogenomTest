using BiogenomTest.Application.DTOS;

namespace BiogenomTest.Application.Interfaces;

public interface INutritionReportService
{
    Task<NutritionReportDto?> GetLatestReportDtoAsync();
} 