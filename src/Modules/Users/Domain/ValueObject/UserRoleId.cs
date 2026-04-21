namespace GestionAerolineas.src.Modules.Users.Domain.ValueObject;

public sealed record UserRoleId
{
    public int Value { get; }

    private UserRoleId(int value)
    {
        Value = value;
    }

    public static UserRoleId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new UserRoleId(value);
    }
}
