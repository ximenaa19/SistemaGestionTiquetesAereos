namespace GestionAerolineas.src.Modules.SystemRoles.Domain.ValueObject;

public sealed record SystemRoleDescription
{
    public string? Value { get; }

    private SystemRoleDescription(string? value)
    {
        Value = value;
    }

    public static SystemRoleDescription Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return new SystemRoleDescription((string?)null);

        var trimmed = value.Trim();

        if (trimmed.Length > 150)
            throw new ArgumentException("La descripcion no puede superar 150 caracteres");

        return new SystemRoleDescription(trimmed);
    }

    public override string ToString() => Value ?? string.Empty;
}
