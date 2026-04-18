namespace GestionAerolineas.src.Modules.StaffRoles.Domain.ValueObject;

public sealed record StaffRoleId
{
    public int Value { get; }

    private StaffRoleId(int value)
    {
        Value = value;
    }

    public static StaffRoleId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new StaffRoleId(value);
    }

    public static StaffRoleId CreateEmpty()
    {
        return new StaffRoleId(0);
    }
}
