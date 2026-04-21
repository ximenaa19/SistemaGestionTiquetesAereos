namespace GestionAerolineas.src.Modules.Users.Domain.ValueObject;

public sealed record UserPasswordHash
{
    public string Value { get; }

    private UserPasswordHash(string value)
    {
        Value = value;
    }

    public static UserPasswordHash Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El password hash no puede estar vacio");

        var trimmed = value.Trim();

        if (trimmed.Length > 255)
            throw new ArgumentException("El password hash no puede tener mas de 255 caracteres");

        return new UserPasswordHash(trimmed);
    }
}
