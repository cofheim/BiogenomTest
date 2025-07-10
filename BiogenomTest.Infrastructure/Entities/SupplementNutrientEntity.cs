namespace BiogenomTest.Infrastructure.Entities;

public class SupplementNutrientEntity
{
    public int Id { get; set; }
    public double Amount { get; set; }
    public string Unit { get; set; }

    /// <summary>
    /// Внешний ключ для связи с таблицей Supplements
    /// </summary>
    public int SupplementId { get; set; }
    /// <summary>
    /// Навигационное свойство к связанному БАД
    /// </summary>
    public SupplementEntity Supplement { get; set; }

    /// <summary>
    /// Внешний ключ для связи с таблицей Nutrient
    /// </summary>
    public int NutrientId { get; set; }
    /// <summary>
    /// Навигационное свойство к связанному нутриенту
    /// </summary>
    public NutrientEntity Nutrient { get; set; }
} 