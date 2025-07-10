
using System.ComponentModel.DataAnnotations;

namespace BiogenomTest.Domain.Models;

/// <summary>
/// представляет преимущество приема БАДов
/// </summary>
public class Advantage
{
    private const int MAX_TEXT_LENGTH = 300;
    private Advantage(string text)
    {
        Text = text;
    }
    private Advantage() { }

    public int Id { get; }

    public string Text { get; private set; }



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