
using System.ComponentModel.DataAnnotations;

namespace BiogenomTest.Domain.Models;

/// <summary>
/// представляет БАД
/// </summary>
public class Supplement
{
    private const int MAX_NAME_LENGTH = 150;
    private const int MAX_DESCRIPTION_LENGTH = 500;
    private Supplement() { }
    private Supplement(string name, string description, string imageUrl)
    {
        Name = name;
        Description = description;
        ImageUrl = imageUrl;
    }

    public int Id { get; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string ImageUrl { get; private set; }
    public List<SupplementNutrient> Nutrients { get; private set; } = [];


    public static (Supplement Supplement, string Error) Create(string name, string description, string imageUrl)
    {
        var error = string.Empty;

        if (string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENGTH)
        {
            error = $"Название не может быть пустым или длиннее {MAX_NAME_LENGTH} символов.";
        }
        else if (description.Length > MAX_DESCRIPTION_LENGTH)
        {
            error = $"Описание не может быть длиннее {MAX_DESCRIPTION_LENGTH} символов.";
        }
        else if (!Uri.TryCreate(imageUrl, UriKind.Absolute, out _))
        {
            error = "Некорректный формат URL изображения.";
        }

        if (!string.IsNullOrEmpty(error))
        {
            return (null, error);
        }

        var supplement = new Supplement(name, description, imageUrl);

        return (supplement, string.Empty);
    }
    
    public void AddNutrient(SupplementNutrient supplementNutrient)
    {
        if (supplementNutrient != null)
        {
            Nutrients.Add(supplementNutrient);
        }
    }
}