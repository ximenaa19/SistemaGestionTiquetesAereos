namespace GestionAerolineas.src.Modules.Permissions.Domain.ValueObject;

public sealed record PermissionId
{
    public int Value { get; }

    private PermissionId(int value)
    {
        Value = value;
    }

    public static PermissionId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new PermissionId(value);
    }

    public static PermissionId CreateEmpty()
    {
        return new PermissionId(0);
    }
}
