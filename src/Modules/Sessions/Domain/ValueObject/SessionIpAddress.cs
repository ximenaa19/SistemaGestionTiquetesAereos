using System.Net;

namespace GestionAerolineas.src.Modules.Sessions.Domain.ValueObject;

public sealed record SessionIpAddress
{
    public string? Value { get; }

    private SessionIpAddress(string? value)
    {
        Value = value;
    }

    public static SessionIpAddress Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return new SessionIpAddress((string?)null);

        var trimmed = value.Trim();

        if (trimmed.Length > 45)
            throw new ArgumentException("La ip no puede superar 45 caracteres");

        if (!IPAddress.TryParse(trimmed, out _))
            throw new ArgumentException("La ip no tiene un formato valido");

        return new SessionIpAddress(trimmed);
    }
}
