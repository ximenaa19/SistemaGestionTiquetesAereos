namespace GestionAerolineas.src.Modules.RolePermissions.Domain.ValueObject;

public sealed record RolePermissionId
{
    public int Value { get; }

    private RolePermissionId(int value)
    {
        Value = value;
    }

    public static RolePermissionId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new RolePermissionId(value);
    }

    public static RolePermissionId CreateEmpty()
    {
        return new RolePermissionId(0);
    }
}

