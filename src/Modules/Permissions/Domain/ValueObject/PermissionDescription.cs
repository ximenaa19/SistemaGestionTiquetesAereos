namespace GestionAerolineas.src.Modules.Permissions.Domain.ValueObject;

public sealed record PermissionDescription
{
    public string? Value { get; }

    private PermissionDescription(string? value)
    {
        Value = value;
    }

    public static PermissionDescription Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return new PermissionDescription((string?)null);

        var trimmed = value.Trim();

        if (trimmed.Length > 200)
            throw new ArgumentException("La descripcion no puede superar 200 caracteres");

        return new PermissionDescription(trimmed);
    }

    public override string ToString() => Value ?? string.Empty;
}
