using BiogenomTest.Application.Interfaces;
using BiogenomTest.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BiogenomTest.Infrastructure.Repositories;

public class NutritionReportRepository : INutritionReportRepository
{
    private readonly BiogenomTestDbContext _context;

    public NutritionReportRepository(BiogenomTestDbContext context)
    {
        _context = context;
    }

    public async Task<NutritionReport?> GetLatestReportAsync()
    {
        // получаем данные
        var reportEntity = await _context.NutritionReports
            .OrderByDescending(r => r.CreationDate)
            .Include(r => r.Advantages)
            .Include(r => r.CurrentIntake) 
            .Include(r => r.RecommendedSupplements) 
                .ThenInclude(s => s.Nutrients) // инфо о списке нутрентов в БАД
                    .ThenInclude(sn => sn.Nutrient) // инфо о самом нутриенте
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (reportEntity == null)
        {
            return null;
        }


        // маппинги

        var report = NutritionReport.Create(reportEntity.CreationDate).Report;

        // маппинг преимуществ
        reportEntity.Advantages
            .Select(a => Advantage.Create(a.Text).Advantage)
            .ToList()
            .ForEach(report.AddAdvantage);

        // маппинг текущего приёма
        reportEntity.CurrentIntake
            .Select(n => Nutrient.Create(n.Name, n.Unit, n.CurrentValue, n.MinNormalValue, n.MaxNormalValue).Nutrient)
            .ToList()
            .ForEach(report.AddNutrient);

        // маппинг коллекции БАД
        reportEntity.RecommendedSupplements.Select(sEntity => 
        {
            // то же самое что с NutritionReport ранее
            var supplement = Supplement.Create(sEntity.Name, sEntity.Description, sEntity.ImageUrl).Supplement;
            
            // маппинг состава БАД
            sEntity.Nutrients.Select(snEntity => 
                SupplementNutrient.Create(snEntity.NutrientId, snEntity.Amount, snEntity.Nutrient.Unit).supplementNutrient)
                .ToList()
                .ForEach(supplement.AddNutrient); // помещаем состав в БАД
            
            return supplement;
        })
        .ToList()
        .ForEach(report.AddSupplement); // добавляем готовый БАД в отчёт

        return report;
    }
} 