using System.Text.RegularExpressions;

namespace GestionAerolineas.src.Modules.Permissions.Domain.ValueObject;

public sealed record PermissionName
{
    public string Value { get; }

    private PermissionName(string value)
    {
        Value = value;
    }

    public static PermissionName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre no puede estar vacio");

        if (value.Length > 100)
            throw new ArgumentException("El nombre no puede superar 100 caracteres");

        var regex = new Regex("^[a-zA-Z0-9_ ]+$");

        if (!regex.IsMatch(value))
            throw new ArgumentException("El nombre solo puede contener letras, numeros, espacios y guiones bajos");

        return new PermissionName(value.Trim());
    }

    public override string ToString() => Value;
}
