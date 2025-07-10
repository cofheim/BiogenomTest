
using System.ComponentModel.DataAnnotations;

namespace BiogenomTest.Domain.Models;

/// <summary>
/// представляет индивидуальный отчет о качестве питания
/// </summary>
public class NutritionReport
{
    private NutritionReport(DateTime creationDate)
    {
        CreationDate = creationDate;
    }
    private NutritionReport() { }

    public int Id { get;  }

    public DateTime CreationDate { get; private set; } = DateTime.Now;  

    public List<Nutrient> CurrentIntake { get; private set; } = [];

    public List<Supplement> RecommendedSupplements { get; private set; } = [];

    public List<Advantage> Advantages { get; private set; } = [];



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