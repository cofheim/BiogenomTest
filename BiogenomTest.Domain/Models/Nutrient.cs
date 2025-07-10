using BiogenomTest.Domain.Enums;

namespace BiogenomTest.Domain.Models;

/// <summary>
/// представляет нутриент (например, витамин, минерал, вода)
/// </summary>
public class Nutrient
{
    private const int MAX_NAME_LENGTH = 100;
    private const int MAX_UNIT_LENGTH = 20;

    private Nutrient() { }

    private Nutrient(string name, string unit, double currentValue, double minNormalValue, double? maxNormalValue)
    {
        Name = name;
        Unit = unit;
        CurrentValue = currentValue;
        MinNormalValue = minNormalValue;
        MaxNormalValue = maxNormalValue;
    }

    public int Id { get; }
    public string Name { get; private set; }
    public string Unit { get; private set; }
    public double CurrentValue { get; private set; }
    public double MinNormalValue { get; private set; }
    public double? MaxNormalValue { get; private set; }

    public NutrientStatus Status
    {
        get
        {
            if (CurrentValue < MinNormalValue)
                return NutrientStatus.Deficit;

            if (MaxNormalValue.HasValue && CurrentValue > MaxNormalValue.Value)
                return NutrientStatus.Surplus;

            return NutrientStatus.Normal;
        }
    }


    public static (Nutrient Nutrient, string Error) Create(string name, string unit, double currentValue, double minNormalValue, double? maxNormalValue = null)
    {
        var error = string.Empty;

        if (string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENGTH)
        {
            error = $"Название не может быть пустым или длиннее {MAX_NAME_LENGTH} символов.";
        }
        else if (string.IsNullOrEmpty(unit) || unit.Length > MAX_UNIT_LENGTH)
        {
            error = $"Единица измерения не может быть пустой или длиннее {MAX_UNIT_LENGTH} символов.";
        }
        if (minNormalValue <= 0)
        {
            error = "Минимальное нормальное значение должно быть положительным.";
        }
        else if (maxNormalValue.HasValue && maxNormalValue.Value < minNormalValue)
        {
            error = "Максимальное значение не может быть меньше минимального.";
        }
        if (!string.IsNullOrEmpty(error))
        {
            return (null, error);
        }

        var nutrient = new Nutrient(name, unit, currentValue, minNormalValue, maxNormalValue);

        return (nutrient, string.Empty);
    }
}