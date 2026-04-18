using System.Text.RegularExpressions;

namespace GestionAerolineas.src.Modules.SeatLocationTypes.Domain.ValueObject;

public sealed record SeatLocationTypeName
{
    public string Value { get; }

    private SeatLocationTypeName(string value)
    {
        Value = value;
    }

    public static SeatLocationTypeName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre no puede estar vacío");

        if (value.Length > 50)
            throw new ArgumentException("Máximo 50 caracteres");

        var trimmed = value.Trim();
        var regex = new Regex("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$");

        if (!regex.IsMatch(trimmed))
            throw new ArgumentException("Solo letras y espacios");

        return new SeatLocationTypeName(trimmed);
    }

    public override string ToString() => Value;
}

