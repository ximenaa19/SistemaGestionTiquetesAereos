namespace GestionAerolineas.src.Modules.Reservations.Domain.ValueObject;

public sealed record ReservationCode
{
    public string Value { get; }

    private ReservationCode(string value)
    {
        Value = value;
    }

    public static ReservationCode Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El codigo_reserva no puede estar vacio");

        var normalized = Normalize(value);

        if (normalized.Length < 6 || normalized.Length > 30)
            throw new ArgumentException("El codigo_reserva debe tener entre 6 y 30 caracteres");

        if (!normalized.All(ch => char.IsLetterOrDigit(ch)))
            throw new ArgumentException("El codigo_reserva solo puede contener letras y numeros");

        return new ReservationCode(normalized);
    }

    public static ReservationCode? CreateOptional(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;

        return Create(value);
    }

    public static string Normalize(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return string.Empty;

        return value.Trim().ToUpperInvariant();
    }
}

