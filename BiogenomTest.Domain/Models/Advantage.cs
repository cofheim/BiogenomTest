
using System.ComponentModel.DataAnnotations;

namespace BiogenomTest.Domain.Models;

/// <summary>
/// Представляет преимущество приема БАДов.
/// </summary>
public class Advantage
{
    private const int MAX_TEXT_LENGTH = 300;
    
    [Key]
    public int Id { get; private set; }
    
    public string Text { get; private set; }

    private Advantage() { }
    
    private Advantage(string text)
    {
        Text = text;
    }

    public static (Advantage Advantage, string Error) Create(string text)
    {
        var error = string.Empty;
        
        if (string.IsNullOrEmpty(text) || text.Length > MAX_TEXT_LENGTH)
        {
            error = $"Текст преимущества не может быть пустым или длиннее {MAX_TEXT_LENGTH} символов.";
        }

        if (!string.IsNullOrEmpty(error))
        {
            return (null, error);
        }

        var advantage = new Advantage(text);

        return (advantage, string.Empty);
    }
} 