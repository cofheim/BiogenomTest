
using System.ComponentModel.DataAnnotations;

namespace BiogenomTest.Domain.Models;

/// <summary>
/// Представляет индивидуальный отчет о качестве питания.
/// Является корнем агрегации.
/// </summary>
public class NutritionReport
{
    [Key]
    public int Id { get; private set; }
    
    public DateTime CreationDate { get; private set; }
    
    public List<Nutrient> CurrentIntake { get; private set; } = [];

    public List<Supplement> RecommendedSupplements { get; private set; } = [];
    
    public List<Advantage> Advantages { get; private set; } = [];

    private NutritionReport() { }

    private NutritionReport(DateTime creationDate)
    {
        CreationDate = creationDate;
    }

    public void AddNutrient(Nutrient nutrient)
    {
        if (nutrient != null)
        {
            CurrentIntake.Add(nutrient);
        }
    }

    public void AddSupplement(Supplement supplement)
    {
        if (supplement != null)
        {
            RecommendedSupplements.Add(supplement);
        }
    }
    
    public void AddAdvantage(Advantage advantage)
    {
        if (advantage != null)
        {
            Advantages.Add(advantage);
        }
    }
} 