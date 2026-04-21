namespace GestionAerolineas.src.Modules.Users.Domain.ValueObject;

public sealed record UserUsername
{
    public string Value { get; }

    private UserUsername(string value)
    {
        Value = value;
    }

    public static UserUsername Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El username no puede estar vacio");

        var trimmed = value.Trim();

        if (trimmed.Length > 50)
            throw new ArgumentException("El username no puede tener mas de 50 caracteres");

        return new UserUsername(trimmed);
    }

    public static string Normalize(string value)
    {
        return (value ?? string.Empty).Trim().ToUpperInvariant();
    }
}
