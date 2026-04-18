namespace GestionAerolineas.src.Modules.SystemRoles.Domain.ValueObject;

public sealed record SystemRoleId
{
    public int Value { get; }

    private SystemRoleId(int value)
    {
        Value = value;
    }

    public static SystemRoleId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new SystemRoleId(value);
    }

    public static SystemRoleId CreateEmpty()
    {
        return new SystemRoleId(0);
    }
}
