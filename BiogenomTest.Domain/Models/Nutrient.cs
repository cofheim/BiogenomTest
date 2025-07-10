
using System.ComponentModel.DataAnnotations;

namespace BiogenomTest.Domain.Models;

/// <summary>
/// Представляет нутриент (например, витамин, минерал, вода).
/// </summary>
public class Nutrient
{
    private const int MAX_NAME_LENGTH = 100;
    private const int MAX_UNIT_LENGTH = 20;

    [Key]
    public int Id { get; private set; }
    
    public string Name { get; private set; }

    public string Unit { get; private set; }

    public double CurrentValue { get; private set; }
    
    public double NormalValue { get; private set; }

    private Nutrient() { }
    
    private Nutrient(string name, string unit, double currentValue, double normalValue)
    {
        Name = name;
        Unit = unit;
        CurrentValue = currentValue;
        NormalValue = normalValue;
    }

    public static (Nutrient Nutrient, string Error) Create(string name, string unit, double currentValue, double normalValue)
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
        else if (currentValue < 0)
        {
            error = "Текущее значение не может быть отрицательным.";
        }
        else if (normalValue <= 0)
        {
            error = "Нормальное значение должно быть положительным.";
        }
        
        if (!string.IsNullOrEmpty(error))
        {
            return (null, error);
        }

        var nutrient = new Nutrient(name, unit, currentValue, normalValue);
        
        return (nutrient, string.Empty);
    }
} 