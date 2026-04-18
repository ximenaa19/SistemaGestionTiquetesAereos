using System.Text.RegularExpressions;

namespace GestionAerolineas.src.Modules.AvailabilityStatuses.Domain.ValueObject;

public sealed record AvailabilityStatusName
{
    public string Value { get; }

    private AvailabilityStatusName(string value)
    {
        Value = value;
    }

    public static AvailabilityStatusName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre no puede estar vacio");

        if (value.Length > 50)
            throw new ArgumentException("El nombre no puede superar 50 caracteres");

        var regex = new Regex("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$");

        if (!regex.IsMatch(value))
            throw new ArgumentException("El nombre solo puede contener letras y espacios");

        return new AvailabilityStatusName(value.Trim());
    }

    public override string ToString() => Value;
}
