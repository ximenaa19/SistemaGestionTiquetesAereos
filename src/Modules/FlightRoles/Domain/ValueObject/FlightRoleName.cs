using System.Text.RegularExpressions;

namespace GestionAerolineas.src.Modules.FlightRoles.Domain.ValueObject;

public sealed record FlightRoleName
{
    public string Value { get; }

    private FlightRoleName(string value)
    {
        Value = value;
    }

    public static FlightRoleName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre no puede estar vacío");

        if (value.Length > 100)
            throw new ArgumentException("Máximo 100 caracteres");

        var trimmed = value.Trim();
        var regex = new Regex("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$");

        if (!regex.IsMatch(trimmed))
            throw new ArgumentException("Solo letras y espacios");

        return new FlightRoleName(trimmed);
    }

    public override string ToString() => Value;
}

