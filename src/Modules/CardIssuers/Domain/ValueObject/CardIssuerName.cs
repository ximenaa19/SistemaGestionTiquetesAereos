using System.Text.RegularExpressions;

namespace GestionAerolineas.src.Modules.CardIssuers.Domain.ValueObject;

public sealed record CardIssuerName
{
    public string Value { get; }

    private CardIssuerName(string value)
    {
        Value = value;
    }

    public static CardIssuerName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre no puede estar vacio");

        if (value.Length > 100)
            throw new ArgumentException("Maximo 100 caracteres");

        var trimmed = value.Trim();
        var regex = new Regex("^[a-zA-ZÃ¡Ã©Ã­Ã³ÃºÃÃ‰ÃÃ“ÃšÃ±Ã‘ ]+$");

        if (!regex.IsMatch(trimmed))
            throw new ArgumentException("Solo letras y espacios");

        return new CardIssuerName(trimmed);
    }

    public override string ToString() => Value;
}
