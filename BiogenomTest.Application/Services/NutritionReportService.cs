using BiogenomTest.Application.DTOS;
using BiogenomTest.Application.Interfaces;
using BiogenomTest.Domain.Models;

namespace BiogenomTest.Application.Services;

public class NutritionReportService : INutritionReportService
{
    private readonly INutritionReportRepository _repository;

    public NutritionReportService(INutritionReportRepository repository)
    {
        _repository = repository;
    }

    public async Task<NutritionReportDto?> GetLatestReportDtoAsync()
    {
        var report = await _repository.GetLatestReportAsync();
        if (report == null)
        {
            return null;
        }
        
        var newIntakeList = CalculateNewIntake(report);

        var dto = new NutritionReportDto
        {
            CreationDate = report.CreationDate,
            Advantages = report.Advantages.Select(a => new AdvantageDto(a.Text)).ToList(),
            RecommendedSupplements = report.RecommendedSupplements.Select(s => new SupplementDto(s.Name, s.Description, s.ImageUrl)).ToList(),
            CurrentIntake = report.CurrentIntake.Select(n => new NutrientDto(n.Name, n.Unit, n.CurrentValue, n.MinNormalValue, n.MaxNormalValue, n.Status.ToString())).ToList(),
            NewIntake = newIntakeList
        };
        
        return dto;
    }

    private List<NutrientDto> CalculateNewIntake(NutritionReport report)
    {
        var newIntakeDict = report.CurrentIntake.ToDictionary(n => n.Id, n => (Nutrient)n.Clone());

        foreach (var supplement in report.RecommendedSupplements)
        {
            foreach (var supNutrient in supplement.Nutrients)
            {
                if (newIntakeDict.TryGetValue(supNutrient.NutrientId, out var nutrientToUpdate))
                {
                    nutrientToUpdate.SetCurrentValue(nutrientToUpdate.CurrentValue + supNutrient.Amount);
                }
            }
        }
        
        return newIntakeDict.Values.Select(n => new NutrientDto(n.Name, n.Unit, n.CurrentValue, n.MinNormalValue, n.MaxNormalValue, n.Status.ToString())).ToList();
    }
} 