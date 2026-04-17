using System.Text.RegularExpressions;

namespace GestionAerolineas.src.Modules.Continents.Domain.ValueObject;

public sealed record ContinentName
{
    public string Value { get; }

    private ContinentName(string value)
    {
        Value = value;
    }

    public static ContinentName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre no puede estar vacío");

        if (value.Length > 50)
            throw new ArgumentException("Máximo 50 caracteres");

        var regex = new Regex("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$");

        if (!regex.IsMatch(value))
            throw new ArgumentException("Solo letras y espacios");

        return new ContinentName(value.Trim());
    }

    public override string ToString() => Value;
}