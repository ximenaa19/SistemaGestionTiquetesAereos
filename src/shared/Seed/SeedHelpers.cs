using System.Globalization;
using System.Text;

namespace GestionAerolineas.src.shared.Seed;

public static class SeedHelpers
{
    public static string Normalize(string? value)
    {
        var trimmed = (value ?? string.Empty).Trim();
        if (trimmed.Length == 0)
            return string.Empty;

        // Normaliza para que coincida con colaciones MySQL típicas (case/accent-insensitive).
        // Ej: "Crédito" == "Credito"
        var normalized = trimmed.Normalize(NormalizationForm.FormD);
        var sb = new StringBuilder(normalized.Length);

        foreach (var ch in normalized)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                sb.Append(ch);
        }

        return sb
            .ToString()
            .Normalize(NormalizationForm.FormC)
            .ToUpperInvariant();
    }
}
