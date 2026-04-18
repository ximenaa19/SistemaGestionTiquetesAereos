using System.Globalization;
using System.Text;

namespace GestionAerolineas.src.Modules.FlightStates.Domain.ValueObject;

public sealed record FlightStateName
{
    private static readonly string[] AllowedCanonicalNames =
    {
        "Programado",
        "Abordando",
        "En vuelo",
        "Cancelado",
        "Completado",
        "Reprogramado"
    };

    public string Value { get; }

    private FlightStateName(string value)
    {
        Value = value;
    }

    public static IReadOnlyCollection<string> AllowedNames => AllowedCanonicalNames;

    public static string AllowedNamesDisplay => string.Join(", ", AllowedCanonicalNames);

    public static FlightStateName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException($"El nombre no puede estar vacio. Valores permitidos: {AllowedNamesDisplay}");

        var canonical = Canonicalize(value);

        if (canonical is null)
            throw new ArgumentException($"Nombre invalido. Valores permitidos: {AllowedNamesDisplay}");

        return new FlightStateName(canonical);
    }

    public static string Normalize(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return string.Empty;

        var trimmed = value.Trim();
        var withoutDiacritics = RemoveDiacritics(trimmed);
        var collapsedSpaces = CollapseSpaces(withoutDiacritics);
        return collapsedSpaces.ToLowerInvariant();
    }

    private static string? Canonicalize(string input)
    {
        var normalized = Normalize(input);

        foreach (var canonical in AllowedCanonicalNames)
        {
            if (Normalize(canonical) == normalized)
                return canonical;
        }

        return null;
    }

    private static string RemoveDiacritics(string text)
    {
        var normalizedFormD = text.Normalize(NormalizationForm.FormD);
        var stringBuilder = new StringBuilder(normalizedFormD.Length);

        foreach (var c in normalizedFormD)
        {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                stringBuilder.Append(c);
        }

        return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
    }

    private static string CollapseSpaces(string text)
    {
        var stringBuilder = new StringBuilder(text.Length);
        bool lastWasSpace = false;

        foreach (var c in text)
        {
            var isSpace = char.IsWhiteSpace(c);
            if (isSpace)
            {
                if (!lastWasSpace)
                    stringBuilder.Append(' ');
                lastWasSpace = true;
            }
            else
            {
                stringBuilder.Append(c);
                lastWasSpace = false;
            }
        }

        return stringBuilder.ToString().Trim();
    }

    public override string ToString() => Value;
}
