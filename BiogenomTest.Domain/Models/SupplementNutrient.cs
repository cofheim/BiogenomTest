namespace BiogenomTest.Domain.Models;

/// <summary>
/// описывает содержание нутриента в одной единице БАД
/// связующая сущность между Supplement и Nutrient
/// </summary>
public class SupplementNutrient
{
    private const int MAX_UNIT_LENGTH = 20;

    private SupplementNutrient() { }
    private SupplementNutrient(int nutrientId, double amount, string unit)
    {
        NutrientId = nutrientId;
        Amount = amount;
        Unit = unit;
    }

    public int Id { get; }
    public int NutrientId { get; private set; }
    public double Amount { get; private set; }
    public string Unit { get; private set; }

    public static (SupplementNutrient supplementNutrient, string Error) Create(int nutrientId, double amount, string unit)
    {
        var error = string.Empty;
        if (nutrientId <= 0)
        {
            error = "Идентификатор нутриента должен быть положительным.";
        }
        else if (amount <= 0)
        {
            error = "Количество должно быть положительным.";
        }
        else if (string.IsNullOrEmpty(unit) || unit.Length > MAX_UNIT_LENGTH)
        {
            error = $"Единица измерения не может быть пустой или длиннее {MAX_UNIT_LENGTH} символов.";
        }

        if (!string.IsNullOrEmpty(error))
        {
            return (null, error);
        }

        var supplementNutrient = new SupplementNutrient(nutrientId, amount, unit);
        return (supplementNutrient, string.Empty);
    }
} 